Imports System.IO
Imports System.Data.SqlClient
Public Class frmConfigTiposDocto
    Private bLoaded As Boolean
    'Private cServicios As Collection
    Private iTipoDocto As Integer
    Private Sub frmConfigServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bLoaded = False
        dgServiciosEmpresa.Rows.Clear()
        'Carga_Empresas(Me.CBEmpresas)
        GL_cUsuarioAPI.lista_empresas()
        getEmpresasExpedientes(Me.CBEmpresas)
        'Carga_ServiciosGenerales()
        iTipoDocto = 0
        getServicios()
        showServicios(CBServicios)
        showServicios(CBServiciosg)
        CargaTiposDoctoGenerales()
        bLoaded = True
    End Sub
    Private Sub CargaTiposDoctoGenerales()
        Dim cQue As String
        dgServiciosGenerales.Rows.Clear()
        cQue = "SELECT * FROM CEXTiposDocto"
        Using cCom1 = New SqlCommand(cQue, FC_Con)
            Using aCr = cCom1.ExecuteReader()
                Do While aCr.Read()
                    dgServiciosGenerales.Rows.Add(aCr("id"), aCr("tipo_docto"), aCr("id_serviciocrm"), getCodServicio(aCr("id_serviciocrm")), getNombreServicio(aCr("id_serviciocrm")), getEstatusServicio(aCr("id_serviciocrm")), aCr("clave"), aCr("id_modulo"))
                Loop
            End Using
        End Using
    End Sub
    Private Sub CBEmpresas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBEmpresas.SelectedIndexChanged
        If bLoaded = False Then Exit Sub
        'getServicios()
        cargaTiposDocto()
        'showServicios(CBServicios)
    End Sub
    Private Sub cargaTiposDocto()
        Dim idEmp As Integer
        Dim cQue As String
        'Dim sEstatus As String
        'Dim s As clServicios
        idEmp = CInt(CBEmpresas.SelectedValue)
        If idEmp > 0 Then
            Try
                ConEmpresaSQL(idEmp)

                crearTablasExpedientes()

                dgServiciosEmpresa.Rows.Clear()

                cQue = "SELECT * FROM zCEXTiposDocto"
                Using dCom = New SqlCommand(cQue, FC_SQL)
                    Using aCr = dCom.ExecuteReader()
                        If aCr.HasRows Then
                            Do While aCr.Read()
                                dgServiciosEmpresa.Rows.Add(aCr("id"), aCr("tipo_docto"), aCr("id_serviciocrm"), getCodServicio(aCr("id_serviciocrm")), getNombreServicio(aCr("id_serviciocrm")), getEstatusServicio(aCr("id_serviciocrm")), aCr("clave"), aCr("id_modulo"))
                            Loop
                        Else
                            CopiarServicios(idEmp)
                        End If
                    End Using
                End Using

                dgServiciosEmpresa.ClearSelection()

            Catch ex As Exception
                MsgBox("Error al cambiar de Empresa." & vbCrLf & ex.Message, vbExclamation, "Validación")
            End Try
        End If
    End Sub

    Private Sub getServicios()
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String, sev As clServicios

        cServicios = New Collection
        'dFiltro = "?usuario=" & GL_cUsuarioAPI.Correo & "&pwd=" & GL_cUsuarioAPI.EncryptedContra & "&rfc=" & Obtener_RFC(CInt(CBEmpresas.SelectedValue)) & "&idempresa=" & CInt(CBEmpresas.SelectedValue) & "&idsubmenu=40"
        'dMetodo = "getServiciosEmpresaCliente"
        'dFiltro = "{""correo"":""" & GL_cUsuarioAPI.Correo & """, ""contra"":""" & GL_cUsuarioAPI.Contra & """}"
        dFiltro = "{" & Chr(34) & "correo" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Correo & Chr(34) & "," &
                        Chr(34) & "contra" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Contra & Chr(34) & "}"
        dMetodo = "serviciosfc"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod <> "false" Then
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                If Not jsonObject("servicio") Is Nothing Then
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
                End If
            End If
        End If
    End Sub

    Private Function Obtener_RFC(ByVal eIDEm As Integer) As String
        Dim vEmpresa As clEmpresa
        Obtener_RFC = ""
        For Each vEmpresa In GL_cUsuarioAPI.MEmpresas
            If vEmpresa.Idempresa = eIDEm Then
                Obtener_RFC = vEmpresa.Rfc
                Exit For
            End If
        Next
    End Function

    Private Sub CopiarServicios(ByVal idEmp As Integer)
        Dim cQue As String

        ConEmpresaSQL(idEmp)

        'cQue = "SELECT * FROM XMLDigTiposDocto"
        cQue = "SELECT * FROM CEXTiposDocto"
        Using cCom1 = New SqlCommand(cQue, FC_Con)
            Using cRs = cCom1.ExecuteReader()
                'cRs.Read()
                If Not cRs.HasRows Then
                    MsgBox("Tabla general de tipos de documentos esta vacia, comunicarse a sistemas.", vbInformation)
                    Exit Sub
                Else
                    'cQue = "INSERT INTO XMLDigTiposDoctoConfig(tipo_docto, id_serviciocrm, codigo_serviciocrm, serviciocrm, estatuscrm) VALUES (@tipo, @idser, @codser, @ser, @estatus)"
                    cQue = "INSERT INTO zCEXTiposDocto(tipo_docto, id_serviciocrm, id_modulo, clave) VALUES (@tipo, @idser, @idmod, @clave)"
                    Using cCom3 = New SqlCommand(cQue, FC_SQL)
                        Do While cRs.Read()
                            cCom3.Parameters.Clear()
                            cCom3.Parameters.AddWithValue("@tipo", cRs("tipo_docto"))
                            cCom3.Parameters.AddWithValue("@idser", cRs("id_serviciocrm"))
                            cCom3.Parameters.AddWithValue("@idmod", cRs("id_modulo"))
                            cCom3.Parameters.AddWithValue("@clave", cRs("clave"))
                            'cCom3.Parameters.AddWithValue("@codser", cRs("codigo_serviciocrm"))
                            'cCom3.Parameters.AddWithValue("@ser", cRs("serviciocrm"))
                            'cCom3.Parameters.AddWithValue("@estatus", cRs("estatuscrm"))
                            cCom3.ExecuteNonQuery()
                        Loop
                    End Using
                End If
            End Using
        End Using

        'Dim sEstatus As String
        'cQue = "SELECT * FROM XMLDigTiposDoctoConfig"
        cQue = "SELECT * FROM zCEXTiposDocto"
        Using dCom = New SqlCommand(cQue, FC_SQL)
            Using aCr = dCom.ExecuteReader()
                Do While aCr.Read()
                    dgServiciosEmpresa.Rows.Add(aCr("id"), aCr("tipo_docto"), aCr("id_serviciocrm"), getCodServicio(aCr("id_serviciocrm")), getNombreServicio(aCr("id_serviciocrm")), getEstatusServicio(aCr("id_serviciocrm")))
                Loop
            End Using
        End Using

    End Sub

    Private Sub BTNuevo_Click(sender As Object, e As EventArgs) Handles BTNuevo.Click
        LimpiaForm()
    End Sub
    Private Sub LimpiaForm()
        TBDocto.Clear()
        CkEstatus.Checked = True
        dgServiciosEmpresa.ClearSelection()
        TBFiltro.Clear()
        CBServicios.SelectedIndex = 0
        iTipoDocto = 0
        tbClave.Clear()
    End Sub
    Private Sub BTNuevog_Click(sender As Object, e As EventArgs) Handles BTNuevog.Click
        LimpiaForm2()
    End Sub

    Private Sub LimpiaForm2()
        TbDoctog.Clear()
        CkEstatusg.Checked = True
        dgServiciosGenerales.ClearSelection()
        TBFiltrog.Clear()
        CBServiciosg.SelectedIndex = 0
        iTipoDocto = 0
        tbClaveg.Clear()
    End Sub

    Private Sub showServicios(ByVal cb As ComboBox)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim s As clServicios

        dt = New DataTable("Servicios")
        dt.Columns.Add("id")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("idfcmodulo")

        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "SELECCIONAR SERVICIO"
        dr(2) = 0
        dt.Rows.Add(dr)

        For Each s In cServicios
            dr = dt.NewRow
            dr(0) = s.Idservicio
            dr(1) = s.Servicio
            dr(2) = s.Idfcmodulo
            dt.Rows.Add(dr)
        Next

        cb.DataSource = dt
        cb.ValueMember = "id"
        cb.DisplayMember = "Nombre"
    End Sub

    Private Sub BTSalir_Click(sender As Object, e As EventArgs) Handles BTSalir.Click
        Me.Close()
    End Sub

    Private Sub TBFiltro_TextChanged(sender As Object, e As EventArgs) Handles TBFiltro.TextChanged
        Dim Criterio As String
        Criterio = UCase(TBFiltro.Text)
        For Each Fila As DataGridViewRow In dgServiciosEmpresa.Rows
            If InStr(1, UCase(Fila.Cells(1).Value), Criterio) <> 0 Then
                dgServiciosEmpresa.CurrentCell = Nothing
                dgServiciosEmpresa.Rows(Fila.Index).Visible = True
            ElseIf InStr(1, UCase(Fila.Cells(3).Value), Criterio) <> 0 Then
                dgServiciosEmpresa.CurrentCell = Nothing
                dgServiciosEmpresa.Rows(Fila.Index).Visible = True
            ElseIf InStr(1, UCase(Fila.Cells(4).Value), Criterio) <> 0 Then
                dgServiciosEmpresa.CurrentCell = Nothing
                dgServiciosEmpresa.Rows(Fila.Index).Visible = True
            Else
                dgServiciosEmpresa.CurrentCell = Nothing
                dgServiciosEmpresa.Rows(Fila.Index).Visible = False
            End If
        Next
    End Sub

    Private Sub BTElimina_Click(sender As Object, e As EventArgs) Handles BTElimina.Click
        Dim idTipo As Integer, cQue As String, mensaje As String
        If dgServiciosEmpresa.CurrentRow Is Nothing Then
            MsgBox("No ha seleccionado el tipo de documento", vbInformation, "Validación")
            Exit Sub
        ElseIf dgServiciosEmpresa.CurrentRow.Selected = False Then
            MsgBox("No ha seleccionado el tipo de documento.", vbInformation, "Validación")
            Exit Sub
        End If

        mensaje = MsgBox("Desea eliminar el tipo de documento seleccionado", vbQuestion + vbYesNo, ("Eliminar Registros"))
        If mensaje = vbYes Then

            ConEmpresaSQL(CInt(CBEmpresas.SelectedValue))

            idTipo = CInt(dgServiciosEmpresa.Item(0, dgServiciosEmpresa.CurrentRow.Index).Value)
            'cQue = "DELETE FROM XMLDigTiposDoctoConfig WHERE id = " & idTipo
            cQue = "DELETE FROM zCEXTiposDocto WHERE id = " & idTipo
            Using dCom = New SqlCommand(cQue, FC_SQL)
                dCom.ExecuteNonQuery()
            End Using

            LimpiaForm()
            cargaTiposDocto()
        End If
    End Sub

    Private Sub BTSalirg_Click(sender As Object, e As EventArgs) Handles BTSalirg.Click
        Me.Close()
    End Sub

    Private Sub BTEliminag_Click(sender As Object, e As EventArgs) Handles BTEliminag.Click
        Dim idTipo As Integer, cQue As String, mensaje As String
        If dgServiciosGenerales.CurrentRow Is Nothing Then
            MsgBox("No ha seleccionado el tipo de documento", vbInformation, "Validación")
            Exit Sub
        ElseIf dgServiciosGenerales.CurrentRow.Selected = False Then
            MsgBox("No ha seleccionado el tipo de documento.", vbInformation, "Validación")
            Exit Sub
        End If

        mensaje = MsgBox("Desea eliminar el tipo de documento seleccionado", vbQuestion + vbYesNo, ("Eliminar Registros"))
        If mensaje = vbYes Then

            idTipo = CInt(dgServiciosGenerales.Item(0, dgServiciosGenerales.CurrentRow.Index).Value)
            'cQue = "DELETE FROM XMLDigTiposDocto WHERE id = " & idTipo
            cQue = "DELETE FROM CEXTiposDocto WHERE id = " & idTipo
            Using dCom = New SqlCommand(cQue, FC_Con)
                dCom.ExecuteNonQuery()
            End Using

            LimpiaForm2()
            CargaTiposDoctoGenerales()
        End If
    End Sub

    Private Sub CkEstatus_CheckedChanged(sender As Object, e As EventArgs) Handles CkEstatus.CheckedChanged

    End Sub

    Private Sub BTAgrega_Click(sender As Object, e As EventArgs) Handles BTAgrega.Click
        Dim TipoDocto As String
        Dim idser As Integer
        Dim servicio As String
        Dim estatus As Boolean
        Dim cQue As String
        Dim codSer As String
        Dim idmod As Integer
        Dim clave As String
        Dim dt As DataTable
        Dim dr As DataRow

        If CBEmpresas.SelectedIndex = 0 Then MsgBox("Seleccione la empresa", vbInformation) : Exit Sub
        If TBDocto.Text = "" Then MsgBox("Campo de documento vacio", vbInformation) : Exit Sub
        If CBServicios.SelectedIndex = 0 Then MsgBox("Seleccione el sericio al que pertenece", vbInformation) : Exit Sub

        dt = CBServicios.DataSource
        dr = dt.Rows(CBServicios.SelectedIndex)
        idmod = dr("idfcmodulo")

        If idmod = ModExped_Bancos Then
            If tbClave.Text = "" Then MsgBox("Campo de clave vacio", vbInformation) : Exit Sub
        ElseIf idmod = ModExped_Activos Then
            If dr("id") = SerCalculosActivos Then
                If tbClave.Text = "" Then MsgBox("Campo de clave vacio", vbInformation) : Exit Sub
            End If
        End If

        TipoDocto = TBDocto.Text
        idser = CInt(CBServicios.SelectedValue)
        servicio = CBServicios.Text
        estatus = IIf(CkEstatus.Checked, True, False)
        codSer = getCodSer(idser)
        clave = tbClave.Text

        ConEmpresaSQL(CInt(CBEmpresas.SelectedValue))

        If iTipoDocto = 0 Then 'Nuevo
            cQue = "INSERT INTO zCEXTiposDocto(tipo_docto, id_serviciocrm, id_modulo, clave) 
                    VALUES (@tipo, @idser, @idmod, @clave)"
            Using cCom3 = New SqlCommand(cQue, FC_SQL)
                cCom3.Parameters.AddWithValue("@tipo", TipoDocto)
                cCom3.Parameters.AddWithValue("@idser", idser)
                cCom3.Parameters.AddWithValue("@idmod", idmod)
                cCom3.Parameters.AddWithValue("@clave", clave)
                cCom3.ExecuteNonQuery()
            End Using
            MsgBox("Tipo de documento agregado correctamente", vbInformation)
            LimpiaForm()
            cargaTiposDocto()
        Else 'Actualiza
            cQue = "UPDATE zCEXTiposDocto 
                    SET tipo_docto=@tipodocto, id_serviciocrm=@idser, id_modulo=@idmod 
                    WHERE id=@idtipo"
            Using cCom = New SqlCommand(cQue, FC_SQL)
                cCom.Parameters.AddWithValue("@tipodocto", TipoDocto)
                cCom.Parameters.AddWithValue("@idser", idser)
                cCom.Parameters.AddWithValue("@idmod", idmod)
                cCom.Parameters.AddWithValue("@idtipo", iTipoDocto)
                cCom.Parameters.AddWithValue("@clave", clave)
                cCom.ExecuteNonQuery()
            End Using
            MsgBox("Tipo de documento actualizado correctamente", vbInformation)
        End If


    End Sub

    Private Function getCodSer(ByVal idser As Integer)
        Dim s As clServicios
        Dim cod As String = ""
        For Each s In cServicios
            If s.Idservicio = idser Then
                cod = s.CodigoServicio
                Exit For
            End If
        Next
        getCodSer = cod
    End Function

    Private Sub dgServiciosEmpresa_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgServiciosEmpresa.CellClick
        Dim i As Integer
        Dim tipodocto As String, servicio As String, activo As String, clave As String

        tbClave.Enabled = False
        'idTipo = CInt(dgServiciosEmpresa.Item(0, dgServiciosEmpresa.CurrentRow.Index).Value)
        iTipoDocto = CInt(dgServiciosEmpresa.Item(0, dgServiciosEmpresa.CurrentRow.Index).Value)
        tipodocto = dgServiciosEmpresa.Item(1, dgServiciosEmpresa.CurrentRow.Index).Value
        servicio = dgServiciosEmpresa.Item(4, dgServiciosEmpresa.CurrentRow.Index).Value
        activo = dgServiciosEmpresa.Item(5, dgServiciosEmpresa.CurrentRow.Index).Value
        clave = IIf(Not IsDBNull(dgServiciosEmpresa.Item(6, dgServiciosEmpresa.CurrentRow.Index).Value),
                       dgServiciosEmpresa.Item(6, dgServiciosEmpresa.CurrentRow.Index).Value, "")
        TBDocto.Text = tipodocto
        tbClave.Text = clave

        If CInt(dgServiciosEmpresa.Item(7, dgServiciosEmpresa.CurrentRow.Index).Value) = 3 Then
            tbClave.Enabled = True
        End If

        i = 0
        For Each item As Object In CBServicios.Items
            If item("Nombre") = servicio Then
                CBServicios.SelectedIndex = i
                Exit For
            End If
            i = i + 1
        Next

        If activo = "Activo" Then
            CkEstatus.Checked = True
        Else
            CkEstatus.Checked = False
        End If
    End Sub


    Private Sub BTAgregag_Click(sender As Object, e As EventArgs) Handles BTAgregag.Click
        Dim TipoDocto As String
        Dim idser As Integer
        Dim servicio As String
        Dim estatus As Boolean
        Dim cQue As String
        Dim codSer As String
        Dim idmod As Integer
        Dim dt As DataTable
        Dim dr As DataRow
        Dim clave As String = ""

        If TbDoctog.Text = "" Then MsgBox("Campo de documento vacio", vbInformation) : Exit Sub
        If CBServiciosg.SelectedIndex = 0 Then MsgBox("Seleccione el sericio al que pertenece", vbInformation) : Exit Sub

        dt = CBServiciosg.DataSource
        dr = dt.Rows(CBServiciosg.SelectedIndex)
        idmod = dr("idfcmodulo")


        If idmod = ModExped_Bancos Then
            If tbClaveg.Text = "" Then MsgBox("Campo de clave vacio", vbInformation) : Exit Sub
        ElseIf idmod = ModExped_Activos Then
            If dr("id") = SerCalculosActivos Then
                If tbClave.Text = "" Then MsgBox("Campo de clave vacio", vbInformation) : Exit Sub
            End If
        End If

        TipoDocto = TbDoctog.Text
        idser = CInt(CBServiciosg.SelectedValue)
        servicio = CBServiciosg.Text
        estatus = IIf(CkEstatusg.Checked, True, False)
        codSer = getCodSer(idser)
        clave = tbClaveg.Text

        If iTipoDocto = 0 Then 'Nuevo
            cQue = "INSERT INTO CEXTiposDocto(tipo_docto, id_serviciocrm, id_modulo, clave) 
                    VALUES (@tipo, @idser, @idmod, @clave)"
            Using cCom3 = New SqlCommand(cQue, FC_Con)
                cCom3.Parameters.AddWithValue("@tipo", TipoDocto)
                cCom3.Parameters.AddWithValue("@idser", idser)
                cCom3.Parameters.AddWithValue("@idmod", idmod)
                cCom3.Parameters.AddWithValue("@clave", clave)
                cCom3.ExecuteNonQuery()
            End Using
            MsgBox("Tipo de documento agregado correctamente", vbInformation)
            LimpiaForm2()
            CargaTiposDoctoGenerales()
        Else 'Actualiza
            cQue = "UPDATE CEXTiposDocto 
                    SET tipo_docto=@tipodocto, id_serviciocrm=@idser, id_modulo=@idmod, clave=@clave
                    WHERE id=@idtipo"
            Using cCom = New SqlCommand(cQue, FC_Con)
                cCom.Parameters.AddWithValue("@tipodocto", TipoDocto)
                cCom.Parameters.AddWithValue("@idser", idser)
                cCom.Parameters.AddWithValue("@idmod", idmod)
                cCom.Parameters.AddWithValue("@clave", clave)
                cCom.Parameters.AddWithValue("@idtipo", iTipoDocto)
                cCom.ExecuteNonQuery()
            End Using
            MsgBox("Tipo de documento actualizado correctamente", vbInformation)
        End If
    End Sub

    Private Sub TBFiltrog_TextChanged(sender As Object, e As EventArgs) Handles TBFiltrog.TextChanged
        Dim Criterio As String
        Criterio = UCase(TBFiltrog.Text)
        For Each Fila As DataGridViewRow In dgServiciosGenerales.Rows
            If InStr(1, UCase(Fila.Cells(1).Value), Criterio) <> 0 Then
                dgServiciosGenerales.CurrentCell = Nothing
                dgServiciosGenerales.Rows(Fila.Index).Visible = True
            ElseIf InStr(1, UCase(Fila.Cells(3).Value), Criterio) <> 0 Then
                dgServiciosGenerales.CurrentCell = Nothing
                dgServiciosGenerales.Rows(Fila.Index).Visible = True
            ElseIf InStr(1, UCase(Fila.Cells(4).Value), Criterio) <> 0 Then
                dgServiciosGenerales.CurrentCell = Nothing
                dgServiciosGenerales.Rows(Fila.Index).Visible = True
            Else
                dgServiciosGenerales.CurrentCell = Nothing
                dgServiciosGenerales.Rows(Fila.Index).Visible = False
            End If
        Next
    End Sub

    Private Sub CBServicios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBServicios.SelectedIndexChanged
        Dim dt As DataTable
        Dim dr As DataRow
        ' If iTipoDocto <> 0 Then Exit Sub

        dt = CBServicios.DataSource
        dr = dt.Rows(CBServicios.SelectedIndex)
        If dr("idfcmodulo") = ModExped_Bancos Then
            tbClave.Enabled = True
        ElseIf dr("idfcmodulo") = ModExped_Activos And SerCalculosActivos = dr("id") Then
            tbClave.Enabled = True
        Else
            tbClave.Enabled = False
        End If
    End Sub

    Private Sub dgServiciosGenerales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgServiciosGenerales.CellClick
        Dim i As Integer
        Dim tipodocto As String, servicio As String, activo As String, clave As String

        tbClaveg.Enabled = False
        'idTipo = CInt(dgServiciosEmpresa.Item(0, dgServiciosEmpresa.CurrentRow.Index).Value)
        iTipoDocto = CInt(dgServiciosGenerales.Item(0, dgServiciosGenerales.CurrentRow.Index).Value)
        tipodocto = dgServiciosGenerales.Item(1, dgServiciosGenerales.CurrentRow.Index).Value
        servicio = dgServiciosGenerales.Item(4, dgServiciosGenerales.CurrentRow.Index).Value
        activo = dgServiciosGenerales.Item(5, dgServiciosGenerales.CurrentRow.Index).Value
        clave = IIf(Not IsDBNull(dgServiciosGenerales.Item(6, dgServiciosGenerales.CurrentRow.Index).Value),
                       dgServiciosGenerales.Item(6, dgServiciosGenerales.CurrentRow.Index).Value, "")
        TbDoctog.Text = tipodocto
        tbClaveg.Text = clave

        If CInt(dgServiciosGenerales.Item(7, dgServiciosGenerales.CurrentRow.Index).Value) = 3 Then
            tbClaveg.Enabled = True
        End If

        i = 0
        For Each item As Object In CBServiciosg.Items
            If item("Nombre") = servicio Then
                CBServiciosg.SelectedIndex = i
                Exit For
            End If
            i = i + 1
        Next

        If activo = "Activo" Then
            CkEstatusg.Checked = True
        Else
            CkEstatusg.Checked = False
        End If
    End Sub

    Private Sub CBServiciosg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBServiciosg.SelectedIndexChanged
        Dim dt As DataTable
        Dim dr As DataRow

        dt = CBServiciosg.DataSource
        dr = dt.Rows(CBServiciosg.SelectedIndex)
        If dr("idfcmodulo") = ModExped_Bancos Then
            tbClaveg.Enabled = True
        ElseIf dr("idfcmodulo") = ModExped_Activos And SerCalculosActivos = dr("id") Then
            tbClave.Enabled = True
        Else
            tbClaveg.Enabled = False
        End If
    End Sub

    Private Sub TPTipos_Click(sender As Object, e As EventArgs) Handles TPTipos.Click

    End Sub

    Private Sub dgServiciosEmpresa_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgServiciosEmpresa.CellContentClick

    End Sub
End Class