Imports System.Data.SqlClient
Public Class frmConfigDigital
    Private sBandLoad As Boolean
    Private Sub FrmConfigDigital_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sBandLoad = True
        TabRubros.Enabled = False
        Carga_Empresas(cbempresa)
        Carga_EmpreasADW()
        sBandLoad = False
    End Sub

    Private Sub Carga_EmpreasADW()
        Dim cQue As String, cSuc As String
        Dim idSucCrm As Integer, idEmpresaCrm As Integer
        Dim nombreCrm As String
        fError = FC_Conexion()
        If fError <> 0 Then Exit Sub

        dgempresas.Rows.Clear()

        cQue = "SELECT  IDEmpresa, Nombre, IdAdw, Ruta, Sucursal FROM XMLRutasADW"
        Using dCom = New SqlCommand(cQue, FC_Con)
            Using mRs = dCom.ExecuteReader()
                Do While mRs.Read()
                    idEmpresaCrm = 0
                    idSucCrm = 0
                    nombreCrm = ""
                    cSuc = "SELECT idempresacrm,nombrecrm,idsucursalcrm FROM XMLDigSucursal
                                WHERE idempresacont=" & mRs("IDEmpresa") & " AND idempresaadw=" & mRs("IdAdw") & ""
                    Using xCom = New SqlCommand(cSuc, FC_Con)
                        Using xRs = xCom.ExecuteReader()
                            xRs.Read()
                            If xRs.HasRows Then
                                idEmpresaCrm = xRs("idempresacrm")
                                idSucCrm = xRs("idsucursalcrm")
                                nombreCrm = xRs("nombrecrm")
                            End If
                        End Using
                    End Using
                    dgempresas.Rows.Add(mRs("IdAdw"), mRs("IDEmpresa"), idEmpresaCrm, mRs("Ruta"),
                                        idSucCrm, mRs("Nombre"), mRs("Sucursal"), nombreCrm)
                Loop
            End Using
        End Using
        dgempresas.ClearSelection()
    End Sub

    Private Sub Cbempresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbempresa.SelectedIndexChanged
        Dim idEmp As Integer, nombre As String
        If sBandLoad = True Then Exit Sub
        idEmp = CInt(cbempresa.SelectedValue)
        nombre = CStr(cbempresa.Text)
        If idEmp > 0 Then
            Carga_DocModelos(idEmp, nombre)
        End If
    End Sub

    Private Sub Carga_DocModelos(ByVal cID As Integer, ByVal cNombre As String)
        Dim cQue As String, fQue As String, claRubro As String

        cQue = "SELECT rutaadw FROM XMLDigSucursal WHERE idempresacrm=" & cID & ""
        Using cCom = New SqlCommand(cQue, FC_Con)
            Using cRs = cCom.ExecuteReader()
                cRs.Read()
                If cRs.HasRows Then
                    TabRubros.Enabled = True
                    If FC_ConexionFOX(cRs("rutaadw")) <> 0 Then Exit Sub
                    fQue = "SELECT CIDDOCUM01,CDESCRIP01 FROM MGW10007"
                    Using fCom = New Odbc.OdbcCommand(fQue, FC_CONFOX)
                        Using fRs = fCom.ExecuteReader()
                            Do While fRs.Read()
                                claRubro = Strings.Left(Trim(fRs("CDESCRIP01")), 3)
                                dgDocModelos.Rows.Add(claRubro, Menu_Digital_Operacion,
                                                      0, fRs("CIDDOCUM01"), False, Trim(fRs("CDESCRIP01")), "COMPRAS")
                            Loop
                        End Using
                    End Using
                    FC_CONFOX.Close()
                Else
                    MsgBox("No se han enviado sucursales a la empresa." &
                            vbCrLf & cNombre, vbInformation, "Validación")
                    TabRubros.Enabled = False
                End If
            End Using
        End Using
    End Sub
    Private Sub TabConfig_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabConfig.Selecting
        Dim tp As TabPage = e.TabPage

        ' Cancelamos la selección si el control
        ' se encuentra deshabilitado.
        '
        e.Cancel = Not tp.Enabled
    End Sub

    Private Sub dgempresas_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgempresas.CellMouseDoubleClick
        Dim eIDEmpresa As Integer, eSucursal As String, eRuta As String, eIDSuc As Integer
        Dim eIDCon As Integer, eIDAdw As Integer, eNomAdw As String, eNomCrm As String
        eIDEmpresa = CInt(cbempresa.SelectedValue)
        eNomCrm = CStr(cbempresa.Text)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 And eIDEmpresa > 0 Then
            eIDCon = dgempresas.Item(1, e.RowIndex).Value
            eIDAdw = dgempresas.Item(0, e.RowIndex).Value
            eNomAdw = dgempresas.Item(5, e.RowIndex).Value
            eSucursal = dgempresas.Item(6, e.RowIndex).Value
            eRuta = dgempresas.Item(3, e.RowIndex).Value

            If dgempresas.Item(7, e.RowIndex).Value = "" Then
                eIDSuc = Enviar_Sucursal(eIDEmpresa, eSucursal, eRuta, 0)
                If eIDSuc <> 0 Then
                    Guarda_Sucursal(1, eIDCon, eIDAdw, eNomAdw, eSucursal,
                                eRuta, eIDEmpresa, eNomCrm, eIDSuc)
                    Carga_DocModelos(eIDEmpresa, eNomCrm)
                End If
            Else
                MsgBox("La sucursal que selecciono ya esta asociada a una empresa CRM.", vbInformation, "Validación")
            End If
        End If
    End Sub

    Private Function Enviar_Sucursal(ByVal eID As Integer, ByVal eSuc As String, ByVal eRuta As String, ByVal eIDSuc As Integer) As Integer
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String

        Enviar_Sucursal = 0
        dFiltro = "{""Correo"":""" & GL_cUsuarioAPI.Correo & """, ""Contra"":""" &
                    GL_cUsuarioAPI.Contra & """, ""Idempresa"":" & eID & ", ""Sucursal"":""" &
                    eSuc & """, ""Ruta"":""" & Replace(eRuta, "\", "\\") & """,""Idsucursal"":" &
                    eIDSuc & "}"
        dMetodo = "addSucursal"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod = "false" Then
                MsgBox("Error al enviar la sucursal", vbExclamation, "Validación")
            Else
                Enviar_Sucursal = CInt(jsonMod)
            End If
        End If
    End Function

    Private Sub Guarda_Sucursal(gAction As Integer, gIdCon As Integer, gIDAdw As Integer,
                                gNomAdw As String, gSuc As String, gRutaAdw As String,
                                gIDEmpCrm As Integer, gNomCrm As String, gIDSucCrm As Integer)
        Dim cQue As String
        cQue = "IF @action = 1 
                BEGIN
                    IF NOT EXISTS (SELECT * FROM XMLDigSucursal WHERE idempresaadw=@idadw)
                        INSERT INTO XMLDigSucursal(idempresacont,idempresaadw,
                                 nombreadw,sucursal,rutaadw,idempresacrm,nombrecrm, 
                                 idsucursalcrm)VALUES(@Idcon, @idadw, @nomadw, @suc, 
                                 @rutaadw, @idempcrm, @nomcrm, @idsuccrm);
               END
               ELSE
                   DELETE FROM XMLDigSucursal WHERE idempresaadw=@idadw;"
        Using cCom = New SqlCommand(cQue, FC_Con)
            cCom.Parameters.AddWithValue("@action", gAction)
            cCom.Parameters.AddWithValue("@Idcon", gIdCon)
            cCom.Parameters.AddWithValue("@idadw", gIDAdw)
            cCom.Parameters.AddWithValue("@nomadw", gNomAdw)
            cCom.Parameters.AddWithValue("@suc", gSuc)
            cCom.Parameters.AddWithValue("@rutaadw", gRutaAdw)
            cCom.Parameters.AddWithValue("@idempcrm", gIDEmpCrm)
            cCom.Parameters.AddWithValue("@nomcrm", gNomCrm)
            cCom.Parameters.AddWithValue("@idsuccrm", gIDSucCrm)
            cCom.ExecuteNonQuery()
        End Using
    End Sub

End Class