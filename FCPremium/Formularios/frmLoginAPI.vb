Public Class frmLoginAPI
    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub BtnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        If TBPass.Text <> "" And TBUser.Text <> "" Then
            If loguear_API() = True Then
                Me.Close()
            End If
        End If
    End Sub

    Private Function loguear_API() As Boolean
        Dim dFiltro As String, dMetodo As String
        Dim jsonMod As String

        loguear_API = False

        dFiltro = "correo=" & TBUser.Text & "&contra=" & TBPass.Text
        dMetodo = "datosadmin"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro)
        If jsonMod <> "" Then
            If jsonMod <> "2" And jsonMod <> "3" Then
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                For Each Row In jsonObject("usuario")
                    If GL_cUsuarioAPI Is Nothing Then
                        GL_cUsuarioAPI = New clUserAPI
                    End If
                    With GL_cUsuarioAPI
                        .Correo = TBUser.Text
                        .Contra = TBPass.Text
                        .Iduser = Row("idusuario")
                        .Nombreuser = Row("nombre")
                        .Apellidop = Row("apellidop")
                        .Apellidom = Row("apellidom")
                        .Status = Row("status")
                        .Tipo = Row("tipo")
                        loguear_API = True
                    End With
                Next
            Else
                GetError_Api(CInt(jsonMod))
            End If
        End If
    End Function

    Private Sub FrmLoginAPI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TBPass.Text = "miconsultor@2020"
        TBUser.Text = "miconsultormx@gmail.com"
    End Sub
End Class