<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfig
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfig))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabParam = New System.Windows.Forms.TabPage()
        Me.btnActiva = New System.Windows.Forms.Button()
        Me.txtRazon = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtRfc = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.linfo2 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.tabGen = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtEmpresas = New System.Windows.Forms.TextBox()
        Me.txtSDK = New System.Windows.Forms.TextBox()
        Me.TBSA = New System.Windows.Forms.TextBox()
        Me.TBUID = New System.Windows.Forms.TextBox()
        Me.TBBDDGen = New System.Windows.Forms.TextBox()
        Me.TBSql = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.linfo = New System.Windows.Forms.Label()
        Me.BtInstala = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.mpConfig = New System.Windows.Forms.TabControl()
        Me.tabModulos = New System.Windows.Forms.TabPage()
        Me.btnDescarga = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.dgModulos = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.versiones = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Download = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.fichaver = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.ficha = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.tabParam.SuspendLayout()
        Me.tabGen.SuspendLayout()
        Me.mpConfig.SuspendLayout()
        Me.tabModulos.SuspendLayout()
        CType(Me.dgModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabParam
        '
        Me.tabParam.Controls.Add(Me.btnActiva)
        Me.tabParam.Controls.Add(Me.txtRazon)
        Me.tabParam.Controls.Add(Me.Label18)
        Me.tabParam.Controls.Add(Me.txtRfc)
        Me.tabParam.Controls.Add(Me.Label11)
        Me.tabParam.Controls.Add(Me.linfo2)
        Me.tabParam.Controls.Add(Me.Label13)
        Me.tabParam.Controls.Add(Me.btnGuardar)
        Me.tabParam.Location = New System.Drawing.Point(4, 22)
        Me.tabParam.Name = "tabParam"
        Me.tabParam.Padding = New System.Windows.Forms.Padding(3)
        Me.tabParam.Size = New System.Drawing.Size(544, 360)
        Me.tabParam.TabIndex = 1
        Me.tabParam.Text = "Parametros"
        Me.tabParam.UseVisualStyleBackColor = True
        '
        'btnActiva
        '
        Me.btnActiva.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnActiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActiva.Location = New System.Drawing.Point(215, 215)
        Me.btnActiva.Name = "btnActiva"
        Me.btnActiva.Size = New System.Drawing.Size(122, 36)
        Me.btnActiva.TabIndex = 16
        Me.btnActiva.Text = "Activar Producto"
        Me.btnActiva.UseVisualStyleBackColor = False
        '
        'txtRazon
        '
        Me.txtRazon.Location = New System.Drawing.Point(136, 29)
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.Size = New System.Drawing.Size(298, 20)
        Me.txtRazon.TabIndex = 30
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(183, 13)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(154, 13)
        Me.Label18.TabIndex = 31
        Me.Label18.Text = "Nombre Cliente o Razon Social"
        '
        'txtRfc
        '
        Me.txtRfc.Location = New System.Drawing.Point(136, 68)
        Me.txtRfc.Name = "txtRfc"
        Me.txtRfc.Size = New System.Drawing.Size(298, 20)
        Me.txtRfc.TabIndex = 28
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(237, 52)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 13)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "RFCCliente"
        '
        'linfo2
        '
        Me.linfo2.BackColor = System.Drawing.Color.Red
        Me.linfo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linfo2.Location = New System.Drawing.Point(144, 143)
        Me.linfo2.Name = "linfo2"
        Me.linfo2.Size = New System.Drawing.Size(290, 18)
        Me.linfo2.TabIndex = 27
        Me.linfo2.Text = "!No se han Configurado todos los parametros.!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.linfo2.Visible = False
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(96, 100)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(412, 30)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "1.- Datos del Cliente para Agregar a nuestra base de Datos." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnGuardar.Location = New System.Drawing.Point(226, 164)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(101, 35)
        Me.btnGuardar.TabIndex = 25
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'tabGen
        '
        Me.tabGen.Controls.Add(Me.Label17)
        Me.tabGen.Controls.Add(Me.txtEmpresas)
        Me.tabGen.Controls.Add(Me.txtSDK)
        Me.tabGen.Controls.Add(Me.TBSA)
        Me.tabGen.Controls.Add(Me.TBUID)
        Me.tabGen.Controls.Add(Me.TBBDDGen)
        Me.tabGen.Controls.Add(Me.TBSql)
        Me.tabGen.Controls.Add(Me.Label15)
        Me.tabGen.Controls.Add(Me.Label14)
        Me.tabGen.Controls.Add(Me.linfo)
        Me.tabGen.Controls.Add(Me.BtInstala)
        Me.tabGen.Controls.Add(Me.Label1)
        Me.tabGen.Controls.Add(Me.Label2)
        Me.tabGen.Controls.Add(Me.Label3)
        Me.tabGen.Controls.Add(Me.Label4)
        Me.tabGen.Location = New System.Drawing.Point(4, 22)
        Me.tabGen.Name = "tabGen"
        Me.tabGen.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGen.Size = New System.Drawing.Size(544, 360)
        Me.tabGen.TabIndex = 0
        Me.tabGen.Text = "General"
        Me.tabGen.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(16, 124)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(399, 10)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtEmpresas
        '
        Me.txtEmpresas.Location = New System.Drawing.Point(19, 198)
        Me.txtEmpresas.Name = "txtEmpresas"
        Me.txtEmpresas.Size = New System.Drawing.Size(298, 20)
        Me.txtEmpresas.TabIndex = 12
        '
        'txtSDK
        '
        Me.txtSDK.Location = New System.Drawing.Point(19, 156)
        Me.txtSDK.Name = "txtSDK"
        Me.txtSDK.Size = New System.Drawing.Size(298, 20)
        Me.txtSDK.TabIndex = 10
        '
        'TBSA
        '
        Me.TBSA.Location = New System.Drawing.Point(133, 101)
        Me.TBSA.Name = "TBSA"
        Me.TBSA.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TBSA.Size = New System.Drawing.Size(100, 20)
        Me.TBSA.TabIndex = 3
        '
        'TBUID
        '
        Me.TBUID.Location = New System.Drawing.Point(19, 101)
        Me.TBUID.Name = "TBUID"
        Me.TBUID.Size = New System.Drawing.Size(100, 20)
        Me.TBUID.TabIndex = 2
        '
        'TBBDDGen
        '
        Me.TBBDDGen.Location = New System.Drawing.Point(19, 62)
        Me.TBBDDGen.Name = "TBBDDGen"
        Me.TBBDDGen.Size = New System.Drawing.Size(214, 20)
        Me.TBBDDGen.TabIndex = 1
        '
        'TBSql
        '
        Me.TBSql.Location = New System.Drawing.Point(19, 19)
        Me.TBSql.Name = "TBSql"
        Me.TBSql.Size = New System.Drawing.Size(214, 20)
        Me.TBSql.TabIndex = 0
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(16, 182)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(163, 13)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Ruta de Empresas de AdminPAQ"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(16, 140)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(124, 13)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Ruta SDK de AdminPAQ"
        '
        'linfo
        '
        Me.linfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.linfo.Location = New System.Drawing.Point(16, 221)
        Me.linfo.Name = "linfo"
        Me.linfo.Size = New System.Drawing.Size(399, 32)
        Me.linfo.TabIndex = 9
        Me.linfo.Text = "Intalación" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Guarda la configuración Principal para los Modulos."
        '
        'BtInstala
        '
        Me.BtInstala.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtInstala.Location = New System.Drawing.Point(173, 256)
        Me.BtInstala.Name = "BtInstala"
        Me.BtInstala.Size = New System.Drawing.Size(82, 35)
        Me.BtInstala.TabIndex = 8
        Me.BtInstala.Text = "Instalar"
        Me.BtInstala.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Instancia General"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Base de Datos General"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Usuario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(130, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Contraseña"
        '
        'mpConfig
        '
        Me.mpConfig.Controls.Add(Me.tabGen)
        Me.mpConfig.Controls.Add(Me.tabParam)
        Me.mpConfig.Controls.Add(Me.tabModulos)
        Me.mpConfig.Location = New System.Drawing.Point(12, 12)
        Me.mpConfig.Name = "mpConfig"
        Me.mpConfig.SelectedIndex = 0
        Me.mpConfig.Size = New System.Drawing.Size(552, 386)
        Me.mpConfig.TabIndex = 1
        '
        'tabModulos
        '
        Me.tabModulos.Controls.Add(Me.btnDescarga)
        Me.tabModulos.Controls.Add(Me.Label7)
        Me.tabModulos.Controls.Add(Me.btnCargar)
        Me.tabModulos.Controls.Add(Me.dgModulos)
        Me.tabModulos.Controls.Add(Me.Label8)
        Me.tabModulos.Location = New System.Drawing.Point(4, 22)
        Me.tabModulos.Name = "tabModulos"
        Me.tabModulos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabModulos.Size = New System.Drawing.Size(544, 360)
        Me.tabModulos.TabIndex = 2
        Me.tabModulos.Text = "Instalar Modulos"
        Me.tabModulos.UseVisualStyleBackColor = True
        '
        'btnDescarga
        '
        Me.btnDescarga.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDescarga.Location = New System.Drawing.Point(286, 6)
        Me.btnDescarga.Name = "btnDescarga"
        Me.btnDescarga.Size = New System.Drawing.Size(150, 32)
        Me.btnDescarga.TabIndex = 15
        Me.btnDescarga.Text = "Descargar Actualizaciónes"
        Me.btnDescarga.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(3, 273)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(433, 50)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = resources.GetString("Label7.Text")
        '
        'btnCargar
        '
        Me.btnCargar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCargar.Location = New System.Drawing.Point(160, 6)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(106, 32)
        Me.btnCargar.TabIndex = 13
        Me.btnCargar.Text = "Consultar Modulos"
        Me.btnCargar.UseVisualStyleBackColor = False
        '
        'dgModulos
        '
        Me.dgModulos.AllowUserToAddRows = False
        Me.dgModulos.AllowUserToDeleteRows = False
        Me.dgModulos.AllowUserToResizeColumns = False
        Me.dgModulos.AllowUserToResizeRows = False
        Me.dgModulos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgModulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewCheckBoxColumn1, Me.fecha, Me.versiones, Me.Download, Me.fichaver, Me.ficha})
        Me.dgModulos.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgModulos.Location = New System.Drawing.Point(6, 41)
        Me.dgModulos.Name = "dgModulos"
        Me.dgModulos.RowHeadersVisible = False
        Me.dgModulos.Size = New System.Drawing.Size(532, 226)
        Me.dgModulos.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Modulos Disponibles." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "IDModulo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre Modulo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 130
        '
        'DataGridViewTextBoxColumn3
        '
        DataGridViewCellStyle3.Format = "0.##"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn3.HeaderText = "Versión"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 45
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Visible"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 42
        '
        'fecha
        '
        Me.fecha.HeaderText = "Fecha Act."
        Me.fecha.Name = "fecha"
        Me.fecha.ToolTipText = "Fecha de Actualización"
        Me.fecha.Width = 75
        '
        'versiones
        '
        DataGridViewCellStyle4.Format = "0.##"
        Me.versiones.DefaultCellStyle = DataGridViewCellStyle4
        Me.versiones.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.versiones.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.versiones.HeaderText = "Versiones"
        Me.versiones.Name = "versiones"
        Me.versiones.Width = 62
        '
        'Download
        '
        Me.Download.HeaderText = "Desc."
        Me.Download.Name = "Download"
        Me.Download.ToolTipText = "Descargar"
        Me.Download.Width = 40
        '
        'fichaver
        '
        Me.fichaver.HeaderText = "Ficha Ver."
        Me.fichaver.Name = "fichaver"
        Me.fichaver.ReadOnly = True
        Me.fichaver.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.fichaver.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.fichaver.ToolTipText = "Ficha de la Versión"
        Me.fichaver.Width = 70
        '
        'ficha
        '
        Me.ficha.HeaderText = "Ficha Tec."
        Me.ficha.Name = "ficha"
        Me.ficha.ReadOnly = True
        Me.ficha.ToolTipText = "Ficha Tecnica del Modulo"
        Me.ficha.Width = 70
        '
        'frmConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 410)
        Me.Controls.Add(Me.mpConfig)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfig"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración"
        Me.tabParam.ResumeLayout(False)
        Me.tabParam.PerformLayout()
        Me.tabGen.ResumeLayout(False)
        Me.tabGen.PerformLayout()
        Me.mpConfig.ResumeLayout(False)
        Me.tabModulos.ResumeLayout(False)
        Me.tabModulos.PerformLayout()
        CType(Me.dgModulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabParam As TabPage
    Friend WithEvents tabGen As TabPage
    Friend WithEvents Label17 As Label
    Friend WithEvents txtEmpresas As TextBox
    Friend WithEvents txtSDK As TextBox
    Friend WithEvents TBSA As TextBox
    Friend WithEvents TBUID As TextBox
    Friend WithEvents TBBDDGen As TextBox
    Friend WithEvents TBSql As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents linfo As Label
    Friend WithEvents BtInstala As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents mpConfig As TabControl
    Friend WithEvents tabModulos As TabPage
    Friend WithEvents Label7 As Label
    Friend WithEvents btnCargar As Button
    Friend WithEvents dgModulos As DataGridView
    Friend WithEvents Label8 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents linfo2 As Label
    Friend WithEvents txtRazon As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtRfc As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnDescarga As Button
    Friend WithEvents btnActiva As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents fecha As DataGridViewTextBoxColumn
    Friend WithEvents versiones As DataGridViewComboBoxColumn
    Friend WithEvents Download As DataGridViewCheckBoxColumn
    Friend WithEvents fichaver As DataGridViewButtonColumn
    Friend WithEvents ficha As DataGridViewButtonColumn
End Class
