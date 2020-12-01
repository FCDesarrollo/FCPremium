<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddEmpresa
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
        Me.dgEmpresas = New System.Windows.Forms.DataGridView()
        Me.idempresacrm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empresacrm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LInfo = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        CType(Me.dgEmpresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgEmpresas
        '
        Me.dgEmpresas.AllowUserToAddRows = False
        Me.dgEmpresas.AllowUserToDeleteRows = False
        Me.dgEmpresas.AllowUserToResizeRows = False
        Me.dgEmpresas.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgEmpresas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idempresacrm, Me.empresacrm})
        Me.dgEmpresas.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgEmpresas.Location = New System.Drawing.Point(10, 41)
        Me.dgEmpresas.MultiSelect = False
        Me.dgEmpresas.Name = "dgEmpresas"
        Me.dgEmpresas.ReadOnly = True
        Me.dgEmpresas.RowHeadersVisible = False
        Me.dgEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgEmpresas.Size = New System.Drawing.Size(386, 182)
        Me.dgEmpresas.TabIndex = 75
        '
        'idempresacrm
        '
        Me.idempresacrm.HeaderText = "idempresacrm"
        Me.idempresacrm.Name = "idempresacrm"
        Me.idempresacrm.ReadOnly = True
        Me.idempresacrm.Visible = False
        '
        'empresacrm
        '
        Me.empresacrm.HeaderText = "Empresa CRM"
        Me.empresacrm.Name = "empresacrm"
        Me.empresacrm.ReadOnly = True
        Me.empresacrm.Width = 380
        '
        'LInfo
        '
        Me.LInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LInfo.Location = New System.Drawing.Point(12, 17)
        Me.LInfo.Name = "LInfo"
        Me.LInfo.Size = New System.Drawing.Size(194, 19)
        Me.LInfo.TabIndex = 78
        Me.LInfo.Text = "Doble Clic para agregar la empresa."
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(321, 12)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 79
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'frmAddEmpresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 234)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.LInfo)
        Me.Controls.Add(Me.dgEmpresas)
        Me.Name = "frmAddEmpresa"
        Me.Text = "frmAddEmpresa"
        CType(Me.dgEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgEmpresas As DataGridView
    Friend WithEvents idempresacrm As DataGridViewTextBoxColumn
    Friend WithEvents empresacrm As DataGridViewTextBoxColumn
    Friend WithEvents LInfo As Label
    Friend WithEvents btnCerrar As Button
End Class
