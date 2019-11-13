<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmdigital
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmdigital))
        Me.LUser = New System.Windows.Forms.Label()
        Me.btnUser = New System.Windows.Forms.Button()
        Me.cbPeriodo = New System.Windows.Forms.ComboBox()
        Me.cbempresa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgRubros = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgDocDigitales = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgDocAdw = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgAsocDoc = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtall = New System.Windows.Forms.TextBox()
        Me.txtasoc = New System.Windows.Forms.TextBox()
        Me.txtpendientes = New System.Windows.Forms.TextBox()
        Me.rball = New System.Windows.Forms.RadioButton()
        Me.rbasoc = New System.Windows.Forms.RadioButton()
        Me.rbpendientes = New System.Windows.Forms.RadioButton()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.btndel = New System.Windows.Forms.Button()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.cboperacion = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MDigital = New System.Windows.Forms.ToolStrip()
        Me.DConfig = New System.Windows.Forms.ToolStripButton()
        Me.DCerrar = New System.Windows.Forms.ToolStripButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbsucursal = New System.Windows.Forms.ComboBox()
        CType(Me.dgRubros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDocDigitales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgDocAdw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAsocDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.MDigital.SuspendLayout()
        Me.SuspendLayout()
        '
        'LUser
        '
        Me.LUser.BackColor = System.Drawing.Color.Silver
        Me.LUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LUser.Location = New System.Drawing.Point(3, 51)
        Me.LUser.Name = "LUser"
        Me.LUser.Size = New System.Drawing.Size(119, 36)
        Me.LUser.TabIndex = 0
        Me.LUser.Text = "USUARIO"
        '
        'btnUser
        '
        Me.btnUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUser.Location = New System.Drawing.Point(128, 60)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(35, 27)
        Me.btnUser.TabIndex = 1
        Me.btnUser.Text = "...."
        Me.btnUser.UseVisualStyleBackColor = True
        '
        'cbPeriodo
        '
        Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodo.FormattingEnabled = True
        Me.cbPeriodo.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbPeriodo.Location = New System.Drawing.Point(169, 64)
        Me.cbPeriodo.Name = "cbPeriodo"
        Me.cbPeriodo.Size = New System.Drawing.Size(116, 21)
        Me.cbPeriodo.TabIndex = 2
        '
        'cbempresa
        '
        Me.cbempresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbempresa.FormattingEnabled = True
        Me.cbempresa.Location = New System.Drawing.Point(65, 91)
        Me.cbempresa.Name = "cbempresa"
        Me.cbempresa.Size = New System.Drawing.Size(318, 21)
        Me.cbempresa.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(169, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Periodo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(288, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Ejercicio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Empresa:"
        '
        'dgRubros
        '
        Me.dgRubros.AllowUserToAddRows = False
        Me.dgRubros.AllowUserToDeleteRows = False
        Me.dgRubros.AllowUserToResizeColumns = False
        Me.dgRubros.AllowUserToResizeRows = False
        Me.dgRubros.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgRubros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgRubros.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgRubros.Location = New System.Drawing.Point(3, 176)
        Me.dgRubros.Name = "dgRubros"
        Me.dgRubros.RowHeadersVisible = False
        Me.dgRubros.Size = New System.Drawing.Size(217, 310)
        Me.dgRubros.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Rubros:"
        '
        'dgDocDigitales
        '
        Me.dgDocDigitales.AllowUserToAddRows = False
        Me.dgDocDigitales.AllowUserToDeleteRows = False
        Me.dgDocDigitales.AllowUserToResizeColumns = False
        Me.dgDocDigitales.AllowUserToResizeRows = False
        Me.dgDocDigitales.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocDigitales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDocDigitales.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocDigitales.Location = New System.Drawing.Point(228, 176)
        Me.dgDocDigitales.Name = "dgDocDigitales"
        Me.dgDocDigitales.RowHeadersVisible = False
        Me.dgDocDigitales.Size = New System.Drawing.Size(205, 310)
        Me.dgDocDigitales.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(225, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Documentos Digitales:"
        '
        'dgDocAdw
        '
        Me.dgDocAdw.AllowUserToAddRows = False
        Me.dgDocAdw.AllowUserToDeleteRows = False
        Me.dgDocAdw.AllowUserToResizeColumns = False
        Me.dgDocAdw.AllowUserToResizeRows = False
        Me.dgDocAdw.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocAdw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDocAdw.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocAdw.Location = New System.Drawing.Point(487, 131)
        Me.dgDocAdw.Name = "dgDocAdw"
        Me.dgDocAdw.RowHeadersVisible = False
        Me.dgDocAdw.Size = New System.Drawing.Size(361, 355)
        Me.dgDocAdw.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(484, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(162, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Documentos en AdminPAQ:"
        '
        'dgAsocDoc
        '
        Me.dgAsocDoc.AllowUserToAddRows = False
        Me.dgAsocDoc.AllowUserToDeleteRows = False
        Me.dgAsocDoc.AllowUserToResizeColumns = False
        Me.dgAsocDoc.AllowUserToResizeRows = False
        Me.dgAsocDoc.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgAsocDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgAsocDoc.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgAsocDoc.Location = New System.Drawing.Point(854, 131)
        Me.dgAsocDoc.Name = "dgAsocDoc"
        Me.dgAsocDoc.RowHeadersVisible = False
        Me.dgAsocDoc.Size = New System.Drawing.Size(236, 355)
        Me.dgAsocDoc.TabIndex = 19
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(851, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(184, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "Asociados al Docto AdminPAQ:"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtall)
        Me.Panel1.Controls.Add(Me.txtasoc)
        Me.Panel1.Controls.Add(Me.txtpendientes)
        Me.Panel1.Controls.Add(Me.rball)
        Me.Panel1.Controls.Add(Me.rbasoc)
        Me.Panel1.Controls.Add(Me.rbpendientes)
        Me.Panel1.Location = New System.Drawing.Point(228, 494)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(214, 55)
        Me.Panel1.TabIndex = 21
        '
        'txtall
        '
        Me.txtall.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtall.Location = New System.Drawing.Point(155, 27)
        Me.txtall.Name = "txtall"
        Me.txtall.Size = New System.Drawing.Size(47, 20)
        Me.txtall.TabIndex = 5
        Me.txtall.Text = "0"
        Me.txtall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtasoc
        '
        Me.txtasoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtasoc.Location = New System.Drawing.Point(84, 27)
        Me.txtasoc.Name = "txtasoc"
        Me.txtasoc.Size = New System.Drawing.Size(47, 20)
        Me.txtasoc.TabIndex = 4
        Me.txtasoc.Text = "0"
        Me.txtasoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtpendientes
        '
        Me.txtpendientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtpendientes.Location = New System.Drawing.Point(14, 27)
        Me.txtpendientes.Name = "txtpendientes"
        Me.txtpendientes.Size = New System.Drawing.Size(47, 20)
        Me.txtpendientes.TabIndex = 3
        Me.txtpendientes.Text = "0"
        Me.txtpendientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'rball
        '
        Me.rball.AutoSize = True
        Me.rball.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rball.Location = New System.Drawing.Point(151, 3)
        Me.rball.Name = "rball"
        Me.rball.Size = New System.Drawing.Size(61, 17)
        Me.rball.TabIndex = 2
        Me.rball.TabStop = True
        Me.rball.Text = "Todos  "
        Me.rball.UseVisualStyleBackColor = False
        '
        'rbasoc
        '
        Me.rbasoc.AutoSize = True
        Me.rbasoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbasoc.Location = New System.Drawing.Point(79, 3)
        Me.rbasoc.Name = "rbasoc"
        Me.rbasoc.Size = New System.Drawing.Size(74, 17)
        Me.rbasoc.TabIndex = 1
        Me.rbasoc.TabStop = True
        Me.rbasoc.Text = "Asociados"
        Me.rbasoc.UseVisualStyleBackColor = False
        '
        'rbpendientes
        '
        Me.rbpendientes.AutoSize = True
        Me.rbpendientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbpendientes.Location = New System.Drawing.Point(3, 3)
        Me.rbpendientes.Name = "rbpendientes"
        Me.rbpendientes.Size = New System.Drawing.Size(78, 17)
        Me.rbpendientes.TabIndex = 0
        Me.rbpendientes.TabStop = True
        Me.rbpendientes.Text = "Pendientes"
        Me.rbpendientes.UseVisualStyleBackColor = False
        '
        'btnadd
        '
        Me.btnadd.Image = CType(resources.GetObject("btnadd.Image"), System.Drawing.Image)
        Me.btnadd.Location = New System.Drawing.Point(442, 211)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(39, 36)
        Me.btnadd.TabIndex = 22
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'btndel
        '
        Me.btndel.Image = CType(resources.GetObject("btndel.Image"), System.Drawing.Image)
        Me.btndel.Location = New System.Drawing.Point(442, 253)
        Me.btndel.Name = "btndel"
        Me.btndel.Size = New System.Drawing.Size(39, 36)
        Me.btndel.TabIndex = 23
        Me.btndel.UseVisualStyleBackColor = True
        '
        'txtEjercicio
        '
        Me.txtEjercicio.Location = New System.Drawing.Point(291, 63)
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.Size = New System.Drawing.Size(83, 20)
        Me.txtEjercicio.TabIndex = 24
        Me.txtEjercicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboperacion
        '
        Me.cboperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperacion.FormattingEnabled = True
        Me.cboperacion.Location = New System.Drawing.Point(3, 131)
        Me.cboperacion.Name = "cboperacion"
        Me.cboperacion.Size = New System.Drawing.Size(217, 21)
        Me.cboperacion.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Operación:"
        '
        'MDigital
        '
        Me.MDigital.AutoSize = False
        Me.MDigital.BackColor = System.Drawing.Color.Teal
        Me.MDigital.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DConfig, Me.DCerrar})
        Me.MDigital.Location = New System.Drawing.Point(0, 0)
        Me.MDigital.Name = "MDigital"
        Me.MDigital.Size = New System.Drawing.Size(1095, 51)
        Me.MDigital.TabIndex = 27
        Me.MDigital.Text = "ToolStrip1"
        '
        'DConfig
        '
        Me.DConfig.AutoSize = False
        Me.DConfig.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DConfig.Image = CType(resources.GetObject("DConfig.Image"), System.Drawing.Image)
        Me.DConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DConfig.Name = "DConfig"
        Me.DConfig.Size = New System.Drawing.Size(87, 48)
        Me.DConfig.Text = "Configuración"
        Me.DConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'DCerrar
        '
        Me.DCerrar.Image = CType(resources.GetObject("DCerrar.Image"), System.Drawing.Image)
        Me.DCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DCerrar.Name = "DCerrar"
        Me.DCerrar.Size = New System.Drawing.Size(43, 48)
        Me.DCerrar.Text = "Cerrar"
        Me.DCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(225, 115)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Sucursal:"
        '
        'cbsucursal
        '
        Me.cbsucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbsucursal.FormattingEnabled = True
        Me.cbsucursal.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbsucursal.Location = New System.Drawing.Point(228, 131)
        Me.cbsucursal.Name = "cbsucursal"
        Me.cbsucursal.Size = New System.Drawing.Size(157, 21)
        Me.cbsucursal.TabIndex = 28
        '
        'frmdigital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1095, 561)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbsucursal)
        Me.Controls.Add(Me.MDigital)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboperacion)
        Me.Controls.Add(Me.txtEjercicio)
        Me.Controls.Add(Me.btndel)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgAsocDoc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgDocAdw)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgDocDigitales)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgRubros)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbempresa)
        Me.Controls.Add(Me.cbPeriodo)
        Me.Controls.Add(Me.btnUser)
        Me.Controls.Add(Me.LUser)
        Me.MaximizeBox = False
        Me.Name = "frmdigital"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asociación Digital"
        CType(Me.dgRubros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDocDigitales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgDocAdw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAsocDoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MDigital.ResumeLayout(False)
        Me.MDigital.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LUser As Label
    Friend WithEvents btnUser As Button
    Friend WithEvents cbPeriodo As ComboBox
    Friend WithEvents cbempresa As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgRubros As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents dgDocDigitales As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents dgDocAdw As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents dgAsocDoc As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtall As TextBox
    Friend WithEvents txtasoc As TextBox
    Friend WithEvents txtpendientes As TextBox
    Friend WithEvents rball As RadioButton
    Friend WithEvents rbasoc As RadioButton
    Friend WithEvents rbpendientes As RadioButton
    Friend WithEvents btnadd As Button
    Friend WithEvents btndel As Button
    Friend WithEvents txtEjercicio As TextBox
    Friend WithEvents cboperacion As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents MDigital As ToolStrip
    Friend WithEvents DConfig As ToolStripButton
    Friend WithEvents DCerrar As ToolStripButton
    Friend WithEvents Label9 As Label
    Friend WithEvents cbsucursal As ComboBox
End Class
