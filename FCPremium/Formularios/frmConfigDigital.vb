Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.IO
Public Class frmConfigDigital
    Private sBandLoad As Boolean
    Private cRubrosConceptos As New Collection
    Private _dtPlanti As DataTable
    Private _GIDEmpresa As Integer
    Private _GIDModelo As Integer
    Private _GIDModulo As Integer
    Private Sub FrmConfigDigital_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 490
        sBandLoad = True
        Carga_Plantillas()
        TabRubros.Enabled = False

        Carga_Empresas(cbempresa)
        Carga_EmpreasADW()
        sBandLoad = False
    End Sub

    Private Sub Carga_Plantillas()
        Dim jsonMod As String, dFiltro As String, dMetodo As String
        Dim dr As DataRow
        _dtPlanti = New DataTable("Plantillas")
        _dtPlanti.Columns.Add("id")
        _dtPlanti.Columns.Add("Nombre")

        dr = _dtPlanti.NewRow
        dr(0) = "0"
        dr(1) = "SELECCIONAR EMPRESA"
        _dtPlanti.Rows.Add(dr)

        dFiltro = "{""Correo"":""" & GL_cUsuarioAPI.Correo & """, ""Contra"":""" &
                    GL_cUsuarioAPI.Contra & """}"
        dMetodo = "Plantillas"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod <> "false" Then
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                For Each Row In jsonObject("plantillas")
                    dr = _dtPlanti.NewRow
                    dr(0) = Row("clave")
                    dr(1) = Row("tipo")
                    _dtPlanti.Rows.Add(dr)
                Next
            End If
        End If
    End Sub

    Private Sub Carga_EmpreasADW()
        Dim cQue As String, cSuc As String
        Dim idSucCrm As Integer, idEmpresaCrm As Integer
        Dim nombreCrm As String

        fError = FC_Conexion()
        If fError <> 0 Then Exit Sub

        dgempresas.Rows.Clear()
        Try
            cQue = "SELECT  POLRutasADW.IDEmpresa,Nombre,IdAdw,Ruta,Sucursal,ctBDD FROM POLRutasADW INNER JOIN 
                            POLEmpresas on POLRutasADW.IDEmpresa = POLEmpresas.IdEmpresa"
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
                                            idSucCrm, mRs("Nombre"), mRs("Sucursal"), nombreCrm, mRs("ctBDD"))
                    Loop
                End Using
            End Using
            dgempresas.ClearSelection()
        Catch ex As Exception
            MsgBox("Error Sistema al Cargar Empresas AminPAQ." & vbCrLf & ex.Message, "Información")
        End Try

    End Sub

    Private Sub Cbempresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbempresa.SelectedIndexChanged
        Dim idEmp As Integer, nombre As String, idDocModelo As Integer, idmodulo As Integer
        If sBandLoad = True Then Exit Sub
        idEmp = CInt(cbempresa.SelectedValue)
        nombre = CStr(cbempresa.Text)
        If idEmp > 0 Then
            If idEmp <> _GIDEmpresa And _GIDEmpresa <> 0 Then
                Enviar_RubrosModel(_GIDEmpresa)
                If dgDocModelos.CurrentRow Is Nothing Then Exit Sub
                If dgDocModelos.CurrentRow.Index >= 0 Then
                    idDocModelo = dgDocModelos.Item(3, dgDocModelos.CurrentCell.RowIndex).Value
                    idmodulo = dgDocModelos.Item(4, dgDocModelos.CurrentCell.RowIndex).Value

                    Envia_rubrosConcepto(_GIDEmpresa, idDocModelo, idmodulo)
                End If
            End If


            _GIDEmpresa = idEmp

                Carga_DocModelos(idEmp, nombre)
                Carga_rubros(idEmp)
                Carga_RubrosConceptos(idEmp)
            End If
    End Sub

    Private Sub Carga_DocModelos(ByVal cID As Integer, ByVal cNombre As String)
        Dim cQue As String, fQue As String, claRubro As String
        Dim conData() As String

        dgDocModelos.Rows.Clear()

        Try
            cQue = "SELECT d.rutaadw,x.ctBDD FROM XMLDigSucursal d
                        INNER JOIN POLEmpresas x ON d.idempresacont=x.IdEmpresa 
                            WHERE d.idempresacrm=" & cID & ""
            Using cCom = New SqlCommand(cQue, FC_Con)
                Using cRs = cCom.ExecuteReader()
                    cRs.Read()
                    If cRs.HasRows Then
                        TabRubros.Enabled = True
                        If FC_ConexionSQL(cRs("ctBDD")) <> 0 Then Exit Sub
                        If FC_ConexionFOX(cRs("rutaadw")) <> 0 Then Exit Sub
                        fQue = "SELECT CIDDOCUM01,CDESCRIP01,CMODULO FROM MGW10007 WHERE CMODULO<>10 order by CMODULO "
                        Using fCom = New Odbc.OdbcCommand(fQue, FC_CONFOX)
                            Using fRs = fCom.ExecuteReader()
                                Do While fRs.Read()
                                    conData = Get_Modulo_SubMenu(fRs("CMODULO"))
                                    claRubro = UCase(Strings.Left(Trim(fRs("CDESCRIP01")), 3))
                                    dgDocModelos.Rows.Add(claRubro, Menu_Digital_Operacion,
                                                          conData(1), fRs("CIDDOCUM01"), fRs("CMODULO"), False, Trim(fRs("CDESCRIP01")), conData(0))
                                Loop
                            End Using
                        End Using
                        FC_CONFOX.Close()
                    Else
                        MsgBox("No se han enviado sucursales a la empresa." &
                                vbCrLf & cNombre, vbInformation, "Validación")
                        TabRubros.Enabled = False
                        dgConceptos.Rows.Clear()
                        TabConfig.SelectedIndex = 0
                    End If
                End Using
            End Using
            'dgDocModelos.ClearSelection()
        Catch ex As Exception
            MsgBox("Error Sistema al Cargar Documentos Modelos." & vbCrLf & ex.Message, "Información")
        End Try

    End Sub

    Private Sub TabConfig_Selecting(sender As Object, e As TabControlCancelEventArgs) Handles TabConfig.Selecting
        Dim tp As TabPage = e.TabPage

        ' Cancelamos la selección si el control
        ' se encuentra deshabilitado.
        '
        e.Cancel = Not tp.Enabled
        If tp.Name = "TabRubros" And tp.Enabled = True Then
            Me.Width = 979
        Else
            Me.Width = 490
        End If
    End Sub

    Private Sub dgempresas_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgempresas.CellMouseDoubleClick
        Dim eIDEmpresa As Integer, eSucursal As String, eRuta As String, eIDSuc As Integer
        Dim eIDCon As Integer, eIDAdw As Integer, eNomAdw As String, eNomCrm As String
        Dim baseContPAQ As String
        eIDEmpresa = CInt(cbempresa.SelectedValue)
        eNomCrm = CStr(cbempresa.Text)
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 And eIDEmpresa > 0 Then
            eIDCon = dgempresas.Item(1, e.RowIndex).Value
            eIDAdw = dgempresas.Item(0, e.RowIndex).Value
            eNomAdw = dgempresas.Item(5, e.RowIndex).Value
            eSucursal = dgempresas.Item(6, e.RowIndex).Value
            eRuta = dgempresas.Item(3, e.RowIndex).Value
            baseContPAQ = dgempresas.Item(8, e.RowIndex).Value

            If dgempresas.Item(7, e.RowIndex).Value = "" Then
                eIDSuc = Enviar_Sucursal(eIDEmpresa, eSucursal, eRuta, 0, eIDAdw)
                If eIDSuc <> 0 Then
                    Guarda_Sucursal(1, eIDCon, eIDAdw, eNomAdw, eSucursal,
                                eRuta, eIDEmpresa, eNomCrm, eIDSuc)
                    CreaTablas_contpaq(baseContPAQ)
                    Carga_DocModelos(eIDEmpresa, eNomCrm)
                    Carga_EmpreasADW()
                End If
            Else
                MsgBox("La sucursal que selecciono ya esta asociada a una empresa CRM.", vbInformation, "Validación")
            End If
        End If
    End Sub

    Private Function Enviar_Sucursal(ByVal eID As Integer, ByVal eSuc As String, ByVal eRuta As String, ByVal eIDSuc As Integer, ByVal eIDAdw As Integer) As Integer
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String

        Enviar_Sucursal = 0
        dFiltro = "{""Correo"":""" & GL_cUsuarioAPI.Correo & """, ""Contra"":""" &
                    GL_cUsuarioAPI.Contra & """, ""Idempresa"":" & eID & ", ""Sucursal"":""" &
                    eSuc & """, ""Ruta"":""" & Replace(eRuta, "\", "\\") & """,""idAdw"":" & eIDAdw & ", ""Idsucursal"":" &
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
        Try
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
        Catch ex As Exception
            MsgBox("Error Sistema al Guardar sucursal" & vbCrLf & ex.Message, "Información")
        End Try

    End Sub

    Private Sub dgDocModelos_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgDocModelos.CurrentCellChanged
        Dim cIDDocModelo As Integer, eIDEmpresa As Integer, cIDModulo As Integer
        If dgDocModelos.CurrentRow Is Nothing Then Exit Sub
        If dgDocModelos.CurrentRow.Index >= 0 Then
            cIDDocModelo = dgDocModelos.Item(3, dgDocModelos.CurrentRow.Index).Value
            cIDModulo = dgDocModelos.Item(4, dgDocModelos.CurrentCell.RowIndex).Value
            eIDEmpresa = CInt(cbempresa.SelectedValue)
            If eIDEmpresa > 0 Then

                If _GIDModelo <> cIDDocModelo And _GIDModelo <> 0 And _GIDModulo <> 0 Then
                    Envia_rubrosConcepto(eIDEmpresa, _GIDModelo, _GIDModulo)
                End If
                _GIDModelo = cIDDocModelo
                _GIDModulo = cIDModulo

                Carga_ConceptosADW(eIDEmpresa, cIDDocModelo)
                Carga_ConceptosExcluidos(cIDDocModelo)
                MarcaConceptos_Enviados(cIDDocModelo)
            End If
        End If
    End Sub



    Private Sub Carga_ConceptosADW(ByVal cID As Integer, ByVal iddocModel As Integer)
        Dim cQue As String, str As String, clave As String
        Dim combobox As DataGridViewComboBoxCell

        dgConceptos.Rows.Clear()

        Try
            cQue = "SELECT rutaadw,sucursal FROM XMLDigSucursal WHERE idempresacrm=" & cID & ""
            Using cCom = New SqlCommand(cQue, FC_Con)
                Using cRs = cCom.ExecuteReader()
                    Do While cRs.Read
                        If FC_ConexionFOX(cRs("rutaadw")) <> 0 Then Exit Sub
                        str = "SELECT CCODIGOC01,CNOMBREC01 FROM MGW10006 WHERE CIDDOCUM01=" & iddocModel & ""
                        Using fCom = New Odbc.OdbcCommand(str, FC_CONFOX)
                            Using fRs = fCom.ExecuteReader()
                                Do While fRs.Read()
                                    clave = UCase(Strings.Left(fRs("CNOMBREC01"), 3))
                                    dgConceptos.Rows.Add(Trim(fRs("CCODIGOC01")),
                                                              True, cRs("sucursal"), Trim(fRs("CNOMBREC01")), False, clave, "")
                                    combobox = dgConceptos.Rows(dgConceptos.Rows.Count - 1).Cells(6)


                                    combobox.DataSource = _dtPlanti
                                    combobox.DisplayMember = "nombre"
                                    combobox.ValueMember = "id"
                                Loop
                            End Using
                        End Using
                        FC_CONFOX.Close()
                    Loop
                End Using
            End Using
            'dgConceptos.ClearSelection()
        Catch ex As Exception
            MsgBox("Error Sistema al Cargar Concepto AdminPAQ" & vbCrLf & ex.Message, "Información")
        End Try
    End Sub



    Private Function Get_Modulo_SubMenuCon(ByVal cIDModulo As Integer) As Integer
        Dim IDSub As Integer

        IDSub = 0
        Select Case cIDModulo
            Case 2, 5
                IDSub = 17
            Case 1, 3
                IDSub = 18
            Case 6
                IDSub = 19
            Case 4
                IDSub = 28
            Case 7, 8, 9, 11
                IDSub = 30
        End Select

        Get_Modulo_SubMenuCon = IDSub
    End Function

    Private Sub Enviar_RubrosAPI(ByVal eRubros As String, ByVal eID As Integer)
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String

        dFiltro = "{""Correo"":""" & GL_cUsuarioAPI.Correo & """, ""Contra"":""" &
                    GL_cUsuarioAPI.Contra & """, ""Idempresa"":" & eID & ",""Rubros"":[" & eRubros & "]}"
        dMetodo = "addRubros"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod = "false" Then
                MsgBox("Error al enviar la los Rubros", vbExclamation, "Validación")
            End If
        End If
    End Sub

    Private Sub Carga_rubros(ByVal eID As Integer)
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String

        dFiltro = "{""Correo"":""" & GL_cUsuarioAPI.Correo & """, ""Contra"":""" &
                    GL_cUsuarioAPI.Contra & """, ""Idempresa"":" & eID & ",""idmenu"":" & Menu_Digital_Operacion & "}"
        dMetodo = "datosRubros"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod = "false" Then
                MsgBox("Error al cargar los Rubros del CRM", vbExclamation, "Validación")
            Else
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                For Each Row In jsonObject("Rubros")
                    For Each Fila As DataGridViewRow In dgDocModelos.Rows
                        If Fila.Cells(0).Value = CStr(Row("clave")) And Fila.Cells(2).Value = CInt(Row("idsubmenu")) Then
                            Fila.Cells(5).Value = IIf(CStr(Row("status")) = 1, True, False)
                        End If
                    Next
                Next
            End If
        End If
    End Sub

    Private Sub btnenvia_Click(sender As Object, e As EventArgs) Handles btnenvia.Click
        Dim eIDEmpresa As Integer
        eIDEmpresa = CInt(cbempresa.SelectedValue)
        Enviar_RubrosModel(eIDEmpresa, True)
    End Sub

    Private Sub Enviar_RubrosModel(ByVal eIDEmpresa As Integer, ByVal Optional eMensaje As Boolean = False)
        Dim Rubros As String = ""

        If eIDEmpresa = 0 Then Exit Sub
        For Each Fila As DataGridViewRow In dgDocModelos.Rows
            Rubros = IIf(Rubros <> "", Rubros & ",", Rubros)
            Rubros = Rubros & "{""clave"":""" & Fila.Cells(0).Value & """,""nombre"":""" &
                    Fila.Cells(6).Value & """,""tipo"":" & Fila.Cells(3).Value & ",""status"":" &
                    IIf(Fila.Cells(5).Value, 1, 0) & ",""idmenu"":" & Fila.Cells(1).Value & ",""idsubmenu"":" &
                    Fila.Cells(2).Value & ",""activo"":" & IIf(Fila.Cells(5).Value, 1, 0) & ", ""plantilla"": ""0""}"
        Next
        If Rubros <> "" And eIDEmpresa > 0 Then
            Enviar_RubrosAPI(Rubros, eIDEmpresa)
            If eMensaje Then
                MsgBox("Rubros Enviados.", vbInformation, "Información")
            End If
        End If
    End Sub

    Private Sub dgConceptos_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgConceptos.CurrentCellDirtyStateChanged
        Dim didDocMo As Integer, dSuc As String, dCodCon As String, dNomCon As String
        RemoveHandler dgConceptos.CurrentCellDirtyStateChanged,
            AddressOf dgConceptos_CurrentCellDirtyStateChanged

        If TypeOf dgConceptos.CurrentCell Is DataGridViewCheckBoxCell And dgConceptos.CurrentCell.ColumnIndex = 1 Then
            dgConceptos.EndEdit()
            Dim Checked As Boolean = CType(dgConceptos.CurrentCell.Value, Boolean)

            didDocMo = dgDocModelos.Item(3, dgDocModelos.CurrentCell.RowIndex).Value
            dSuc = dgConceptos.Item(2, dgConceptos.CurrentCell.RowIndex).Value
            dCodCon = dgConceptos.Item(0, dgConceptos.CurrentCell.RowIndex).Value
            dNomCon = dgConceptos.Item(3, dgConceptos.CurrentCell.RowIndex).Value
            Guarda_ConceptoExcluido(didDocMo, dSuc, dCodCon, dNomCon)

            'If Checked Then
            '    MessageBox.Show("You have checked")
            'Else
            '    MessageBox.Show("You have un-checked")
            'End If
        End If

        AddHandler dgConceptos.CurrentCellDirtyStateChanged,
            AddressOf dgConceptos_CurrentCellDirtyStateChanged
    End Sub

    Private Sub Guarda_ConceptoExcluido(ByVal gIDDocMo As Integer, ByVal gSuc As String, ByVal gCodCon As String, ByVal gNomCon As String)
        Dim cQue As String

        cQue = "IF NOT EXISTS (SELECT * FROM XMLDigConceptos WHERE sucursal=@suc AND codconcepto=@codcon)
                      BEGIN INSERT INTO XMLDigConceptos(IDDocmodelo,sucursal,codconcepto,
                                nomconcepto)VALUES(@IdDocMo, @suc, @codcon, @nomcon) END
               ELSE BEGIN DELETE FROM XMLDigConceptos 
                    WHERE sucursal=@suc AND codconcepto=@codcon END"
        Using cCom = New SqlCommand(cQue, FC_SQL)
            cCom.Parameters.AddWithValue("@IdDocMo", gIDDocMo)
            cCom.Parameters.AddWithValue("@suc", gSuc)
            cCom.Parameters.AddWithValue("@codcon", gCodCon)
            cCom.Parameters.AddWithValue("@nomcon", gNomCon)
            cCom.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub Carga_ConceptosExcluidos(ByVal cID As Integer)
        Dim cQue As String

        cQue = "SELECT sucursal,codconcepto,nomconcepto FROM XMLDigConceptos 
                    WHERE IDDocmodelo=" & cID & ""
        Using cCom = New SqlCommand(cQue, FC_SQL)
            Using cRs = cCom.ExecuteReader()
                Do While cRs.Read
                    For Each Fila As DataGridViewRow In dgConceptos.Rows
                        If Fila.Cells(0).Value = cRs("codconcepto") And Fila.Cells(2).Value = cRs("sucursal") Then
                            Fila.Cells(1).Value = False
                            Exit For
                        End If
                    Next
                Loop
            End Using
        End Using

    End Sub

    Private Sub btnEnviaCon_Click(sender As Object, e As EventArgs) Handles btnEnviaCon.Click
        Dim eIDEmpresa As Integer, idDocModelo As Integer, idmodulo As Integer
        eIDEmpresa = CInt(cbempresa.SelectedValue)

        idDocModelo = dgDocModelos.Item(3, dgDocModelos.CurrentCell.RowIndex).Value
        idmodulo = dgDocModelos.Item(4, dgDocModelos.CurrentCell.RowIndex).Value

        Envia_rubrosConcepto(eIDEmpresa, idDocModelo, idmodulo, True)
    End Sub

    Private Sub Envia_rubrosConcepto(ByVal eIDEmpresa As Integer, idDocModelo As Integer,
                                        idmodulo As Integer, Optional eMensaje As Boolean = False)
        Dim Rubros As String = "", idSubMe As Integer

        If eIDEmpresa = 0 Then Exit Sub
        idSubMe = Get_Modulo_SubMenuCon(idmodulo)

        For Each Fila As DataGridViewRow In dgConceptos.Rows
            If Fila.Cells(4).Value = False Or (Fila.Cells(6).FormattedValue.ToString <> "" And Fila.Cells(6).Value <> "0") Then
                Rubros = IIf(Rubros <> "", Rubros & ",", Rubros)
                Rubros = Rubros & "{""clave"":""" & Fila.Cells(0).Value & """,""nombre"":""" &
                        Fila.Cells(3).Value & """,""tipo"":" & idDocModelo & ",""status"":" &
                        IIf(Fila.Cells(4).Value, 1, 0) & ",""idmenu"":" & Menu_Recepcion_Lotes & ",""idsubmenu"":" &
                        idSubMe & ",""activo"":" & IIf(Fila.Cells(4).Value, 1, 0) & ", ""plantilla"":""" &
                        Fila.Cells(6).Value & """}"
            End If
        Next
        If Rubros <> "" And eIDEmpresa > 0 Then
            Enviar_RubrosAPI(Rubros, eIDEmpresa)
            Carga_RubrosConceptos(eIDEmpresa)
            If eMensaje Then
                MsgBox("Rubros Enviados.", vbInformation, "Información")
            End If
        End If
    End Sub


    Private Sub Carga_RubrosConceptos(ByVal eID As Integer)
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String, r As clRubro

        cRubrosConceptos = Nothing
        cRubrosConceptos = New Collection
        dFiltro = "{""Correo"":""" & GL_cUsuarioAPI.Correo & """, ""Contra"":""" &
                    GL_cUsuarioAPI.Contra & """, ""Idempresa"":" & eID & ",""idmenu"":" & Menu_Recepcion_Lotes & "}"
        dMetodo = "datosRubros"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod = "false" Then
                MsgBox("Error al cargar los Rubros(Conceptos) del CRM", vbExclamation, "Validación")
            Else
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                For Each Row In jsonObject("Rubros")
                    For Each Fila As DataGridViewRow In dgDocModelos.Rows
                        r = New clRubro
                        r.Id = CInt(Row("id"))
                        r.Clave = CStr(Row("clave"))
                        r.Nombre = CStr(Row("nombre"))
                        r.Tipo = CInt(Row("tipo"))
                        r.Status = CInt(Row("status"))
                        r.Idmenu = CInt(Row("idmenu"))
                        r.Idsubmenu = CInt(Row("idsubmenu"))
                        r.Claveplantilla = CStr(Row("claveplantilla"))
                        cRubrosConceptos.Add(r)
                    Next
                Next
            End If
        End If
    End Sub

    Private Sub MarcaConceptos_Enviados(ByVal mIDDodModelo As Integer)
        Dim r As clRubro

        For Each r In cRubrosConceptos
            If r.Status = 1 Then
                For Each Fila As DataGridViewRow In dgConceptos.Rows
                    If mIDDodModelo = r.Tipo And Fila.Cells(0).Value = r.Clave And Fila.Cells(3).Value = r.Nombre Then
                        Fila.Cells(4).Value = True
                        Fila.Cells(6).Value = r.Claveplantilla
                        Exit For
                    End If
                Next
            End If
        Next

    End Sub

    Private Sub frmConfigDigital_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim eIDEmpresa As Integer
        eIDEmpresa = CInt(cbempresa.SelectedValue)
        Enviar_RubrosModel(eIDEmpresa)
    End Sub

    Private Sub dgempresas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgempresas.CellContentClick

    End Sub
End Class