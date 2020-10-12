<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmClipExp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClipExp))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MDigital = New System.Windows.Forms.ToolStrip()
        Me.BTConfigEmpresas = New System.Windows.Forms.ToolStripButton()
        Me.BTConfig = New System.Windows.Forms.ToolStripButton()
        Me.BTCerrar = New System.Windows.Forms.ToolStripButton()
        Me.btnDel = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboperacion = New System.Windows.Forms.ComboBox()
        Me.txtEjercicio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgDocDigitales = New System.Windows.Forms.DataGridView()
        Me.iddocdig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgdocAsoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.docFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.docDocumento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgdocdes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.download = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbempresa = New System.Windows.Forms.ComboBox()
        Me.cbPeriodo = New System.Windows.Forms.ComboBox()
        Me.btnUser = New System.Windows.Forms.Button()
        Me.LUser = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtall = New System.Windows.Forms.TextBox()
        Me.txtasoc = New System.Windows.Forms.TextBox()
        Me.txtpendientes = New System.Windows.Forms.TextBox()
        Me.rball = New System.Windows.Forms.RadioButton()
        Me.rbasoc = New System.Windows.Forms.RadioButton()
        Me.rbpendientes = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cbsucursal = New System.Windows.Forms.ComboBox()
        Me.dgServicios = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBFiltro = New System.Windows.Forms.TextBox()
        Me.CBMenus = New System.Windows.Forms.ComboBox()
        Me.CBSubmenus = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgElementos = New System.Windows.Forms.DataGridView()
        Me.idelemento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.elemento1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.elemento2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgTiposDocto = New System.Windows.Forms.DataGridView()
        Me.idtipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipodocto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TbFiltroEle = New System.Windows.Forms.TextBox()
        Me.LInfo = New System.Windows.Forms.Label()
        Me.btGenera = New System.Windows.Forms.Button()
        Me.tbYear = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cbMonth = New System.Windows.Forms.ComboBox()
        Me.IDServ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodServ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Servicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idmodulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idmenu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Menu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idsubmenu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubMenu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pendientes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idfcmod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MDigital.SuspendLayout()
        CType(Me.dgDocDigitales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgElementos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTiposDocto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MDigital
        '
        Me.MDigital.AutoSize = False
        Me.MDigital.BackColor = System.Drawing.Color.Teal
        Me.MDigital.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTConfigEmpresas, Me.BTConfig, Me.BTCerrar})
        Me.MDigital.Location = New System.Drawing.Point(0, 0)
        Me.MDigital.Name = "MDigital"
        Me.MDigital.Size = New System.Drawing.Size(1163, 51)
        Me.MDigital.TabIndex = 28
        Me.MDigital.Text = "ToolStrip1"
        '
        'BTConfigEmpresas
        '
        Me.BTConfigEmpresas.AutoSize = False
        Me.BTConfigEmpresas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTConfigEmpresas.Image = CType(resources.GetObject("BTConfigEmpresas.Image"), System.Drawing.Image)
        Me.BTConfigEmpresas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BTConfigEmpresas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTConfigEmpresas.Name = "BTConfigEmpresas"
        Me.BTConfigEmpresas.Size = New System.Drawing.Size(87, 48)
        Me.BTConfigEmpresas.Text = "Configuración"
        Me.BTConfigEmpresas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BTConfigEmpresas.ToolTipText = "Configuración de Empresas"
        '
        'BTConfig
        '
        Me.BTConfig.AutoSize = False
        Me.BTConfig.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTConfig.Image = CType(resources.GetObject("BTConfig.Image"), System.Drawing.Image)
        Me.BTConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BTConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTConfig.Name = "BTConfig"
        Me.BTConfig.Size = New System.Drawing.Size(120, 48)
        Me.BTConfig.Text = "Tipos de documento"
        Me.BTConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.BTConfig.ToolTipText = "Configuracion de Tipos de Documento"
        '
        'BTCerrar
        '
        Me.BTCerrar.Image = CType(resources.GetObject("BTCerrar.Image"), System.Drawing.Image)
        Me.BTCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.BTCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTCerrar.Name = "BTCerrar"
        Me.BTCerrar.Size = New System.Drawing.Size(43, 48)
        Me.BTCerrar.Text = "Cerrar"
        Me.BTCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnDel
        '
        Me.btnDel.BackColor = System.Drawing.Color.Red
        Me.btnDel.Location = New System.Drawing.Point(277, 184)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(42, 23)
        Me.btnDel.TabIndex = 55
        Me.btnDel.Text = "DEL"
        Me.btnDel.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 51
        Me.Label8.Text = "Operación:"
        '
        'cboperacion
        '
        Me.cboperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboperacion.FormattingEnabled = True
        Me.cboperacion.Location = New System.Drawing.Point(12, 157)
        Me.cboperacion.Name = "cboperacion"
        Me.cboperacion.Size = New System.Drawing.Size(165, 21)
        Me.cboperacion.TabIndex = 50
        '
        'txtEjercicio
        '
        Me.txtEjercicio.Location = New System.Drawing.Point(300, 74)
        Me.txtEjercicio.Name = "txtEjercicio"
        Me.txtEjercicio.Size = New System.Drawing.Size(69, 20)
        Me.txtEjercicio.TabIndex = 49
        Me.txtEjercicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 190)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Documentos Digitales:"
        '
        'dgDocDigitales
        '
        Me.dgDocDigitales.AllowDrop = True
        Me.dgDocDigitales.AllowUserToAddRows = False
        Me.dgDocDigitales.AllowUserToDeleteRows = False
        Me.dgDocDigitales.AllowUserToResizeRows = False
        Me.dgDocDigitales.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocDigitales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDocDigitales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.iddocdig, Me.dgdocAsoc, Me.docFecha, Me.docDocumento, Me.dgdocdes, Me.download})
        Me.dgDocDigitales.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocDigitales.Location = New System.Drawing.Point(12, 209)
        Me.dgDocDigitales.Name = "dgDocDigitales"
        Me.dgDocDigitales.RowHeadersVisible = False
        Me.dgDocDigitales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDocDigitales.Size = New System.Drawing.Size(357, 306)
        Me.dgDocDigitales.TabIndex = 47
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
        'download
        '
        Me.download.HeaderText = "Download"
        Me.download.Name = "download"
        Me.download.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Empresa:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(297, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Ejercicio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(175, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Periodo:"
        '
        'cbempresa
        '
        Me.cbempresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbempresa.FormattingEnabled = True
        Me.cbempresa.Location = New System.Drawing.Point(12, 117)
        Me.cbempresa.Name = "cbempresa"
        Me.cbempresa.Size = New System.Drawing.Size(357, 21)
        Me.cbempresa.TabIndex = 43
        '
        'cbPeriodo
        '
        Me.cbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPeriodo.FormattingEnabled = True
        Me.cbPeriodo.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbPeriodo.Location = New System.Drawing.Point(178, 75)
        Me.cbPeriodo.Name = "cbPeriodo"
        Me.cbPeriodo.Size = New System.Drawing.Size(116, 21)
        Me.cbPeriodo.TabIndex = 42
        '
        'btnUser
        '
        Me.btnUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUser.Location = New System.Drawing.Point(137, 71)
        Me.btnUser.Name = "btnUser"
        Me.btnUser.Size = New System.Drawing.Size(35, 27)
        Me.btnUser.TabIndex = 41
        Me.btnUser.Text = "...."
        Me.btnUser.UseVisualStyleBackColor = True
        '
        'LUser
        '
        Me.LUser.BackColor = System.Drawing.Color.Silver
        Me.LUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LUser.Location = New System.Drawing.Point(12, 62)
        Me.LUser.Name = "LUser"
        Me.LUser.Size = New System.Drawing.Size(119, 36)
        Me.LUser.TabIndex = 40
        Me.LUser.Text = "USUARIO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(197, 518)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(172, 13)
        Me.Label10.TabIndex = 57
        Me.Label10.Text = "Doble Click para ver el Documento"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtall)
        Me.Panel1.Controls.Add(Me.txtasoc)
        Me.Panel1.Controls.Add(Me.txtpendientes)
        Me.Panel1.Controls.Add(Me.rball)
        Me.Panel1.Controls.Add(Me.rbasoc)
        Me.Panel1.Controls.Add(Me.rbpendientes)
        Me.Panel1.Location = New System.Drawing.Point(12, 534)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(242, 55)
        Me.Panel1.TabIndex = 56
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
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(180, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Sucursal:"
        '
        'cbsucursal
        '
        Me.cbsucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbsucursal.FormattingEnabled = True
        Me.cbsucursal.Location = New System.Drawing.Point(189, 157)
        Me.cbsucursal.Name = "cbsucursal"
        Me.cbsucursal.Size = New System.Drawing.Size(180, 21)
        Me.cbsucursal.TabIndex = 58
        '
        'dgServicios
        '
        Me.dgServicios.AllowUserToAddRows = False
        Me.dgServicios.AllowUserToDeleteRows = False
        Me.dgServicios.AllowUserToResizeRows = False
        Me.dgServicios.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgServicios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IDServ, Me.CodServ, Me.Servicio, Me.idmodulo, Me.Modulo, Me.idmenu, Me.Menu, Me.idsubmenu, Me.SubMenu, Me.pendientes, Me.idfcmod})
        Me.dgServicios.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgServicios.Location = New System.Drawing.Point(398, 115)
        Me.dgServicios.MultiSelect = False
        Me.dgServicios.Name = "dgServicios"
        Me.dgServicios.RowHeadersVisible = False
        Me.dgServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgServicios.Size = New System.Drawing.Size(753, 92)
        Me.dgServicios.TabIndex = 60
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(398, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Servicios:"
        '
        'TBFiltro
        '
        Me.TBFiltro.Location = New System.Drawing.Point(398, 74)
        Me.TBFiltro.Name = "TBFiltro"
        Me.TBFiltro.Size = New System.Drawing.Size(227, 20)
        Me.TBFiltro.TabIndex = 62
        '
        'CBMenus
        '
        Me.CBMenus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBMenus.FormattingEnabled = True
        Me.CBMenus.Location = New System.Drawing.Point(631, 73)
        Me.CBMenus.Name = "CBMenus"
        Me.CBMenus.Size = New System.Drawing.Size(186, 21)
        Me.CBMenus.TabIndex = 63
        '
        'CBSubmenus
        '
        Me.CBSubmenus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBSubmenus.FormattingEnabled = True
        Me.CBSubmenus.Location = New System.Drawing.Point(823, 73)
        Me.CBSubmenus.Name = "CBSubmenus"
        Me.CBSubmenus.Size = New System.Drawing.Size(186, 21)
        Me.CBSubmenus.TabIndex = 64
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(398, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 65
        Me.Label6.Text = "Filtrar:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(631, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "Menus:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(820, 56)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "SubMenus:"
        '
        'btnadd
        '
        Me.btnadd.Image = CType(resources.GetObject("btnadd.Image"), System.Drawing.Image)
        Me.btnadd.Location = New System.Drawing.Point(330, 184)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(39, 22)
        Me.btnadd.TabIndex = 68
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(398, 216)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(131, 13)
        Me.Label12.TabIndex = 71
        Me.Label12.Text = "Listado de elementos:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(909, 216)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(191, 13)
        Me.Label13.TabIndex = 72
        Me.Label13.Text = "Listado de tipos de documentos:"
        '
        'dgElementos
        '
        Me.dgElementos.AllowUserToAddRows = False
        Me.dgElementos.AllowUserToDeleteRows = False
        Me.dgElementos.AllowUserToResizeRows = False
        Me.dgElementos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgElementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgElementos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idelemento, Me.elemento1, Me.elemento2})
        Me.dgElementos.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgElementos.Location = New System.Drawing.Point(398, 232)
        Me.dgElementos.MultiSelect = False
        Me.dgElementos.Name = "dgElementos"
        Me.dgElementos.RowHeadersVisible = False
        Me.dgElementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgElementos.Size = New System.Drawing.Size(492, 283)
        Me.dgElementos.TabIndex = 73
        '
        'idelemento
        '
        Me.idelemento.HeaderText = "idelemento"
        Me.idelemento.Name = "idelemento"
        Me.idelemento.Visible = False
        '
        'elemento1
        '
        Me.elemento1.HeaderText = ""
        Me.elemento1.Name = "elemento1"
        Me.elemento1.Width = 300
        '
        'elemento2
        '
        Me.elemento2.HeaderText = ""
        Me.elemento2.Name = "elemento2"
        Me.elemento2.Width = 190
        '
        'dgTiposDocto
        '
        Me.dgTiposDocto.AllowUserToAddRows = False
        Me.dgTiposDocto.AllowUserToDeleteRows = False
        Me.dgTiposDocto.AllowUserToResizeRows = False
        Me.dgTiposDocto.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgTiposDocto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgTiposDocto.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idtipo, Me.tipodocto})
        Me.dgTiposDocto.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgTiposDocto.Location = New System.Drawing.Point(912, 232)
        Me.dgTiposDocto.MultiSelect = False
        Me.dgTiposDocto.Name = "dgTiposDocto"
        Me.dgTiposDocto.RowHeadersVisible = False
        Me.dgTiposDocto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTiposDocto.Size = New System.Drawing.Size(239, 237)
        Me.dgTiposDocto.TabIndex = 74
        '
        'idtipo
        '
        Me.idtipo.HeaderText = "idtipo"
        Me.idtipo.Name = "idtipo"
        Me.idtipo.Visible = False
        Me.idtipo.Width = 10
        '
        'tipodocto
        '
        Me.tipodocto.HeaderText = "Tipo de Documento"
        Me.tipodocto.Name = "tipodocto"
        Me.tipodocto.Width = 240
        '
        'TbFiltroEle
        '
        Me.TbFiltroEle.Location = New System.Drawing.Point(663, 213)
        Me.TbFiltroEle.Name = "TbFiltroEle"
        Me.TbFiltroEle.Size = New System.Drawing.Size(227, 20)
        Me.TbFiltroEle.TabIndex = 75
        '
        'LInfo
        '
        Me.LInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LInfo.Location = New System.Drawing.Point(398, 518)
        Me.LInfo.Name = "LInfo"
        Me.LInfo.Size = New System.Drawing.Size(492, 71)
        Me.LInfo.TabIndex = 76
        Me.LInfo.Text = "Información"
        '
        'btGenera
        '
        Me.btGenera.Location = New System.Drawing.Point(1080, 54)
        Me.btGenera.Name = "btGenera"
        Me.btGenera.Size = New System.Drawing.Size(71, 55)
        Me.btGenera.TabIndex = 77
        Me.btGenera.Text = "Generar Doctos"
        Me.btGenera.UseVisualStyleBackColor = True
        '
        'tbYear
        '
        Me.tbYear.Enabled = False
        Me.tbYear.Location = New System.Drawing.Point(1063, 497)
        Me.tbYear.Name = "tbYear"
        Me.tbYear.Size = New System.Drawing.Size(86, 20)
        Me.tbYear.TabIndex = 82
        Me.tbYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1060, 479)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(60, 13)
        Me.Label14.TabIndex = 81
        Me.Label14.Text = "Ejercicio:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(906, 479)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 80
        Me.Label15.Text = "Periodo:"
        '
        'cbMonth
        '
        Me.cbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMonth.Enabled = False
        Me.cbMonth.FormattingEnabled = True
        Me.cbMonth.Items.AddRange(New Object() {"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE", "NOVIEMBRE", "DICIEMBRE"})
        Me.cbMonth.Location = New System.Drawing.Point(909, 496)
        Me.cbMonth.Name = "cbMonth"
        Me.cbMonth.Size = New System.Drawing.Size(148, 21)
        Me.cbMonth.TabIndex = 79
        '
        'IDServ
        '
        Me.IDServ.HeaderText = "idservicio"
        Me.IDServ.Name = "IDServ"
        Me.IDServ.ReadOnly = True
        Me.IDServ.Visible = False
        '
        'CodServ
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CodServ.DefaultCellStyle = DataGridViewCellStyle2
        Me.CodServ.HeaderText = "Cod."
        Me.CodServ.Name = "CodServ"
        Me.CodServ.ReadOnly = True
        Me.CodServ.ToolTipText = "Codigo del Servicio"
        Me.CodServ.Width = 80
        '
        'Servicio
        '
        Me.Servicio.HeaderText = "Nombre Servicio"
        Me.Servicio.Name = "Servicio"
        Me.Servicio.ReadOnly = True
        Me.Servicio.ToolTipText = "Nombre Servicio"
        Me.Servicio.Width = 240
        '
        'idmodulo
        '
        Me.idmodulo.HeaderText = "idmodulo"
        Me.idmodulo.Name = "idmodulo"
        Me.idmodulo.Visible = False
        '
        'Modulo
        '
        Me.Modulo.HeaderText = "Modulo"
        Me.Modulo.Name = "Modulo"
        Me.Modulo.ReadOnly = True
        Me.Modulo.Width = 120
        '
        'idmenu
        '
        Me.idmenu.HeaderText = "idmenu"
        Me.idmenu.Name = "idmenu"
        Me.idmenu.Visible = False
        '
        'Menu
        '
        Me.Menu.HeaderText = "Menu"
        Me.Menu.Name = "Menu"
        Me.Menu.ReadOnly = True
        Me.Menu.Width = 120
        '
        'idsubmenu
        '
        Me.idsubmenu.HeaderText = "idsubmenu"
        Me.idsubmenu.Name = "idsubmenu"
        Me.idsubmenu.Visible = False
        '
        'SubMenu
        '
        Me.SubMenu.HeaderText = "SubMenu"
        Me.SubMenu.Name = "SubMenu"
        Me.SubMenu.ReadOnly = True
        Me.SubMenu.Width = 120
        '
        'pendientes
        '
        Me.pendientes.HeaderText = "Pendientes"
        Me.pendientes.Name = "pendientes"
        Me.pendientes.Width = 70
        '
        'idfcmod
        '
        Me.idfcmod.HeaderText = "idfcmodulo"
        Me.idfcmod.Name = "idfcmod"
        Me.idfcmod.Visible = False
        '
        'frmClipExp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1163, 601)
        Me.Controls.Add(Me.tbYear)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cbMonth)
        Me.Controls.Add(Me.btGenera)
        Me.Controls.Add(Me.LInfo)
        Me.Controls.Add(Me.TbFiltroEle)
        Me.Controls.Add(Me.dgTiposDocto)
        Me.Controls.Add(Me.dgElementos)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CBSubmenus)
        Me.Controls.Add(Me.CBMenus)
        Me.Controls.Add(Me.TBFiltro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dgServicios)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbsucursal)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboperacion)
        Me.Controls.Add(Me.txtEjercicio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgDocDigitales)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbempresa)
        Me.Controls.Add(Me.cbPeriodo)
        Me.Controls.Add(Me.btnUser)
        Me.Controls.Add(Me.LUser)
        Me.Controls.Add(Me.MDigital)
        Me.Name = "frmClipExp"
        Me.Text = "Clip Expedientes"
        Me.MDigital.ResumeLayout(False)
        Me.MDigital.PerformLayout()
        CType(Me.dgDocDigitales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgServicios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgElementos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTiposDocto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MDigital As ToolStrip
    Friend WithEvents BTConfig As ToolStripButton
    Friend WithEvents BTCerrar As ToolStripButton
    Friend WithEvents btnDel As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents cboperacion As ComboBox
    Friend WithEvents txtEjercicio As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dgDocDigitales As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cbempresa As ComboBox
    Friend WithEvents cbPeriodo As ComboBox
    Friend WithEvents btnUser As Button
    Friend WithEvents LUser As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtall As TextBox
    Friend WithEvents txtasoc As TextBox
    Friend WithEvents txtpendientes As TextBox
    Friend WithEvents rball As RadioButton
    Friend WithEvents rbasoc As RadioButton
    Friend WithEvents rbpendientes As RadioButton
    Friend WithEvents Label9 As Label
    Friend WithEvents cbsucursal As ComboBox
    Friend WithEvents dgServicios As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents TBFiltro As TextBox
    Friend WithEvents CBMenus As ComboBox
    Friend WithEvents CBSubmenus As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnadd As Button
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents dgElementos As DataGridView
    Friend WithEvents dgTiposDocto As DataGridView
    Friend WithEvents TbFiltroEle As TextBox
    Friend WithEvents idtipo As DataGridViewTextBoxColumn
    Friend WithEvents tipodocto As DataGridViewTextBoxColumn
    Friend WithEvents idelemento As DataGridViewTextBoxColumn
    Friend WithEvents elemento1 As DataGridViewTextBoxColumn
    Friend WithEvents elemento2 As DataGridViewTextBoxColumn
    Friend WithEvents LInfo As Label
    Friend WithEvents BTConfigEmpresas As ToolStripButton
    Friend WithEvents btGenera As Button
    Friend WithEvents iddocdig As DataGridViewTextBoxColumn
    Friend WithEvents dgdocAsoc As DataGridViewTextBoxColumn
    Friend WithEvents docFecha As DataGridViewTextBoxColumn
    Friend WithEvents docDocumento As DataGridViewTextBoxColumn
    Friend WithEvents dgdocdes As DataGridViewTextBoxColumn
    Friend WithEvents download As DataGridViewTextBoxColumn
    Friend WithEvents tbYear As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cbMonth As ComboBox
    Friend WithEvents IDServ As DataGridViewTextBoxColumn
    Friend WithEvents CodServ As DataGridViewTextBoxColumn
    Friend WithEvents Servicio As DataGridViewTextBoxColumn
    Friend WithEvents idmodulo As DataGridViewTextBoxColumn
    Friend WithEvents Modulo As DataGridViewTextBoxColumn
    Friend WithEvents idmenu As DataGridViewTextBoxColumn
    Friend WithEvents Menu As DataGridViewTextBoxColumn
    Friend WithEvents idsubmenu As DataGridViewTextBoxColumn
    Friend WithEvents SubMenu As DataGridViewTextBoxColumn
    Friend WithEvents pendientes As DataGridViewTextBoxColumn
    Friend WithEvents idfcmod As DataGridViewTextBoxColumn
End Class
