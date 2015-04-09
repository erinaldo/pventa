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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblIdUsuario
        '
        Me.lblIdUsuario.AutoSize = True
        Me.lblIdUsuario.Location = New System.Drawing.Point(218, 16)
        Me.lblIdUsuario.Name = "lblIdUsuario"
        Me.lblIdUsuario.Size = New System.Drawing.Size(34, 13)
        Me.lblIdUsuario.TabIndex = 5
        Me.lblIdUsuario.Text = "idUsu"
        Me.lblIdUsuario.Visible = False
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
        'lblCierre
        '
        Me.lblCierre.AutoSize = True
        Me.lblCierre.Location = New System.Drawing.Point(339, 40)
        Me.lblCierre.Name = "lblCierre"
        Me.lblCierre.Size = New System.Drawing.Size(32, 13)
        Me.lblCierre.TabIndex = 3
        Me.lblCierre.Text = "xxxxx"
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(272, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cierre Caja:"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario:"
        '
        'dgvRendicion
        '
        Me.dgvRendicion.AllowUserToAddRows = False
        Me.dgvRendicion.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRendicion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRendicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRendicion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.descripcion, Me.totalFacturado, Me.rendicion, Me.diferencia, Me.cantComprobantes, Me.tpoOperacion})
        Me.dgvRendicion.Location = New System.Drawing.Point(12, 86)
        Me.dgvRendicion.Name = "dgvRendicion"
        Me.dgvRendicion.Size = New System.Drawing.Size(552, 303)
        Me.dgvRendicion.TabIndex = 8
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.totalFacturado.DefaultCellStyle = DataGridViewCellStyle2
        Me.totalFacturado.HeaderText = "Total"
        Me.totalFacturado.Name = "totalFacturado"
        Me.totalFacturado.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.totalFacturado.Width = 85
        '
        'rendicion
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.rendicion.DefaultCellStyle = DataGridViewCellStyle3
        Me.rendicion.HeaderText = "Rendicion"
        Me.rendicion.Name = "rendicion"
        Me.rendicion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.rendicion.Width = 85
        '
        'diferencia
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.diferencia.DefaultCellStyle = DataGridViewCellStyle4
        Me.diferencia.HeaderText = "Diferencia"
        Me.diferencia.Name = "diferencia"
        Me.diferencia.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.diferencia.Width = 85
        '
        'cantComprobantes
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.cantComprobantes.DefaultCellStyle = DataGridViewCellStyle5
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
        Me.lblDiferencia.TabIndex = 9
        Me.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(284, 410)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 24)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Diferencia:"
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(430, 450)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 46)
        Me.Button1.TabIndex = 7
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormCierreCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 506)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblDiferencia)
        Me.Controls.Add(Me.dgvRendicion)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "FormCierreCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre de Caja"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvRendicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
End Class
