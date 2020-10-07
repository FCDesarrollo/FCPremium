Public Class clServicios
    Private _idservicio As Integer
    Private _codservicio As String
    Private _servicio As String
    Private _descripcion As String
    Private _tipo As Integer
    Private _status As Boolean
    Private _idmodulo As Integer
    Private _idmenu As Integer
    Private _idsubmenu As Integer
    Private _sevcontratado As Integer
    Private _idfcmodulo As Integer

    Public Property Idfcmodulo As Integer
        Get
            Return _idfcmodulo
        End Get
        Set(value As Integer)
            _idfcmodulo = value
        End Set
    End Property
    Public Property Idservicio As Integer
        Get
            Return _idservicio
        End Get
        Set(value As Integer)
            _idservicio = value
        End Set
    End Property
    Public Property CodigoServicio As String
        Get
            Return _codservicio
        End Get
        Set(value As String)
            _codservicio = value
        End Set
    End Property
    Public Property Servicio As String
        Get
            Return _servicio
        End Get
        Set(value As String)
            _servicio = value
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
    Public Property Tipo As Integer
        Get
            Return _tipo
        End Get
        Set(value As Integer)
            _tipo = value
        End Set
    End Property
    Public Property Status As Boolean
        Get
            Return _status
        End Get
        Set(value As Boolean)
            _status = value
        End Set
    End Property
    Public Property Idmodulo As Integer
        Get
            Return _idmodulo
        End Get
        Set(value As Integer)
            _idmodulo = value
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
    Public Property ServicioContratado As Integer
        Get
            Return _sevcontratado
        End Get
        Set(value As Integer)
            _sevcontratado = value
        End Set
    End Property

End Class
