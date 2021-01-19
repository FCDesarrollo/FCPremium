Imports System.Data.SqlClient
Imports System.IO
Public Class frmConfigEmpresasEmp
    Private Sub frmConfigEmpresasEmp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim fm As frmConfigExpedientes
        Dim dt As DataTable
        Dim dr As DataRow

        Carga_sucursales(IDEmp, Me.cbSucursales)

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

        cargaEmpresasADW()
        'dt = cbADW.DataSource
        'For i As Integer = 0 To cbADW.Items.Count - 1
        '    dr = dt.Rows(i)
        '    If dr("id") = idAdw Then
        '        cbADW.SelectedIndex = i
        '        Exit For
        '    End If
        'Next
    End Sub
    Private Sub cargaEmpresasCon(ByVal cb As ComboBox)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim cQue As String

        dt = New DataTable("Empresas")
        dt.Columns.Add("id")
        dt.Columns.Add("Nombre")
        dt.Columns.Add("AliasBDD")
        'dt.Columns.Add("idAdw")

        dr = dt.NewRow
        dr(0) = 0
        dr(1) = "SELECCIONAR EMPRESA"
        dr(2) = ""
        'dr(3) = ""
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
                    'dr(3) = getIDSucConfig(cRs("Id"))
                    'dr(3) = getIDSucConfig(cRs("Id"))
                    dt.Rows.Add(dr)
                Loop
            End Using
        End Using

        cb.DataSource = dt
        cb.ValueMember = "id"
        cb.DisplayMember = "Nombre"
    End Sub
    Private Function getNombreSucConfig(idAdw As Integer)
        Dim Nombre As String = ""
        Dim s As clSucursalesCRM

        For Each s In cSucursalesCRM
            If s.IDAdw = idAdw Then
                Nombre = s.Sucursal
                Exit For
            End If
        Next
        getNombreSucConfig = Nombre
    End Function
    Private Function getIDSucConfig(idAdw As Integer)
        Dim Id As Integer
        Dim s As clSucursalesCRM
        Id = 0
        For Each s In cSucursalesCRM
            If s.IDAdw = idAdw Then
                Id = s.IDSucursal
                Exit For
            End If
        Next

        'Using Con = New SqlCommand("SELECT idsucursalcrm FROM CEXEmpresas WHERE idempresaadw = " & idAdw & " and idempresacrm = " & IDEmp, FC_Con)
        '    Using Rs = Con.ExecuteReader()
        '        If Rs.HasRows Then
        '            Rs.Read()
        '            Id = IIf(IsDBNull(Rs("idsucursalcrm")), Id, Rs("idsucursalcrm"))
        '        End If
        '    End Using
        'End Using
        getIDSucConfig = Id
    End Function
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
    Private Sub cargaEmpresasADW()
        Dim Query As String, aDatos() As String, aRuta As String

        If FC_ConexionComercial("CompacWAdmin") <> 0 Then Exit Sub

        dgEmpresasADW.Rows.Clear()

        Query = "SELECT CIDEMPRESA, CNOMBREEMPRESA, CRUTADATOS FROM Empresas WHERE CIDEMPRESA <> 1"
        Using fCom = New SqlCommand(Query, FC_CONCOMER)
            Using cRs = fCom.ExecuteReader()
                Do While cRs.Read()
                    aDatos = Split(cRs("CRUTADATOS"), "|")
                    aRuta = aDatos(UBound(aDatos))
                    dgEmpresasADW.Rows.Add(checkEmpresa(IDEmp, cRs("cidempresa")), Trim(cRs("cidempresa")), Trim(cRs("cnombree01")), Trim(aRuta), getIDSucConfig(cRs("cidempresa")), getNombreSucConfig(cRs("cidempresa")))
                Loop
            End Using
        End Using

    End Sub
    Private Function checkEmpresa(idempresacrm As Integer, idadw As Integer)
        Dim exist As Boolean
        exist = False
        Using Con = New SqlCommand("SELECT * FROM CEXEmpresas WHERE idempresacrm = " & idempresacrm & " and idempresaadw = " & idadw, FC_Con)
            Using Rs = Con.ExecuteReader()
                If Rs.HasRows Then
                    exist = True
                End If
            End Using
        End Using
        checkEmpresa = exist
    End Function
    Private Sub btCerrar_Click(sender As Object, e As EventArgs) Handles btCerrar.Click
        Me.Close()
    End Sub

    Private Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Dim empCon As String = ""
        Dim empNom As String = ""
        Dim empAdw As String = ""
        Dim nomEmp As String = ""
        Dim Query As String
        Dim dt As DataTable, dr As DataRow
        Dim cont As Integer
        Dim idSuc As Integer

        If cbCon.SelectedValue = 0 Then
            MsgBox("Seleccione una empresa de ContPAQ i Contabilidad", vbInformation)
            Exit Sub
        End If
        If cbNom.SelectedValue = 0 Then
            MsgBox("Seleccione una empresa de ContPAQ i Nominas", vbInformation)
            Exit Sub
        End If


        idCon = cbCon.SelectedValue
        idNom = cbNom.SelectedValue
        'idAdw = cbADW.SelectedValue

        cont = 0
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
        'If idAdw <> 0 Then
        '    dt = cbADW.DataSource
        '    dr = dt.Rows(cbADW.SelectedIndex)
        '    empAdw = dr("RutaADw")
        'End If

        For Each Fila As DataGridViewRow In dgEmpresasADW.Rows
            If Fila.Cells(0).Value = True Then
                idAdw = Fila.Cells(1).Value
                empAdw = Fila.Cells(2).Value
                idSuc = Fila.Cells(4).Value

                If idSuc <> 0 Then
                    Using Con = New SqlCommand("SELECT * FROM CEXEmpresas WHERE idempresacrm = " & IDEmp & " And idempresaadw =" & idAdw, FC_Con)
                        Using Rs = Con.ExecuteReader()
                            If Rs.HasRows Then
                                Rs.Read()
                                Query = "UPDATE CEXEmpresas " &
                                        "SET idempresanom=@idempnom, idsucursalcrm=@idsuccrm, idempresacon=@idempcon, idempresaadw=@idempadw, ctBDDNom=@ctNom, ctBDDCon=@ctCon, RutaADW=@ctAdw " &
                                        "WHERE idempresacrm=@idempcrm"
                                nomEmp = Trim(Rs("empresacrm"))
                            Else
                                For Each emp In GL_cUsuarioAPI.MEmpresas
                                    If emp.Idempresa = IDEmp Then
                                        nomEmp = emp.Nombreempresa
                                        Exit For
                                    End If
                                Next
                                Query = "INSERT INTO CEXEmpresas(idempresacrm, idsucursalcrm, empresacrm, idempresanom, idempresacon, idempresaadw,ctBDDNom,ctBDDCon,RutaADW) " &
                                        "VALUES(@idempcrm, @idsuccrm, @nomemp, @idempnom, @idempcon, @idempadw, @ctNom, @ctCon, @ctAdw)"
                            End If
                        End Using
                    End Using

                    Using cCom = New SqlCommand(Query, FC_Con)
                        cCom.Parameters.AddWithValue("@idempcrm", IDEmp)
                        cCom.Parameters.AddWithValue("@idsuccrm", idSuc)
                        cCom.Parameters.AddWithValue("@nomemp", nomEmp)
                        cCom.Parameters.AddWithValue("@idempcon", idCon)
                        cCom.Parameters.AddWithValue("@idempnom", idNom)
                        cCom.Parameters.AddWithValue("@idempadw", idAdw)
                        cCom.Parameters.AddWithValue("@ctCon", empCon)
                        cCom.Parameters.AddWithValue("@ctNom", empNom)
                        cCom.Parameters.AddWithValue("@ctAdw", empAdw)
                        cCom.ExecuteNonQuery()
                    End Using
                    cont = cont + 1
                Else
                    MsgBox("La empresa de AdminPAQ (" & empAdw & ") no se ha configurado a una sucursal en el CRM.", vbInformation)
                End If

            End If
        Next

        Using Con = New SqlCommand("IF EXISTS (SELECT * FROM CEXEmpresas WHERE idempresacrm = " & IDEmp & " And idempresaadw is null) 
	                                BEGIN DELETE FROM CEXEmpresas WHERE idempresacrm = " & IDEmp & " And idempresaadw is null END", FC_Con)
            Con.ExecuteNonQuery()
        End Using

        If cont = 0 Then
            MsgBox("Seleccione una empresa de AdminPAQ.", vbInformation)
            Exit Sub
        End If


        MsgBox("Guardado correctamente", vbInformation)

        Me.Close()

    End Sub

    Private Sub dgEmpresasADW_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEmpresasADW.CellContentClick

    End Sub

    Private Sub dgEmpresasADW_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEmpresasADW.CellClick
        If dgEmpresasADW.CurrentCell.ColumnIndex <> 0 Then Exit Sub
        If dgEmpresasADW.Item(0, dgEmpresasADW.CurrentRow.Index).Value = True Then
            dgEmpresasADW.Item(0, dgEmpresasADW.CurrentRow.Index).Value = False
            Using Con = New SqlCommand("DELETE FROM CEXEmpresas WHERE idempresacrm = " & IDEmp & " and idempresaadw = " & dgEmpresasADW.Item(1, dgEmpresasADW.CurrentRow.Index).Value, FC_Con)
                Con.ExecuteNonQuery()
            End Using
        Else
            dgEmpresasADW.Item(0, dgEmpresasADW.CurrentRow.Index).Value = True
        End If
    End Sub
End Class