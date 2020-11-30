Imports System.Data.SqlClient
Imports System.IO
Public Class frmConfigExpedientes
    'Private Sub frmConfigEmpresasExp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    Private Sub frmConfigExpedientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaEmpresasConfig()
    End Sub
    Public Sub cargaEmpresasConfig()
        Dim emp As clEmpresa
        Dim cbc As New DataGridViewComboBoxColumn()
        'Dim i As Integer
        Dim cQue As String
        Dim count As Integer
        Dim idEmpCon As Integer
        Dim idEmpNom As Integer
        Dim idEmpAdw As Integer
        Dim ctBDDCon As String = ""
        Dim ctBDDNom As String = ""
        Dim ctBDDAdw As String = ""

        dgEmpresas.Rows.Clear()

        GL_cUsuarioAPI.lista_empresas()
        For Each emp In GL_cUsuarioAPI.MEmpresas
            idEmpCon = 0
            ctBDDCon = ""
            idEmpNom = 0
            ctBDDNom = ""
            idEmpAdw = 0
            ctBDDAdw = ""
            'ctBDDCon <> NULL OR
            count = 0
            cQue = "SELECT idempresacon, idempresanom, idempresaadw, ctBDDCon, ctBDDNom, RutaADW FROM CEXEmpresas WHERE idempresacrm = " & emp.Idempresa
            Using dCom = New SqlCommand(cQue, FC_Con)
                Using aCr = dCom.ExecuteReader()
                    If aCr.HasRows Then
                        Do While aCr.Read
                            idEmpCon = CInt(IIf(Not IsDBNull(aCr("idempresacon")), aCr("idempresacon"), 0))
                            ctBDDCon = IIf(Not IsDBNull(aCr("ctBDDCon")), aCr("ctBDDCon"), "")

                            idEmpNom = CInt(IIf(Not IsDBNull(aCr("idempresanom")), aCr("idempresanom"), 0))
                            ctBDDNom = IIf(Not IsDBNull(aCr("ctBDDNom")), aCr("ctBDDNom"), "")

                            idEmpAdw = CInt(IIf(Not IsDBNull(aCr("idempresaadw")), aCr("idempresaadw"), 0))

                            If idEmpAdw <> 0 Then count = count + 1
                        Loop
                        dgEmpresas.Rows.Add(emp.Idempresa, emp.Nombreempresa, idEmpCon, ctBDDCon, idEmpNom, ctBDDNom, 0, count)
                    End If
                End Using
            End Using
            'dgEmpresas.Rows.Add(emp.Idempresa, emp.Nombreempresa, idEmpCon, ctBDDCon, idEmpNom, ctBDDNom, idEmpAdw, ctBDDAdw)
        Next
        dgEmpresas.ClearSelection()
    End Sub
    Private Function getEmpresasCON(ByVal idEmp As Integer)
        Dim cQue As String
        Dim ctBDD As String = ""
        cQue = "SELECT ctBDDCon FROM CEXEmpresas WHERE ctBDDCon <> NULL OR idempresacrm = " & idEmp
        Using dCom = New SqlCommand(cQue, FC_Con)
            Using aCr = dCom.ExecuteReader()
                aCr.Read()
                If aCr.HasRows Then
                    If Not IsDBNull(aCr(0)) Then
                        ctBDD = aCr("ctBDDCon")
                    End If
                End If
            End Using
        End Using
        getEmpresasCON = ctBDD
    End Function
    Private Function getEmpresasNOM(ByVal idEmp As Integer)
        Dim cQue As String
        Dim ctBDD As String = ""
        cQue = "SELECT ctBDDNom FROM CEXEmpresas WHERE ctBDDNom <> NULL OR idempresacrm = " & idEmp
        Using dCom = New SqlCommand(cQue, FC_Con)
            Using aCr = dCom.ExecuteReader()
                aCr.Read()
                If aCr.HasRows Then
                    If Not IsDBNull(aCr(0)) Then
                        ctBDD = aCr(0)
                    End If
                End If
            End Using
        End Using
        getEmpresasNOM = ctBDD
    End Function
    Private Function getEmpresasADW(ByVal idEmp As Integer)
        Dim cQue As String
        Dim ctBDD As String = ""
        cQue = "SELECT RutaADW FROM CEXEmpresas WHERE RutaADW <> NULL OR idempresacrm = " & idEmp
        Using dCom = New SqlCommand(cQue, FC_Con)
            Using aCr = dCom.ExecuteReader()
                aCr.Read()
                If aCr.HasRows Then
                    If Not IsDBNull(aCr(0)) Then
                        ctBDD = aCr(0)
                    End If
                End If
            End Using
        End Using
        getEmpresasADW = ctBDD
    End Function

    Private Sub dgEmpresas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEmpresas.CellDoubleClick
        IDEmp = CInt(dgEmpresas.Item(0, dgEmpresas.CurrentRow.Index).Value)
        idCon = CInt(dgEmpresas.Item(2, dgEmpresas.CurrentRow.Index).Value)
        idNom = CInt(dgEmpresas.Item(4, dgEmpresas.CurrentRow.Index).Value)
        idAdw = CInt(dgEmpresas.Item(6, dgEmpresas.CurrentRow.Index).Value)
        frmConfigEmpresasEmp.ShowDialog()
        cargaEmpresasConfig()
    End Sub

    Private Sub btnAgregaEmp_Click(sender As Object, e As EventArgs) Handles btnAgregaEmp.Click
        frmAddEmpresa.ShowDialog()
    End Sub

    Private Sub dgEmpresas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEmpresas.CellContentClick

    End Sub

    Private Sub frmConfigExpedientes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Dim idEmpresa As Integer
        'For Each Fila As DataGridViewRow In dgEmpresas.Rows
        '    idEmpresa = Fila.Cells(0).Value
        '    Using Con = New SqlCommand("IF EXISTS (SELECT * FROM CEXEmpresas WHERE idempresacrm = " & idEmpresa & " And idempresaadw is null) 
        '                         BEGIN
        '                          DELETE FROM CEXEmpresas WHERE idempresacrm = " & idEmpresa & " And idempresaadw is null	   
        '                         END", FC_Con)
        '        Con.ExecuteNonQuery()
        '    End Using
        'Next

    End Sub

    Private Sub btnEliminaEmp_Click(sender As Object, e As EventArgs) Handles btnEliminaEmp.Click
        Dim idempresa As Integer
        Dim mensaje As String

        If dgEmpresas.CurrentRow.Index = 0 Then Exit Sub

        mensaje = MsgBox("¿Desea eliminar la empresa seleccionada?", vbQuestion + vbYesNo, ("Eliminar Empresa"))
        If mensaje = vbYes Then
            idempresa = CInt(dgEmpresas.Item(0, dgEmpresas.CurrentRow.Index).Value)
            Using Con = New SqlCommand("DELETE FROM CEXEmpresas WHERE idempresacrm = " & idempresa, FC_Con)
                Con.ExecuteNonQuery()
            End Using

            cargaEmpresasConfig()
        End If

    End Sub
End Class