Imports System.Data.SqlClient

Public Class frmAddDoc
    Private _idsubme As Integer
    Private _rfcempresa As String
    Private _gridDatos As DataGridView
    Private _suc As String
    Public Property IDSubme As Integer
        Get
            Return _idsubme
        End Get
        Set(value As Integer)
            _idsubme = value
        End Set
    End Property
    Public Property Rfcempresa As String
        Get
            Return _rfcempresa
        End Get
        Set(value As String)
            _rfcempresa = value
        End Set
    End Property

    Public Property GridDatos As DataGridView
        Get
            Return _gridDatos
        End Get
        Set(value As DataGridView)
            _gridDatos = value
        End Set
    End Property

    Public Property Suc As String
        Get
            Return _suc
        End Get
        Set(value As String)
            _suc = value
        End Set
    End Property

    Private _CargandoDatos As Boolean

    Private Sub frmAddDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _CargandoDatos = True
        Carga_Conceptos()
        _CargandoDatos = False
    End Sub

    Private Sub Carga_Conceptos()
        Dim dt As DataTable
        Dim dr As DataRow
        dt = New DataTable("conceptos")
        dt.Columns.Add("id")
        dt.Columns.Add("Nombre")

        dr = dt.NewRow
        dr(0) = -1
        dr(1) = "SELECCIONAR CONCEPTO"
        dt.Rows.Add(dr)

        If _idsubme <> 15 Then
            dr = dt.NewRow
            dr(0) = 15
            dr(1) = "COMPRAS"
            dt.Rows.Add(dr)
        End If
        If _idsubme <> 16 Then
            dr = dt.NewRow
            dr(0) = 16
            dr(1) = "VENTAS"
            dt.Rows.Add(dr)
        End If

        If _idsubme <> 23 Then
            dr = dt.NewRow
            dr(0) = 23
            dr(1) = "PAGOS"
            dt.Rows.Add(dr)
        End If

        If _idsubme <> 24 Then
            dr = dt.NewRow
            dr(0) = 24
            dr(1) = "COBROS"
            dt.Rows.Add(dr)
        End If

        If _idsubme <> 26 Then
            dr = dt.NewRow
            dr(0) = 26
            dr(1) = "INVENTARIOS"
            dt.Rows.Add(dr)
        End If

        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "BANCOS"
        dt.Rows.Add(dr)

        cbConcepAdw.DataSource = dt
        cbConcepAdw.ValueMember = "id"
        cbConcepAdw.DisplayMember = "Nombre"
    End Sub

    Private Sub cbConcepAdw_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbConcepAdw.SelectedIndexChanged
        Dim dIDSub As Integer
        If _CargandoDatos = True Then Exit Sub
        dIDSub = cbConcepAdw.SelectedValue
        If dIDSub = 0 Then
            Carga_Bancos()
        Else
            Carga_Doctos()
        End If
    End Sub

    Private Sub Carga_Doctos()
        Dim dDatos() As String, dIDSub As Integer
        Dim idModulo As String, fQue As String, fecha As String

        dIDSub = cbConcepAdw.SelectedValue

        dgDocAdw.Rows.Clear()

        fecha = Format(CDate(dtFecha.Value), "yyyy-MM-dd")
        dDatos = Get_IDs_cModulos(dIDSub)
        For Each idModulo In dDatos
            fQue = "SELECT MGW10008.CIDDOCUM01,CFECHA,CSERIEDO01,CFOLIO,
                        CRAZONSO01,CTOTAL,CREFEREN01,CPLURAL,MGW10006.CCODIGOC01,MGW10006.CNOMBREC01 FROM MGW10008 
                        INNER JOIN MGW10006 ON MGW10008.CIDCONCE01=MGW10006.CIDCONCE01
                        INNER JOIN MGW10034 ON MGW10008.CIDMONEDA=MGW10034.CIDMONEDA
                        INNER JOIN MGW10007 ON MGW10008.CIDDOCUM02=MGW10007.CIDDOCUM01
                        WHERE CMODULO=" & CInt(idModulo) & " AND CFECHA={d '" & fecha & "'}  ORDER BY CFECHA DESC"
            Using fCom = New Odbc.OdbcCommand(fQue, FC_CONFOX)
                Using fRs = fCom.ExecuteReader()
                    Do While fRs.Read
                        dgDocAdw.Rows.Add(fRs("CIDDOCUM01"), Trim(fRs("CNOMBREC01")),
                                                      Format(fRs("CFECHA"), "yyyy-MM-dd"), Trim(fRs("CSERIEDO01")), fRs("CFOLIO"),
                                                      Trim(fRs("CRAZONSO01")), fRs("CTOTAL"),
                                                      Trim(fRs("CREFEREN01")), Trim(fRs("CPLURAL")))
                    Loop
                End Using
            End Using
        Next
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub


    Private Sub dgDocAdw_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDocAdw.CellContentDoubleClick
        Dim idDoc As Long, idsub As Integer, i As Integer
        With dgDocAdw
            If .CurrentRow Is Nothing Then Exit Sub
            If .CurrentRow.Index >= 0 Then
                i = .CurrentRow.Index
                idDoc = .Item(0, i).Value
                idsub = cbConcepAdw.SelectedValue
                If Exist_list(idDoc, idsub) = False Then
                    dglistadoc.Rows.Add(.Item(0, i).Value, idsub, .Item(1, i).Value,
                              .Item(2, i).Value, .Item(3, i).Value,
                              .Item(4, i).Value, .Item(5, i).Value, .Item(6, i).Value)
                End If
            End If
        End With
    End Sub

    Private Function Exist_list(ByVal dIDdoc As Long, ByVal dIDSub As Integer) As Boolean

        Dim sExiste As Boolean
        sExiste = False
        For Each Fila As DataGridViewRow In dglistadoc.Rows
            If Fila.Cells(0).Value = dIDdoc And Fila.Cells(1).Value = dIDSub Then
                sExiste = True
                Exit For
            End If
        Next
        Return sExiste
    End Function

    Private Sub Busca_dato(ByVal cTexto As String, ByVal cAdd As Boolean, fil As Integer)
        Dim cont As Integer
        cont = 0
BuscaInicio:
        If cont = 2 Then Exit Sub
        If cAdd = True Then
            For Each Fila As DataGridViewRow In dgDocAdw.Rows
                If Fila.Index > fil Then
                    For t = 1 To 6
                        If InStr(UCase(Fila.Cells(t).Value), UCase(cTexto), CompareMethod.Text) <> 0 Then
                            Fila.Selected = True
                            dgDocAdw.CurrentCell = Fila.Cells(2)
                            Exit Sub
                        End If
                    Next
                End If
            Next
            fil = 0
            cont += 1
        Else
            For x = dgDocAdw.Rows.Count - 1 To 0 Step -1
                If x < fil Then
                    For t = 1 To 6
                        If InStr(UCase(CStr(dgDocAdw.Item(t, x).Value)), UCase(cTexto), CompareMethod.Text) <> 0 Then
                            dgDocAdw.Rows(x).Selected = True
                            dgDocAdw.CurrentCell = dgDocAdw.Rows(x).Cells(2)
                            Exit Sub
                        End If
                    Next
                End If
            Next
            fil = dgDocAdw.Rows.Count - 1
            cont += 1
        End If
        GoTo BuscaInicio
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Dim fil As Integer
        If txtbusca.Text <> "" Then
            If dgDocAdw.CurrentRow Is Nothing Then
                fil = 0
            Else
                fil = dgDocAdw.CurrentRow.Index
            End If
            Busca_dato(txtbusca.Text, True, fil)
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Dim fil As Integer
        If txtbusca.Text <> "" Then
            If dgDocAdw.CurrentRow Is Nothing Then
                fil = 0
            Else
                fil = dgDocAdw.CurrentRow.Index
            End If
            Busca_dato(txtbusca.Text, False, fil)
        End If
    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged
        Dim dIDSub As Integer
        If _CargandoDatos = True Then Exit Sub
        dIDSub = cbConcepAdw.SelectedValue
        If dIDSub = 0 Then
            Carga_Bancos()
        Else
            Carga_Doctos()
        End If
    End Sub

    Private Sub Guarda_Otro(ByVal esOtro As Integer)
        Dim aSuc As String, aIDAdw As Integer, aFecha As Date, aNom As String, aIDDoc As Integer
        Dim aIDRubro As Integer, aConcep As String, aFolio As Integer, aSerie As String

        aSuc = _suc
        With GridDatos
            aIDDoc = .Item(0, .CurrentRow.Index).Value
            aNom = .Item(3, .CurrentRow.Index).Value
            aFecha = .Item(2, .CurrentRow.Index).Value
        End With

        For Each Fila As DataGridViewRow In dglistadoc.Rows
            aIDAdw = Fila.Cells(0).Value
            aIDRubro = 0
            aConcep = Fila.Cells(2).Value
            If esOtro = 2 Then
                aConcep = aConcep & " de " & Fila.Cells(6).Value & " a "
            End If
            aFolio = Fila.Cells(5).Value
            aSerie = Fila.Cells(4).Value
            If Marcar_Documentos(aIDDoc, 1, aIDRubro, aConcep, aFolio, aSerie, _rfcempresa, aIDAdw) = True Then
                If Vincular_Documentos(aSuc, aIDAdw, aFecha, aIDDoc, aNom, _idsubme, 1, esOtro) Then
                    MsgBox("Asociado Correctamente", vbInformation, "Validación")
                End If
            End If
        Next
    End Sub

    Private Sub btnAsociar_Click(sender As Object, e As EventArgs) Handles btnAsociar.Click
        Dim esOtro As Integer, dIDSub As Integer
        dIDSub = cbConcepAdw.SelectedValue
        If dIDSub = 0 Then
            esOtro = 2
        Else
            esOtro = 1
        End If
        Guarda_Otro(esOtro)
    End Sub

    Private Sub Carga_Bancos()
        Dim gQue As String, fecha As String
        Dim aQue As String

        fecha = Format(CDate(dtFecha.Value), "yyyy-MM-dd")

        dgDocAdw.Rows.Clear()

        gQue = "SELECT b.Id,b.Fecha,b.Importe,c.Nombre,t.idEgr,b.Traspaso FROM zBanPortal b
                   INNER JOIN CuentasCheques c ON  b.idCuentaBanco=c.Id
                   INNER JOIN zBanTraspasos t ON b.id=t.idIng WHERE tipomov=1 AND
                   Fecha='" & fecha & "' AND 
                  (Traspaso=3 OR Traspaso=10 OR Traspaso=7 or Traspaso=8)"
        Using gCom = New SqlCommand(gQue, FC_SQL)
            Using gCr = gCom.ExecuteReader
                Do While gCr.Read
                    aQue = "SELECT c.Nombre FROM zBanPortal b
                            INNER JOIN CuentasCheques c ON  b.idCuentaBanco=c.Id 
                            WHERE b.id=" & gCr("idEgr") & ""
                    Using aCom = New SqlCommand(aQue, FC_SQL)
                        Using aCr = aCom.ExecuteReader
                            aCr.Read()
                            If aCr.HasRows Then
                                dgDocAdw.Rows.Add(gCr("Id"), Get_ConceptoBancos(gCr("Traspaso")),
                                                      Format(gCr("Fecha"), "yyyy-MM-dd"), Trim(gCr("Nombre")), gCr("Id"),
                                                      Trim(aCr("Nombre")), gCr("Importe"),
                                                      Trim(gCr("Nombre")), "")
                            End If
                        End Using
                    End Using
                Loop
            End Using
        End Using


    End Sub
End Class