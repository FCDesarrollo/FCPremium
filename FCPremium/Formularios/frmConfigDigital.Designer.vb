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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigDigital))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbempresa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabConfig = New System.Windows.Forms.TabControl()
        Me.tbaSuc = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgempresas = New System.Windows.Forms.DataGridView()
        Me.digidadw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digidempresacont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digidempresacrm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digruta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digidsuc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dignombreadw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digsucursal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digempresacrm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bddCont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabRubros = New System.Windows.Forms.TabPage()
        Me.btnenvia = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgDocModelos = New System.Windows.Forms.DataGridView()
        Me.digclave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digidmenu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digidsubmenu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digiddocmode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgtipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgenviado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dgnombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digoperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgConceptos = New System.Windows.Forms.DataGridView()
        Me.digcodcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digactcon = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.digsuc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digcon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digconEnvia = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.digconclave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plan = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnEnviaCon = New System.Windows.Forms.Button()
        Me.TabConfig.SuspendLayout()
        Me.tbaSuc.SuspendLayout()
        CType(Me.dgempresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabRubros.SuspendLayout()
        CType(Me.dgDocModelos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Label1.Location = New System.Drawing.Point(6, 3)
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
        Me.Label4.Location = New System.Drawing.Point(130, 295)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(315, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Doble Click para enviar la Sucursal a la Empresa CRM"
        '
        'dgempresas
        '
        Me.dgempresas.AllowUserToAddRows = False
        Me.dgempresas.AllowUserToDeleteRows = False
        Me.dgempresas.AllowUserToResizeColumns = False
        Me.dgempresas.AllowUserToResizeRows = False
        Me.dgempresas.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgempresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgempresas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.digidadw, Me.digidempresacont, Me.digidempresacrm, Me.digruta, Me.digidsuc, Me.dignombreadw, Me.digsucursal, Me.digempresacrm, Me.bddCont})
        Me.dgempresas.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgempresas.Location = New System.Drawing.Point(3, 19)
        Me.dgempresas.MultiSelect = False
        Me.dgempresas.Name = "dgempresas"
        Me.dgempresas.RowHeadersVisible = False
        Me.dgempresas.Size = New System.Drawing.Size(439, 273)
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
        'bddCont
        '
        Me.bddCont.HeaderText = "base"
        Me.bddCont.Name = "bddCont"
        Me.bddCont.ReadOnly = True
        Me.bddCont.Visible = False
        '
        'TabRubros
        '
        Me.TabRubros.Controls.Add(Me.btnenvia)
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
        'btnenvia
        '
        Me.btnenvia.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnenvia.Location = New System.Drawing.Point(309, 3)
        Me.btnenvia.Name = "btnenvia"
        Me.btnenvia.Size = New System.Drawing.Size(130, 23)
        Me.btnenvia.TabIndex = 18
        Me.btnenvia.Text = "Enviar Rubros al CRM"
        Me.btnenvia.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(274, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Documentos Modelos para enviar como Rubros"
        '
        'dgDocModelos
        '
        Me.dgDocModelos.AllowUserToAddRows = False
        Me.dgDocModelos.AllowUserToResizeColumns = False
        Me.dgDocModelos.AllowUserToResizeRows = False
        Me.dgDocModelos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocModelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDocModelos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.digclave, Me.digidmenu, Me.digidsubmenu, Me.digiddocmode, Me.dgtipo, Me.dgenviado, Me.dgnombre, Me.digoperacion})
        Me.dgDocModelos.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocModelos.Location = New System.Drawing.Point(3, 28)
        Me.dgDocModelos.MultiSelect = False
        Me.dgDocModelos.Name = "dgDocModelos"
        Me.dgDocModelos.RowHeadersVisible = False
        Me.dgDocModelos.Size = New System.Drawing.Size(439, 280)
        Me.dgDocModelos.TabIndex = 16
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
        'digiddocmode
        '
        Me.digiddocmode.HeaderText = "iddocmodelo"
        Me.digiddocmode.Name = "digiddocmode"
        Me.digiddocmode.Visible = False
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
        Me.dgenviado.Width = 60
        '
        'dgnombre
        '
        Me.dgnombre.HeaderText = "Nombre"
        Me.dgnombre.Name = "dgnombre"
        Me.dgnombre.ReadOnly = True
        Me.dgnombre.Width = 180
        '
        'digoperacion
        '
        Me.digoperacion.HeaderText = "Operación"
        Me.digoperacion.Name = "digoperacion"
        Me.digoperacion.ReadOnly = True
        Me.digoperacion.Width = 170
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(485, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Conceptos."
        '
        'dgConceptos
        '
        Me.dgConceptos.AllowUserToAddRows = False
        Me.dgConceptos.AllowUserToDeleteRows = False
        Me.dgConceptos.AllowUserToResizeColumns = False
        Me.dgConceptos.AllowUserToResizeRows = False
        Me.dgConceptos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgConceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.digcodcon, Me.digactcon, Me.digsuc, Me.digcon, Me.digconEnvia, Me.digconclave, Me.plan})
        Me.dgConceptos.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgConceptos.Location = New System.Drawing.Point(488, 126)
        Me.dgConceptos.Name = "dgConceptos"
        Me.dgConceptos.RowHeadersVisible = False
        Me.dgConceptos.Size = New System.Drawing.Size(463, 312)
        Me.dgConceptos.TabIndex = 21
        '
        'digcodcon
        '
        Me.digcodcon.HeaderText = "codgico concepto"
        Me.digcodcon.Name = "digcodcon"
        Me.digcodcon.Visible = False
        '
        'digactcon
        '
        Me.digactcon.HeaderText = "Excluye"
        Me.digactcon.Name = "digactcon"
        Me.digactcon.ToolTipText = "Conceptos Excluidos para busqueda de documentos en AdminPAQ"
        Me.digactcon.Width = 45
        '
        'digsuc
        '
        Me.digsuc.HeaderText = "Sucursal"
        Me.digsuc.Name = "digsuc"
        Me.digsuc.ReadOnly = True
        Me.digsuc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.digsuc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.digsuc.Width = 70
        '
        'digcon
        '
        Me.digcon.HeaderText = "Concepto"
        Me.digcon.Name = "digcon"
        Me.digcon.ReadOnly = True
        Me.digcon.Width = 145
        '
        'digconEnvia
        '
        Me.digconEnvia.HeaderText = "Rec. Lote"
        Me.digconEnvia.Name = "digconEnvia"
        Me.digconEnvia.ToolTipText = "Concepto para enviar como Rubro para la recepción por lotes"
        Me.digconEnvia.Width = 70
        '
        'digconclave
        '
        Me.digconclave.HeaderText = "Clave"
        Me.digconclave.Name = "digconclave"
        Me.digconclave.Visible = False
        '
        'plan
        '
        Me.plan.HeaderText = "Plantilla"
        Me.plan.Name = "plan"
        Me.plan.Width = 120
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(485, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(466, 87)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = resources.GetString("Label7.Text")
        '
        'btnEnviaCon
        '
        Me.btnEnviaCon.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnEnviaCon.Location = New System.Drawing.Point(763, 99)
        Me.btnEnviaCon.Name = "btnEnviaCon"
        Me.btnEnviaCon.Size = New System.Drawing.Size(188, 24)
        Me.btnEnviaCon.TabIndex = 23
        Me.btnEnviaCon.Text = "Enviar Conceptos(Rubros) al CRM"
        Me.btnEnviaCon.UseVisualStyleBackColor = False
        '
        'frmConfigDigital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 450)
        Me.Controls.Add(Me.btnEnviaCon)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgConceptos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TabConfig)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cbempresa)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfigDigital"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración Digital"
        Me.TabConfig.ResumeLayout(False)
        Me.tbaSuc.ResumeLayout(False)
        Me.tbaSuc.PerformLayout()
        CType(Me.dgempresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabRubros.ResumeLayout(False)
        Me.TabRubros.PerformLayout()
        CType(Me.dgDocModelos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents cbempresa As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TabConfig As TabControl
    Friend WithEvents tbaSuc As TabPage
    Friend WithEvents TabRubros As TabPage
    Friend WithEvents Label4 As Label
    Friend WithEvents dgDocModelos As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dgConceptos As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents digclave As DataGridViewTextBoxColumn
    Friend WithEvents digidmenu As DataGridViewTextBoxColumn
    Friend WithEvents digidsubmenu As DataGridViewTextBoxColumn
    Friend WithEvents digiddocmode As DataGridViewTextBoxColumn
    Friend WithEvents dgtipo As DataGridViewTextBoxColumn
    Friend WithEvents dgenviado As DataGridViewCheckBoxColumn
    Friend WithEvents dgnombre As DataGridViewTextBoxColumn
    Friend WithEvents digoperacion As DataGridViewTextBoxColumn
    Friend WithEvents btnenvia As Button
    Friend WithEvents btnEnviaCon As Button
    Friend WithEvents digcodcon As DataGridViewTextBoxColumn
    Friend WithEvents digactcon As DataGridViewCheckBoxColumn
    Friend WithEvents digsuc As DataGridViewTextBoxColumn
    Friend WithEvents digcon As DataGridViewTextBoxColumn
    Friend WithEvents digconEnvia As DataGridViewCheckBoxColumn
    Friend WithEvents digconclave As DataGridViewTextBoxColumn
    Friend WithEvents plan As DataGridViewComboBoxColumn
    Friend WithEvents dgempresas As DataGridView
    Friend WithEvents digidadw As DataGridViewTextBoxColumn
    Friend WithEvents digidempresacont As DataGridViewTextBoxColumn
    Friend WithEvents digidempresacrm As DataGridViewTextBoxColumn
    Friend WithEvents digruta As DataGridViewTextBoxColumn
    Friend WithEvents digidsuc As DataGridViewTextBoxColumn
    Friend WithEvents dignombreadw As DataGridViewTextBoxColumn
    Friend WithEvents digsucursal As DataGridViewTextBoxColumn
    Friend WithEvents digempresacrm As DataGridViewTextBoxColumn
    Friend WithEvents bddCont As DataGridViewTextBoxColumn
End Class
