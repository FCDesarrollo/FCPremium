Imports System.Data.SqlClient
Public Class frmAddEmpresa
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmAddEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargaEmpresasCRM()
    End Sub

    Private Sub CargaEmpresasCRM()
        Dim cQue As String
        dgEmpresas.Rows.Clear()
        GL_cUsuarioAPI.lista_empresas()
        For Each emp In GL_cUsuarioAPI.MEmpresas
            cQue = "SELECT * FROM CEXEmpresas WHERE idempresacrm = " & emp.Idempresa
            Using dCom = New SqlCommand(cQue, FC_Con)
                Using aCr = dCom.ExecuteReader()
                    aCr.Read()
                    If Not aCr.HasRows Then
                        dgEmpresas.Rows.Add(emp.Idempresa, emp.Nombreempresa)
                    End If
                End Using
            End Using
        Next
    End Sub

    Private Sub dgEmpresas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEmpresas.CellDoubleClick
        Dim id As Integer
        Dim nombre As String
        id = CInt(dgEmpresas.Item(0, dgEmpresas.CurrentRow.Index).Value)
        nombre = dgEmpresas.Item(1, dgEmpresas.CurrentRow.Index).Value
        Using Con = New SqlCommand("INSERT INTO CEXEmpresas(idempresacrm, empresacrm) VALUES(" & id & ", '" & nombre & "')", FC_Con)
            Con.ExecuteNonQuery()
        End Using
        CargaEmpresasCRM()
    End Sub

    Private Sub frmAddEmpresa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmConfigExpedientes.cargaEmpresasConfig()
    End Sub
End Class