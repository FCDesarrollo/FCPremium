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
        Dim cQue As String
        Dim objList As New ListViewItem
        Dim s As clServicios

        ConEmpresaSQL(IDEmp)
        Me.dgServicios.Rows.Clear()
        For Each s In cServicios
            'dgServicios.Rows.Add(True, aCr("id_serviciocrm"), aCr("codigo_serviciocrm"), aCr("serviciocrm"), aCr("pendientes"), 0)
            dgServicios.Rows.Add(True, s.Idservicio, s.CodigoServicio, s.Servicio, getPendientesSer(s.Idfcmodulo), 0, s.Idfcmodulo)
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
        'Dim aRut As String

        pr.Visible = True
        pr.Maximum = 1000
        pr.Minimum = 0

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
                If idModulo = 3 Then 'Bancos
                    'Using cCon = New SqlCommand("SELECT ejercicio FROM XMLDigAsocExped WHERE procesado = 0 GROUP BY ejercicio", FC_SQL)
                    Using cCon = New SqlCommand("SELECT ejercicio FROM zClipExped WHERE procesado = 0 GROUP BY ejercicio", FC_SQL)
                        count = 0
                        Using Rs = cCon.ExecuteReader()
                            Do While Rs.Read()
                                EjercicioExpBancos = Rs("ejercicio")
                                count += 1
                            Loop
                            If count > 1 Then
                                frmEjerciciosBan.ShowDialog()
                            End If
                        End Using
                    End Using
                    crearDocumentoPDF(idServicio, EjercicioExpBancos)
                Else
                    crearDocumentoPDF(idServicio)
                End If

                If NomArc <> "" Then
                    nomArch = NomArc
                    If idModulo = 3 Then
                        IDSubM = Guarda_Doc(nomArch, fecMayor, idServicio, EjercicioExpBancos)
                        Using cCom = New SqlCommand("UPDATE zClipExped SET procesado = 1 WHERE idmodulo = " & idModulo & " and ejercicio = " & EjercicioExpBancos, FC_SQL)
                            cCom.ExecuteNonQuery()
                        End Using
                    Else
                        IDSubM = Guarda_Doc(nomArch, fecMayor, idServicio)
                        Using cCom = New SqlCommand("UPDATE zClipExped SET procesado = 1 WHERE idmodulo = " & idModulo, FC_SQL)
                            cCom.ExecuteNonQuery()
                        End Using
                    End If
                    BuscaNoSincronizado(Obtener_RFC(IDEmp), getCodServicio(idServicio), Year(fecMayor), Format(Month(fecMayor), "00"), aRut, IDSubM)
                    Fila.Cells(4).Value = 0
                End If
            End If
        Next
        pr.Value = 1000
        pr.Refresh()
        System.Threading.Thread.Sleep(1000)
        pr.Visible = False
        'LCargando.Visible = False

    End Sub
    '    Private Function crearDocumentoPDF(idSer As Integer, idEmp As Integer, Periodo As Integer, Ejercicio As Integer) As String
    Private Sub crearDocumentoPDF(idSer As Integer, Optional Ejercicio As Integer = 0)
        Dim exApp As New Excel.Application
        Dim wb As Excel.Workbook
        Dim RutaDestino As String = ""
        Dim cQue As String = ""
        ' Dim idmoddestino As Integer, idmenudestino As Integer, idsubdestino As Integer


        'exApp = New Excel.Application
        exApp.Visible = False
        exApp.DisplayAlerts = False

        wb = exApp.Workbooks.Add

        exApp.ScreenUpdating = False
        wb.ActiveSheet.Cells(1, 2) = UCase(getNombreEmpresa(IDEmp))
        'wb.ActiveSheet.Cells(2, 2) = getTipoDocto(IDEmp, idSer)
        wb.ActiveSheet.Cells(2, 2) = getNombreServicio(idSer)
        exApp.ScreenUpdating = True

        If idSer = 25 Then
            imprimeEncabezado(wb, IDEmp, idSer, Ejercicio)
            imprimeDatosRelacionados(wb, IDEmp, idSer, Ejercicio)
        Else
            imprimeEncabezado(wb, IDEmp, idSer)
            imprimeDatosRelacionados(wb, IDEmp, idSer)
        End If


        If NomArc <> "" Then
            'cQue = "SELECT Top 1 idmodulo_destino, idmenu_destino, idsubmenu_destino FROM XMLDigAsocExped WHERE idservicio = " & idSer
            'Using cCom = New SqlCommand(cQue, FC_SQL)
            '    Using Rs = cCom.ExecuteReader()
            '        Rs.Read()
            '        If Rs.HasRows Then
            '            idmoddestino = Rs("idmodulo_destino")
            '            idmenudestino = Rs("idmenu_destino")
            '            idsubdestino = Rs("idsubmenu_destino")
            '        End If
            '    End Using
            'End Using

            barCount = 750
            pr.Value = barCount
            pr.Refresh()

            RutaDestino = FC_RutaSincronizada & "\" & Obtener_RFC(IDEmp) &
                    "\Administracion\" & Get_NomCarpeta_Menu(getIDMenu(idSer)) & "\" & Get_NomCarpeta_SubMenu(getIDSubMenu(idSer)) & "\" & NomArc
            aRut = Obtener_RFC(IDEmp) & "\Administracion\" & Get_NomCarpeta_Menu(getIDMenu(idSer)) & "\" & Get_NomCarpeta_SubMenu(getIDSubMenu(idSer))
            'exApp.Visible = True
            CrearPDF(exApp, RutaDestino & ".pdf")
        End If


        wb.Close()
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

End Class