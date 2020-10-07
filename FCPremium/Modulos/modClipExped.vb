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
    Public cServicios As Collection
    Public cDocDig As Collection

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

    Public Function getPendientesSer(idMod As Integer) As Integer
        Dim p As Integer
        p = 0
        Using Con = New SqlCommand("SELECT count(e.id) AS pendientes FROM zClipExped e WHERE e.idmodulo =" & idMod & " and e.procesado = 0", FC_SQL)
            Using Rs = Con.ExecuteReader()
                If Rs.HasRows Then
                    Rs.Read()
                    p = Rs("pendientes")
                End If
            End Using
        End Using
        getPendientesSer = p
    End Function

    Public Sub imprimeEncabezado(wb As Excel.Workbook, idEmp As Integer, idSer As Integer, Optional Ejercicio As Integer = 0)
        Dim Fila As Integer, ColIni As Integer, ColFin As Integer
        Dim Query As String

        barCount = 250
        frmGeneraDoctos.pr.Value = barCount
        frmGeneraDoctos.pr.Refresh()

        Fila = 5
        With wb.ActiveSheet
            If idSer = 21 Then 'Empleados
                .Cells(Fila, 1) = "ID"
                .Cells(Fila, 2) = "Codigo"
                .Cells(Fila, 3) = "NSS"
                .Cells(Fila, 4) = "RFC"
                .Cells(Fila, 5) = "Nombre"
                .Range("B" & Fila).ColumnWidth = 7
                .Range("C" & Fila).ColumnWidth = 12
                .Range("D" & Fila).ColumnWidth = 16
                .Range("E" & Fila).ColumnWidth = 35
                ColIni = 6
            ElseIf idSer = 22 Then 'Periodos
                .Cells(Fila, 1) = "ID"
                .Cells(Fila, 2) = "Periodo"
                .Range("B" & Fila).ColumnWidth = 15
                .Range("E" & Fila).ColumnWidth = 35
                ColIni = 6
            ElseIf idSer = 23 Then 'Activos Fijos
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
                .Range("F" & Fila).ColumnWidth = 40
                ColIni = 7
            ElseIf idSer = 25 Then 'Bancos
                .Cells(2, 2) = "Expediente de Bancos a 12 Meses"
                .Cells(1, 14) = "Expediente de Bancos"
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

    Public Function Col_Letter(lngCol As Integer) As String
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

    Public Sub imprimeDatosRelacionados(wb As Excel.Workbook, idEmp As Integer, idSer As Integer, Optional Ejercicio As Integer = 0)

        getDocumentosCRM(idEmp, Ejercicio)

        Select Case idSer
            Case Is = 21 'Empleados
                imprimeEmpleados(wb, idEmp, idSer)
            Case Is = 22 'Periodos
                imprimeNomina(wb, idEmp, idSer)
            Case Is = 23 'Activos Fijos
                imprimeActivosFijos(wb, idEmp, idSer)
            Case Is = 25 'Bancos
                ImprimeBancos(wb, idEmp, idSer, Ejercicio)
        End Select
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

        FormatoHoja(wb)

        c = 0
        Fila = 8
        With wb.ActiveSheet
            ConEmpresaSQL(idEmp)

            '''TITULO CUENTA
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

        'Using cCon = New SqlCommand("SELECT TOP 1 codigo_serviciocrm FROM XMLDigTiposDoctoConfig WHERE id_serviciocrm = " & idSer, FC_SQL)
        'Using cCon = New SqlCommand("SELECT TOP 1 codigo_serviciocrm FROM zCEXTiposDocto WHERE id_serviciocrm = " & idSer, FC_SQL)
        '    Using aCr = cCon.ExecuteReader()
        '        aCr.Read()
        '        If aCr.HasRows Then
        '            'NomArc = Obtener_RFC(idEmp) & "_" & Ejercicio & "_" & Trim(aCr("codigo_serviciocrm"))
        NomArc = Obtener_RFC(idEmp) & "_" & Ejercicio & "_" & Trim(getCodServicio(idSer))
        '        End If
        '    End Using
        'End Using
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

    Public Sub imprimeActivosFijos(wb As Excel.Workbook, idEmp As Integer, idSer As Integer)
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

        FormatoHoja(wb)

        c = 0
        Fila = 6
        With wb.ActiveSheet
            ConEmpresaSQL(idEmp)
            ConEmpresaNom(idEmp)

            Query = "SELECT a.Id, a.codigo, a.activofijo, a.fechaadqui, a.valornominal, t.tipo 
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

                        'Query = "SELECT fecha, nombrearchivo, ruta_cloud, idtipodocto FROM XMLDigAsocExped WHERE idelemento = " & aCr("Id") & " and idservicio = " & idSer
                        Query = "SELECT fecha, ruta, ruta_original, tipo, iddigital FROM zClipExped WHERE idcuenta = " & aCr("Id") & " and idservicio = " & idSer
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

            .cells(3, 2) = "Por Activo"
            .cells(4, 2) = "Al " & Format(fecMayor, "dd-MM-yyyy")

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

        'FormatoHoja(wb, Fila, wb.ActiveSheet.UsedRange.Columns.Count)

        'Using cCon = New SqlCommand("SELECT TOP 1 codigo_serviciocrm FROM XMLDigTiposDoctoConfig WHERE id_serviciocrm = " & idSer, FC_SQL)
        '    Using aCr = cCon.ExecuteReader()
        '        aCr.Read()
        '        If aCr.HasRows Then
        '            NomArc = Obtener_RFC(idEmp) & "_" & Trim(aCr("codigo_serviciocrm"))
        NomArc = Obtener_RFC(idEmp) & "_" & Trim(getCodServicio(idSer))
        '        End If
        '    End Using
        'End Using

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

        FormatoHoja(wb)

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
                        Query = "SELECT fecha, ruta, ruta_original, tipo, iddigital FROM zClipExped WHERE idcuenta = " & aCr("idperiodo") & " and idservicio = " & idSer
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

            .cells(3, 2) = "Por Periodo"
            .cells(4, 2) = "Al " & Format(fecMayor, "dd-MM-yyyy")

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

        'FormatoHoja(wb, Fila, wb.ActiveSheet.UsedRange.Columns.Count)


        'Using cCon = New SqlCommand("SELECT TOP 1 codigo_serviciocrm FROM XMLDigTiposDoctoConfig WHERE id_serviciocrm = " & idSer, FC_SQL)
        '    Using aCr = cCon.ExecuteReader()
        '        aCr.Read()
        '        If aCr.HasRows Then
        '            NomArc = Obtener_RFC(idEmp) & "_" & Trim(aCr("codigo_serviciocrm"))
        NomArc = Obtener_RFC(idEmp) & "_" & Trim(getCodServicio(idSer))
        '        End If
        '    End Using
        'End Using

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

        FormatoHoja(wb)

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
                        Query = "SELECT fecha, ruta, ruta_original, tipo, iddigital FROM zClipExped WHERE idcuenta = " & aCr("idempleado") & " and idservicio = " & idSer
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

            .cells(3, 2) = "Por Empleado"
            .cells(4, 2) = "Al " & Format(fecMayor, "dd-MM-yyyy")

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

        'FormatoHoja(wb, Fila, wb.ActiveSheet.UsedRange.Columns.Count)

        'Using cCon = New SqlCommand("SELECT TOP 1 codigo_serviciocrm FROM XMLDigTiposDoctoConfig WHERE id_serviciocrm = " & idSer, FC_SQL)
        '    Using aCr = cCon.ExecuteReader()
        '        aCr.Read()
        '        If aCr.HasRows Then
        '            NomArc = Obtener_RFC(idEmp) & "_" & Trim(aCr("codigo_serviciocrm"))
        NomArc = Obtener_RFC(idEmp) & "_" & Trim(getCodServicio(idSer))
        '        End If
        '    End Using
        'End Using

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
    Public Sub FormatoHoja(wb As Excel.Workbook)
        With wb
            '.ActiveSheet.Range("A1:" & Col_Letter(ColF) & FilaF).Select
            '.ActiveSheet.Range(Col_Letter(ColF) & FilaF).Activate
            With .ActiveSheet.PageSetup
                .PrintTitleRows = ""
                .PrintTitleColumns = ""
            End With
            .ActiveSheet.PageSetup.PrintArea = ""
            With .ActiveSheet.PageSetup
                .LeftMargin = wb.Application.InchesToPoints(0.25)
                .RightMargin = wb.Application.InchesToPoints(0.25)
                .TopMargin = wb.Application.InchesToPoints(0.75)
                .BottomMargin = wb.Application.InchesToPoints(0.75)
                .HeaderMargin = wb.Application.InchesToPoints(0.3)
                .FooterMargin = wb.Application.InchesToPoints(0.3)
                .Orientation = Excel.XlPageOrientation.xlLandscape
                .PaperSize = Excel.XlPaperSize.xlPaperLetter
                .Zoom = 100
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

    'Public Function getTipoDocto(idEmp As Integer, idSer As Integer)
    '    Dim nombre As String = ""
    '    Dim Query As String
    '    ConEmpresaSQL(idEmp)
    '    Query = "SELECT TOP (1) serviciocrm FROM XMLDigTiposDoctoConfig WHERE id_serviciocrm = " & idSer
    '    Using dCom = New SqlCommand(Query, FC_SQL)
    '        Using aCr = dCom.ExecuteReader()
    '            aCr.Read()
    '            If aCr.HasRows Then
    '                nombre = aCr("serviciocrm")
    '            End If
    '        End Using
    '    End Using
    '    getTipoDocto = nombre
    'End Function

    'Public Function getCodigoSer(ByVal idSer As Integer) As String
    '    Dim Query As String
    '    getCodigoSer = ""
    '    Query = "SELECT TOP 1 codigo_serviciocrm FROM XMLDigTiposDoctoConfig WHERE id_serviciocrm = " & idSer
    '    Using dCom = New SqlCommand(Query, FC_SQL)
    '        Using aCr = dCom.ExecuteReader()
    '            aCr.Read()
    '            If aCr.HasRows Then
    '                getCodigoSer = aCr("codigo_serviciocrm")
    '            End If
    '        End Using
    '    End Using
    'End Function

    Public Function Guarda_Doc(ByVal nomArchivo As String, FecF As Date, idSer As Integer, Optional Ejercicio As Integer = 0) As Integer
        Dim tipodoc As String = "", fechad As Date 'dQue As String
        Dim aPeriodo As Integer, aEjercicio As Integer, fechamod As Date
        Dim arch As String, nomAr As String, Query As String
        Dim idsubmenu As Integer
        'Dim respSincro As Boolean

        ConEmpresaSQL(IDEmp)

        'tipodoc = getCodigoSer(idSer)
        tipodoc = getCodServicio(idSer)
        idsubmenu = getIDSubMenu(idSer)

        'Query = "SELECT TOP 1 codigo_serviciocrm FROM XMLDigTiposDoctoConfig WHERE id_serviciocrm = " & idSer
        'Using dCom = New SqlCommand(Query, FC_SQL)
        '    Using aCr = dCom.ExecuteReader()
        '        aCr.Read()
        '        If aCr.HasRows Then
        '            tipodoc = aCr("codigo_serviciocrm")
        '        End If
        '    End Using
        'End Using

        'Query = "SELECT TOP 1 idsubmenu_destino FROM XMLDigAsocExped WHERE idservicio = " & idSer
        'Using dCom = New SqlCommand(Query, FC_SQL)
        '    Using aCr = dCom.ExecuteReader()
        '        aCr.Read()
        '        If aCr.HasRows Then
        '            idsubmenu = aCr("idsubmenu_destino")
        '        End If
        '    End Using
        'End Using

        'idsub = 63 'Balanzas y Anexos
        'tipodoc = "AVANCEP"
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


    Public Function Vincular_DocumentosExpedActivos(modDesk As Integer, idCuenta As Integer, idDigital As Integer,
                                                   Periodo As Integer, Ejercicio As Integer, tipoDocto As String, fecDocto As Date,
                                                   Ruta As String, RutaOriginal As String)
        Dim sQue As String, vinculo As Boolean
        vinculo = False
        Try
            sQue = "INSERT INTO zClipExped(" &
                        "idusuario, idmodulo, tipo, ejercicio, periodo, ruta, " &
                        "idcuenta, iddigital, ruta_original, fecha, fecha_reg) " &
                    "VALUES (" &
                        "" & GL_cUsuarioAPI.Iduser & ", " & modDesk & ", '" & tipoDocto & "', " & Ejercicio & "," &
                        "" & Periodo & ",'" & Ruta & "'," & idCuenta & ", " & idDigital & ", " &
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
                    Chr(34) & "fechaprocesado" & Chr(34) & ": " & Chr(34) & Now & Chr(34) & "," &
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

End Module
