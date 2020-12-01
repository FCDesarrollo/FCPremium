Public Class clSucursalesCRM
    Private _idsucursal As Long
    Private _sucursal As String
    Private _rutaadw As String
    Private _idadw As Long
    Private _predeterminada As Integer

    Public Property IDSucursal As Long
        Get
            Return _idsucursal
        End Get
        Set(value As Long)
            _idsucursal = value
        End Set
    End Property

    Public Property Sucursal As String
        Get
            Return _sucursal
        End Get
        Set(value As String)
            _sucursal = value
        End Set
    End Property

    Public Property RutaADW As String
        Get
            Return _rutaadw
        End Get
        Set(value As String)
            _rutaadw = value
        End Set
    End Property

    Public Property IDAdw As Long
        Get
            Return _idadw
        End Get
        Set(value As Long)
            _idadw = value
        End Set
    End Property

    Public Property Predeterminada As Integer
        Get
            Return _predeterminada
        End Get
        Set(value As Integer)
            _predeterminada = value
        End Set
    End Property

End Class
