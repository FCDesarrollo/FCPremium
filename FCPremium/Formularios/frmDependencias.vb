Imports System.Data.SqlClient
Public Class frmDependencias
    Private idDep As Integer
    Private Sub frmDependencias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim TL(4) As ToolTip
        getEmpresas(Me.CBEmpresas)
        CargaDependenciasGenerales()

        TL(0) = New ToolTip
        TL(0).SetToolTip(Me.btnElimina, "Elimina Dependencia")
        TL(1) = New ToolTip
        TL(1).SetToolTip(Me.btEliminag, "Elimina Dependencia")
        TL(2) = New ToolTip
        TL(2).SetToolTip(Me.btnAgrega, "Agregar Dependencia")
        TL(3) = New ToolTip
        TL(3).SetToolTip(Me.btnAgregag, "Agregar Dependencia")

        LimpiaForm()
    End Sub

    Private Sub CargaDependenciasGenerales()
        Dim cQue As String
        dgDependenciasg.Rows.Clear()
        cQue = "SELECT * FROM CEXDependencias"
        Using cCom1 = New SqlCommand(cQue, FC_Con)
            Using aCr = cCom1.ExecuteReader()
                Do While aCr.Read()
                    dgDependenciasg.Rows.Add(aCr("id"), aCr("dependencia"))
                Loop
            End Using
        End Using

        dgDependenciasg.ClearSelection()
    End Sub

    Private Sub CargaDependenciasEmpresa(idEmp As Integer)
        Dim cQue As String
        ConEmpresaSQL(idEmp)

        dgDependencias.Rows.Clear()
        cQue = "SELECT * FROM zCEXDependencias"
        Using cCom1 = New SqlCommand(cQue, FC_SQL)
            Using aCr = cCom1.ExecuteReader()
                Do While aCr.Read()
                    dgDependencias.Rows.Add(aCr("id"), aCr("dependencia"))
                Loop
            End Using
        End Using

        dgDependencias.ClearSelection()
    End Sub

    Private Sub btAgregag_Click(sender As Object, e As EventArgs)
        Dim dependencia As String
        dependencia = InputBox("Ingrese el nombre de la nueva dependencia", "Alta de dependencias", "", 100, 0)
        If dependencia = "" Then Exit Sub
        If SoloLetras(dependencia) = False Then
            MsgBox("Ingrese una dependencia valida", vbInformation, "ERROR")
            Exit Sub
        End If

        Using Con = New SqlCommand("INSERT INTO CEXDependencias (dependencia) VALUES('" & dependencia & "')", FC_Con)
            Con.ExecuteNonQuery()
        End Using

        CargaDependenciasGenerales()
    End Sub

    Private Sub btEliminag_Click(sender As Object, e As EventArgs) Handles btEliminag.Click
        Dim idDep As Integer

        For Each Fila As DataGridViewRow In dgDependenciasg.SelectedRows
            idDep = Fila.Cells(0).Value
            Using Con = New SqlCommand("DELETE FROM CEXDependencias WHERE id = " & idDep, FC_Con)
                Con.ExecuteNonQuery()
            End Using
        Next

        CargaDependenciasGenerales()
    End Sub

    Private Sub CBEmpresas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBEmpresas.SelectedIndexChanged
        If CBEmpresas.SelectedIndex = 0 Then Exit Sub
        CargaDependenciasEmpresa(CInt(CBEmpresas.SelectedValue))
    End Sub

    Private Sub BTAgrega_Click(sender As Object, e As EventArgs)
        Dim dependencia As String
        If CBEmpresas.SelectedIndex = 0 Then Exit Sub
        dependencia = InputBox("Ingrese el nombre de la nueva dependencia", "Alta de dependencias", "", 100, 0)
        If dependencia = "" Then Exit Sub
        If SoloLetras(dependencia) = False Then
            MsgBox("Ingrese una dependencia valida", vbInformation, "ERROR")
            Exit Sub
        End If

        ConEmpresaSQL(CInt(CBEmpresas.SelectedValue))

        Using Con = New SqlCommand("INSERT INTO ZCEXDependencias (dependencia) VALUES('" & dependencia & "')", FC_SQL)
            Con.ExecuteNonQuery()
        End Using

        CargaDependenciasEmpresa(CInt(CBEmpresas.SelectedValue))

    End Sub

    Private Sub btElimina_Click(sender As Object, e As EventArgs)
        Dim idDep As Integer
        If CBEmpresas.SelectedIndex = 0 Then Exit Sub
        ConEmpresaSQL(CInt(CBEmpresas.SelectedValue))

        For Each Fila As DataGridViewRow In dgDependencias.SelectedRows
            idDep = Fila.Cells(0).Value
            Using Con = New SqlCommand("DELETE FROM zCEXDependencias WHERE id = " & idDep, FC_SQL)
                Con.ExecuteNonQuery()
            End Using
        Next

        CargaDependenciasEmpresa(CInt(CBEmpresas.SelectedValue))
    End Sub

    Private Sub btnElimina_Click(sender As Object, e As EventArgs) Handles btnElimina.Click
        Dim idDep As Integer

        If CBEmpresas.SelectedIndex = 0 Then
            MsgBox("Seleccione una empresa", vbInformation)
            Exit Sub
        End If

        ConEmpresaSQL(CInt(CBEmpresas.SelectedValue))

        For Each Fila As DataGridViewRow In dgDependencias.SelectedRows
            idDep = Fila.Cells(0).Value
            Using Con = New SqlCommand("DELETE FROM zCEXDependencias WHERE id = " & idDep, FC_SQL)
                Con.ExecuteNonQuery()
            End Using
        Next

        MsgBox("Dependencia eliminada correctamente", vbInformation)

        CargaDependenciasEmpresa(CInt(CBEmpresas.SelectedValue))

        LimpiaForm()
    End Sub

    Private Sub btnAgrega_Click(sender As Object, e As EventArgs) Handles btnAgrega.Click
        Dim dependencia As String
        If CBEmpresas.SelectedIndex = 0 Then
            MsgBox("Seleccione una empresa", vbInformation)
            Exit Sub
        End If

        'dependencia = InputBox("Ingrese el nombre de la nueva dependencia", "Alta de dependencias", "", 100, 0)
        dependencia = TBDependencia.Text
        If dependencia = "" Then Exit Sub
        If SoloLetras(dependencia) = False Then
            MsgBox("Ingrese una dependencia valida", vbInformation, "ERROR")
            Exit Sub
        End If

        ConEmpresaSQL(CInt(CBEmpresas.SelectedValue))

        If idDep = 0 Then
            Using Con = New SqlCommand("INSERT INTO ZCEXDependencias (dependencia) VALUES('" & dependencia & "')", FC_SQL)
                Con.ExecuteNonQuery()
            End Using
            MsgBox("Dependencia agregada correctamente.", vbInformation)
        Else
            Using Con = New SqlCommand("UPDATE ZCEXDependencias SET dependencia = '" & dependencia & "' WHERE id = " & idDep, FC_SQL)
                Con.ExecuteNonQuery()
            End Using
            MsgBox("Dependencia modificada correctamente.", vbInformation)
        End If

        CargaDependenciasEmpresa(CInt(CBEmpresas.SelectedValue))

        LimpiaForm()
    End Sub

    Private Sub dgDependencias_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDependencias.CellClick
        idDep = CInt(dgDependencias.Item(0, dgDependencias.CurrentRow.Index).Value)
        TBDependencia.Text = dgDependencias.Item(1, dgDependencias.CurrentRow.Index).Value
    End Sub

    Private Sub BTNuevo_Click(sender As Object, e As EventArgs) Handles BTNuevo.Click
        LimpiaForm()
    End Sub

    Private Sub LimpiaForm()
        idDep = 0
        TBDependencia.Text = ""
        dgDependencias.ClearSelection()
        tbDependenciag.Text = ""
        dgDependenciasg.ClearSelection()
    End Sub

    Private Sub BTSalir_Click(sender As Object, e As EventArgs) Handles BTSalir.Click
        Me.Close()
    End Sub

    Private Sub btnSalirg_Click(sender As Object, e As EventArgs) Handles btnSalirg.Click
        Me.Close()
    End Sub

    Private Sub btnAgregag_Click(sender As Object, e As EventArgs) Handles btnAgregag.Click
        Dim dependencia As String

        'dependencia = InputBox("Ingrese el nombre de la nueva dependencia", "Alta de dependencias", "", 100, 0)
        dependencia = tbDependenciag.Text
        If dependencia = "" Then Exit Sub
        If SoloLetras(dependencia) = False Then
            MsgBox("Ingrese una dependencia valida", vbInformation, "ERROR")
            Exit Sub
        End If

        If idDep = 0 Then
            Using Con = New SqlCommand("INSERT INTO CEXDependencias (dependencia) VALUES('" & dependencia & "')", FC_Con)
                Con.ExecuteNonQuery()
            End Using
            MsgBox("Dependencia agregada correctamente", vbInformation)
        Else
            Using Con = New SqlCommand("UPDATE CEXDependencias SET dependencia = '" & dependencia & "' WHERE id = " & idDep, FC_Con)
                Con.ExecuteNonQuery()
            End Using
            MsgBox("Dependencia modificada correctamente", vbInformation)
        End If

        CargaDependenciasGenerales()

        LimpiaForm()

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        LimpiaForm()
    End Sub

    Private Sub btnEliminag_Click(sender As Object, e As EventArgs) Handles btnEliminag.Click
        Dim idDep As Integer

        For Each Fila As DataGridViewRow In dgDependenciasg.SelectedRows
            idDep = Fila.Cells(0).Value
            Using Con = New SqlCommand("DELETE FROM CEXDependencias WHERE id = " & idDep, FC_Con)
                Con.ExecuteNonQuery()
            End Using
        Next

        MsgBox("Dependencia eliminada correctamente", vbInformation)

        CargaDependenciasGenerales()

        LimpiaForm()
    End Sub

    Private Sub dgDependenciasg_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDependenciasg.CellContentClick

    End Sub

    Private Sub dgDependenciasg_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgDependenciasg.CellClick
        idDep = CInt(dgDependenciasg.Item(0, dgDependenciasg.CurrentRow.Index).Value)
        tbDependenciag.Text = dgDependenciasg.Item(1, dgDependenciasg.CurrentRow.Index).Value
    End Sub
End Class