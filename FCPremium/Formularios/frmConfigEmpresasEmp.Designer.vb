<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfigEmpresasEmp
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
        Me.cbCon = New System.Windows.Forms.ComboBox()
        Me.cbNom = New System.Windows.Forms.ComboBox()
        Me.btGuardar = New System.Windows.Forms.Button()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgEmpresasADW = New System.Windows.Forms.DataGridView()
        Me.cbSucursales = New System.Windows.Forms.ComboBox()
        Me.seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idadminpaq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rutaadw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idsucursalcrm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sucursalcrm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgEmpresasADW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbCon
        '
        Me.cbCon.FormattingEnabled = True
        Me.cbCon.Location = New System.Drawing.Point(12, 25)
        Me.cbCon.Name = "cbCon"
        Me.cbCon.Size = New System.Drawing.Size(212, 21)
        Me.cbCon.TabIndex = 0
        '
        'cbNom
        '
        Me.cbNom.FormattingEnabled = True
        Me.cbNom.Location = New System.Drawing.Point(240, 25)
        Me.cbNom.Name = "cbNom"
        Me.cbNom.Size = New System.Drawing.Size(212, 21)
        Me.cbNom.TabIndex = 1
        '
        'btGuardar
        '
        Me.btGuardar.Location = New System.Drawing.Point(135, 234)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(89, 30)
        Me.btGuardar.TabIndex = 3
        Me.btGuardar.Text = "Guardar y salir"
        Me.btGuardar.UseVisualStyleBackColor = True
        '
        'btCerrar
        '
        Me.btCerrar.Location = New System.Drawing.Point(240, 234)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(75, 30)
        Me.btCerrar.TabIndex = 4
        Me.btCerrar.Text = "Cerrar"
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "CONTPAQ i Contabilidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(240, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "CONTPAQ i Nominas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Empresas de AdminPAQ"
        '
        'dgEmpresasADW
        '
        Me.dgEmpresasADW.AllowUserToAddRows = False
        Me.dgEmpresasADW.AllowUserToDeleteRows = False
        Me.dgEmpresasADW.AllowUserToResizeRows = False
        Me.dgEmpresasADW.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgEmpresasADW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgEmpresasADW.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seleccion, Me.idadminpaq, Me.servicio, Me.rutaadw, Me.idsucursalcrm, Me.sucursalcrm})
        Me.dgEmpresasADW.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgEmpresasADW.Location = New System.Drawing.Point(12, 73)
        Me.dgEmpresasADW.MultiSelect = False
        Me.dgEmpresasADW.Name = "dgEmpresasADW"
        Me.dgEmpresasADW.ReadOnly = True
        Me.dgEmpresasADW.RowHeadersVisible = False
        Me.dgEmpresasADW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgEmpresasADW.Size = New System.Drawing.Size(440, 155)
        Me.dgEmpresasADW.TabIndex = 75
        '
        'cbSucursales
        '
        Me.cbSucursales.Enabled = False
        Me.cbSucursales.FormattingEnabled = True
        Me.cbSucursales.Location = New System.Drawing.Point(316, 52)
        Me.cbSucursales.Name = "cbSucursales"
        Me.cbSucursales.Size = New System.Drawing.Size(136, 21)
        Me.cbSucursales.TabIndex = 76
        Me.cbSucursales.Visible = False
        '
        'seleccion
        '
        Me.seleccion.HeaderText = ""
        Me.seleccion.Name = "seleccion"
        Me.seleccion.ReadOnly = True
        Me.seleccion.Width = 30
        '
        'idadminpaq
        '
        Me.idadminpaq.HeaderText = "idadw"
        Me.idadminpaq.Name = "idadminpaq"
        Me.idadminpaq.ReadOnly = True
        Me.idadminpaq.Visible = False
        '
        'servicio
        '
        Me.servicio.HeaderText = "Empresa"
        Me.servicio.Name = "servicio"
        Me.servicio.ReadOnly = True
        Me.servicio.Width = 270
        '
        'rutaadw
        '
        Me.rutaadw.HeaderText = "rutaadw"
        Me.rutaadw.Name = "rutaadw"
        Me.rutaadw.ReadOnly = True
        Me.rutaadw.Visible = False
        '
        'idsucursalcrm
        '
        Me.idsucursalcrm.HeaderText = "idsucursalcrm"
        Me.idsucursalcrm.Name = "idsucursalcrm"
        Me.idsucursalcrm.ReadOnly = True
        Me.idsucursalcrm.Visible = False
        '
        'sucursalcrm
        '
        Me.sucursalcrm.HeaderText = "Sucursal CRM"
        Me.sucursalcrm.Name = "sucursalcrm"
        Me.sucursalcrm.ReadOnly = True
        Me.sucursalcrm.Width = 135
        '
        'frmConfigEmpresasEmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(464, 280)
        Me.Controls.Add(Me.cbSucursales)
        Me.Controls.Add(Me.dgEmpresasADW)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btCerrar)
        Me.Controls.Add(Me.btGuardar)
        Me.Controls.Add(Me.cbNom)
        Me.Controls.Add(Me.cbCon)
        Me.Name = "frmConfigEmpresasEmp"
        Me.Text = "Configuracion de Empresas"
        CType(Me.dgEmpresasADW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbCon As ComboBox
    Friend WithEvents cbNom As ComboBox
    Friend WithEvents btGuardar As Button
    Friend WithEvents btCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgEmpresasADW As DataGridView
    Friend WithEvents cbSucursales As ComboBox
    Friend WithEvents seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents idadminpaq As DataGridViewTextBoxColumn
    Friend WithEvents servicio As DataGridViewTextBoxColumn
    Friend WithEvents rutaadw As DataGridViewTextBoxColumn
    Friend WithEvents idsucursalcrm As DataGridViewTextBoxColumn
    Friend WithEvents sucursalcrm As DataGridViewTextBoxColumn
End Class
