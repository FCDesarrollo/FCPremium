<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmGeneraDoctos
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
        Me.ckTodos = New System.Windows.Forms.CheckBox()
        Me.btGenera = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgServicios = New System.Windows.Forms.DataGridView()
        Me.LCargando = New System.Windows.Forms.Label()
        Me.pr = New System.Windows.Forms.ProgressBar()
        Me.seleccion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.idservicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.servicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pendiente = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ejercicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idfcmodulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgServicios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ckTodos
        '
        Me.ckTodos.AutoSize = True
        Me.ckTodos.Location = New System.Drawing.Point(12, 25)
        Me.ckTodos.Name = "ckTodos"
        Me.ckTodos.Size = New System.Drawing.Size(187, 17)
        Me.ckTodos.TabIndex = 1
        Me.ckTodos.Text = "Seleccione los servicios a generar"
        Me.ckTodos.UseVisualStyleBackColor = True
        '
        'btGenera
        '
        Me.btGenera.Location = New System.Drawing.Point(340, 169)
        Me.btGenera.Name = "btGenera"
        Me.btGenera.Size = New System.Drawing.Size(75, 23)
        Me.btGenera.TabIndex = 2
        Me.btGenera.Text = "Generar"
        Me.btGenera.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(421, 169)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Cerrar"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'dgServicios
        '
        Me.dgServicios.AllowUserToAddRows = False
        Me.dgServicios.AllowUserToDeleteRows = False
        Me.dgServicios.AllowUserToResizeRows = False
        Me.dgServicios.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgServicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgServicios.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seleccion, Me.idservicio, Me.codser, Me.servicio, Me.pendiente, Me.ejercicio, Me.idfcmodulo})
        Me.dgServicios.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgServicios.Location = New System.Drawing.Point(12, 48)
        Me.dgServicios.MultiSelect = False
        Me.dgServicios.Name = "dgServicios"
        Me.dgServicios.RowHeadersVisible = False
        Me.dgServicios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgServicios.Size = New System.Drawing.Size(484, 115)
        Me.dgServicios.TabIndex = 74
        '
        'LCargando
        '
        Me.LCargando.AutoSize = True
        Me.LCargando.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LCargando.Location = New System.Drawing.Point(333, 9)
        Me.LCargando.Name = "LCargando"
        Me.LCargando.Size = New System.Drawing.Size(69, 13)
        Me.LCargando.TabIndex = 76
        Me.LCargando.Text = "Cargando.."
        Me.LCargando.Visible = False
        '
        'pr
        '
        Me.pr.Location = New System.Drawing.Point(336, 25)
        Me.pr.Name = "pr"
        Me.pr.Size = New System.Drawing.Size(160, 17)
        Me.pr.Step = 20
        Me.pr.TabIndex = 75
        Me.pr.Visible = False
        '
        'seleccion
        '
        Me.seleccion.HeaderText = ""
        Me.seleccion.Name = "seleccion"
        Me.seleccion.Width = 30
        '
        'idservicio
        '
        Me.idservicio.HeaderText = "idservicio"
        Me.idservicio.Name = "idservicio"
        Me.idservicio.Visible = False
        '
        'codser
        '
        Me.codser.HeaderText = "codigo servicio"
        Me.codser.Name = "codser"
        Me.codser.Visible = False
        '
        'servicio
        '
        Me.servicio.HeaderText = "Servicio"
        Me.servicio.Name = "servicio"
        Me.servicio.Width = 350
        '
        'pendiente
        '
        Me.pendiente.HeaderText = "Pendientes"
        Me.pendiente.Name = "pendiente"
        '
        'ejercicio
        '
        Me.ejercicio.HeaderText = "Ejercicio"
        Me.ejercicio.Name = "ejercicio"
        Me.ejercicio.Visible = False
        '
        'idfcmodulo
        '
        Me.idfcmodulo.HeaderText = "idfcmodulo"
        Me.idfcmodulo.Name = "idfcmodulo"
        Me.idfcmodulo.Visible = False
        '
        'frmGeneraDoctos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 204)
        Me.Controls.Add(Me.LCargando)
        Me.Controls.Add(Me.pr)
        Me.Controls.Add(Me.dgServicios)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btGenera)
        Me.Controls.Add(Me.ckTodos)
        Me.Name = "frmGeneraDoctos"
        Me.Text = "Generacion de documentos"
        CType(Me.dgServicios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ckTodos As CheckBox
    Friend WithEvents btGenera As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents dgServicios As DataGridView
    Friend WithEvents LCargando As Label
    Friend WithEvents pr As ProgressBar
    Friend WithEvents seleccion As DataGridViewCheckBoxColumn
    Friend WithEvents idservicio As DataGridViewTextBoxColumn
    Friend WithEvents codser As DataGridViewTextBoxColumn
    Friend WithEvents servicio As DataGridViewTextBoxColumn
    Friend WithEvents pendiente As DataGridViewTextBoxColumn
    Friend WithEvents ejercicio As DataGridViewTextBoxColumn
    Friend WithEvents idfcmodulo As DataGridViewTextBoxColumn
End Class
