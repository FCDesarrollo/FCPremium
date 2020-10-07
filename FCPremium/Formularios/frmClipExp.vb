Imports System.Data.SqlClient
Imports System.IO
Public Class frmClipExp
    Private sBandLoad As Boolean
    Private sDocDigitales As Collection
    Private _rfcEmpresa As String
    Private bEventos As Boolean

    Private Sub BTCerrar_Click(sender As Object, e As EventArgs) Handles BTCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmClipExp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LUser.Text = "Usuario: " & GL_cUsuarioAPI.Nombreuser & " " & GL_cUsuarioAPI.Apellidop & " " & GL_cUsuarioAPI.Apellidom
        txtEjercicio.Text = Year(Now)
        cbPeriodo.SelectedIndex = Month(Now) - 1
        Carga_submenus(Menu_Digital_Expedientes)
        sBandLoad = True
        getEmpresas(Me.cbempresa)
        getEncryptedPass()
        sBandLoad = False
        bEventos = True
    End Sub

    Private Sub getEncryptedPass()
        Dim dMetodo As String, dFiltro As String = "", jsonMod As String
        dFiltro = "{""usuario"":""" & GL_cUsuarioAPI.Correo & """, ""pwd"":""" & GL_cUsuarioAPI.Contra & """}"
        dMetodo = "inicioUsuario"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod <> "false" Then
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                GL_cUsuarioAPI.EncryptedContra = jsonObject("usuario")(0)("password")
            End If
        End If
    End Sub

    Private Sub Carga_Servicios()
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String, sev As clServicios

        cServicios = New Collection
        'dFiltro = "?usuario=" & GL_cUsuarioAPI.Correo & "&pwd=" & GL_cUsuarioAPI.EncryptedContra & "&rfc=" & Obtener_RFC(CInt(cbempresa.SelectedValue)) & "&idempresa=" & CInt(cbempresa.SelectedValue) & "&idsubmenu=40" '& CInt(cboperacion.SelectedValue)
        'dMetodo = "getServiciosEmpresaCliente"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "GET", "JSON")
        dFiltro = "{" & Chr(34) & "correo" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Correo & Chr(34) & "," &
                        Chr(34) & "contra" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Contra & Chr(34) & "}"
        dMetodo = "serviciosfc"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod <> "false" Then
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                'If CInt(jsonObject("error")) = 0 Then
                For Each Row In jsonObject("servicio")
                        If IsNumeric(Row("idmodulo")) And IsNumeric(Row("idmenu")) Then
                            If CInt(Row("idmodulo")) = 1 Or CInt(Row("idmodulo")) = 4 Then '1=MiContabilidad 2=MiAdministracion
                                If CInt(Row("idmenu")) = 2 Or CInt(Row("idmenu")) = 14 Or CInt(Row("idmenu")) = 15 Then
                                    sev = New clServicios
                                    sev.Idservicio = Row("id")
                                    sev.CodigoServicio = Row("codigoservicio")
                                    sev.Servicio = Row("nombreservicio")
                                    sev.Descripcion = Row("descripcion")
                                    sev.Tipo = Row("tipo")
                                    sev.Status = Row("status")
                                    sev.Idfcmodulo = Row("idfcmodulo")
                                    If IsNumeric(Row("idmodulo")) Then
                                        sev.Idmodulo = Row("idmodulo")
                                    Else
                                        sev.Idmodulo = 0
                                    End If
                                    If IsNumeric(Row("idmenu")) Then
                                        sev.Idmenu = Row("idmenu")
                                    Else
                                        sev.Idmenu = 0
                                    End If
                                    If IsNumeric(Row("idsubmenu")) Then
                                        sev.Idsubmenu = Row("idsubmenu")
                                    Else
                                        sev.Idsubmenu = 0
                                    End If
                                    If IsNumeric(Row("serviciocontratado")) Then
                                        sev.ServicioContratado = Row("serviciocontratado")
                                    Else
                                        sev.ServicioContratado = 0
                                    End If
                                    cServicios.Add(sev)
                                End If
                            End If
                        End If
                    Next
                'Else
                ' If CInt(jsonObject("error")) = 4 Then
                ' MsgBox("Error al cambiar de Empresa, el usuario no tiene permisos para consultar los servicios.", vbExclamation, "Validación")
                ' End If
                'End If
            End If
        End If
    End Sub

    Private Sub Cambio_Empresa(ByVal idEmp As Integer)
        Dim cQue As String
        Dim docPendientes As Integer
        sBandLoad = True
        'LInfo.Text = ""
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
            dgDocDigitales.Rows.Clear()
            dgServicios.Rows.Clear()
            CBMenus.DataSource = Nothing
            CBMenus.Items.Clear()
            CBSubmenus.DataSource = Nothing
            CBSubmenus.Items.Clear()

            txtall.Text = 0
            txtasoc.Text = 0
            txtpendientes.Text = 0
            _rfcEmpresa = Obtener_RFC(idEmp)
            Carga_Permisos(idEmp, Me.cboperacion, Menu_Digital_Expedientes)
            Carga_sucursales(idEmp, Me.cbsucursal)
            Carga_Servicios()

            'If bEventos = True Then
            CBMenus.DataSource = Nothing
            CBMenus.Items.Clear()
            CBSubmenus.DataSource = Nothing
            CBSubmenus.Items.Clear()
            CargaComboMenus(Me.CBMenus)
            CargaComboSubM(Me.CBSubmenus)
            dgServicios.Rows.Clear()
            For Each s In cServicios
                docPendientes = 0
                ConEmpresaSQL(CInt(cbempresa.SelectedValue))
                'cQue = "SELECT sum(doctos_pendientes) as pendientes FROM XMLDigTiposDoctoConfig WHERE id_serviciocrm = " & s.Idservicio
                'cQue = "SELECT count(e.id) AS pendientes FROM zClipExped e INNER JOIN zCEXTiposDocto t ON t.id = e.idcuenta WHERE t.id_serviciocrm = " & s.Idservicio
                cQue = "SELECT count(e.id) AS pendientes FROM zClipExped e WHERE e.idmodulo = " & s.idfcmodulo & " and e.procesado = 0"
                Using cCom = New SqlCommand(cQue, FC_SQL)
                    Using Rs = cCom.ExecuteReader()
                        Rs.Read()
                        If Rs.HasRows Then
                            If IsDBNull(Rs("pendientes")) Then
                                docPendientes = 0
                            Else
                                docPendientes = Rs("pendientes")
                            End If
                        End If
                    End Using
                End Using
                dgServicios.Rows.Add(s.Idservicio, s.CodigoServicio, s.Servicio, s.Idmodulo, getModulo(s.Idmodulo), s.Idmenu, getMenu(s.Idmenu), s.Idsubmenu, getSubMenu(s.Idsubmenu), docPendientes, s.Idfcmodulo)
            Next
            dgServicios.ClearSelection()
            LInfo.Text = ""
            'End If
        Catch ex As Exception
            MsgBox("Error al cambiar de Empresa." & vbCrLf & ex.Message, vbExclamation, "Validación")
        End Try
        sBandLoad = False

    End Sub
    Public Sub Filtro_Servicios()
        Dim menu As String, subm As String
        menu = CBMenus.SelectedValue
        subm = CBSubmenus.SelectedValue

        For Each Fila As DataGridViewRow In dgServicios.Rows
            If Not Fila.Cells(5).Value = menu And menu <> 0 Then
                dgServicios.CurrentCell = Nothing
                dgServicios.Rows(Fila.Index).Visible = False
            ElseIf Not Fila.Cells(7).Value = subm And subm <> 0 Then
                dgServicios.CurrentCell = Nothing
                dgServicios.Rows(Fila.Index).Visible = False
            Else
                dgServicios.CurrentCell = Nothing
                dgServicios.Rows(Fila.Index).Visible = True
            End If
        Next
    End Sub

    Private Sub cbempresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbempresa.SelectedIndexChanged
        Dim idEmp As Integer
        If sBandLoad = True Then Exit Sub
        idEmp = CInt(cbempresa.SelectedValue)
        If idEmp > 0 Then
            Cambio_Empresa(idEmp)
        End If
    End Sub

    Private Sub cboperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboperacion.SelectedIndexChanged
        Dim idEmp As Integer, idSubMenu As Integer
        If sBandLoad = True Then Exit Sub
        dgDocDigitales.Rows.Clear()
        txtall.Text = 0
        txtasoc.Text = 0
        txtpendientes.Text = 0
        idEmp = CInt(cbempresa.SelectedValue)
        idSubMenu = CInt(cboperacion.SelectedValue)
        sBandLoad = True
        Buscar_documentos()
        sBandLoad = False
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
            Filtro_Documentos()
        End If
    End Sub

    Private Sub Carga_documentosCRM(ByVal eID As Integer, ByVal eEjercicio As Integer,
                                ByVal ePeriodo As Integer, ByVal eIdModulo As Integer, ByVal eSucursal As String)
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String, cTodos As String, doc As clDocDigital
        Dim dDigAsoc As New Dictionary(Of Integer, Integer), dQue As String, fechai As Date, fechaf As Date

        fechai = CDate(eEjercicio & "-" & ePeriodo & "-01")
        fechaf = ObtenerUltimoDia(fechai)
        ''dQue = "SELECT iddocdig,iddocADW FROM XMLDigAsoc WHERE sucursal=@suc AND fecha BETWEEN @fechai AND @fechaf"
        'dQue = "SELECT iddocdig, idsubmenu_destino FROM XMLDigAsocExped WHERE sucursalcrm=@suc AND fecha BETWEEN @fechai AND @fechaf"
        'Using dCom = New SqlCommand(dQue, FC_SQL)
        '    dCom.Parameters.AddWithValue("@suc", eSucursal)
        '    dCom.Parameters.AddWithValue("@fechai", fechai)
        '    dCom.Parameters.AddWithValue("@fechaf", fechaf)
        '    Using aCr = dCom.ExecuteReader()
        '        Do While aCr.Read()
        '            If Not dDigAsoc.ContainsKey(aCr("iddocdig")) Then
        '                dDigAsoc.Add(aCr("iddocdig"), aCr("idsubmenu_destino"))
        '            End If
        '        Loop
        '    End Using
        'End Using

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
                    doc.Download = Row("download")
                    'doc.Estatus = Row("estatus")

                    doc.Descripcion = "Concepto: " & CStr(Row("conceptoadw")) & vbCrLf &
                            "Folio: " & CStr(Row("folioadw")) & IIf(CStr(Row("serieadw")) <> "", "Serie: " & CStr(Row("serieadw")), "")
                    'If dDigAsoc.ContainsKey(doc.Id) Then
                    If CInt(Row("estatus")) = 1 Then
                        'doc.Iddocadw = dDigAsoc.Item(doc.Id)
                        doc.Iddocadw = Row("id")
                        doc.Estatus = 1
                        'Else
                    Else
                        doc.Iddocadw = 0
                        doc.Estatus = 0
                    End If
                    'End If

                    sDocDigitales.Add(doc)
                Next
            End If
        End If

        dDigAsoc = Nothing
    End Sub

    Private Sub Filtro_Documentos()
        Dim tPendientes As Integer, tAsociados As Integer
        Dim tAsoc As String, agrego As Boolean, cuenta As Integer
        Dim d As clDocDigital

        dgDocDigitales.Rows.Clear()

        tPendientes = 0
        tAsociados = 0
        cuenta = 0
        For Each d In sDocDigitales
            tPendientes = tPendientes + IIf(d.Estatus = 0, 1, 0)
            tAsociados = tAsociados + d.Estatus
            tAsoc = IIf(d.Estatus = 1, "♦", "")

            agrego = False
            If rbpendientes.Checked = True And d.Estatus = 0 Then
                agrego = True
                dgDocDigitales.Rows.Add(d.Id, tAsoc, Format(d.Fechadocto, "yyyy-MM-dd"), d.Codigodocumento & Path.GetExtension(d.Documento), d.Download)
            ElseIf rbasoc.Checked = True And d.Estatus = 1 Then
                agrego = True
                dgDocDigitales.Rows.Add(d.Id, tAsoc, Format(d.Fechadocto, "yyyy-MM-dd"), d.Codigodocumento & Path.GetExtension(d.Documento), d.Download)
            ElseIf rball.Checked = True Then
                agrego = True
                dgDocDigitales.Rows.Add(d.Id, tAsoc, Format(d.Fechadocto, "yyyy-MM-dd"), d.Codigodocumento & Path.GetExtension(d.Documento), d.Download)
            End If

            If agrego = True Then
                dgDocDigitales.Item(3, dgDocDigitales.Rows.Count - 1).ToolTipText = d.Documento
                dgDocDigitales.Item(1, dgDocDigitales.Rows.Count - 1).ToolTipText = d.Descripcion
            End If
            cuenta += 1
            If cuenta > 1000 Then cuenta = 1000
        Next
        System.Threading.Thread.Sleep(1000)

        txtpendientes.Text = tPendientes
        txtasoc.Text = tAsociados
        txtall.Text = tPendientes + tAsociados
        dgDocDigitales.ClearSelection()

    End Sub

    Private Sub cbsucursal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbsucursal.SelectedIndexChanged
        Dim bddFox As String
        If sBandLoad = True Then Exit Sub
        bddFox = CStr(cbsucursal.SelectedValue)
        Buscar_documentos()
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
                    "\Entrada\AlmacenDigitalExpedientes\" & nomCarp & "\" & nomArchivo
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

    Private Sub CBMenus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBMenus.SelectedIndexChanged
        If bEventos = False Then Exit Sub
        Filtro_Servicios()
    End Sub

    Private Sub CBSubmenus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBSubmenus.SelectedIndexChanged
        If bEventos = False Then Exit Sub
        Filtro_Servicios()
    End Sub

    Private Function getModulo(ByVal iMod As Integer) As String
        Dim NomSub As String = ""
        Select Case iMod
            Case 1
                NomSub = "Mi Contabilidad"
            Case 4
                NomSub = "Mi Administracion"
        End Select
        getModulo = NomSub
    End Function
    Private Function getMenu(ByVal iMen As Integer) As String
        Dim NomSub As String = ""
        Select Case iMen
            Case 14
                NomSub = "Expedientes Digitales"
            Case 15
                NomSub = "Publicaciones"
        End Select
        getMenu = NomSub
    End Function
    Private Function getSubMenu(ByVal iSub As Integer) As String
        Dim NomSub As String = ""
        Select Case iSub
            Case 51
                NomSub = "Constitucion y Estatutos"
            Case 52
                NomSub = "Gobierno"
            Case 53
                NomSub = "Bancos"
            Case 54
                NomSub = "Recursos Humanos"
            Case 55
                NomSub = "Clientes"
            Case 56
                NomSub = "Proveedores"
            Case 57
                NomSub = "Activos Fijos"
            Case 58
                NomSub = "Folios Oficiales"
            Case 59
                NomSub = "Biblioteca de Conocimiento"
            Case 60
                NomSub = "Mural"
        End Select
        getSubMenu = NomSub
    End Function
    Public Sub CargaComboMenus(ByVal cb As ComboBox)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim dic As New Dictionary(Of String, String)
        Dim count As Integer = 0

        bEventos = False

        dt = New DataTable("Menus")
        dt.Columns.Add("id")
        dt.Columns.Add("menu")
        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "SELECCIONAR MENU"
        dt.Rows.Add(dr)

        For Each s In cServicios
            If Not dic.ContainsValue(getMenu(s.idmenu)) Then
                dr = dt.NewRow
                dr(0) = s.idmenu
                dr(1) = getMenu(s.idmenu)
                dt.Rows.Add(dr)
                dic.Add(count, getMenu(s.idmenu))
                count += 1
            End If
        Next

        cb.DataSource = dt
        cb.ValueMember = "id"
        cb.DisplayMember = "Menu"

        bEventos = True
    End Sub
    Public Sub CargaComboSubM(ByVal cb As ComboBox)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim s As clServicios
        Dim dic As New Dictionary(Of String, String)
        Dim count As Integer = 0

        bEventos = False

        dt = New DataTable("Submenus")
        dt.Columns.Add("id")
        dt.Columns.Add("submenu")
        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "SELECCIONAR SUBMENU"
        dt.Rows.Add(dr)

        For Each s In cServicios
            If Not dic.ContainsValue(getSubMenu(s.Idsubmenu)) Then
                dr = dt.NewRow
                dr(0) = s.Idsubmenu
                dr(1) = getSubMenu(s.Idsubmenu)
                dt.Rows.Add(dr)
                dic.Add(count, getSubMenu(s.Idsubmenu))
                count += 1
            End If
        Next

        cb.DataSource = dt
        cb.ValueMember = "id"
        cb.DisplayMember = "Submenu"

        bEventos = True
    End Sub

    Public Sub cargaPeriodos(ByVal cb As ComboBox)
        Dim dt As DataTable
        Dim dr As DataRow

        dt = New DataTable("Periodos")
        dt.Columns.Add("periodo")
        dt.Columns.Add("nombre")
        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "SELECCIONAR PERIODO"
        dt.Rows.Add(dr)

        For i As Integer = 1 To 12
            dr = dt.NewRow
            dr(0) = i
            dr(1) = getPeriodo(i)
            dt.Rows.Add(dr)
        Next

        cb.DataSource = dt
        cb.ValueMember = "periodo"
        cb.DisplayMember = "nombre"

    End Sub

    Public Function getPeriodo(ByVal numero As Integer) As String
        Dim valor As String = ""
        Select Case numero
            Case 1
                valor = "Enero"
            Case 2
                valor = "Febrero"
            Case 3
                valor = "Marzo"
            Case 4
                valor = "Abril"
            Case 5
                valor = "Mayo"
            Case 6
                valor = "Junio"
            Case 7
                valor = "Julio"
            Case 8
                valor = "Agosto"
            Case 9
                valor = "Septiembre"
            Case 10
                valor = "Octubre"
            Case 11
                valor = "Noviembre"
            Case 12
                valor = "Diciembre"
        End Select
        getPeriodo = valor
    End Function

    Private Sub TBFiltro_TextChanged(sender As Object, e As EventArgs) Handles TBFiltro.TextChanged
        Dim Criterio As String
        CBMenus.SelectedIndex = 0
        CBSubmenus.SelectedIndex = 0
        Criterio = UCase(TBFiltro.Text)
        For Each Fila As DataGridViewRow In dgServicios.Rows
            If Not InStr(1, UCase(Fila.Cells(2).Value), Criterio) <> 0 Then
                dgServicios.CurrentCell = Nothing
                dgServicios.Rows(Fila.Index).Visible = False
            Else
                dgServicios.CurrentCell = Nothing
                dgServicios.Rows(Fila.Index).Visible = True
            End If
        Next
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        If dgDocDigitales.CurrentRow Is Nothing Then
            MsgBox("No ha seleccionado documento digital", vbInformation, "Validación")
            Exit Sub
        ElseIf dgDocDigitales.CurrentRow.Selected = False Then
            MsgBox("No ha seleccionado documento digital", vbInformation, "Validación")
            Exit Sub
        End If
        If dgServicios.CurrentRow Is Nothing Then
            MsgBox("No ha seleccionado el servicio", vbInformation, "Validación")
            Exit Sub
        ElseIf dgServicios.CurrentRow.Selected = False Then
            MsgBox("No ha seleccionado el servicio", vbInformation, "Validación")
            Exit Sub
        End If
        If dgElementos.CurrentRow Is Nothing Then
            MsgBox("No ha seleccionado el elemento de la lista al que pertenece", vbInformation, "Validación")
            Exit Sub
        ElseIf dgElementos.CurrentRow.Selected = False Then
            MsgBox("No ha seleccionado el elemento de la lista al que pertenece", vbInformation, "Validación")
            Exit Sub
        End If
        If dgTiposDocto.CurrentRow Is Nothing Then
            MsgBox("No ha seleccionado el tipo de documento al que pertenece", vbInformation, "Validación")
            Exit Sub
        ElseIf dgTiposDocto.CurrentRow.Selected = False Then
            MsgBox("No ha seleccionado el tipo de documento al que pertenece", vbInformation, "Validación")
            Exit Sub
        End If
        bEventos = False
        Asociar_DocDigital()
        bEventos = True
    End Sub
    Private Sub Asociar_DocDigital()
        Dim aSuc As String, aFecha As Date, aNom As String, aIDDoc As Integer
        Dim idmodulo As Integer, idmenu As Integer, idsubMenu As Integer 'Variables de destino
        Dim idsubMenuOrigen As Integer
        Dim idservicio As Integer, servicio As String
        Dim idelemento As Integer, elemento As String
        Dim idtipodocto As Integer, tipo As String
        Dim urlCloud As String
        Dim Ejercicio As Integer = 0, Periodo As Integer = 0
        Dim resp As Boolean
        Dim RutaO() As String
        Dim idFCMod As Integer
        Dim oRut As String

        idFCMod = CInt(dgServicios.Item(10, dgServicios.CurrentRow.Index).Value)
        idservicio = CInt(dgServicios.Item(0, dgServicios.CurrentRow.Index).Value)
        servicio = dgServicios.Item(2, dgServicios.CurrentRow.Index).Value

        If idFCMod = 3 Then
            If cbMonth.SelectedIndex = 0 Then
                MsgBox("Seleccione el periodo al que corresponde el documento digital.", vbInformation)
                Exit Sub
            End If
            If tbYear.Text = "" Then
                MsgBox("Ingrese el ejercicio al que corresponde el documento digital.", vbInformation)
                Exit Sub
            Else
                If Not IsNumeric(tbYear.Text) Then
                    MsgBox("Ingrese un ejercicio valido.", vbInformation)
                    Exit Sub
                Else
                    If tbYear.Text.Count <> 4 Then
                        MsgBox("Ingrese un ejercicio valido.", vbInformation)
                        Exit Sub
                    End If
                End If
            End If
            Ejercicio = CInt(tbYear.Text)
            Periodo = CInt(cbMonth.SelectedValue)
        End If

        aSuc = CStr(cbsucursal.Text)
        idsubMenuOrigen = CInt(cboperacion.SelectedValue)

        idmodulo = CInt(dgServicios.Item(3, dgServicios.CurrentRow.Index).Value)
        idmenu = CInt(dgServicios.Item(5, dgServicios.CurrentRow.Index).Value)
        idsubMenu = CInt(dgServicios.Item(7, dgServicios.CurrentRow.Index).Value)
        idelemento = CInt(dgElementos.Item(0, dgElementos.CurrentRow.Index).Value)
        elemento = dgElementos.Item(1, dgElementos.CurrentRow.Index).Value
        idtipodocto = CInt(dgTiposDocto.Item(0, dgTiposDocto.CurrentRow.Index).Value)
        tipo = dgTiposDocto.Item(1, dgTiposDocto.CurrentRow.Index).Value

        For Each Fila As DataGridViewRow In dgDocDigitales.SelectedRows
            aIDDoc = Fila.Cells(0).Value
            aFecha = Fila.Cells(2).Value
            aNom = Fila.Cells(3).Value
            urlCloud = Fila.Cells(4).Value
            oRut = Fila.Cells(3).ToolTipText
            RutaO = aNom.Split(".")
            resp = False

            If ClipMarcadoCRM(Obtener_RFC(CInt(cbempresa.SelectedValue)), idFCMod, idsubMenu, elemento, tipo, Periodo, Ejercicio, True, aIDDoc) = True Then
                If idFCMod = 3 Then 'Bancos
                    resp = Vincular_DocumentosExpedBancos(idFCMod, idelemento, aIDDoc, Periodo, Ejercicio, idtipodocto, aFecha, oRut, RutaO(0))
                ElseIf idFCMod = 11 Then 'Activos Fijos
                    resp = Vincular_DocumentosExpedActivos(idFCMod, idelemento, aIDDoc, Month(aFecha), Year(aFecha), idtipodocto, aFecha, oRut, RutaO(0))
                Else
                    resp = Vincular_DocumentosExped(idFCMod, idelemento, aIDDoc, idtipodocto, aFecha, oRut, RutaO(0))
                End If
            Else
                MsgBox("Error al intentar marcar el documento, volver a intentar y si el problema persiste, comunicarse a sistemas.", vbInformation)
                Exit For
            End If
            If resp Then
                Fila.Cells(1).Value = "♦"
                Marca_Procesado(aIDDoc, 1)
                dgServicios.Item(9, dgServicios.CurrentRow.Index).Value = dgServicios.Item(9, dgServicios.CurrentRow.Index).Value + 1
            End If
        Next
        Filtro_Documentos()
    End Sub
    Private Sub Marca_Procesado(ByVal idDocDig As Integer, ByVal sStat As Integer)
        Dim d As clDocDigital
        For Each d In sDocDigitales
            If d.Id = idDocDig Then
                d.Estatus = sStat
                Exit For
            End If
        Next
    End Sub

    Private Sub BTConfig_Click(sender As Object, e As EventArgs) Handles BTConfig.Click
        frmConfigTiposDocto.ShowDialog()
    End Sub

    Private Sub dgServicios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgServicios.CellClick
        Dim idservicio As Integer, idEmp As Integer
        TbFiltroEle.Clear()
        idEmp = CInt(cbempresa.SelectedValue)
        idservicio = CInt(dgServicios.Item(0, dgServicios.CurrentRow.Index).Value)

        If idservicio = 25 Then
            cbMonth.Enabled = True
            tbYear.Enabled = True
            tbYear.Text = Year(Now)
            cargaPeriodos(Me.cbMonth)
        Else
            cbMonth.Enabled = False
            tbYear.Enabled = False
        End If

        Carga_Elementos(idservicio, idEmp)
        Carga_TiposDocto(idservicio, idEmp)
    End Sub

    Private Sub Carga_Elementos(ByVal idser As Integer, ByVal idEmp As Integer)
        Dim cQue As String, query As String = ""
        Dim dDic As Dictionary(Of String, String)

        dgElementos.Rows.Clear()

        dDic = getQueryElemento(idser)
        If dDic Is Nothing Then Exit Sub

        'cQue = "SELECT * FROM XMLDigEmpresas WHERE idempresacrm = " & idEmp
        cQue = "SELECT * FROM CEXEmpresas WHERE idempresacrm = " & idEmp
        Using cCom = New SqlCommand(cQue, FC_Con)
            Using cRs = cCom.ExecuteReader()
                cRs.Read()
                If cRs.HasRows Then
                    For Each d In dDic
                        If d.Key() = "NOM" Then
                            If FC_ConexionSQL(cRs("ctBDDNom")) <> 0 Then Exit Sub
                            query = d.Value
                        ElseIf d.Key() = "CON" Then
                            If FC_ConexionSQL(cRs("ctBDDCon")) <> 0 Then Exit Sub
                            query = d.Value
                        ElseIf d.Key() = "ADW" Then
                            If FC_ConexionSQL(cRs("RutaADW")) <> 0 Then Exit Sub
                            query = d.Value
                        End If
                    Next
                End If
            End Using
        End Using

        If query = "" Then Exit Sub

        Using cCom = New SqlCommand(query, FC_SQL)
            Using aCr = cCom.ExecuteReader()
                If idser = 22 Then
                    dgElementos.Columns(1).HeaderText = "Periodo"
                    dgElementos.Columns(1).Width = 492
                    dgElementos.Columns(2).Visible = False
                    Do While aCr.Read()
                        dgElementos.Rows.Add(aCr(0), aCr("nombretipoperiodo") & " " & aCr("diasdelperiodo") & " del " & Format(aCr("fechainicio"), "dd-MM-yyyy") & " al " & Format(aCr("fechafin"), "dd-MM-yyyy"))
                    Loop
                ElseIf idser = 21 Then
                    dgElementos.Columns(2).Visible = True
                    dgElementos.Columns(1).Width = 300
                    dgElementos.Columns(2).Width = 190
                    dgElementos.Columns(1).HeaderText = "Empleado"
                    dgElementos.Columns(2).HeaderText = "NSS"
                    Do While aCr.Read()
                        dgElementos.Rows.Add(aCr(0), aCr(2), aCr(3))
                    Loop
                ElseIf idser = 23 Then
                    dgElementos.Columns(2).Visible = True
                    dgElementos.Columns(1).Width = 300
                    dgElementos.Columns(2).Width = 190
                    dgElementos.Columns(1).HeaderText = "Activo Fijo"
                    dgElementos.Columns(2).HeaderText = "Tipo"
                    Do While aCr.Read()
                        dgElementos.Rows.Add(aCr(0), aCr(2), aCr(3))
                    Loop
                ElseIf idser = 25 Then
                    dgElementos.Columns(1).HeaderText = "Cuentas"
                    dgElementos.Columns(1).Width = 492
                    dgElementos.Columns(2).Visible = False
                    Do While aCr.Read()
                        dgElementos.Rows.Add(aCr("Id"), aCr("Nombre"), aCr("Codigo"))
                    Loop
                End If
            End Using
        End Using
    End Sub

    Private Function getQueryElemento(ByVal idser As Integer)
        Dim Query As String = ""
        Dim dDic As Dictionary(Of String, String)
        Dim Tipo As String = ""
        dDic = New Dictionary(Of String, String)
        Select Case idser
            Case 21 'Nomimas(Empleados)
                Query = "SELECT idempleado, codigoempleado, nombrelargo, numerosegurosocial FROM NOM10001"
                Tipo = "NOM"
            Case 22 'Nominas(Periodos)
                'Query = "SELECT p.idperiodo, p.fechainicio, p.fechafin, t.nombretipoperiodo, t.diasdelperiodo FROM NOM10002 p 
                '        INNER JOIN NOM10023 t ON t.idtipoperiodo = p.idtipoperiodo 
                '        WHERE month(fechafin) <= month(CONVERT(DATE,GETDATE())) ORDER BY fechafin DESC"
                Query = "SELECT p.idperiodo, p.fechainicio, p.fechafin, t.nombretipoperiodo, t.diasdelperiodo FROM NOM10002 p 
                        INNER JOIN NOM10023 t ON t.idtipoperiodo = p.idtipoperiodo 
                        WHERE p.mes <= MONTH(GETDATE()) and p.ejercicio = YEAR(GETDATE()) ORDER BY fechafin DESC"
                Tipo = "NOM"
            Case 23
                Query = "SELECT a.Id, a.codigo, a.activofijo, t.tipo 
                        FROM zACFActivos a INNER JOIN zACFTipos t ON t.id = a.tipoact
                        ORDER BY t.tipo"
                Tipo = "CON"
            Case 25
                Query = "SELECT Id, Codigo, Nombre FROM CuentasCheques"
                Tipo = "CON"
        End Select
        dDic.Add(Tipo, Query)
        getQueryElemento = dDic
    End Function

    Private Sub Carga_TiposDocto(ByVal idser As Integer, ByVal idEmp As Integer)
        Dim cQue As String
        'cQue = "SELECT * FROM XMLDigEmpresas WHERE idempresacrm = " & idEmp
        cQue = "SELECT * FROM CEXEmpresas WHERE idempresacrm = " & idEmp
        Using cCom = New SqlCommand(cQue, FC_Con)
            Using cRs = cCom.ExecuteReader()
                cRs.Read()
                If cRs.HasRows Then
                    If FC_ConexionSQL(cRs("ctBDDCon")) <> 0 Then Exit Sub
                End If
            End Using
        End Using

        dgTiposDocto.Rows.Clear()
        'cQue = "SELECT * FROM XMLDigTiposDoctoConfig WHERE id_serviciocrm = " & idser
        cQue = "SELECT * FROM zCEXTiposDocto WHERE id_serviciocrm = " & idser
        Using cCom = New SqlCommand(cQue, FC_SQL)
            Using aCr = cCom.ExecuteReader()
                Do While aCr.Read()
                    dgTiposDocto.Rows.Add(aCr("id"), aCr("tipo_docto"))
                Loop
            End Using
        End Using
    End Sub

    Private Sub TbFiltroEle_TextChanged(sender As Object, e As EventArgs) Handles TbFiltroEle.TextChanged
        Dim Criterio As String
        Criterio = UCase(TbFiltroEle.Text)
        For Each Fila As DataGridViewRow In dgElementos.Rows
            If InStr(1, UCase(Fila.Cells(1).Value), Criterio) <> 0 Then
                dgElementos.CurrentCell = Nothing
                dgElementos.Rows(Fila.Index).Visible = True
            ElseIf InStr(1, UCase(Fila.Cells(2).Value), Criterio) <> 0 Then
                dgElementos.CurrentCell = Nothing
                dgElementos.Rows(Fila.Index).Visible = True
            Else
                dgElementos.CurrentCell = Nothing
                dgElementos.Rows(Fila.Index).Visible = False
            End If
        Next
    End Sub

    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        Dim sQue As String, mensaje As String
        Dim sIDDoc As Integer

        If rbasoc.Checked = False Then Exit Sub

        If dgDocDigitales.CurrentRow Is Nothing Then
            MsgBox("No ha seleccionado documento digital", vbInformation, "Validación")
            Exit Sub
        ElseIf dgDocDigitales.CurrentRow.Selected = False Then
            MsgBox("No ha seleccionado documento digital", vbInformation, "Validación")
            Exit Sub
        End If

        mensaje = MsgBox("¿Desea desasociar el documento digital seleccionado?", vbQuestion + vbYesNo, ("Eliminar Registros"))
        If mensaje = vbYes Then
            'sQue = "SELECT * FROM XMLDigEmpresas WHERE idempresacrm = " & CInt(cbempresa.SelectedValue)
            sQue = "SELECT * FROM CEXEmpresas WHERE idempresacrm = " & CInt(cbempresa.SelectedValue)
            Using cCom = New SqlCommand(sQue, FC_Con)
                Using cRs = cCom.ExecuteReader()
                    cRs.Read()
                    If cRs.HasRows Then
                        If FC_ConexionSQL(cRs("ctBDDCon")) <> 0 Then Exit Sub
                    End If
                End Using
            End Using

            sIDDoc = CInt(dgDocDigitales.Item(0, dgDocDigitales.CurrentRow.Index).Value)
            'sQue = "SELECT * FROM XMLDigAsocExped WHERE iddocdig=@iddoc;"
            sQue = "SELECT e.*, t.id_serviciocrm  FROM zClipExped e INNER JOIN zCEXTiposDocto t ON t.id = e.tipo WHERE iddigital=@iddoc;"
            Using sCom = New SqlCommand(sQue, FC_SQL)
                sCom.Parameters.AddWithValue("@iddoc", sIDDoc)
                Using cRs = sCom.ExecuteReader()
                    cRs.Read()
                    If cRs.HasRows() Then
                        If ClipMarcadoCRM(Obtener_RFC(CInt(cbempresa.SelectedValue)), 0, getIDSubMenu(cRs("id_serviciocrm")), "", "", cRs("periodo"), cRs("ejercicio"), False, sIDDoc) = True Then
                            'sQue = "DELETE FROM XMLDigAsocExped WHERE iddocdig=@iddoc;"
                            sQue = "DELETE FROM zClipExped WHERE iddigital=@iddoc;"
                            Using Con = New SqlCommand(sQue, FC_SQL)
                                Con.Parameters.AddWithValue("@iddoc", sIDDoc)
                                Con.ExecuteNonQuery()
                            End Using

                            For Each Fila As DataGridViewRow In dgServicios.Rows
                                If Fila.Cells(0).Value = cRs("id_serviciocrm") Then
                                    If Fila.Cells(9).Value > 0 Then
                                        Fila.Cells(9).Value = Fila.Cells(9).Value - 1
                                    End If
                                    Exit For
                                End If
                            Next

                        Else
                            MsgBox("Hubo un error y no se pudo eliminar la asociacion, volver a intentar, si el error persiste, comuniquese a sistemas.", vbInformation)
                            Exit Sub
                        End If
                    End If
                End Using
            End Using

            dgDocDigitales.Item(1, dgDocDigitales.CurrentRow.Index).Value = ""
            Marca_Procesado(sIDDoc, 0)
            Filtro_Documentos()
        End If
    End Sub

    Private Sub BTConfigEmpresas_Click(sender As Object, e As EventArgs) Handles BTConfigEmpresas.Click
        frmConfigExpedientes.ShowDialog()
    End Sub

    Private Sub dgDocDigitales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDocDigitales.CellClick
        Dim element As String = "", elementValue As String = ""
        Dim cQue As String = ""
        Dim idservicio As Integer, servicio As String, tipodocto As String

        LInfo.Text = ""

        With dgDocDigitales
            If rbasoc.Checked Then

                'cQue = "SELECT * FROM XMLDigEmpresas WHERE idempresacrm = " & CInt(cbempresa.SelectedValue)
                cQue = "SELECT * FROM CEXEmpresas WHERE idempresacrm = " & CInt(cbempresa.SelectedValue)
                Using cCom = New SqlCommand(cQue, FC_Con)
                    Using cRs = cCom.ExecuteReader()
                        cRs.Read()
                        If cRs.HasRows Then
                            If FC_ConexionSQL(cRs("ctBDDCon")) <> 0 Then Exit Sub
                        End If
                    End Using
                End Using

                'cQue = "SELECT a.idservicio, a.nombreservicio, a.elemento, t.tipo_docto FROM XMLDigAsocExped a INNER JOIN XMLDigTiposDoctoConfig t ON t.id = a.idtipodocto WHERE iddocdig = " & CInt(.Item(0, .CurrentRow.Index).Value)
                cQue = "SELECT t.id_serviciocrm,  a.idcuenta, a.idmodulo, t.tipo_docto FROM zClipExped a INNER JOIN zCEXTiposDocto t ON t.id = a.tipo WHERE iddigital = " & CInt(.Item(0, .CurrentRow.Index).Value)
                Using cCom = New SqlCommand(cQue, FC_SQL)
                    Using aCr = cCom.ExecuteReader()
                        If aCr.HasRows Then
                            aCr.Read()
                            idservicio = aCr("id_serviciocrm")
                            'servicio = aCr("nombreservicio")
                            servicio = getNombreServicio(aCr("id_serviciocrm"))
                            tipodocto = aCr("tipo_docto")
                            'elementValue = aCr("elemento")
                            elementValue = getElemento(aCr("idcuenta"), aCr("idmodulo"))
                        End If
                    End Using
                End Using

                If idservicio = 21 Then
                    element = "Empleado: "
                ElseIf idservicio = 22 Then
                    element = "Periodo: "
                ElseIf idservicio = 23 Then
                    element = "Activo Fijo: "
                ElseIf idservicio = 25 Then
                    element = "Bancos: "
                End If

                LInfo.Text = "Documento Digital: " & .Item(3, .CurrentRow.Index).Value & vbCrLf &
                             "Servicio: " & servicio & vbCrLf &
                             element & elementValue & vbCrLf &
                             "Tipo de Documento: " & tipodocto
            End If
        End With
    End Sub

    Private Sub btGenera_Click(sender As Object, e As EventArgs) Handles btGenera.Click
        Dim IdSer As Integer
        Dim Query As String
        If cbempresa.SelectedIndex = 0 Then
            MsgBox("Seleccione una empresa.")
            Exit Sub
        End If

        ConEmpresaSQL(IDEmp)

        IDEmp = CInt(cbempresa.SelectedValue)
        frmGeneraDoctos.ShowDialog()

        For Each Fila As DataGridViewRow In dgServicios.Rows
            IdSer = Fila.Cells(0).Value
            'Query = "SELECT sum(doctos_pendientes) as pendientes FROM XMLDigTiposDoctoConfig WHERE id_serviciocrm = " & IdSer
            'Query = "SELECT sum(doctos_pendientes) as pendientes FROM zCEXTiposDocto WHERE id_serviciocrm = " & IdSer
            Query = "SELECT count(e.id) AS pendientes FROM zClipExped e INNER JOIN zCEXTiposDocto t ON t.id = e.tipo WHERE t.id_serviciocrm =" & IdSer & " and e.procesado = 0"
            Using cCom = New SqlCommand(Query, FC_SQL)
                Using Rs = cCom.ExecuteReader()
                    Rs.Read()
                    If Rs.HasRows Then
                        Fila.Cells(9).Value = Rs("pendientes")
                    End If
                End Using
            End Using
        Next
    End Sub



    Public Function getElemento(idElemento As Integer, idMod As Integer) As String
        Dim valor As String = ""
        If idMod = 1 Then
            Using Con = New SqlCommand("", FC_Nom)

            End Using
        Else
            Using Con = New SqlCommand("", FC_Con)

            End Using
        End If
        getElemento = valor
    End Function

    Private Sub dgServicios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgServicios.CellContentClick

    End Sub

    Private Sub dgDocDigitales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDocDigitales.CellContentClick

    End Sub
End Class