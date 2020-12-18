Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Office.Interop
Public Class frmGeneraDoctos
    Private bLoaded As Boolean
    Public EjercicioExpBancos As Integer
    Private Sub frmGeneraDoctos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bLoaded = False
        ckTodos.Checked = True
        cargaDoctosPendientes()
        bLoaded = True
    End Sub
    Private Sub cargaDoctosPendientes()
        'Dim cQue As String
        Dim objList As New ListViewItem
        Dim s As clServicios

        ConEmpresaSQL(IDEmp)
        Me.dgServicios.Rows.Clear()
        For Each s In cServicios
            'dgServicios.Rows.Add(True, aCr("id_serviciocrm"), aCr("codigo_serviciocrm"), aCr("serviciocrm"), aCr("pendientes"), 0)
            dgServicios.Rows.Add(True, s.Idservicio, s.CodigoServicio, s.Servicio, getPendientesSer(s.Idfcmodulo, s.Idservicio), 0, s.Idfcmodulo)
        Next

        'cQue = "SELECT id_serviciocrm, codigo_serviciocrm, serviciocrm, sum(doctos_pendientes) as pendientes " &
        '        "FROM XMLDigTiposDoctoConfig GROUP BY serviciocrm, id_serviciocrm, codigo_serviciocrm"
        'Using dCom = New SqlCommand(cQue, FC_SQL)
        '    Using aCr = dCom.ExecuteReader()
        '        Do While aCr.Read()
        '            dgServicios.Rows.Add(True, aCr("id_serviciocrm"), aCr("codigo_serviciocrm"), aCr("serviciocrm"), aCr("pendientes"), 0)
        '        Loop
        '    End Using
        'End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub ckTodos_CheckedChanged(sender As Object, e As EventArgs) Handles ckTodos.CheckedChanged
        If bLoaded = False Then Exit Sub
        For Each Fila As DataGridViewRow In dgServicios.Rows
            Fila.Cells(0).Value = ckTodos.Checked
        Next
    End Sub

    Private Sub btGenera_Click(sender As Object, e As EventArgs) Handles btGenera.Click
        Dim idServicio As Integer
        Dim nomArch As String = ""
        Dim respSincro As Boolean
        Dim count As Integer
        Dim IDSubM As Integer
        Dim idModulo As Integer
        Dim Que As String
        'Dim aRut As String

        pr.Visible = True
        pr.Maximum = 1000
        pr.Minimum = 0

        Try
            EjercicioExpBancos = Year(Now)
            For Each Fila As DataGridViewRow In dgServicios.Rows
                NomArc = ""
                aRut = ""
                barCount = 0
                IDSubM = 0
                fecMayor = "#1/1/0001 12:00:00 AM#"
                respSincro = False
                pr.Value = barCount
                pr.Refresh()

                'If Fila.Cells(0).Value = True And Fila.Cells(4).Value <> 0 Then
                If Fila.Cells(0).Value = True Then
                    idServicio = Fila.Cells(1).Value
                    idModulo = Fila.Cells(6).Value
                    If idModulo = ModExped_Bancos Or idModulo = ModExped_Fiscales Or (idModulo = ModExped_Activos And idServicio = SerCalculosActivos) Then
                        If idModulo = ModExped_Bancos Then
                            Que = "SELECT ejercicio FROM zClipExped WHERE idmodulo = " & idModulo & " and procesado = 0 GROUP BY ejercicio"
                        ElseIf idModulo = ModExped_Activos Then
                            Que = "SELECT ejercicio FROM zClipExped WHERE idmodulo = " & idModulo & " and numero1 = " & SerCalculosActivos & " and procesado = 0 GROUP BY ejercicio"
                        Else
                            Que = "SELECT ejercicio FROM zClipExped WHERE idmodulo = " & idModulo & " and idcuenta = " & getIDTax(Obtener_RFC(IDEmp)) & " and procesado = 0 GROUP BY ejercicio"
                        End If
                        If idServicio <> SerExped_Permanente Then
                            Using cCon = New SqlCommand(Que, FC_SQL)
                                count = 0
                                Using Rs = cCon.ExecuteReader()
                                    Do While Rs.Read()
                                        EjercicioExpBancos = Rs("ejercicio")
                                        count += 1
                                    Loop
                                    If count > 1 Then
                                        frmEjerciciosBan.idMod = idModulo
                                        frmEjerciciosBan.ShowDialog()
                                    End If
                                End Using
                            End Using
                        End If
                        crearDocumentoPDF(idServicio, idModulo, EjercicioExpBancos)
                    Else
                        crearDocumentoPDF(idServicio, idModulo)
                    End If

                    If NomArc <> "" Then
                        nomArch = NomArc
                        If idModulo = ModExped_Bancos Then
                            IDSubM = Guarda_Doc(nomArch, Now(), idServicio, EjercicioExpBancos)
                            Using cCom = New SqlCommand("UPDATE zClipExped SET procesado = 1 WHERE idmodulo = " & idModulo & " and ejercicio = " & EjercicioExpBancos, FC_SQL)
                                cCom.ExecuteNonQuery()
                            End Using
                        ElseIf idModulo = ModExped_Fiscales Then
                            IDSubM = Guarda_Doc(nomArch, Now(), idServicio, EjercicioExpBancos)
                            If idServicio <> SerExped_Permanente Then
                                Using cCom = New SqlCommand("UPDATE zClipExped SET procesado = 1 WHERE idmodulo = " & idModulo & " and idcuenta = " & getIDTax(Obtener_RFC(IDEmp)) & " and periodo <> 0 and ejercicio = " & EjercicioExpBancos, FC_SQL)
                                    cCom.ExecuteNonQuery()
                                End Using
                            Else
                                Using cCom = New SqlCommand("UPDATE zClipExped SET procesado = 1 WHERE idmodulo = " & idModulo & " and idcuenta = " & getIDTax(Obtener_RFC(IDEmp)) & " and periodo = 0", FC_SQL)
                                    cCom.ExecuteNonQuery()
                                End Using
                            End If
                        ElseIf idModulo = ModExped_Activos Then
                            IDSubM = Guarda_Doc(nomArch, Now(), idServicio)
                            If idServicio = SerCalculosActivos Then
                                Using cCom = New SqlCommand("UPDATE zClipExped SET procesado = 1 WHERE idmodulo = " & idModulo & " and numero1 = " & idServicio & " And ejercicio = " & EjercicioExpBancos, FC_SQL)
                                    cCom.ExecuteNonQuery()
                                End Using
                            Else
                                Using cCom = New SqlCommand("UPDATE zClipExped SET procesado = 1 WHERE idmodulo = " & idModulo & " and (numero1 = " & idServicio & " or numero1 is null)", FC_SQL)
                                    cCom.ExecuteNonQuery()
                                End Using
                            End If
                        Else
                            IDSubM = Guarda_Doc(nomArch, Now(), idServicio)
                            Using cCom = New SqlCommand("UPDATE zClipExped SET procesado = 1 WHERE idmodulo = " & idModulo, FC_SQL)
                                cCom.ExecuteNonQuery()
                            End Using
                        End If
                        BuscaNoSincronizado(Obtener_RFC(IDEmp), getCodServicio(idServicio), Year(Now), Format(Month(Now), "00"), aRut, IDSubM)
                        Fila.Cells(4).Value = 0
                    End If
                End If
            Next
            pr.Value = 1000
            pr.Refresh()
            System.Threading.Thread.Sleep(1000)
            pr.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        'LCargando.Visible = False

    End Sub
    '    Private Function crearDocumentoPDF(idSer As Integer, idEmp As Integer, Periodo As Integer, Ejercicio As Integer) As String
    Private Sub crearDocumentoPDF(idSer As Integer, idMod As Integer, Optional Ejercicio As Integer = 0)
        Dim exApp As New Excel.Application
        Dim wb As Excel.Workbook
        Dim RutaDestino As String = ""
        Dim cQue As String = ""

        exApp.Visible = False
        exApp.DisplayAlerts = False

        wb = exApp.Workbooks.Add

        'exApp.Visible = True

        If idMod = ModExped_Bancos Or idMod = ModExped_Fiscales Or (idMod = ModExped_Activos And idSer = SerCalculosActivos) Then
            imprimeEncabezado(wb, IDEmp, idSer, idMod, Ejercicio)
            imprimeDatosRelacionados(wb, IDEmp, idSer, idMod, Ejercicio)
        Else
            imprimeEncabezado(wb, IDEmp, idSer, idMod)
            imprimeDatosRelacionados(wb, IDEmp, idSer, idMod)
        End If

        If NomArc <> "" Then
            barCount = 750
            pr.Value = barCount
            pr.Refresh()

            RutaDestino = FC_RutaSincronizada & "\" & Obtener_RFC(IDEmp) &
                    "\" & Get_NomCarpeta_Modulo(getIDModulo(idSer)) & "\" & Get_NomCarpeta_Menu(getIDMenu(idSer)) & "\" & Get_NomCarpeta_SubMenu(getIDSubMenu(idSer)) & "\" & NomArc
            aRut = Obtener_RFC(IDEmp) & "\" & Get_NomCarpeta_Modulo(getIDModulo(idSer)) & "\" & Get_NomCarpeta_Menu(getIDMenu(idSer)) & "\" & Get_NomCarpeta_SubMenu(getIDSubMenu(idSer))
            'exApp.Visible = True
            CrearPDF(exApp, RutaDestino & ".pdf")

            'Exit Sub
        End If

        wb.Close()
        exApp.DisplayAlerts = True
        exApp.Quit()

        releaseObject(wb)
        releaseObject(exApp)
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.WaitForPendingFinalizers()
            GC.Collect()
        End Try
    End Sub

    Private Sub CrearPDF(ByVal libro As Excel.Application, ByVal nombreFinal As String)
        Dim pmkr2 As AdobePDFMakerForOffice.PDFMaker

        pmkr2 = Nothing

        For Each a In libro.COMAddIns
            If InStr(UCase(a.Description), "PDFMAKER") > 0 Then
                pmkr2 = a.Object
                Exit For
            End If
        Next

        If pmkr2 Is Nothing Then
            MsgBox("Cannot Find PDFMaker add-in", vbOKOnly, "")
            Exit Sub
        End If

        Dim pdfname As String
        pdfname = nombreFinal

        Dim stng As AdobePDFMakerForOffice.ISettings
        pmkr2.GetCurrentConversionSettings(stng)


        stng.AddBookmarks = True
        stng.AddLinks = True
        stng.AddTags = True
        stng.ConvertAllPages = True
        stng.CreateFootnoteLinks = True
        stng.CreateXrefLinks = True
        stng.OutputPDFFileName = pdfname
        stng.PromptForPDFFilename = False
        stng.ShouldShowProgressDialog = False
        stng.ViewPDFFile = False

        stng.LayoutBasedOnPrinterSettings = True
        stng.PrintActivesheetOnly = False '' para imprimir todas las hojas

        pmkr2.CreatePDFEx(stng, 0)

        stng = Nothing
        pmkr2 = Nothing ' Discontinue associa

        KillProcess("acrodist.exe")
    End Sub

    Public Sub KillProcess(ByVal processName As String)
        On Error GoTo ErrHandler
        Dim oWMI
        Dim ret
        Dim sService
        Dim oWMIServices
        Dim oWMIService
        Dim oServices
        Dim oService
        Dim servicename

        oWMI = GetObject("winmgmts:")
        oServices = oWMI.InstancesOf("win32_process")

        For Each oService In oServices
            servicename = LCase(Trim(CStr(oService.Name) & ""))

            If InStr(1, servicename, LCase(processName), vbTextCompare) > 0 Then
                ret = oService.Terminate
            End If
        Next

        oServices = Nothing
        oWMI = Nothing
        Exit Sub
ErrHandler:
        Err.Clear()
    End Sub

    Private Sub dgServicios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgServicios.CellClick
        bLoaded = False

        If dgServicios.Item(0, dgServicios.CurrentRow.Index).Value = True Then
            dgServicios.Item(0, dgServicios.CurrentRow.Index).Value = False
            ckTodos.Checked = False
        Else
            ckTodos.Checked = True
            dgServicios.Item(0, dgServicios.CurrentRow.Index).Value = True
            For Each Fila As DataGridViewRow In dgServicios.Rows
                If Fila.Cells(0).Value = False Then
                    ckTodos.Checked = False
                End If
            Next
        End If

        bLoaded = True
    End Sub

    Private Sub dgServicios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgServicios.CellContentClick

    End Sub
End Class