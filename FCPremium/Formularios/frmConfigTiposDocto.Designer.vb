<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigTiposDocto
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
        Me.TPServicios = New System.Windows.Forms.TabControl()
        Me.TPTipos = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbClave = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CBServicios = New System.Windows.Forms.ComboBox()
        Me.CkEstatus = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBDocto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BTSalir = New System.Windows.Forms.Button()
        Me.BTElimina = New System.Windows.Forms.Button()
        Me.BTAgrega = New System.Windows.Forms.Button()
        Me.BTNuevo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBFiltro = New System.Windows.Forms.TextBox()
        Me.dgServiciosEmpresa = New System.Windows.Forms.DataGridView()
        Me.idtipodocto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipodocto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idservicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codservicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.estatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idmodulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CBEmpresas = New System.Windows.Forms.ComboBox()
        Me.TPTiposGen = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbClaveg = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TBFiltrog = New System.Windows.Forms.TextBox()
        Me.CkEstatusg = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CBServiciosg = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TbDoctog = New System.Windows.Forms.TextBox()
        Me.BTSalirg = New System.Windows.Forms.Button()
        Me.BTEliminag = New System.Windows.Forms.Button()
        Me.BTAgregag = New System.Windows.Forms.Button()
        Me.BTNuevog = New System.Windows.Forms.Button()
        Me.dgServiciosGenerales = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.claveg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idmodulog = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TPServicios.SuspendLayout()
        Me.TPTipos.SuspendLayout()
        CType(Me.dgServiciosEmpresa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPTiposGen.SuspendLayout()
        CType(Me.dgServiciosGenerales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TPServicios
        '
        Me.TPServicios.Controls.Add(Me.TPTipos)
        Me.TPServicios.Controls.Add(Me.TPTiposGen)
        Me.TPServicios.Location = New System.Drawing.Point(12, 12)
        Me.TPServicios.Name = "TPServicios"
        Me.TPServicios.SelectedIndex = 0
        Me.TPServicios.Size = New System.Drawing.Size(856, 351)
        Me.TPServicios.TabIndex = 0
        '
        'TPTipos
        '
        Me.TPTipos.Controls.Add(Me.Label5)
        Me.TPTipos.Controls.Add(Me.tbClave)
        Me.TPTipos.Controls.Add(Me.Label8)
        Me.TPTipos.Controls.Add(Me.CBServicios)
        Me.TPTipos.Controls.Add(Me.CkEstatus)
        Me.TPTipos.Controls.Add(Me.Label4)
        Me.TPTipos.Controls.Add(Me.TBDocto)
        Me.TPTipos.Controls.Add(Me.Label3)
        Me.TPTipos.Controls.Add(Me.BTSalir)
        Me.TPTipos.Controls.Add(Me.BTElimina)
        Me.TPTipos.Controls.Add(Me.BTAgrega)
        Me.TPTipos.Controls.Add(Me.BTNuevo)
        Me.TPTipos.Controls.Add(Me.Label1)
        Me.TPTipos.Controls.Add(Me.TBFiltro)
        Me.TPTipos.Controls.Add(Me.dgServiciosEmpresa)
        Me.TPTipos.Controls.Add(Me.CBEmpresas)
        Me.TPTipos.Location = New System.Drawing.Point(4, 22)
        Me.TPTipos.Name = "TPTipos"
        Me.TPTipos.Padding = New System.Windows.Forms.Padding(3)
        Me.TPTipos.Size = New System.Drawing.Size(848, 325)
        Me.TPTipos.TabIndex = 0
        Me.TPTipos.Text = "Tipos de documentos"
        Me.TPTipos.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(729, 187)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "Clave:"
        '
        'tbClave
        '
        Me.tbClave.Location = New System.Drawing.Point(772, 184)
        Me.tbClave.MaxLength = 3
        Me.tbClave.Name = "tbClave"
        Me.tbClave.Size = New System.Drawing.Size(68, 20)
        Me.tbClave.TabIndex = 64
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(593, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 63
        Me.Label8.Text = "Servicios:"
        '
        'CBServicios
        '
        Me.CBServicios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBServicios.FormattingEnabled = True
        Me.CBServicios.Location = New System.Drawing.Point(593, 157)
        Me.CBServicios.Name = "CBServicios"
        Me.CBServicios.Size = New System.Drawing.Size(247, 21)
        Me.CBServicios.TabIndex = 60
        '
        'CkEstatus
        '
        Me.CkEstatus.AutoSize = True
        Me.CkEstatus.Checked = True
        Me.CkEstatus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkEstatus.Location = New System.Drawing.Point(784, 93)
        Me.CkEstatus.Name = "CkEstatus"
        Me.CkEstatus.Size = New System.Drawing.Size(56, 17)
        Me.CkEstatus.TabIndex = 33
        Me.CkEstatus.Text = "Activo"
        Me.CkEstatus.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(590, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Documento:"
        '
        'TBDocto
        '
        Me.TBDocto.Location = New System.Drawing.Point(593, 113)
        Me.TBDocto.Name = "TBDocto"
        Me.TBDocto.Size = New System.Drawing.Size(247, 20)
        Me.TBDocto.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Buscar:"
        '
        'BTSalir
        '
        Me.BTSalir.Location = New System.Drawing.Point(782, 13)
        Me.BTSalir.Name = "BTSalir"
        Me.BTSalir.Size = New System.Drawing.Size(58, 37)
        Me.BTSalir.TabIndex = 27
        Me.BTSalir.Text = "Salir"
        Me.BTSalir.UseVisualStyleBackColor = True
        '
        'BTElimina
        '
        Me.BTElimina.Location = New System.Drawing.Point(718, 13)
        Me.BTElimina.Name = "BTElimina"
        Me.BTElimina.Size = New System.Drawing.Size(58, 37)
        Me.BTElimina.TabIndex = 26
        Me.BTElimina.Text = "Eliminar"
        Me.BTElimina.UseVisualStyleBackColor = True
        '
        'BTAgrega
        '
        Me.BTAgrega.Location = New System.Drawing.Point(608, 13)
        Me.BTAgrega.Name = "BTAgrega"
        Me.BTAgrega.Size = New System.Drawing.Size(104, 37)
        Me.BTAgrega.TabIndex = 25
        Me.BTAgrega.Text = "Agregar/Modificar"
        Me.BTAgrega.UseVisualStyleBackColor = True
        '
        'BTNuevo
        '
        Me.BTNuevo.Location = New System.Drawing.Point(544, 13)
        Me.BTNuevo.Name = "BTNuevo"
        Me.BTNuevo.Size = New System.Drawing.Size(58, 37)
        Me.BTNuevo.TabIndex = 24
        Me.BTNuevo.Text = "Nuevo"
        Me.BTNuevo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Empresas CRM:"
        '
        'TBFiltro
        '
        Me.TBFiltro.Location = New System.Drawing.Point(6, 68)
        Me.TBFiltro.Name = "TBFiltro"
        Me.TBFiltro.Size = New System.Drawing.Size(293, 20)
        Me.TBFiltro.TabIndex = 22
        '
        'dgServiciosEmpresa
        '
        Me.dgServiciosEmpresa.AllowUserToAddRows = False
        Me.dgServiciosEmpresa.AllowUserToDeleteRows = False
        Me.dgServiciosEmpresa.AllowUserToResizeColumns = False
        Me.dgServiciosEmpresa.AllowUserToResizeRows = False
        Me.dgServiciosEmpresa.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgServiciosEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgServiciosEmpresa.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idtipodocto, Me.tipodocto, Me.idservicio, Me.codservicio, Me.servicio, Me.estatus, Me.clave, Me.idmodulo})
        Me.dgServiciosEmpresa.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgServiciosEmpresa.Location = New System.Drawing.Point(6, 94)
        Me.dgServiciosEmpresa.MultiSelect = False
        Me.dgServiciosEmpresa.Name = "dgServiciosEmpresa"
        Me.dgServiciosEmpresa.ReadOnly = True
        Me.dgServiciosEmpresa.RowHeadersVisible = False
        Me.dgServiciosEmpresa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgServiciosEmpresa.Size = New System.Drawing.Size(578, 225)
        Me.dgServiciosEmpresa.TabIndex = 19
        '
        'idtipodocto
        '
        Me.idtipodocto.HeaderText = "idtipodocto"
        Me.idtipodocto.Name = "idtipodocto"
        Me.idtipodocto.ReadOnly = True
        Me.idtipodocto.Visible = False
        '
        'tipodocto
        '
        Me.tipodocto.HeaderText = "Tipo de Documento"
        Me.tipodocto.Name = "tipodocto"
        Me.tipodocto.ReadOnly = True
        Me.tipodocto.Width = 210
        '
        'idservicio
        '
        Me.idservicio.HeaderText = "idservicio"
        Me.idservicio.Name = "idservicio"
        Me.idservicio.ReadOnly = True
        Me.idservicio.Visible = False
        '
        'codservicio
        '
        Me.codservicio.HeaderText = "Codigo"
        Me.codservicio.Name = "codservicio"
        Me.codservicio.ReadOnly = True
        Me.codservicio.Width = 80
        '
        'servicio
        '
        Me.servicio.HeaderText = "Servicio"
        Me.servicio.Name = "servicio"
        Me.servicio.ReadOnly = True
        Me.servicio.Width = 210
        '
        'estatus
        '
        Me.estatus.HeaderText = "Estatus"
        Me.estatus.Name = "estatus"
        Me.estatus.ReadOnly = True
        Me.estatus.Width = 70
        '
        'clave
        '
        Me.clave.HeaderText = "Clave"
        Me.clave.Name = "clave"
        Me.clave.ReadOnly = True
        Me.clave.Visible = False
        '
        'idmodulo
        '
        Me.idmodulo.HeaderText = "IDModulo"
        Me.idmodulo.Name = "idmodulo"
        Me.idmodulo.ReadOnly = True
        Me.idmodulo.Visible = False
        '
        'CBEmpresas
        '
        Me.CBEmpresas.FormattingEnabled = True
        Me.CBEmpresas.Location = New System.Drawing.Point(6, 22)
        Me.CBEmpresas.Name = "CBEmpresas"
        Me.CBEmpresas.Size = New System.Drawing.Size(293, 21)
        Me.CBEmpresas.TabIndex = 2
        '
        'TPTiposGen
        '
        Me.TPTiposGen.Controls.Add(Me.Label6)
        Me.TPTiposGen.Controls.Add(Me.tbClaveg)
        Me.TPTiposGen.Controls.Add(Me.Label12)
        Me.TPTiposGen.Controls.Add(Me.TBFiltrog)
        Me.TPTiposGen.Controls.Add(Me.CkEstatusg)
        Me.TPTiposGen.Controls.Add(Me.Label11)
        Me.TPTiposGen.Controls.Add(Me.CBServiciosg)
        Me.TPTiposGen.Controls.Add(Me.Label7)
        Me.TPTiposGen.Controls.Add(Me.TbDoctog)
        Me.TPTiposGen.Controls.Add(Me.BTSalirg)
        Me.TPTiposGen.Controls.Add(Me.BTEliminag)
        Me.TPTiposGen.Controls.Add(Me.BTAgregag)
        Me.TPTiposGen.Controls.Add(Me.BTNuevog)
        Me.TPTiposGen.Controls.Add(Me.dgServiciosGenerales)
        Me.TPTiposGen.Controls.Add(Me.Label2)
        Me.TPTiposGen.Location = New System.Drawing.Point(4, 22)
        Me.TPTiposGen.Name = "TPTiposGen"
        Me.TPTiposGen.Padding = New System.Windows.Forms.Padding(3)
        Me.TPTiposGen.Size = New System.Drawing.Size(848, 325)
        Me.TPTiposGen.TabIndex = 1
        Me.TPTiposGen.Text = "Tipos de documentos generales"
        Me.TPTiposGen.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(729, 156)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(37, 13)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Clave:"
        '
        'tbClaveg
        '
        Me.tbClaveg.Location = New System.Drawing.Point(772, 153)
        Me.tbClaveg.MaxLength = 3
        Me.tbClaveg.Name = "tbClaveg"
        Me.tbClaveg.Size = New System.Drawing.Size(68, 20)
        Me.tbClaveg.TabIndex = 73
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 72
        Me.Label12.Text = "Buscar:"
        '
        'TBFiltrog
        '
        Me.TBFiltrog.Location = New System.Drawing.Point(6, 22)
        Me.TBFiltrog.Name = "TBFiltrog"
        Me.TBFiltrog.Size = New System.Drawing.Size(293, 20)
        Me.TBFiltrog.TabIndex = 71
        '
        'CkEstatusg
        '
        Me.CkEstatusg.AutoSize = True
        Me.CkEstatusg.Checked = True
        Me.CkEstatusg.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkEstatusg.Location = New System.Drawing.Point(786, 67)
        Me.CkEstatusg.Name = "CkEstatusg"
        Me.CkEstatusg.Size = New System.Drawing.Size(56, 17)
        Me.CkEstatusg.TabIndex = 67
        Me.CkEstatusg.Text = "Activo"
        Me.CkEstatusg.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(590, 110)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 66
        Me.Label11.Text = "Servicios:"
        '
        'CBServiciosg
        '
        Me.CBServiciosg.FormattingEnabled = True
        Me.CBServiciosg.Location = New System.Drawing.Point(590, 126)
        Me.CBServiciosg.Name = "CBServiciosg"
        Me.CBServiciosg.Size = New System.Drawing.Size(250, 21)
        Me.CBServiciosg.TabIndex = 65
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(589, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Documento:"
        '
        'TbDoctog
        '
        Me.TbDoctog.Location = New System.Drawing.Point(592, 87)
        Me.TbDoctog.Name = "TbDoctog"
        Me.TbDoctog.Size = New System.Drawing.Size(250, 20)
        Me.TbDoctog.TabIndex = 38
        '
        'BTSalirg
        '
        Me.BTSalirg.Location = New System.Drawing.Point(784, 13)
        Me.BTSalirg.Name = "BTSalirg"
        Me.BTSalirg.Size = New System.Drawing.Size(58, 37)
        Me.BTSalirg.TabIndex = 37
        Me.BTSalirg.Text = "Salir"
        Me.BTSalirg.UseVisualStyleBackColor = True
        '
        'BTEliminag
        '
        Me.BTEliminag.Location = New System.Drawing.Point(720, 13)
        Me.BTEliminag.Name = "BTEliminag"
        Me.BTEliminag.Size = New System.Drawing.Size(58, 37)
        Me.BTEliminag.TabIndex = 36
        Me.BTEliminag.Text = "Eliminar"
        Me.BTEliminag.UseVisualStyleBackColor = True
        '
        'BTAgregag
        '
        Me.BTAgregag.Location = New System.Drawing.Point(632, 13)
        Me.BTAgregag.Name = "BTAgregag"
        Me.BTAgregag.Size = New System.Drawing.Size(82, 37)
        Me.BTAgregag.TabIndex = 35
        Me.BTAgregag.Text = "Agregar o modificar"
        Me.BTAgregag.UseVisualStyleBackColor = True
        '
        'BTNuevog
        '
        Me.BTNuevog.Location = New System.Drawing.Point(568, 13)
        Me.BTNuevog.Name = "BTNuevog"
        Me.BTNuevog.Size = New System.Drawing.Size(58, 37)
        Me.BTNuevog.TabIndex = 34
        Me.BTNuevog.Text = "Nuevo"
        Me.BTNuevog.UseVisualStyleBackColor = True
        '
        'dgServiciosGenerales
        '
        Me.dgServiciosGenerales.AllowUserToAddRows = False
        Me.dgServiciosGenerales.AllowUserToDeleteRows = False
        Me.dgServiciosGenerales.AllowUserToResizeColumns = False
        Me.dgServiciosGenerales.AllowUserToResizeRows = False
        Me.dgServiciosGenerales.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgServiciosGenerales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgServiciosGenerales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.claveg, Me.idmodulog})
        Me.dgServiciosGenerales.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgServiciosGenerales.Location = New System.Drawing.Point(6, 68)
        Me.dgServiciosGenerales.MultiSelect = False
        Me.dgServiciosGenerales.Name = "dgServiciosGenerales"
        Me.dgServiciosGenerales.RowHeadersVisible = False
        Me.dgServiciosGenerales.Size = New System.Drawing.Size(578, 236)
        Me.dgServiciosGenerales.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 16)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Listado de servicios generales."
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "idtipodocto"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Tipo de Documento"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 210
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "idservicio"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Codigo"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Servicio"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 210
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Estatus"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 70
        '
        'claveg
        '
        Me.claveg.HeaderText = "claveg"
        Me.claveg.Name = "claveg"
        Me.claveg.Visible = False
        '
        'idmodulog
        '
        Me.idmodulog.HeaderText = "idmodulog"
        Me.idmodulog.Name = "idmodulog"
        Me.idmodulog.Visible = False
        '
        'frmConfigTiposDocto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 375)
        Me.Controls.Add(Me.TPServicios)
        Me.Name = "frmConfigTiposDocto"
        Me.Text = "Configuracion Tipos de Documento"
        Me.TPServicios.ResumeLayout(False)
        Me.TPTipos.ResumeLayout(False)
        Me.TPTipos.PerformLayout()
        CType(Me.dgServiciosEmpresa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPTiposGen.ResumeLayout(False)
        Me.TPTiposGen.PerformLayout()
        CType(Me.dgServiciosGenerales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TPServicios As TabControl
    Friend WithEvents TPTipos As TabPage
    Friend WithEvents TPTiposGen As TabPage
    Friend WithEvents CBEmpresas As ComboBox
    Friend WithEvents dgServiciosEmpresa As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents dgServiciosGenerales As DataGridView
    Friend WithEvents BTSalir As Button
    Friend WithEvents BTElimina As Button
    Friend WithEvents BTAgrega As Button
    Friend WithEvents BTNuevo As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TBFiltro As TextBox
    Friend WithEvents CkEstatus As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TBDocto As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TbDoctog As TextBox
    Friend WithEvents BTSalirg As Button
    Friend WithEvents BTEliminag As Button
    Friend WithEvents BTAgregag As Button
    Friend WithEvents BTNuevog As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents CBServicios As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TBFiltrog As TextBox
    Friend WithEvents CkEstatusg As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents CBServiciosg As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbClave As TextBox
    Friend WithEvents idtipodocto As DataGridViewTextBoxColumn
    Friend WithEvents tipodocto As DataGridViewTextBoxColumn
    Friend WithEvents idservicio As DataGridViewTextBoxColumn
    Friend WithEvents codservicio As DataGridViewTextBoxColumn
    Friend WithEvents servicio As DataGridViewTextBoxColumn
    Friend WithEvents estatus As DataGridViewTextBoxColumn
    Friend WithEvents clave As DataGridViewTextBoxColumn
    Friend WithEvents idmodulo As DataGridViewTextBoxColumn
    Friend WithEvents Label6 As Label
    Friend WithEvents tbClaveg As TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents claveg As DataGridViewTextBoxColumn
    Friend WithEvents idmodulog As DataGridViewTextBoxColumn
End Class
