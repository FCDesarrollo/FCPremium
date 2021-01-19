Imports System.Data.SqlClient
Imports System.IO

Public Class frmdigital
    Private sBandLoad As Boolean
    Private sDocDigitales As Collection
    Private _rfcEmpresa As String
    Private Sub Frmdigital_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tolTips()
        LUser.Text = "Usuario: " & GL_cUsuarioAPI.Nombreuser & " " & GL_cUsuarioAPI.Apellidop & " " & GL_cUsuarioAPI.Apellidom
        txtEjercicio.Text = Year(Now)
        cbPeriodo.SelectedIndex = Month(Now) - 1
        Carga_submenus(Menu_Digital_Operacion)
        sBandLoad = True
        Carga_Empresas(cbempresa)
        sBandLoad = False
    End Sub

    Private Sub Cbempresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbempresa.SelectedIndexChanged
        Dim idEmp As Integer
        If sBandLoad = True Then Exit Sub
        idEmp = CInt(cbempresa.SelectedValue)
        If idEmp > 0 Then
            Cambio_Empresa(idEmp)
        End If
    End Sub

    Private Sub Cambio_Empresa(ByVal idEmp As Integer)
        Dim cQue As String
        sBandLoad = True
        LInfo.Text = ""
        Try
            cQue = "SELECT d.rutaadw,x.ctBDD FROM XMLDigSucursal d
                        INNER JOIN XMLEmpresas x ON d.idempresacont=x.IdEmpresa 
                            WHERE d.idempresacrm=" & idEmp & ""
            Using cCom = New SqlCommand(cQue, FC_Con)
                Using cRs = cCom.ExecuteReader()
                    cRs.Read()
                    If cRs.HasRows Then
                        If FC_ConexionSQL(cRs("ctBDD")) <> 0 Then Exit Sub
                    End If
                End Using
            End Using
            cbdocmodelo.DataSource = Nothing
            cbdocmodelo.Items.Clear()
            dgDocAdw.Rows.Clear()
            dgAsocDoc.Rows.Clear()
            dgDocDigitales.Rows.Clear()


            txtall.Text = 0
            txtasoc.Text = 0
            txtpendientes.Text = 0
            _rfcEmpresa = Obtener_RFC(idEmp)
            Carga_Permisos(idEmp, Me.cboperacion, Menu_Digital_Operacion)
            Carga_sucursales(idEmp, cbsucursal)
        Catch ex As Exception
            MsgBox("Erro al cambiar de Empresa." & vbCrLf & ex.Message, vbExclamation, "Validación")
        End Try
        sBandLoad = False

    End Sub

    Private Sub DConfig_Click(sender As Object, e As EventArgs) Handles DConfig.Click
        frmConfigDigital.ShowDialog()
        frmConfigDigital.Dispose()
        Buscar_documentos()
    End Sub

    Private Sub DCerrar_Click(sender As Object, e As EventArgs) Handles DCerrar.Click
        Me.Close()
    End Sub

    Private Sub cboperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboperacion.SelectedIndexChanged
        Dim idEmp As Integer, idSubMenu As Integer
        If sBandLoad = True Then Exit Sub
        dgDocAdw.Rows.Clear()
        dgAsocDoc.Rows.Clear()
        dgDocDigitales.Rows.Clear()

        txtall.Text = 0
        txtasoc.Text = 0
        txtpendientes.Text = 0
        LInfo.Text = ""
        idEmp = CInt(cbempresa.SelectedValue)
        idSubMenu = CInt(cboperacion.SelectedValue)
        sBandLoad = True
        Carga_rubros(idEmp, idSubMenu, cbdocmodelo)
        Buscar_documentos()
        sBandLoad = False
    End Sub

    Private Sub Carga_documentosCRM(ByVal eID As Integer, ByVal eEjercicio As Integer,
                                    ByVal ePeriodo As Integer, ByVal eIdModulo As Integer, ByVal eSucursal As String)
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String, cTodos As String, doc As clDocDigital
        Dim dDigAsoc As New Dictionary(Of Integer, Integer), dQue As String, fechai As Date, fechaf As Date

        fechai = CDate(eEjercicio & "-" & ePeriodo & "-01")
        fechaf = ObtenerUltimoDia(fechai)
        dQue = "SELECT iddocdig,iddocADW FROM XMLDigAsoc WHERE sucursal=@suc AND fecha BETWEEN @fechai AND @fechaf"
        Using dCom = New SqlCommand(dQue, FC_SQL)
            dCom.Parameters.AddWithValue("@suc", eSucursal)
            dCom.Parameters.AddWithValue("@fechai", fechai)
            dCom.Parameters.AddWithValue("@fechaf", fechaf)
            Using aCr = dCom.ExecuteReader()
                Do While aCr.Read()
                    If Not dDigAsoc.ContainsKey(aCr("iddocdig")) Then
                        dDigAsoc.Add(aCr("iddocdig"), aCr("iddocADW"))
                    End If
                Loop
            End Using
        End Using

        sDocDigitales = New Collection

        cTodos = "false"
        dFiltro = "{""Correo"":""" & GL_cUsuarioAPI.Correo & """, ""Contra"":""" &
                    GL_cUsuarioAPI.Contra & """, ""Idempresa"":" & eID & ", ""All"":""" &
                    cTodos & """, ""Ejercicio"":" & eEjercicio & ",""Periodo"":" &
                    ePeriodo & ",""Idmodulo"":""" & eIdModulo & """,""Sucursal"":""" & eSucursal & """}"
        dMetodo = "documentosdigitales"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod <> "false" Then
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                For Each Row In jsonObject("documentos")
                    doc = New clDocDigital
                    doc.Id = Row("id")
                    doc.Fechadocto = Row("fechadocto")
                    doc.Codigodocumento = Row("codigodocumento")
                    doc.Documento = Row("documento")
                    doc.Estatus = Row("estatus")

                    doc.Descripcion = "Concepto: " & CStr(Row("conceptoadw")) & vbCrLf &
                            "Folio: " & CStr(Row("folioadw")) & IIf(CStr(Row("serieadw")) <> "", "Serie: " & CStr(Row("serieadw")), "")
                    If dDigAsoc.ContainsKey(doc.Id) Then
                        doc.Iddocadw = dDigAsoc.Item(doc.Id)
                    Else
                        doc.Iddocadw = 0
                    End If

                    sDocDigitales.Add(doc)
                Next
            End If
        End If

        dDigAsoc = Nothing
    End Sub

    Private Sub Buscar_documentos()
        Dim idEmp As Integer, dEjercicio As Integer, dPeriodo As Integer
        Dim dSucursal As String, Idmodulo As Integer, dRuta As String ', idDocModelo As Integer

        idEmp = CInt(cbempresa.SelectedValue)
        dPeriodo = CInt(cbPeriodo.SelectedIndex) + 1
        dSucursal = CStr(cbsucursal.Text)
        dRuta = CStr(cbsucursal.SelectedValue)
        If IsNumeric(txtEjercicio.Text) Then
            dEjercicio = CInt(txtEjercicio.Text)
        Else
            MsgBox("El ejercicio es incorrecto.", vbExclamation, "Validación")
            Exit Sub
        End If

        Idmodulo = CInt(cboperacion.SelectedValue)

        If idEmp > 0 And Idmodulo > 0 And dSucursal <> "" And dSucursal <> "SELECCIONAR SUCURSAL" Then
            Carga_documentosCRM(idEmp, dEjercicio, dPeriodo, Idmodulo, dSucursal)
            Carga_DocumentosADW(dRuta)
            'Carga_DocumentosOtros(False)
            Filtro_Documentos()

        End If
    End Sub

    Private Sub cbsucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbsucursal.SelectedIndexChanged
        Dim bddFox As String
        If sBandLoad = True Then Exit Sub
        bddFox = CStr(cbsucursal.SelectedValue)
        Buscar_documentos()
    End Sub

    Private Sub Filtro_Documentos()
        Dim tPendientes As Integer, tAsociados As Integer
        Dim tAsoc As String, agrego As Boolean, cuenta As Integer
        Dim d As clDocDigital

        dgDocDigitales.Rows.Clear()
        tPendientes = 0
        tAsociados = 0
        pr.Visible = True
        pr.Location = New Point(154, 155)
        LCargando.Visible = True
        LCargando.Location = New Point(153, 139)
        LCargando.Refresh()
        pr.Maximum = 1000
        pr.Minimum = 0
        cuenta = 0
        pr.Value = cuenta
        pr.Refresh()
        'Application.DoEvents()
        For Each d In sDocDigitales
            pr.Value = cuenta
            pr.Refresh()
            'Application.DoEvents()

            tPendientes = tPendientes + IIf(d.Estatus = 0, 1, 0)
            tAsociados = tAsociados + d.Estatus
            tAsoc = IIf(d.Estatus = 1, "♦", "")



            agrego = False
            If rbpendientes.Checked = True And d.Estatus = 0 Then
                agrego = True
                dgDocDigitales.Rows.Add(d.Id, tAsoc, Format(d.Fechadocto, "yyyy-MM-dd"), d.Codigodocumento & Path.GetExtension(d.Documento))
            ElseIf rbasoc.Checked = True And d.Estatus = 1 Then
                agrego = True
                dgDocDigitales.Rows.Add(d.Id, tAsoc, Format(d.Fechadocto, "yyyy-MM-dd"), d.Codigodocumento & Path.GetExtension(d.Documento))
            ElseIf rball.Checked = True Then
                agrego = True
                dgDocDigitales.Rows.Add(d.Id, tAsoc, Format(d.Fechadocto, "yyyy-MM-dd"), d.Codigodocumento & Path.GetExtension(d.Documento))
            End If
            If agrego = True Then
                dgDocDigitales.Item(3, dgDocDigitales.Rows.Count - 1).ToolTipText = d.Documento
                dgDocDigitales.Item(1, dgDocDigitales.Rows.Count - 1).ToolTipText = d.Descripcion
                If d.Estatus = 1 And d.Iddocadw <> 0 Then
                    If Not Verifica_docadw(d.Iddocadw) Then
                        dgDocDigitales.Rows(dgDocDigitales.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Orange
                    End If
                End If
            End If
            cuenta += 1
            If cuenta > 1000 Then cuenta = 1000
        Next
        pr.Value = 1000
        pr.Refresh()
        'Application.DoEvents()
        System.Threading.Thread.Sleep(1000)
        pr.Visible = False
        LCargando.Visible = False

        txtpendientes.Text = tPendientes
        txtasoc.Text = tAsociados
        txtall.Text = tPendientes + tAsociados
        dgDocDigitales.ClearSelection()
    End Sub

    Private Sub cbPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPeriodo.SelectedIndexChanged
        Buscar_documentos()
    End Sub

    Private Sub rbpendientes_CheckedChanged(sender As Object, e As EventArgs) Handles rbpendientes.CheckedChanged
        If sDocDigitales Is Nothing Then Exit Sub
        Filtro_Documentos()
    End Sub

    Private Sub rbasoc_CheckedChanged(sender As Object, e As EventArgs) Handles rbasoc.CheckedChanged
        If sDocDigitales Is Nothing Then Exit Sub
        Filtro_Documentos()
    End Sub

    Private Sub rball_CheckedChanged(sender As Object, e As EventArgs) Handles rball.CheckedChanged
        If sDocDigitales Is Nothing Then Exit Sub
        Filtro_Documentos()
    End Sub




    Private Sub dgDocDigitales_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDocDigitales.CellContentDoubleClick
        Dim RutaArch As String, idsubMenu As Integer, nomCarp As String
        Dim nomArchivo As String, val As Integer
        Try
            If dgDocDigitales.CurrentRow Is Nothing Then Exit Sub
            If dgDocDigitales.CurrentRow.Index >= 0 Then
                nomArchivo = dgDocDigitales.Item(3, dgDocDigitales.CurrentRow.Index).Value
                idsubMenu = CInt(cboperacion.SelectedValue)
                nomCarp = Get_NomCarpeta_SubMenu(idsubMenu)

                RutaArch = FC_RutaSincronizada & "\" & _rfcEmpresa &
                    "\Entrada\AlmacenDigitalOperaciones\" & nomCarp & "\" & nomArchivo
                If File.Exists(RutaArch) Then
                    val = Shell("rundll32.exe url.dll,FileProtocolHandler " & (RutaArch), AppWinStyle.NormalFocus, False, -1)
                Else
                    MsgBox("El Documento no existe en la ruta especificada." &
                           vbCrLf & RutaArch, vbInformation, "Validación")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al abrir el archivo." & vbCrLf & ex.Message, vbInformation, "Validación")
        End Try

    End Sub

    Private Function Obtener_RFC(ByVal eIDEm As Integer) As String
        Dim vEmpresa As clEmpresa
        Obtener_RFC = ""
        For Each vEmpresa In GL_cUsuarioAPI.MEmpresas
            If vEmpresa.Idempresa = eIDEm Then
                Obtener_RFC = vEmpresa.Rfc
            End If
        Next
    End Function

    Private Sub Carga_DocumentosADW(ByVal cRut As String)
        Dim fQue As String, fechaI As String, fechaF As String, sMes As Integer
        Dim num As Integer, nomSuc As String, dDocExclu As Dictionary(Of String, String)
        Dim cuenta As Integer, dDatos() As String, dAll As Boolean, idRubro As Integer
        Dim idDocModelo As Integer, nomDocModelo As String

        nomSuc = cbsucursal.Text
        FC_ConexionComercial(cRut)
        'If FC_ConexionFOX(cRut) <> 0 Then Exit Sub
        dAll = False
        If cbdocmodelo.SelectedValue = "0" Or cbdocmodelo.SelectedValue = "-1" Then
            If cbdocmodelo.Items.Count >= 2 Then
                dAll = True
            Else
                MsgBox("No existen Documentos Modelos Configurados." &
                               vbCrLf & "Valla a la Configuración", vbInformation, "Validación")
                Exit Sub
            End If
        Else
            dDatos = Split(cbdocmodelo.SelectedValue, "|")
            idRubro = dDatos(0)
            idDocModelo = dDatos(1)
        End If

        dgDocAdw.Rows.Clear()

        If idRubro = 0 And idDocModelo = 0 And dAll = False Then Exit Sub


        sMes = cbPeriodo.SelectedIndex + 1
        fechaI = txtEjercicio.Text & "-" & Format(sMes, "00") & "-01"
        fechaF = Format(ObtenerUltimoDia(CDate(fechaI)), "yyyy-MM-dd")

        'Try
        For Each item As Object In cbdocmodelo.Items
                If (cbdocmodelo.SelectedValue = CStr(item("iddoc")) And dAll = False) Or (dAll = True And (CStr(item("iddoc")) <> "0" And CStr(item("iddoc")) <> "-1")) Then
                    dDatos = Split(item("iddoc"), "|")
                    idRubro = dDatos(0)
                    idDocModelo = dDatos(1)
                    nomDocModelo = item("nombre")
                    dDocExclu = New Dictionary(Of String, String)
                    fQue = "SELECT codconcepto, nomconcepto FROM XMLDigConceptos 
                    WHERE IDDocmodelo=" & idDocModelo & " AND sucursal='" & nomSuc & "'"
                    Using cQue = New SqlCommand(fQue, FC_SQL)
                        Using cRs = cQue.ExecuteReader()
                            Do While cRs.Read
                                If Not dDocExclu.ContainsKey(cRs("codconcepto")) Then
                                    dDocExclu.Add(cRs("codconcepto"), cRs("nomconcepto"))
                                End If
                            Loop
                        End Using
                    End Using

                fQue = "SELECT doc.CIDDOCUMENTO,CFECHA,CSERIEDOCUMENTO,CFOLIO,
                        CRAZONSOCIAL,CTOTAL,CREFERENCIA,CPLURAL,con.CCODIGOCONCEPTO,con.CNOMBRECONCEPTO FROM admDocumentos doc
                        INNER JOIN admConceptos con ON doc.CIDCONCEPTODOCUMENTO=con.CIDCONCEPTODOCUMENTO
                        INNER JOIN admMonedas mon ON doc.CIDMONEDA=mon.CIDMONEDA
                        WHERE doc.CIDDOCUMENTODE=" & idDocModelo & " AND CFECHA 
                        BETWEEN {d '" & fechaI & "'} AND {d '" & fechaF & "'} ORDER BY CFECHA DESC"
                Using cCom = New SqlCommand(fQue, FC_CONCOMER)
                    Using cCr = cCom.ExecuteReader
                        pr.Visible = True
                        pr.Location = New Point(705, 158)
                        LCargando.Visible = True
                        LCargando.Location = New Point(630, 165)
                        LCargando.Refresh()
                        pr.Maximum = 1000
                        pr.Minimum = 0
                        cuenta = 0
                        pr.Value = cuenta
                        pr.Refresh()
                        Do While cCr.Read
                            pr.Value = cuenta
                            pr.Refresh()
                            'If aRs("CIDDOCUMENTO") = 9704 Then
                            '    Debug.Print(aRs("CIDDOCUMENTO"))
                            'End If
                            'Application.DoEvents()
                            If Not dDocExclu.ContainsKey(Trim(cCr("CCODIGOCONCEPTO"))) Then
                                num = Get_NumArchivos(cCr("CIDDOCUMENTO"), nomSuc)
                                dgDocAdw.Rows.Add(cCr("CIDDOCUMENTO"), num, nomDocModelo, Trim(cCr("CNOMBRECONCEPTO")),
                                                      Format(cCr("CFECHA"), "yyyy-MM-dd"), Trim(cCr("CSERIEDOCUMENTO")), cCr("CFOLIO"),
                                                      Trim(cCr("CRAZONSOCIAL")), cCr("CTOTAL"),
                                                      Trim(cCr("CREFERENCIA")), Trim(cCr("CPLURAL")), idRubro, idDocModelo)
                                If num > 0 Then
                                    dgDocAdw.Rows(dgDocAdw.Rows.Count - 1).DefaultCellStyle.BackColor = Color.CadetBlue
                                End If

                            End If

                            cuenta += 1
                            If cuenta > 1000 Then cuenta = 1000
                        Loop
                        pr.Value = 1000
                        pr.Refresh()
                        'Application.DoEvents()
                        System.Threading.Thread.Sleep(1000)
                        pr.Visible = False
                        LCargando.Visible = False
                    End Using
                End Using
            End If
            Next


            dgDocAdw.Sort(dgDocAdw.Columns(4), System.ComponentModel.ListSortDirection.Descending)
            cbdocmodelo.SelectedIndex = 0



        'Catch ex As Exception
        '    MsgBox("Error al cargar Documentos AdminPAQ." & vbCrLf & ex.Message, vbInformation, "Validación")
        'End Try

    End Sub

    Private Sub Carga_DocumentosOtros(ByVal dlimpia As Boolean)
        Dim dIDMenu As Integer, dQue As String, eSucursal As String
        Dim fechaI As String, fechaF As String, sMes As Integer

        If dlimpia = True Then
            dgDocAdw.Rows.Clear()
        End If

        sMes = cbPeriodo.SelectedIndex + 1
        fechaI = txtEjercicio.Text & "-" & Format(sMes, "00") & "-01"
        fechaF = Format(ObtenerUltimoDia(CDate(fechaI)), "yyyy-MM-dd")

        dIDMenu = CInt(cboperacion.SelectedValue)
        eSucursal = CStr(cbsucursal.Text)
        dQue = "SELECT iddocADW,esOtro FROM XMLDigAsoc WHERE idsubmenu=@idmen AND esOtro<>@otro
                    AND sucursal=@suc AND fecha BETWEEN @fechai AND @fechaf"
        Using dCom = New SqlCommand(dQue, FC_SQL)
            dCom.Parameters.AddWithValue("@suc", eSucursal)
            dCom.Parameters.AddWithValue("@idmen", dIDMenu)
            dCom.Parameters.AddWithValue("@otro", 0)
            dCom.Parameters.AddWithValue("@fechai", fechaI)
            dCom.Parameters.AddWithValue("@fechaf", fechaF)
            Using aCr = dCom.ExecuteReader()
                Do While aCr.Read()
                    If aCr("esOtro") = 1 Then
                        Carga_DocumentoOtroADW(aCr("iddocADW"), eSucursal)
                    ElseIf aCr("esOtro") = 2 Then
                        Carga_DocumentoOtroBancos(aCr("iddocADW"), eSucursal)
                    End If
                Loop
            End Using
        End Using

        dgDocAdw.Sort(dgDocAdw.Columns(4), System.ComponentModel.ListSortDirection.Descending)
    End Sub

    Private Sub Carga_DocumentoOtroBancos(ByVal dIdBan As Long, ByVal dSucursal As String)
        Dim dQue As String, num As Integer
        Dim aQue As String
        dQue = "SELECT b.Id,b.Fecha,b.Importe,c.Nombre,t.idEgr,b.Traspaso FROM zBanPortal b
                   INNER JOIN CuentasCheques c ON  b.idCuentaBanco=c.Id
                   INNER JOIN zBanTraspasos t ON b.id=t.idIng WHERE b.id=" & dIdBan & ""
        Using dCom = New SqlCommand(dQue, FC_SQL)
            Using dCr = dCom.ExecuteReader
                dCr.Read()
                If dCr.HasRows Then
                    aQue = "SELECT c.Nombre FROM zBanPortal b
                            INNER JOIN CuentasCheques c ON  b.idCuentaBanco=c.Id 
                            WHERE b.id=" & dCr("idEgr") & ""
                    Using aCom = New SqlCommand(aQue, FC_SQL)
                        Using aCr = aCom.ExecuteReader
                            aCr.Read()
                            If aCr.HasRows Then
                                num = Get_NumArchivos(dCr("Id"), dSucursal)
                                dgDocAdw.Rows.Add(dCr("Id"), num, "BANCOS", Get_ConceptoBancos(dCr("Traspaso")),
                                                  Format(dCr("Fecha"), "yyyy-MM-dd"), "", dCr("Id"),
                                                  Trim(aCr("nOMBRE")), dCr("Importe"),
                                                  dCr("Nombre"), 0, 0)
                                If num > 0 Then
                                    dgDocAdw.Rows(dgDocAdw.Rows.Count - 1).DefaultCellStyle.BackColor = Color.CadetBlue
                                End If
                            End If
                        End Using
                    End Using
                End If
            End Using
        End Using
    End Sub

    Private Sub Carga_DocumentoOtroADW(ByVal dIdAdw As Long, ByVal dSucursal As String)
        Dim fQue As String, num As Integer

        Try
            fQue = "SELECT doc.CIDDOCUMENTO as iddoc,CFECHA,CSERIEDOCUMENTO,CFOLIO,mod.CIDDOCUMENTODE,mod.CDESCRIPCION,
                        CRAZONSOCIAL,CTOTAL,CREFERENCIA,CPLURAL,con.CCODIGOCONCEPTO,con.CNOMBRECONCEPTO FROM admDocumentos doc 
                        INNER JOIN admConceptos con ON doc.CIDCONCEPTODOCUMENTO=con.CIDCONCEPTODOCUMENTO
                        INNER JOIN admMonedas mon ON doc.CIDMONEDA=mon.CIDMONEDA
                        INNER JOIN admDocumentosModelo mod ON doc.CIDDOCUMENTODE=mod.CIDDOCUMENTODE
                        WHERE doc.CIDDOCUMENTO=" & dIdAdw & ""
            Using cCom = New SqlCommand(fQue, FC_CONCOMER)
                Using cCr = cCom.ExecuteReader
                    If cCr.HasRows Then
                        num = Get_NumArchivos(cCr("iddoc"), dSucursal)
                        dgDocAdw.Rows.Add(cCr("iddoc"), num, Trim(cCr("CDESCRIPCION")), Trim(cCr("CNOMBRECONCEPTO")),
                                          Format(cCr("CFECHA"), "yyyy-MM-dd"), Trim(cCr("CSERIEDOCUMENTO")), cCr("CFOLIO"),
                                          Trim(cCr("CRAZONSOCIAL")), cCr("CTOTAL"),
                                          Trim(cCr("CREFERENCIA")), Trim(cCr("CPLURAL")), 0, Trim(cCr("CIDDOCUMENTODE")))
                        If num > 0 Then
                            dgDocAdw.Rows(dgDocAdw.Rows.Count - 1).DefaultCellStyle.BackColor = Color.CadetBlue
                        End If
                    End If
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error al cargar Documentos Otros Comercial." & vbCrLf & ex.Message, vbInformation, "Validación")
        End Try

    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Add_DocDigital()
    End Sub

    Private Sub Add_DocDigital()
        Dim aSuc As String, aIDAdw As Integer, aFecha As Date, aNom As String, aIDDoc As Integer
        Dim idsubMenu As Integer, aDes As String
        Dim aIDRubro As Integer, aConcep As String, aFolio As Integer, aSerie As String
        If dgDocDigitales.CurrentRow Is Nothing Then
            MsgBox("No ha seleccionado documento digital", vbInformation, "Validación")
            Exit Sub
        End If
        If dgDocAdw.CurrentRow.Index >= 0 Then
            aIDAdw = dgDocAdw.Item(0, dgDocAdw.CurrentRow.Index).Value
            aIDRubro = dgDocAdw.Item(11, dgDocAdw.CurrentRow.Index).Value
            aConcep = dgDocAdw.Item(3, dgDocAdw.CurrentRow.Index).Value
            aFolio = dgDocAdw.Item(6, dgDocAdw.CurrentRow.Index).Value
            aSerie = dgDocAdw.Item(5, dgDocAdw.CurrentRow.Index).Value
            aDes = "Concepto: " & aConcep & vbCrLf & "Folio: " & aFolio & IIf(aSerie <> "", "Serie: " & aSerie, "")
        Else
            MsgBox("No ha seleccionado documento de Comercial", vbInformation, "Validación")
            Exit Sub
        End If
        aSuc = CStr(cbsucursal.Text)

        idsubMenu = CInt(cboperacion.SelectedValue)
        For Each Fila As DataGridViewRow In dgDocDigitales.SelectedRows
            ' If Fila.Cells(1).Value = "" Then
            aIDDoc = Fila.Cells(0).Value
            aFecha = Fila.Cells(2).Value
            aNom = Fila.Cells(3).Value
            If Marcar_Documentos(aIDDoc, 1, aIDRubro, aConcep, aFolio, aSerie, _rfcEmpresa, aIDAdw) = True Then
                If Vincular_Documentos(aSuc, aIDAdw, aFecha, aIDDoc, aNom, idsubMenu, 1, 0) Then
                    Fila.Cells(1).Value = "♦"
                    Marca_Procesado(aIDDoc, 1, aDes)
                    dgDocAdw.Item(1, dgDocAdw.CurrentRow.Index).Value = dgDocAdw.Item(1, dgDocAdw.CurrentRow.Index).Value + 1
                    dgDocAdw.Rows(dgDocAdw.CurrentRow.Index).DefaultCellStyle.BackColor = Color.CadetBlue
                    If Existe_AsociadoDoc(aIDDoc) = False Then
                        dgAsocDoc.Rows.Add(aIDDoc, idsubMenu, Format(aFecha, "yyyy-MM-dd"), aNom)
                    End If
                End If
            End If
            'End If
        Next
        Filtro_Documentos()
    End Sub

    Private Sub Marca_Procesado(ByVal idDocDig As Integer, ByVal sStat As Integer, ByVal aDes As String)
        Dim d As clDocDigital
        For Each d In sDocDigitales
            If d.Id = idDocDig Then
                d.Estatus = sStat
                d.Descripcion = aDes
                Exit For
            End If
        Next
    End Sub

    Private Function Existe_AsociadoDoc(ByVal idDocDig As Integer) As Boolean
        Dim sExiste As Boolean
        sExiste = False
        For Each Fila As DataGridViewRow In dgAsocDoc.Rows
            If Fila.Cells(0).Value = idDocDig Then
                sExiste = True
                Exit For
            End If
        Next
        Return sExiste
    End Function



    Private Function Get_NumArchivos(ByVal idDocADW As Integer, ByVal gSucursal As String) As Integer
        Dim gQue As String
        Get_NumArchivos = 0
        gQue = "SELECT COUNT(*) as num FROM XMLDigAsoc WHERE 
                    sucursal ='" & gSucursal & "' AND iddocADW=" & idDocADW & ""
        Using gCom = New SqlCommand(gQue, FC_SQL)
            Using gCr = gCom.ExecuteReader
                gCr.Read()
                If gCr.HasRows Then
                    Get_NumArchivos = gCr("num")
                End If
            End Using
        End Using
    End Function

    Private Sub DocDig_AsociadosADW(ByVal sIdAdw As Integer, dSuc As String)
        Dim dQue As String
        dgAsocDoc.Rows.Clear()
        dQue = "SELECT iddocdig,idsubmenu,fecha,nombrearchivo FROM XMLDigAsoc 
                    WHERE sucursal='" & dSuc & "' AND iddocADW=" & sIdAdw & ""
        Using dCom = New SqlCommand(dQue, FC_SQL)
            Using dCr = dCom.ExecuteReader()
                Do While dCr.Read
                    dgAsocDoc.Rows.Add(dCr("iddocdig"), dCr("idsubmenu"),
                                       Format(dCr("fecha"), "yyyy-MM-dd"), dCr("nombrearchivo"))
                Loop
            End Using
        End Using
        dgAsocDoc.ClearSelection()
    End Sub


    Private Sub dgDocAdw_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgDocAdw.CurrentCellChanged
        Dim idAdw As Integer, dSucursal As String
        dSucursal = cbsucursal.Text
        With dgDocAdw
            If .CurrentRow Is Nothing Then Exit Sub
            If .CurrentRow.Index >= 0 Then
                idAdw = .Item(0, .CurrentRow.Index).Value
                DocDig_AsociadosADW(idAdw, dSucursal)

                LInfo.Text = "Documento Modelo: " & .Item(2, .CurrentRow.Index).Value & "    Concepto:  " & .Item(3, .CurrentRow.Index).Value &
                                vbCrLf & "Fecha:  " & .Item(4, .CurrentRow.Index).Value &
                "   Serie:  " & .Item(5, .CurrentRow.Index).Value & "   Folio:  " &
                .Item(6, .CurrentRow.Index).Value & "   Importe:  " & .Item(8, .CurrentRow.Index).Value &
                vbCrLf & "Razon Social:  " & .Item(7, .CurrentRow.Index).Value &
                vbCrLf & "Referencia:  " & .Item(9, .CurrentRow.Index).Value &
                vbCrLf & "Moneda:  " & .Item(10, .CurrentRow.Index).Value
            End If
        End With
    End Sub

    Private Sub Buscar_Fecha_Coincidencias(ByVal bCol As Integer, ByVal cTexto As String)
        For Each Fila As DataGridViewRow In dgDocAdw.Rows
            If Fila.Cells(bCol).Value = cTexto Then
                Fila.Selected = True
                dgDocAdw.CurrentCell = Fila.Cells(2)
                Exit For
            End If
        Next
    End Sub

    Private Sub Busca_Coincidencias(ByVal cTexto As String, ByVal cAdd As Boolean, ByVal fil As Integer)
        Dim cont As Integer
        cont = 0
BuscaInicio:
        If cont = 2 Then Exit Sub
        If cAdd = True Then
            For Each Fila As DataGridViewRow In dgDocAdw.Rows
                If Fila.Index > fil Then
                    For t = 3 To 7
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
                    For t = 3 To 7
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

    Private Sub dgDocDigitales_CurrentCellChanged(sender As Object, e As EventArgs) Handles dgDocDigitales.CurrentCellChanged
        If dgDocDigitales.CurrentCell Is Nothing Then Exit Sub
        If dgDocDigitales.CurrentCell.RowIndex >= 0 Then
            Buscar_Fecha_Coincidencias(4, dgDocDigitales.Item(2, dgDocDigitales.CurrentCell.RowIndex).Value)
        End If
    End Sub

    Private Function Verifica_Contabilizado(ByVal vSuc As String, ByVal idEmpCrm As Integer, idDocADW As Integer) As Boolean
        Dim vQue As String, EmpresaAdmin As String, vCarpetas As String()

        Try
            Verifica_Contabilizado = False
            EmpresaAdmin = ""
            vQue = "SELECT rutaadw FROM XMLDigSucursal 
                        WHERE idempresacrm=" & idEmpCrm & " AND sucursal='" & vSuc & "'"
            Using vCom = New SqlCommand(vQue, FC_Con)
                Using vCr = vCom.ExecuteReader()
                    vCr.Read()
                    If vCr.HasRows Then
                        vCarpetas = Split(vCr("rutaadw"), "\")
                        EmpresaAdmin = vCarpetas(UBound(vCarpetas))
                    End If
                End Using
            End Using
            If EmpresaAdmin <> "" Then
                vQue = "SELECT Folio FROM zInterfaz 
                        WHERE idDoc=" & idDocADW & " AND Empresa='" & EmpresaAdmin & "'"
                Using vCom = New SqlCommand(vQue, FC_SQL)
                    Using vCr = vCom.ExecuteReader()
                        vCr.Read()
                        If vCr.HasRows Then
                            Verifica_Contabilizado = True
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            Verifica_Contabilizado = True
            MsgBox("Error del Sistema al Verificar Contabilizado" & vbCrLf & ex.Message, vbExclamation, "Información")
        End Try

    End Function

    Private Sub btnDelDig_Click(sender As Object, e As EventArgs) Handles btnDelDig.Click
        Dim bSuc As String, idempreCrm As Integer, idDocdigital As Integer, idDocAdw As Integer
        Dim bIDsubMenu As Integer, bFecha As Date, bNom As String = ""
        Dim aIDRubro As Integer, aConcep As String, aFolio As Integer, aSerie As String
        idempreCrm = CInt(cbempresa.SelectedValue)
        bSuc = cbsucursal.Text
        If dgAsocDoc.CurrentCell Is Nothing Or dgDocAdw.CurrentCell Is Nothing Then Exit Sub
        If dgDocAdw.CurrentCell.RowIndex >= 0 Then
            idDocAdw = dgDocAdw.Item(0, dgDocAdw.CurrentCell.RowIndex).Value
            aIDRubro = 0
            aConcep = ""
            aFolio = 0
            aSerie = ""
        End If
        If dgAsocDoc.CurrentCell.RowIndex >= 0 Then
            idDocdigital = dgAsocDoc.Item(0, dgAsocDoc.CurrentCell.RowIndex).Value
            bIDsubMenu = dgAsocDoc.Item(1, dgAsocDoc.CurrentCell.RowIndex).Value
            bFecha = dgAsocDoc.Item(2, dgAsocDoc.CurrentCell.RowIndex).Value
            bNom = dgAsocDoc.Item(2, dgAsocDoc.CurrentCell.RowIndex).Value
        End If
        If idempreCrm > 0 Then
            'If Verifica_Contabilizado(bSuc, idempreCrm, idDocAdw) = False Then
            If Marcar_Documentos(idDocdigital, 0, aIDRubro, aConcep, aFolio, aSerie, _rfcEmpresa, idDocAdw) = True Then
                If Vincular_Documentos(bSuc, idDocAdw, bFecha, idDocdigital, bNom, bIDsubMenu, 0, 0) Then
                    'Marca_Procesado(idDocdigital, 0, "")
                    'If dgDocAdw.Item(1, dgDocAdw.CurrentRow.Index).Value > 0 Then
                    '    dgDocAdw.Item(1, dgDocAdw.CurrentRow.Index).Value = dgDocAdw.Item(1, dgDocAdw.CurrentRow.Index).Value - 1
                    'End If
                    'dgAsocDoc.Rows.Remove(dgAsocDoc.CurrentRow)
                    MsgBox("Documento Digital Desasociado Correctamente.", vbInformation, "Validación")
                    Buscar_documentos()
                End If
            End If
            'Filtro_Documentos()
            'Else
            '    MsgBox("El Documento de AdminPAQ ya esta Contabilizado." &
            '           vbCrLf & "Imposible Eliminar", vbInformation, "Validación")
            'End If
        End If
    End Sub


    Private Sub dgAsocDoc_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAsocDoc.CellContentDoubleClick
        Dim RutaArch As String, idsubMenu As Integer, nomCarp As String
        Dim nomArchivo As String, val As Integer
        Try
            If dgAsocDoc.CurrentRow Is Nothing Then Exit Sub
            If dgAsocDoc.CurrentRow.Index >= 0 Then
                nomArchivo = dgAsocDoc.Item(3, dgAsocDoc.CurrentRow.Index).Value
                idsubMenu = dgAsocDoc.Item(1, dgAsocDoc.CurrentRow.Index).Value
                nomCarp = Get_NomCarpeta_SubMenu(idsubMenu)

                RutaArch = FC_RutaSincronizada & "\" & _rfcEmpresa &
                    "\Entrada\AlmacenDigitalOperaciones\" & nomCarp & "\" & nomArchivo
                If File.Exists(RutaArch) Then
                    val = Shell("rundll32.exe url.dll,FileProtocolHandler " & (RutaArch), AppWinStyle.NormalFocus, False, -1)
                Else
                    MsgBox("El Documento no existe en la ruta especificada." &
                           vbCrLf & RutaArch, vbInformation, "Validación")
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al abrir el archivo." & vbCrLf & ex.Message, vbInformation, "Validación")
        End Try
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Dim fil As Integer
        If txtBus.Text <> "" Then
            If dgDocAdw.CurrentRow Is Nothing Then
                fil = 0
            Else
                fil = dgDocAdw.CurrentRow.Index
            End If
            Busca_Coincidencias(txtBus.Text, True, fil)
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Dim fil As Integer
        If txtBus.Text <> "" Then
            If dgDocAdw.CurrentRow Is Nothing Then
                fil = 0
            Else
                fil = dgDocAdw.CurrentRow.Index
            End If
            Busca_Coincidencias(txtBus.Text, False, fil)
        End If
    End Sub

    Private Sub tolTips()
        Dim TL(2) As ToolTip
        TL(0) = New ToolTip
        TL(0).SetToolTip(Me.btnChange, "Mueve el documento a otro Rubro")
        TL(1) = New ToolTip
        TL(1).SetToolTip(Me.btnDel, "Elima el Documento del CRM")
        'TL(2) = New ToolTip
        'TL(2).SetToolTip(Me.ProgressBar1, "esto es una progressbar")
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click
        Dim idempreCrm As Integer
        If dgDocDigitales.CurrentRow Is Nothing Then
            MsgBox("No ha seleccionado documento", vbInformation, "Validación")
            Exit Sub
        End If
        idempreCrm = CInt(cbempresa.SelectedValue)

        If dgDocDigitales.SelectedRows.Count > 1 Then
            MsgBox("Debe seleccionar solo un documento", vbInformation, "Validación")
            Exit Sub
        End If

        If idempreCrm > 0 Then
            G_claRubroNew = ""
            G_carFin = ""
            Dim frm As New frmRubros
            frm.RuIDEmpresa = idempreCrm
            frm.ShowDialog()
            If G_carFin <> "" And G_claRubroNew <> "" Then
                Mover_Documento()
                Buscar_documentos()
            End If
        End If
    End Sub

    Private Sub Eliminar_Documento()
        Dim dMetodo As String, jsonMod As String
        Dim dFiltro As String, idDoc As Integer, nomAr As String

        idDoc = dgDocDigitales.Item(0, dgDocDigitales.CurrentRow.Index).Value
        nomAr = cboperacion.Text & "/" & dgDocDigitales.Item(3, dgDocDigitales.CurrentRow.Index).Value

        dFiltro = "{" & Chr(34) & "rfcempresa" & Chr(34) & ": " & Chr(34) & _rfcEmpresa & Chr(34) & ", " &
                        Chr(34) & "usuario" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Correo & Chr(34) & "," &
                        Chr(34) & "pwd" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Contra & Chr(34) & "," &
                        Chr(34) & "idarchivo" & Chr(34) & ":" & idDoc & "," &
                        Chr(34) & "idmenu" & Chr(34) & ": " & Menu_Digital_Operacion & "," &
                        Chr(34) & "archivo" & Chr(34) & ": " & Chr(34) & nomAr & Chr(34) & "}"
        dMetodo = "EliminaDocumentoAll"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
            If jsonObject("error").ToString() = "0" Then
                MsgBox("Documento Eliminado Correctamente")
            Else
                GetError_Api(CInt(jsonObject("error").ToString()))
            End If
        End If
    End Sub

    Private Sub Mover_Documento()
        'Dim dMetodo As String, jsonMod As String
        'Dim dFiltro As String, idDoc As Integer, claveRubroAnt As String
        'Dim obser As String, nomAr As String, carIni As String

        'idDoc = dgDocDigitales.Item(0, dgDocDigitales.CurrentRow.Index).Value
        'claveRubroAnt = dgRubros.Item(3, dgRubros.CurrentRow.Index).Value
        'obser = "Documento Cambiado del Rubro " & dgRubros.Item(2, dgRubros.CurrentRow.Index).Value
        'nomAr = dgDocDigitales.Item(3, dgDocDigitales.CurrentRow.Index).Value
        'carIni = cboperacion.Text

        'dFiltro = "{" & Chr(34) & "rfcempresa" & Chr(34) & ": " & Chr(34) & _rfcEmpresa & Chr(34) & ", " &
        '                Chr(34) & "usuario" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Correo & Chr(34) & "," &
        '                Chr(34) & "pwd" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Contra & Chr(34) & "," &
        '                Chr(34) & "iddocumento" & Chr(34) & ":" & idDoc & "," &
        '                Chr(34) & "claverubroant" & Chr(34) & ": " & Chr(34) & claveRubroAnt & Chr(34) & "," &
        '                Chr(34) & "claverubronew" & Chr(34) & ": " & Chr(34) & G_claRubroNew & Chr(34) & "," &
        '                Chr(34) & "observaciones" & Chr(34) & ": " & Chr(34) & obser & Chr(34) & "," &
        '                Chr(34) & "idmenu" & Chr(34) & ": " & Menu_Digital_Operacion & "," &
        '                Chr(34) & "nombrearchivo" & Chr(34) & ": " & Chr(34) & nomAr & Chr(34) & "," &
        '                Chr(34) & "carpetaini" & Chr(34) & ": " & Chr(34) & carIni & Chr(34) & "," &
        '                Chr(34) & "carpetafin" & Chr(34) & ": " & Chr(34) & G_carFin & Chr(34) & "}"
        'dMetodo = "CambiaRubroDocumento"
        'jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        'If jsonMod <> "" Then
        '    jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
        '    If jsonObject("error").ToString() = "0" Then
        '        MsgBox("Documento Cambiado Correctamente")
        '    Else
        '        GetError_Api(CInt(jsonObject("error").ToString()))
        '    End If
        'End If

    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim idempreCrm As Integer
        If dgDocDigitales.CurrentRow Is Nothing Then
            MsgBox("No ha seleccionado documento", vbInformation, "Validación")
            Exit Sub
        End If
        idempreCrm = CInt(cbempresa.SelectedValue)

        If dgDocDigitales.SelectedRows.Count > 1 Then
            MsgBox("Debe seleccionar solo un documento", vbInformation, "Validación")
            Exit Sub
        End If

        If idempreCrm > 0 Then
            Eliminar_Documento()
            Buscar_documentos()
        End If
    End Sub

    Private Sub cbdocmodelo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbdocmodelo.SelectedIndexChanged
        Dim dRuta As String, dSucursal As String
        If sBandLoad = True Then Exit Sub

        dSucursal = CStr(cbsucursal.Text)
        dRuta = CStr(cbsucursal.SelectedValue)



        If dRuta <> "" And dSucursal <> "" And dSucursal <> "SELECCIONAR SUCURSAL" Then
            If cbdocmodelo.SelectedValue = "0" Then
                Carga_DocumentosADW(dRuta)
                'Carga_DocumentosOtros(False)
            ElseIf cbdocmodelo.SelectedValue = "-1" Then
                Carga_DocumentosOtros(True)
            Else
                Filtro_DocumentosADW()
            End If
        End If

    End Sub

    Public Sub Filtro_DocumentosADW()
        Dim dDatos() As String, idRubro As Integer, idDocModelo As Integer
        dDatos = Split(cbdocmodelo.SelectedValue, "|")
        idRubro = dDatos(0)
        idDocModelo = dDatos(1)
        For Each Fila As DataGridViewRow In dgDocAdw.Rows
            If Not Fila.Cells(12).Value = idDocModelo Then
                dgDocAdw.CurrentCell = Nothing
                dgDocAdw.Rows(Fila.Index).Visible = False
            Else
                dgDocAdw.CurrentCell = Nothing
                dgDocAdw.Rows(Fila.Index).Visible = True
            End If
        Next
    End Sub

    Private Function Verifica_docadw(ByVal idadw As Integer) As Boolean
        Verifica_docadw = False
        For Each Fila As DataGridViewRow In dgDocAdw.Rows
            If Fila.Cells(0).Value = idadw Then
                Verifica_docadw = True
                Exit For
            End If
        Next
    End Function

    Private Sub btnMarcar_Click(sender As Object, e As EventArgs) Handles btnMarcar.Click
        'utileria_marcar()
    End Sub

    Public Sub utileria_marcar()
        Dim mQue As String, con As Integer, fQue As String, cRut As String
        Dim mID As Integer, mIDAdw As Integer, mStatus As Integer, mIDRubro As Integer
        Dim fconcepto As String, ffolio As Integer, fSerie As String

        mStatus = 1
        mIDRubro = 10
        GL_cUsuarioAPI.Correo = "marina.valdez@dublock.com"
        GL_cUsuarioAPI.Contra = "DURANGO"
        cRut = cbsucursal.SelectedValue
        FC_ConexionComercial(cRut)
        'If FC_ConexionFOX(cRut) <> 0 Then Exit Sub
        con = 0
        mQue = "SELECT iddocdig,iddocADW FROM XMLDigAsoc ORDER BY iddocdig"
        Using mCom = New SqlCommand(mQue, FC_SQL)
            Using mCr = mCom.ExecuteReader
                Do While mCr.Read
                    mID = mCr("iddocdig")
                    mIDAdw = mCr("iddocADW")
                    fQue = "SELECT c.CNOMBRECONCEPTO as con,d.CFOLIO as fol,d.CSERIEDOCUMENTO as ser FROM admDocumentos d 
                                INNER JOIN admConceptos c ON d.CIDCONCE01=c.CIDCONCE01 
                                    WHERE d.CIDDOCUMENTO=" & mIDAdw & ""
                    Using cComer = New SqlCommand(fQue, FC_CONCOMER)
                        Using cCr = cComer.ExecuteReader
                            Do While cCr.Read
                                fconcepto = Trim(cCr("con"))
                                ffolio = cCr("fol")
                                fSerie = Trim(cCr("ser"))
                                'If Marcar_Documentos(mID, mStatus, mIDRubro, fconcepto, ffolio, fSerie, _rfcEmpresa) Then
                                '    con += 1
                                'End If
                            Loop
                        End Using
                    End Using
                Loop
            End Using
        End Using
    End Sub

    Private Sub btnAsocDoc_Click(sender As Object, e As EventArgs) Handles btnAsocDoc.Click
        If dgDocDigitales.CurrentRow Is Nothing Then
            MsgBox("No ha seleccionado documento digital", vbInformation, "Validación")
            Exit Sub
        End If
        If dgDocDigitales.SelectedRows.Count > 0 Then
            Dim frm As New frmAddDoc
            frm.IDSubme = CInt(cboperacion.SelectedValue)
            frm.Rfcempresa = _rfcEmpresa
            frm.Suc = CStr(cbsucursal.Text)
            frm.GridDatos = dgDocDigitales
            frm.dtFecha.Value = dgDocDigitales.Item(2, dgDocDigitales.CurrentRow.Index).Value
            frm.ShowDialog()
            frm.Dispose()
            Buscar_documentos()
        Else
            MsgBox("No ha seleccionado documento digital", vbInformation, "Validación")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bddFox As String
        If sBandLoad = True Then Exit Sub
        bddFox = CStr(cbsucursal.SelectedValue)
        Buscar_documentos()
    End Sub

End Class