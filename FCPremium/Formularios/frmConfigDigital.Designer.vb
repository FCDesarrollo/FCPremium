<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigDigital
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbempresa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgempresas = New System.Windows.Forms.DataGridView()
        Me.digidadw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digidempresacont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digidempresacrm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digruta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digidsuc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dignombreadw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digsucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digempresacrm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabConfig = New System.Windows.Forms.TabControl()
        Me.tbaSuc = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabRubros = New System.Windows.Forms.TabPage()
        Me.dgDocModelos = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.digclave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digidmenu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digidsubmenu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgenviado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgnombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digoperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgempresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabConfig.SuspendLayout()
        Me.tbaSuc.SuspendLayout()
        Me.TabRubros.SuspendLayout()
        CType(Me.dgDocModelos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Empresas CRM:"
        '
        'cbempresa
        '
        Me.cbempresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbempresa.FormattingEnabled = True
        Me.cbempresa.Location = New System.Drawing.Point(12, 27)
        Me.cbempresa.Name = "cbempresa"
        Me.cbempresa.Size = New System.Drawing.Size(357, 21)
        Me.cbempresa.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(142, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Empresas de AdminPAQ"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(357, 41)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Datos Necesarios para enviar a la empresa CRM." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Sucursales." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "- Rubros."
        '
        'dgempresas
        '
        Me.dgempresas.AllowUserToAddRows = False
        Me.dgempresas.AllowUserToDeleteRows = False
        Me.dgempresas.AllowUserToResizeColumns = False
        Me.dgempresas.AllowUserToResizeRows = False
        Me.dgempresas.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgempresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgempresas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.digidadw, Me.digidempresacont, Me.digidempresacrm, Me.digruta, Me.digidsuc, Me.dignombreadw, Me.digsucursal, Me.digempresacrm})
        Me.dgempresas.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgempresas.Location = New System.Drawing.Point(9, 24)
        Me.dgempresas.Name = "dgempresas"
        Me.dgempresas.RowHeadersVisible = False
        Me.dgempresas.Size = New System.Drawing.Size(430, 259)
        Me.dgempresas.TabIndex = 18
        '
        'digidadw
        '
        Me.digidadw.HeaderText = "idadw"
        Me.digidadw.Name = "digidadw"
        Me.digidadw.Visible = False
        '
        'digidempresacont
        '
        Me.digidempresacont.HeaderText = "idempresacont"
        Me.digidempresacont.Name = "digidempresacont"
        Me.digidempresacont.Visible = False
        '
        'digidempresacrm
        '
        Me.digidempresacrm.HeaderText = "idempresacrm"
        Me.digidempresacrm.Name = "digidempresacrm"
        Me.digidempresacrm.Visible = False
        '
        'digruta
        '
        Me.digruta.HeaderText = "Ruta"
        Me.digruta.Name = "digruta"
        Me.digruta.Visible = False
        '
        'digidsuc
        '
        Me.digidsuc.HeaderText = "idsucursal"
        Me.digidsuc.Name = "digidsuc"
        Me.digidsuc.ReadOnly = True
        Me.digidsuc.Visible = False
        '
        'dignombreadw
        '
        Me.dignombreadw.HeaderText = "Nombre ADW"
        Me.dignombreadw.Name = "dignombreadw"
        Me.dignombreadw.ReadOnly = True
        Me.dignombreadw.Width = 170
        '
        'digsucursal
        '
        Me.digsucursal.HeaderText = "Sucursal ADW"
        Me.digsucursal.Name = "digsucursal"
        Me.digsucursal.ReadOnly = True
        '
        'digempresacrm
        '
        Me.digempresacrm.HeaderText = "Empresa CRM"
        Me.digempresacrm.Name = "digempresacrm"
        Me.digempresacrm.ReadOnly = True
        Me.digempresacrm.Width = 170
        '
        'TabConfig
        '
        Me.TabConfig.Controls.Add(Me.tbaSuc)
        Me.TabConfig.Controls.Add(Me.TabRubros)
        Me.TabConfig.Location = New System.Drawing.Point(15, 101)
        Me.TabConfig.Name = "TabConfig"
        Me.TabConfig.SelectedIndex = 0
        Me.TabConfig.Size = New System.Drawing.Size(453, 337)
        Me.TabConfig.TabIndex = 19
        '
        'tbaSuc
        '
        Me.tbaSuc.Controls.Add(Me.Label4)
        Me.tbaSuc.Controls.Add(Me.dgempresas)
        Me.tbaSuc.Controls.Add(Me.Label1)
        Me.tbaSuc.Location = New System.Drawing.Point(4, 22)
        Me.tbaSuc.Name = "tbaSuc"
        Me.tbaSuc.Padding = New System.Windows.Forms.Padding(3)
        Me.tbaSuc.Size = New System.Drawing.Size(445, 311)
        Me.tbaSuc.TabIndex = 0
        Me.tbaSuc.Text = "Sucursales"
        Me.tbaSuc.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Yellow
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(117, 286)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(315, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Doble Click para enviar la Sucursal a la Empresa CRM"
        '
        'TabRubros
        '
        Me.TabRubros.Controls.Add(Me.Label5)
        Me.TabRubros.Controls.Add(Me.dgDocModelos)
        Me.TabRubros.Location = New System.Drawing.Point(4, 22)
        Me.TabRubros.Name = "TabRubros"
        Me.TabRubros.Padding = New System.Windows.Forms.Padding(3)
        Me.TabRubros.Size = New System.Drawing.Size(445, 311)
        Me.TabRubros.TabIndex = 1
        Me.TabRubros.Text = "Rubros"
        Me.TabRubros.UseVisualStyleBackColor = True
        '
        'dgDocModelos
        '
        Me.dgDocModelos.AllowUserToAddRows = False
        Me.dgDocModelos.AllowUserToResizeColumns = False
        Me.dgDocModelos.AllowUserToResizeRows = False
        Me.dgDocModelos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocModelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDocModelos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.digclave, Me.digidmenu, Me.digidsubmenu, Me.dgtipo, Me.dgenviado, Me.dgnombre, Me.digoperacion})
        Me.dgDocModelos.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocModelos.Location = New System.Drawing.Point(6, 31)
        Me.dgDocModelos.Name = "dgDocModelos"
        Me.dgDocModelos.RowHeadersVisible = False
        Me.dgDocModelos.Size = New System.Drawing.Size(416, 274)
        Me.dgDocModelos.TabIndex = 16
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(274, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Documentos Modelos para enviar como Rubros"
        '
        'digclave
        '
        Me.digclave.HeaderText = "clave"
        Me.digclave.Name = "digclave"
        Me.digclave.Visible = False
        '
        'digidmenu
        '
        Me.digidmenu.HeaderText = "idmenu"
        Me.digidmenu.Name = "digidmenu"
        Me.digidmenu.Visible = False
        '
        'digidsubmenu
        '
        Me.digidsubmenu.HeaderText = "idsubmenu"
        Me.digidsubmenu.Name = "digidsubmenu"
        Me.digidsubmenu.Visible = False
        '
        'dgtipo
        '
        Me.dgtipo.HeaderText = "Tipo"
        Me.dgtipo.Name = "dgtipo"
        Me.dgtipo.ReadOnly = True
        Me.dgtipo.Visible = False
        Me.dgtipo.Width = 150
        '
        'dgenviado
        '
        Me.dgenviado.HeaderText = "Enviado"
        Me.dgenviado.Name = "dgenviado"
        Me.dgenviado.Width = 70
        '
        'dgnombre
        '
        Me.dgnombre.HeaderText = "Nombre"
        Me.dgnombre.Name = "dgnombre"
        Me.dgnombre.ReadOnly = True
        Me.dgnombre.Width = 170
        '
        'digoperacion
        '
        Me.digoperacion.HeaderText = "Operación"
        Me.digoperacion.Name = "digoperacion"
        Me.digoperacion.ReadOnly = True
        Me.digoperacion.Width = 150
        '
        'frmConfigDigital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TabConfig)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbempresa)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfigDigital"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración Digital"
        CType(Me.dgempresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabConfig.ResumeLayout(False)
        Me.tbaSuc.ResumeLayout(False)
        Me.tbaSuc.PerformLayout()
        Me.TabRubros.ResumeLayout(False)
        Me.TabRubros.PerformLayout()
        CType(Me.dgDocModelos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents cbempresa As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgempresas As DataGridView
    Friend WithEvents TabConfig As TabControl
    Friend WithEvents tbaSuc As TabPage
    Friend WithEvents TabRubros As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents digidadw As DataGridViewTextBoxColumn
    Friend WithEvents digidempresacont As DataGridViewTextBoxColumn
    Friend WithEvents digidempresacrm As DataGridViewTextBoxColumn
    Friend WithEvents digruta As DataGridViewTextBoxColumn
    Friend WithEvents digidsuc As DataGridViewTextBoxColumn
    Friend WithEvents dignombreadw As DataGridViewTextBoxColumn
    Friend WithEvents digsucursal As DataGridViewTextBoxColumn
    Friend WithEvents digempresacrm As DataGridViewTextBoxColumn
    Friend WithEvents dgDocModelos As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents digclave As DataGridViewTextBoxColumn
    Friend WithEvents digidmenu As DataGridViewTextBoxColumn
    Friend WithEvents digidsubmenu As DataGridViewTextBoxColumn
    Friend WithEvents dgtipo As DataGridViewTextBoxColumn
    Friend WithEvents dgenviado As DataGridViewCheckBoxColumn
    Friend WithEvents dgnombre As DataGridViewTextBoxColumn
    Friend WithEvents digoperacion As DataGridViewTextBoxColumn
End Class
