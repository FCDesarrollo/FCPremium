Imports Microsoft.Win32
Imports System.Data.SqlClient
Imports System.Data.Odbc
Module GeneralFC
    ''VARIABLES PARA REGISTRO EN REGEEDIT
    Public Const FC_REGKEY As String = "HKEY_LOCAL_MACHINE\SOFTWARE\FCModulos\"
    Public Const FC_REGKEYWRITE As String = "HKLM\SOFTWARE\FCModulos"
    Public Const FormatoFecha As String = "YYYY-mm-DD"

    ''VARIABLES DE CONEXION
    Public DConexiones As Dictionary(Of String, SqlConnection)
    Public FC_Con As New SqlConnection
    Public FC_SQL As New SqlConnection
    Public FC_CONFOX As New OdbcConnection
    ''VARIABLES PARA CONSULTAS
    Public Rs As SqlDataReader
    Public ComRs As SqlCommand
    Public fError As Long

    Private _FC_DATABASE As String

    Public Function FC_GetDatos() As String()
        On Error Resume Next
        Dim sArr(0 To 2) As String
        sArr(0) = My.Computer.Registry.GetValue(FC_REGKEY, "Instancia", Nothing)
        sArr(1) = My.Computer.Registry.GetValue(FC_REGKEY, "Uid", Nothing)
        sArr(2) = My.Computer.Registry.GetValue(FC_REGKEY, "Password", Nothing)
        FC_GetDatos = sArr
    End Function

    Public Property FC_DATABASE() As String
        Get
            On Error Resume Next
            FC_DATABASE = My.Computer.Registry.GetValue(FC_REGKEY, "BDDGen", "")

        End Get
        Set(ByVal val As String)
            On Error Resume Next
            WriteToRegistry("BDDGen", val)
        End Set
    End Property

    Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer
    Const SW_SHOWNORMAL = 1
    Public Sub WriteToRegistry(ByVal Key As String, ByVal Value As String)
        Dim command As String
        command = "/k %windir%\System32\reg.exe ADD \\" & Environ$("computername") & "\" & FC_REGKEYWRITE & " /v " & Key & " /t REG_SZ /d """ & Value & """ /f"
        ShellExecute(0, "runas", "C:\Windows\System32\cmd.exe", command, "C:\", 0)
    End Sub

    Public Function FC_Conexion(Optional ByVal sopcio As String = "") As Long
        Dim conData() As String
        On Error GoTo ERR_CON

        If FC_Con.State = ConnectionState.Closed Then
            conData = FC_GetDatos()
            FC_Con = New SqlConnection()
            FC_Con.ConnectionString = "Data Source=" + conData(0) + " ;" &
                         "Initial Catalog=" + IIf(sopcio <> "", sopcio, FC_DATABASE) + ";" &
                         "User Id=" + conData(1) + ";Password=" + conData(2) + ";MultipleActiveResultSets=True"
            FC_Con.Open()
        End If
        FC_Conexion = 0
        Exit Function
ERR_CON:
        MsgBox("Error al conectar base de datos General." & vbCrLf & Err.Description, vbCritical, "Validación")
        FC_Conexion = Err.Number
    End Function

    Public Function FC_ConexionSQL(ByVal BaseSQL As String) As Long
        Dim conData() As String
        On Error GoTo ERR_CON

        If FC_SQL.State = ConnectionState.Connecting Then FC_SQL.Close()
        conData = FC_GetDatos()
        FC_SQL = New SqlConnection()
        FC_SQL.ConnectionString = "Data Source=" + conData(0) + " ;" &
                         "Initial Catalog=" + BaseSQL + ";" &
                         "User Id=" + conData(1) + ";Password=" + conData(2) + ";MultipleActiveResultSets=True"
        FC_SQL.Open()
        FC_ConexionSQL = 0
        Exit Function
ERR_CON:
        MsgBox("Error al conectar base SQL." & vbCrLf & Err.Description, vbCritical, "Validación")
        FC_ConexionSQL = Err.Number
    End Function

    Public Function FC_ConexionFOX(foxRuta As String) As Long
        Dim sConn As String
        On Error GoTo ERR_CON
        If FC_CONFOX.State = ConnectionState.Connecting Then FC_CONFOX.Close()
        sConn = "Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;SourceDB=" &
                foxRuta & ";"
        FC_CONFOX = New OdbcConnection(sConn)
        FC_CONFOX.Open()
        FC_ConexionFOX = 0
        Exit Function
ERR_CON:
        MsgBox("Error al conectar base FoxCon." & vbCrLf & Err.Description, "Validación")
        FC_ConexionFOX = Err.Number
    End Function

    Public Property FC_RutaEmpresasAdmin() As String
        Get
            On Error Resume Next
            FC_RutaEmpresasAdmin = My.Computer.Registry.GetValue(FC_REGKEY, "RutaEmpresas", Nothing) 'objShell.RegRead(FC_REGKEY & "BDDGen")
        End Get
        Set(ByVal val As String)
            On Error Resume Next
            WriteToRegistry("RutaEmpresas", val)
        End Set
    End Property

    Public Sub FC_SetDatos(ByVal Inst As String, ByVal Uid As String, ByVal Pwd As String)
        WriteToRegistry("Instancia", Inst)
        WriteToRegistry("Password", Pwd)
        WriteToRegistry("Uid", Uid)
    End Sub

    Public Property FC_RutaSDKAdmin() As String
        Get
            On Error Resume Next
            FC_RutaSDKAdmin = My.Computer.Registry.GetValue(FC_REGKEY, "RutaAdminPAQ", Nothing) 'objShell.RegRead(FC_REGKEY & "BDDGen")
        End Get
        Set(ByVal val As String)
            On Error Resume Next
            WriteToRegistry("RutaAdminPAQ", val)
        End Set
    End Property

    Public Property FC_RutaModulos() As String
        Get
            On Error Resume Next
            FC_RutaModulos = My.Computer.Registry.GetValue(FC_REGKEY, "RutaModulos", Nothing)
        End Get
        Set(ByVal val As String)
            On Error Resume Next
            WriteToRegistry("RutaModulos", val)
        End Set
    End Property

    Public Property FC_RutaSincronizada() As String
        Get
            On Error Resume Next
            FC_RutaSincronizada = My.Computer.Registry.GetValue(FC_REGKEY, "RutaSincronizada", Nothing)
        End Get
        Set(ByVal val As String)
            On Error Resume Next
            WriteToRegistry("RutaSincronizada", val)
        End Set
    End Property


    Public Function FC_GetCons() As Long
        Dim cRs As SqlDataReader
        Dim comCrs As SqlCommand
        Dim Exists As Boolean
        Dim prevKey As String

        On Error GoTo ERR_GETCONS
        FC_Conexion()
        comCrs = New SqlCommand("SELECT * FROM Instancias", FC_Con)
        cRs = comCrs.ExecuteReader()
        If cRs.HasRows = False Then MsgBox("No hay instancias registradas.", vbExclamation, "Error de instancias FC") : FC_GetCons = 1 : Exit Function

        DConexiones = New Dictionary(Of String, SqlConnection)

        Do While cRs.Read()
            Exists = False
            If Not Exists Then
                DConexiones.Add(CStr(cRs("nombre")), New SqlConnection)
                DConexiones(CStr(cRs("nombre"))).ConnectionString = "Data Source=" + cRs("server") + " ;" &
                         "User Id=" + cRs("uid") + ";Password=" + cRs("pwd") + ";MultipleActiveResultSets=True"
                DConexiones(CStr(cRs("nombre"))).Open()
            End If
        Loop
        FC_GetCons = 0
        cRs.Close()

        Exit Function
ERR_GETCONS:
        FC_GetCons = Err.Number
    End Function

    Public Sub FC_CrearBDD()
        Dim opCmd As SqlCommand
        If Not FC_Con Is Nothing Then
            If FC_Con.State = ConnectionState.Open Then
                FC_Con.Close()
            End If
            'If FC_Con.Database <> "master" Then
            '    fError = FC_Conexion()
            '    If fError <> 0 Then Exit Sub
            'End If
        End If
        fError = FC_Conexion("master")
        If fError <> 0 Then Exit Sub
        Try
            opCmd = New SqlCommand("IF db_id('" & FC_DATABASE & "') IS NULL CREATE DATABASE " & FC_DATABASE & ";", FC_Con)
            opCmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        FC_Con.Close()
    End Sub

    Public Function verificarTablasModulo(ByVal arrTablas() As String) As Boolean
        Dim cmdChk As SqlCommand
        Dim cQue As String
        Dim i As Integer, n As Integer

        fError = FC_Conexion()
        If fError <> 0 Then

        End If

        cQue = "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES " &
        "WHERE TABLE_TYPE = 'BASE TABLE' " &
        "AND TABLE_NAME = @nombreTabla"

        For i = LBound(arrTablas) To UBound(arrTablas)
            cmdChk = New SqlCommand(cQue, FC_Con)
            cmdChk.Parameters.AddWithValue("@nombreTabla", arrTablas(i))
            ' Comprobamos si está
            ' Devuelve 1 si ya existe
            ' o 0 si no existe
            n = CInt(cmdChk.ExecuteScalar())
            If n = 0 Then
                verificarTablasModulo = False
                Exit Function
            End If
            cmdChk.Dispose()
        Next i

        verificarTablasModulo = True
    End Function

    Public Function EstaAbierto(ByVal Myform As Form) As Boolean
        Dim objForm As Form
        Dim blnAbierto As Boolean = False
        blnAbierto = False
        For Each objForm In My.Application.OpenForms
            If (Trim(objForm.Name) = Trim(Myform.Name)) Then
                blnAbierto = True
            End If
        Next
        Return blnAbierto
    End Function

    Public Function ObtenerUltimoDia(Fecha As Date) As Date
        '    ObtenerPrimerDia = DateSerial(Year(Fecha), Month(Fecha) + 0, 1)
        ObtenerUltimoDia = DateSerial(Year(Fecha), Month(Fecha) + 1, 0)
    End Function
End Module
