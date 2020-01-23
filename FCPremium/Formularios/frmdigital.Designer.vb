<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmdigital
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmdigital))
        Me.LUser = New System.Windows.Forms.Label()
        Me.btnUser = New System.Windows.Forms.Button()
        Me.cbPeriodo = New System.Windows.Forms.ComboBox()
        Me.cbempresa = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgDocDigitales = New System.Windows.Forms.DataGridView()
        Me.iddocdig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgdocAsoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.docFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.docDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgdocdes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgDocAdw = New System.Windows.Forms.DataGridView()
        Me.adwciddocum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.numar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.addgdocmod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digadw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cfech = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cserie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cfolio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.razonso01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cimporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.crefe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmoneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgadwidrubro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgadwiddocmodelo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgAsocDoc = New System.Windows.Forms.DataGridView()
        Me.iddocdiga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idsuba = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digafech = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.diganom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtall = New System.Windows.Forms.TextBox()
        Me.txtasoc = New System.Windows.Forms.TextBox()
        Me.txtpendientes = New System.Windows.Forms.TextBox()
        Me.rball = New System.Windows.Forms.RadioButton()
        Me.rbasoc = New System.Windows.Forms.RadioButton()
        Me.rbpendientes = New System.Windows.Forms.RadioButton()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.cboperacion = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MDigital = New System.Windows.Forms.ToolStrip()
        Me.DConfig = New System.Windows.Forms.ToolStripButton()
        Me.DCerrar = New System.Windows.Forms.ToolStripButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbsucursal = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnDelDig = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtBus = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.LInfo = New System.Windows.Forms.Label()
        Me.btnChange = New System.Windows.Forms.Button()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.pr = New System.Windows.Forms.ProgressBar()
        Me.LCargando = New System.Windows.Forms.Label()
        Me.cbdocmodelo = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMarcar = New System.Windows.Forms.Button()
        Me.btnAsocDoc = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.cbempresa.Size = New System.Drawing.Size(295, 21)
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
        'dgDocDigitales
        '
        Me.dgDocDigitales.AllowDrop = True
        Me.dgDocDigitales.AllowUserToAddRows = False
        Me.dgDocDigitales.AllowUserToDeleteRows = False
        Me.dgDocDigitales.AllowUserToResizeRows = False
        Me.dgDocDigitales.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocDigitales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDocDigitales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.iddocdig, Me.dgdocAsoc, Me.docFecha, Me.docDocumento, Me.dgdocdes})
        Me.dgDocDigitales.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocDigitales.Location = New System.Drawing.Point(3, 180)
        Me.dgDocDigitales.Name = "dgDocDigitales"
        Me.dgDocDigitales.RowHeadersVisible = False
        Me.dgDocDigitales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDocDigitales.Size = New System.Drawing.Size(357, 306)
        Me.dgDocDigitales.TabIndex = 15
        '
        'iddocdig
        '
        Me.iddocdig.HeaderText = "iddocdig"
        Me.iddocdig.Name = "iddocdig"
        Me.iddocdig.Visible = False
        '
        'dgdocAsoc
        '
        Me.dgdocAsoc.HeaderText = "♦"
        Me.dgdocAsoc.Name = "dgdocAsoc"
        Me.dgdocAsoc.ReadOnly = True
        Me.dgdocAsoc.ToolTipText = "Documento Asociado"
        Me.dgdocAsoc.Width = 20
        '
        'docFecha
        '
        Me.docFecha.HeaderText = "Fecha"
        Me.docFecha.Name = "docFecha"
        Me.docFecha.ReadOnly = True
        Me.docFecha.Width = 65
        '
        'docDocumento
        '
        Me.docDocumento.HeaderText = "Documento"
        Me.docDocumento.Name = "docDocumento"
        Me.docDocumento.ReadOnly = True
        Me.docDocumento.Width = 270
        '
        'dgdocdes
        '
        Me.dgdocdes.HeaderText = "Descripcion"
        Me.dgdocdes.Name = "dgdocdes"
        Me.dgdocdes.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Documentos Digitales:"
        '
        'dgDocAdw
        '
        Me.dgDocAdw.AllowUserToAddRows = False
        Me.dgDocAdw.AllowUserToDeleteRows = False
        Me.dgDocAdw.AllowUserToResizeRows = False
        Me.dgDocAdw.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocAdw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDocAdw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.adwciddocum, Me.numar, Me.addgdocmod, Me.digadw, Me.cfech, Me.cserie, Me.cfolio, Me.razonso01, Me.cimporte, Me.crefe, Me.cmoneda, Me.dgadwidrubro, Me.dgadwiddocmodelo})
        Me.dgDocAdw.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocAdw.Location = New System.Drawing.Point(421, 182)
        Me.dgDocAdw.MultiSelect = False
        Me.dgDocAdw.Name = "dgDocAdw"
        Me.dgDocAdw.RowHeadersVisible = False
        Me.dgDocAdw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDocAdw.Size = New System.Drawing.Size(638, 306)
        Me.dgDocAdw.TabIndex = 17
        '
        'adwciddocum
        '
        Me.adwciddocum.HeaderText = "ciddocum01"
        Me.adwciddocum.Name = "adwciddocum"
        Me.adwciddocum.ReadOnly = True
        Me.adwciddocum.Visible = False
        '
        'numar
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.numar.DefaultCellStyle = DataGridViewCellStyle3
        Me.numar.HeaderText = "Num."
        Me.numar.Name = "numar"
        Me.numar.ReadOnly = True
        Me.numar.ToolTipText = "Número de Archivos Asociados"
        Me.numar.Width = 40
        '
        'addgdocmod
        '
        Me.addgdocmod.HeaderText = "Doc. Modelo"
        Me.addgdocmod.Name = "addgdocmod"
        Me.addgdocmod.ReadOnly = True
        Me.addgdocmod.ToolTipText = "Documento Modelo"
        '
        'digadw
        '
        Me.digadw.HeaderText = "Nombre Concepto"
        Me.digadw.Name = "digadw"
        '
        'cfech
        '
        Me.cfech.HeaderText = "Fecha"
        Me.cfech.Name = "cfech"
        Me.cfech.ReadOnly = True
        Me.cfech.Width = 65
        '
        'cserie
        '
        Me.cserie.HeaderText = "Serie"
        Me.cserie.Name = "cserie"
        Me.cserie.ReadOnly = True
        Me.cserie.Width = 40
        '
        'cfolio
        '
        Me.cfolio.HeaderText = "Folio"
        Me.cfolio.Name = "cfolio"
        Me.cfolio.ReadOnly = True
        Me.cfolio.Width = 50
        '
        'razonso01
        '
        Me.razonso01.HeaderText = "Razon Social"
        Me.razonso01.Name = "razonso01"
        Me.razonso01.ReadOnly = True
        '
        'cimporte
        '
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.cimporte.DefaultCellStyle = DataGridViewCellStyle4
        Me.cimporte.HeaderText = "Importe"
        Me.cimporte.Name = "cimporte"
        Me.cimporte.ReadOnly = True
        Me.cimporte.Width = 80
        '
        'crefe
        '
        Me.crefe.HeaderText = "Referencia"
        Me.crefe.Name = "crefe"
        Me.crefe.ReadOnly = True
        '
        'cmoneda
        '
        Me.cmoneda.HeaderText = "Moneda"
        Me.cmoneda.Name = "cmoneda"
        Me.cmoneda.ReadOnly = True
        '
        'dgadwidrubro
        '
        Me.dgadwidrubro.HeaderText = "idrubro"
        Me.dgadwidrubro.Name = "dgadwidrubro"
        Me.dgadwidrubro.ReadOnly = True
        Me.dgadwidrubro.Visible = False
        '
        'dgadwiddocmodelo
        '
        Me.dgadwiddocmodelo.HeaderText = "iddocmodelo"
        Me.dgadwiddocmodelo.Name = "dgadwiddocmodelo"
        Me.dgadwiddocmodelo.ReadOnly = True
        Me.dgadwiddocmodelo.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(418, 165)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(162, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Documentos en AdminPAQ:"
        '
        'dgAsocDoc
        '
        Me.dgAsocDoc.AllowUserToAddRows = False
        Me.dgAsocDoc.AllowUserToDeleteRows = False
        Me.dgAsocDoc.AllowUserToResizeRows = False
        Me.dgAsocDoc.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgAsocDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgAsocDoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.iddocdiga, Me.idsuba, Me.digafech, Me.diganom})
        Me.dgAsocDoc.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgAsocDoc.Location = New System.Drawing.Point(1077, 182)
        Me.dgAsocDoc.MultiSelect = False
        Me.dgAsocDoc.Name = "dgAsocDoc"
        Me.dgAsocDoc.RowHeadersVisible = False
        Me.dgAsocDoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAsocDoc.Size = New System.Drawing.Size(277, 306)
        Me.dgAsocDoc.TabIndex = 19
        '
        'iddocdiga
        '
        Me.iddocdiga.HeaderText = "iddocdi"
        Me.iddocdiga.Name = "iddocdiga"
        Me.iddocdiga.ReadOnly = True
        Me.iddocdiga.Visible = False
        '
        'idsuba
        '
        Me.idsuba.HeaderText = "idsubmenu"
        Me.idsuba.Name = "idsuba"
        Me.idsuba.Visible = False
        '
        'digafech
        '
        Me.digafech.HeaderText = "Fecha"
        Me.digafech.Name = "digafech"
        Me.digafech.ReadOnly = True
        Me.digafech.Width = 65
        '
        'diganom
        '
        Me.diganom.HeaderText = "Nombre Archivo"
        Me.diganom.Name = "diganom"
        Me.diganom.ReadOnly = True
        Me.diganom.Width = 250
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1074, 166)
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
        Me.Panel1.Location = New System.Drawing.Point(6, 504)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 55)
        Me.Panel1.TabIndex = 21
        '
        'txtall
        '
        Me.txtall.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtall.Location = New System.Drawing.Point(178, 26)
        Me.txtall.Name = "txtall"
        Me.txtall.Size = New System.Drawing.Size(47, 20)
        Me.txtall.TabIndex = 5
        Me.txtall.Text = "0"
        Me.txtall.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtasoc
        '
        Me.txtasoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtasoc.Location = New System.Drawing.Point(101, 26)
        Me.txtasoc.Name = "txtasoc"
        Me.txtasoc.Size = New System.Drawing.Size(47, 20)
        Me.txtasoc.TabIndex = 4
        Me.txtasoc.Text = "0"
        Me.txtasoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtpendientes
        '
        Me.txtpendientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtpendientes.Location = New System.Drawing.Point(16, 26)
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
        Me.rball.Location = New System.Drawing.Point(178, 3)
        Me.rball.Name = "rball"
        Me.rball.Size = New System.Drawing.Size(61, 17)
        Me.rball.TabIndex = 2
        Me.rball.Text = "Todos  "
        Me.rball.UseVisualStyleBackColor = False
        '
        'rbasoc
        '
        Me.rbasoc.AutoSize = True
        Me.rbasoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbasoc.Location = New System.Drawing.Point(91, 3)
        Me.rbasoc.Name = "rbasoc"
        Me.rbasoc.Size = New System.Drawing.Size(74, 17)
        Me.rbasoc.TabIndex = 1
        Me.rbasoc.Text = "Asociados"
        Me.rbasoc.UseVisualStyleBackColor = False
        '
        'rbpendientes
        '
        Me.rbpendientes.AutoSize = True
        Me.rbpendientes.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbpendientes.Checked = True
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
        Me.btnadd.Location = New System.Drawing.Point(366, 279)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(39, 36)
        Me.btnadd.TabIndex = 22
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'txtEjercicio
        '
        Me.txtEjercicio.Location = New System.Drawing.Point(291, 63)
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.Size = New System.Drawing.Size(69, 20)
        Me.txtEjercicio.TabIndex = 24
        Me.txtEjercicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboperacion
        '
        Me.cboperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperacion.FormattingEnabled = True
        Me.cboperacion.Location = New System.Drawing.Point(3, 131)
        Me.cboperacion.Name = "cboperacion"
        Me.cboperacion.Size = New System.Drawing.Size(189, 21)
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
        Me.MDigital.Size = New System.Drawing.Size(1354, 51)
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
        Me.Label9.Location = New System.Drawing.Point(198, 115)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Sucursal:"
        '
        'cbsucursal
        '
        Me.cbsucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbsucursal.FormattingEnabled = True
        Me.cbsucursal.Location = New System.Drawing.Point(201, 131)
        Me.cbsucursal.Name = "cbsucursal"
        Me.cbsucursal.Size = New System.Drawing.Size(160, 21)
        Me.cbsucursal.TabIndex = 28
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(188, 489)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(172, 13)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Doble Click para ver el Documento"
        '
        'btnDelDig
        '
        Me.btnDelDig.BackColor = System.Drawing.Color.Red
        Me.btnDelDig.Location = New System.Drawing.Point(1274, 156)
        Me.btnDelDig.Name = "btnDelDig"
        Me.btnDelDig.Size = New System.Drawing.Size(42, 23)
        Me.btnDelDig.TabIndex = 31
        Me.btnDelDig.Text = "DES"
        Me.btnDelDig.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(1170, 491)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(172, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Doble Click para ver el Documento"
        '
        'txtBus
        '
        Me.txtBus.Location = New System.Drawing.Point(660, 132)
        Me.txtBus.Name = "txtBus"
        Me.txtBus.Size = New System.Drawing.Size(205, 20)
        Me.txtBus.TabIndex = 33
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(660, 115)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(150, 13)
        Me.Label12.TabIndex = 34
        Me.Label12.Text = "Busqueda Coincidencias:"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(874, 131)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(41, 24)
        Me.btnSiguiente.TabIndex = 35
        Me.btnSiguiente.Text = "Sig."
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'btnAnterior
        '
        Me.btnAnterior.Location = New System.Drawing.Point(921, 132)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(41, 23)
        Me.btnAnterior.TabIndex = 36
        Me.btnAnterior.Text = "Ant."
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'LInfo
        '
        Me.LInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LInfo.Location = New System.Drawing.Point(418, 491)
        Me.LInfo.Name = "LInfo"
        Me.LInfo.Size = New System.Drawing.Size(546, 73)
        Me.LInfo.TabIndex = 37
        Me.LInfo.Text = "Información"
        '
        'btnChange
        '
        Me.btnChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChange.Location = New System.Drawing.Point(434, 54)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(42, 23)
        Me.btnChange.TabIndex = 38
        Me.btnChange.Text = "> <"
        Me.btnChange.UseVisualStyleBackColor = False
        Me.btnChange.Visible = False
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.Red
        Me.btnDel.Location = New System.Drawing.Point(318, 156)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(42, 23)
        Me.btnDel.TabIndex = 39
        Me.btnDel.Text = "DEL"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'pr
        '
        Me.pr.Location = New System.Drawing.Point(705, 158)
        Me.pr.Name = "pr"
        Me.pr.Size = New System.Drawing.Size(160, 23)
        Me.pr.Step = 20
        Me.pr.TabIndex = 40
        Me.pr.Visible = False
        '
        'LCargando
        '
        Me.LCargando.AutoSize = True
        Me.LCargando.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCargando.Location = New System.Drawing.Point(630, 165)
        Me.LCargando.Name = "LCargando"
        Me.LCargando.Size = New System.Drawing.Size(69, 13)
        Me.LCargando.TabIndex = 41
        Me.LCargando.Text = "Cargando.."
        Me.LCargando.Visible = False
        '
        'cbdocmodelo
        '
        Me.cbdocmodelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbdocmodelo.FormattingEnabled = True
        Me.cbdocmodelo.Location = New System.Drawing.Point(421, 131)
        Me.cbdocmodelo.Name = "cbdocmodelo"
        Me.cbdocmodelo.Size = New System.Drawing.Size(233, 21)
        Me.cbdocmodelo.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(418, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Documento Modelo"
        '
        'btnMarcar
        '
        Me.btnMarcar.Location = New System.Drawing.Point(496, 54)
        Me.btnMarcar.Name = "btnMarcar"
        Me.btnMarcar.Size = New System.Drawing.Size(75, 23)
        Me.btnMarcar.TabIndex = 44
        Me.btnMarcar.Text = "Marcar"
        Me.btnMarcar.UseVisualStyleBackColor = True
        Me.btnMarcar.Visible = False
        '
        'btnAsocDoc
        '
        Me.btnAsocDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAsocDoc.Image = CType(resources.GetObject("btnAsocDoc.Image"), System.Drawing.Image)
        Me.btnAsocDoc.Location = New System.Drawing.Point(1012, 132)
        Me.btnAsocDoc.Name = "btnAsocDoc"
        Me.btnAsocDoc.Size = New System.Drawing.Size(47, 49)
        Me.btnAsocDoc.TabIndex = 45
        Me.btnAsocDoc.Text = "Otros"
        Me.btnAsocDoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAsocDoc.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(366, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(62, 49)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "Buscar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmdigital
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1354, 571)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnAsocDoc)
        Me.Controls.Add(Me.btnMarcar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbdocmodelo)
        Me.Controls.Add(Me.LCargando)
        Me.Controls.Add(Me.pr)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.LInfo)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtBus)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnDelDig)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbsucursal)
        Me.Controls.Add(Me.MDigital)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboperacion)
        Me.Controls.Add(Me.txtEjercicio)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgAsocDoc)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgDocAdw)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgDocDigitales)
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
    Friend WithEvents txtEjercicio As TextBox
    Friend WithEvents cboperacion As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents MDigital As ToolStrip
    Friend WithEvents DConfig As ToolStripButton
    Friend WithEvents DCerrar As ToolStripButton
    Friend WithEvents Label9 As Label
    Friend WithEvents cbsucursal As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents iddocdiga As DataGridViewTextBoxColumn
    Friend WithEvents idsuba As DataGridViewTextBoxColumn
    Friend WithEvents digafech As DataGridViewTextBoxColumn
    Friend WithEvents diganom As DataGridViewTextBoxColumn
    Friend WithEvents btnDelDig As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents txtBus As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnSiguiente As Button
    Friend WithEvents btnAnterior As Button
    Friend WithEvents LInfo As Label
    Friend WithEvents btnChange As Button
    Friend WithEvents btnDel As Button
    Friend WithEvents pr As ProgressBar
    Friend WithEvents LCargando As Label
    Friend WithEvents cbdocmodelo As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents adwciddocum As DataGridViewTextBoxColumn
    Friend WithEvents numar As DataGridViewTextBoxColumn
    Friend WithEvents addgdocmod As DataGridViewTextBoxColumn
    Friend WithEvents digadw As DataGridViewTextBoxColumn
    Friend WithEvents cfech As DataGridViewTextBoxColumn
    Friend WithEvents cserie As DataGridViewTextBoxColumn
    Friend WithEvents cfolio As DataGridViewTextBoxColumn
    Friend WithEvents razonso01 As DataGridViewTextBoxColumn
    Friend WithEvents cimporte As DataGridViewTextBoxColumn
    Friend WithEvents crefe As DataGridViewTextBoxColumn
    Friend WithEvents cmoneda As DataGridViewTextBoxColumn
    Friend WithEvents dgadwidrubro As DataGridViewTextBoxColumn
    Friend WithEvents dgadwiddocmodelo As DataGridViewTextBoxColumn
    Friend WithEvents iddocdig As DataGridViewTextBoxColumn
    Friend WithEvents dgdocAsoc As DataGridViewTextBoxColumn
    Friend WithEvents docFecha As DataGridViewTextBoxColumn
    Friend WithEvents docDocumento As DataGridViewTextBoxColumn
    Friend WithEvents dgdocdes As DataGridViewTextBoxColumn
    Friend WithEvents btnMarcar As Button
    Friend WithEvents btnAsocDoc As Button
    Friend WithEvents Button1 As Button
End Class
