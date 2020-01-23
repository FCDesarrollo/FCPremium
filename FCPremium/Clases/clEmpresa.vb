Public Class clEmpresa
    Private _idempresa As Integer
    Private _nombreempresa As String
    Private _rutaempresa As String
    Private _rfc As String
    Private _direccion As String
    Private _telefono As String
    Private _codigopostal As Integer
    Private _fecharegistro As Date
    Private _status As Integer
    Private _password As String
    Private _correo As String
    Private _empresaBD As String
    Private _vigencia As Date
    Private _usuario_storage As String
    Private _password_storage As String



    Public Property Idempresa As Integer
        Get
            Return _idempresa
        End Get
        Set(value As Integer)
            _idempresa = value
        End Set
    End Property

    Public Property Nombreempresa As String
        Get
            Return _nombreempresa
        End Get
        Set(value As String)
            _nombreempresa = value
        End Set
    End Property

    Public Property Rutaempresa As String
        Get
            Return _rutaempresa
        End Get
        Set(value As String)
            _rutaempresa = value
        End Set
    End Property

    Public Property Rfc As String
        Get
            Return _rfc
        End Get
        Set(value As String)
            _rfc = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _direccion
        End Get
        Set(value As String)
            _direccion = value
        End Set
    End Property

    Public Property Telefono As String
        Get
            Return _telefono
        End Get
        Set(value As String)
            _telefono = value
        End Set
    End Property

    Public Property Codigopostal As Integer
        Get
            Return _codigopostal
        End Get
        Set(value As Integer)
            _codigopostal = value
        End Set
    End Property

    Public Property Fecharegistro As Date
        Get
            Return _fecharegistro
        End Get
        Set(value As Date)
            _fecharegistro = value
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

    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Public Property Correo As String
        Get
            Return _correo
        End Get
        Set(value As String)
            _correo = value
        End Set
    End Property

    Public Property EmpresaBD As String
        Get
            Return _empresaBD
        End Get
        Set(value As String)
            _empresaBD = value
        End Set
    End Property

    Public Property Vigencia As Date
        Get
            Return _vigencia
        End Get
        Set(value As Date)
            _vigencia = value
        End Set
    End Property

    Public Property Usuario_storage As String
        Get
            Return _usuario_storage
        End Get
        Set(value As String)
            _usuario_storage = value
        End Set
    End Property

    Public Property Password_storage As String
        Get
            Return _password_storage
        End Get
        Set(value As String)
            _password_storage = value
        End Set
    End Property

End Class
