Public Class clUserAPI
    Private _iduser As Integer
    Private _nombreuser As String
    Private _apellidop As String
    Private _apellidom As String
    Private _usuario As String
    Private _tipo As Integer
    Private _status As Integer

    Private _correo As String
    Private _contra As String

    Private _pwd As String

    Private _mEmpresas As New Collection

    Public Property Correo As String
        Get
            Return _correo
        End Get
        Set(value As String)
            _correo = value
        End Set
    End Property

    Public Property Contra As String
        Get
            Return _contra
        End Get
        Set(value As String)
            _contra = value
        End Set
    End Property

    Public Property EncryptedContra As String
        Get
            Return _pwd
        End Get
        Set(value As String)
            _pwd = value
        End Set
    End Property

    Public Property MEmpresas As Collection
        Get
            Return _mEmpresas
        End Get
        Set(value As Collection)
            _mEmpresas = value
        End Set
    End Property

    Public Property Iduser As Integer
        Get
            Return _iduser
        End Get
        Set(value As Integer)
            _iduser = value
        End Set
    End Property

    Public Property Nombreuser As String
        Get
            Return _nombreuser
        End Get
        Set(value As String)
            _nombreuser = value
        End Set
    End Property

    Public Property Apellidop As String
        Get
            Return _apellidop
        End Get
        Set(value As String)
            _apellidop = value
        End Set
    End Property

    Public Property Apellidom As String
        Get
            Return _apellidom
        End Get
        Set(value As String)
            _apellidom = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
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

    Public Sub lista_empresas()
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String, e As clEmpresa

        _mEmpresas = New Collection

        dMetodo = "ListaEmpresas?idusuario=" & GL_cUsuarioAPI.Iduser
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "GET")
        If jsonMod <> "" Then
            jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
            For Each Row In jsonObject("empresas")
                e = New clEmpresa
                e.Idempresa = Row("idempresa")
                e.Nombreempresa = Row("nombreempresa")
                e.Rutaempresa = Row("rutaempresa")
                e.Rfc = Row("RFC")
                e.Direccion = Row("direccion")
                e.Telefono = Row("telefono")

                e.Fecharegistro = Row("fecharegistro")
                e.Status = Row("status")
                e.Correo = Row("correo")
                e.EmpresaBD = Row("empresaBD")
                'e.Vigencia = Row("vigencia")
                e.Usuario_storage = Row("usuario_storage")
                e.Password_storage = Row("password_storage")

                _mEmpresas.Add(e)
            Next
        End If
    End Sub

End Class
