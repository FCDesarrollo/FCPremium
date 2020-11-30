Public Class clModulosCRM
    Private _idmodulo As Integer
    Private _nombremodulo As String
    Private _estatus As Boolean
    Public Property IDModulo As Integer
        Get
            Return _idmodulo
        End Get
        Set(value As Integer)
            _idmodulo = value
        End Set
    End Property

    Public Property NombreModulo As String
        Get
            Return _nombremodulo
        End Get
        Set(value As String)
            _nombremodulo = value
        End Set
    End Property

    Public Property Estatus As Boolean
        Get
            Return _estatus
        End Get
        Set(value As Boolean)
            _estatus = value
        End Set
    End Property
End Class
