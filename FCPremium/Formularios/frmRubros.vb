Public Class frmRubros
    Private _rIDEmpresa As Integer
    Private _sBandLoad As Boolean
    Public Property RuIDEmpresa As Integer
        Get
            Return _rIDEmpresa
        End Get
        Set(value As Integer)
            _rIDEmpresa = value
        End Set
    End Property

    Private Sub frmRubros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _sBandLoad = True
        Carga_Permisos(_rIDEmpresa, Me.cboperacion, Menu_Digital_Operacion)
        _sBandLoad = False
    End Sub

    Private Sub cboperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboperacion.SelectedIndexChanged
        Dim idSubMenu As Integer
        If _sBandLoad = True Then Exit Sub
        idSubMenu = CInt(cboperacion.SelectedValue)

        'Carga_rubros(_rIDEmpresa, idSubMenu, dgRubros, cboperacion)
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnMover_Click(sender As Object, e As EventArgs) Handles btnMover.Click
        Dim idSubMenu As Integer
        idSubMenu = CInt(cboperacion.SelectedValue)
        If idSubMenu > 0 Then
            If dgRubros.CurrentRow Is Nothing Then
                MsgBox("Debe Seleccionar un rubro.", vbInformation, "Validción")
                Exit Sub
            End If
            If dgRubros.CurrentRow.Index >= 0 Then
                Dim form As New frmdigital
                G_carFin = cboperacion.Text
                G_claRubroNew = dgRubros.Item(3, dgRubros.CurrentRow.Index).Value
                Me.Close()
            End If
        End If
    End Sub
End Class