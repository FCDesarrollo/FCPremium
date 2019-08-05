Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel
Public Class clModulos
    Private _idmodulo As Integer
    Private _nombremodulo As String
    Private _version As Double
    Private _fechaActualiza As Date
    Private _permisouser As Integer
    Private _nombrearchivo As String
    Private _permisomod As Integer
    Private _nombreficha As String

    Private _archivover As String
    Private _nombrecarpeta As String

    Private _xlApp As Excel.Application
    Private _xlBook As Excel.Workbook

    Public Property Idmodulo As Integer
        Get
            Return _idmodulo
        End Get
        Set(value As Integer)
            _idmodulo = value
        End Set
    End Property

    Public Property Nombremodulo As String
        Get
            Return _nombremodulo
        End Get
        Set(value As String)
            _nombremodulo = value
        End Set
    End Property

    Public Property Version As Double
        Get
            Return _version
        End Get
        Set(value As Double)
            _version = value
        End Set
    End Property

    Public Property FechaActualiza As Date
        Get
            Return _fechaActualiza
        End Get
        Set(value As Date)
            _fechaActualiza = value
        End Set
    End Property



    Public Property Nombrearchivo As String
        Get
            Return _nombrearchivo
        End Get
        Set(value As String)
            _nombrearchivo = value
        End Set
    End Property

    Public Property Permisouser As Integer
        Get
            Return _permisouser
        End Get
        Set(value As Integer)
            _permisouser = value
        End Set
    End Property

    Public Property XlApp As Application
        Get
            Return _xlApp
        End Get
        Set(value As Application)
            _xlApp = value
        End Set
    End Property

    Public Property XlBook As Workbook
        Get
            Return _xlBook
        End Get
        Set(value As Workbook)
            _xlBook = value
        End Set
    End Property

    Public Property Permisomod As Integer
        Get
            Return _permisomod
        End Get
        Set(value As Integer)
            _permisomod = value
        End Set
    End Property

    Public Property Nombreficha As String
        Get
            Return _nombreficha
        End Get
        Set(value As String)
            _nombreficha = value
        End Set
    End Property

    Public Property Archivover As String
        Get
            Return _archivover
        End Get
        Set(value As String)
            _archivover = value
        End Set
    End Property

    Public Property Nombrecarpeta As String
        Get
            Return _nombrecarpeta
        End Get
        Set(value As String)
            _nombrecarpeta = value
        End Set
    End Property

    Public Sub SaveModulo()
        Dim cQue As String
        cQue = "IF NOT EXISTS (SELECT idmodulo FROM FCModulos WHERE idmodulo=@idmod)
                        BEGIN INSERT INTO FCModulos(idmodulo,nombre_modulo,version,permiso)
                                VALUES(@idmod, @nombre, @version, @permiso) END"
        Try
            Using gCom = New SqlCommand(cQue, FC_Con)
                gCom.Parameters.AddWithValue("@idmod", _idmodulo)
                gCom.Parameters.AddWithValue("@nombre", _nombremodulo)
                gCom.Parameters.AddWithValue("@version", _version)
                gCom.Parameters.AddWithValue("@permiso", _permisomod)
                gCom.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub ActualizaMod()
        Dim dQue As String
        dQue = "UPDATE FCModulos SET version=@ver, fechaactualizacion=@fecha, 
                                permiso=@per, nombre_archivo=@nomar, nombre_ficha=@ficha,
                                cargado=@carga, archivo_ver=@arcver,nombre_carpeta=@nomcar WHERE idmodulo=@idmod"
        Try
            Using dCom = New SqlCommand(dQue, FC_Con)
                dCom.Parameters.AddWithValue("@ver", _version)
                dCom.Parameters.AddWithValue("@fecha", _fechaActualiza)
                dCom.Parameters.AddWithValue("@per", _permisomod)
                dCom.Parameters.AddWithValue("@nomar", _nombrearchivo)
                dCom.Parameters.AddWithValue("@ficha", _nombreficha)
                dCom.Parameters.AddWithValue("@carga", 0)
                dCom.Parameters.AddWithValue("@arcver", _archivover)
                dCom.Parameters.AddWithValue("@nomcar", _nombrecarpeta)
                dCom.Parameters.AddWithValue("@idmod", _idmodulo)
                dCom.ExecuteNonQuery()
                serverMod()
            End Using
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub serverMod()
        Dim dFiltro As String, sfech As String
        Dim jsonMod As String
        sfech = Format(_fechaActualiza.Date, "yyyy-MM-dd")

        dFiltro = "rfc=" & cParam.Rfclien & "&idmodulo=" & _idmodulo & "&fecha=" &
                    sfech & "&version=" & Strings.Format(_version, "0.0#") & "&permiso=" & _permisomod
        If My.Computer.Network.IsAvailable Then
            jsonMod = ConsumeAPI(cParam.Api, "actualizaVersion", dFiltro)
        End If
    End Sub
End Class
