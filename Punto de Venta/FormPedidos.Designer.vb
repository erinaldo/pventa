<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPedidos
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
        Me.GrillaPedidosPendientes = New System.Windows.Forms.DataGridView()
        Me.nrocomp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.formapago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.importe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        CType(Me.GrillaPedidosPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrillaPedidosPendientes
        '
        Me.GrillaPedidosPendientes.AllowUserToAddRows = False
        Me.GrillaPedidosPendientes.AllowUserToDeleteRows = False
        Me.GrillaPedidosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaPedidosPendientes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nrocomp, Me.formapago, Me.importe})
        Me.GrillaPedidosPendientes.Location = New System.Drawing.Point(12, 78)
        Me.GrillaPedidosPendientes.Name = "GrillaPedidosPendientes"
        Me.GrillaPedidosPendientes.ReadOnly = True
        Me.GrillaPedidosPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaPedidosPendientes.Size = New System.Drawing.Size(461, 349)
        Me.GrillaPedidosPendientes.TabIndex = 5
        '
        'nrocomp
        '
        Me.nrocomp.HeaderText = "NroComprobante"
        Me.nrocomp.Name = "nrocomp"
        Me.nrocomp.ReadOnly = True
        Me.nrocomp.Width = 90
        '
        'formapago
        '
        Me.formapago.HeaderText = "Forma de Pago"
        Me.formapago.Name = "formapago"
        Me.formapago.ReadOnly = True
        Me.formapago.Width = 200
        '
        'importe
        '
        Me.importe.HeaderText = "Importe"
        Me.importe.Name = "importe"
        Me.importe.ReadOnly = True
        Me.importe.Width = 110
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(368, 444)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Imprimir"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(287, 444)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Cerrar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FormPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 479)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GrillaPedidosPendientes)
        Me.Name = "FormPedidos"
        Me.Text = "Pedidos Pendientes"
        CType(Me.GrillaPedidosPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrillaPedidosPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents nrocomp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents formapago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents importe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
