﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEmiteFac
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GrillaArticulos = New System.Windows.Forms.DataGridView()
        Me.lblCantidad = New System.Windows.Forms.Label()
        Me.TextPCompra = New System.Windows.Forms.TextBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextCodigo = New System.Windows.Forms.TextBox()
        Me.cmbcliente = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblLista = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtFechaEmi = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextCodBar = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.CodigoArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DescripcionArticulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codbar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pcompra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.GrillaArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrillaArticulos
        '
        Me.GrillaArticulos.AllowUserToAddRows = False
        Me.GrillaArticulos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaArticulos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrillaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaArticulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodigoArticulo, Me.DescripcionArticulo, Me.PrecioUnitario, Me.Cantidad, Me.Total, Me.Codbar, Me.pcompra})
        Me.GrillaArticulos.Location = New System.Drawing.Point(12, 163)
        Me.GrillaArticulos.Name = "GrillaArticulos"
        Me.GrillaArticulos.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrillaArticulos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.GrillaArticulos.RowTemplate.Height = 100
        Me.GrillaArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaArticulos.Size = New System.Drawing.Size(760, 282)
        Me.GrillaArticulos.StandardTab = True
        Me.GrillaArticulos.TabIndex = 3
        '
        'lblCantidad
        '
        Me.lblCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidad.ForeColor = System.Drawing.Color.Red
        Me.lblCantidad.Location = New System.Drawing.Point(653, 489)
        Me.lblCantidad.Name = "lblCantidad"
        Me.lblCantidad.Size = New System.Drawing.Size(94, 37)
        Me.lblCantidad.TabIndex = 110
        Me.lblCantidad.Text = "Total"
        Me.lblCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextPCompra
        '
        Me.TextPCompra.Location = New System.Drawing.Point(478, 22)
        Me.TextPCompra.Name = "TextPCompra"
        Me.TextPCompra.Size = New System.Drawing.Size(76, 22)
        Me.TextPCompra.TabIndex = 108
        Me.TextPCompra.TabStop = False
        Me.TextPCompra.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Red
        Me.lblTotal.Location = New System.Drawing.Point(475, 489)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(133, 37)
        Me.lblTotal.TabIndex = 107
        Me.lblTotal.Text = "Total"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(518, 458)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 17)
        Me.Label7.TabIndex = 106
        Me.Label7.Text = "Total"
        '
        'TextCodigo
        '
        Me.TextCodigo.Location = New System.Drawing.Point(579, 22)
        Me.TextCodigo.Name = "TextCodigo"
        Me.TextCodigo.Size = New System.Drawing.Size(76, 22)
        Me.TextCodigo.TabIndex = 105
        Me.TextCodigo.TabStop = False
        Me.TextCodigo.Visible = False
        '
        'cmbcliente
        '
        Me.cmbcliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbcliente.FormattingEnabled = True
        Me.cmbcliente.Location = New System.Drawing.Point(463, 18)
        Me.cmbcliente.Name = "cmbcliente"
        Me.cmbcliente.Size = New System.Drawing.Size(285, 23)
        Me.cmbcliente.TabIndex = 100
        Me.cmbcliente.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblLista)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbcliente)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DtFechaEmi)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 82)
        Me.GroupBox1.TabIndex = 112
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales"
        '
        'lblLista
        '
        Me.lblLista.AutoSize = True
        Me.lblLista.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLista.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLista.Location = New System.Drawing.Point(460, 51)
        Me.lblLista.Name = "lblLista"
        Me.lblLista.Size = New System.Drawing.Size(0, 16)
        Me.lblLista.TabIndex = 7
        Me.lblLista.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(357, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Lista de Precios:"
        Me.Label6.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(407, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cliente:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(134, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "TICKET"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(113, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo Comprobante:"
        '
        'DtFechaEmi
        '
        Me.DtFechaEmi.Enabled = False
        Me.DtFechaEmi.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtFechaEmi.Location = New System.Drawing.Point(65, 21)
        Me.DtFechaEmi.Name = "DtFechaEmi"
        Me.DtFechaEmi.Size = New System.Drawing.Size(129, 21)
        Me.DtFechaEmi.TabIndex = 101
        Me.DtFechaEmi.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'TextCodBar
        '
        Me.TextCodBar.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodBar.Location = New System.Drawing.Point(175, 20)
        Me.TextCodBar.Name = "TextCodBar"
        Me.TextCodBar.Size = New System.Drawing.Size(183, 26)
        Me.TextCodBar.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(34, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(135, 18)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Código de barras:"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(627, 448)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(145, 34)
        Me.Label13.TabIndex = 109
        Me.Label13.Text = "Cantidad de articulos facturados"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TextPCompra)
        Me.GroupBox2.Controls.Add(Me.TextCodigo)
        Me.GroupBox2.Controls.Add(Me.TextCodBar)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 100)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(760, 57)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'Button1
        '
        Me.Button1.Image = Global.PuntoVenta.My.Resources.Resources.viewmag_icono_4318_16
        Me.Button1.Location = New System.Drawing.Point(373, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(36, 26)
        Me.Button1.TabIndex = 2
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Image = Global.PuntoVenta.My.Resources.Resources.boton_de_cancelacion_de_icono_6056_32
        Me.cmdCancelar.Location = New System.Drawing.Point(256, 468)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(95, 46)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = Global.PuntoVenta.My.Resources.Resources.si_puede_aceptar_icono_7881_32
        Me.cmdAceptar.Location = New System.Drawing.Point(357, 468)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(95, 46)
        Me.cmdAceptar.TabIndex = 4
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Image = Global.PuntoVenta.My.Resources.Resources.emptytrash_icono_9439_32
        Me.cmdEliminar.Location = New System.Drawing.Point(30, 468)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(95, 46)
        Me.cmdEliminar.TabIndex = 6
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'CodigoArticulo
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CodigoArticulo.DefaultCellStyle = DataGridViewCellStyle2
        Me.CodigoArticulo.HeaderText = "Código"
        Me.CodigoArticulo.Name = "CodigoArticulo"
        Me.CodigoArticulo.ReadOnly = True
        Me.CodigoArticulo.Width = 75
        '
        'DescripcionArticulo
        '
        Me.DescripcionArticulo.HeaderText = "Descripción"
        Me.DescripcionArticulo.Name = "DescripcionArticulo"
        Me.DescripcionArticulo.ReadOnly = True
        Me.DescripcionArticulo.Width = 330
        '
        'PrecioUnitario
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.PrecioUnitario.DefaultCellStyle = DataGridViewCellStyle3
        Me.PrecioUnitario.HeaderText = "P.Unitario"
        Me.PrecioUnitario.Name = "PrecioUnitario"
        Me.PrecioUnitario.ReadOnly = True
        Me.PrecioUnitario.Width = 105
        '
        'Cantidad
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cantidad.HeaderText = "Cantidad"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.ReadOnly = True
        Me.Cantidad.Width = 85
        '
        'Total
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total.DefaultCellStyle = DataGridViewCellStyle5
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Width = 105
        '
        'Codbar
        '
        Me.Codbar.HeaderText = "Codbar"
        Me.Codbar.Name = "Codbar"
        Me.Codbar.ReadOnly = True
        Me.Codbar.Visible = False
        '
        'pcompra
        '
        Me.pcompra.HeaderText = "pcompra"
        Me.pcompra.Name = "pcompra"
        Me.pcompra.ReadOnly = True
        Me.pcompra.Visible = False
        '
        'FormEmiteFac
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 532)
        Me.Controls.Add(Me.GrillaArticulos)
        Me.Controls.Add(Me.lblCantidad)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.GroupBox2)
        Me.KeyPreview = True
        Me.Name = "FormEmiteFac"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Punto de Venta"
        CType(Me.GrillaArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrillaArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblCantidad As System.Windows.Forms.Label
    Friend WithEvents TextPCompra As System.Windows.Forms.TextBox
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextCodigo As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdEliminar As System.Windows.Forms.Button
    Friend WithEvents cmbcliente As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblLista As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DtFechaEmi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextCodBar As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CodigoArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescripcionArticulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrecioUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codbar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pcompra As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
