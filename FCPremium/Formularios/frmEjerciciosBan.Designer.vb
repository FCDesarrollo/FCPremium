<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEjerciciosBan
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cbEjercicio = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btAceptar = New System.Windows.Forms.Button()
        Me.LInfo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbEjercicio
        '
        Me.cbEjercicio.FormattingEnabled = True
        Me.cbEjercicio.Location = New System.Drawing.Point(73, 69)
        Me.cbEjercicio.Name = "cbEjercicio"
        Me.cbEjercicio.Size = New System.Drawing.Size(125, 21)
        Me.cbEjercicio.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ejercicios:"
        '
        'btAceptar
        '
        Me.btAceptar.Location = New System.Drawing.Point(97, 96)
        Me.btAceptar.Name = "btAceptar"
        Me.btAceptar.Size = New System.Drawing.Size(101, 23)
        Me.btAceptar.TabIndex = 2
        Me.btAceptar.Text = "Aceptar"
        Me.btAceptar.UseVisualStyleBackColor = True
        '
        'LInfo
        '
        Me.LInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LInfo.Location = New System.Drawing.Point(12, 9)
        Me.LInfo.Name = "LInfo"
        Me.LInfo.Size = New System.Drawing.Size(186, 57)
        Me.LInfo.TabIndex = 77
        Me.LInfo.Text = "Existen documentos pendientes de procesar de diferentes ejercicios, seleccione el" &
    " ejercicio que desea procesar"
        '
        'frmEjerciciosBan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(210, 129)
        Me.Controls.Add(Me.LInfo)
        Me.Controls.Add(Me.btAceptar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbEjercicio)
        Me.Name = "frmEjerciciosBan"
        Me.Text = "Expediente de Bancos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbEjercicio As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btAceptar As Button
    Friend WithEvents LInfo As Label
End Class
