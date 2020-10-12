Imports System.ComponentModel
Imports System.IO
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class frmPrincipal
    Private modu As clModulos

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(228, 227, 228)
        BloqueaMenu()
        CargaMenu()
        If cUsuario IsNot Nothing Then
            Me.Text = "Inicio -  Usuario: " & cUsuario.Nombreuser & " " & cUsuario.Apellidop
        End If
    End Sub

    Private Sub CargaMenu()
        Dim numMod As Integer

RegresaMenu:
        If FCPremium.sSystema = 0 Then
            MConfig.Enabled = True
        ElseIf FCPremium.sSystema = 1 Then
            numMod = GetNumMod()
            If numMod = 0 Then
                MsgBox("No se han agregado los Modulos.", vbInformation, "Validación")
                sSystema = 0
                GoTo RegresaMenu
            Else
                MostrarMenu()
            End If
        End If
    End Sub

    Private Sub MConfig_Click(sender As Object, e As EventArgs) Handles MConfig.Click
        Dim tempUser As String, tempPass As String
        Dim frm As New frmConfig
        frm.ShowDialog()
        frm.Dispose()
        If sSystema = 1 Then
            tempUser = cUsuario.Usuario
            tempPass = cUsuario.Password
            cUsuario = New clUsuario
            cUsuario.login(tempUser, tempPass)
            BloqueaMenu()
            MostrarMenu()
        End If
        If menUser = True Then
            MuserADD.Enabled = True
        End If
    End Sub

    Private Sub BloqueaMenu()
        For Each oToolStripButton In PMenu.Items
            'oToolStripButton.enabled = False
        Next
        MUser.Enabled = True
        MuserADD.Enabled = False
    End Sub

    Private Sub MostrarMenu()
        Dim numPer As Integer

        numPer = GetNumPermisoClien()
        If cUsuario.Tipo = tAdmin Then MConfig.Enabled = True
        If (cUsuario.Tipo = tAdmin Or cUsuario.Tipo = tSupervisor) _
                And numPer > 0 Then MuserADD.Enabled = True
        For Each modu In cUsuario.Modper
            For Each oToolStripButton In PMenu.Items
                If oToolStripButton.tag = modu.Idmodulo Then
                    oToolStripButton.enabled = IIf(modu.Permisouser = 1, True, False)
                    Exit For
                End If
            Next
        Next modu
    End Sub

    Private Sub MXml_Click(sender As Object, e As EventArgs) Handles MXml.Click
        Dim mIDModulo As Integer
        mIDModulo = MXml.Tag
        OpenModulo(mIDModulo)
    End Sub

    Private Sub frmPrincipal_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If cUsuario IsNot Nothing Then
            For Each modu In cUsuario.Modper
                modu.XlBook = Nothing
                If (Not (modu.XlApp Is Nothing)) Then
                    modu.XlApp.Quit()
                End If
                modu.XlApp = Nothing
            Next modu
        End If
    End Sub

    Private Sub OpenModulo(ByVal gIDModulo)
        Dim sExiste As Boolean
        sExiste = False

        For Each modu In cUsuario.Modper
            If gIDModulo = modu.Idmodulo Then
                If File.Exists(cParam.RDescarga & "\archivos\" & modu.Nombrearchivo) Then
                    modu.XlBook = Nothing
                    If (Not (modu.XlApp Is Nothing)) Then
                        modu.XlApp.Quit()
                    End If
                    modu.XlApp = Nothing
                    modu.XlApp = New Microsoft.Office.Interop.Excel.Application()
                    modu.XlBook = modu.XlApp.Workbooks.Open(cParam.RDescarga & "\archivos\" & modu.Nombrearchivo)
                    modu.XlApp.Visible = True
                    modu.XlApp.ActiveWindow.WindowState = XlWindowState.xlMaximized

                    sExiste = True
                End If
                Exit For
            End If
        Next modu
        If sExiste = False Then MsgBox("No se encontro el Modulo.", vbInformation, "Validación")
    End Sub

    Private Sub MEstados_Click(sender As Object, e As EventArgs) Handles MEstados.Click
        Dim mIDModulo As Integer
        mIDModulo = MEstados.Tag
        OpenModulo(mIDModulo)
    End Sub

    Private Sub MPolizas_Click(sender As Object, e As EventArgs) Handles MPolizas.Click
        Dim mIDModulo As Integer
        mIDModulo = MPolizas.Tag
        OpenModulo(mIDModulo)
    End Sub

    Private Sub MBancos_Click(sender As Object, e As EventArgs) Handles MBancos.Click
        Dim mIDModulo As Integer
        mIDModulo = MBancos.Tag
        OpenModulo(mIDModulo)
    End Sub

    Private Sub MCaja_Click(sender As Object, e As EventArgs) Handles MCaja.Click
        Dim mIDModulo As Integer
        mIDModulo = MCaja.Tag
        OpenModulo(mIDModulo)
    End Sub

    Private Sub MNomina_Click(sender As Object, e As EventArgs) Handles MNomina.Click
        Dim mIDModulo As Integer
        mIDModulo = MNomina.Tag
        OpenModulo(mIDModulo)
    End Sub

    Private Sub MConcilia_Click(sender As Object, e As EventArgs) Handles MConcilia.Click
        Dim mIDModulo As Integer
        mIDModulo = MConcilia.Tag
        OpenModulo(mIDModulo)
    End Sub

    Private Sub MuserLog_Click(sender As Object, e As EventArgs) Handles MuserLog.Click
        Me.Close()
    End Sub

    Private Sub MuserChan_Click(sender As Object, e As EventArgs) Handles MuserChan.Click
        frmLogin.Show()
        Me.Refresh()
    End Sub

    Private Sub MuserADD_Click(sender As Object, e As EventArgs) Handles MuserADD.Click
        frmUsuario.Show()
    End Sub

    Private Sub MActivos_Click(sender As Object, e As EventArgs) Handles MActivos.Click

    End Sub

    Private Sub MDigital_Click(sender As Object, e As EventArgs) Handles MDigital.Click
        Dim hijo As New frmdigital
        hijo.MdiParent = Me
        If Inicio_UserAPI() = False Then
            frmLoginAPI.ShowDialog()
            If Inicio_UserAPI() = True Then
                If CheckForm(hijo) Is Nothing Then
                    hijo.Show()
                End If
            Else
                MsgBox("No se inicio sesión en el CRM.", vbInformation, "Validación")
            End If
        Else
            If CheckForm(hijo) Is Nothing Then
                hijo.Show()
            End If
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim hijo As New frmClipExp
        hijo.MdiParent = Me
        If Inicio_UserAPI() = False Then
            frmLoginAPI.ShowDialog()
            If Inicio_UserAPI() = True Then
                If CheckForm(hijo) Is Nothing Then
                    hijo.Show()
                End If
            Else
                MsgBox("No se inicio sesión en el CRM.", vbInformation, "Validación")
            End If
        Else
            If CheckForm(hijo) Is Nothing Then
                hijo.Show()
            End If
        End If
    End Sub
End Class