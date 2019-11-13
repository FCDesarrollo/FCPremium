Public Class frmdigital
    Private sBandLoad As Boolean
    Private Sub Frmdigital_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LUser.Text = "Usuario: " & GL_cUsuarioAPI.Nombreuser & " " & GL_cUsuarioAPI.Apellidop & " " & GL_cUsuarioAPI.Apellidom
        txtEjercicio.Text = Year(Now)
        cbPeriodo.SelectedIndex = 0
        Carga_submenus(Menu_Digital_Operacion)
        sBandLoad = True
        Carga_Empresas(cbempresa)
        sBandLoad = False

    End Sub

    Private Sub Carga_Permisos(ByVal cIDEmpresa As Integer)
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String, subM As clSubMenu
        Dim dt As DataTable
        Dim dr As DataRow
        dt = New DataTable("operaciones")
        dt.Columns.Add("id")
        dt.Columns.Add("Nombre")

        dr = dt.NewRow
        dr(0) = -1
        dr(1) = "SELECCIONAR OPERACIÓN"
        dt.Rows.Add(dr)



        dMetodo = "PermisoSubMenus?idusuario=" & GL_cUsuarioAPI.Iduser &
                    "&idempresa=" & cIDEmpresa & "&idmenu=" & Menu_Digital_Operacion
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "GET")
        If jsonMod <> "" Then
            jsonMod = "{ ""permiso"":" & jsonMod & "}"
            jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
            For Each Row In jsonObject("permiso")
                If CInt(Row("tipopermiso")) <> 0 Then
                    For Each subM In GL_SubMenu
                        If CInt(Row("idsubmenu")) = subM.Idsubmenu Then
                            dr = dt.NewRow
                            dr(0) = subM.Idsubmenu
                            dr(1) = subM.Nombresubmenu
                            dt.Rows.Add(dr)
                            Exit For
                        End If
                    Next

                End If
            Next
        End If

        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "TODOS"
        dt.Rows.Add(dr)

        cboperacion.DataSource = dt
        cboperacion.ValueMember = "id"
        cboperacion.DisplayMember = "Nombre"
    End Sub



    Private Sub Cbempresa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbempresa.SelectedIndexChanged
        Dim idEmp As Integer
        If sBandLoad = True Then Exit Sub
        idEmp = CInt(cbempresa.SelectedValue)
        If idEmp > 0 Then
            Carga_Permisos(idEmp)
        End If
    End Sub

    Private Sub DConfig_Click(sender As Object, e As EventArgs) Handles DConfig.Click
        frmConfigDigital.ShowDialog()
    End Sub

    Private Sub DCerrar_Click(sender As Object, e As EventArgs) Handles DCerrar.Click
        Me.Close()
    End Sub
End Class