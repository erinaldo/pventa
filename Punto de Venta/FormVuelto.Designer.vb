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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTot = New System.Windows.Forms.Label()
        Me.cmbFormas = New System.Windows.Forms.ComboBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textdto = New System.Windows.Forms.TextBox()
        Me.txttotaldto = New System.Windows.Forms.TextBox()
        Me.txtAbona = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblVuelto = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(252, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "%"
        '
        'lblTot
        '
        Me.lblTot.AutoSize = True
        Me.lblTot.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTot.ForeColor = System.Drawing.Color.Red
        Me.lblTot.Location = New System.Drawing.Point(139, 81)
        Me.lblTot.Name = "lblTot"
        Me.lblTot.Size = New System.Drawing.Size(120, 37)
        Me.lblTot.TabIndex = 18
        Me.lblTot.Text = "Label5"
        '
        'cmbFormas
        '
        Me.cmbFormas.FormattingEnabled = True
        Me.cmbFormas.Location = New System.Drawing.Point(146, 39)
        Me.cmbFormas.Name = "cmbFormas"
        Me.cmbFormas.Size = New System.Drawing.Size(169, 21)
        Me.cmbFormas.TabIndex = 17
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.PuntoVenta.My.Resources.Resources.boton_de_cancelacion_de_icono_6056_32
        Me.btnCancelar.Location = New System.Drawing.Point(53, 335)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(95, 46)
        Me.btnCancelar.TabIndex = 16
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.PuntoVenta.My.Resources.Resources.si_puede_aceptar_icono_7881_32
        Me.btnAceptar.Location = New System.Drawing.Point(190, 335)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(95, 46)
        Me.btnAceptar.TabIndex = 15
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Total con descuento:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(70, 138)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Descuento:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(98, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Total:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Forma de Pago:"
        '
        'textdto
        '
        Me.textdto.Location = New System.Drawing.Point(146, 135)
        Me.textdto.Name = "textdto"
        Me.textdto.Size = New System.Drawing.Size(100, 20)
        Me.textdto.TabIndex = 20
        '
        'txttotaldto
        '
        Me.txttotaldto.Location = New System.Drawing.Point(146, 186)
        Me.txttotaldto.Name = "txttotaldto"
        Me.txttotaldto.Size = New System.Drawing.Size(100, 20)
        Me.txttotaldto.TabIndex = 21
        '
        'txtAbona
        '
        Me.txtAbona.Location = New System.Drawing.Point(146, 232)
        Me.txtAbona.Name = "txtAbona"
        Me.txtAbona.Size = New System.Drawing.Size(100, 20)
        Me.txtAbona.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(70, 235)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Abona con:"
        '
        'lblVuelto
        '
        Me.lblVuelto.AutoSize = True
        Me.lblVuelto.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVuelto.ForeColor = System.Drawing.Color.Red
        Me.lblVuelto.Location = New System.Drawing.Point(139, 270)
        Me.lblVuelto.Name = "lblVuelto"
        Me.lblVuelto.Size = New System.Drawing.Size(120, 37)
        Me.lblVuelto.TabIndex = 25
        Me.lblVuelto.Text = "Label5"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(92, 289)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Vuelto:"
        '
        'FormVuelto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 393)
        Me.Controls.Add(Me.lblVuelto)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAbona)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txttotaldto)
        Me.Controls.Add(Me.textdto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblTot)
        Me.Controls.Add(Me.cmbFormas)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormVuelto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vuelto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblTot As System.Windows.Forms.Label
    Friend WithEvents cmbFormas As System.Windows.Forms.ComboBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents textdto As System.Windows.Forms.TextBox
    Friend WithEvents txttotaldto As System.Windows.Forms.TextBox
    Friend WithEvents txtAbona As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblVuelto As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
