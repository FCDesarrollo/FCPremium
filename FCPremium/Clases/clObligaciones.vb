Public Class clObligaciones
    Private _idobligacion As Integer
    Private _claveobligacion As String
    Private _obligacion As String
    Private _consecutivo As Integer
    Private _tipo As String
    Private _claveestado As String
    Private _estado As String
    Private _ejercicio As Integer
    Private _periodo As String

    Public Property periodo As String
        Get
            Return _periodo
        End Get
        Set(value As String)
            _periodo = value
        End Set
    End Property

    Public Property ejercicio As Integer
        Get
            Return _ejercicio
        End Get
        Set(value As Integer)
            _ejercicio = value
        End Set
    End Property

    Public Property idobligacion As Integer
        Get
            Return _idobligacion
        End Get
        Set(value As Integer)
            _idobligacion = value
        End Set
    End Property

    Public Property consecutivo As Integer
        Get
            Return _consecutivo
        End Get
        Set(value As Integer)
            _consecutivo = value
        End Set
    End Property

    Public Property tipo As String
        Get
            Return _tipo
        End Get
        Set(value As String)
            _tipo = value
        End Set
    End Property

    Public Property claveestado As String
        Get
            Return _claveestado
        End Get
        Set(value As String)
            _claveestado = value
        End Set
    End Property

    Public Property estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property claveobligacion As String
        Get
            Return _claveobligacion
        End Get
        Set(value As String)
            _claveobligacion = value
        End Set
    End Property

    Public Property obligacion As String
        Get
            Return _obligacion
        End Get
        Set(value As String)
            _obligacion = value
        End Set
    End Property
End Class
