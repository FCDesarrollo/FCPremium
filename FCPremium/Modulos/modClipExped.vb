Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System.Globalization
Module modClipExped
    Public NomArc As String
    Public aRut As String
    Public fecMayor As Date
    Public barCount As Long
    Public IDEmp As Integer
    Public idCon As Integer
    Public idNom As Integer
    Public idAdw As Integer
    Public cSucursalesCRM As Collection
    Public cServicios As Collection
    Public cDocDig As Collection
    Public cModulosCRM As Collection
    Public cMenusCRM As Collection
    Public cSubMenusCRM As Collection
    Public Const G_ServerCloud As String = "cloud.dublock.com"
    Public vAgenda(1000, 10) As String
    Public cAgendas As Collection
    Public ACount As Integer
    'Variables de modulos
    Public Const ModExped_Bancos As Integer = 3
    Public Const ModExped_Activos As Integer = 11
    Public Const ModExped_Fiscales As Integer = 12
    Public Const ModExped_Empleados As Integer = 13
    Public Const ModExped_Nominas As Integer = 14
    Public Const ModExped_Gobierno As Integer = 15
    Public Const ModExped_Proveedores As Integer = 16
    Public Const ModExped_Clientes As Integer = 17
    'Variables de servivios
    Public Const SerExped_Permanente As Integer = 27
    Public Const SerCalculosActivos As Integer = 31

    Public Sub getEmpresasExpedientes(ByVal cb As ComboBox)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim cQue As String


        dt = New DataTable("Empresas")
        dt.Columns.Add("id")
        dt.Columns.Add("Nombre")

        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "SELECCIONAR EMPRESA"
        dt.Rows.Add(dr)

        GL_cUsuarioAPI.lista_empresas()

        cQue = "SELECT DISTINCT idempresacrm, empresacrm FROM CEXEmpresas"
        Using cCom = New SqlCommand(cQue, FC_Con)
            Using cRs = cCom.ExecuteReader()
                Do While cRs.Read()
                    dr = dt.NewRow
                    dr(0) = Trim(cRs("idempresacrm"))
                    dr(1) = Trim(cRs("empresacrm"))
                    dt.Rows.Add(dr)
                Loop
            End Using
        End Using

        cb.DataSource = dt
        cb.ValueMember = "id"
        cb.DisplayMember = "Nombre"
    End Sub

    Public Sub crearTablasExpedientes()
        Dim cQue As String
        Dim cpCom As SqlCommand
        cQue = "IF OBJECT_ID('zCEXTiposDocto') IS NULL
	                        BEGIN
		                        CREATE TABLE [dbo].[zCEXTiposDocto](
			                        [id] [int] IDENTITY(1,1) NOT NULL,
			                        [tipo_docto] [nvarchar](150) NULL,
                                    [id_modulo] [int] NULL,
                                    [id_serviciocrm] [int] NULL,
                                    [clave] [nvarchar](50) NULL
		                        ) ON [PRIMARY]
                        END"
        cpCom = New SqlCommand(cQue, FC_SQL)
        cpCom.ExecuteNonQuery()
        cpCom.Dispose()

        cQue = "IF OBJECT_ID('zCEXDependencias') IS NULL
	                BEGIN
		                CREATE TABLE [dbo].[zCEXDependencias](
	                    [id] [int] IDENTITY(1,1) NOT NULL,
	                    [dependencia] [varchar](150) NULL
                        ) ON [PRIMARY]
                END"
        cpCom = New SqlCommand(cQue, FC_SQL)
        cpCom.ExecuteNonQuery()
        cpCom.Dispose()


    End Sub



    Private Sub CargaExpedienteActivos(wb As Excel.Workbook, idEmp As Integer, idSer As Integer, Ejercicio As Integer)
        Dim f As Integer, Que As String
        Dim cEjercicio As Integer, mColum As Integer, tDoc As String
        Dim numExpe As Integer
        Dim e As Integer
        Dim Query As String
        Dim Fila As Integer, c As Integer, i As Integer, reg As Integer, Col As Integer
        Dim vMatriz(10000, 9)
        Dim impreso As Boolean
        Dim uF As Long
        Dim ext As String = ""
        Dim Array() As String

        'On Error GoTo Err

        'RutaSQLBan
        cEjercicio = Ejercicio
        wb.ActiveSheet.Range("B5") = Ejercicio
        c = 0
        f = 7
        ' For t = 0 To LbEmpresas.ListCount - 1
        'If LbEmpresas.Selected(t) = True Then
        With wb.ActiveSheet
            '''NOMBRE DE LA EMPRESA Y ENCABEZADOS
            'If f <> 7 Then f = f + 1
            .Cells(f, 2) = getNombreEmpresa(idEmp)
            .Cells(f, 18) = idEmp
            .Cells(f, 2).Font.Bold = True
            f = f + 1

            '''TITULO CUENTA
            .Cells(f, 2) = "Cuenta"
            .Cells(f, 2).Interior.Color = 5287936 '''COLORES DE FONDO
            .Cells(f, 2).Font.ThemeColor = Excel.XlThemeColor.xlThemeColorDark1 '''COLOR DE LETRA BLANCO
            .Cells(f, 2).Font.Bold = True '''NEGRITA
            f = f + 1

            ConEmpresaSQL(idEmp)
            Que = "SELECT * FROM zACFCedulas"
            Using Con = New SqlCommand(Que, FC_SQL)
                Using Rs = Con.ExecuteReader()
                    Do While Rs.Read()
                        .Cells(f, 2) = Trim(Rs(1))
                        .Cells(f, 18) = Trim(Rs(0))
                        '.Cells(f, 19) = LbEmpresas.List(t, 1)
                        '.Cells(f, 20) = LbEmpresas.List(t, 3)

                        '''FORMATO DE BORDES DE LOS MESES
                        For e = 3 To 15
                            .Cells(f, e).Clear
                            .Cells(f, e).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(f, e).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(f, e).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(f, e).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous

                            .Cells(f, e).Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlHairline
                            .Cells(f, e).Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = Excel.XlBorderWeight.xlHairline
                            .Cells(f, e).Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlHairline
                            .Cells(f, e).Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = Excel.XlBorderWeight.xlHairline

                            If e = 15 Then
                                .Cells(f, e).Interior.Color = &HE0E0E0
                            End If
                        Next e

                        Dim indice As String, x As Integer, numExp As Integer
                        x = 1

                        For e = 3 To 15
                            numExp = 0
                            'Que = "select count(*) as numExpe from zClipExped where ejercicio = " & cEjercicio & " and tipo = " & .Cells(f, 18).value & " and periodo = " & x & " And idmodulo=" & ModExped_Activos & ""
                            Que = "SELECT fecha, ruta, ruta_original, tipo, ejercicio, periodo, iddigital FROM zClipExped WHERE tipo = " & Rs(0) & " and idmodulo = " & ModExped_Activos & " and numero1 = " & SerCalculosActivos & " and not iddigital is null and periodo = " & x & " And Ejercicio = " & cEjercicio & " ORDER BY fecha DESC"
                            Using Con2 = New SqlCommand(Que, FC_SQL)
                                Using Rs1 = Con2.ExecuteReader()
                                    Do While Rs1.Read
                                        Array = Rs1("ruta").Split(".")
                                        ext = Array(Array.Count - 1)
                                        vMatriz(c, 1) = Rs(0)
                                        vMatriz(c, 2) = Trim(Rs(1))
                                        vMatriz(c, 3) = Rs1("fecha")
                                        vMatriz(c, 4) = Rs1("ruta_original") & "." & ext
                                        'vMatriz(c, 5) = Rs("ruta_cloud")
                                        'vMatriz(c, 6) = Rs("idtipodocto")
                                        vMatriz(c, 5) = getURLCloud(Rs1("iddigital"))
                                        vMatriz(c, 6) = Rs1("tipo")
                                        vMatriz(c, 7) = Rs1("ejercicio")
                                        vMatriz(c, 8) = Rs1("periodo")
                                        vMatriz(c, 9) = False

                                        c = c + 1

                                        numExp = numExp + 1
                                    Loop

                                    If numExp <> 0 Then
                                        .Cells(f, e) = "A" & numExp
                                        SuperIndice(wb, .Cells(f, e).value, f, e)
                                    End If

                                    x = x + 1
                                End Using
                            End Using
                        Next e
                        f = f + 1
                    Loop
                    '.HPageBreaks.Add(.Cells(f, 1).value)
                    'f = f + 1
                End Using
            End Using

            reg = c
            uF = f - 1
            f = f + 2
            For i = 9 To uF
                impreso = False
                For c = 0 To reg - 1
                    If vMatriz(c, 1) = .cells(i, 18).value And vMatriz(c, 9) = False Then
                        For x As Integer = 1 To 12
                            Col = x + 2
                            If CInt(vMatriz(c, 8)) = x Then
                                '.cells(i, Col) = "R"
                                If impreso = False Then
                                    f = f + 1
                                    .Cells(f, 1) = "'" & .Cells(i, 1).value
                                    .Cells(f, 2) = .Cells(i, 2).value
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & f)
                                    .Hyperlinks.Add(Anchor:= .Range("B" & f), Address:="", SubAddress:=
                                        "Hoja1!B" & i)
                                    f = f + 1
                                    impreso = True
                                Else
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & f)
                                End If
                                .Cells(f, 2) = vMatriz(c, 3)
                                .Cells(f, 3) = vMatriz(c, 4)
                                '.Cells(Fila, 4) = "(" & .Cells(5, Col).value & ")"
                                .Hyperlinks.Add(Anchor:= .Range("C" & f), Address:=vMatriz(c, 5))
                                vMatriz(c, 9) = True
                                f = f + 1
                                Exit For
                            End If
                        Next
                    End If
                Next
            Next

            .range("R1:R" & f).Clear
        End With

        FormatoHoja(wb, idSer)

        NomArc = Obtener_RFC(idEmp) & "_" & Ejercicio & "_" & Trim(getCodServicio(idSer))
    End Sub

    Public Sub SuperIndice(wb As Excel.Workbook, indice As String, Fila As Integer, Columna As Integer)
        With wb.ActiveSheet.Cells(Fila, Columna).Characters(start:=1, Length:=1).Font
            .Name = "Calibri"
            .FontStyle = "Normal"
            .Size = 11
            .Strikethrough = False
            .Superscript = False
            .Subscript = False
            .OutlineFont = False
            .Shadow = False
            .Underline = Excel.XlUnderlineStyle.xlUnderlineStyleNone
            .ThemeColor = Excel.XlThemeColor.xlThemeColorLight1
            .TintAndShade = 0
            .ThemeFont = Excel.XlThemeFont.xlThemeFontMinor
        End With
        With wb.ActiveSheet.Cells(Fila, Columna).Characters(start:=2, Length:=1).Font
            .Name = "Calibri"
            .FontStyle = "Normal"
            .Size = 11
            .Strikethrough = False
            .Superscript = True
            .Subscript = False
            .OutlineFont = False
            .Shadow = False
            .Underline = Excel.XlUnderlineStyle.xlUnderlineStyleNone
            .ThemeColor = Excel.XlThemeColor.xlThemeColorLight1
            .TintAndShade = 0
            .ThemeFont = Excel.XlThemeFont.xlThemeFontMinor
        End With
    End Sub

    Public Function SoloLetras(cadena As String) As Boolean
        Dim ch As Char
        Dim resp As Boolean
        resp = True
        For Each ch In cadena
            If IsNumeric(ch) Then
                resp = False
                Exit For
            End If
        Next
        SoloLetras = resp
    End Function

    Private Sub getDocumentosCRM(ByVal eID As Integer, ByVal eEjercicio As Integer)
        Dim dMetodo As String, dFiltro As String = ""
        Dim jsonMod As String, cTodos As String, doc As Dictionary(Of String, String)
        Dim dDigAsoc As New Dictionary(Of Integer, Integer)

        cDocDig = New Collection

        cTodos = "true"
        dFiltro = "{""Correo"":""" & GL_cUsuarioAPI.Correo & """, ""Contra"":""" &
                    GL_cUsuarioAPI.Contra & """, ""Idempresa"":" & eID & ", ""All"":""" & cTodos & """}"
        dMetodo = "documentosdigitales"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod <> "false" Then
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                For Each Row In jsonObject("documentos")
                    If eEjercicio = 0 Then
                        doc = New Dictionary(Of String, String)
                        doc("Id") = Row("id")
                        doc("Fechadocto") = Row("fechadocto")
                        doc("Codigodocumento") = Row("codigodocumento")
                        doc("Documento") = Row("documento")
                        doc("Download") = Row("download")
                        cDocDig.Add(doc)
                    Else
                        If CInt(Year(Row("fechadocto"))) = eEjercicio Then
                            doc = New Dictionary(Of String, String)
                            doc("Id") = Row("id")
                            doc("Fechadocto") = Row("fechadocto")
                            doc("Codigodocumento") = Row("codigodocumento")
                            doc("Documento") = Row("documento")
                            doc("Download") = Row("download")
                            cDocDig.Add(doc)
                        End If
                    End If
                Next
            End If
        End If
        dDigAsoc = Nothing
    End Sub

    Public Function getPendientesSer(idMod As Integer, idSer As Integer) As Integer
        Dim p As Integer
        Dim Que As String
        p = 0
        If idMod = ModExped_Fiscales Then 'expedientes fiscales
            If idSer = SerExped_Permanente Then
                Que = "SELECT count(e.id) AS pendientes FROM zClipExped e WHERE e.idmodulo =" & idMod & " and idcuenta = " & getIDTax(Obtener_RFC(IDEmp)) & " and periodo = 0 and e.procesado = 0"
            Else
                Que = "SELECT count(e.id) AS pendientes FROM zClipExped e WHERE e.idmodulo =" & idMod & " and idcuenta = " & getIDTax(Obtener_RFC(IDEmp)) & " and periodo <> 0 and e.procesado = 0"
            End If
        ElseIf idMod = ModExped_Activos Then
            If idSer = SerCalculosActivos Then
                Que = "SELECT count(id) AS pendientes FROM zClipExped WHERE idmodulo = " & idMod & " and procesado = 0 and numero1 = " & SerCalculosActivos
            Else
                Que = "SELECT count(id) AS pendientes FROM zClipExped WHERE idmodulo = " & idMod & " and procesado = 0 and (numero1 <> " & SerCalculosActivos & " or numero1 is null)"
            End If
        Else
            Que = "SELECT count(e.id) AS pendientes FROM zClipExped e WHERE e.idmodulo =" & idMod & " and e.procesado = 0"
        End If
        Using Con = New SqlCommand(Que, FC_SQL)
            Using Rs = Con.ExecuteReader()
                If Rs.HasRows Then
                    Rs.Read()
                    p = Rs("pendientes")
                End If
            End Using
        End Using
        getPendientesSer = p
    End Function

    Public Sub imprimeEncabezado(wb As Excel.Workbook, idEmp As Integer, idSer As Integer, idMod As Integer, Optional Ejercicio As Integer = 0)
        Dim Fila As Integer, ColIni As Integer, ColFin As Integer
        Dim Query As String, EjerIni As Integer, EjerFin As Integer

        barCount = 250
        frmGeneraDoctos.pr.Value = barCount
        frmGeneraDoctos.pr.Refresh()

        Fila = 5
        With wb.ActiveSheet
            If idMod = ModExped_Empleados Then 'Empleados
                ColIni = 6
                InsertaLogoEmp(wb, idEmp, .range("B1"))
                .Cells(1, 5) = UCase(getNombreEmpresa(idEmp))
                .Cells(2, 5) = getNombreServicio(idSer)
                .Cells(Fila, 1) = "ID"
                .Cells(Fila, 2) = "Codigo"
                .Cells(Fila, 3) = "NSS"
                .Cells(Fila, 4) = "RFC"
                .Cells(Fila, 5) = "Nombre"
                .Range("B" & Fila).ColumnWidth = 7
                .Range("C" & Fila).ColumnWidth = 12
                .Range("D" & Fila).ColumnWidth = 16
                .Range("E" & Fila).ColumnWidth = 35

            ElseIf idMod = ModExped_Nominas Then 'Periodos
                ColIni = 6
                InsertaLogoEmp(wb, idEmp, .range("B1"))
                .Cells(1, 3) = UCase(getNombreEmpresa(idEmp))
                .Cells(2, 3) = getNombreServicio(idSer)
                .Cells(Fila, 1) = "ID"
                .Cells(Fila, 2) = "Periodo"
                .Range("B" & Fila).ColumnWidth = 15
                .Range("E" & Fila).ColumnWidth = 35

            ElseIf idMod = ModExped_Activos Then 'Activos Fijos
                If idSer = SerCalculosActivos Then
                    InsertaLogoEmp(wb, idEmp, .range("B1"))
                    .Cells(1, 3) = UCase(getNombreEmpresa(idEmp))
                    .Cells(2, 3) = getNombreServicio(idSer)
                    .Cells(Fila, 2) = Ejercicio
                    .Cells(Fila, 3) = "Ene"
                    .Cells(Fila, 4) = "Feb"
                    .Cells(Fila, 5) = "Mar"
                    .Cells(Fila, 6) = "Abr"
                    .Cells(Fila, 7) = "May"
                    .Cells(Fila, 8) = "Jun"
                    .Cells(Fila, 9) = "Jul"
                    .Cells(Fila, 10) = "Ago"
                    .Cells(Fila, 11) = "Sep"
                    .Cells(Fila, 12) = "Oct"
                    .Cells(Fila, 13) = "Nov"
                    .Cells(Fila, 14) = "Dic"
                    .Range("B" & Fila).ColumnWidth = 30
                    .Range("C" & Fila & ":O" & Fila).ColumnWidth = 7
                    .Range("B5:O5").HorizontalAlignment = Excel.Constants.xlCenter

                    wb.Application.ScreenUpdating = False
                    .Columns("A:A").EntireColumn.Hidden = True
                    .Range("B5").Interior.Pattern = Excel.Constants.xlSolid
                    .Range("B5").Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorLight2
                    .Range("B5").Interior.TintAndShade = 0.399975585192419
                    wb.Application.ScreenUpdating = True
                    Exit Sub
                Else
                    ColIni = 7
                    InsertaLogoEmp(wb, idEmp, .range("B1"))
                    .Cells(1, 4) = UCase(getNombreEmpresa(idEmp))
                    .Cells(2, 4) = getNombreServicio(idSer)
                    .cells(3, 4) = "Por Activo"
                    .cells(4, 4) = "Al " & Now
                    .Cells(Fila, 1) = "ID"
                    .Cells(Fila, 2) = "Tipo Activo"
                    .Cells(Fila, 3) = "Fecha Adq"
                    .Cells(Fila, 4) = "MOI"
                    .Cells(Fila, 5) = "Codigo"
                    .Cells(Fila, 6) = "Activo"
                    .Range("B" & Fila).ColumnWidth = 25
                    .Range("C" & Fila).ColumnWidth = 12
                    .Range("D" & Fila).ColumnWidth = 12
                    .Range("E" & Fila).ColumnWidth = 12
                    .Range("F" & Fila).ColumnWidth = 70
                End If

            ElseIf idMod = ModExped_Gobierno Then
                ColIni = 7
                InsertaLogoEmp(wb, idEmp, .range("B1"))
                .Cells(1, 3) = UCase(getNombreEmpresa(idEmp))
                .Cells(2, 3) = getNombreServicio(idSer)
                .Cells(3, 3) = "Por Dependencia"
                .cells(4, 3) = "Al " & Now
                .cells(Fila, 2) = "Dependencia"
                .Range("B" & Fila).ColumnWidth = 35

            ElseIf idMod = ModExped_Proveedores Then
                ColIni = 6
                InsertaLogoEmp(wb, idEmp, .range("B1"))
                .Cells(1, 3) = UCase(getNombreEmpresa(idEmp))
                .Cells(2, 3) = getNombreServicio(idSer)
                .Cells(3, 3) = "Por Proveedor"
                .cells(4, 3) = "Al " & Now
                .cells(Fila, 2) = "RFC"
                .cells(Fila, 3) = "Proveedor"
                .Range("B" & Fila).ColumnWidth = 30
                .Range("C" & Fila).ColumnWidth = 35

            ElseIf idMod = ModExped_Clientes Then
                ColIni = 6
                InsertaLogoEmp(wb, idEmp, .range("B1"))
                .Cells(1, 3) = UCase(getNombreEmpresa(idEmp))
                .Cells(2, 3) = getNombreServicio(idSer)
                .Cells(3, 3) = "Por Cliente"
                .cells(4, 3) = "Al " & Now
                .cells(Fila, 2) = "RFC"
                .cells(Fila, 3) = "Cliente"
                .Range("B" & Fila).ColumnWidth = 30
                .Range("C" & Fila).ColumnWidth = 35

            ElseIf idMod = ModExped_Bancos Then 'Bancos
                InsertaLogoEmp(wb, idEmp, .range("B1"))
                .Cells(1, 3) = UCase(getNombreEmpresa(idEmp))
                .Cells(1, 14) = getNombreServicio(idSer)
                '.Cells(1, 14) = "Expediente de Bancos"
                .Cells(2, 3) = "Expediente de Bancos a 12 Meses"
                .Cells(Fila, 2) = Ejercicio
                .Cells(Fila, 3) = "Ene"
                .Cells(Fila, 4) = "Feb"
                .Cells(Fila, 5) = "Mar"
                .Cells(Fila, 6) = "Abr"
                .Cells(Fila, 7) = "May"
                .Cells(Fila, 8) = "Jun"
                .Cells(Fila, 9) = "Jul"
                .Cells(Fila, 10) = "Ago"
                .Cells(Fila, 11) = "Sep"
                .Cells(Fila, 12) = "Oct"
                .Cells(Fila, 13) = "Nov"
                .Cells(Fila, 14) = "Dic"
                .Cells(Fila, 15) = "Fijo"
                .Range("B" & Fila).ColumnWidth = 30
                .Range("C" & Fila & ":O" & Fila).ColumnWidth = 7
                .Range("B5:O5").HorizontalAlignment = Excel.Constants.xlCenter

                wb.Application.ScreenUpdating = False
                .Columns("A:A").EntireColumn.Hidden = True
                .Range("J1:O1").Merge
                .Range("J1:O1").HorizontalAlignment = Excel.Constants.xlCenter
                .Range("J1:O1").Interior.Pattern = Excel.Constants.xlSolid
                .Range("J1:O1").Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorLight1
                .Range("J1:O1").Interior.TintAndShade = 0.599993896298105

                .Range("J2:O2").Merge
                .Range("J2:O2").Interior.Pattern = Excel.Constants.xlSolid
                .Range("J2:O2").Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorLight2
                .Range("J2:O2").Interior.TintAndShade = 0.599993896298105

                .Range("B5").Interior.Pattern = Excel.Constants.xlSolid
                .Range("B5").Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorLight2
                .Range("B5").Interior.TintAndShade = 0.399975585192419
                wb.Application.ScreenUpdating = True

                Exit Sub

            ElseIf idMod = ModExped_Fiscales Then 'TaxFile Expedientes Fiscales
                If idSer = SerExped_Permanente Then
                    InsertaLogoEmp(wb, idEmp, .range("B2"))
                    .Cells(2, 3) = UCase(getNombreEmpresa(idEmp))
                    .Cells(3, 3) = "Cedula de Integración del Expediente Permanente"
                    .cells(4, 2) = Trim(Obtener_RFC(idEmp))
                    EjerIni = CInt("20" & Right(Left(Left(.Cells(4, 2).Value, 9), 5), 2))
                    'EjerIni = CInt("20" & Right(Left(.cells(4, 2).value, 9), 2))
                    ColIni = 3
                    EjerFin = EjerIni
                    Do While EjerFin <= Year(Now)
                        .cells(4, ColIni) = EjerFin
                        ColIni = ColIni + 1
                        EjerFin = EjerFin + 1
                    Loop
                    .cells(1, ColIni - 1) = "Claves: N=Nomal, C=Complementaria, SuperIndice=Numero de archivos"
                    .range(Col_Letter(ColIni - 1) & "1").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .range(Col_Letter(3) & "4:" & Col_Letter(ColIni) & "4").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("B4").ColumnWidth = 35
                    .Range("C4:" & Col_Letter(ColIni) & "4").ColumnWidth = 8
                    .Range("B4:" & Col_Letter(ColIni) & "4").HorizontalAlignment = Excel.Constants.xlCenter

                    wb.Application.ScreenUpdating = False
                    .Columns("A:A").EntireColumn.Hidden = True
                    .Range("B4").Interior.Pattern = Excel.Constants.xlSolid
                    .Range("B4").Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorLight2
                    .Range("B4").Interior.TintAndShade = 0.399975585192419
                    wb.Application.ScreenUpdating = True

                Else
                    InsertaLogoEmp(wb, idEmp, .range("B3"))
                    .Cells(3, 3) = UCase(getNombreEmpresa(idEmp))
                    .Cells(4, 3) = "Cedula de Integración del Cumplimiento de Obligaciones Fiscales"
                    .cells(2, 15) = "Claves: N=Nomal, C=Complementaria, P=Pago, D=Devolucion, C=Compensacion, R=Requerimiento, M=Multa, A=Recurso Administrativo, J=Juicio Contencioso"
                    .range("O2").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                    .range("O2").Font.Size = 8
                    .cells(3, 15) = "Ultima fecha de modificacion"
                    .cells(4, 15) = Now()
                    .range("L3:O3").Merge
                    .range("L4:O4").Merge
                    .range("L3").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .range("L4").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

                    .range("B2:O2").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous

                    .cells(1, 3) = "P"
                    .range("C1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    '.range("C1").Font.Color = 255
                    .cells(1, 4) = "Terminado"

                    .cells(1, 5) = "P"
                    .range("E1").Font.Color = -16776961
                    .range("E1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .cells(1, 6) = "Iniciado no terminado"

                    .cells(1, 9) = "Superindice=Numero de archivos"
                    .cells(1, 13) = "Obligacion vencida no cumplida"
                    .range("A1:O1").Font.Size = 8
                    '.range("E1").Interior.Color = 255
                    '.range("C1").Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorLight1
                    .range("L1").Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent2
                    .range("L1").Interior.TintAndShade = 0.599993896298105
                    .range("L1").Interior.PatternTintAndShade = 0

                    .Cells(5, 2) = "Ejercicio " & Ejercicio
                    .Cells(5, 3) = "ENE"
                    .Cells(5, 4) = "FEB"
                    .Cells(5, 5) = "MAR"
                    .Cells(5, 6) = "ABR"
                    .Cells(5, 7) = "MAY"
                    .Cells(5, 8) = "JUN"
                    .Cells(5, 9) = "JUL"
                    .Cells(5, 10) = "AGO"
                    .Cells(5, 11) = "SEP"
                    .Cells(5, 12) = "OCT"
                    .Cells(5, 13) = "NOV"
                    .Cells(5, 14) = "DIC"
                    .Cells(5, 15) = "ANUAL"
                    .Range("B" & Fila).ColumnWidth = 35
                    .Range("C" & Fila & ":O" & Fila).ColumnWidth = 7
                    .Range("B5:O5").HorizontalAlignment = Excel.Constants.xlCenter

                    wb.Application.ScreenUpdating = False
                    .Columns("A:A").EntireColumn.Hidden = True
                    .Range("B5").Interior.Pattern = Excel.Constants.xlSolid
                    .Range("B5").Interior.ThemeColor = Excel.XlThemeColor.xlThemeColorLight2
                    .Range("B5").Interior.TintAndShade = 0.399975585192419
                    wb.Application.ScreenUpdating = True
                End If
                Exit Sub

                End If

            ColFin = ColIni
            ConEmpresaSQL(idEmp)
            'Query = "SELECT * FROM XMLDigTiposDoctoConfig WHERE id_serviciocrm = " & idSer
            Query = "SELECT * FROM zCEXTiposDocto WHERE id_serviciocrm = " & idSer
            Using dCom = New SqlCommand(Query, FC_SQL)
                Using aCr = dCom.ExecuteReader()
                    Do While aCr.Read()
                        .Cells(1, ColFin) = aCr("id")
                        .Cells(Fila, ColFin) = Trim(aCr("tipo_docto"))
                        ColFin = ColFin + 1
                    Loop
                End Using
            End Using
        End With

        'Formato encabezado
        wb.Application.ScreenUpdating = False
        wb.Activate()
        With wb.ActiveSheet
            .Columns("A:A").EntireColumn.Hidden = True
            With .Range(Col_Letter(ColIni) & Fila & ":" & Col_Letter(ColFin - 1) & Fila)
                .HorizontalAlignment = Excel.Constants.xlCenter ' xlCenter
                .VerticalAlignment = Excel.Constants.xlBottom 'xlBottom
                .WrapText = False
                .Orientation = 90
                .AddIndent = False
                .IndentLevel = 0
                .ShrinkToFit = False
                .ReadingOrder = Excel.Constants.xlContext ' xlContext
                .MergeCells = False
            End With
            .Range(Col_Letter(ColIni) & Fila & ":" & Col_Letter(ColFin - 1) & Fila).ColumnWidth = 4
            With .Range(Col_Letter(ColIni) & Fila & ":" & Col_Letter(ColFin - 1) & Fila).Font
                .Color = -4165632
                .TintAndShade = 0
                .Bold = True
            End With
            'wb.ActiveSheet.Range("A" & Fila & ":" & Col_Letter(ColFin - 1) & Fila).Select
            .Range("A" & Fila & ":" & Col_Letter(ColFin - 1) & Fila).Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone ' xlNone
            .Range("A" & Fila & ":" & Col_Letter(ColFin - 1) & Fila).Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone 'xlNone
            .Range("A" & Fila & ":" & Col_Letter(ColFin - 1) & Fila).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlLineStyleNone 'xlNone
            .Range("A" & Fila & ":" & Col_Letter(ColFin - 1) & Fila).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlLineStyleNone 'xlNone
            With .Range("A" & Fila & ":" & Col_Letter(ColFin - 1) & Fila).Borders(Excel.XlBordersIndex.xlEdgeBottom)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .ColorIndex = 0
                .TintAndShade = 0
                .Weight = Excel.XlBorderWeight.xlThin
            End With
            .Range("A" & Fila & ":" & Col_Letter(ColFin - 1) & Fila).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Range("A" & Fila & ":" & Col_Letter(ColFin - 1) & Fila).Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Range("A" & Fila & ":" & Col_Letter(ColFin - 1) & Fila).Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlLineStyleNone
        End With
        wb.Application.ScreenUpdating = True
    End Sub

    Public Sub InsertaLogoEmp(wb As Excel.Workbook, idEmp As Integer, Rango As Excel.Range)
        Dim dMetodo As String, dFiltro As String = "", jsonMod As String, download As String

        dFiltro = "{" & Chr(34) & "rfc" & Chr(34) & ": " & Chr(34) & Obtener_RFC(idEmp) & Chr(34) & ", " &
                    Chr(34) & "usuario" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Correo & Chr(34) & "," &
                    Chr(34) & "pwd" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.EncryptedContra & Chr(34) & "}"
        dMetodo = "getLogosEmpresa"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
        If CInt(jsonObject("error")) = 0 Then
            If Not jsonObject("logos") Is Nothing Then
                download = jsonObject("logos")(0)("download")
                download = download & "/download"
                With Rango.Parent
                    .Pictures.Insert(download)
                    .Shapes(.Shapes.Count).Left = Rango.Left
                    .Shapes(.Shapes.Count).Top = Rango.Top
                End With
            End If
        End If
    End Sub

    Public Function Col_Letter(lngCol As Integer) As String
        Col_Letter = ""
        Select Case lngCol
            Case Is = 1
                Col_Letter = "A"
            Case Is = 2
                Col_Letter = "B"
            Case Is = 3
                Col_Letter = "C"
            Case Is = 4
                Col_Letter = "D"
            Case Is = 5
                Col_Letter = "E"
            Case Is = 6
                Col_Letter = "F"
            Case Is = 7
                Col_Letter = "G"
            Case Is = 8
                Col_Letter = "H"
            Case Is = 9
                Col_Letter = "I"
            Case Is = 10
                Col_Letter = "J"
            Case Is = 11
                Col_Letter = "K"
            Case Is = 12
                Col_Letter = "L"
            Case Is = 13
                Col_Letter = "M"
            Case Is = 14
                Col_Letter = "N"
            Case Is = 15
                Col_Letter = "O"
            Case Is = 16
                Col_Letter = "P"
            Case Is = 17
                Col_Letter = "Q"
            Case Is = 18
                Col_Letter = "R"
            Case Is = 19
                Col_Letter = "S"
            Case Is = 20
                Col_Letter = "T"
            Case Is = 21
                Col_Letter = "U"
            Case Is = 22
                Col_Letter = "V"
            Case Is = 23
                Col_Letter = "W"
            Case Is = 24
                Col_Letter = "X"
            Case Is = 25
                Col_Letter = "Y"
            Case Is = 26
                Col_Letter = "Z"
        End Select
        'Dim vArr
        'vArr = Split(Cells(1, lngCol).Address(True, False), "$")
        'Col_Letter = vArr(0)
    End Function

    Public Sub imprimeDatosRelacionados(wb As Excel.Workbook, idEmp As Integer, idSer As Integer, idMod As Integer, Optional Ejercicio As Integer = 0, Optional idSuc As Integer = 0)

        getDocumentosCRM(idEmp, Ejercicio)

        Select Case idMod
            Case Is = ModExped_Empleados 'Empleados
                imprimeEmpleados(wb, idEmp, idSer)
            Case Is = ModExped_Nominas 'Periodos
                imprimeNomina(wb, idEmp, idSer)
            Case Is = ModExped_Activos 'Activos Fijos
                If idSer = SerCalculosActivos Then
                    CargaExpedienteActivos(wb, idEmp, idSer, Ejercicio)
                Else
                    imprimeActivosFijos(wb, idEmp, idSer, idMod)
                End If
            Case Is = ModExped_Bancos 'Bancos
                ImprimeBancos(wb, idEmp, idSer, Ejercicio)
            Case Is = ModExped_Fiscales 'Expediente Fiscal
                ImprimeExpedienteFiscal(wb, idEmp, idSer, Ejercicio, idMod)
            Case Is = ModExped_Gobierno 'Expediente Gobierno
                ImprimeDependenciasGob(wb, idEmp, idSer)
            Case Is = ModExped_Proveedores  'Expediente de Proveedores Credito
                ImprimeExpedienteProveedores(wb, idEmp, idSer, idSuc)
            Case Is = ModExped_Clientes  'Expediente de Clientes Credito
                ImprimeExpedienteClientes(wb, idEmp, idSer, idSuc)
        End Select
    End Sub

    Public Function getIDTax(sRFC As String) As Integer
        Dim ID As Integer = 0
        Using Con = New SqlCommand("SELECT Id FROM TaxRFC WHERE RFC = '" & sRFC & "'", FC_Con)
            Using Rs = Con.ExecuteReader()
                If Rs.HasRows Then
                    Rs.Read()
                    ID = Rs("Id")
                End If
            End Using
        End Using
        getIDTax = ID
    End Function

    Public Sub ImprimeExpedienteFiscal(wb As Excel.Workbook, idEmp As Integer, idSer As Integer, Ejercicio As Integer, idMod As Integer)
        Dim idTAXRFC As Integer
        idTAXRFC = getIDTax(Obtener_RFC(idEmp))
        If idTAXRFC <> 0 Then
            barCount = 500
            frmGeneraDoctos.pr.Value = barCount
            frmGeneraDoctos.pr.Refresh()
            FormatoHoja(wb, idSer)
            If idSer = SerExped_Permanente Then
                Ejercicio = 0 'Todos los ejercicios
                CalculaPendientes(idTAXRFC, Now, Ejercicio, 0)
                EjecutaExpediente(wb, idTAXRFC, idSer, idMod)
                NomArc = Obtener_RFC(idEmp) & "_" & Year(Now) & "_" & Trim(getCodServicio(idSer))
            Else
                CalculaPendientes(idTAXRFC, Now, Ejercicio, 0)
                EjecutaCumplimiento(wb, idTAXRFC, Ejercicio, idMod, idSer)
                MarcaPeriodicasPendientes(wb)
                NomArc = Obtener_RFC(idEmp) & "_" & Ejercicio & "_" & Trim(getCodServicio(idSer))
            End If
        Else
            MsgBox("Error en la configuracion del modulo TaxFile,", vbInformation)
        End If
    End Sub

    Public Sub ImprimeBancos(wb As Excel.Workbook, idEmp As Integer, idSer As Integer, Ejercicio As Integer)
        Dim Query As String
        Dim Fila As Integer, c As Integer, i As Integer, reg As Integer, Col As Integer
        Dim vMatriz(10000, 9)
        Dim impreso As Boolean
        Dim uF As Long
        Dim ext As String = ""
        Dim Array() As String

        barCount = 500
        frmGeneraDoctos.pr.Value = barCount
        frmGeneraDoctos.pr.Refresh()

        FormatoHoja(wb, idSer)

        c = 0
        Fila = 8
        With wb.ActiveSheet
            ConEmpresaSQL(idEmp)

            'TITULO CUENTA
            .Cells(7, 2) = "Cuenta"
            .Cells(7, 2).Interior.Color = 5287936
            .Cells(7, 2).Font.ThemeColor = Excel.XlThemeColor.xlThemeColorDark1
            .Cells(7, 2).Font.Bold = True

            Query = "SELECT Id, Codigo, Nombre FROM CuentasCheques"
            Using cCom = New SqlCommand(Query, FC_SQL)
                Using aCr = cCom.ExecuteReader()
                    Do While aCr.Read()
                        .Cells(Fila, 1) = aCr("Id")
                        .Cells(Fila, 2) = Trim(aCr("Nombre"))

                        For e As Integer = 3 To 15
                            .Cells(Fila, e).Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(Fila, e).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(Fila, e).Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(Fila, e).Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
                            .Cells(Fila, e).Borders(Excel.XlBordersIndex.xlEdgeTop).Weight = Excel.XlBorderWeight.xlHairline
                            .Cells(Fila, e).Borders(Excel.XlBordersIndex.xlEdgeRight).Weight = Excel.XlBorderWeight.xlHairline
                            .Cells(Fila, e).Borders(Excel.XlBordersIndex.xlEdgeBottom).Weight = Excel.XlBorderWeight.xlHairline
                            .Cells(Fila, e).Borders(Excel.XlBordersIndex.xlEdgeLeft).Weight = Excel.XlBorderWeight.xlHairline
                            If e = 15 Then
                                .Cells(Fila, e).Interior.Color = &HE0E0E0
                            End If
                        Next

                        'Query = "SELECT fecha, nombrearchivo, ruta_cloud, idtipodocto, ejercicio, periodo FROM XMLDigAsocExped WHERE idelemento = " & aCr("Id") & " and idservicio = " & idSer & " And Ejercicio = " & Ejercicio & " ORDER BY fecha DESC"
                        Query = "SELECT fecha, ruta, ruta_original, tipo, ejercicio, periodo, iddigital FROM zClipExped WHERE idcuenta = " & aCr("Id") & " and idmodulo = 3 and not iddigital is null And Ejercicio = " & Ejercicio & " ORDER BY fecha DESC"
                        Using cCom2 = New SqlCommand(Query, FC_SQL)
                            Using Rs = cCom2.ExecuteReader()
                                Do While Rs.Read()
                                    Array = Rs("ruta").Split(".")
                                    ext = Array(Array.Count - 1)
                                    vMatriz(c, 1) = aCr("Id")
                                    vMatriz(c, 2) = Trim(aCr("Nombre"))
                                    vMatriz(c, 3) = Rs("fecha")
                                    vMatriz(c, 4) = Rs("ruta_original") & "." & ext
                                    'vMatriz(c, 5) = Rs("ruta_cloud")
                                    'vMatriz(c, 6) = Rs("idtipodocto")
                                    vMatriz(c, 5) = getURLCloud(Rs("iddigital"))
                                    vMatriz(c, 6) = Rs("tipo")
                                    vMatriz(c, 7) = Rs("ejercicio")
                                    vMatriz(c, 8) = Rs("periodo")
                                    vMatriz(c, 9) = False

                                    If fecMayor < Rs("fecha") Then
                                        fecMayor = Rs("fecha")
                                    End If
                                    c = c + 1
                                Loop
                            End Using
                        End Using
                        Fila = Fila + 1
                    Loop
                End Using
            End Using


            reg = c
            uF = Fila - 1
            Fila = Fila + 2
            For i = 8 To uF
                impreso = False
                For c = 0 To reg - 1
                    If vMatriz(c, 1) = .cells(i, 1).value And vMatriz(c, 9) = False Then
                        For x As Integer = 1 To 12
                            Col = x + 2
                            If CInt(vMatriz(c, 8)) = x Then
                                .cells(i, Col) = "R"
                                If impreso = False Then
                                    Fila = Fila + 2
                                    .Cells(Fila, 1) = "'" & .Cells(i, 1).value
                                    .Cells(Fila, 2) = .Cells(i, 2).value
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & Fila, TextToDisplay:="R")
                                    .Hyperlinks.Add(Anchor:= .Range("B" & Fila), Address:="", SubAddress:=
                                        "Hoja1!B" & i)
                                    Fila = Fila + 1
                                    impreso = True
                                Else
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & Fila, TextToDisplay:="R")
                                End If
                                .Cells(Fila, 2) = vMatriz(c, 3)
                                .Cells(Fila, 3) = vMatriz(c, 4)
                                '.Cells(Fila, 4) = "(" & .Cells(5, Col).value & ")"
                                .Hyperlinks.Add(Anchor:= .Range("C" & Fila), Address:=vMatriz(c, 5))
                                vMatriz(c, 9) = True
                                Fila = Fila + 1
                                Exit For
                            End If
                        Next
                    End If
                Next
            Next

        End With

        NomArc = Obtener_RFC(idEmp) & "_" & Ejercicio & "_" & Trim(getCodServicio(idSer))

    End Sub

    Public Function getURLCloud(idDig As Integer) As String
        Dim s As Dictionary(Of String, String)
        Dim URL As String = ""
        For Each s In cDocDig
            If CInt(s("Id")) = idDig Then
                URL = s("Download")
                Exit For
            End If
        Next
        getURLCloud = URL
    End Function
    Public Function getNombreServicio(idSer As Integer) As String
        Dim s As clServicios
        Dim sev As String = ""
        For Each s In cServicios
            If s.Idservicio = idSer Then
                sev = s.Servicio
                Exit For
            End If
        Next
        getNombreServicio = sev
    End Function
    Public Function getSucursalCRM(idSuc As Long) As String
        Dim s As clSucursalesCRM
        Dim suc As String = ""
        For Each s In cSucursalesCRM
            If s.IDSucursal = idSuc Then
                suc = s.Sucursal
                Exit For
            End If
        Next
        getSucursalCRM = suc
    End Function
    Public Function getIDSucCRM(Suc As String) As Integer
        Dim s As clSucursalesCRM
        Dim idsuc As Integer
        For Each s In cSucursalesCRM
            If s.Sucursal = Suc Then
                idsuc = s.IDSucursal
                Exit For
            End If
        Next
        getIDSucCRM = idsuc
    End Function
    Public Function getEstatusServicio(idSer As Integer) As String
        Dim s As clServicios
        Dim estatus As String = ""
        For Each s In cServicios
            If s.Idservicio = idSer Then
                estatus = IIf(s.Status = True, "Activo", "Inactivo")
                Exit For
            End If
        Next
        getEstatusServicio = estatus
    End Function

    Public Function getCodServicio(idSer As Integer) As String
        Dim s As clServicios
        Dim sev As String = ""
        For Each s In cServicios
            If s.Idservicio = idSer Then
                sev = s.CodigoServicio
                Exit For
            End If
        Next
        getCodServicio = sev
    End Function

    Public Function getIDSubMenu(idSer As Integer) As Integer
        Dim s As clServicios
        Dim id As Integer
        For Each s In cServicios
            If s.Idservicio = idSer Then
                id = s.Idsubmenu
                Exit For
            End If
        Next
        getIDSubMenu = id
    End Function

    Public Function getIDServicio(idMod As Integer) As Integer
        Dim s As clServicios
        Dim id As Integer
        For Each s In cServicios
            If s.Idfcmodulo = idMod Then
                id = s.Idservicio
                Exit For
            End If
        Next
        getIDServicio = id
    End Function

    Public Function getIDMenu(idSer As Integer) As Integer
        Dim s As clServicios
        Dim id As Integer
        For Each s In cServicios
            If s.Idservicio = idSer Then
                id = s.Idmenu
                Exit For
            End If
        Next
        getIDMenu = id
    End Function

    Public Function getIDModulo(idSer As Integer) As Integer
        Dim s As clServicios
        Dim id As Integer
        For Each s In cServicios
            If s.Idservicio = idSer Then
                id = s.Idmodulo
                Exit For
            End If
        Next
        getIDModulo = id
    End Function

    Public Sub imprimeActivosFijos(wb As Excel.Workbook, idEmp As Integer, idSer As Integer, idMod As Integer)
        Dim Query As String
        Dim Fila As Integer, c As Integer, i As Integer, reg As Integer, Col As Integer
        Dim vMatriz(10000, 7)
        Dim impreso As Boolean
        Dim uF As Long
        Dim ext As String = ""
        Dim Array() As String

        barCount = 500
        frmGeneraDoctos.pr.Value = barCount
        frmGeneraDoctos.pr.Refresh()

        FormatoHoja(wb, idSer, idMod)

        c = 0
        Fila = 6
        With wb.ActiveSheet
            ConEmpresaSQL(idEmp)
            ConEmpresaNom(idEmp)

            Query = "SELECT a.Id, a.codigo, a.activofijo, a.fechaadqui, a.valornominal, a.TipoAct, t.tipo 
                        FROM zACFActivos a INNER JOIN zACFTipos t ON t.id = a.tipoact
                        ORDER BY t.tipo"
            Using cCom = New SqlCommand(Query, FC_SQL)
                Using aCr = cCom.ExecuteReader()
                    Do While aCr.Read()
                        .Cells(Fila, 1) = aCr("Id")
                        .Cells(Fila, 2) = Trim(aCr("tipo"))
                        .Cells(Fila, 3) = "'" & Format(aCr("fechaadqui"), "dd-MM-yyyy")
                        .Cells(Fila, 4) = Format(aCr("valornominal"), "##,###.00")
                        .Cells(Fila, 5) = "'" & Trim(aCr("codigo"))
                        .Cells(Fila, 6) = Trim(aCr("activofijo"))

                        'Query = "SELECT fecha, ruta, ruta_original, tipo, iddigital FROM zClipExped WHERE idcuenta = " & aCr("Id") & " and idservicio = " & idSer
                        Query = "SELECT fecha, ruta, ruta_original, tipo, iddigital FROM zClipExped WHERE idcuenta = " & aCr("Id") & " and idmodulo = 11 and (numero1 <> " & SerCalculosActivos & " or numero1 is null) AND not iddigital is null ORDER BY fecha DESC"
                        Using cCom2 = New SqlCommand(Query, FC_SQL)
                            Using Rs = cCom2.ExecuteReader()
                                Do While Rs.Read()
                                    Array = Rs("ruta").Split(".")
                                    ext = Array(Array.Count - 1)
                                    vMatriz(c, 1) = aCr("Id")
                                    vMatriz(c, 2) = Trim(aCr("tipo"))
                                    vMatriz(c, 3) = Rs("fecha")
                                    vMatriz(c, 4) = Rs("ruta_original") & "." & ext
                                    vMatriz(c, 5) = getURLCloud(Rs("iddigital"))
                                    vMatriz(c, 6) = Rs("tipo")
                                    vMatriz(c, 7) = False

                                    'If fecMayor < Rs("fecha") Then
                                    'fecMayor = Rs("fecha")
                                    'End If
                                    c = c + 1
                                Loop
                            End Using
                        End Using
                        Fila = Fila + 1
                    Loop
                End Using
            End Using

            i = 6
            reg = c
            uF = Fila - 1
            Fila = Fila + 2
            For i = 6 To uF
                'Do While Str(.Cells(i, 2).value) <> ""
                Col = 7
                impreso = False
                Do While CStr(.Cells(1, Col).value) <> ""
                    For c = 0 To reg - 1
                        If .Cells(1, Col).value = vMatriz(c, 6) Then
                            If vMatriz(c, 1) = .Cells(i, 1).value And vMatriz(c, 7) = False Then
                                .Cells(i, Col) = "X"
                                '.Range(Col_Letter(CInt(Col)) & i).Select
                                With .Range(Col_Letter(CInt(Col)) & i)
                                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter ' xlCenter
                                    .VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    .WrapText = False
                                    .Orientation = 0
                                    .AddIndent = False
                                    .IndentLevel = 0
                                    .ShrinkToFit = False
                                    .ReadingOrder = Excel.Constants.xlContext
                                    .MergeCells = False
                                End With
                                If impreso = False Then
                                    Fila = Fila + 2
                                    .Cells(Fila, 1) = "'" & .Cells(i, 1).value
                                    .Cells(Fila, 2) = .Cells(i, 2).value
                                    .Cells(Fila, 3) = "'" & .Cells(i, 3).value
                                    .Cells(Fila, 4) = .Cells(i, 4).value
                                    .Cells(Fila, 5) = .Cells(i, 5).value
                                    .Cells(Fila, 6) = .Cells(i, 6).value
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!F" & Fila, TextToDisplay:="X")
                                    .Hyperlinks.Add(Anchor:= .Range("F" & Fila), Address:="", SubAddress:=
                                        "Hoja1!F" & i)
                                    Fila = Fila + 1
                                    impreso = True
                                Else
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & Fila, TextToDisplay:="X")
                                End If
                                .Cells(Fila, 5) = vMatriz(c, 3)
                                .Cells(Fila, 6) = vMatriz(c, 4)
                                .Cells(Fila, 7) = "(" & .Cells(5, Col).value & ")"
                                .Hyperlinks.Add(Anchor:= .Range("F" & Fila), Address:=vMatriz(c, 5))
                                vMatriz(c, 7) = True
                                Fila = Fila + 1
                            End If
                        End If
                    Next
                    Col += 1
                Loop
            Next
            .Range("F1:Z1").clear
        End With

        NomArc = Obtener_RFC(idEmp) & "_" & Trim(getCodServicio(idSer))

    End Sub

    Public Sub ImprimeDependenciasGob(wb As Excel.Workbook, idEmp As Integer, idSer As Integer)
        Dim Query As String
        Dim Fila As Integer, c As Integer, i As Integer, reg As Integer, Col As Integer
        Dim vMatriz(10000, 7)
        Dim impreso As Boolean
        Dim ext As String = ""
        Dim Array() As String
        Dim uF As Long

        barCount = 500
        frmGeneraDoctos.pr.Value = barCount
        frmGeneraDoctos.pr.Refresh()

        FormatoHoja(wb, idSer)

        c = 0
        Fila = 6
        With wb.ActiveSheet
            ConEmpresaSQL(idEmp)
            Query = "SELECT * FROM zCEXDependencias"
            Using cCom = New SqlCommand(Query, FC_SQL)
                Using aCr = cCom.ExecuteReader()
                    Do While aCr.Read()
                        'fec = aCr("fechanacimiento")
                        .Cells(Fila, 1).value = Trim(aCr("id"))
                        .Cells(Fila, 2) = Trim(aCr("dependencia"))
                        '.Cells(Fila, 3) = "'" & Trim(aCr("numerosegurosocial"))
                        '.Cells(Fila, 4) = Trim(aCr("rfc")) & Right(Year(aCr("fechanacimiento")), 2) & Format(Month(aCr("fechanacimiento")), "00") & fec.ToString("dd", CultureInfo.InvariantCulture) & Trim(aCr("homoclave"))
                        '.Cells(Fila, 5) = Trim(aCr("nombrelargo"))

                        'Query = "SELECT fecha, nombrearchivo, ruta_cloud, idtipodocto FROM XMLDigAsocExped WHERE idelemento = " & aCr("idempleado") & " and idservicio = " & idSer
                        Query = "SELECT fecha, ruta, ruta_original, tipo, iddigital FROM zClipExped WHERE idcuenta = " & aCr("id") & " and idmodulo = " & ModExped_Gobierno & ""
                        Using cCom2 = New SqlCommand(Query, FC_SQL)
                            Using Rs = cCom2.ExecuteReader()
                                Do While Rs.Read()
                                    Array = Rs("ruta").Split(".")
                                    ext = Array(Array.Count - 1)
                                    vMatriz(c, 1) = aCr("id")
                                    vMatriz(c, 2) = aCr("dependencia")
                                    vMatriz(c, 3) = Rs("fecha")
                                    vMatriz(c, 4) = Rs("ruta_original") & "." & ext
                                    vMatriz(c, 5) = getURLCloud(Rs("iddigital"))
                                    vMatriz(c, 6) = Rs("tipo")
                                    vMatriz(c, 7) = False

                                    'If fecMayor < Rs("fecha") Then
                                    '    fecMayor = Rs("fecha")
                                    'End If
                                    c = c + 1
                                Loop
                            End Using
                        End Using
                        Fila = Fila + 1
                    Loop
                End Using
            End Using

            reg = c
            uF = Fila - 1
            Fila = Fila + 2
            For i = 6 To uF
                'Do While Str(.Cells(i, 2).value) <> ""
                Col = 7
                impreso = False
                Do While CStr(.Cells(1, Col).value) <> ""
                    For c = 0 To reg - 1
                        If .Cells(1, Col).value = vMatriz(c, 6) Then
                            If vMatriz(c, 1) = .Cells(i, 1).value And vMatriz(c, 7) = False Then
                                .Cells(i, Col) = "X"
                                '.Range(Col_Letter(CInt(Col)) & i).Select
                                With .Range(Col_Letter(CInt(Col)) & i)
                                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter ' xlCenter
                                    .VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    .WrapText = False
                                    .Orientation = 0
                                    .AddIndent = False
                                    .IndentLevel = 0
                                    .ShrinkToFit = False
                                    .ReadingOrder = Excel.Constants.xlContext
                                    .MergeCells = False
                                End With
                                If impreso = False Then
                                    Fila = Fila + 2
                                    .Cells(Fila, 1) = "'" & .Cells(i, 1).value
                                    .Cells(Fila, 2) = .Cells(i, 2).value
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & Fila, TextToDisplay:="X")
                                    .Hyperlinks.Add(Anchor:= .Range("B" & Fila), Address:="", SubAddress:=
                                        "Hoja1!B" & i)
                                    Fila = Fila + 1
                                    impreso = True
                                Else
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & Fila, TextToDisplay:="X")
                                End If
                                .Cells(Fila, 2) = vMatriz(c, 3)
                                .Cells(Fila, 3) = vMatriz(c, 4)
                                .Cells(Fila, 6) = "(" & .Cells(5, Col).value & ")"
                                .Hyperlinks.Add(Anchor:= .Range("C" & Fila), Address:=vMatriz(c, 5))
                                vMatriz(c, 7) = True
                                Fila = Fila + 1
                            End If
                        End If
                    Next
                    Col += 1
                Loop
            Next
            .Range("D1:Z1").clear
        End With

        NomArc = Obtener_RFC(idEmp) & "_" & Trim(getCodServicio(idSer))

    End Sub

    Public Sub ImprimeExpedienteProveedores(wb As Excel.Workbook, idEmp As Integer, idSer As Integer, idSucCrm As Integer)
        Dim Query As String
        Dim Fila As Integer, c As Integer, i As Integer, reg As Integer, Col As Integer
        Dim vMatriz(10000, 8)
        Dim impreso As Boolean
        Dim ext As String = ""
        Dim Array() As String
        Dim uF As Long

        barCount = 500
        frmGeneraDoctos.pr.Value = barCount
        frmGeneraDoctos.pr.Refresh()

        FormatoHoja(wb, idSer)

        c = 0
        Fila = 6
        With wb.ActiveSheet
            'ConEmpresaSQL(idEmp)
            Query = "SELECT * FROM CEXEmpresas WHERE idempresacrm = " & idEmp & " AND idsucursalcrm =" & idSucCrm
            Using Con = New SqlCommand(Query, FC_Con)
                Using RsGen = Con.ExecuteReader()
                    Do While RsGen.Read()
                        FC_ConexionComercial(RsGen("RutaADW"))
                        Query = "SELECT CIDCLIENTEPROVEEDOR, CRFC, CRAZONSOCIAL FROM admClientes WHERE CTIPOCLIENTE <> 1 And CIDCLIENTEPROVEEDOR <> 0"
                        Using cCom = New SqlCommand(Query, FC_CONCOMER)
                            Using aCr = cCom.ExecuteReader()
                                Do While aCr.Read()
                                    Query = "SELECT fecha, ruta, ruta_original, tipo, iddigital, numero1 FROM zClipExped WHERE idcuenta = " & Trim(aCr("CIDCLIEN01")) & " and numero1 = " & idSucCrm & " and idmodulo = " & ModExped_Proveedores & ""
                                    Using cCom2 = New SqlCommand(Query, FC_SQL)
                                        Using Rs = cCom2.ExecuteReader()
                                            If Rs.HasRows Then
                                                Do While Rs.Read()
                                                    Array = Rs("ruta").Split(".")
                                                    ext = Array(Array.Count - 1)
                                                    vMatriz(c, 1) = Rs("numero1")
                                                    vMatriz(c, 2) = Trim(aCr("CRFC")) & " (" & getSucursalCRM(RsGen("idsucursalcrm")) & ")"
                                                    vMatriz(c, 3) = Rs("fecha")
                                                    vMatriz(c, 4) = Rs("ruta_original") & "." & ext
                                                    vMatriz(c, 5) = getURLCloud(Rs("iddigital"))
                                                    vMatriz(c, 6) = Rs("tipo")
                                                    vMatriz(c, 7) = False
                                                    'vMatriz(c, 8) = aCr("numero1") 'id sucursal

                                                    c = c + 1
                                                Loop
                                                .Cells(Fila, 1).value = RsGen("idsucursalcrm")  'Trim(aCr("CIDCLIEN01"))
                                                .Cells(Fila, 2) = Trim(aCr("CRFC")) & " (" & getSucursalCRM(RsGen("idsucursalcrm")) & ")"
                                                .Cells(Fila, 3) = "'" & Trim(aCr("CRAZONSOCIAL"))
                                                Fila = Fila + 1
                                            End If
                                        End Using
                                    End Using
                                    'Fila = Fila + 1
                                Loop
                            End Using
                        End Using



                    Loop
                End Using
            End Using



            reg = c
            uF = Fila - 1
            Fila = Fila + 2
            For i = 6 To uF
                'Do While Str(.Cells(i, 2).value) <> ""
                Col = 6
                impreso = False
                Do While CStr(.Cells(1, Col).value) <> ""
                    For c = 0 To reg - 1
                        If .Cells(1, Col).value = vMatriz(c, 6) Then
                            If vMatriz(c, 2) = .Cells(i, 2).value And vMatriz(c, 1) = .cells(i, 1).value And vMatriz(c, 7) = False Then
                                .Cells(i, Col) = "X"
                                '.Range(Col_Letter(CInt(Col)) & i).Select
                                With .Range(Col_Letter(CInt(Col)) & i)
                                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter ' xlCenter
                                    .VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    .WrapText = False
                                    .Orientation = 0
                                    .AddIndent = False
                                    .IndentLevel = 0
                                    .ShrinkToFit = False
                                    .ReadingOrder = Excel.Constants.xlContext
                                    .MergeCells = False
                                End With
                                If impreso = False Then
                                    Fila = Fila + 2
                                    .Cells(Fila, 1) = "'" & .Cells(i, 1).value
                                    .Cells(Fila, 2) = .Cells(i, 2).value
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & Fila, TextToDisplay:="X")
                                    .Hyperlinks.Add(Anchor:= .Range("B" & Fila), Address:="", SubAddress:=
                                        "Hoja1!B" & i)
                                    Fila = Fila + 1
                                    impreso = True
                                Else
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & Fila, TextToDisplay:="X")
                                End If
                                .Cells(Fila, 2) = vMatriz(c, 3)
                                .Cells(Fila, 3) = vMatriz(c, 4)
                                .Cells(Fila, 4) = "(" & .Cells(5, Col).value & ")"
                                .Hyperlinks.Add(Anchor:= .Range("C" & Fila), Address:=vMatriz(c, 5))
                                vMatriz(c, 7) = True
                                Fila = Fila + 1
                            End If
                        End If
                    Next
                    Col += 1
                Loop
            Next
            .Range("D1:Z1").clear
        End With

        NomArc = Obtener_RFC(idEmp) & "_" & Trim(getCodServicio(idSer))
    End Sub

    Public Sub ImprimeExpedienteClientes(wb As Excel.Workbook, idEmp As Integer, idSer As Integer, idSucCrm As Integer)
        Dim Query As String
        Dim Fila As Integer, c As Integer, i As Integer, reg As Integer, Col As Integer
        Dim vMatriz(10000, 8)
        Dim impreso As Boolean
        Dim ext As String = ""
        Dim Array() As String
        Dim uF As Long

        barCount = 500
        frmGeneraDoctos.pr.Value = barCount
        frmGeneraDoctos.pr.Refresh()

        FormatoHoja(wb, idSer)

        c = 0
        Fila = 6
        With wb.ActiveSheet
            'ConEmpresaSQL(idEmp)
            Query = "SELECT * FROM CEXEmpresas WHERE idempresacrm = " & idEmp & " AND idsucursalcrm =" & idSucCrm
            Using Con = New SqlCommand(Query, FC_Con)
                Using RsGen = Con.ExecuteReader()
                    Do While RsGen.Read()
                        FC_ConexionComercial(RsGen("RutaADW"))

                        Query = "SELECT CIDCLIENTEPROVEEDOR, CRFC, CRAZONSOCIAL FROM admClientes WHERE CTIPOCLIENTE <> 3 And CIDCLIENTEPROVEEDOR <> 0"
                        Using cCom = New SqlCommand(Query, FC_CONCOMER)
                            Using aCr = cCom.ExecuteReader()
                                Do While aCr.Read()
                                    'fec = aCr("fechanacimiento")
                                    '.Cells(Fila, 1).value = Trim(aCr("CIDCLIEN01"))
                                    '.Cells(Fila, 2) = Trim(aCr("CRFC"))
                                    '.Cells(Fila, 3) = "'" & Trim(aCr("CRAZONSO01"))

                                    'Query = "SELECT fecha, nombrearchivo, ruta_cloud, idtipodocto FROM XMLDigAsocExped WHERE idelemento = " & aCr("idempleado") & " and idservicio = " & idSer
                                    Query = "SELECT fecha, ruta, ruta_original, tipo, iddigital, numero1 FROM zClipExped WHERE idcuenta = " & Trim(aCr("CIDCLIEN01")) & " and numero1 = " & idSucCrm & " and idmodulo = " & ModExped_Clientes & ""
                                    Using cCom2 = New SqlCommand(Query, FC_SQL)
                                        Using Rs = cCom2.ExecuteReader()
                                            If Rs.HasRows Then
                                                Do While Rs.Read()
                                                    Array = Rs("ruta").Split(".")
                                                    ext = Array(Array.Count - 1)
                                                    vMatriz(c, 1) = Rs("numero1")
                                                    vMatriz(c, 2) = Trim(aCr("CRFC")) & " (" & getSucursalCRM(RsGen("idsucursalcrm")) & ")"
                                                    vMatriz(c, 3) = Rs("fecha")
                                                    vMatriz(c, 4) = Rs("ruta_original") & "." & ext
                                                    vMatriz(c, 5) = getURLCloud(Rs("iddigital"))
                                                    vMatriz(c, 6) = Rs("tipo")
                                                    vMatriz(c, 7) = False
                                                    'vMatriz(c, 8) = aCr("numero1") 'id sucursal

                                                    c = c + 1
                                                Loop
                                                .Cells(Fila, 1).value = RsGen("idsucursalcrm")  'Trim(aCr("CIDCLIEN01"))
                                                .Cells(Fila, 2) = Trim(aCr("CRFC")) & " (" & getSucursalCRM(RsGen("idsucursalcrm")) & ")"
                                                .Cells(Fila, 3) = "'" & Trim(aCr("CRAZONSOCIAL"))
                                                Fila = Fila + 1
                                            End If
                                        End Using
                                    End Using
                                    'Fila = Fila + 1
                                Loop
                            End Using
                        End Using



                    Loop
                End Using
            End Using



            reg = c
            uF = Fila - 1
            Fila = Fila + 2
            For i = 6 To uF
                'Do While Str(.Cells(i, 2).value) <> ""
                Col = 6
                impreso = False
                Do While CStr(.Cells(1, Col).value) <> ""
                    For c = 0 To reg - 1
                        If .Cells(1, Col).value = vMatriz(c, 6) Then
                            If vMatriz(c, 2) = .Cells(i, 2).value And vMatriz(c, 1) = .cells(i, 1).value And vMatriz(c, 7) = False Then
                                .Cells(i, Col) = "X"
                                '.Range(Col_Letter(CInt(Col)) & i).Select
                                With .Range(Col_Letter(CInt(Col)) & i)
                                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter ' xlCenter
                                    .VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    .WrapText = False
                                    .Orientation = 0
                                    .AddIndent = False
                                    .IndentLevel = 0
                                    .ShrinkToFit = False
                                    .ReadingOrder = Excel.Constants.xlContext
                                    .MergeCells = False
                                End With
                                If impreso = False Then
                                    Fila = Fila + 2
                                    .Cells(Fila, 1) = "'" & .Cells(i, 1).value
                                    .Cells(Fila, 2) = .Cells(i, 2).value
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & Fila, TextToDisplay:="X")
                                    .Hyperlinks.Add(Anchor:= .Range("B" & Fila), Address:="", SubAddress:=
                                        "Hoja1!B" & i)
                                    Fila = Fila + 1
                                    impreso = True
                                Else
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & Fila, TextToDisplay:="X")
                                End If
                                .Cells(Fila, 2) = vMatriz(c, 3)
                                .Cells(Fila, 3) = vMatriz(c, 4)
                                .Cells(Fila, 4) = "(" & .Cells(5, Col).value & ")"
                                .Hyperlinks.Add(Anchor:= .Range("C" & Fila), Address:=vMatriz(c, 5))
                                vMatriz(c, 7) = True
                                Fila = Fila + 1
                            End If
                        End If
                    Next
                    Col += 1
                Loop
            Next
            .Range("D1:Z1").clear
        End With

        NomArc = Obtener_RFC(idEmp) & "_" & Trim(getCodServicio(idSer))
    End Sub

    Public Sub imprimeNomina(wb As Excel.Workbook, idEmp As Integer, idSer As Integer)
        Dim Query As String
        Dim Fila As Integer, c As Integer, i As Integer, reg As Integer, Col As Integer
        Dim vMatriz(10000, 7)
        Dim impreso As Boolean
        Dim ext As String = ""
        Dim Array() As String
        Dim uF As Long

        barCount = 500
        frmGeneraDoctos.pr.Value = barCount
        frmGeneraDoctos.pr.Refresh()

        FormatoHoja(wb, idSer)

        c = 0
        Fila = 6
        With wb.ActiveSheet
            ConEmpresaSQL(idEmp)
            ConEmpresaNom(idEmp)
            Query = "SELECT p.idperiodo, p.fechainicio, p.fechafin, t.nombretipoperiodo, t.diasdelperiodo FROM NOM10002 p 
                    INNER JOIN NOM10023 t ON t.idtipoperiodo = p.idtipoperiodo 
                    WHERE p.mes <= MONTH(GETDATE()) and p.ejercicio = YEAR(GETDATE()) ORDER BY fechafin DESC"
            Using cCom = New SqlCommand(Query, FC_Nom)
                Using aCr = cCom.ExecuteReader()
                    Do While aCr.Read()
                        .Cells(Fila, 1) = aCr("idperiodo")
                        .Cells(Fila, 2) = Trim(aCr("nombretipoperiodo") & " " & aCr("diasdelperiodo") & " del " & Format(aCr("fechainicio"), "dd-MM-yyyy") & " al " & Format(aCr("fechafin"), "dd-MM-yyyy"))

                        'Query = "SELECT fecha, nombrearchivo, ruta_cloud, idtipodocto FROM XMLDigAsocExped WHERE idelemento = " & aCr("idperiodo") & " and idservicio = " & idSer
                        Query = "SELECT fecha, ruta, ruta_original, tipo, iddigital FROM zClipExped WHERE idcuenta = " & aCr("idperiodo") & " and idmodulo = 14 ORDER BY Fecha DESC"
                        Using cCom2 = New SqlCommand(Query, FC_SQL)
                            Using Rs = cCom2.ExecuteReader()
                                Do While Rs.Read()
                                    Array = Rs("ruta").Split(".")
                                    ext = Array(Array.Count - 1)
                                    vMatriz(c, 1) = aCr("idperiodo")
                                    vMatriz(c, 2) = Trim(aCr("nombretipoperiodo") & " " & aCr("diasdelperiodo") & " del " & Format(aCr("fechainicio"), "dd-MM-yyyy") & " al " & Format(aCr("fechafin"), "dd-MM-yyyy"))
                                    vMatriz(c, 3) = Rs("fecha")
                                    vMatriz(c, 4) = Rs("ruta_original") & "." & ext
                                    vMatriz(c, 5) = getURLCloud(Rs("iddigital"))
                                    vMatriz(c, 6) = Rs("tipo")
                                    vMatriz(c, 7) = False

                                    If fecMayor < Rs("fecha") Then
                                        fecMayor = Rs("fecha")
                                    End If
                                    c = c + 1
                                Loop
                            End Using
                        End Using
                        Fila = Fila + 1
                    Loop
                End Using
            End Using

            .cells(3, 3) = "Por Periodo"
            .cells(4, 3) = "Al " & Format(fecMayor, "dd-MM-yyyy")

            i = 6
            reg = c
            uF = Fila - 1
            Fila = Fila + 2
            For i = 6 To uF
                'Do While Str(.Cells(i, 2).value) <> ""
                Col = 6
                impreso = False
                Do While CStr(.Cells(1, Col).value) <> ""
                    For c = 0 To reg - 1
                        If .Cells(1, Col).value = vMatriz(c, 6) Then
                            If vMatriz(c, 1) = .Cells(i, 1).value And vMatriz(c, 7) = False Then
                                .Cells(i, Col) = "X"
                                '.Range(Col_Letter(CInt(Col)) & i).Select
                                With .Range(Col_Letter(CInt(Col)) & i)
                                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter ' xlCenter
                                    .VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    .WrapText = False
                                    .Orientation = 0
                                    .AddIndent = False
                                    .IndentLevel = 0
                                    .ShrinkToFit = False
                                    .ReadingOrder = Excel.Constants.xlContext
                                    .MergeCells = False
                                End With
                                If impreso = False Then
                                    Fila = Fila + 2
                                    .Cells(Fila, 1) = "'" & .Cells(i, 1).value
                                    .Cells(Fila, 2) = .Cells(i, 2).value
                                    '.Cells(Fila, 3) = .Cells(i, 3).value
                                    '.Cells(Fila, 4) = .Cells(i, 4).value
                                    '.Cells(Fila, 5) = .Cells(i, 5).value
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & Fila, TextToDisplay:="X")
                                    .Hyperlinks.Add(Anchor:= .Range("B" & Fila), Address:="", SubAddress:=
                                        "Hoja1!B" & i)
                                    Fila = Fila + 1
                                    impreso = True
                                Else
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!B" & Fila, TextToDisplay:="X")
                                End If
                                .Cells(Fila, 4) = vMatriz(c, 3)
                                .Cells(Fila, 5) = vMatriz(c, 4)
                                .Cells(Fila, 6) = "(" & .Cells(5, Col).value & ")"
                                .Hyperlinks.Add(Anchor:= .Range("E" & Fila), Address:=vMatriz(c, 5))
                                vMatriz(c, 7) = True
                                Fila = Fila + 1
                            End If
                        End If
                    Next
                    Col += 1
                Loop
            Next
            .Range("F1:Z1").clear
        End With

        NomArc = Obtener_RFC(idEmp) & "_" & Trim(getCodServicio(idSer))

    End Sub

    Public Sub imprimeEmpleados(wb As Excel.Workbook, idEmp As Integer, idSer As Integer)
        Dim Query As String
        Dim Fila As Integer, c As Integer, i As Integer, reg As Integer, Col As Integer
        Dim vMatriz(10000, 7)
        Dim impreso As Boolean
        Dim fec As Date
        Dim uF As Long
        Dim ext As String = ""
        Dim Array() As String

        barCount = 500
        frmGeneraDoctos.pr.Value = barCount
        frmGeneraDoctos.pr.Refresh()

        FormatoHoja(wb, idSer)

        c = 0
        Fila = 6
        With wb.ActiveSheet
            ConEmpresaSQL(idEmp)
            ConEmpresaNom(idEmp)
            Query = "SELECT idempleado, codigoempleado, nombrelargo, numerosegurosocial, fechanacimiento, rfc, homoclave FROM NOM10001 ORDER BY codigoempleado"
            Using cCom = New SqlCommand(Query, FC_Nom)
                Using aCr = cCom.ExecuteReader()
                    Do While aCr.Read()
                        fec = aCr("fechanacimiento")
                        .Cells(Fila, 1).value = Trim(aCr("idempleado"))
                        .Cells(Fila, 2) = "'" & Trim(aCr("codigoempleado"))
                        .Cells(Fila, 3) = "'" & Trim(aCr("numerosegurosocial"))
                        .Cells(Fila, 4) = Trim(aCr("rfc")) & Right(Year(aCr("fechanacimiento")), 2) & Format(Month(aCr("fechanacimiento")), "00") & fec.ToString("dd", CultureInfo.InvariantCulture) & Trim(aCr("homoclave"))
                        .Cells(Fila, 5) = Trim(aCr("nombrelargo"))

                        'Query = "SELECT fecha, nombrearchivo, ruta_cloud, idtipodocto FROM XMLDigAsocExped WHERE idelemento = " & aCr("idempleado") & " and idservicio = " & idSer
                        Query = "SELECT fecha, ruta, ruta_original, tipo, iddigital FROM zClipExped WHERE idcuenta = " & aCr("idempleado") & " and idmodulo = 13 ORDER BY Fecha DESC"
                        Using cCom2 = New SqlCommand(Query, FC_SQL)
                            Using Rs = cCom2.ExecuteReader()
                                Do While Rs.Read()
                                    Array = Rs("ruta").Split(".")
                                    ext = Array(Array.Count - 1)
                                    vMatriz(c, 1) = aCr("idempleado")
                                    vMatriz(c, 2) = aCr("codigoempleado")
                                    vMatriz(c, 3) = Rs("fecha")
                                    vMatriz(c, 4) = Rs("ruta_original") & "." & ext
                                    vMatriz(c, 5) = getURLCloud(Rs("iddigital"))
                                    vMatriz(c, 6) = Rs("tipo")
                                    vMatriz(c, 7) = False

                                    If fecMayor < Rs("fecha") Then
                                        fecMayor = Rs("fecha")
                                    End If
                                    c = c + 1
                                Loop
                            End Using
                        End Using
                        Fila = Fila + 1
                    Loop
                End Using
            End Using

            .cells(3, 5) = "Por Empleado"
            .cells(4, 5) = "Al " & Format(fecMayor, "dd-MM-yyyy")

            i = 6
            reg = c
            uF = Fila - 1
            Fila = Fila + 2
            For i = 6 To uF
                'Do While Str(.Cells(i, 2).value) <> ""
                Col = 6
                impreso = False
                Do While CStr(.Cells(1, Col).value) <> ""
                    For c = 0 To reg - 1
                        If .Cells(1, Col).value = vMatriz(c, 6) Then
                            If vMatriz(c, 1) = .Cells(i, 1).value And vMatriz(c, 7) = False Then
                                .Cells(i, Col) = "X"
                                '.Range(Col_Letter(CInt(Col)) & i).Select
                                With .Range(Col_Letter(CInt(Col)) & i)
                                    .HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter ' xlCenter
                                    .VerticalAlignment = Excel.XlHAlign.xlHAlignCenter
                                    .WrapText = False
                                    .Orientation = 0
                                    .AddIndent = False
                                    .IndentLevel = 0
                                    .ShrinkToFit = False
                                    .ReadingOrder = Excel.Constants.xlContext
                                    .MergeCells = False
                                End With
                                If impreso = False Then
                                    Fila = Fila + 2
                                    .Cells(Fila, 1) = "'" & .Cells(i, 1).value
                                    .Cells(Fila, 2) = "'" & .Cells(i, 2).value
                                    .Cells(Fila, 3) = .Cells(i, 3).value
                                    .Cells(Fila, 4) = .Cells(i, 4).value
                                    .Cells(Fila, 5) = .Cells(i, 5).value
                                    '.Range(Col_Letter(CInt(Col)) & i).Select
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!E" & Fila, TextToDisplay:="X")
                                    '.Range("E" & Fila).Select
                                    .Hyperlinks.Add(Anchor:= .Range("E" & Fila), Address:="", SubAddress:=
                                        "Hoja1!E" & i)
                                    Fila = Fila + 1
                                    impreso = True
                                Else
                                    '.Range(Col_Letter(CInt(Col)) & i).Select
                                    .Hyperlinks.Add(Anchor:= .Range(Col_Letter(CInt(Col)) & i), Address:="", SubAddress:=
                                        "Hoja1!E" & Fila, TextToDisplay:="X")
                                End If
                                .Cells(Fila, 4) = vMatriz(c, 3)
                                .Cells(Fila, 5) = vMatriz(c, 4)
                                .Cells(Fila, 6) = "(" & .Cells(5, Col).value & ")"
                                '.Range("E" & Fila).Select
                                .Hyperlinks.Add(Anchor:= .Range("E" & Fila), Address:=vMatriz(c, 5))
                                vMatriz(c, 7) = True
                                Fila = Fila + 1
                            End If
                        End If
                    Next
                    Col += 1
                Loop
                '   i += 1
                'Loop
            Next
            .Range("F1:Z1").clear
        End With

        NomArc = Obtener_RFC(idEmp) & "_" & Trim(getCodServicio(idSer))

    End Sub

    Public Function Obtener_RFC(ByVal eIDEm As Integer) As String
        Dim vEmpresa As clEmpresa
        Obtener_RFC = ""
        For Each vEmpresa In GL_cUsuarioAPI.MEmpresas
            If vEmpresa.Idempresa = eIDEm Then
                Obtener_RFC = vEmpresa.Rfc
                Exit For
            End If
        Next
    End Function

    'Public Sub FormatoHoja(wb As Excel.Workbook, FilaF As Integer, ColF As Integer)
    Public Sub FormatoHoja(wb As Excel.Workbook, idSer As Integer, Optional idMod As Integer = 0)
        With wb
            With .ActiveSheet.PageSetup
                .PrintTitleRows = ""
                .PrintTitleColumns = ""
            End With
            .ActiveSheet.PageSetup.PrintArea = ""
            With .ActiveSheet.PageSetup
                .LeftMargin = wb.Application.InchesToPoints(0.236220472440945)
                .RightMargin = wb.Application.InchesToPoints(0.236220472440945)
                .TopMargin = wb.Application.InchesToPoints(0.748031496062992)
                .BottomMargin = wb.Application.InchesToPoints(0.748031496062992)
                .HeaderMargin = wb.Application.InchesToPoints(0.31496062992126)
                .FooterMargin = wb.Application.InchesToPoints(0.31496062992126)
                .Orientation = Excel.XlPageOrientation.xlLandscape
                If idSer = SerExped_Permanente Then
                    .PaperSize = Excel.XlPaperSize.xlPaperLegal
                    .Zoom = False
                ElseIf idMod = ModExped_Activos And idSer <> SerCalculosActivos Then
                    .PaperSize = Excel.XlPaperSize.xlPaperLegal
                    .Zoom = False
                Else
                    .PaperSize = Excel.XlPaperSize.xlPaperLetter
                    .Zoom = 100
                End If
                .PrintQuality = 600
                .FitToPagesWide = 1
                .FitToPagesTall = False
                .PrintErrors = Excel.XlPrintErrors.xlPrintErrorsDisplayed
                .OddAndEvenPagesHeaderFooter = False
                .DifferentFirstPageHeaderFooter = False
                .ScaleWithDocHeaderFooter = True
                .AlignMarginsHeaderFooter = True
            End With
        End With
    End Sub

    Public Function getNombreEmpresa(ByVal idEmp As Integer)
        Dim nombre As String = ""
        Dim Query As String
        'Query = "SELECT empresacrm FROM XMLDigEmpresas WHERE idempresacrm = " & idEmp
        Query = "SELECT empresacrm FROM CEXEmpresas WHERE idempresacrm = " & idEmp
        Using dCom = New SqlCommand(Query, FC_Con)
            Using aCr = dCom.ExecuteReader()
                aCr.Read()
                If aCr.HasRows Then
                    nombre = aCr("empresacrm")
                End If
            End Using
        End Using
        getNombreEmpresa = nombre
    End Function


    Public Function Guarda_Doc(ByVal nomArchivo As String, FecF As Date, idSer As Integer, Optional Ejercicio As Integer = 0) As Integer
        Dim tipodoc As String = "", fechad As Date 'dQue As String
        Dim aPeriodo As Integer, aEjercicio As Integer, fechamod As Date
        Dim arch As String, nomAr As String, Query As String
        Dim idsubmenu As Integer

        ConEmpresaSQL(IDEmp)

        tipodoc = getCodServicio(idSer)
        idsubmenu = getIDSubMenu(idSer)

        fechamod = Now
        fechad = FecF
        arch = nomArchivo & ".pdf"
        nomAr = nomArchivo
        aPeriodo = Format(Month(fechad), "00")
        aEjercicio = Year(fechad)

        ''REGISTRA BITACORA
        Query = "IF NOT EXISTS(SELECT * FROM zIncContBitacora WHERE tipodocumento=@tipodoc AND " &
                                "periodo=@periodo AND ejercicio=@ejercicio) " &
                    "INSERT INTO zIncContBitacora(idsubmenu,tipodocumento,periodo,ejercicio,fecha,fechamodificacion,archivo, " &
                        "nombrearchivo, sincronizado)VALUES(@idsub,@tipodoc,@periodo,@ejercicio,@fecha,@fechamod, " &
                        "@archivo,@nomarchivo,@sincro);" &
                "ELSE " &
                    "UPDATE zIncContBitacora SET fechamodificacion=@fechamod, sincronizado=0, fecha=@fecha " &
                        "WHERE tipodocumento=@tipodoc AND periodo=@periodo AND " &
                            "idsubmenu=@idsub AND ejercicio=@ejercicio AND fecha<=@fecha;"
        Using dCom = New SqlCommand(Query, FC_SQL)
            dCom.Parameters.AddWithValue("@idsub", idsubmenu)
            dCom.Parameters.AddWithValue("@tipodoc", tipodoc)
            dCom.Parameters.AddWithValue("@periodo", Format(Month(fechad), "00"))
            dCom.Parameters.AddWithValue("@ejercicio", Year(fechad))
            dCom.Parameters.AddWithValue("@fecha", fechad)
            dCom.Parameters.AddWithValue("@fechamod", Now)
            dCom.Parameters.AddWithValue("@archivo", nomArchivo & ".pdf")
            dCom.Parameters.AddWithValue("@nomarchivo", nomAr)
            dCom.Parameters.AddWithValue("@sincro", 0)
            dCom.ExecuteNonQuery()
        End Using

        Guarda_Doc = idsubmenu
    End Function

    Public Sub BuscaNoSincronizado(ByVal dRfc As String, ByVal dTipo As String, ByVal dEjercicio As Integer, ByVal dPeriodo As Integer, druta As String, idSub As Integer)
        Dim Query As String
        Query = "SELECT id,idsubmenu,tipodocumento,periodo,ejercicio,fecha,fechamodificacion,archivo," &
                "nombrearchivo FROM zIncContBitacora WHERE ejercicio=" & dEjercicio & " AND periodo=" &
                dPeriodo & " AND sincronizado=0 AND tipodocumento='" & dTipo & "'"
        Using cCom = New SqlCommand(Query, FC_SQL)
            Using Rs = cCom.ExecuteReader
                Do While Rs.Read()
                    If EnviarBitacora(dRfc, dTipo, Rs("fechamodificacion"), Rs("periodo"),
                        Rs("ejercicio"), Trim(Rs("archivo")), Trim(Rs("nombrearchivo")), Rs("fecha"), druta, idSub) = True Then
                        Using cCom2 = New SqlCommand("UPDATE zIncContBitacora SET sincronizado=1 WHERE id=" & Rs("id"), FC_SQL)
                            cCom2.ExecuteNonQuery()
                        End Using
                    End If
                Loop
            End Using
        End Using
    End Sub

    Public Function EnviarBitacora(ByVal dRfc As String, ByVal dTipo As String, ByVal dFechamod As Date,
                                   ByVal dPeriodo As Integer, ByVal dEjercicio As Integer, ByVal dArchivo As String,
                                   ByVal dNomArch As String, ByVal dFecha As Date, ByVal dRut As String, ByVal idSub As Integer) As Boolean
        Dim dFiltro As String, dMetodo As String
        Dim jsonMod As String

        EnviarBitacora = False
        dRut = dRut.Replace("\", "/")
        dFiltro = "{" & Chr(34) & "Rfc" & Chr(34) & ": " & Chr(34) & dRfc & Chr(34) & ", " &
                    Chr(34) & "Correo" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Correo & Chr(34) & "," &
                    Chr(34) & "Contra" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Contra & Chr(34) & "," &
                    Chr(34) & "Idsubmenu" & Chr(34) & ": " & Chr(34) & idSub & Chr(34) & "," &
                    Chr(34) & "Tipodocumento" & Chr(34) & ": " & Chr(34) & dTipo & Chr(34) & "," &
                    Chr(34) & "Regbitacora" & Chr(34) & ":[{ " &
                    Chr(34) & "Fechamodificacion" & Chr(34) & ": " & Chr(34) & Format(dFechamod, "yyyy-MM-dd h:mm:ss") & Chr(34) & ", " &
                    Chr(34) & "Fecha" & Chr(34) & ": " & Chr(34) & Format(dFecha, "yyyy-MM-dd") & Chr(34) & ", " &
                    Chr(34) & "Periodo" & Chr(34) & ": " & Chr(34) & dPeriodo & Chr(34) & ", " &
                    Chr(34) & "Ejercicio" & Chr(34) & ": " & Chr(34) & dEjercicio & Chr(34) & ", " &
                    Chr(34) & "Archivo" & Chr(34) & ": " & Chr(34) & dArchivo & Chr(34) & ", " &
                    Chr(34) & "Url" & Chr(34) & ": " & Chr(34) & dRut & "/" & Chr(34) & ", " &
                    Chr(34) & "Nombrearchivo" & Chr(34) & ": " & Chr(34) & dNomArch & Chr(34) & "}]}"
        dMetodo = "registraBitacora"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        If jsonMod <> "" Then
            If jsonMod = "true" Then
                EnviarBitacora = True
            Else
                EnviarBitacora = False
            End If
        End If
    End Function

    Public Function Vincular_DocumentosExpedBancos(modDesk As Integer, idCuenta As Integer, idDigital As Integer,
                                                   Periodo As Integer, Ejercicio As Integer, tipoDocto As String, fecDocto As Date,
                                                   Ruta As String, RutaOriginal As String)
        Dim sQue As String, vinculo As Boolean
        vinculo = False
        Try
            sQue = "INSERT INTO zClipExped(" &
                    "idusuario, idmodulo, idcuenta, " &
                    "periodo, ejercicio, tipo, " &
                    "fecha, fecha_reg, " &
                    "iddigital, ruta, ruta_original) " &
                "VALUES(" &
                    "" & GL_cUsuarioAPI.Iduser & ", " & modDesk & ", " & idCuenta & ", " &
                    "" & Periodo & "," & Ejercicio & ", '" & tipoDocto & "', " &
                    "'" & Format(fecDocto, "yyyy-MM-dd") & "', '" & Format(Now(), "yyyy-MM-dd") & "', " &
                    "" & idDigital & ", '" & Ruta & "', '" & RutaOriginal & "')"
            Using sCom = New SqlCommand(sQue, FC_SQL)
                sCom.ExecuteNonQuery()
                vinculo = True
                Return vinculo
            End Using
        Catch ex As Exception
            MsgBox("Error del Sistema al Guardar la asociación" & vbCrLf & ex.Message, vbExclamation, "Información")
            Return vinculo
        End Try
    End Function

    Public Function Vincular_DocumentosExpedFiscales(modDesk As Integer, RFC As String, idDigital As Integer,
                                                   Periodo As Integer, Ejercicio As Integer, Tipo As Integer, fecDocto As Date,
                                                   Ruta As String, RutaOriginal As String, IdObligacion As Integer, idEstado As Integer)
        Dim sQue As String, vinculo As Boolean
        Dim idRFC As Integer, idMovto As Integer
        Dim ckini As Integer, ckfin As Integer, nArchIni As Integer, nArchFin As Integer

        idRFC = getIDTax(RFC)

        sQue = "SELECT taxmovtos.id, idestado, foliado, ckini, ckfin, narchini, narchfin 
                    FROM taxmovtos, taxcatobligacion 
                WHERE taxcatobligacion.id=taxmovtos.idobligacion and idrfc=" & idRFC & " and idobligacion=" & IdObligacion & " 
                    and Ejercicio=" & Ejercicio & " and Periodo=" & Periodo & " AND idEstado = " & idEstado
oneMoreTime:
        Using Con = New SqlCommand(sQue, FC_Con)
            Using Rs = Con.ExecuteReader()
                If Rs.HasRows Then
                    Rs.Read()
                    idMovto = Rs("id")
                    If Rs("ckini") = True Then
                        nArchIni = CInt(Rs("narchini")) + 1
                        nArchFin = CInt(Rs("narchfin"))
                    Else
                        nArchIni = CInt(Rs("narchini"))
                        nArchFin = CInt(Rs("narchfin")) + 1
                    End If
                    Using Con3 = New SqlCommand("Update taxmovtos set idrfc=" & idRFC & ", ejercicio=" & Ejercicio & ", periodo=" & Periodo & ", idobligacion=" & IdObligacion & ", idestado=" & idEstado & ", fechareg='" & Format(Now, "yyyy-MM-dd") & "', ckini=" & ckini & ", ckfin=" & ckfin & ", narchini=" & nArchIni & ", narchfin=" & nArchFin & " where id=" & idMovto, FC_Con)
                        Con3.ExecuteNonQuery()
                    End Using
                Else
                    If Tipo = 1 Then
                        ckini = 1
                        ckfin = 0
                        nArchIni = 0
                        nArchFin = 0
                    Else '2
                        ckini = 0
                        ckfin = 1
                        nArchIni = 0
                        nArchFin = 0
                    End If
                    Using Con2 = New SqlCommand("Insert into taxmovtos (idrfc, ejercicio, periodo, idobligacion, idestado, Foliado, fechareg, CkIni, CkFin, nArchIni, nArchFin) Values (" & idRFC & ", " & Ejercicio & ", " & Periodo & ", " & IdObligacion & ", " & idEstado & ", '', '" & Format(Now, "yyyy-MM-dd") & "', " & ckini & ", " & ckfin & ", " & nArchIni & ", " & nArchFin & ")", FC_Con)
                        If Con2.ExecuteNonQuery Then
                            GoTo oneMoreTime 'consultamos de nuevo para traernos el ID del Movto
                        Else
                            MsgBox("Error al registrar un nuevo movimiento.", vbInformation)
                            idMovto = 0
                            Return False
                            Exit Function
                        End If
                    End Using
                End If
            End Using
        End Using


        vinculo = False
        Try
            sQue = "INSERT INTO zClipExped(" &
                    "idusuario, idmodulo, idcuenta, " &
                    "periodo, ejercicio, tipo, " &
                    "fecha, fecha_reg, " &
                    "iddigital, ruta, ruta_original, numero1) " &
                "VALUES(" &
                    "" & GL_cUsuarioAPI.Iduser & ", " & modDesk & ", " & idRFC & ", " &
                    "" & Periodo & "," & Ejercicio & ", '" & Tipo & "', " &
                    "'" & Format(fecDocto, "yyyy-MM-dd") & "', '" & Format(Now(), "yyyy-MM-dd") & "', " &
                    "" & idDigital & ", '" & Ruta & "', '" & RutaOriginal & "', " & idMovto & ")"
            Using sCom = New SqlCommand(sQue, FC_SQL)
                sCom.ExecuteNonQuery()
                vinculo = True
                Return vinculo
            End Using
        Catch ex As Exception
            MsgBox("Error del Sistema al Guardar la asociación" & vbCrLf & ex.Message, vbExclamation, "Información")
            Return vinculo
        End Try

    End Function


    Public Function Vincular_DocumentosExpedActivos(modDesk As Integer, idCuenta As Integer, idDigital As Integer,
                                                   Periodo As Integer, Ejercicio As Integer, tipoDocto As String, fecDocto As Date,
                                                   Ruta As String, RutaOriginal As String, idServicio As Integer)
        Dim sQue As String, vinculo As Boolean
        vinculo = False
        Try
            sQue = "INSERT INTO zClipExped(" &
                        "idusuario, idmodulo, tipo, ejercicio, periodo, ruta, " &
                        "idcuenta, iddigital, ruta_original, fecha, fecha_reg, numero1) " &
                    "VALUES (" &
                        "" & GL_cUsuarioAPI.Iduser & ", " & modDesk & ", '" & tipoDocto & "', " & Ejercicio & "," &
                        "" & Periodo & ",'" & Ruta & "'," & idCuenta & ", " & idDigital & ", " &
                        "'" & RutaOriginal & "', '" & Format(fecDocto, "yyyy-MM-dd") & "', '" & Format(Now(), "yyyy-MM-dd") & "', " & idServicio & ")"
            Using sCom = New SqlCommand(sQue, FC_SQL)
                sCom.ExecuteNonQuery()
                vinculo = True
                Return vinculo
            End Using
        Catch ex As Exception
            MsgBox("Error del Sistema al Guardar la asociación" & vbCrLf & ex.Message, vbExclamation, "Información")
            Return vinculo
        End Try
    End Function

    'Vincula a tabla unificada documentos crm de expedientes de proveedores y clientes, se guarda sucursal en campo numero1
    Public Function Vincular_DocumentosProvCli(modDesk As Integer, idCuenta As Integer, idDigital As Integer,
                                                   tipoDocto As String, fecDocto As Date,
                                                   Ruta As String, RutaOriginal As String, idSuc As Integer)

        Dim sQue As String, vinculo As Boolean
        vinculo = False
        Try
            sQue = "INSERT INTO zClipExped(" &
                        "idusuario, idmodulo, tipo, ruta, " &
                        "idcuenta, iddigital, ruta_original, fecha, fecha_reg, numero1) " &
                    "VALUES (" &
                        "" & GL_cUsuarioAPI.Iduser & ", " & modDesk & ", '" & tipoDocto & "', '" & Ruta & "'," & idCuenta & ", " & idDigital & ", " &
                        "'" & RutaOriginal & "', '" & Format(fecDocto, "yyyy-MM-dd") & "', '" & Format(Now(), "yyyy-MM-dd") & "', " & idSuc & ")"
            Using sCom = New SqlCommand(sQue, FC_SQL)
                sCom.ExecuteNonQuery()
                vinculo = True
                Return vinculo
            End Using
        Catch ex As Exception
            MsgBox("Error del Sistema al Guardar la asociación" & vbCrLf & ex.Message, vbExclamation, "Información")
            Return vinculo
        End Try

    End Function

    Public Function Vincular_DocumentosExped(modDesk As Integer, idCuenta As Integer, idDigital As Integer,
                                                   tipoDocto As String, fecDocto As Date,
                                                   Ruta As String, RutaOriginal As String)
        Dim sQue As String, vinculo As Boolean
        vinculo = False
        Try
            sQue = "INSERT INTO zClipExped(" &
                        "idusuario, idmodulo, tipo, ruta, " &
                        "idcuenta, iddigital, ruta_original, fecha, fecha_reg) " &
                    "VALUES (" &
                        "" & GL_cUsuarioAPI.Iduser & ", " & modDesk & ", '" & tipoDocto & "', '" & Ruta & "'," & idCuenta & ", " & idDigital & ", " &
                        "'" & RutaOriginal & "', '" & Format(fecDocto, "yyyy-MM-dd") & "', '" & Format(Now(), "yyyy-MM-dd") & "')"
            Using sCom = New SqlCommand(sQue, FC_SQL)
                sCom.ExecuteNonQuery()
                vinculo = True
                Return vinculo
            End Using
        Catch ex As Exception
            MsgBox("Error del Sistema al Guardar la asociación" & vbCrLf & ex.Message, vbExclamation, "Información")
            Return vinculo
        End Try
    End Function

    Public Function ClipMarcadoCRM(sRFC As String, modDesk As Integer, idSub As Integer, sCuenta As String, sTipoDoc As String,
                                   Periodo As Integer, Ejercicio As Integer, bEstatus As Boolean, idDocDigital As Integer) As Boolean

        Dim dMetodo As String, dFiltro As String = "", jsonMod As String
        Dim resp As Boolean
        resp = False
        If bEstatus = True Then
            dFiltro = "{" & Chr(34) & "rfc" & Chr(34) & ": " & Chr(34) & sRFC & Chr(34) & ", " &
                    Chr(34) & "usuario" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Correo & Chr(34) & "," &
                    Chr(34) & "pwd" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.EncryptedContra & Chr(34) & "," &
                    Chr(34) & "idmodulodesk" & Chr(34) & ": " & Chr(34) & modDesk & Chr(34) & "," &
                    Chr(34) & "idsubmenu" & Chr(34) & ": " & Chr(34) & idSub & Chr(34) & "," &
                    Chr(34) & "fechaprocesado" & Chr(34) & ": " & Chr(34) & Format(Now, "yyyy-MM-dd h:m:s") & Chr(34) & "," &
                    Chr(34) & "cuenta" & Chr(34) & ": " & Chr(34) & sCuenta & Chr(34) & "," &
                    Chr(34) & "tipodoc" & Chr(34) & ": " & Chr(34) & sTipoDoc & Chr(34) & "," &
                    Chr(34) & "periodo" & Chr(34) & ": " & Chr(34) & Periodo & Chr(34) & "," &
                    Chr(34) & "ejercicio" & Chr(34) & ": " & Chr(34) & Ejercicio & Chr(34) & "," &
                    Chr(34) & "status" & Chr(34) & ": " & Chr(34) & "1" & Chr(34) & "," &
                    Chr(34) & "archivos" & Chr(34) & ":[{ " & Chr(34) & "idarchivodet" & Chr(34) & ": " & Chr(34) & idDocDigital & Chr(34) & "}]}"
        Else
            dFiltro = "{" & Chr(34) & "rfc" & Chr(34) & ": " & Chr(34) & sRFC & Chr(34) & ", " &
                    Chr(34) & "usuario" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.Correo & Chr(34) & "," &
                    Chr(34) & "pwd" & Chr(34) & ": " & Chr(34) & GL_cUsuarioAPI.EncryptedContra & Chr(34) & "," &
                    Chr(34) & "idsubmenu" & Chr(34) & ": " & Chr(34) & idSub & Chr(34) & "," &
                    Chr(34) & "periodo" & Chr(34) & ": " & Chr(34) & Periodo & Chr(34) & "," &
                    Chr(34) & "ejercicio" & Chr(34) & ": " & Chr(34) & Ejercicio & Chr(34) & "," &
                    Chr(34) & "status" & Chr(34) & ": " & Chr(34) & "0" & Chr(34) & "," &
                    Chr(34) & "archivos" & Chr(34) & ":[{ " & Chr(34) & "idarchivodet" & Chr(34) & ": " & Chr(34) & idDocDigital & Chr(34) & "}]}"
        End If
        dMetodo = "ClipMarcado"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "POST", "JSON")
        jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
        If CInt(jsonObject("error")) = 0 Then
            resp = True
        End If
        ClipMarcadoCRM = resp
    End Function

    Public Function GetLink_Compartido(ByVal gArchivo As String, ByVal userCRM As String, ByVal passCRM As String) As String
        Dim sURL As String
        Dim idEmp As Integer
        Dim strJson As String
        Dim objJson As Object
        Dim hReq As Object, JSON As Object
        Dim sServidor As String, dpath As String

        sURL = "http://" & userCRM & ":" & passCRM & "@" & G_ServerCloud & "/ocs/v2.php/apps/files_sharing/api/v1/shares"
        dpath = "path=CRM/" & userCRM & "/" & gArchivo & "&shareType=3"

        hReq = CreateObject("MSXML2.ServerXMLHTTP")
        With hReq
            .Open("POST", sURL, False)
            .setRequestHeader("Content-type", "application/x-www-form-urlencoded")
            .setRequestHeader("OCS-APIREQUEST", "true")
            .setRequestHeader("Authorization", "Basic " & EncodeBase64(userCRM & ":" & passCRM))
            .send(dpath)
            If .Status <> 200 Then
                Select Case .Status
                    Case 500 'Error Interno
                        MsgBox("Internal Server Error(500).", vbCritical)
                    Case 403 'Prohibido
                        MsgBox("Error al intentar marcar el lote como procesado." & vbCrLf & "El servidor prohibió el acceso al recurso.", vbCritical)
                    Case 401 'Falló autenticación
                        MsgBox("Solicitud rechazada por el servidor. Revise que el usuario y contraseña sean correctos y vuelva a intentar.", vbExclamation)
                End Select
                GetLink_Compartido = ""
                Exit Function
            End If
        End With

        strJson = hReq.responseText
        If strJson <> "" Then
            GetLink_Compartido = Extraer_Link(strJson)
        Else
            GetLink_Compartido = ""
        End If

        On Error GoTo Err_Update

        Exit Function
Err_Update:
        GetLink_Compartido = ""
        End
    End Function

    Public Function EncodeBase64(text As String) As String
        Dim base64Decoded As String = text
        Dim base64Encoded As String = ""
        Dim data As Byte()
        data = System.Text.ASCIIEncoding.ASCII.GetBytes(base64Decoded)
        base64Encoded = System.Convert.ToBase64String(data)
        EncodeBase64 = base64Encoded
    End Function

    Public Function Extraer_Link(ByVal XmlString As String) As String
        Dim objDOMDoc As New MSXML2.DOMDocument40
        Dim Dato As MSXML2.IXMLDOMNodeList
        Dim dLink As String = ""

        objDOMDoc.async = False

        Call objDOMDoc.load(XmlString)

        'dLink = ""

        If objDOMDoc.parseError.reason <> "" Then
            MsgBox(objDOMDoc.parseError.reason)
            Exit Function
        End If

        Dato = objDOMDoc.getElementsByTagName("url")
        dLink = Dato.item(0).nodeTypedValue

        objDOMDoc = Nothing

        Extraer_Link = dLink
    End Function

    Public Sub getModulosCRM()
        Dim dMetodo As String, dFiltro As String = "", jsonMod As String
        Dim m As clModulosCRM
        cModulosCRM = New Collection
        dMetodo = "Modulos"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "GET", "JSON")
        'jsonMod = jsonMod.TrimStart("[").TrimEnd("]")
        If jsonMod <> "" Then
            If jsonMod <> "false" Then
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                For Each Row In jsonObject(0)
                    m = New clModulosCRM
                    m.IDModulo = Row("idmodulo")
                    m.NombreModulo = Row("nombre_modulo")
                    m.Estatus = Row("status")
                Next
            End If
        End If
    End Sub
    Public Sub getMenusCRM()
        Dim dMetodo As String, dFiltro As String = "", jsonMod As String
        Dim m As clMenusCRM
        'dFiltro = "{""usuario"":""" & GL_cUsuarioAPI.Correo & """, ""pwd"":""" & GL_cUsuarioAPI.Contra & """}"
        dMetodo = "Menus"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "GET", "JSON")
        If jsonMod <> "" Then
            If jsonMod <> "false" Then
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                For Each Row In jsonObject(0)
                    m = New clMenusCRM
                    m.IDMenu = Row("idmenu")
                    m.NombreMenu = Row("nombre_menu")
                    m.Estatus = Row("status")
                Next
            End If
        End If
    End Sub
    Public Sub getSubMenusCRM()
        Dim dMetodo As String, dFiltro As String = "", jsonMod As String
        Dim s As clSubMenusCRM
        'dFiltro = "{""usuario"":""" & GL_cUsuarioAPI.Correo & """, ""pwd"":""" & GL_cUsuarioAPI.Contra & """}"
        dMetodo = "SubMenus"
        jsonMod = ConsumeAPI(mApi, dMetodo, dFiltro, "GET", "JSON")
        If jsonMod <> "" Then
            If jsonMod <> "false" Then
                jsonObject = Newtonsoft.Json.Linq.JObject.Parse(jsonMod)
                For Each Row In jsonObject(0)
                    s = New clSubMenusCRM
                    s.IDSubMenu = Row("idsubmenu")
                    s.NombreSubMenu = Row("nombre_submenu")
                    s.Estatus = Row("status")
                Next
            End If
        End If
    End Sub

    Public Function getModulo(ByVal iMod As Integer) As String
        Dim NomSub As String = ""
        'Dim m As clModulosCRM

        'For Each m In cModulosCRM
        '    If iMod = m.IDModulo Then
        '        NomSub = m.NombreModulo
        '        Exit For
        '    End If
        'Next
        Select Case iMod
            Case 1
                NomSub = "Mi Contabilidad"
            Case 4
                NomSub = "Mi Administracion"
        End Select
        getModulo = NomSub
    End Function
    Public Function getMenu(ByVal iMen As Integer) As String
        Dim NomSub As String = ""
        'Dim m As clMenusCRM
        'For Each m In cMenusCRM
        '    If m.IDMenu = iMen Then
        '        NomSub = m.NombreMenu
        '        Exit For
        '    End If
        'Next
        Select Case iMen
            Case 2
                NomSub = "Cumplimiento Fiscal"
            Case 14
                NomSub = "Expedientes Digitales"
            Case 15
                NomSub = "Publicaciones"
        End Select
        getMenu = NomSub
    End Function
    Public Function getSubMenu(ByVal iSub As Integer) As String
        Dim NomSub As String = ""

        'Dim s As clSubMenusCRM
        'For Each s In cSubMenusCRM
        '    If s.IDSubMenu = iSub Then
        '        NomSub = s.NombreSubMenu
        '        Exit For
        '    End If
        'Next

        Select Case iSub
            Case 5
                NomSub = "Pagos Provisionales y Mensuales"
            Case 6
                NomSub = "Pagos Mensuales"
            Case 7
                NomSub = "Declaraciones Anuales"
            Case 8
                NomSub = "Expedientes Fiscales"
            Case 51
                NomSub = "Constitucion y Estatutos"
            Case 52
                NomSub = "Gobierno"
            Case 53
                NomSub = "Bancos"
            Case 54
                NomSub = "Recursos Humanos"
            Case 55
                NomSub = "Clientes"
            Case 56
                NomSub = "Proveedores"
            Case 57
                NomSub = "Activos Fijos"
            Case 58
                NomSub = "Folios Oficiales"
            Case 59
                NomSub = "Biblioteca de Conocimiento"
            Case 60
                NomSub = "Mural"
        End Select
        getSubMenu = NomSub
    End Function

    Sub CalculaPendientes(IdRFC, Fecha, ejercicio, IdEstado)
        Dim Query As String, Que As String
        Dim Filtroejercicio As String
        Dim PerActual As Integer
        Dim EjeActual As Integer
        Dim R As Integer
        Dim MesFin As Integer
        Dim xP As Integer
        Dim EjeIni As Integer, EjeFin As Integer
        Dim dAgenda As clObligaciones

        'ReDim vAgenda(1000, 10)
        Erase vAgenda

        'LISTAS PREDEFINIDAS
        Dim vTipos(2)
        vTipos(1) = "Permanente"
        vTipos(2) = "Periodica"

        Dim vAnual(3)
        vAnual(1) = "Anual"
        vAnual(2) = "Periodica"
        vAnual(3) = "Eventual"

        Dim vPeriodos(13)
        vPeriodos(1) = "Ene"
        vPeriodos(2) = "Feb"
        vPeriodos(3) = "Mar"
        vPeriodos(4) = "Abr"
        vPeriodos(5) = "May"
        vPeriodos(6) = "Jun"
        vPeriodos(7) = "Jul"
        vPeriodos(8) = "Ago"
        vPeriodos(9) = "Sep"
        vPeriodos(10) = "Oct"
        vPeriodos(11) = "Nov"
        vPeriodos(12) = "Dic"

        Dim vMeses(12, 12)
        'Periodos a Cumplir Mensual
        For O = 1 To 12
            vMeses(12, O) = 1
        Next O
        'Periodos a Cumplir Bimestral
        For O = 12 To 1 Step -2
            vMeses(6, O) = 1
        Next O
        'Periodos a Cumplir Trimestral
        For O = 12 To 1 Step -4
            vMeses(4, O) = 1
        Next O
        'Periodos a Cumplir Semestral
        'For O = 12 To Step -16
        '    vMeses(2, O) = 1
        'Next O
        'Periodos a Cumplir Anual
        For O = 1 To 12 Step 12
            vMeses(1, O) = 1
        Next O

        cAgendas = New Collection

        'encuentra las obligaciones de este rfc
        Query = "Select taxcatobligacion.id, taxcatobligacion.idtipo, taxcatobligacion.codigo, taxcatobligacion.obligacion, taxcatobligacion.plazomeses, taxcatobligacion.anual, taxcatobligacion.vecesanio, taxrfcobligacion.ejercicio " &
        " from taxcatobligacion, taxrfcobligacion where taxcatobligacion.id=taxrfcobligacion.idobligacion " &
        " and taxrfcobligacion.idrfc=" & IdRFC & " order by ejercicio, Codigo"

        If ejercicio = 0 Then 'Todos
            Filtroejercicio = ""
            EjeIni = CLng(EjeIni)
            EjeFin = CLng(EjeFin)
        Else
            Filtroejercicio = " and taxmovtos.ejercicio=" & ejercicio
            EjeIni = ejercicio
            EjeFin = ejercicio
        End If

        PerActual = Month(Fecha)
        EjeActual = Year(Fecha)

        'Rs.Open Query, VBASigo.Con
        R = 1
        Using Con = New SqlCommand(Query, FC_Con)
            Using Rs = Con.ExecuteReader()
                Do While Rs.Read()
                    'revisa que esten terminadas
                    Que = "Select taxmovtos.id, taxmovtos.ckini,taxmovtos.ckfin, taxcatestados.obligacion, taxcatestados.clave, taxcatestados.estado, taxmovtos.ejercicio, taxmovtos.periodo, taxmovtos.fechareg from taxmovtos, taxcatestados where taxcatestados.id=taxmovtos.idestado " &
                    " and taxmovtos.ckfin=0 and taxmovtos.idobligacion=" & Rs(0) & " and idrfc=" & IdRFC & Filtroejercicio & " order by Ejercicio,idobligacion, idestado"
                    Using Con2 = New SqlCommand(Que, FC_Con)
                        Using Rs2 = Con2.ExecuteReader()
                            Do While Rs2.Read()
                                dAgenda = New clObligaciones
                                dAgenda.idobligacion = Trim(Rs(0))
                                dAgenda.consecutivo = R
                                dAgenda.claveobligacion = Trim(Rs(2))
                                dAgenda.obligacion = Trim(Rs(3))
                                dAgenda.tipo = vTipos(Trim(Rs(1)))
                                'If vTipos(Trim(Rs(1))) <> "Permanente" Then
                                If dAgenda.tipo <> "Permanente" Then
                                    dAgenda.tipo = vAnual(Trim(Rs(5)))
                                End If
                                dAgenda.claveestado = Trim(Rs2(4))
                                dAgenda.estado = Trim(Rs2(5))
                                dAgenda.ejercicio = Trim(Rs2(6))
                                dAgenda.periodo = vPeriodos(Trim(Rs2(7)))

                                If fecMayor < Rs2("fechareg") Then
                                    fecMayor = Rs2("fechareg")
                                End If

                                cAgendas.Add(dAgenda)
                                R = R + 1
                            Loop
                        End Using
                    End Using

                    ''Tipo Periodicas(No Permanentes), No eventuales, Sin Cumplimiento
                    'por cada ejercicio
                    For e = EjeIni To EjeFin
                        If e < EjeActual Then
                            MesFin = 12
                        Else
                            MesFin = PerActual
                        End If
                        If Rs(5) = 1 Then
                            MesFin = 1
                        End If

                        'Tipo Periodicas(No Permanentes), No eventuales, Sin Cumplimiento, Del Ejercicio
                        If Rs(1) = 2 And Rs(5) <> 3 And Rs(7) = e Then
                            'por cada periodo
                            For P = 1 To MesFin
                                If Rs(5) = 1 Then
                                    xP = 13 'periodo de las anuales
                                Else
                                    xP = P
                                End If
                                'de acuerdo a VecesAnio, revisa si el mes trae obligacion
                                'revisa que el mes actual sea menor igual a el periodo mas plazo de cumplimiento
                                If (vMeses(Rs(6), P) = 1 And (PerActual >= (P + Rs(4)) And e = EjeActual)) Or e < EjeActual Then
                                    Que = "Select taxmovtos.id, taxcatestados.clave, taxcatestados.estado, taxmovtos.ejercicio, taxmovtos.periodo from taxmovtos, taxcatestados " &
                                    "where taxcatestados.id=taxmovtos.idestado " &
                                    " and taxmovtos.idobligacion=" & Rs(0) & " and taxcatestados.obligacion=1 and taxmovtos.ckfin=1 " &
                                    "and taxmovtos.Ejercicio=" & e & " and periodo=" & xP & " and taxmovtos.idrfc=" & IdRFC & " order by ejercicio, periodo, idestado"
                                    'RsMov.Open Que, VBASigo.Con
                                    Using Con2 = New SqlCommand(Que, FC_Con)
                                        Using Rs2 = Con2.ExecuteReader()
                                            If Not Rs2.HasRows Then
                                                Rs2.Read()
                                                dAgenda = New clObligaciones
                                                dAgenda.idobligacion = Trim(Rs(0))
                                                dAgenda.consecutivo = R
                                                dAgenda.claveobligacion = Trim(Rs(2))
                                                dAgenda.obligacion = Trim(Rs(3))
                                                dAgenda.tipo = vAnual(Trim(Rs(5)))
                                                dAgenda.claveestado = "*"
                                                dAgenda.estado = "Cumplimiento"
                                                dAgenda.ejercicio = e
                                                If Rs(5) <> 1 Then
                                                    dAgenda.periodo = vPeriodos(P)
                                                End If
                                                cAgendas.Add(dAgenda)
                                                R = R + 1
                                            End If
                                        End Using
                                    End Using
                                End If
                            Next P
                        End If
                    Next e
                Loop
            End Using
        End Using
        ACount = R
    End Sub

    Sub EjecutaCumplimiento(wb As Excel.Workbook, IdRFC As Integer, ejercicio As Integer, idMod As Integer, idSer As Integer)
        Dim Query As String
        Dim Corto As String
        Dim sRFC As String
        Dim SuperIndices As Integer
        Dim Col As Integer, sCol As Char
        Dim NormaAnt As String
        Dim Fila As Integer
        Dim ext As String = ""
        Dim Array() As String

        'generales
        Query = "Select * from taxconfig"
        Using Con = New SqlCommand(Query, FC_Con)
            Using Rs = Con.ExecuteReader()
                If Rs.HasRows Then
                    Rs.Read()
                    SuperIndices = Rs(1)
                Else
                    MsgBox("Error en Configuración", vbCritical, "Error")
                    Exit Sub
                End If
            End Using
        End Using

        Query = "Select * from taxrfc where id=" & IdRFC
        Using Con = New SqlCommand(Query, FC_Con)
            Using Rs = Con.ExecuteReader()
                If Rs.HasRows Then
                    Rs.Read()
                    Corto = Trim(Rs(3))
                    sRFC = Trim(Rs(1))
                Else
                    MsgBox("Error en el Catalogo de RFC", vbExclamation, "Error")
                    Exit Sub
                End If
            End Using
        End Using


        Col = wb.ActiveSheet.Range("z5").End(Excel.XlDirection.xlToLeft).Column
        sCol = Chr(Col + 64)

        'limpia la hoja
        wb.ActiveSheet.Range("a6:z100") = ""
        With wb.ActiveSheet.Range("a6:z100")
            .Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Interior.Pattern = Excel.XlPattern.xlPatternNone
            .Interior.TintAndShade = 0
            .Interior.PatternTintAndShade = 0
            .Font.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        End With
        'Quita Sangrias
        wb.ActiveSheet.Range("b6:b100").IndentLevel = 0

        'Arma la tabla
        'Imprime las Obligaciones Periodocas (Cumplimiento)
        Query = "Select taxrfcobligacion.idobligacion, taxcatobligacion.codigo, taxcatobligacion.obligacion, taxcatnormas.norma from " &
        "TaxRFCObligacion, TaxCatObligacion, TaxCatNormas " &
        "Where taxcatnormas.id=taxcatobligacion.idnorma and taxcatobligacion.id=taxrfcobligacion.idobligacion " &
        "and taxcatobligacion.idtipo=2 and taxrfcobligacion.idrfc=" & IdRFC & " and taxrfcobligacion.ejercicio=" & ejercicio &
        " order by idnorma, codigo"

        NormaAnt = ""
        Fila = 6
        Using Con = New SqlCommand(Query, FC_Con)
            Using Rs = Con.ExecuteReader()
                Do While Rs.Read()
                    If NormaAnt <> Trim(Rs(3)) Then
                        wb.ActiveSheet.Cells(Fila, 2) = Trim(Rs(3))
                        NormaAnt = Trim(Rs(3))
                        'bordes
                        With wb.ActiveSheet.Range("B" & CStr(Fila) & ":" & sCol & CStr(Fila)).Borders(Excel.XlBordersIndex.xlEdgeTop)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With
                        With wb.ActiveSheet.Range("B" & CStr(Fila) & ":" & sCol & CStr(Fila)).Borders(Excel.XlBordersIndex.xlEdgeBottom)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With

                        Fila = Fila + 1
                    End If

                    wb.ActiveSheet.Cells(Fila, 1) = Rs(0) 'idobligacion
                    wb.ActiveSheet.Cells(Fila, 2) = Trim(Rs(1)) & " " & Trim(Rs(2))
                    wb.ActiveSheet.Cells(Fila, 2).IndentLevel = 2
                    With wb.ActiveSheet.Range("B" & CStr(Fila) & ":" & sCol & CStr(Fila))
                        With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlHairline
                        End With
                        With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlHairline
                        End With
                        With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlHairline
                        End With
                        With .Borders(Excel.XlBordersIndex.xlInsideVertical)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlHairline
                        End With
                    End With
                    Fila = Fila + 1
                Loop
            End Using
        End Using

        Dim vIxPeriodo(3000)
        Dim m As Integer
        m = 1
        Col = 3
        'Do While CStr(wb.ActiveSheet.Cells(3, Col)) <> vbEmpty
        Do While CStr(wb.ActiveSheet.Cells(5, Col).value) <> ""
            vIxPeriodo(m) = Col
            m = m + 1
            Col = Col + 1
        Loop

        Dim vMovtos(1000, 20)
        Dim vObligaciones(1000, 3)
        Dim O As Integer
        O = 0
        'matriz indexada
        Query = "Select taxmovtos.idobligacion, taxcatestados.clave, taxmovtos.ckini, taxmovtos.ckfin, taxmovtos.nArchIni, taxmovtos.nArchFin, taxmovtos.ejercicio, taxmovtos.periodo, taxcatestados.estado, taxmovtos.id from taxmovtos, taxcatobligacion, taxcatestados " &
        "where taxcatobligacion.id=taxmovtos.idobligacion and taxcatestados.id=taxmovtos.idestado and idrfc=" & IdRFC & " and idtipo=2 and ejercicio=" & ejercicio & " order by idestado"
        'MsgBox Query
        Using Con = New SqlCommand(Query, FC_Con)
            Using Rs = Con.ExecuteReader()
                Do While Rs.Read()
                    If SuperIndices Then
                        vMovtos(Rs(0), vIxPeriodo(Rs(7))) = vMovtos(Rs(0), vIxPeriodo(Rs(7))) & Trim(Rs(1)) & "(" & Rs(4) + Rs(5) & ")"
                    Else
                        vMovtos(Rs(0), vIxPeriodo(Rs(4))) = vMovtos(Rs(0), vIxPeriodo(Rs(7))) & Trim(Rs(1))
                    End If
                    vObligaciones(O, 0) = Rs("id") 'idmovto
                    vObligaciones(O, 1) = Rs("idobligacion")
                    vObligaciones(O, 2) = Rs("periodo")
                    vObligaciones(O, 3) = Rs("estado")
                    O = O + 1
                Loop
            End Using
        End Using

        With wb.Styles.Add("Hyperlink")
            .IncludeNumber = False
            .IncludeFont = False
            .IncludeAlignment = False
            .IncludeBorder = False
            .IncludePatterns = False
            .IncludeProtection = False
        End With

        'Imprime
        Dim UltF As Integer, uFil As Integer, impreso As Boolean
        UltF = wb.ActiveSheet.Range("a65000").End(Excel.XlDirection.xlUp).Row
        uFil = UltF + 2
        For F = 6 To UltF
            Col = 3
            impreso = False
            Do While CStr(wb.ActiveSheet.Cells(5, Col).value) <> ""
                wb.ActiveSheet.Cells(F, Col) = vMovtos(wb.ActiveSheet.Cells(F, 1).value, Col)
                If wb.ActiveSheet.Cells(F, Col).value <> "" Then

                    For i As Integer = 0 To O
                        If CInt(vObligaciones(i, 1)) = CInt(wb.ActiveSheet.Cells(F, 1).value) Then
                            Using Con = New SqlCommand("SELECT c.fecha, c.ruta, c.ruta_original, c.tipo, c.ejercicio, c.periodo, c.iddigital, c.numero1
                                                    FROM zClipExped c WHERE c.numero1 = " & CInt(vObligaciones(i, 0)) & " and c.idcuenta = " & IdRFC & " and ejercicio = " & ejercicio & " and periodo = " & (Col - 2) & " and c.idmodulo = " & idMod & " ORDER BY c.fecha DESC", FC_SQL)
                                Using Rs = Con.ExecuteReader()
                                    Do While Rs.Read()
                                        Array = Rs("ruta").Split(".")
                                        ext = Array(Array.Count - 1)
                                        If impreso = False Then
                                            uFil = uFil + 1
                                            wb.ActiveSheet.cells(uFil, 2) = wb.ActiveSheet.Cells(F, 2).value
                                            wb.ActiveSheet.Hyperlinks.Add(Anchor:=wb.ActiveSheet.Range(Col_Letter(CInt(Col)) & F), Address:="", SubAddress:=
                                                    "Hoja1!B" & uFil)

                                            wb.ActiveSheet.Hyperlinks.Add(Anchor:=wb.ActiveSheet.Range("B" & uFil), Address:="", SubAddress:=
                                                    "Hoja1!B" & F)
                                            FormatoHipervinculo(wb, 2, uFil)

                                            impreso = True
                                        Else
                                            wb.ActiveSheet.Hyperlinks.Add(Anchor:=wb.ActiveSheet.Range(Col_Letter(CInt(Col)) & F), Address:="", SubAddress:=
                                                    "Hoja1!B" & uFil)
                                        End If

                                        If Not IsDBNull(Rs("iddigital")) Then
                                            uFil = uFil + 1
                                            'CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Col - 2)
                                            wb.ActiveSheet.cells(uFil, 2) = UCase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Col - 2)) & " " & ejercicio
                                            wb.ActiveSheet.cells(uFil, 3) = "'" & Rs("fecha") & " (" & vObligaciones(i, 3) & " " & IIf(Rs("tipo") = 2, "Final", "Inicial") & ")"
                                            wb.ActiveSheet.cells(uFil, 7) = Rs("ruta_original") & "." & ext
                                            wb.ActiveSheet.range(Col_Letter(7) & uFil & ":" & Col_Letter(11) & uFil).Merge
                                            wb.ActiveSheet.Hyperlinks.Add(Anchor:=wb.ActiveSheet.Range(Col_Letter(CInt(7)) & uFil), Address:=getURLCloud(Rs("iddigital")))
                                            FormatoHipervinculo(wb, 7, uFil)
                                        End If
                                    Loop
                                End Using
                            End Using
                        End If
                    Next
                End If
                Col = Col + 1
            Loop
        Next F

        'Col = wb.ActiveSheet.Range("z5").End(Excel.XlDirection.xlToLeft).Column
        'FormatoHoja(wb, uFil, Col)

        'wb.Styles.Add("Hyperlink").IncludeFont = True
        '.IncludeNumber = False
        '.IncludeFont = True
        '.IncludeAlignment = False
        '.IncludeBorder = False
        '.IncludePatterns = False
        '.IncludeProtection = False
        'End With




        'Procedimiento para ajustar formatos superindices
        If SuperIndices Then
            'Hoja = ActiveSheet.Name
            'UltF = wb.ActiveSheet.Range("b65000").End(Excel.XlDirection.xlUp).Row
            For F = 6 To UltF
                Col = 3
                Do While wb.ActiveSheet.Cells(5, Col).value <> ""
                    If wb.ActiveSheet.Cells(F, Col).value <> "" Then
                        FormatoSuperIndice(wb, F, Col, idSer)
                    End If
                    Col = Col + 1
                Loop
            Next F
        End If

    End Sub

    Sub FormatoHipervinculo(wb As Excel.Workbook, Col As Integer, F As Integer)
        Dim Columna As String
        Columna = Col_Letter(CInt(Col))
        wb.ActiveSheet.range(Columna & F).Font.Bold = True
        wb.ActiveSheet.range(Columna & F).Font.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle
        wb.ActiveSheet.range(Columna & F).Font.ThemeColor = Excel.XlThemeColor.xlThemeColorAccent1
    End Sub

    Sub FormatoSuperIndice(wb As Excel.Workbook, Fila As Integer, Columna As Integer, idSer As Integer)
        Dim vSuperIndices(100, 20)
        Dim vClaves(100, 20)
        Dim K As Integer, j As Integer
        Dim Marca As String
        Dim Li As Integer, Lf As Integer
        Dim F As Integer, Col As Integer

        'ubicaciones de los parentesis
        j = 0
        K = 1
        Marca = wb.ActiveSheet.Cells(Fila, Columna).value
        For L = 1 To Len(Marca)
            Li = InStr(L, Marca, "(")
            If Li <> 0 Then

                'ubicaciones de los parentesis
                j = j + 1
                L = Li + 1
                Lf = InStr(L, Marca, ")")
                If Lf <> 0 Then
                    j = j + 1
                    L = Lf + 1
                End If

            End If
            vSuperIndices(F, Col) = vSuperIndices(F, Col) & Li - (j - 2) & "|" & Lf - (j - 1) & ";"
            vClaves(F, Col) = vClaves(F, Col) & K & "|" & Li - (j - 2) & ";"
            K = Lf - (j - 1)
        Next L

        'Superindices

        'quita parentesis
        wb.ActiveSheet.Cells(Fila, Columna) = Replace(Marca, "(", "")
        wb.ActiveSheet.Cells(Fila, Columna) = Replace(wb.ActiveSheet.Cells(Fila, Columna).value, ")", "")

        Dim spi()
        Dim Clv()
        Dim lt()
        Dim lc()
        Dim x As Integer, y As Integer
        Dim u As Integer, w As Integer
        Dim Clave As String
        spi = Split(vSuperIndices(F, Col), ";")
        Clv = Split(vClaves(F, Col), ";")
        For s = 0 To UBound(spi) - 1
            'por cada superindice
            lt = Split(spi(s), "|")
            x = lt(0)
            y = lt(1) - lt(0)
            wb.ActiveSheet.Cells(Fila, Columna).Characters(Start:=x, Length:=y).Font.Superscript = True
            'por cada clave
            lc = Split(Clv(s), "|")
            u = lc(0)
            w = lc(1) - lc(0)
            Clave = Mid(wb.ActiveSheet.Cells(Fila, Columna).value, u, w)
            If EstaPendiente(wb, Clave, Fila, Columna, idSer) Then
                wb.ActiveSheet.Cells(Fila, Columna).Characters(Start:=u, Length:=w).Font.Color = -16776961
            End If
        Next s

    End Sub

    Function EstaPendiente(wb As Excel.Workbook, Clave As String, Fila As Integer, Columna As Integer, idSer As Integer) As Boolean
        Dim IdObligacion As Long
        Dim ejercicio As Long
        Dim periodo As String
        Dim sPer As String
        Dim o As clObligaciones
        IdObligacion = wb.ActiveSheet.Cells(Fila, 1).value

        If idSer <> SerExped_Permanente Then
            periodo = wb.ActiveSheet.Cells(5, Columna).value
            ejercicio = CLng(Replace(wb.ActiveSheet.Range("b5").value, "Ejercicio ", ""))
        Else
            ejercicio = wb.ActiveSheet.Cells(4, Columna).value
            periodo = ""
        End If

        EstaPendiente = False

        For Each o In cAgendas
            sPer = ""
            sPer = UCase(o.periodo)
            If o.tipo = "Anual" Then
                sPer = UCase(o.tipo)
            End If
            If CLng(o.idobligacion) = IdObligacion And o.claveestado = Clave And sPer = periodo And CLng(o.ejercicio) = ejercicio Then
                EstaPendiente = True
                Exit For
            End If
        Next

        'For R = 1 To ACount
        '    sPer = UCase(vAgenda(R, 8))
        '    If vAgenda(R, 4) = "Anual" Then
        '        sPer = UCase(vAgenda(R, 4))
        '    End If
        '    If CLng(vAgenda(R, 0)) = IdObligacion And vAgenda(R, 5) = Clave And sPer = periodo And CLng(vAgenda(R, 7)) = ejercicio Then
        '        EstaPendiente = True
        '        Exit For
        '    End If
        'Next R
    End Function

    Sub MarcaPeriodicasPendientes(wb As Excel.Workbook)
        Dim UltF As Integer
        Dim IdObligacion As Long
        Dim Col As Integer
        Dim periodo As String
        Dim sPer As String
        Dim o As clObligaciones
        wb.ActiveSheet.Range("b7:z100").Interior.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic

        UltF = wb.ActiveSheet.Range("b65000").End(Excel.XlDirection.xlUp).Row
        For F = 5 To UltF
            IdObligacion = wb.ActiveSheet.Cells(F, 1).value
            If IdObligacion <> 0 Then
                Col = 3
                Do While CStr(wb.ActiveSheet.Cells(5, Col).value) <> ""
                    periodo = wb.ActiveSheet.Cells(5, Col).value
                    'lo busca en la lista
                    For Each o In cAgendas
                        sPer = UCase(o.periodo)
                        If o.tipo = "Anual" Then
                            sPer = UCase(o.tipo)
                        End If
                        If o.claveestado = "*" And CLng(o.idobligacion) = IdObligacion And sPer = periodo Then
                            With wb.ActiveSheet.Cells(F, Col).Interior
                                .Pattern = Excel.XlPattern.xlPatternSolid
                                .PatternColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                                .ThemeColor = Excel.XlThemeColor.xlThemeColorAccent2
                                .TintAndShade = 0.599993896298105
                                .PatternTintAndShade = 0
                            End With
                            Exit For
                        End If
                    Next
                    'For R = 1 To ACount
                    '    sPer = UCase(vAgenda(R, 8))
                    '    If vAgenda(R, 4) = "Anual" Then
                    '        sPer = UCase(vAgenda(R, 4))
                    '    End If

                    '    If vAgenda(R, 5) = "*" And CLng(vAgenda(R, 0)) = IdObligacion And sPer = periodo Then
                    '        With wb.ActiveSheet.Cells(F, Col).Interior
                    '            .Pattern = Excel.XlPattern.xlPatternSolid
                    '            .PatternColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                    '            .ThemeColor = Excel.XlThemeColor.xlThemeColorAccent2
                    '            .TintAndShade = 0.599993896298105
                    '            .PatternTintAndShade = 0
                    '        End With
                    '        Exit For
                    '    End If
                    'Next R
                    Col = Col + 1
                Loop
            End If
        Next F
    End Sub

    Sub EjecutaExpediente(wb As Excel.Workbook, IDRFC As Long, idSer As Integer, idMod As Integer)
        Dim Query As String, Corto As String, sRFC As String, NormaAnt As String
        Dim SuperIndices As Integer, Col As Integer, Fila As Integer
        Dim sCol As Char
        Dim ext As String = ""
        Dim Array() As String

        'generales
        Query = "Select * from taxconfig"
        Using Con = New SqlCommand(Query, FC_Con)
            Using Rs = Con.ExecuteReader()
                If Rs.HasRows Then
                    Rs.Read()
                    SuperIndices = Rs(1)
                    wb.ActiveSheet.Range("A1") = SuperIndices
                Else
                    MsgBox("Error en Configuración", vbCritical, "Error")
                    Exit Sub
                End If
            End Using
        End Using


        Query = "Select * from taxrfc where id=" & IDRFC
        Using Con = New SqlCommand(Query, FC_Con)
            Using Rs = Con.ExecuteReader()
                If Rs.HasRows Then
                    Rs.Read()
                    Corto = Trim(Rs(3))
                    sRFC = Trim(Rs(1))
                Else
                    MsgBox("Error en el Catalogo de RFC", vbExclamation, "Error")
                    Exit Sub
                End If
            End Using
        End Using

        'identifica al contribuyente
        'wb.ActiveSheet.range("B1") = Corto
        'wb.ActiveSheet.range("B2") = sRFC
        wb.ActiveSheet.range("A3") = IDRFC

        'encabezados de Ejercicios
        'Muestraejercicios sRFC

        Col = wb.ActiveSheet.Range("Z4").End(Excel.XlDirection.xlToLeft).Column
        sCol = Chr(Col + 64)


        'limpia la hoja
        wb.ActiveSheet.range("a5:z100") = ""
        With wb.ActiveSheet.Range("A5:Z100")
            .Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            .Font.ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
        End With

        'Quita Sangrias
        wb.ActiveSheet.Range("B5:B100").IndentLevel = 0

        'Arma la tabla
        'Imprime las Obligaciones Permanentes (Tipo expediente)
        Query = "Select taxrfcobligacion.idobligacion, taxcatobligacion.codigo, taxcatobligacion.obligacion, taxcatnormas.norma from " &
        "TaxRFCObligacion, TaxCatObligacion, TaxCatNormas " &
        "Where taxcatnormas.id=taxcatobligacion.idnorma and taxcatobligacion.id=taxrfcobligacion.idobligacion " &
        "and taxcatobligacion.idtipo=1 and taxrfcobligacion.idrfc=" & IDRFC &
        "order by idnorma, codigo"

        NormaAnt = ""
        Fila = 5
        Using Con = New SqlCommand(Query, FC_Con)
            Using Rs = Con.ExecuteReader()
                Do While Rs.Read()
                    'encabezado
                    If NormaAnt <> Trim(Rs(3)) Then
                        wb.ActiveSheet.Cells(Fila, 2) = Trim(Rs(3))
                        NormaAnt = Trim(Rs(3))
                        'bordes
                        With wb.ActiveSheet.Range("B" & CStr(Fila) & ":" & sCol & CStr(Fila)).Borders(Excel.XlBordersIndex.xlEdgeTop)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With
                        With wb.ActiveSheet.Range("B" & CStr(Fila) & ":" & sCol & CStr(Fila)).Borders(Excel.XlBordersIndex.xlEdgeBottom)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlThin
                        End With

                        Fila = Fila + 1
                    End If
                    'Obligaciones
                    wb.ActiveSheet.Cells(Fila, 1) = Rs(0) 'idobligacion
                    wb.ActiveSheet.Cells(Fila, 2) = Trim(Rs(1)) & " " & Trim(Rs(2))
                    wb.ActiveSheet.Cells(Fila, 2).IndentLevel = 2
                    With wb.ActiveSheet.Range("B" & CStr(Fila) & ":" & sCol & CStr(Fila))
                        With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlHairline
                        End With
                        With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlHairline
                        End With
                        With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlHairline
                        End With
                        With .Borders(Excel.XlBordersIndex.xlInsideVertical)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .ColorIndex = 0
                            .TintAndShade = 0
                            .Weight = Excel.XlBorderWeight.xlHairline
                        End With
                    End With
                    Fila = Fila + 1
                Loop
            End Using
        End Using


        'movimientos
        Dim vIxEjercicio(3000)
        Dim ejercicio As Integer
        Col = 3
        Do While CStr(wb.ActiveSheet.Cells(4, Col).value) <> ""
            ejercicio = wb.ActiveSheet.Cells(4, Col).value
            vIxEjercicio(ejercicio) = Col
            Col = Col + 1
        Loop


        Dim vMovtos(1000, 20)
        Dim vObligaciones(1000, 3)
        Dim O As Integer
        O = 0

        'matriz indexada
        Query = "Select taxmovtos.idobligacion, taxcatestados.clave, taxmovtos.ckini, taxmovtos.ckfin, taxmovtos.nArchini,taxmovtos.nArchfin, taxmovtos.ejercicio, taxcatestados.estado, taxmovtos.id from taxmovtos, taxcatobligacion, taxcatestados " &
        "where taxcatobligacion.id=taxmovtos.idobligacion and taxcatestados.id=taxmovtos.idestado and idrfc=" & IDRFC & " and idtipo=1 order by idestado"
        Using Con = New SqlCommand(Query, FC_Con)
            Using Rs = Con.ExecuteReader()
                Do While Rs.Read()
                    If SuperIndices Then
                        vMovtos(Rs(0), vIxEjercicio(Rs(6))) = vMovtos(Rs(0), vIxEjercicio(Rs(6))) & Trim(Rs(1)) & "(" & Rs(5) + Rs(4) & ")"
                    Else
                        vMovtos(Rs(0), vIxEjercicio(Rs(6))) = vMovtos(Rs(0), vIxEjercicio(Rs(6))) & Trim(Rs(1))
                    End If
                    vObligaciones(O, 0) = Rs("id") 'idmovto
                    vObligaciones(O, 1) = Rs("idobligacion")
                    vObligaciones(O, 2) = Rs("ejercicio")
                    vObligaciones(O, 3) = Rs("estado")
                    O = O + 1
                Loop
            End Using
        End Using


        With wb.Styles.Add("Hyperlink")
            .IncludeNumber = False
            .IncludeFont = False
            .IncludeAlignment = False
            .IncludeBorder = False
            .IncludePatterns = False
            .IncludeProtection = False
        End With

        'Imprime
        Dim UltF As Integer, uFil As Integer, impreso As Boolean
        UltF = wb.ActiveSheet.Range("a65000").End(Excel.XlDirection.xlUp).Row
        uFil = UltF + 2
        For F = 5 To UltF
            Col = 3
            impreso = False
            Do While CStr(wb.ActiveSheet.Cells(4, Col).value) <> ""
                wb.ActiveSheet.Cells(F, Col) = vMovtos(wb.ActiveSheet.Cells(F, 1).value, Col)
                If wb.ActiveSheet.Cells(F, Col).value <> "" Then
                    For i As Integer = 0 To O
                        If CInt(vObligaciones(i, 1)) = CInt(wb.ActiveSheet.Cells(F, 1).value) Then
                            Using Con = New SqlCommand("SELECT c.fecha, c.ruta, c.ruta_original, c.tipo, c.ejercicio, c.periodo, c.iddigital, c.numero1
                                                    FROM zClipExped c WHERE c.numero1 = " & CInt(vObligaciones(i, 0)) & " and c.idcuenta = " & IDRFC & " and ejercicio = " & CInt(wb.ActiveSheet.Cells(4, Col).value) & " and c.idmodulo = " & idMod & " ORDER BY c.fecha DESC", FC_SQL)
                                Using Rs = Con.ExecuteReader()
                                    Do While Rs.Read()
                                        Array = Rs("ruta").Split(".")
                                        ext = Array(Array.Count - 1)
                                        If impreso = False Then
                                            uFil = uFil + 1
                                            wb.ActiveSheet.cells(uFil, 2) = wb.ActiveSheet.Cells(F, 2).value
                                            wb.ActiveSheet.Hyperlinks.Add(Anchor:=wb.ActiveSheet.Range(Col_Letter(CInt(Col)) & F), Address:="", SubAddress:=
                                                    "Hoja1!B" & uFil)
                                            wb.ActiveSheet.Hyperlinks.Add(Anchor:=wb.ActiveSheet.Range("B" & uFil), Address:="", SubAddress:=
                                                    "Hoja1!B" & F)
                                            FormatoHipervinculo(wb, 2, uFil)
                                            impreso = True
                                        Else
                                            wb.ActiveSheet.Hyperlinks.Add(Anchor:=wb.ActiveSheet.Range(Col_Letter(CInt(Col)) & F), Address:="", SubAddress:=
                                                    "Hoja1!B" & uFil)
                                        End If

                                        If Not IsDBNull(Rs("iddigital")) Then
                                            uFil = uFil + 1
                                            'CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Col - 2)
                                            wb.ActiveSheet.cells(uFil, 2) = UCase(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Col - 2)) & " " & ejercicio
                                            wb.ActiveSheet.cells(uFil, 3) = "'" & Rs("fecha") & " (" & vObligaciones(i, 3) & " " & IIf(Rs("tipo") = 2, "Final", "Inicial") & ")"
                                            wb.ActiveSheet.cells(uFil, 7) = Rs("ruta_original") & "." & ext
                                            wb.ActiveSheet.Hyperlinks.Add(Anchor:=wb.ActiveSheet.Range(Col_Letter(CInt(7)) & uFil), Address:=getURLCloud(Rs("iddigital")))
                                            FormatoHipervinculo(wb, 7, uFil)
                                        End If
                                    Loop
                                End Using
                            End Using
                        End If
                    Next
                End If
                Col = Col + 1
            Loop
        Next F


        'Col = wb.ActiveSheet.Range("Z4").End(Excel.XlDirection.xlToLeft).Column
        'FormatoHoja(wb, uFil, Col)

        'Procedimiento para ajustar formatos superindices
        If SuperIndices Then
            'Hoja = ActiveSheet.Name
            'UltF = wb.ActiveSheet.Range("b65000").End(Excel.XlDirection.xlUp).Row
            For F = 5 To UltF
                Col = 3
                Do While CStr(wb.ActiveSheet.Cells(4, Col).value) <> ""
                    If CStr(wb.ActiveSheet.Cells(F, Col).value) <> "" Then
                        FormatoSuperIndice(wb, F, Col, idSer)
                    End If
                    Col = Col + 1
                Loop
            Next F
        End If
    End Sub

End Module
