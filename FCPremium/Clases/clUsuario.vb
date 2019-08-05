Imports System.Data.SqlClient

Public Class clUsuario
    Private _iduser As Integer
    Private _nombreuser As String
    Private _apellidop As String
    Private _apellidom As String
    Private _usuario As String
    Private _password As String
    Private _tipo As Integer
    Private _status As Integer

    Private _modper As New Collection

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

    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
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

    Public Property Modper As Collection
        Get
            Return _modper
        End Get
        Set(value As Collection)
            _modper = value
        End Set
    End Property

    Public Function login(ByVal luser As String, ByVal lpass As String) As Boolean
        Dim vQue As String
        login = False

        vQue = "SELECT idusuario,nombre,apellido_p,apellido_m,usuario,password,tipo,status 
                    FROM FCUser WHERE usuario=@user AND password=@pass"
        Using vCom = New SqlCommand(vQue, FC_Con)
            vCom.Parameters.AddWithValue("@user", luser)
            vCom.Parameters.AddWithValue("@pass", lpass)
            Using vRs = vCom.ExecuteReader()
                vRs.Read()
                If vRs.HasRows = True Then
                    _iduser = vRs("idusuario")
                    _nombreuser = vRs("nombre")
                    _apellidop = vRs("apellido_p")
                    _apellidom = vRs("apellido_m")
                    _usuario = vRs("usuario")
                    _password = vRs("password")
                    _tipo = vRs("tipo")
                    _status = vRs("status")
                    permisosModulos()
                    login = True
                End If
            End Using
        End Using
    End Function

    Private Sub permisosModulos()
        Dim vque As String, dFil As String
        Dim dModulos As clModulos

        dFil = IIf(_tipo <> tAdmin, "AND u.idusuario=@iduser", "")
        vque = "SELECT m.idmodulo,m.nombre_modulo,m.version,m.fechaactualizacion,
                    m.nombre_archivo,u.permiso FROM FCModulos m LEFT JOIN FCModUser u 
                    ON m.idmodulo=u.idmodulo WHERE m.version<>0 "
        Using vCom = New SqlCommand(vque, FC_Con)
            If _tipo <> tAdmin Then
                vCom.Parameters.AddWithValue("@iduser", _iduser)
            End If
            Using vRs = vCom.ExecuteReader()
                Do While vRs.Read()
                    dModulos = New clModulos
                    With dModulos
                        .Idmodulo = vRs("idmodulo")
                        .Nombremodulo = vRs("nombre_modulo")
                        .Version = vRs("version")
                        .FechaActualiza = vRs("fechaactualizacion")
                        .Permisouser = IIf(_tipo <> tAdmin, IIf(vRs("permiso") Is DBNull.Value, 0, vRs("permiso")), 1)
                        .Nombrearchivo = vRs("nombre_archivo")
                    End With
                    _modper.Add(dModulos)
                Loop
            End Using
        End Using
    End Sub

    Public Sub AddUser()
        Dim aQue As String, aIDU As Integer
        Dim mMod As clModulos
        If Me.Iduser = 0 Then
            aQue = "INSERT INTO FCUser(nombre,apellido_p,apellido_m,usuario,
                            password,tipo,status)VALUES(@nom,@apep,@apem,@user,@pass,@tipo,@status)"
        Else
            aQue = "UPDATE FCUser SET nombre=@nom, apellido_p=@apep, apellido_m=@apem,
                        usuario=@user, password=@pass, tipo=@tipo, status=@status
                    WHERE idusuario=@iduse"
        End If
        Using aCom = New SqlCommand(aQue, FC_Con)
            If Me.Iduser <> 0 Then
                aCom.Parameters.AddWithValue("@iduse", Me.Iduser)
            End If
            aCom.Parameters.AddWithValue("@nom", Me.Nombreuser)
            aCom.Parameters.AddWithValue("@apep", Me.Apellidop)
            aCom.Parameters.AddWithValue("@apem", Me.Apellidom)
            aCom.Parameters.AddWithValue("@user", Me.Usuario)
            aCom.Parameters.AddWithValue("@pass", Me.Password)
            aCom.Parameters.AddWithValue("@tipo", Me.Tipo)
            aCom.Parameters.AddWithValue("@status", Me.Status)
            aCom.ExecuteNonQuery()
            aIDU = getIDUser()
            If aIDU <> 0 Then
                For Each mMod In Me.Modper
                    aQue = "IF NOT EXISTS (SELECT idmodulo FROM FCModUser WHERE idusuario=@iduse AND idmodulo=@idmod)
                        BEGIN INSERT INTO FCModUser(idusuario, idmodulo, permiso)
                                VALUES(@iduse, @idmod, @permiso) END
                        ELSE BEGIN UPDATE FCModUser SET permiso =@permiso
                                WHERE idusuario = @iduse AND idmodulo = @idmod END"
                    Using gCom = New SqlCommand(aQue, FC_Con)
                        gCom.Parameters.AddWithValue("@iduse", aIDU)
                        gCom.Parameters.AddWithValue("@idmod", mMod.Idmodulo)
                        gCom.Parameters.AddWithValue("@permiso", mMod.Permisouser)
                        gCom.ExecuteNonQuery()
                    End Using
                Next
            End If

        End Using
    End Sub

    Private Function getIDUser() As Integer
        Dim vQue As String
        getIDUser = 0
        vQue = "SELECT idusuario FROM FCUser WHERE usuario=@user AND password=@pass"
        Using vCom = New SqlCommand(vQue, FC_Con)
            vCom.Parameters.AddWithValue("@user", Me.Usuario)
            vCom.Parameters.AddWithValue("@pass", Me.Password)
            Using vRs = vCom.ExecuteReader()
                vRs.Read()
                If vRs.HasRows = True Then
                    getIDUser = vRs("idusuario")
                End If
            End Using
        End Using
    End Function

End Class
