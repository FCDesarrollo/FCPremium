<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfigExpedientes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgEmpresas = New System.Windows.Forms.DataGridView()
        Me.idempresacrm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empresacrm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idempresacon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empresacon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idempresanom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empresanom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idempresaadw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.empresaadw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LInfo = New System.Windows.Forms.Label()
        Me.btnAgregaEmp = New System.Windows.Forms.Button()
        Me.btnEliminaEmp = New System.Windows.Forms.Button()
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
        Me.dgEmpresas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idempresacrm, Me.empresacrm, Me.idempresacon, Me.empresacon, Me.idempresanom, Me.empresanom, Me.idempresaadw, Me.empresaadw})
        Me.dgEmpresas.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgEmpresas.Location = New System.Drawing.Point(15, 34)
        Me.dgEmpresas.MultiSelect = False
        Me.dgEmpresas.Name = "dgEmpresas"
        Me.dgEmpresas.ReadOnly = True
        Me.dgEmpresas.RowHeadersVisible = False
        Me.dgEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgEmpresas.Size = New System.Drawing.Size(652, 207)
        Me.dgEmpresas.TabIndex = 74
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
        Me.empresacrm.Width = 300
        '
        'idempresacon
        '
        Me.idempresacon.HeaderText = "idempresacon"
        Me.idempresacon.Name = "idempresacon"
        Me.idempresacon.ReadOnly = True
        Me.idempresacon.Visible = False
        '
        'empresacon
        '
        Me.empresacon.HeaderText = "CONTPAQ i Contabilidad"
        Me.empresacon.Name = "empresacon"
        Me.empresacon.ReadOnly = True
        Me.empresacon.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.empresacon.Width = 140
        '
        'idempresanom
        '
        Me.idempresanom.HeaderText = "idempresanom"
        Me.idempresanom.Name = "idempresanom"
        Me.idempresanom.ReadOnly = True
        Me.idempresanom.Visible = False
        '
        'empresanom
        '
        Me.empresanom.HeaderText = "CONTPAQ i Nominas"
        Me.empresanom.Name = "empresanom"
        Me.empresanom.ReadOnly = True
        Me.empresanom.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.empresanom.Width = 140
        '
        'idempresaadw
        '
        Me.idempresaadw.HeaderText = "idempresaadw"
        Me.idempresaadw.Name = "idempresaadw"
        Me.idempresaadw.ReadOnly = True
        Me.idempresaadw.Visible = False
        '
        'empresaadw
        '
        Me.empresaadw.HeaderText = "AdminPAQ"
        Me.empresaadw.Name = "empresaadw"
        Me.empresaadw.ReadOnly = True
        Me.empresaadw.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.empresaadw.Width = 65
        '
        'LInfo
        '
        Me.LInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LInfo.Location = New System.Drawing.Point(12, 244)
        Me.LInfo.Name = "LInfo"
        Me.LInfo.Size = New System.Drawing.Size(304, 32)
        Me.LInfo.TabIndex = 77
        Me.LInfo.Text = "Doble click para configurar las empresas de Contabilidad, Nominas y AdminPAQ a la" &
    " empresa del CRM."
        '
        'btnAgregaEmp
        '
        Me.btnAgregaEmp.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAgregaEmp.Location = New System.Drawing.Point(587, 5)
        Me.btnAgregaEmp.Name = "btnAgregaEmp"
        Me.btnAgregaEmp.Size = New System.Drawing.Size(37, 23)
        Me.btnAgregaEmp.TabIndex = 78
        Me.btnAgregaEmp.Text = "+"
        Me.btnAgregaEmp.UseVisualStyleBackColor = False
        '
        'btnEliminaEmp
        '
        Me.btnEliminaEmp.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEliminaEmp.Location = New System.Drawing.Point(630, 5)
        Me.btnEliminaEmp.Name = "btnEliminaEmp"
        Me.btnEliminaEmp.Size = New System.Drawing.Size(37, 23)
        Me.btnEliminaEmp.TabIndex = 79
        Me.btnEliminaEmp.Text = "-"
        Me.btnEliminaEmp.UseVisualStyleBackColor = False
        '
        'frmConfigExpedientes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 285)
        Me.Controls.Add(Me.btnEliminaEmp)
        Me.Controls.Add(Me.btnAgregaEmp)
        Me.Controls.Add(Me.LInfo)
        Me.Controls.Add(Me.dgEmpresas)
        Me.Name = "frmConfigExpedientes"
        Me.Text = "Configuracion de Empresas"
        CType(Me.dgEmpresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgEmpresas As DataGridView
    Friend WithEvents LInfo As Label
    Friend WithEvents btnAgregaEmp As Button
    Friend WithEvents btnEliminaEmp As Button
    Friend WithEvents idempresacrm As DataGridViewTextBoxColumn
    Friend WithEvents empresacrm As DataGridViewTextBoxColumn
    Friend WithEvents idempresacon As DataGridViewTextBoxColumn
    Friend WithEvents empresacon As DataGridViewTextBoxColumn
    Friend WithEvents idempresanom As DataGridViewTextBoxColumn
    Friend WithEvents empresanom As DataGridViewTextBoxColumn
    Friend WithEvents idempresaadw As DataGridViewTextBoxColumn
    Friend WithEvents empresaadw As DataGridViewTextBoxColumn
End Class
