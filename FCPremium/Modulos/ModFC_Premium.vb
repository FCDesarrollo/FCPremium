Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Management
Imports Ionic.Zip

Module ModFC_Premium
    '    if not exists(
    'SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_NAME = 'prueba2' AND TABLE_NAME= 'FCParametros')
    'BEGIN
    '	ALTER TABLE FCParametros
    '  ADD prueba2 VARCHAR(50) END

    Public Sub CrearTablasPremium()
        Dim cpCom As SqlCommand
        Dim cQue As String
        FC_Con.Close()
        fError = FC_Conexion()
        If fError <> 0 Then Exit Sub
        cQue = "IF OBJECT_ID('dbo.Instancias') IS NULL " &
                    "Begin CREATE TABLE [dbo].[Instancias]([id] [int] NULL,[nombre] [nvarchar](20) NULL," &
                    "[server] [nvarchar](50) NULL,[uid] [nvarchar](30) NULL,[pwd] [nvarchar](60) NULL) ON [PRIMARY] END"
        cpCom = New SqlCommand(cQue, FC_Con)
        cpCom.ExecuteNonQuery()
        cpCom.Dispose()

        cQue = "IF OBJECT_ID('dbo.FCModulo') IS NULL " &
                    "Begin CREATE TABLE [dbo].[FCModulos](
                            [idmodulo] [int] NOT NULL,
                            [nombre_modulo] [nvarchar](250) NOT NULL,
                            [version] [numeric](18, 2) NOT NULL,
                            [fechaactualizacion] [date] NULL,
                            [permiso] [int] NOT NULL,
                            [nombre_archivo] [nvarchar](250) NULL,
                            [nombre_ficha] [nvarchar](250) NULL,
                            [ficha_ver] [nvarchar](250) NULL,
                            [cargado] [int] NULL,
                            [archivo_ver] [nvarchar](250) NULL,
                            [nombre_carpeta] [nvarchar](250) NULL
                            ) ON [PRIMARY] END"
        cpCom = New SqlCommand(cQue, FC_Con)
        cpCom.ExecuteNonQuery()
        cpCom.Dispose()

        cQue = "IF OBJECT_ID('dbo.FCParametros') IS NULL " &
                    "Begin CREATE TABLE [dbo].[FCParametros](
	                        [ultima_actualizacion] [date] NULL,
	                        [Actualizado] [numeric](18, 2) NULL,
	                        [nombrecliente] [nvarchar](250) NULL,
	                        [rfccliente] [nvarchar](250) NULL
                        ) ON [PRIMARY] END"
        cpCom = New SqlCommand(cQue, FC_Con)
        cpCom.ExecuteNonQuery()
        cpCom.Dispose()

        cQue = "IF OBJECT_ID('dbo.FCUser') IS NULL " &
                    "Begin CREATE TABLE [dbo].[FCUser](
	                        [idusuario] [int] IDENTITY(1,1) NOT NULL,
	                        [nombre] [nvarchar](250) NOT NULL,
	                        [apellido_p] [nvarchar](250) NOT NULL,
	                        [apellido_m] [nvarchar](250) NOT NULL,
	                        [usuario] [nvarchar](150) NOT NULL,
	                        [password] [nvarchar](50) NOT NULL,
	                        [tipo] [int] NOT NULL,
	                        [status] [int] NOT NULL
                        ) ON [PRIMARY] END"
        cpCom = New SqlCommand(cQue, FC_Con)
        cpCom.ExecuteNonQuery()
        cpCom.Dispose()

        cQue = "IF OBJECT_ID('dbo.FCModUser') IS NULL " &
                    "Begin CREATE TABLE [dbo].[FCModUser](
	                    [idusuario] [int] NOT NULL,
	                    [idmodulo] [int] NOT NULL,
	                    [permiso] [int] NOT NULL
                    ) ON [PRIMARY] END"
        cpCom = New SqlCommand(cQue, FC_Con)
        cpCom.ExecuteNonQuery()
        cpCom.Dispose()


    End Sub

    Public Function VerificaTablas() As Boolean
        Dim arrTabs() As String = {"Instancias", "FCModulos", "FCParametros", "FCUser", "FCModUser"}
        VerificaTablas = verificarTablasModulo(arrTabs)
    End Function

    Public Function GetNumMod() As Integer
        Dim RsGet As SqlDataReader

        GetNumMod = 0
        Using ComRsGet As New SqlCommand("SELECT COUNT(*) AS NUMERO FROM FCModulos", FC_Con)
            RsGet = ComRsGet.ExecuteReader()
            RsGet.Read()
            If RsGet.HasRows = True Then
                If RsGet("NUMERO") IsNot DBNull.Value Then GetNumMod = RsGet("NUMERO")
            End If
            RsGet.Close()
        End Using
    End Function

    Public Function GetNumPermisoClien() As Integer
        Dim RsGet As SqlDataReader

        GetNumPermisoClien = 0
        Using ComRsGet As New SqlCommand("SELECT COUNT(*) AS NUMERO FROM FCModulos WHERE version<>0 AND permiso=1", FC_Con)
            RsGet = ComRsGet.ExecuteReader()
            RsGet.Read()
            If RsGet.HasRows = True Then
                If RsGet("NUMERO") IsNot DBNull.Value Then GetNumPermisoClien = RsGet("NUMERO")
            End If
            RsGet.Close()
        End Using
    End Function

    Public Function ConsumeAPI(ByVal aAPi As String, ByVal aMetodo As String,
                               ByVal aDatos As String, Optional sMe As String = "POST", Optional sType As String = "URL") As String
        Dim s As HttpWebRequest
        Dim enc As UTF8Encoding
        Dim response As HttpWebResponse
        Dim reader As StreamReader
        Dim rawresponse As String
        Dim postdata As String
        Dim postdatabytes As Byte()

        Try
            If sMe = "POST" Then
                s = HttpWebRequest.Create(aAPi & aMetodo)
            Else
                s = HttpWebRequest.Create(aAPi & aMetodo & aDatos)
            End If
            enc = New System.Text.UTF8Encoding()
            If sMe = "POST" Then
                postdata = aDatos
                postdatabytes = enc.GetBytes(postdata)
                s.ContentLength = postdatabytes.Length
            End If
            s.Method = sMe
            If sType = "URL" Then
                s.ContentType = "application/x-www-form-urlencoded"
            Else
                s.ContentType = "application/json"
            End If

            If sMe = "POST" Then
                Using stream = s.GetRequestStream()
                    stream.Write(postdatabytes, 0, postdatabytes.Length)
                End Using
            End If
            'Dim result = s.GetResponse()
            response = DirectCast(s.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())

            rawresponse = reader.ReadToEnd()
            ConsumeAPI = rawresponse
        Catch ex As Exception
            MsgBox("Error al Consumir API", vbExclamation, "Validación")
            ConsumeAPI = ""
        End Try

    End Function

    Public Function descargaModulos(ByVal dApi As String, ByVal dCliente As String, ByVal dRFC As String) As Boolean
        Dim jsonMod As String, dMetodo As String, dFiltro As String
        Dim idMod As Integer, nomMod As String
        Dim desModulo As clModulos

        descargaModulos = False

        dFiltro = "rfc=" & dRFC & "&razon=" & dCliente
        dMetodo = "enviarModulos"
        jsonMod = ConsumeAPI(dApi, dMetodo, dFiltro)
        If jsonMod <> "" Then
            FC_Conexion()
            jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
            For Each Row In jsonObject("modulo")
                idMod = Row("idmodulo")
                nomMod = Row("nombre_modulo")
                desModulo = New clModulos
                desModulo.Idmodulo = idMod
                desModulo.Nombremodulo = nomMod
                desModulo.Version = 0
                desModulo.Permisomod = 0
                desModulo.SaveModulo()
            Next
            descargaModulos = True
        End If
    End Function

    Public Function DownloadVersion(ByVal idVersion As Integer,
                                     ByVal idModulo As Integer, dpermiso As Integer) As Boolean
        Dim jsonMod As String, dFiltro As String, dMetodo As String, dUrl As String
        Dim dDatosLink As String, dArchivo As String
        Dim cdMod As clModulos

        DownloadVersion = False

        dDatosLink = "&user=" & mUserNube & "&pass=" &
                        mPassNube & "&link=" & mLinkNube

        dFiltro = "idversion=" & idVersion
        dMetodo = "datosVersion"
        jsonMod = ConsumeAPI(cParam.Api, dMetodo, dFiltro)
        If jsonMod <> "" Then
            FC_Conexion()
            jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
            For Each Row In jsonObject("version")
                dArchivo = "archivo=FCPremium/" & CStr(Row("nombre_carpeta")) & "/" &
                        CStr(Row("nomdes"))
                dUrl = ConsumeAPI(cParam.Api, "linkArchivo", dArchivo & dDatosLink)
                If dUrl <> "" Then
                    My.Computer.Network.DownloadFile(dUrl & "/download",
                         FC_RutaModulos & "\archivos\" & CStr(Row("nomfin")), "", "", True, 900, True)

                    cdMod = New clModulos
                    cdMod.Version = CDbl(Row("nombre_version"))
                    cdMod.FechaActualiza = Strings.Format(FormatoFecha, Date.Now)
                    cdMod.Permisomod = dpermiso
                    cdMod.Nombrearchivo = CStr(Row("nomfin"))
                    cdMod.Nombreficha = CStr(Row("nombre_ficha"))
                    cdMod.Idmodulo = idModulo
                    cdMod.Archivover = CStr(Row("arch_version"))
                    cdMod.Nombrecarpeta = CStr(Row("nombre_carpeta"))
                    cdMod.ActualizaMod()

                    If CStr(Row("nombre_ficha")) <> "NO" And CStr(Row("nombre_ficha")) <> "" Then
                        ''PENDIENTE DESCARGAR FICHA TECNICA
                        dArchivo = "archivo=FCPremium/" & CStr(Row("nombre_carpeta")) & "/" &
                        CStr(Row("nombre_ficha"))
                        dUrl = ConsumeAPI(cParam.Api, "linkArchivo", dArchivo & dDatosLink)
                        My.Computer.Network.DownloadFile(dUrl & "/download",
                         FC_RutaModulos & "\SpreadSheets\" & CStr(Row("nombre_carpeta")) & "\" & CStr(Row("nombre_ficha")), "", "", True, 900, True)
                    End If

                    If CStr(Row("arch_version")) <> "NO" And CStr(Row("arch_version")) <> "" Then
                        ''PENDIENTE DESCARGAR FICHA TECNICA
                        dArchivo = "archivo=FCPremium/" & CStr(Row("nombre_carpeta")) & "/" &
                        CStr(Row("arch_version"))
                        dUrl = ConsumeAPI(cParam.Api, "linkArchivo", dArchivo & dDatosLink)
                        My.Computer.Network.DownloadFile(dUrl & "/download",
                         FC_RutaModulos & "\SpreadSheets\" & CStr(Row("nombre_carpeta")) & "\" & CStr(Row("arch_version")), "", "", True, 900, True)
                    End If

                    ''PROCEDIMIENTO PARA ACTUALIZAR LA BASE DE DATOS GENERAL LAS TABLAS DEL MODULO
                    If CStr(Row("script_gen")) <> "NO" And CStr(Row("script_gen")) <> "" Then
                        dArchivo = "archivo=FCPremium/" & CStr(Row("nombre_carpeta")) & "/" &
                        CStr(Row("script_gen"))
                        dUrl = ConsumeAPI(cParam.Api, "linkArchivo", dArchivo & dDatosLink)

                        If dUrl <> "" Then
                            If ActualizaBDDGeneral(dUrl, FC_RutaModulos, CStr(Row("script_gen"))) Then

                            End If
                        End If
                    End If
                    If CStr(Row("spreedsheets")) <> "NO" And CStr(Row("spreedsheets")) <> "" Then
                        dArchivo = "archivo=FCPremium/" & CStr(Row("nombre_carpeta")) & "/" &
                        CStr(Row("nombre_carpeta"))
                        dUrl = ConsumeAPI(cParam.Api, "linkArchivo", dArchivo & dDatosLink)
                        My.Computer.Network.DownloadFile(dUrl & "/download",
                         FC_RutaModulos & "\SpreadSheets\" & CStr(Row("nombre_carpeta")) & ".zip", "", "", True, 900, True)
                        Dim ZipToUnpack As String = FC_RutaModulos & "\SpreadSheets\" & CStr(Row("nombre_carpeta")) & ".zip"
                        Dim UnpackDirectory As String = FC_RutaModulos & "\SpreadSheets"
                        Using zip1 As ZipFile = ZipFile.Read(ZipToUnpack)
                            Dim e As ZipEntry
                            For Each e In zip1
                                e.Extract(UnpackDirectory, ExtractExistingFileAction.OverwriteSilently)
                            Next
                        End Using
                    End If
                End If
            Next
        End If
    End Function

    Private Function ActualizaBDDGeneral(ByVal aUrl As String, ByRef aRutaDes As String, aNomAr As String) As Boolean
        My.Computer.Network.DownloadFile(aUrl & "/download",
         aRutaDes & "\SQL\" & CStr(aNomAr), "", "", True, 900, True)

        ActualizaBDDGeneral = False


        Dim Dato As String = ""
        Dim Sep() As String
        FileOpen(1, aRutaDes & "\SQL\" & CStr(aNomAr), OpenMode.Binary, OpenAccess.Default)
        Dato = Space(FileLen(aRutaDes & "\SQL\" & CStr(aNomAr)))
        FileGet(1, Dato)
        FileClose(1)
        Sep = Split(Dato, "|")

        For i As Integer = 0 To Sep.Count - 1
            Using aCmd = New SqlCommand(Sep(i), FC_Con)
                aCmd.ExecuteNonQuery()
                aCmd.Dispose()
                ActualizaBDDGeneral = True
            End Using
        Next

    End Function

    Public Function ValidaAPi() As Boolean
        ValidaAPi = True
        If cParam.Api = "" Then
            MsgBox("No se ha especificado la API." & vbCrLf & "Ir a parametros para configurar.", vbInformation, "Validación")
            ValidaAPi = False
        ElseIf cParam.RDescarga = "" Then
            MsgBox("La ruta para descarga no Existe." & vbCrLf & "Ir a parametros para configurar.", vbInformation, "Validación")
            ValidaAPi = False
        End If
    End Function

    Public Function GetSerialMother() As String
        GetSerialMother = ""
        Dim serial As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_BaseBoard")

        For Each serialB As ManagementObject In serial.Get()
            GetSerialMother = (serialB.GetPropertyValue("SerialNumber").ToString)
        Next
    End Function

    Public Function GetSerialDisco() As String
        Dim serialDD As New ManagementObject("Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'")
            GetSerialDisco = Trim(serialDD.Properties("SerialNumber").Value.ToString)
    End Function


End Module
