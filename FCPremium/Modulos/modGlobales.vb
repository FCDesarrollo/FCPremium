Module modGlobales
    Public Const tAdmin As Integer = 0
    Public Const tSupervisor As Integer = 1
    Public Const tUsuario As Integer = 2

    Public sSystema As Integer ' 0.- IGUAL SIN INSTALAR , 1.- YA INSTALADO
    Public Const UserAdmin As String = "FCPREMIUM"
    Public Const PassAdmin As String = "FC2019"
    Public menUser As Boolean

    Public jsonObject As Newtonsoft.Json.Linq.JObject

    Public cUsuario As clUsuario
    Public cParam As clParametros

    Public GL_cUsuarioAPI As clUserAPI
    Public GL_SubMenu As Collection

    Public Const conInfo As String = "Intalación " & vbCrLf & "Guarda la configuración Principal para los Modulos."


    Public mLinkNube As String
    Public mUserNube As String
    Public mPassNube As String
    'Public Const mApi As String = "http://localhost/ApiConsultorMX/miconsultor/public/"
    Public Const mApi As String = "http://apicrm.dublock.com/public/"

    Public Const Menu_Digital_Operacion As Integer = 5
    Public Function Inicio_UserAPI() As Boolean
        Inicio_UserAPI = False
        If GL_cUsuarioAPI IsNot Nothing Then
            If GL_cUsuarioAPI.Correo <> "" And GL_cUsuarioAPI.Contra <> "" Then Inicio_UserAPI = True
        End If
    End Function

    Public Sub GetError_Api(ByVal aError As Integer)
        Select Case aError
            Case 1
                MsgBox("El RFC de la empresa es incorrecto.", vbInformation, "Error Conexion CRM")
            Case 2
                MsgBox("Correo de usuario incorrecta.", vbInformation, "Error Conexion CRM")
            Case 3
                MsgBox("La contraseña es incorrecta.", vbInformation, "Error Conexion CRM")
            Case 4
                MsgBox("El Usuario no tiene permisos para realizar esta accion.", vbInformation, "Error Conexion CRM")
            Case 5
                MsgBox("El tipo de documento no es valido.", vbInformation, "Error Conexion CRM")
        End Select
    End Sub

    Public Sub Carga_submenus(ByVal cIdmenu As Integer)
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String, subM As clSubMenu

        GL_SubMenu = New Collection

        dFiltro = "idmenu=" & cIdmenu
        dMetodo = "SubMenusFiltro"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro)
        If jsonMod <> "" Then
            jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
            For Each Row In jsonObject("submenus")
                subM = New clSubMenu
                subM.Idsubmenu = Row("idsubmenu")
                subM.Idmenu = Row("idmenu")
                subM.Nombresubmenu = Row("nombre_submenu")
                subM.NombreCarpeta = Row("nombre_carpeta")
                subM.Descripcion = Row("descripcion")
                subM.Ref = Row("ref")
                subM.Fecha = Row("fecha")
                subM.Status = Row("status")
                subM.Nombremenu = Row("nombre_menu")
                GL_SubMenu.Add(subM)
            Next
        End If
    End Sub

    Public Function CheckForm(_form As Form) As Form
        For Each f As Form In Application.OpenForms
            If f.Name = _form.Name Then
                Return f
            End If
        Next

        Return Nothing
    End Function

    Public Sub Carga_Empresas(ByVal cb As ComboBox)
        Dim vEmpresa As clEmpresa, dt As DataTable
        Dim dr As DataRow
        dt = New DataTable("Empresas")
        dt.Columns.Add("id")
        dt.Columns.Add("Nombre")

        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "SELECCIONAR EMPRESA"
        dt.Rows.Add(dr)

        GL_cUsuarioAPI.lista_empresas()

        For Each vEmpresa In GL_cUsuarioAPI.MEmpresas
            dr = dt.NewRow
            dr(0) = vEmpresa.Idempresa
            dr(1) = vEmpresa.Nombreempresa
            dt.Rows.Add(dr)
        Next

        cb.DataSource = dt
        cb.ValueMember = "id"
        cb.DisplayMember = "Nombre"
    End Sub
End Module
