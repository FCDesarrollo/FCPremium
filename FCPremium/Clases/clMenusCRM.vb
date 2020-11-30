Public Class clMenusCRM
    Private _idmenu As Integer
    Private _nombremenu As String
    Private _estatus As Boolean
    Public Property IDMenu As Integer
        Get
            Return _idmenu
        End Get
        Set(value As Integer)
            _idmenu = value
        End Set
    End Property

    Public Property NombreMenu As String
        Get
            Return _nombremenu
        End Get
        Set(value As String)
            _nombremenu = value
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
