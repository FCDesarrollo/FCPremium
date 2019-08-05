Imports System.Data.SqlClient

Public Class clParametros
    Private _api As String
    Private _userapi As String
    Private _passapi As String
    Private _rDescarga As String
    Private _ufecha As Date
    Private _uversion As Double
    Private _nomclien As String
    Private _rfclien As String

    Private _equipo As String
    Public Property Api As String
        Get
            Return _api
        End Get
        Set(value As String)
            _api = value
        End Set
    End Property

    Public Property Userapi As String
        Get
            Return _userapi
        End Get
        Set(value As String)
            _userapi = value
        End Set
    End Property

    Public Property Passapi As String
        Get
            Return _passapi
        End Get
        Set(value As String)
            _passapi = value
        End Set
    End Property

    Public Property RDescarga As String
        Get
            Return _rDescarga
        End Get
        Set(value As String)
            _rDescarga = value
        End Set
    End Property

    Public Property Ufecha As Date
        Get
            Return _ufecha
        End Get
        Set(value As Date)
            _ufecha = value
        End Set
    End Property

    Public Property Uversion As Double
        Get
            Return _uversion
        End Get
        Set(value As Double)
            _uversion = value
        End Set
    End Property

    Public Property Nomclien As String
        Get
            Return _nomclien
        End Get
        Set(value As String)
            _nomclien = value
        End Set
    End Property

    Public Property Rfclien As String
        Get
            Return _rfclien
        End Get
        Set(value As String)
            _rfclien = value
        End Set
    End Property

    Public Property Equipo As String
        Get
            Return _equipo
        End Get
        Set(value As String)
            _equipo = value
        End Set
    End Property

    Public Function loadParam() As Boolean
        Dim vQue As String
        loadParam = False
        vQue = "SELECT  ultima_actualizacion, Actualizado, nombrecliente, rfccliente
                    FROM FCParametros"
        Using vCom = New SqlCommand(vQue, FC_Con)
            Using vRs = vCom.ExecuteReader()
                vRs.Read()
                If vRs.HasRows = True Then
                    loadParam = True
                    _api = mApi
                    _userapi = FCPremium.UserAdmin
                    _passapi = FCPremium.PassAdmin
                    _rDescarga = FC_RutaModulos
                    _ufecha = vRs("ultima_actualizacion")
                    _uversion = vRs("Actualizado")
                    _nomclien = vRs("nombrecliente")
                    _rfclien = vRs("rfccliente")
                    _equipo = GetSerialMother() & GetSerialDisco()
                End If
            End Using
        End Using
    End Function

    Public Function SaveParam() As Boolean
        SaveParam = False
        Dim cQue As String

        cQue = "DELETE FROM FCParametros"
        Using dleCom = New SqlCommand(cQue, FC_Con)
            dleCom.ExecuteNonQuery()
        End Using

        _uversion = ClientRegistrado()

        cQue = "INSERT INTO FCParametros(ultima_actualizacion,Actualizado,nombrecliente, rfccliente)
                                            VALUES(@ultima, @ver, @nombre, @rfc)"
        Try
            Using gCom = New SqlCommand(cQue, FC_Con)
                gCom.Parameters.AddWithValue("@ultima", _ufecha)
                gCom.Parameters.AddWithValue("@ver", _uversion)
                gCom.Parameters.AddWithValue("@nombre", _nomclien)
                gCom.Parameters.AddWithValue("@rfc", _rfclien)
                gCom.ExecuteNonQuery()
                SaveParam = True
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Private Function ClientRegistrado() As Double
        Dim dFiltro As String
        Dim jsonMod As String
        ClientRegistrado = 0
        dFiltro = "rfc=" & _rfclien & "&razon=" & _nomclien
        If My.Computer.Network.IsAvailable Then
            jsonMod = ConsumeAPI(_api, "altaCliente", dFiltro)
            ClientRegistrado = CDbl(jsonMod)
        End If
    End Function

    Public Sub atualizaVersion()
        Dim aversion As Double, cQue As String
        aversion = ClientRegistrado()
        cQue = "UPDATE FCParametros SET Actualizado=@ver"
        Try
            Using gCom = New SqlCommand(cQue, FC_Con)
                gCom.Parameters.AddWithValue("@ver", aversion)
                gCom.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Function ValidaParametros() As Boolean
        ValidaParametros = True

        If _api = "" Or _userapi = "" Or _passapi = "" _
                Or _nomclien = "" Or _rfclien = "" Or _rDescarga = "" Then
            ValidaParametros = False
        End If

    End Function
End Class
