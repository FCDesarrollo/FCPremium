Imports System.Data.SqlClient

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
    Public Const Menu_Recepcion_Lotes As Integer = 6

    Public G_claRubroNew As String
    Public G_carFin As String

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

    Public Sub Carga_sucursales(ByVal cIDEmp As Integer, ByVal cb As ComboBox)
        Dim dt As DataTable, tieneSuc As Boolean
        Dim dr As DataRow
        dt = New DataTable("Sucursal")
        dt.Columns.Add("Ruta")
        dt.Columns.Add("Nombre")

        dr = dt.NewRow
        dr(0) = ""
        dr(1) = "SELECCIONAR SUCURSAL"
        dt.Rows.Add(dr)

        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String

        tieneSuc = False
        dFiltro = "{""Correo"":""" & GL_cUsuarioAPI.Correo & """, ""Contra"":""" &
                    GL_cUsuarioAPI.Contra & """, ""Idempresa"":" &
                    cIDEmp & ",""Sincronizado"":1}"
        dMetodo = "datosSucursal"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod = "false" Then
                MsgBox("Error al cargar las Sucursales del CRM", vbExclamation, "Validación")
            Else
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                For Each Row In jsonObject("Sucursales")
                    tieneSuc = True
                    dr = dt.NewRow
                    dr(0) = Row("rutaadw")
                    dr(1) = Row("sucursal")
                    dt.Rows.Add(dr)
                Next
            End If
        End If

        If tieneSuc = False Then
            dt.Rows.Clear()
            dr = dt.NewRow
            dr(0) = -1
            dr(1) = "SIN SUCURSAL ASIGNADA"
            dt.Rows.Add(dr)
            'MsgBox("La Empresa no tiene sucursales.", vbInformation, "Validación")
        End If

        cb.DataSource = dt
        cb.ValueMember = "Ruta"
        cb.DisplayMember = "Nombre"
    End Sub


    Public Sub Carga_rubros(ByVal cIDEmp As Integer, ByVal idsub As Integer, cb2 As ComboBox)
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String, esTodo As Boolean

        Dim dt As DataTable
        Dim dr As DataRow
        dt = New DataTable("Rubros")
        dt.Columns.Add("iddoc")
        dt.Columns.Add("Nombre")

        dr = dt.NewRow
        dr(0) = "0"
        dr(1) = "TODOS"
        dt.Rows.Add(dr)

        'dg.Rows.Clear()
        esTodo = IIf(idsub = 0, True, False)

        'For Each item As Object In cb.Items
        '    If idsub = CInt(item("id")) Or esTodo Then
        If idsub > 0 Then
            dFiltro = "{""Correo"":""" & GL_cUsuarioAPI.Correo & """, ""Contra"":""" &
                    GL_cUsuarioAPI.Contra & """, ""Idempresa"":" &
                    cIDEmp & ",""idmenu"":" & Menu_Digital_Operacion & ",""idsubmenu"":" &
                    idsub & "}"
            dMetodo = "datosRubrosSubMenu"
            jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
            If jsonMod <> "" Then
                If jsonMod <> "false" Then
                    jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                    For Each Row In jsonObject("Rubros")
                        If CInt(Row("status")) = 1 Then
                            dr = dt.NewRow
                            dr(0) = CStr(Row("id")) & "|" & CStr(Row("tipo"))
                            dr(1) = CStr(Row("nombre"))
                            dt.Rows.Add(dr)
                            'dg.Rows.Add(CInt(Row("tipo")), CStr(item("Nombre")), Row("nombre"), Row("clave"), Row("idsubmenu"))
                        End If
                    Next
                End If
            End If
        End If
        '    End If
        'Next

        'dr = dt.NewRow
        'dr(0) = "0"
        'dr(1) = "TODOS"
        'dt.Rows.Add(dr)
        dr = dt.NewRow
        dr(0) = "-1"
        dr(1) = "OTROS"
        dt.Rows.Add(dr)

        cb2.DataSource = dt
        cb2.ValueMember = "iddoc"
        cb2.DisplayMember = "Nombre"
    End Sub

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

    Public Sub Carga_Permisos(ByVal cIDEmpresa As Integer, ByVal cb As ComboBox)
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String, subM As clSubMenu
        Dim dt As DataTable
        Dim dr As DataRow
        dt = New DataTable("operaciones")
        dt.Columns.Add("id")
        dt.Columns.Add("Nombre")

        dr = dt.NewRow
        dr(0) = -1
        dr(1) = "SELECCIONAR OPERACIÓN"
        dt.Rows.Add(dr)



        dMetodo = "PermisoSubMenus?idusuario=" & GL_cUsuarioAPI.Iduser &
                    "&idempresa=" & cIDEmpresa & "&idmenu=" & Menu_Digital_Operacion
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "GET")
        If jsonMod <> "" Then
            jsonMod = "{ ""permiso"":" & jsonMod & "}"
            jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
            For Each Row In jsonObject("permiso")
                If CInt(Row("tipopermiso")) <> 0 Then
                    For Each subM In GL_SubMenu
                        If CInt(Row("idsubmenu")) = subM.Idsubmenu Then
                            dr = dt.NewRow
                            dr(0) = subM.Idsubmenu
                            dr(1) = subM.Nombresubmenu
                            dt.Rows.Add(dr)
                            Exit For
                        End If
                    Next

                End If
            Next
        End If

        'dr = dt.NewRow
        'dr(0) = 0
        'dr(1) = "TODOS"
        'dt.Rows.Add(dr)

        cb.DataSource = dt
        cb.ValueMember = "id"
        cb.DisplayMember = "Nombre"
    End Sub

    Public Function Get_Modulo_SubMenu(ByVal cIDModulo As Integer) As String()
        Dim sArr(0 To 1) As String, NomSub As String, IDSub As Integer

        NomSub = ""
        IDSub = 0
        Select Case cIDModulo
            Case 2, 5
                NomSub = "Compras"
                IDSub = 15
            Case 1, 3
                NomSub = "Ventas"
                IDSub = 16
            Case 6
                NomSub = "Pagos"
                IDSub = 23
            Case 4
                NomSub = "Cobros"
                IDSub = 24
            Case 7, 8, 9, 11
                NomSub = "Inventarios"
                IDSub = 26
        End Select

        sArr(0) = NomSub
        sArr(1) = IDSub
        Get_Modulo_SubMenu = sArr
    End Function

    Public Function Get_IDs_cModulos(ByVal cIdSub As Integer) As String()
        Dim IDs() As String

        IDs = {}
        Select Case cIdSub
            Case 15
                IDs = {2, 5}
            Case 16
                IDs = {1, 3}
            Case 23
                IDs = {6}
            Case 24
                IDs = {4}
            Case 26
                IDs = {7, 8, 9, 11}
        End Select

        Get_IDs_cModulos = IDs
    End Function

    Public Function Get_NomCarpeta_SubMenu(ByVal cIdSub As Integer) As String
        Dim NomCarp As String

        NomCarp = ""
        Select Case cIdSub
            Case 15
                NomCarp = "Compras"
            Case 16
                NomCarp = "Ventas"
            Case 23
                NomCarp = "Pagos"
            Case 24
                NomCarp = "Cobros"
            Case 25
                NomCarp = "Produccion"
            Case 26
                NomCarp = "Inventarios"
        End Select

        Get_NomCarpeta_SubMenu = NomCarp
    End Function

    Public Function Marcar_Documentos(ByVal mID As Integer, ByVal mStatus As Integer,
                                      mIDRubro As Integer, mConcepto As String, mFolio As Integer,
                                      mSerie As String, ByVal rfcEmpresa As String, ByVal mIDDoc As Integer) As Boolean
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String

        Dim dFechaPro = Format(Now, "yyyy-MM-dd hh:mm")

        Marcar_Documentos = False
        dFiltro = "{" & Chr(34) & "rfcempresa" & Chr(34) & ": " & Chr(34) & rfcEmpresa & Chr(34) & ", " &
                        Chr(34) & "usuario" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Correo & Chr(34) & "," &
                        Chr(34) & "pwd" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Contra & Chr(34) & "," &
                        Chr(34) & "id" & Chr(34) & ": " & Chr(34) & mID & Chr(34) & "," &
                        Chr(34) & "iddoc" & Chr(34) & ": " & Chr(34) & mIDDoc & Chr(34) & "," &
                        Chr(34) & "status" & Chr(34) & ": " & Chr(34) & mStatus & Chr(34) & "," &
                        Chr(34) & "idrubro" & Chr(34) & ": " & mIDRubro & "," &
                        Chr(34) & "concepto" & Chr(34) & ": " & Chr(34) & mConcepto & Chr(34) & "," &
                        Chr(34) & "folio" & Chr(34) & ": " & mFolio & "," &
                        Chr(34) & "serie" & Chr(34) & ": " & Chr(34) & mSerie & Chr(34) & "," &
                        Chr(34) & "fechapro" & Chr(34) & ": " & Chr(34) & dFechaPro & Chr(34) & "}"
        dMetodo = "AlmacenMarcado"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
            If jsonObject("error").ToString() = "0" Then
                Marcar_Documentos = True
            Else
                GetError_Api(CInt(jsonObject("error").ToString()))
            End If
        End If
    End Function

    Public Function Vincular_Documentos(ByVal sSuc As String, ByVal sIDAdw As Integer, ByVal sFecha As Date,
                                    ByVal sIDDoc As Integer, ByVal sNom As String, idSub As Integer, ByVal sActi As Integer, ByVal sOtro As Integer) As Boolean
        Dim sQue As String, vinculo As Boolean
        vinculo = False
        Try
            sQue = "IF @action = 1 
                BEGIN
                    IF NOT EXISTS (SELECT * FROM XMLDigAsoc WHERE sucursal=@suc AND iddocADW=@iddocadw AND iddocdig=@iddoc)
                        INSERT INTO XMLDigAsoc(idusuariocrm,fecha,nombreusercrm,sucursal,
                                 iddocADW,iddocdig,nombrearchivo,idsubmenu,esOtro)VALUES(@Iduser, @fecha, @nomuser, @suc, 
                                 @iddocadw, @iddoc, @nomarchivo, @idsub, @otro );
               END
               ELSE
                   DELETE FROM XMLDigAsoc WHERE sucursal=@suc AND iddocADW=@iddocadw AND iddocdig=@iddoc;"
            Using sCom = New SqlCommand(sQue, FC_SQL)
                sCom.Parameters.AddWithValue("@Iduser", GL_cUsuarioAPI.Iduser)
                sCom.Parameters.AddWithValue("@fecha", sFecha)
                sCom.Parameters.AddWithValue("@nomuser", GL_cUsuarioAPI.Nombreuser & " " & GL_cUsuarioAPI.Apellidop)
                sCom.Parameters.AddWithValue("@suc", sSuc)
                sCom.Parameters.AddWithValue("@iddocadw", sIDAdw)
                sCom.Parameters.AddWithValue("@iddoc", sIDDoc)
                sCom.Parameters.AddWithValue("@nomarchivo", sNom)
                sCom.Parameters.AddWithValue("@idsub", idSub)
                sCom.Parameters.AddWithValue("@otro", sOtro)
                sCom.Parameters.AddWithValue("@action", sActi)
                sCom.ExecuteNonQuery()
                vinculo = True
                Return vinculo
            End Using
        Catch ex As Exception
            MsgBox("Error del Sistema al Guardar la asociación" & vbCrLf & ex.Message, vbExclamation, "Información")
            Return vinculo
        End Try

    End Function

    Public Function Get_ConceptoBancos(ByVal dTipoBan As Integer) As String
        Dim nomCon As String
        Select Case dTipoBan
            Case 3
                nomCon = "TRASPASO ENTRE CUENTAS"
            Case 7
                nomCon = "COMPRA DE DIVISAS"
            Case 8
                nomCon = "VENTA DE DIVISAS"
            Case 10
                nomCon = "CANCELADO"
        End Select
        Get_ConceptoBancos = nomCon
    End Function
End Module
