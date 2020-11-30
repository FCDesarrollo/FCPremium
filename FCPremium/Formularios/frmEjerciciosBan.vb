Imports System.Data.SqlClient
Public Class frmEjerciciosBan
    Public idMod As Integer
    Private Sub btAceptar_Click(sender As Object, e As EventArgs) Handles btAceptar.Click
        frmGeneraDoctos.EjercicioExpBancos = CInt(cbEjercicio.Text)
        Me.Close()
    End Sub

    Private Sub frmEjerciciosBan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargaEjercicios(Me.cbEjercicio)
    End Sub

    Private Sub cargaEjercicios(ByVal cb As ComboBox)
        Dim dt As DataTable
        Dim dr As DataRow
        Dim cQue As String

        dt = New DataTable("Ejercicios")
        dt.Columns.Add("ejercicio")

        'cQue = "SELECT ejercicio FROM XMLDigAsocExped WHERE procesado = 0 GROUP BY ejercicio ORDER BY ejercicio DESC"

        If idMod = ModExped_Fiscales Then
            cQue = "SELECT ejercicio FROM zClipExped WHERE procesado = 0 and idmodulo = " & idMod & " and idcuenta = " & getIDTax(Obtener_RFC(IDEmp)) & " GROUP BY ejercicio ORDER BY ejercicio DESC"
        Else
            cQue = "SELECT ejercicio FROM zClipExped WHERE procesado = 0 and idmodulo = " & idMod & " GROUP BY ejercicio ORDER BY ejercicio DESC"
        End If
        Using cCom = New SqlCommand(cQue, FC_SQL)
            Using cRs = cCom.ExecuteReader()
                Do While cRs.Read()
                    dr = dt.NewRow
                    dr(0) = Trim(cRs("ejercicio"))
                    dt.Rows.Add(dr)
                Loop
            End Using
        End Using


        cb.DataSource = dt
        cb.ValueMember = "ejercicio"
        'cb.DisplayMember = "Nombre"
    End Sub

    Private Sub frmEjerciciosBan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmGeneraDoctos.EjercicioExpBancos = CInt(cbEjercicio.Text)
    End Sub
End Class