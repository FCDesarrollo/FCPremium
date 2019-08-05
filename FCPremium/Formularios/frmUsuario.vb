Imports System.Data.SqlClient

Public Class frmUsuario
    Private Sub FrmUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarCombo()
        cargaModu()
        CargaUsuarios()

    End Sub

    Private Sub cargaModu()
        Dim cQue As String

        dgmodulos.Rows.Clear()


        fError = FC_Conexion()
        If fError <> 0 Then Exit Sub

        cQue = "SELECT idmodulo,nombre_modulo FROM FCModulos WHERE permiso=1"
        Using dCom = New SqlCommand(cQue, FC_Con)
            Using mRs = dCom.ExecuteReader()
                Do While mRs.Read()
                    dgmodulos.Rows.Add(mRs("idmodulo"), mRs("nombre_modulo"), False)
                Loop
            End Using
        End Using
        dgmodulos.ClearSelection()
    End Sub

    Private Sub CargaUsuarios()
        Dim uQue As String, stip As String
        Dim fFiltro As String

        dgusuarios.Rows.Clear()

        fFiltro = IIf(cUsuario.Tipo = tAdmin, "", IIf(cUsuario.Tipo = tSupervisor,
                                                     "WHERE tipo <> " & tAdmin, ""))
        uQue = "SELECT idusuario, nombre, apellido_p, apellido_m, usuario, tipo, status
                      FROM FCUser " & fFiltro
        Using uCom = New SqlCommand(uQue, FC_Con)
            Using mRs = uCom.ExecuteReader()
                Do While mRs.Read()
                    stip = IIf(mRs("tipo") = tAdmin, "ADMINISTRADOR", IIf(mRs("tipo") = tSupervisor, "SUPERVISOR", "USUARIO"))
                    dgusuarios.Rows.Add(mRs("idusuario"), mRs("nombre"),
                                            mRs("apellido_p") & " " & mRs("apellido_m"),
                                            mRs("usuario"), stip, IIf(mRs("status") = 1, "SI", "NO"))
                Loop
            End Using
        End Using
        dgusuarios.ClearSelection()
    End Sub

    Private Sub llenarCombo()
        Dim dt As DataTable
        Dim dr As DataRow

        dt = New DataTable("tipos")

        dt.Columns.Add("id")
        dt.Columns.Add("desc")

        dr = dt.NewRow()
        dr(0) = ""
        dr(1) = "Seleccione"
        dt.Rows.Add(dr)

        If cUsuario.Tipo = tAdmin Then
            dr = dt.NewRow()
            dr(0) = tAdmin
            dr(1) = "ADMINISTRADOR"
            dt.Rows.Add(dr)
        End If

        dr = dt.NewRow()
        dr(0) = tSupervisor
        dr(1) = "SUPERVISOR"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr(0) = tUsuario
        dr(1) = "USUARIO"
        dt.Rows.Add(dr)

        cbtipo.DataSource = dt
        cbtipo.DisplayMember = "desc"
        cbtipo.ValueMember = "id"
        cbtipo.SelectedIndex = 0
    End Sub

    Private Function validar() As Boolean
        validar = True
        If Me.txtnombre.Text = "" Then
            MsgBox("El Nombre esta vacío.", vbInformation, "Validación")
            validar = False
            txtnombre.Select()
        ElseIf Me.txtapellidop.Text = "" Then
            MsgBox("El Apellido Paterno esta vacío.", vbInformation, "Validación")
            validar = False
            txtapellidop.Select()
        ElseIf Me.txtapellidom.Text = "" Then
            MsgBox("El Apellido Materno esta vacío.", vbInformation, "Validación")
            validar = False
            txtapellidom.Select()
        ElseIf Me.txtuser.Text = "" Then
            MsgBox("El usuario esta vacío.", vbInformation, "Validación")
            validar = False
            txtuser.Select()
        ElseIf GetExisteUser(txtuser.Text) Then
            MsgBox("El Usuario ya existe.", vbInformation, "Validación")
            validar = False
            txtuser.Select()
        ElseIf Me.txtpass.Text = "" Then
            MsgBox("El password esta vacío.", vbInformation, "Validación")
            validar = False
            txtpass.Select()
        ElseIf Me.txtpass.Text <> Me.txtconfirmepass.Text Then
            MsgBox("La contraseña no coinciden.", vbInformation, "Validación")
            validar = False
            txtpass.Select()
        ElseIf Me.cbtipo.SelectedIndex = 0 Then
            MsgBox("No se ha seleccionado ningun tipo de usuario.", vbInformation, "Validación")
            validar = False
            cbtipo.Select()
        End If
    End Function

    Private Sub GuardaUsuario()
        Dim nUser As clUsuario
        Dim dModulos As clModulos
        nUser = New clUsuario

        nUser.Iduser = txtuser.Tag
        nUser.Nombreuser = txtnombre.Text
        nUser.Apellidop = txtapellidop.Text
        nUser.Apellidom = txtapellidom.Text
        nUser.Usuario = txtuser.Text
        nUser.Password = Eramake.eCryptography.Encrypt(txtpass.Text)
        nUser.Tipo = cbtipo.SelectedValue
        nUser.Status = IIf(Me.ckhabilitado.Checked, 1, 0)

        For i = 0 To dgmodulos.Rows.Count - 1
            dModulos = New clModulos
            dModulos.Idmodulo = dgmodulos.Item(0, i).Value
            dModulos.Permisouser = IIf(dgmodulos.Item(2, i).Value, 1, 0)
            nUser.Modper.Add(dModulos)
        Next i

        nUser.AddUser()

        nUser = Nothing

    End Sub

    Private Sub Limpiar()
        txtuser.Tag = 0
        txtnombre.Text = ""
        txtapellidop.Text = ""
        txtapellidom.Text = ""
        txtuser.Text = ""
        txtpass.Text = ""
        txtconfirmepass.Text = ""
        cbtipo.SelectedIndex = 0
        ckhabilitado.Checked = True
        ckhabilitado.Visible = False
        Me.btnEliminar.Enabled = False
    End Sub
    Private Function GetExisteUser(ByVal cNomUsuario As String) As Boolean
        Dim gQue As String, RsGet As SqlDataReader
        GetExisteUser = False

        gQue = "SELECT idusuario FROM FCUser WHERE usuario=@user"
        Using gCom = New SqlCommand(gQue, FC_Con)
            gCom.Parameters.AddWithValue("@user", cNomUsuario)
            RsGet = gCom.ExecuteReader()
            RsGet.Read()
            If RsGet.HasRows = True Then
                GetExisteUser = False
            End If
            RsGet.Close()
        End Using
    End Function

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If validar() = True Then
            GuardaUsuario()
            Limpiar()
            cargaModu()
            CargaUsuarios()
        End If
    End Sub

    Private Sub Txtuser_TextChanged(sender As Object, e As EventArgs) Handles txtuser.TextChanged
        Me.txtuser.Text = UCase(Me.txtuser.Text)
        Me.txtuser.SelectionStart = Me.txtuser.TextLength + 1
    End Sub

    Private Sub Txtnombre_TextChanged(sender As Object, e As EventArgs) Handles txtnombre.TextChanged
        Me.txtnombre.Text = UCase(Me.txtnombre.Text)
        Me.txtnombre.SelectionStart = Me.txtnombre.TextLength + 1
    End Sub

    Private Sub Txtapellidop_TextChanged(sender As Object, e As EventArgs) Handles txtapellidop.TextChanged
        Me.txtapellidop.Text = UCase(Me.txtapellidop.Text)
        Me.txtapellidop.SelectionStart = Me.txtapellidop.TextLength + 1
    End Sub

    Private Sub Txtapellidom_TextChanged(sender As Object, e As EventArgs) Handles txtapellidom.TextChanged
        Me.txtapellidom.Text = UCase(Me.txtapellidom.Text)
        Me.txtapellidom.SelectionStart = Me.txtapellidom.TextLength + 1
    End Sub

    Private Sub datosUsuario(ByVal iduse As Integer)
        Dim dQue As String, sQue As String

        dQue = "SELECT idusuario, nombre, apellido_p, apellido_m, 
                usuario, password, tipo, status FROM FCUser WHERE idusuario=@iduse"
        Using vCom = New SqlCommand(dQue, FC_Con)
            vCom.Parameters.AddWithValue("@iduse", iduse)
            Using vRs = vCom.ExecuteReader()
                vRs.Read()
                If vRs.HasRows = True Then
                    Me.btnEliminar.Enabled = True
                    txtuser.Tag = iduse
                    txtnombre.Text = vRs("nombre")
                    txtapellidop.Text = vRs("apellido_p")
                    txtapellidom.Text = vRs("apellido_m")
                    txtuser.Text = vRs("usuario")
                    txtpass.Text = Eramake.eCryptography.Decrypt(vRs("password"))
                    txtconfirmepass.Text = Eramake.eCryptography.Decrypt(vRs("password"))
                    cbtipo.SelectedValue = vRs("tipo")
                    If vRs("status") = 0 Then
                        Me.ckhabilitado.Visible = True
                        Me.ckhabilitado.Checked = False
                    End If
                End If
            End Using
        End Using
        sQue = "SELECT idmodulo,permiso FROM FCModUser WHERE idusuario=@iduse"
        Using cmod = New SqlCommand(sQue, FC_Con)
            cmod.Parameters.AddWithValue("@iduse", iduse)
            Using mRs = cmod.ExecuteReader()
                Do While mRs.Read
                    For i = 0 To dgmodulos.Rows.Count - 1
                        If dgmodulos.Item(0, i).Value = mRs("idmodulo") Then
                            dgmodulos.Item(2, i).Value = IIf(mRs("permiso") = 1, True, False)
                        End If
                    Next i
                Loop
            End Using
        End Using
    End Sub

    Private Sub Dgusuarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgusuarios.CellContentClick
        'Dim sfil As Integer
        'sfil = dgusuarios.CurrentCell.RowIndex
        'If dgusuarios.CurrentRow IsNot Nothing Then
        '    datosUsuario(dgusuarios.Item(0, sfil).Value)
        'End If
    End Sub


    Private Sub dgusuarios_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgusuarios.CellDoubleClick
        Dim sfil As Integer
        sfil = dgusuarios.CurrentCell.RowIndex
        If dgusuarios.CurrentRow IsNot Nothing Then
            datosUsuario(dgusuarios.Item(0, sfil).Value)
        End If
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Limpiar()
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgusuarios.CurrentRow IsNot Nothing Then
            EliminarUser(Me.txtuser.Tag)
            Limpiar()
            cargaModu()
            CargaUsuarios()
        Else
            MsgBox("Debe seleccionar un usuario a eliminar", vbInformation + vbExclamation, "Validación")
        End If
    End Sub

    Private Sub EliminarUser(ByVal iduse As Integer)
        Dim eQue As String
        If iduse <> 0 Then
            eQue = "UPDATE FCUser SET status=0 WHERE idusuario=@iduse"
            Using aCom = New SqlCommand(eQue, FC_Con)
                aCom.Parameters.AddWithValue("@iduse", iduse)
                aCom.ExecuteNonQuery()
            End Using
        Else
            MsgBox("El usuario es incorrecto.", vbInformation + vbExclamation, "Validación")
        End If
    End Sub
End Class