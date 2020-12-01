<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.PMenu = New System.Windows.Forms.ToolStrip()
        Me.MUser = New System.Windows.Forms.ToolStripDropDownButton()
        Me.MuserADD = New System.Windows.Forms.ToolStripMenuItem()
        Me.MuserChan = New System.Windows.Forms.ToolStripMenuItem()
        Me.MuserLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.MSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MXml = New System.Windows.Forms.ToolStripButton()
        Me.MPolizas = New System.Windows.Forms.ToolStripButton()
        Me.MBancos = New System.Windows.Forms.ToolStripButton()
        Me.MCaja = New System.Windows.Forms.ToolStripButton()
        Me.MNomina = New System.Windows.Forms.ToolStripButton()
        Me.Msep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MConcilia = New System.Windows.Forms.ToolStripButton()
        Me.MEstados = New System.Windows.Forms.ToolStripButton()
        Me.MActivos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MDigital = New System.Windows.Forms.ToolStripButton()
        Me.MExpedientes = New System.Windows.Forms.ToolStripButton()
        Me.MEntregas = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MLayouts = New System.Windows.Forms.ToolStripButton()
        Me.MSep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MConfig = New System.Windows.Forms.ToolStripButton()
        Me.PMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'PMenu
        '
        Me.PMenu.AutoSize = False
        Me.PMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.PMenu.Font = New System.Drawing.Font("Segoe UI", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.PMenu.GripMargin = New System.Windows.Forms.Padding(3)
        Me.PMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.PMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MUser, Me.MSep1, Me.MXml, Me.MPolizas, Me.MBancos, Me.MCaja, Me.MNomina, Me.Msep2, Me.MConcilia, Me.MEstados, Me.MActivos, Me.ToolStripSeparator1, Me.MDigital, Me.MExpedientes, Me.MEntregas, Me.ToolStripSeparator2, Me.MLayouts, Me.MSep3, Me.MConfig})
        Me.PMenu.Location = New System.Drawing.Point(0, 0)
        Me.PMenu.Name = "PMenu"
        Me.PMenu.Size = New System.Drawing.Size(1102, 60)
        Me.PMenu.TabIndex = 0
        Me.PMenu.Text = "ToolStrip1"
        '
        'MUser
        '
        Me.MUser.AutoSize = False
        Me.MUser.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MuserADD, Me.MuserChan, Me.MuserLog})
        Me.MUser.Image = CType(resources.GetObject("MUser.Image"), System.Drawing.Image)
        Me.MUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MUser.Name = "MUser"
        Me.MUser.Size = New System.Drawing.Size(65, 50)
        Me.MUser.Tag = "0"
        Me.MUser.Text = "Usuarios"
        Me.MUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MuserADD
        '
        Me.MuserADD.Name = "MuserADD"
        Me.MuserADD.Size = New System.Drawing.Size(170, 22)
        Me.MuserADD.Text = "Nuevo"
        '
        'MuserChan
        '
        Me.MuserChan.Name = "MuserChan"
        Me.MuserChan.Size = New System.Drawing.Size(170, 22)
        Me.MuserChan.Text = "Cambiar Usuario"
        '
        'MuserLog
        '
        Me.MuserLog.Name = "MuserLog"
        Me.MuserLog.Size = New System.Drawing.Size(170, 22)
        Me.MuserLog.Text = "Salir"
        '
        'MSep1
        '
        Me.MSep1.Name = "MSep1"
        Me.MSep1.Size = New System.Drawing.Size(6, 60)
        Me.MSep1.Tag = "0"
        '
        'MXml
        '
        Me.MXml.AutoSize = False
        Me.MXml.Image = CType(resources.GetObject("MXml.Image"), System.Drawing.Image)
        Me.MXml.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MXml.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MXml.Name = "MXml"
        Me.MXml.Size = New System.Drawing.Size(60, 50)
        Me.MXml.Tag = "1"
        Me.MXml.Text = "Xml"
        Me.MXml.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MPolizas
        '
        Me.MPolizas.AutoSize = False
        Me.MPolizas.Image = CType(resources.GetObject("MPolizas.Image"), System.Drawing.Image)
        Me.MPolizas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MPolizas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MPolizas.Name = "MPolizas"
        Me.MPolizas.Size = New System.Drawing.Size(60, 50)
        Me.MPolizas.Tag = "2"
        Me.MPolizas.Text = "Polizas"
        Me.MPolizas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MBancos
        '
        Me.MBancos.AutoSize = False
        Me.MBancos.Image = CType(resources.GetObject("MBancos.Image"), System.Drawing.Image)
        Me.MBancos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MBancos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MBancos.Name = "MBancos"
        Me.MBancos.Size = New System.Drawing.Size(60, 50)
        Me.MBancos.Tag = "3"
        Me.MBancos.Text = "Bancos"
        Me.MBancos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MCaja
        '
        Me.MCaja.AutoSize = False
        Me.MCaja.Image = CType(resources.GetObject("MCaja.Image"), System.Drawing.Image)
        Me.MCaja.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MCaja.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MCaja.Name = "MCaja"
        Me.MCaja.Size = New System.Drawing.Size(66, 50)
        Me.MCaja.Tag = "4"
        Me.MCaja.Text = "Caja Chica"
        Me.MCaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.MCaja.ToolTipText = "CAJA CHICA"
        '
        'MNomina
        '
        Me.MNomina.AutoSize = False
        Me.MNomina.Image = CType(resources.GetObject("MNomina.Image"), System.Drawing.Image)
        Me.MNomina.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MNomina.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MNomina.Name = "MNomina"
        Me.MNomina.Size = New System.Drawing.Size(60, 50)
        Me.MNomina.Tag = "5"
        Me.MNomina.Text = "Nomina"
        Me.MNomina.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Msep2
        '
        Me.Msep2.Name = "Msep2"
        Me.Msep2.Size = New System.Drawing.Size(6, 60)
        Me.Msep2.Tag = "0"
        '
        'MConcilia
        '
        Me.MConcilia.AutoSize = False
        Me.MConcilia.Image = CType(resources.GetObject("MConcilia.Image"), System.Drawing.Image)
        Me.MConcilia.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MConcilia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MConcilia.Name = "MConcilia"
        Me.MConcilia.Size = New System.Drawing.Size(76, 50)
        Me.MConcilia.Tag = "6"
        Me.MConcilia.Text = "Conciliación"
        Me.MConcilia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MEstados
        '
        Me.MEstados.AutoSize = False
        Me.MEstados.Image = CType(resources.GetObject("MEstados.Image"), System.Drawing.Image)
        Me.MEstados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MEstados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MEstados.Name = "MEstados"
        Me.MEstados.Size = New System.Drawing.Size(120, 50)
        Me.MEstados.Tag = "7"
        Me.MEstados.Text = "Estados Financieros"
        Me.MEstados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MActivos
        '
        Me.MActivos.AutoSize = False
        Me.MActivos.Image = CType(resources.GetObject("MActivos.Image"), System.Drawing.Image)
        Me.MActivos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MActivos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MActivos.Name = "MActivos"
        Me.MActivos.Size = New System.Drawing.Size(52, 57)
        Me.MActivos.Tag = "8"
        Me.MActivos.Text = "Activos"
        Me.MActivos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 60)
        Me.ToolStripSeparator1.Tag = "0"
        '
        'MDigital
        '
        Me.MDigital.AutoSize = False
        Me.MDigital.Image = CType(resources.GetObject("MDigital.Image"), System.Drawing.Image)
        Me.MDigital.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MDigital.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MDigital.Name = "MDigital"
        Me.MDigital.Size = New System.Drawing.Size(106, 57)
        Me.MDigital.Tag = "9"
        Me.MDigital.Text = "Clip Operaciones"
        Me.MDigital.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MExpedientes
        '
        Me.MExpedientes.AutoSize = False
        Me.MExpedientes.Image = CType(resources.GetObject("MExpedientes.Image"), System.Drawing.Image)
        Me.MExpedientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MExpedientes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MExpedientes.Name = "MExpedientes"
        Me.MExpedientes.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MExpedientes.Size = New System.Drawing.Size(103, 57)
        Me.MExpedientes.Tag = "18"
        Me.MExpedientes.Text = "Clip Expedientes"
        Me.MExpedientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MEntregas
        '
        Me.MEntregas.AutoSize = False
        Me.MEntregas.Image = CType(resources.GetObject("MEntregas.Image"), System.Drawing.Image)
        Me.MEntregas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MEntregas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MEntregas.Name = "MEntregas"
        Me.MEntregas.Size = New System.Drawing.Size(59, 57)
        Me.MEntregas.Tag = "20"
        Me.MEntregas.Text = "Entregas"
        Me.MEntregas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 60)
        Me.ToolStripSeparator2.Tag = "0"
        '
        'MLayouts
        '
        Me.MLayouts.AutoSize = False
        Me.MLayouts.Image = CType(resources.GetObject("MLayouts.Image"), System.Drawing.Image)
        Me.MLayouts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MLayouts.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MLayouts.Name = "MLayouts"
        Me.MLayouts.Size = New System.Drawing.Size(103, 57)
        Me.MLayouts.Tag = "19"
        Me.MLayouts.Text = "Layouts Nomina"
        Me.MLayouts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MSep3
        '
        Me.MSep3.Name = "MSep3"
        Me.MSep3.Size = New System.Drawing.Size(6, 60)
        Me.MSep3.Tag = "0"
        '
        'MConfig
        '
        Me.MConfig.AutoSize = False
        Me.MConfig.Image = CType(resources.GetObject("MConfig.Image"), System.Drawing.Image)
        Me.MConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MConfig.Name = "MConfig"
        Me.MConfig.Size = New System.Drawing.Size(85, 50)
        Me.MConfig.Tag = "-1"
        Me.MConfig.Text = "Configuración"
        Me.MConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1102, 450)
        Me.Controls.Add(Me.PMenu)
        Me.IsMdiContainer = True
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.PMenu.ResumeLayout(False)
        Me.PMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PMenu As ToolStrip
    Friend WithEvents MXml As ToolStripButton
    Friend WithEvents MPolizas As ToolStripButton
    Friend WithEvents MBancos As ToolStripButton
    Friend WithEvents MCaja As ToolStripButton
    Friend WithEvents MNomina As ToolStripButton
    Friend WithEvents MConcilia As ToolStripButton
    Friend WithEvents MEstados As ToolStripButton
    Friend WithEvents MSep1 As ToolStripSeparator
    Friend WithEvents MSep3 As ToolStripSeparator
    Friend WithEvents MConfig As ToolStripButton
    Friend WithEvents Msep2 As ToolStripSeparator
    Friend WithEvents MUser As ToolStripDropDownButton
    Friend WithEvents MuserADD As ToolStripMenuItem
    Friend WithEvents MuserChan As ToolStripMenuItem
    Friend WithEvents MuserLog As ToolStripMenuItem
    Friend WithEvents MActivos As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents MDigital As ToolStripButton
    Friend WithEvents MEntregas As ToolStripButton
    Friend WithEvents MExpedientes As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents MLayouts As ToolStripButton
End Class
