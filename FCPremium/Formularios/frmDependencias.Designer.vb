<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDependencias
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
        Me.TPEmpresas = New System.Windows.Forms.TabPage()
        Me.btnElimina = New System.Windows.Forms.Button()
        Me.btnAgrega = New System.Windows.Forms.Button()
        Me.BTNuevo = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBDependencia = New System.Windows.Forms.TextBox()
        Me.BTSalir = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgDependencias = New System.Windows.Forms.DataGridView()
        Me.iddependencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dependencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CBEmpresas = New System.Windows.Forms.ComboBox()
        Me.TPGenerales = New System.Windows.Forms.TabPage()
        Me.btEliminag = New System.Windows.Forms.Button()
        Me.dgDependenciasg = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbDependenciag = New System.Windows.Forms.TextBox()
        Me.btnEliminag = New System.Windows.Forms.Button()
        Me.btnAgregag = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.btnSalirg = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TPServicios.SuspendLayout()
        Me.TPEmpresas.SuspendLayout()
        CType(Me.dgDependencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPGenerales.SuspendLayout()
        CType(Me.dgDependenciasg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TPServicios
        '
        Me.TPServicios.Controls.Add(Me.TPEmpresas)
        Me.TPServicios.Controls.Add(Me.TPGenerales)
        Me.TPServicios.Location = New System.Drawing.Point(12, 12)
        Me.TPServicios.Name = "TPServicios"
        Me.TPServicios.SelectedIndex = 0
        Me.TPServicios.Size = New System.Drawing.Size(321, 322)
        Me.TPServicios.TabIndex = 1
        '
        'TPEmpresas
        '
        Me.TPEmpresas.Controls.Add(Me.btnElimina)
        Me.TPEmpresas.Controls.Add(Me.btnAgrega)
        Me.TPEmpresas.Controls.Add(Me.BTNuevo)
        Me.TPEmpresas.Controls.Add(Me.Label4)
        Me.TPEmpresas.Controls.Add(Me.TBDependencia)
        Me.TPEmpresas.Controls.Add(Me.BTSalir)
        Me.TPEmpresas.Controls.Add(Me.Label1)
        Me.TPEmpresas.Controls.Add(Me.dgDependencias)
        Me.TPEmpresas.Controls.Add(Me.CBEmpresas)
        Me.TPEmpresas.Location = New System.Drawing.Point(4, 22)
        Me.TPEmpresas.Name = "TPEmpresas"
        Me.TPEmpresas.Padding = New System.Windows.Forms.Padding(3)
        Me.TPEmpresas.Size = New System.Drawing.Size(313, 296)
        Me.TPEmpresas.TabIndex = 0
        Me.TPEmpresas.Text = "Por Empresa"
        Me.TPEmpresas.UseVisualStyleBackColor = True
        '
        'btnElimina
        '
        Me.btnElimina.Location = New System.Drawing.Point(182, 6)
        Me.btnElimina.Name = "btnElimina"
        Me.btnElimina.Size = New System.Drawing.Size(63, 21)
        Me.btnElimina.TabIndex = 39
        Me.btnElimina.Text = "Eliminar"
        Me.btnElimina.UseVisualStyleBackColor = True
        '
        'btnAgrega
        '
        Me.btnAgrega.Location = New System.Drawing.Point(65, 6)
        Me.btnAgrega.Name = "btnAgrega"
        Me.btnAgrega.Size = New System.Drawing.Size(111, 21)
        Me.btnAgrega.TabIndex = 38
        Me.btnAgrega.Text = "Agregar/Modificar"
        Me.btnAgrega.UseVisualStyleBackColor = True
        '
        'BTNuevo
        '
        Me.BTNuevo.Location = New System.Drawing.Point(6, 6)
        Me.BTNuevo.Name = "BTNuevo"
        Me.BTNuevo.Size = New System.Drawing.Size(53, 21)
        Me.BTNuevo.TabIndex = 37
        Me.BTNuevo.Text = "Nuevo"
        Me.BTNuevo.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Dependencia:"
        '
        'TBDependencia
        '
        Me.TBDependencia.Location = New System.Drawing.Point(9, 86)
        Me.TBDependencia.Name = "TBDependencia"
        Me.TBDependencia.Size = New System.Drawing.Size(298, 20)
        Me.TBDependencia.TabIndex = 35
        '
        'BTSalir
        '
        Me.BTSalir.Location = New System.Drawing.Point(251, 6)
        Me.BTSalir.Name = "BTSalir"
        Me.BTSalir.Size = New System.Drawing.Size(56, 21)
        Me.BTSalir.TabIndex = 27
        Me.BTSalir.Text = "Salir"
        Me.BTSalir.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Empresas CRM:"
        '
        'dgDependencias
        '
        Me.dgDependencias.AllowUserToAddRows = False
        Me.dgDependencias.AllowUserToDeleteRows = False
        Me.dgDependencias.AllowUserToResizeColumns = False
        Me.dgDependencias.AllowUserToResizeRows = False
        Me.dgDependencias.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDependencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDependencias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.iddependencia, Me.Dependencia})
        Me.dgDependencias.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDependencias.Location = New System.Drawing.Point(9, 112)
        Me.dgDependencias.MultiSelect = False
        Me.dgDependencias.Name = "dgDependencias"
        Me.dgDependencias.ReadOnly = True
        Me.dgDependencias.RowHeadersVisible = False
        Me.dgDependencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDependencias.Size = New System.Drawing.Size(298, 178)
        Me.dgDependencias.TabIndex = 19
        '
        'iddependencia
        '
        Me.iddependencia.HeaderText = "iddependencia"
        Me.iddependencia.Name = "iddependencia"
        Me.iddependencia.ReadOnly = True
        Me.iddependencia.Visible = False
        '
        'Dependencia
        '
        Me.Dependencia.HeaderText = "Dependencia"
        Me.Dependencia.Name = "Dependencia"
        Me.Dependencia.ReadOnly = True
        Me.Dependencia.Width = 290
        '
        'CBEmpresas
        '
        Me.CBEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBEmpresas.FormattingEnabled = True
        Me.CBEmpresas.Location = New System.Drawing.Point(9, 46)
        Me.CBEmpresas.Name = "CBEmpresas"
        Me.CBEmpresas.Size = New System.Drawing.Size(298, 21)
        Me.CBEmpresas.TabIndex = 2
        '
        'TPGenerales
        '
        Me.TPGenerales.Controls.Add(Me.btnEliminag)
        Me.TPGenerales.Controls.Add(Me.btnAgregag)
        Me.TPGenerales.Controls.Add(Me.btnNuevo)
        Me.TPGenerales.Controls.Add(Me.btnSalirg)
        Me.TPGenerales.Controls.Add(Me.Label2)
        Me.TPGenerales.Controls.Add(Me.tbDependenciag)
        Me.TPGenerales.Controls.Add(Me.btEliminag)
        Me.TPGenerales.Controls.Add(Me.dgDependenciasg)
        Me.TPGenerales.Location = New System.Drawing.Point(4, 22)
        Me.TPGenerales.Name = "TPGenerales"
        Me.TPGenerales.Padding = New System.Windows.Forms.Padding(3)
        Me.TPGenerales.Size = New System.Drawing.Size(313, 296)
        Me.TPGenerales.TabIndex = 1
        Me.TPGenerales.Text = "Generales"
        Me.TPGenerales.UseVisualStyleBackColor = True
        '
        'btEliminag
        '
        Me.btEliminag.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btEliminag.Location = New System.Drawing.Point(312, 6)
        Me.btEliminag.Name = "btEliminag"
        Me.btEliminag.Size = New System.Drawing.Size(27, 21)
        Me.btEliminag.TabIndex = 39
        Me.btEliminag.Text = "-"
        Me.btEliminag.UseVisualStyleBackColor = False
        '
        'dgDependenciasg
        '
        Me.dgDependenciasg.AllowUserToAddRows = False
        Me.dgDependenciasg.AllowUserToDeleteRows = False
        Me.dgDependenciasg.AllowUserToResizeColumns = False
        Me.dgDependenciasg.AllowUserToResizeRows = False
        Me.dgDependenciasg.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDependenciasg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgDependenciasg.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.dgDependenciasg.GridColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgDependenciasg.Location = New System.Drawing.Point(7, 78)
        Me.dgDependenciasg.MultiSelect = False
        Me.dgDependenciasg.Name = "dgDependenciasg"
        Me.dgDependenciasg.ReadOnly = True
        Me.dgDependenciasg.RowHeadersVisible = False
        Me.dgDependenciasg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDependenciasg.Size = New System.Drawing.Size(300, 212)
        Me.dgDependenciasg.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(4, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Dependencia:"
        '
        'tbDependenciag
        '
        Me.tbDependenciag.Location = New System.Drawing.Point(7, 52)
        Me.tbDependenciag.Name = "tbDependenciag"
        Me.tbDependenciag.Size = New System.Drawing.Size(298, 20)
        Me.tbDependenciag.TabIndex = 40
        '
        'btnEliminag
        '
        Me.btnEliminag.Location = New System.Drawing.Point(182, 6)
        Me.btnEliminag.Name = "btnEliminag"
        Me.btnEliminag.Size = New System.Drawing.Size(63, 21)
        Me.btnEliminag.TabIndex = 45
        Me.btnEliminag.Text = "Eliminar"
        Me.btnEliminag.UseVisualStyleBackColor = True
        '
        'btnAgregag
        '
        Me.btnAgregag.Location = New System.Drawing.Point(65, 6)
        Me.btnAgregag.Name = "btnAgregag"
        Me.btnAgregag.Size = New System.Drawing.Size(111, 21)
        Me.btnAgregag.TabIndex = 44
        Me.btnAgregag.Text = "Agregar/Modificar"
        Me.btnAgregag.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Location = New System.Drawing.Point(6, 6)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(53, 21)
        Me.btnNuevo.TabIndex = 43
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'btnSalirg
        '
        Me.btnSalirg.Location = New System.Drawing.Point(251, 6)
        Me.btnSalirg.Name = "btnSalirg"
        Me.btnSalirg.Size = New System.Drawing.Size(56, 21)
        Me.btnSalirg.TabIndex = 42
        Me.btnSalirg.Text = "Salir"
        Me.btnSalirg.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "iddependencia"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Dependencia"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 290
        '
        'frmDependencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(345, 346)
        Me.Controls.Add(Me.TPServicios)
        Me.Name = "frmDependencias"
        Me.Text = "Configuracion de Dependencias"
        Me.TPServicios.ResumeLayout(False)
        Me.TPEmpresas.ResumeLayout(False)
        Me.TPEmpresas.PerformLayout()
        CType(Me.dgDependencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPGenerales.ResumeLayout(False)
        Me.TPGenerales.PerformLayout()
        CType(Me.dgDependenciasg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TPServicios As TabControl
    Friend WithEvents TPEmpresas As TabPage
    Friend WithEvents BTSalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dgDependencias As DataGridView
    Friend WithEvents CBEmpresas As ComboBox
    Friend WithEvents TPGenerales As TabPage
    Friend WithEvents btEliminag As Button
    Friend WithEvents dgDependenciasg As DataGridView
    Friend WithEvents Label4 As Label
    Friend WithEvents TBDependencia As TextBox
    Friend WithEvents btnElimina As Button
    Friend WithEvents btnAgrega As Button
    Friend WithEvents BTNuevo As Button
    Friend WithEvents iddependencia As DataGridViewTextBoxColumn
    Friend WithEvents Dependencia As DataGridViewTextBoxColumn
    Friend WithEvents btnEliminag As Button
    Friend WithEvents btnAgregag As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents btnSalirg As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents tbDependenciag As TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
End Class
