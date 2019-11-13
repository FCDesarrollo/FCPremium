Public Class clSubMenu
    Private _idsubmenu As Integer
    Private _idmenu As Integer
    Private _nombresubmenu As String
    Private _nombreCarpeta As String
    Private _descripcion As String
    Private _ref As String
    Private _fecha As Date
    Private _status As Integer
    Private _nombremenu As String

    Public Property Idsubmenu As Integer
        Get
            Return _idsubmenu
        End Get
        Set(value As Integer)
            _idsubmenu = value
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

    Public Property Nombresubmenu As String
        Get
            Return _nombresubmenu
        End Get
        Set(value As String)
            _nombresubmenu = value
        End Set
    End Property

    Public Property NombreCarpeta As String
        Get
            Return _nombreCarpeta
        End Get
        Set(value As String)
            _nombreCarpeta = value
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

    Public Property Ref As String
        Get
            Return _ref
        End Get
        Set(value As String)
            _ref = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _fecha
        End Get
        Set(value As Date)
            _fecha = value
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

    Public Property Nombremenu As String
        Get
            Return _nombremenu
        End Get
        Set(value As String)
            _nombremenu = value
        End Set
    End Property
End Class
