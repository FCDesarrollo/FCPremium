Public Class clSubMenusCRM
    Private _idsubmenu As Integer
    Private _nombresubmenu As String
    Private _estatus As Boolean
    Public Property IDSubMenu As Integer
        Get
            Return _idsubmenu
        End Get
        Set(value As Integer)
            _idsubmenu = value
        End Set
    End Property

    Public Property NombreSubMenu As String
        Get
            Return _nombresubmenu
        End Get
        Set(value As String)
            _nombresubmenu = value
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
