Public Class clDocDigital
    Private _id As Integer
    Private _fechadocto As Date
    Private _codigodocumento As String
    Private _documento As String
    Private _estatus As Integer
    Private _descripcion As String
    Private _iddocadw As Integer

    Public Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Property Fechadocto As Date
        Get
            Return _fechadocto
        End Get
        Set(value As Date)
            _fechadocto = value
        End Set
    End Property

    Public Property Codigodocumento As String
        Get
            Return _codigodocumento
        End Get
        Set(value As String)
            _codigodocumento = value
        End Set
    End Property

    Public Property Documento As String
        Get
            Return _documento
        End Get
        Set(value As String)
            _documento = value
        End Set
    End Property

    Public Property Estatus As Integer
        Get
            Return _estatus
        End Get
        Set(value As Integer)
            _estatus = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Iddocadw As Integer
        Get
            Return _iddocadw
        End Get
        Set(value As Integer)
            _iddocadw = value
        End Set
    End Property
End Class
