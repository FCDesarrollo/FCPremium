<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRubros
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
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboperacion = New System.Windows.Forms.ComboBox()
        Me.dgRubros = New System.Windows.Forms.DataGridView()
        Me.digtip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digOpe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgRub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgrubcla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digruidsubmenu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMover = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        CType(Me.dgRubros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Operación:"
        '
        'cboperacion
        '
        Me.cboperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperacion.FormattingEnabled = True
        Me.cboperacion.Location = New System.Drawing.Point(12, 23)
        Me.cboperacion.Name = "cboperacion"
        Me.cboperacion.Size = New System.Drawing.Size(259, 21)
        Me.cboperacion.TabIndex = 27
        '
        'dgRubros
        '
        Me.dgRubros.AllowUserToAddRows = False
        Me.dgRubros.AllowUserToDeleteRows = False
        Me.dgRubros.AllowUserToResizeRows = False
        Me.dgRubros.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgRubros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.digtip, Me.digOpe, Me.dgRub, Me.dgrubcla, Me.digruidsubmenu})
        Me.dgRubros.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgRubros.Location = New System.Drawing.Point(12, 63)
        Me.dgRubros.MultiSelect = False
        Me.dgRubros.Name = "dgRubros"
        Me.dgRubros.RowHeadersVisible = False
        Me.dgRubros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgRubros.Size = New System.Drawing.Size(259, 241)
        Me.dgRubros.TabIndex = 29
        '
        'digtip
        '
        Me.digtip.HeaderText = "Tipo"
        Me.digtip.Name = "digtip"
        Me.digtip.ReadOnly = True
        Me.digtip.Visible = False
        '
        'digOpe
        '
        Me.digOpe.HeaderText = "Operación"
        Me.digOpe.Name = "digOpe"
        Me.digOpe.ReadOnly = True
        Me.digOpe.Width = 80
        '
        'dgRub
        '
        Me.dgRub.HeaderText = "Rubro"
        Me.dgRub.Name = "dgRub"
        Me.dgRub.ReadOnly = True
        Me.dgRub.Width = 170
        '
        'dgrubcla
        '
        Me.dgrubcla.HeaderText = "Clave"
        Me.dgrubcla.Name = "dgrubcla"
        Me.dgrubcla.Visible = False
        '
        'digruidsubmenu
        '
        Me.digruidsubmenu.HeaderText = "idsubmenu"
        Me.digruidsubmenu.Name = "digruidsubmenu"
        Me.digruidsubmenu.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Rubro:"
        '
        'btnMover
        '
        Me.btnMover.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnMover.Location = New System.Drawing.Point(45, 315)
        Me.btnMover.Name = "btnMover"
        Me.btnMover.Size = New System.Drawing.Size(75, 34)
        Me.btnMover.TabIndex = 31
        Me.btnMover.Text = "Mover"
        Me.btnMover.UseVisualStyleBackColor = False
        '
        'btnsalir
        '
        Me.btnsalir.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnsalir.Location = New System.Drawing.Point(145, 315)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(75, 34)
        Me.btnsalir.TabIndex = 32
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.UseVisualStyleBackColor = False
        '
        'frmRubros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(283, 350)
        Me.Controls.Add(Me.btnsalir)
        Me.Controls.Add(Me.btnMover)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgRubros)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboperacion)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRubros"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mover Documento"
        CType(Me.dgRubros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label8 As Label
    Friend WithEvents cboperacion As ComboBox
    Friend WithEvents dgRubros As DataGridView
    Friend WithEvents digtip As DataGridViewTextBoxColumn
    Friend WithEvents digOpe As DataGridViewTextBoxColumn
    Friend WithEvents dgRub As DataGridViewTextBoxColumn
    Friend WithEvents dgrubcla As DataGridViewTextBoxColumn
    Friend WithEvents digruidsubmenu As DataGridViewTextBoxColumn
    Friend WithEvents Label1 As Label
    Friend WithEvents btnMover As Button
    Friend WithEvents btnsalir As Button
End Class
