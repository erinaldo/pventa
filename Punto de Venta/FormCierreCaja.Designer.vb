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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCierreCaja))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblIdUsuario = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblCierre = New System.Windows.Forms.Label()
        Me.lblApertura = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvRendicion = New System.Windows.Forms.DataGridView()
        Me.descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalFacturado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rendicion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.diferencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantComprobantes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpoOperacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblDiferencia = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblIngreso = New System.Windows.Forms.Label()
        Me.lblRetiro = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvRendicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblIdUsuario)
        Me.GroupBox1.Controls.Add(Me.lblUsuario)
        Me.GroupBox1.Controls.Add(Me.lblCierre)
        Me.GroupBox1.Controls.Add(Me.lblApertura)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 68)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'lblIdUsuario
        '
        Me.lblIdUsuario.AutoSize = True
        Me.lblIdUsuario.Location = New System.Drawing.Point(218, 16)
        Me.lblIdUsuario.Name = "lblIdUsuario"
        Me.lblIdUsuario.Size = New System.Drawing.Size(34, 13)
        Me.lblIdUsuario.TabIndex = 18
        Me.lblIdUsuario.Text = "idUsu"
        Me.lblIdUsuario.Visible = False
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(58, 16)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(32, 13)
        Me.lblUsuario.TabIndex = 17
        Me.lblUsuario.Text = "xxxxx"
        '
        'lblCierre
        '
        Me.lblCierre.AutoSize = True
        Me.lblCierre.Location = New System.Drawing.Point(339, 40)
        Me.lblCierre.Name = "lblCierre"
        Me.lblCierre.Size = New System.Drawing.Size(32, 13)
        Me.lblCierre.TabIndex = 22
        Me.lblCierre.Text = "xxxxx"
        '
        'lblApertura
        '
        Me.lblApertura.AutoSize = True
        Me.lblApertura.Location = New System.Drawing.Point(86, 40)
        Me.lblApertura.Name = "lblApertura"
        Me.lblApertura.Size = New System.Drawing.Size(32, 13)
        Me.lblApertura.TabIndex = 20
        Me.lblApertura.Text = "xxxxx"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(272, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Cierre Caja:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Apertura Caja:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Usuario:"
        '
        'dgvRendicion
        '
        Me.dgvRendicion.AllowUserToAddRows = False
        Me.dgvRendicion.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRendicion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRendicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRendicion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.descripcion, Me.totalFacturado, Me.rendicion, Me.diferencia, Me.cantComprobantes, Me.tpoOperacion})
        Me.dgvRendicion.Location = New System.Drawing.Point(12, 125)
        Me.dgvRendicion.Name = "dgvRendicion"
        Me.dgvRendicion.Size = New System.Drawing.Size(552, 264)
        Me.dgvRendicion.StandardTab = True
        Me.dgvRendicion.TabIndex = 0
        '
        'descripcion
        '
        Me.descripcion.HeaderText = "Descripcion"
        Me.descripcion.Name = "descripcion"
        Me.descripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.descripcion.Width = 145
        '
        'totalFacturado
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.totalFacturado.DefaultCellStyle = DataGridViewCellStyle7
        Me.totalFacturado.HeaderText = "Total"
        Me.totalFacturado.Name = "totalFacturado"
        Me.totalFacturado.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.totalFacturado.Width = 85
        '
        'rendicion
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.rendicion.DefaultCellStyle = DataGridViewCellStyle8
        Me.rendicion.HeaderText = "Rendicion"
        Me.rendicion.Name = "rendicion"
        Me.rendicion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.rendicion.Width = 85
        '
        'diferencia
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.diferencia.DefaultCellStyle = DataGridViewCellStyle9
        Me.diferencia.HeaderText = "Diferencia"
        Me.diferencia.Name = "diferencia"
        Me.diferencia.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.diferencia.Width = 85
        '
        'cantComprobantes
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cantComprobantes.DefaultCellStyle = DataGridViewCellStyle10
        Me.cantComprobantes.HeaderText = "Cant.Comprob."
        Me.cantComprobantes.Name = "cantComprobantes"
        Me.cantComprobantes.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cantComprobantes.Width = 90
        '
        'tpoOperacion
        '
        Me.tpoOperacion.HeaderText = "Tpo.Operacion"
        Me.tpoOperacion.Name = "tpoOperacion"
        Me.tpoOperacion.Visible = False
        '
        'lblDiferencia
        '
        Me.lblDiferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferencia.Location = New System.Drawing.Point(389, 398)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(164, 42)
        Me.lblDiferencia.TabIndex = 24
        Me.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(284, 410)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 24)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Diferencia:"
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(430, 450)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 46)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Image = Global.PuntoVenta.My.Resources.Resources.boton_de_cancelacion_de_icono_6056_32
        Me.cmdCancelar.Location = New System.Drawing.Point(318, 450)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(95, 46)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 17)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Ingreso de Dinero:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(284, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 17)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Retiro de Dinero:"
        '
        'lblIngreso
        '
        Me.lblIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIngreso.Location = New System.Drawing.Point(149, 94)
        Me.lblIngreso.Name = "lblIngreso"
        Me.lblIngreso.Size = New System.Drawing.Size(106, 17)
        Me.lblIngreso.TabIndex = 27
        Me.lblIngreso.Text = "Label7"
        '
        'lblRetiro
        '
        Me.lblRetiro.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetiro.Location = New System.Drawing.Point(401, 94)
        Me.lblRetiro.Name = "lblRetiro"
        Me.lblRetiro.Size = New System.Drawing.Size(124, 17)
        Me.lblRetiro.TabIndex = 28
        Me.lblRetiro.Text = "Label7"
        '
        'FormCierreCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 506)
        Me.ControlBox = false
        Me.Controls.Add(Me.lblRetiro)
        Me.Controls.Add(Me.lblIngreso)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblDiferencia)
        Me.Controls.Add(Me.dgvRendicion)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FormCierreCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre de Caja"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        CType(Me.dgvRendicion,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblCierre As System.Windows.Forms.Label
    Friend WithEvents lblApertura As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvRendicion As System.Windows.Forms.DataGridView
    Friend WithEvents lblDiferencia As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalFacturado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rendicion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents diferencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cantComprobantes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpoOperacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblIdUsuario As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblIngreso As System.Windows.Forms.Label
    Friend WithEvents lblRetiro As System.Windows.Forms.Label
End Class
