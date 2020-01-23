<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddDoc
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dtFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbConcepAdw = New System.Windows.Forms.ComboBox()
        Me.dgDocAdw = New System.Windows.Forms.DataGridView()
        Me.adwciddocum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.digadw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cfech = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cserie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cfolio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.razonso01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cimporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.crefe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmoneda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dglistadoc = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgidsu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAsociar = New System.Windows.Forms.Button()
        Me.btnsalir = New System.Windows.Forms.Button()
        Me.txtbusca = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAnterior = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        CType(Me.dgDocAdw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dglistadoc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtFecha
        '
        Me.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFecha.Location = New System.Drawing.Point(12, 24)
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(95, 20)
        Me.dtFecha.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha"
        '
        'cbConcepAdw
        '
        Me.cbConcepAdw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbConcepAdw.FormattingEnabled = True
        Me.cbConcepAdw.Location = New System.Drawing.Point(121, 23)
        Me.cbConcepAdw.Name = "cbConcepAdw"
        Me.cbConcepAdw.Size = New System.Drawing.Size(249, 21)
        Me.cbConcepAdw.TabIndex = 4
        '
        'dgDocAdw
        '
        Me.dgDocAdw.AllowUserToAddRows = False
        Me.dgDocAdw.AllowUserToDeleteRows = False
        Me.dgDocAdw.AllowUserToResizeRows = False
        Me.dgDocAdw.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocAdw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDocAdw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.adwciddocum, Me.digadw, Me.cfech, Me.cserie, Me.cfolio, Me.razonso01, Me.cimporte, Me.crefe, Me.cmoneda})
        Me.dgDocAdw.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDocAdw.Location = New System.Drawing.Point(12, 72)
        Me.dgDocAdw.MultiSelect = False
        Me.dgDocAdw.Name = "dgDocAdw"
        Me.dgDocAdw.RowHeadersVisible = False
        Me.dgDocAdw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDocAdw.Size = New System.Drawing.Size(540, 232)
        Me.dgDocAdw.TabIndex = 18
        '
        'adwciddocum
        '
        Me.adwciddocum.HeaderText = "ciddocum01"
        Me.adwciddocum.Name = "adwciddocum"
        Me.adwciddocum.ReadOnly = True
        Me.adwciddocum.Visible = False
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
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.cimporte.DefaultCellStyle = DataGridViewCellStyle1
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(123, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Conceptos:"
        '
        'dglistadoc
        '
        Me.dglistadoc.AllowUserToAddRows = False
        Me.dglistadoc.AllowUserToDeleteRows = False
        Me.dglistadoc.AllowUserToResizeRows = False
        Me.dglistadoc.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dglistadoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dglistadoc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.dgidsu, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.dglistadoc.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dglistadoc.Location = New System.Drawing.Point(9, 336)
        Me.dglistadoc.MultiSelect = False
        Me.dglistadoc.Name = "dglistadoc"
        Me.dglistadoc.RowHeadersVisible = False
        Me.dglistadoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dglistadoc.Size = New System.Drawing.Size(441, 100)
        Me.dglistadoc.TabIndex = 20
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ciddocum01"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'dgidsu
        '
        Me.dgidsu.HeaderText = "idsubmen"
        Me.dgidsu.Name = "dgidsu"
        Me.dgidsu.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nombre Concepto"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Fecha"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 65
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Serie"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 40
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Folio"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 50
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Razon Social"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTextBoxColumn7.HeaderText = "Importe"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Registros:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 320)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(161, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Lista de documentos agregados:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(169, 307)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(179, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Doble Click para agregar a la Lista V"
        '
        'btnAsociar
        '
        Me.btnAsociar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnAsociar.Location = New System.Drawing.Point(460, 336)
        Me.btnAsociar.Name = "btnAsociar"
        Me.btnAsociar.Size = New System.Drawing.Size(82, 35)
        Me.btnAsociar.TabIndex = 24
        Me.btnAsociar.Text = "Asociar"
        Me.btnAsociar.UseVisualStyleBackColor = False
        '
        'btnsalir
        '
        Me.btnsalir.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnsalir.Location = New System.Drawing.Point(460, 387)
        Me.btnsalir.Name = "btnsalir"
        Me.btnsalir.Size = New System.Drawing.Size(82, 34)
        Me.btnsalir.TabIndex = 33
        Me.btnsalir.Text = "Salir"
        Me.btnsalir.UseVisualStyleBackColor = False
        '
        'txtbusca
        '
        Me.txtbusca.Location = New System.Drawing.Point(121, 49)
        Me.txtbusca.Name = "txtbusca"
        Me.txtbusca.Size = New System.Drawing.Size(256, 20)
        Me.txtbusca.TabIndex = 34
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(72, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Buscar:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(280, 439)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(170, 13)
        Me.Label7.TabIndex = 36
        Me.Label7.Text = "Doble Click para eliminar de la lista"
        '
        'btnAnterior
        '
        Me.btnAnterior.Location = New System.Drawing.Point(430, 46)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(41, 23)
        Me.btnAnterior.TabIndex = 38
        Me.btnAnterior.Text = "Ant."
        Me.btnAnterior.UseVisualStyleBackColor = True
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(383, 45)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(41, 24)
        Me.btnSiguiente.TabIndex = 37
        Me.btnSiguiente.Text = "Sig."
        Me.btnSiguiente.UseVisualStyleBackColor = True
        '
        'frmAddDoc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 457)
        Me.Controls.Add(Me.btnAnterior)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtbusca)
        Me.Controls.Add(Me.btnsalir)
        Me.Controls.Add(Me.btnAsociar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dglistadoc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgDocAdw)
        Me.Controls.Add(Me.cbConcepAdw)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtFecha)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddDoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Otros Documentos"
        CType(Me.dgDocAdw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dglistadoc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtFecha As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents cbConcepAdw As ComboBox
    Friend WithEvents dgDocAdw As DataGridView
    Friend WithEvents adwciddocum As DataGridViewTextBoxColumn
    Friend WithEvents digadw As DataGridViewTextBoxColumn
    Friend WithEvents cfech As DataGridViewTextBoxColumn
    Friend WithEvents cserie As DataGridViewTextBoxColumn
    Friend WithEvents cfolio As DataGridViewTextBoxColumn
    Friend WithEvents razonso01 As DataGridViewTextBoxColumn
    Friend WithEvents cimporte As DataGridViewTextBoxColumn
    Friend WithEvents crefe As DataGridViewTextBoxColumn
    Friend WithEvents cmoneda As DataGridViewTextBoxColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents dglistadoc As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnAsociar As Button
    Friend WithEvents btnsalir As Button
    Friend WithEvents txtbusca As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents dgidsu As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents btnAnterior As Button
    Friend WithEvents btnSiguiente As Button
End Class
