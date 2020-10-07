Imports System.Data.SqlClient
Imports System.IO
Public Class frmConfigEmpresasEmp
    Private Sub frmConfigEmpresasEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fm As frmConfigExpedientes
        Dim dt As DataTable
        Dim dr As DataRow

        cargaEmpresasCon(Me.cbCon)
        dt = cbCon.DataSource
        For i As Integer = 0 To cbCon.Items.Count - 1
            dr = dt.Rows(i)
            If dr("id") = idCon Then
                cbCon.SelectedIndex = i
                Exit For
            End If
        Next

        cargaEmpresasNom(Me.cbNom)
        dt = cbNom.DataSource
        For i As Integer = 0 To cbNom.Items.Count - 1
            dr = dt.Rows(i)
            If dr("id") = idNom Then
                cbNom.SelectedIndex = i
                Exit For
            End If
        Next

        cargaEmpresasADW(Me.cbADW)
        dt = cbADW.DataSource
        For i As Integer = 0 To cbADW.Items.Count - 1
            dr = dt.Rows(i)
            If dr("id") = idAdw Then
                cbADW.SelectedIndex = i
                Exit For
            End If
        Next
    End Sub
    Private Sub cargaEmpresasCon(ByVal cb As ComboBox)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim cQue As String

        dt = New DataTable("Empresas")
        dt.Columns.Add("id")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("AliasBDD")

        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "SELECCIONAR EMPRESA"
        dr(2) = ""
        dt.Rows.Add(dr)

        FC_ConexionSQL("GeneralesSQL")

        cQue = "SELECT Id, Nombre, AliasBDD FROM ListaEmpresas"
        Using cCom = New SqlCommand(cQue, FC_SQL)
            Using cRs = cCom.ExecuteReader()
                Do While cRs.Read()
                    dr = dt.NewRow
                    dr(0) = Trim(cRs("Id"))
                    dr(1) = Trim(cRs("Nombre"))
                    dr(2) = Trim(cRs("AliasBDD"))
                    dt.Rows.Add(dr)
                Loop
            End Using
        End Using

        cb.DataSource = dt
        cb.ValueMember = "id"
        cb.DisplayMember = "Nombre"
    End Sub
    Private Sub cargaEmpresasNom(ByVal cb As ComboBox)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim cQue As String

        dt = New DataTable("Empresas")
        dt.Columns.Add("id")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("AliasBDD")

        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "SELECCIONAR EMPRESA"
        dr(2) = ""
        dt.Rows.Add(dr)

        FC_ConexionSQL("nomGenerales")

        cQue = "Select IDEmpresa, NombreEmpresa,RutaEmpresa FROM NOM10000 WHERE IDEmpresa>1"
        Using cCom = New SqlCommand(cQue, FC_SQL)
            Using cRs = cCom.ExecuteReader()
                Do While cRs.Read()
                    dr = dt.NewRow
                    dr(0) = Trim(cRs("IDEmpresa"))
                    dr(1) = Trim(cRs("NombreEmpresa"))
                    dr(2) = Trim(cRs("RutaEmpresa"))
                    dt.Rows.Add(dr)
                Loop
            End Using
        End Using

        cb.DataSource = dt
        cb.ValueMember = "id"
        cb.DisplayMember = "Nombre"
    End Sub
    Private Sub cargaEmpresasADW(ByVal cb As ComboBox)
        Dim Query As String
        Dim dt As DataTable
        Dim dr As DataRow
        Dim cQue As String

        dt = New DataTable("Empresas")
        dt.Columns.Add("id")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("RutaADW")

        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "SELECCIONAR EMPRESA"
        dr(2) = ""
        dt.Rows.Add(dr)

        If FC_ConexionFOX(FC_RutaEmpresasAdmin) <> 0 Then Exit Sub
        Query = "SELECT cidempresa, cnombree01, crutadatos FROM MGW00001 WHERE cidempresa <> 1"
        Using fCom = New Odbc.OdbcCommand(Query, FC_CONFOX)
            Using cRs = fCom.ExecuteReader()
                Do While cRs.Read()
                    dr = dt.NewRow
                    dr(0) = Trim(cRs("cidempresa"))
                    dr(1) = Trim(cRs("cnombree01"))
                    dr(2) = Trim(cRs("crutadatos"))
                    dt.Rows.Add(dr)
                Loop
            End Using
        End Using

        cb.DataSource = dt
        cb.ValueMember = "id"
        cb.DisplayMember = "Nombre"
    End Sub

    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Close()
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Dim empCon As String = ""
        Dim empNom As String = ""
        Dim empAdw As String = ""
        Dim Query As String
        Dim dt As DataTable, dr As DataRow
        idCon = cbCon.SelectedValue
        idNom = cbNom.SelectedValue
        idAdw = cbADW.SelectedValue

        If idCon <> 0 Then
            dt = cbCon.DataSource
            dr = dt.Rows(cbCon.SelectedIndex)
            empCon = dr("AliasBDD")
        End If
        If idNom <> 0 Then
            dt = cbNom.DataSource
            dr = dt.Rows(cbNom.SelectedIndex)
            empNom = dr("AliasBDD")
        End If
        If idAdw <> 0 Then
            dt = cbADW.DataSource
            dr = dt.Rows(cbADW.SelectedIndex)
            empAdw = dr("RutaADw")
        End If

        Query = "UPDATE CEXEmpresas " &
                    "SET idempresanom=@idempnom, idempresacon=@idempcon, idempresaadw=@idempadw, ctBDDNom=@ctNom, ctBDDCon=@ctCon, RutaADW=@ctAdw " &
                "WHERE idempresacrm=@idempcrm"
        Using cCom = New SqlCommand(Query, FC_Con)
            cCom.Parameters.AddWithValue("@idempcrm", IDEmp)
            cCom.Parameters.AddWithValue("@idempcon", idCon)
            cCom.Parameters.AddWithValue("@idempnom", idNom)
            cCom.Parameters.AddWithValue("@idempadw", idAdw)
            cCom.Parameters.AddWithValue("@ctCon", empCon)
            cCom.Parameters.AddWithValue("@ctNom", empNom)
            cCom.Parameters.AddWithValue("@ctAdw", empAdw)
            cCom.ExecuteNonQuery()
        End Using

        MsgBox("Guardado correctamente", vbInformation)

        Me.Close()

    End Sub
End Class