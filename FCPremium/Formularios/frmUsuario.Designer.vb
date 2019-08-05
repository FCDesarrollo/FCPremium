<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuario))
        Me.txtnombre = New System.Windows.Forms.TextBox()
        Me.txtapellidop = New System.Windows.Forms.TextBox()
        Me.txtapellidom = New System.Windows.Forms.TextBox()
        Me.txtuser = New System.Windows.Forms.TextBox()
        Me.txtpass = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgusuarios = New System.Windows.Forms.DataGridView()
        Me.iduser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.uapellidos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.uusuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.utipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ustatu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgmodulos = New System.Windows.Forms.DataGridView()
        Me.uidmodulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unommod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.upermiso = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.cbtipo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtconfirmepass = New System.Windows.Forms.TextBox()
        Me.ckhabilitado = New System.Windows.Forms.CheckBox()
        CType(Me.dgusuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgmodulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtnombre
        '
        Me.txtnombre.Location = New System.Drawing.Point(12, 22)
        Me.txtnombre.Name = "txtnombre"
        Me.txtnombre.Size = New System.Drawing.Size(190, 20)
        Me.txtnombre.TabIndex = 0
        '
        'txtapellidop
        '
        Me.txtapellidop.Location = New System.Drawing.Point(12, 61)
        Me.txtapellidop.Name = "txtapellidop"
        Me.txtapellidop.Size = New System.Drawing.Size(190, 20)
        Me.txtapellidop.TabIndex = 1
        '
        'txtapellidom
        '
        Me.txtapellidom.Location = New System.Drawing.Point(12, 100)
        Me.txtapellidom.Name = "txtapellidom"
        Me.txtapellidom.Size = New System.Drawing.Size(190, 20)
        Me.txtapellidom.TabIndex = 2
        '
        'txtuser
        '
        Me.txtuser.Location = New System.Drawing.Point(14, 139)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(190, 20)
        Me.txtuser.TabIndex = 3
        '
        'txtpass
        '
        Me.txtpass.Location = New System.Drawing.Point(14, 178)
        Me.txtpass.Name = "txtpass"
        Me.txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpass.Size = New System.Drawing.Size(190, 20)
        Me.txtpass.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Nombre(s):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Apellido Paterno:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Apellido Materno:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Usuario:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Password:"
        '
        'dgusuarios
        '
        Me.dgusuarios.AllowUserToAddRows = False
        Me.dgusuarios.AllowUserToDeleteRows = False
        Me.dgusuarios.AllowUserToResizeColumns = False
        Me.dgusuarios.AllowUserToResizeRows = False
        Me.dgusuarios.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgusuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgusuarios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.iduser, Me.unombre, Me.uapellidos, Me.uusuario, Me.utipo, Me.ustatu})
        Me.dgusuarios.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgusuarios.Location = New System.Drawing.Point(1, 304)
        Me.dgusuarios.MultiSelect = False
        Me.dgusuarios.Name = "dgusuarios"
        Me.dgusuarios.ReadOnly = True
        Me.dgusuarios.RowHeadersVisible = False
        Me.dgusuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgusuarios.Size = New System.Drawing.Size(519, 166)
        Me.dgusuarios.TabIndex = 13
        Me.dgusuarios.TabStop = False
        '
        'iduser
        '
        Me.iduser.HeaderText = "iduse"
        Me.iduser.Name = "iduser"
        Me.iduser.ReadOnly = True
        Me.iduser.Visible = False
        '
        'unombre
        '
        Me.unombre.HeaderText = "Nombre"
        Me.unombre.Name = "unombre"
        Me.unombre.ReadOnly = True
        Me.unombre.Width = 120
        '
        'uapellidos
        '
        Me.uapellidos.HeaderText = "Apellidos"
        Me.uapellidos.Name = "uapellidos"
        Me.uapellidos.ReadOnly = True
        Me.uapellidos.Width = 140
        '
        'uusuario
        '
        Me.uusuario.HeaderText = "Usuario"
        Me.uusuario.Name = "uusuario"
        Me.uusuario.ReadOnly = True
        '
        'utipo
        '
        Me.utipo.HeaderText = "Tipo"
        Me.utipo.Name = "utipo"
        Me.utipo.ReadOnly = True
        Me.utipo.Width = 90
        '
        'ustatu
        '
        Me.ustatu.HeaderText = "Activo"
        Me.ustatu.Name = "ustatu"
        Me.ustatu.ReadOnly = True
        Me.ustatu.Width = 60
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(-2, 288)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Lista de Usuarios:"
        '
        'dgmodulos
        '
        Me.dgmodulos.AllowUserToAddRows = False
        Me.dgmodulos.AllowUserToDeleteRows = False
        Me.dgmodulos.AllowUserToResizeColumns = False
        Me.dgmodulos.AllowUserToResizeRows = False
        Me.dgmodulos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgmodulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgmodulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.uidmodulo, Me.unommod, Me.upermiso})
        Me.dgmodulos.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgmodulos.Location = New System.Drawing.Point(215, 62)
        Me.dgmodulos.Name = "dgmodulos"
        Me.dgmodulos.RowHeadersVisible = False
        Me.dgmodulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgmodulos.Size = New System.Drawing.Size(305, 178)
        Me.dgmodulos.TabIndex = 15
        Me.dgmodulos.TabStop = False
        '
        'uidmodulo
        '
        Me.uidmodulo.HeaderText = "idmodulo"
        Me.uidmodulo.Name = "uidmodulo"
        Me.uidmodulo.ReadOnly = True
        Me.uidmodulo.Visible = False
        '
        'unommod
        '
        Me.unommod.HeaderText = "Nombre Modulo"
        Me.unommod.Name = "unommod"
        Me.unommod.ReadOnly = True
        Me.unommod.Width = 200
        '
        'upermiso
        '
        Me.upermiso.HeaderText = "Activo"
        Me.upermiso.Name = "upermiso"
        Me.upermiso.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.upermiso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.upermiso.Width = 80
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(212, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Modulos:"
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(153, 246)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 52)
        Me.btnGuardar.TabIndex = 8
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(234, 246)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 52)
        Me.btnEliminar.TabIndex = 9
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'btnNuevo
        '
        Me.btnNuevo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(315, 246)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(75, 52)
        Me.btnNuevo.TabIndex = 10
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNuevo.UseVisualStyleBackColor = False
        '
        'cbtipo
        '
        Me.cbtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbtipo.FormattingEnabled = True
        Me.cbtipo.Location = New System.Drawing.Point(215, 20)
        Me.cbtipo.Name = "cbtipo"
        Me.cbtipo.Size = New System.Drawing.Size(121, 21)
        Me.cbtipo.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(212, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Tipo Usuario:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 201)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Confirmar Password:"
        '
        'txtconfirmepass
        '
        Me.txtconfirmepass.Location = New System.Drawing.Point(15, 217)
        Me.txtconfirmepass.Name = "txtconfirmepass"
        Me.txtconfirmepass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtconfirmepass.Size = New System.Drawing.Size(190, 20)
        Me.txtconfirmepass.TabIndex = 5
        '
        'ckhabilitado
        '
        Me.ckhabilitado.AutoSize = True
        Me.ckhabilitado.Checked = True
        Me.ckhabilitado.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckhabilitado.Location = New System.Drawing.Point(352, 24)
        Me.ckhabilitado.Name = "ckhabilitado"
        Me.ckhabilitado.Size = New System.Drawing.Size(56, 17)
        Me.ckhabilitado.TabIndex = 7
        Me.ckhabilitado.Text = "Activo"
        Me.ckhabilitado.UseVisualStyleBackColor = True
        Me.ckhabilitado.Visible = False
        '
        'frmUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(524, 476)
        Me.Controls.Add(Me.ckhabilitado)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtconfirmepass)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbtipo)
        Me.Controls.Add(Me.btnNuevo)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dgmodulos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dgusuarios)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtpass)
        Me.Controls.Add(Me.txtuser)
        Me.Controls.Add(Me.txtapellidom)
        Me.Controls.Add(Me.txtapellidop)
        Me.Controls.Add(Me.txtnombre)
        Me.MaximizeBox = False
        Me.Name = "frmUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        CType(Me.dgusuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgmodulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtnombre As TextBox
    Friend WithEvents txtapellidop As TextBox
    Friend WithEvents txtapellidom As TextBox
    Friend WithEvents txtuser As TextBox
    Friend WithEvents txtpass As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dgusuarios As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents dgmodulos As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents btnGuardar As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents cbtipo As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtconfirmepass As TextBox
    Friend WithEvents ckhabilitado As CheckBox
    Friend WithEvents uidmodulo As DataGridViewTextBoxColumn
    Friend WithEvents unommod As DataGridViewTextBoxColumn
    Friend WithEvents upermiso As DataGridViewCheckBoxColumn
    Friend WithEvents iduser As DataGridViewTextBoxColumn
    Friend WithEvents unombre As DataGridViewTextBoxColumn
    Friend WithEvents uapellidos As DataGridViewTextBoxColumn
    Friend WithEvents uusuario As DataGridViewTextBoxColumn
    Friend WithEvents utipo As DataGridViewTextBoxColumn
    Friend WithEvents ustatu As DataGridViewTextBoxColumn
End Class
