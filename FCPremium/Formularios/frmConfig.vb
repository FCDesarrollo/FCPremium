Imports System.ComponentModel
Imports System.Data.SqlClient
Public Class frmConfig
    Private Con As New SqlConnection
    Private sBanLoad As Integer
    Private Sub BtInstala_Click(sender As Object, e As EventArgs) Handles BtInstala.Click
        Dim lError As Long, cQue As String

        'validaciones
        If Trim(TBSql.Text) = "" Or Trim(TBSA.Text) = "" Or Trim(Me.TBUID.Text) = "" Or Trim(TBBDDGen.Text) = "" Then
            MsgBox("Debe configurar todos los elementos solicitados", vbExclamation, "Validación")
            Exit Sub
        End If

        On Error Resume Next
        Con = New SqlConnection()
        Con.ConnectionString = "Data Source=" + Trim(TBSql.Text) + " ;" &
                    "User Id=" + Trim(TBUID.Text) + ";Password=" + Trim(TBSA.Text)

        Con.Open()

        If Con.State = ConnectionState.Closed Then
            MsgBox("Imposible realizar la conexión SQL: " & vbCrLf & Err.Description, vbCritical, "Conexión SQL")
            Exit Sub
        Else
            Con.Close()
        End If

        FC_SetDatos(Trim(TBSql.Text), Trim(TBUID.Text), Trim(TBSA.Text))
        If TBBDDGen.Text <> "" Then FC_DATABASE = Trim(TBBDDGen.Text)

        If txtSDK.Text <> "" Then FC_RutaSDKAdmin = txtSDK.Text
        If txtEmpresas.Text <> "" Then FC_RutaEmpresasAdmin = txtEmpresas.Text
        FC_RutaModulos = Application.StartupPath

        FC_CrearBDD()
        'If TBBDDGen.Text <> "" Then FC_DATABASE = Trim(TBBDDGen.Text)
        CrearTablasPremium()
        On Error GoTo 0
        If sSystema = 0 Then
            cQue = "IF NOT EXISTS (SELECT idusuario FROM FCUser WHERE nombre=@nom)
                        BEGIN INSERT INTO FCUser(nombre,apellido_p,apellido_m,usuario,password,tipo,status)
                                VALUES(@nom, @nom, @nom, @use, @pass, @tip , @status) END"
            Using cCom = New SqlCommand(cQue, FC_Con)
                cCom.Parameters.AddWithValue("@nom", "ADMINISTRADOR")
                cCom.Parameters.AddWithValue("@use", FCPremium.UserAdmin)
                cCom.Parameters.AddWithValue("@pass", Eramake.eCryptography.Encrypt(FCPremium.PassAdmin))
                cCom.Parameters.AddWithValue("@tip", 0)
                cCom.Parameters.AddWithValue("@status", 1)
                cCom.ExecuteNonQuery()
            End Using
            cUsuario = New clUsuario
            cUsuario.login(FCPremium.UserAdmin, FCPremium.PassAdmin)
        End If

        linfo.Text = conInfo
        MsgBox("Datos generales configurados.", vbInformation, "Instalación Terminada")
        mpConfig.SelectedIndex = 1
    End Sub

    Private Sub mpConfig_SelectedIndexChanged(sender As Object, e As EventArgs) Handles mpConfig.SelectedIndexChanged
        If mpConfig.SelectedIndex = 1 And (sBanLoad = 0 Or sBanLoad = 2 Or sBanLoad = 1) Then
            If VerificaTablas() = False Then
                MsgBox("Faltan Tablas por crear volver a darle Instalar para crearlas.", vbInformation, "Validación")
                linfo.Text = "Faltan Tablas por crear volver a darle Instalar para crearlas."
                mpConfig.SelectedIndex = 0
            Else
                cParam = New clParametros
                cParam.loadParam()
                Me.txtRazon.Text = cParam.Nomclien
                Me.txtRfc.Text = cParam.Rfclien

                sBanLoad = 1
            End If
        ElseIf mpConfig.SelectedIndex = 2 And (sBanLoad = 1 Or sBanLoad = 2) Then
            If cParam.ValidaParametros = False Then
                linfo2.Visible = True
                mpConfig.SelectedIndex = 1
            Else
                muestraModulos()
                sBanLoad = 2
            End If
        Else
            mpConfig.SelectedIndex = 0
        End If
    End Sub

    Private Sub FrmConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim arrDatos() As String
        sBanLoad = 0
        If My.Settings.ProductoRegistrado = False And My.Settings.Serial = "" Then
            btnActiva.Visible = True
        Else
            btnActiva.Visible = False
        End If

        arrDatos = FC_GetDatos()
        Me.TBSql.Text = arrDatos(0)
        Me.TBUID.Text = arrDatos(1)
        Me.TBSA.Text = arrDatos(2)

        TBBDDGen.Text = FC_DATABASE

        txtSDK.Text = FC_RutaSDKAdmin
        txtEmpresas.Text = FC_RutaEmpresasAdmin

        If Trim(Join(arrDatos)) <> "" Then
            If VerificaTablas() = True Then
                dgModulos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                mpConfig.SelectedIndex = 1
            End If
        End If
    End Sub


    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If txtRazon.Text = "" Or txtRfc.Text = "" Then
            linfo2.Visible = True
        Else
            fError = FC_Conexion()
            If fError <> 0 Then Exit Sub
            cParam = New clParametros
            cParam.Api = mApi
            cParam.Userapi = FCPremium.UserAdmin
            cParam.Passapi = FCPremium.PassAdmin
            cParam.RDescarga = FC_RutaModulos
            cParam.Ufecha = Strings.Format(FormatoFecha, Date.Now)
            cParam.Nomclien = txtRazon.Text
            cParam.Rfclien = txtRfc.Text
            cParam.Equipo = GetSerialMother() & GetSerialDisco()

            If cParam.SaveParam = True Then
                linfo2.Visible = False
                mpConfig.SelectedIndex = 2
            End If
        End If
    End Sub

    Private Function CargaModulos(ByVal cActualiza As Integer) As Boolean
        fError = FC_Conexion()
        Dim numMod As Integer
        CargaModulos = False
        If fError <> 0 Then Exit Function


        numMod = GetNumMod()

        If sSystema = 0 Or cActualiza = 1 Or numMod = 0 Then
            If My.Computer.Network.IsAvailable Then
                If descargaModulos(cParam.Api, Me.txtRazon.Text, Me.txtRfc.Text) = True Then
                    CargaModulos = True
                End If
                If cParam.Uversion = 0 And cParam.Rfclien <> "" Then
                    cParam.atualizaVersion()
                End If
            Else
                MsgBox("Sin Conexión cargar Modulos Manualmente.", vbInformation, "Validación")
            End If
        End If
    End Function

    Private Sub muestraModulos()
        Dim mQue As String, jsonMod As String, dMetodo As String, dFiltro As String
        Dim combobox As DataGridViewComboBoxCell, jsonObject As Newtonsoft.Json.Linq.JObject
        Dim sVersion As String, idVersion As Integer

        Dim dt As DataTable
        Dim dr As DataRow

        dgModulos.Rows.Clear()

        mQue = "SELECT idmodulo,nombre_modulo,version,fechaactualizacion,permiso FROM FCModulos"
        Using mcom = New SqlCommand(mQue, FC_Con)
            Using mRs = mcom.ExecuteReader()
                Do While mRs.Read()
                    dgModulos.Rows.Add(mRs("idmodulo"), mRs("nombre_modulo"),
                                       mRs("version"), mRs("permiso"),
                                       mRs("fechaactualizacion"), "", False, "Ficha", "Ficha")
                    combobox = dgModulos.Rows(dgModulos.Rows.Count - 1).Cells(5)


                    If My.Computer.Network.IsAvailable Then
                        dFiltro = "idmodulo=" & mRs("idmodulo")
                        dMetodo = "versionesModulos"
                        jsonMod = ConsumeAPI(cParam.Api, dMetodo, dFiltro)
                        If jsonMod <> "" Then
                            dt = New DataTable("VERSIONES")
                            dt.Columns.Add("idver")
                            dt.Columns.Add("nomver")
                            dr = dt.NewRow()
                            dr(0) = 0
                            dr(1) = "Seleccione"
                            dt.Rows.Add(dr)
                            jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                            For Each Row In jsonObject("version")
                                sVersion = Row("nombre_version")
                                idVersion = Row("idversion")
                                dr = dt.NewRow()
                                dr(0) = idVersion
                                dr(1) = sVersion
                                dt.Rows.Add(dr)
                            Next
                            combobox.DataSource = dt
                            combobox.DisplayMember = "nomver"
                            combobox.ValueMember = "idver"
                        End If

                    End If
                Loop
            End Using
        End Using

    End Sub


    Private Sub BtnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        If CargaModulos(1) = True Then
            muestraModulos()
        End If
    End Sub

    Private Sub DownloadActualizacion()
        Dim dPermiso As Integer
        For i = 0 To dgModulos.Rows.Count - 1
            If dgModulos.Item(5, i).FormattedValue.ToString <> "" And dgModulos.Item(6, i).Value = True Then
                If dgModulos.Item(2, i).Value <> dgModulos.Item(5, i).FormattedValue.ToString Then
                    dPermiso = IIf(dgModulos.Item(3, i).Value, 1, 0)
                    DownloadVersion(dgModulos.Item(5, i).Value, dgModulos.Item(0, i).Value, dPermiso)
                End If
            End If
        Next i
        MsgBox("Actualizacion Termina.")
    End Sub

    Private Sub BtnDescarga_Click(sender As Object, e As EventArgs) Handles btnDescarga.Click
        If My.Computer.Network.IsAvailable Then
            If ValidaAPi() = True Then
                DownloadActualizacion()
                muestraModulos()
            End If
        Else
            MsgBox("No existe un conexión a internet.", vbInformation, "Validación")
        End If
    End Sub

    Private Sub frmConfig_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Dim arrDatos() As String
        menUser = False
        arrDatos = FC_GetDatos()
        If Trim(Join(arrDatos)) <> "" Then
            If VerificaTablas() = True Then
                If (GetNumPermisoClien() > 0) Then
                    menUser = True
                End If
            End If
        End If
    End Sub

    Private Sub BtnActiva_Click(sender As Object, e As EventArgs) Handles btnActiva.Click
        frmActivador.ShowDialog()
        If My.Settings.ProductoRegistrado = True And My.Settings.Serial <> "" Then
            btnActiva.Visible = False
        End If
    End Sub

    Private Sub DgModulos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgModulos.CellContentClick
        If e.ColumnIndex = 7 Then
            AbrirPDF(CInt(dgModulos.Rows(e.RowIndex).Cells(0).Value.ToString()), "archivo_ver")
        ElseIf e.ColumnIndex = 8 Then
            AbrirPDF(CInt(dgModulos.Rows(e.RowIndex).Cells(0).Value.ToString()), "nombre_ficha")
        End If
    End Sub

    Private Sub AbrirPDF(ByVal cIDModulo As Integer, ByVal cCampo As String)
        Dim ruta As String, vQue As String

        ruta = ""
        vQue = "SELECT " & cCampo & " as ruta,nombre_carpeta From FCModulos WHERE idmodulo=@idmod"
        Using vCom = New SqlCommand(vQue, FC_Con)
            vCom.Parameters.AddWithValue("@idmod", cIDModulo)
            Using vRs = vCom.ExecuteReader()
                vRs.Read()
                If vRs.HasRows = True Then
                    ruta = FC_RutaModulos & "\SpreadSheets\" & vRs("nombre_carpeta") & "\" & vRs("ruta")
                End If
            End Using
        End Using

        If ruta <> "NO" Then
            If Dir(ruta, FileAttribute.Archive) <> "" Then
                System.Diagnostics.Process.Start(ruta)
            Else
                MsgBox("El Archivo no se encontro", vbExclamation + vbInformation, "Validación")
            End If
        Else
            MsgBox("El Modulo no tiene ficha.", vbExclamation + vbInformation, "Validación")
        End If
    End Sub

    Private Sub tabModulos_Click(sender As Object, e As EventArgs) Handles tabModulos.Click

    End Sub
End Class