Imports System.Data.SqlClient

Public Class frmActivador
    Private Sub BtnActivar_Click(sender As Object, e As EventArgs) Handles btnActivar.Click
        Dim cClave As String, dFiltro As String
        If cParam Is Nothing Then
            cParam = New clParametros
            cParam.loadParam()
        End If
        If txtproducto.Text <> "" And cParam.Rfclien <> "" And cParam.Rfclien <> "" And cParam.Equipo <> "" Then
            cClave = txtproducto.Text
            dFiltro = "rfc=" & cParam.Rfclien & "&razon=" & cParam.Nomclien & "&equipo=" & cParam.Equipo & "&clave=" & cClave
            If My.Computer.Network.IsAvailable Then
                If My.Settings.ProductoRegistrado = False And My.Settings.Serial = "" Then
                    VerificaNumeroSerie(dFiltro)
                ElseIf My.Settings.ProductoRegistrado = True Then

                End If
            Else
                MsgBox("No es posible Activar sin Conexión a Internet.", vbInformation + vbExclamation, "Validación")
            End If
        Else
            MsgBox("La clave es Incorrecta.", vbInformation + vbExclamation, "Validación")
        End If
    End Sub

    Private Sub VerificaNumeroSerie(ByVal vFiltro As String)
        Dim vectoraux() As String
        Dim jsonMod As String
        jsonMod = ConsumeAPI(cParam.Api, "verificarLicencia", vFiltro)
        If jsonMod <> "" Then
            vectoraux = jsonMod.Split(",")
            If vectoraux(0) = "Licencia Valida" Then
                My.Settings.Serial = vectoraux(1)
                My.Settings.FechaCaduca = Strings.Format(FormatoFecha, vectoraux(2))
                My.Settings.ProductoRegistrado = True
                My.Settings.FechaConexion = Strings.Format(FormatoFecha, Date.Now)
                My.Settings.Save()
                MsgBox("Producto Activado.", vbInformation, "Validación")
                Me.Close()
            Else
                MsgBox(vectoraux(0), vbInformation + vbExclamation, "Validación")
            End If
        End If
    End Sub

    Private Sub FrmActivador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.ProductoRegistrado = False And My.Settings.Serial = "" Then
            Me.lbcla.Text = "Clave del Producto:"
        Else
            Me.lbcla.Text = "Clave de Activación:"
        End If

    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        End
    End Sub
End Class