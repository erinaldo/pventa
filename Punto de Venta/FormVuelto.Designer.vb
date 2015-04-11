<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVuelto
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
        Me.lblTot = New System.Windows.Forms.Label()
        Me.cmbFormas = New System.Windows.Forms.ComboBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAbona = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblVuelto = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout
        Me.SuspendLayout
        '
        'lblTot
        '
        Me.lblTot.AutoSize = true
        Me.lblTot.Font = New System.Drawing.Font("Arial", 26!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTot.ForeColor = System.Drawing.Color.Red
        Me.lblTot.Location = New System.Drawing.Point(204, 111)
        Me.lblTot.Name = "lblTot"
        Me.lblTot.Size = New System.Drawing.Size(126, 41)
        Me.lblTot.TabIndex = 18
        Me.lblTot.Text = "Label5"
        '
        'cmbFormas
        '
        Me.cmbFormas.Font = New System.Drawing.Font("Microsoft Sans Serif", 14!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbFormas.FormattingEnabled = true
        Me.cmbFormas.Location = New System.Drawing.Point(106, 34)
        Me.cmbFormas.Name = "cmbFormas"
        Me.cmbFormas.Size = New System.Drawing.Size(239, 32)
        Me.cmbFormas.TabIndex = 3
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.PuntoVenta.My.Resources.Resources.boton_de_cancelacion_de_icono_6056_32
        Me.btnCancelar.Location = New System.Drawing.Point(109, 283)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 46)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.PuntoVenta.My.Resources.Resources.si_puede_aceptar_icono_7881_32
        Me.btnAceptar.Location = New System.Drawing.Point(246, 283)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(95, 46)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Total:"
        '
        'txtAbona
        '
        Me.txtAbona.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbona.Location = New System.Drawing.Point(211, 167)
        Me.txtAbona.Name = "txtAbona"
        Me.txtAbona.Size = New System.Drawing.Size(119, 29)
        Me.txtAbona.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(83, 173)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 20)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Abona con:"
        '
        'lblVuelto
        '
        Me.lblVuelto.AutoSize = True
        Me.lblVuelto.Font = New System.Drawing.Font("Arial", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVuelto.ForeColor = System.Drawing.Color.Red
        Me.lblVuelto.Location = New System.Drawing.Point(204, 212)
        Me.lblVuelto.Name = "lblVuelto"
        Me.lblVuelto.Size = New System.Drawing.Size(126, 41)
        Me.lblVuelto.TabIndex = 25
        Me.lblVuelto.Text = "Label5"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(114, 225)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 20)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Vuelto:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbFormas)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(447, 94)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Forma de Pago"
        '
        'FormVuelto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 343)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblVuelto)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAbona)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblTot)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label2)
        Me.KeyPreview = True
        Me.Name = "FormVuelto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vuelto"
        Me.GroupBox1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents lblTot As System.Windows.Forms.Label
    Friend WithEvents cmbFormas As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAbona As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblVuelto As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
