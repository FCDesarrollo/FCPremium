Imports System.Data.SqlClient
Public Class frmLogin
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim arrDatos() As String
        Dim vectoraux() As String
        Dim jsonMod As String, dFiltro As String
        'Me.TBUser.Text = "FCPREMIUM"
        'Me.TBPass.Text = "FC2019"

        menUser = False
        mUserNube = "admindublock"
        mPassNube = "4u1B6nyy3W"
        mLinkNube = "https://" & mUserNube & ":" & mPassNube & "@cloud.dublock.com/ocs/v2.php/apps/files_sharing/api/v1/shares"

        'My.Settings.Reset()
        arrDatos = FC_GetDatos()
        'My.Settings.FechaCaduca = Date.Now

        If Trim(Join(arrDatos)) = "" Then

inicionew:
            'MsgBox("Ingrese el Usuario y Contraseña para empezar la Instalación", vbInformation, "Validación")
            sSystema = 0
            TBUser.Text = FCPremium.UserAdmin
            TBPass.Text = FCPremium.PassAdmin
        ElseIf VerificaTablas() = False Then
            sSystema = 0
            TBUser.Text = FCPremium.UserAdmin
            TBPass.Text = FCPremium.PassAdmin
        Else
            sSystema = 1
            fError = FC_Conexion()
            cParam = New clParametros
            If cParam.loadParam() = False Then
                MsgBox("Falta confifurar los parametros." & vbCrLf & "Ingresar como Administrador.", vbInformation, "Validación")
                GoTo inicionew
            End If
Entrar:
            If My.Computer.Network.IsAvailable Then
                dFiltro = "rfc=" & cParam.Rfclien & "&equipo=" & cParam.Equipo
                jsonMod = ConsumeAPI(cParam.Api, "activa", dFiltro)
                If jsonMod <> "" Then
                    vectoraux = jsonMod.Split(",")
                    If vectoraux(0) = "Licencia Valida" Then
                        My.Settings.Serial = vectoraux(1)
                        My.Settings.FechaCaduca = Strings.Format(FormatoFecha, vectoraux(2))
                        My.Settings.ProductoRegistrado = True
                        My.Settings.FechaConexion = Strings.Format(FormatoFecha, Date.Now)
                        My.Settings.Save()
                        If Date.Now.Date > My.Settings.FechaCaduca.Date And My.Settings.FechaCaduca <> DateTime.MinValue Then
                            MsgBox("La clave de Producto ha expirado.", MsgBoxStyle.Exclamation, "Validación")
                            frmActivador.ShowDialog()
                            If Date.Now.Date > My.Settings.FechaCaduca.Date Then
                                Me.Close()
                            Else
                                GoTo Entrar
                            End If
                        End If
                    Else
                        MsgBox("El Producto no esta activado.", MsgBoxStyle.Exclamation, "Validación")
                        frmActivador.ShowDialog()
                        If My.Settings.Serial <> "" Then
                            GoTo Entrar
                        Else
                            Me.Close()
                        End If
                    End If
                Else
                    MsgBox("El Producto no esta activado.", MsgBoxStyle.Exclamation, "Validación")
                    frmActivador.ShowDialog()
                    If My.Settings.Serial <> "" Then
                        GoTo Entrar
                    Else
                        Me.Close()
                    End If
                End If
            Else
                If My.Settings.FechaConexion <> DateTime.MinValue Then
                    Dim ddias As Integer = DateDiff(DateInterval.Day, My.Settings.FechaConexion.Date, Date.Now.Date)
                    If ddias > 20 Then
                        MsgBox("La clave de Producto no se ha podido actualizar." & vbCrLf & "Conectar a internet para actualizar.", MsgBoxStyle.Exclamation, "Validación")
                        Me.Close()
                    End If
                ElseIf My.Settings.FechaConexion = DateTime.MinValue Then
                    My.Settings.ProductoRegistrado = True
                    My.Settings.FechaConexion = Strings.Format(FormatoFecha, Date.Now)
                    My.Settings.Save()
                End If
            End If
        End If
    End Sub

    Private Function verificaClave()
        verificaClave = False
        Dim dFiltro As String
        Dim jsonMod As String
        dFiltro = "rfc=" & cParam.Rfclien & "&equipo=" & cParam.Equipo & "&clave=" & My.Settings.Serial
        If My.Computer.Network.IsAvailable Then
            jsonMod = ConsumeAPI(cParam.Api, "validarClave", dFiltro)
            verificaClave = IIf(CInt(jsonMod) = 1, True, False)
        End If
    End Function

    Private Sub BtnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        If Me.TBUser.Text <> "" And Me.TBPass.Text <> "" Then
            If VerificaUsuario() = True Then
                If EstaAbierto(frmPrincipal) = True Then
                    frmPrincipal.Close()
                End If
                frmPrincipal.Show()
                Me.Close()
            Else
                MsgBox("El Usuario o Contraseña es Incorrecto.", MsgBoxStyle.Exclamation, "Validación")
            End If
        End If
    End Sub



    Private Function VerificaUsuario() As Boolean

        VerificaUsuario = False
        If FCPremium.sSystema = 0 Then
            If Me.TBUser.Text = FCPremium.UserAdmin And Me.TBPass.Text = FCPremium.PassAdmin Then
                VerificaUsuario = True
            End If
        ElseIf FCPremium.sSystema = 1 Then
            fError = FC_Conexion()
            cUsuario = New clUsuario
            VerificaUsuario = cUsuario.login(Me.TBUser.Text, Eramake.eCryptography.Encrypt(Me.TBPass.Text))
        End If
    End Function

    Private Sub TBUser_TextChanged(sender As Object, e As EventArgs) Handles TBUser.TextChanged
        Me.TBUser.Text = UCase(Me.TBUser.Text)
        Me.TBUser.SelectionStart = Me.TBUser.TextLength + 1
    End Sub
End Class