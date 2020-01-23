Public Class clRubro
    Private _id As Integer
    Private _clave As String
    Private _nombre As String
    Private _tipo As Integer
    Private _status As Integer
    Private _idmenu As Integer
    Private _idsubmenu As Integer

    Private _claveplantilla As String

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Clave As String
        Get
            Return _clave
        End Get
        Set(value As String)
            _clave = value
        End Set
    End Property

    Public Property Nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property Tipo As Integer
        Get
            Return _tipo
        End Get
        Set(value As Integer)
            _tipo = value
        End Set
    End Property

    Public Property Status As Integer
        Get
            Return _status
        End Get
        Set(value As Integer)
            _status = value
        End Set
    End Property

    Public Property Idmenu As Integer
        Get
            Return _idmenu
        End Get
        Set(value As Integer)
            _idmenu = value
        End Set
    End Property

    Public Property Idsubmenu As Integer
        Get
            Return _idsubmenu
        End Get
        Set(value As Integer)
            _idsubmenu = value
        End Set
    End Property

    Public Property Claveplantilla As String
        Get
            Return _claveplantilla
        End Get
        Set(value As String)
            _claveplantilla = value
        End Set
    End Property
End Class
