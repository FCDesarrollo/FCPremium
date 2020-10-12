<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConfigEmpresasEmp
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
        Me.cbCon = New System.Windows.Forms.ComboBox()
        Me.cbNom = New System.Windows.Forms.ComboBox()
        Me.cbADW = New System.Windows.Forms.ComboBox()
        Me.btGuardar = New System.Windows.Forms.Button()
        Me.btCerrar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cbCon
        '
        Me.cbCon.FormattingEnabled = True
        Me.cbCon.Location = New System.Drawing.Point(12, 25)
        Me.cbCon.Name = "cbCon"
        Me.cbCon.Size = New System.Drawing.Size(306, 21)
        Me.cbCon.TabIndex = 0
        '
        'cbNom
        '
        Me.cbNom.FormattingEnabled = True
        Me.cbNom.Location = New System.Drawing.Point(12, 65)
        Me.cbNom.Name = "cbNom"
        Me.cbNom.Size = New System.Drawing.Size(306, 21)
        Me.cbNom.TabIndex = 1
        '
        'cbADW
        '
        Me.cbADW.FormattingEnabled = True
        Me.cbADW.Location = New System.Drawing.Point(12, 108)
        Me.cbADW.Name = "cbADW"
        Me.cbADW.Size = New System.Drawing.Size(306, 21)
        Me.cbADW.TabIndex = 2
        '
        'btGuardar
        '
        Me.btGuardar.Location = New System.Drawing.Point(148, 137)
        Me.btGuardar.Name = "btGuardar"
        Me.btGuardar.Size = New System.Drawing.Size(89, 30)
        Me.btGuardar.TabIndex = 3
        Me.btGuardar.Text = "Guardar y salir"
        Me.btGuardar.UseVisualStyleBackColor = True
        '
        'btCerrar
        '
        Me.btCerrar.Location = New System.Drawing.Point(243, 137)
        Me.btCerrar.Name = "btCerrar"
        Me.btCerrar.Size = New System.Drawing.Size(75, 30)
        Me.btCerrar.TabIndex = 4
        Me.btCerrar.Text = "Cerrar"
        Me.btCerrar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(125, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "CONTPAQ i Contabilidad"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "CONTPAQ i Nominas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "AdminPAQ"
        '
        'frmConfigEmpresasEmp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(330, 179)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btCerrar)
        Me.Controls.Add(Me.btGuardar)
        Me.Controls.Add(Me.cbADW)
        Me.Controls.Add(Me.cbNom)
        Me.Controls.Add(Me.cbCon)
        Me.Name = "frmConfigEmpresasEmp"
        Me.Text = "Configuracion de Empresas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbCon As ComboBox
    Friend WithEvents cbNom As ComboBox
    Friend WithEvents cbADW As ComboBox
    Friend WithEvents btGuardar As Button
    Friend WithEvents btCerrar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
