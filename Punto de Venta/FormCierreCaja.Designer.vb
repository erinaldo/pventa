<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCierreCaja
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblApertura = New System.Windows.Forms.Label()
        Me.lblCierre = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblIngresoDinero = New System.Windows.Forms.Label()
        Me.lblRetiroDinero = New System.Windows.Forms.Label()
        Me.lblEfectivo = New System.Windows.Forms.Label()
        Me.lblTarjetas = New System.Windows.Forms.Label()
        Me.lblCheques = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblUsuario)
        Me.GroupBox1.Controls.Add(Me.lblCierre)
        Me.GroupBox1.Controls.Add(Me.lblApertura)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(520, 68)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Apertura Caja:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(264, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cierre Caja:"
        '
        'lblApertura
        '
        Me.lblApertura.AutoSize = True
        Me.lblApertura.Location = New System.Drawing.Point(86, 40)
        Me.lblApertura.Name = "lblApertura"
        Me.lblApertura.Size = New System.Drawing.Size(32, 13)
        Me.lblApertura.TabIndex = 2
        Me.lblApertura.Text = "xxxxx"
        '
        'lblCierre
        '
        Me.lblCierre.AutoSize = True
        Me.lblCierre.Location = New System.Drawing.Point(331, 40)
        Me.lblCierre.Name = "lblCierre"
        Me.lblCierre.Size = New System.Drawing.Size(32, 13)
        Me.lblCierre.TabIndex = 3
        Me.lblCierre.Text = "xxxxx"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(58, 16)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(32, 13)
        Me.lblUsuario.TabIndex = 4
        Me.lblUsuario.Text = "xxxxx"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblCheques)
        Me.GroupBox2.Controls.Add(Me.lblTarjetas)
        Me.GroupBox2.Controls.Add(Me.lblEfectivo)
        Me.GroupBox2.Controls.Add(Me.lblRetiroDinero)
        Me.GroupBox2.Controls.Add(Me.lblIngresoDinero)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 86)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(520, 275)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(430, 377)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(326, 377)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Salir"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Ingresos de Dinero:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Retiros de Dinero:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Efectivo:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(22, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Tarjetas:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Cheques:"
        '
        'lblIngresoDinero
        '
        Me.lblIngresoDinero.AutoSize = True
        Me.lblIngresoDinero.Location = New System.Drawing.Point(127, 35)
        Me.lblIngresoDinero.Name = "lblIngresoDinero"
        Me.lblIngresoDinero.Size = New System.Drawing.Size(32, 13)
        Me.lblIngresoDinero.TabIndex = 5
        Me.lblIngresoDinero.Text = "xxxxx"
        '
        'lblRetiroDinero
        '
        Me.lblRetiroDinero.AutoSize = True
        Me.lblRetiroDinero.Location = New System.Drawing.Point(127, 73)
        Me.lblRetiroDinero.Name = "lblRetiroDinero"
        Me.lblRetiroDinero.Size = New System.Drawing.Size(32, 13)
        Me.lblRetiroDinero.TabIndex = 6
        Me.lblRetiroDinero.Text = "xxxxx"
        '
        'lblEfectivo
        '
        Me.lblEfectivo.AutoSize = True
        Me.lblEfectivo.Location = New System.Drawing.Point(127, 112)
        Me.lblEfectivo.Name = "lblEfectivo"
        Me.lblEfectivo.Size = New System.Drawing.Size(32, 13)
        Me.lblEfectivo.TabIndex = 7
        Me.lblEfectivo.Text = "xxxxx"
        '
        'lblTarjetas
        '
        Me.lblTarjetas.AutoSize = True
        Me.lblTarjetas.Location = New System.Drawing.Point(127, 154)
        Me.lblTarjetas.Name = "lblTarjetas"
        Me.lblTarjetas.Size = New System.Drawing.Size(32, 13)
        Me.lblTarjetas.TabIndex = 8
        Me.lblTarjetas.Text = "xxxxx"
        '
        'lblCheques
        '
        Me.lblCheques.AutoSize = True
        Me.lblCheques.Location = New System.Drawing.Point(127, 196)
        Me.lblCheques.Name = "lblCheques"
        Me.lblCheques.Size = New System.Drawing.Size(32, 13)
        Me.lblCheques.TabIndex = 9
        Me.lblCheques.Text = "xxxxx"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(22, 238)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Total:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(127, 238)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "xxxxx"
        '
        'FormCierreCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(544, 413)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormCierreCaja"
        Me.Text = "Cierre de Caja"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblCierre As System.Windows.Forms.Label
    Friend WithEvents lblApertura As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblCheques As System.Windows.Forms.Label
    Friend WithEvents lblTarjetas As System.Windows.Forms.Label
    Friend WithEvents lblEfectivo As System.Windows.Forms.Label
    Friend WithEvents lblRetiroDinero As System.Windows.Forms.Label
    Friend WithEvents lblIngresoDinero As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
