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
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.GrillaComprobanteVentaDetalle = New System.Windows.Forms.DataGridView()
        CType(Me.GrillaPedidosPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GrillaComprobanteVentaDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrillaPedidosPendientes
        '
        Me.GrillaPedidosPendientes.AllowUserToAddRows = False
        Me.GrillaPedidosPendientes.AllowUserToDeleteRows = False
        Me.GrillaPedidosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaPedidosPendientes.Location = New System.Drawing.Point(12, 12)
        Me.GrillaPedidosPendientes.Name = "GrillaPedidosPendientes"
        Me.GrillaPedidosPendientes.ReadOnly = True
        Me.GrillaPedidosPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaPedidosPendientes.Size = New System.Drawing.Size(725, 199)
        Me.GrillaPedidosPendientes.TabIndex = 5
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(370, 457)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 6
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(289, 457)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 7
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'GrillaComprobanteVentaDetalle
        '
        Me.GrillaComprobanteVentaDetalle.AllowUserToAddRows = False
        Me.GrillaComprobanteVentaDetalle.AllowUserToDeleteRows = False
        Me.GrillaComprobanteVentaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaComprobanteVentaDetalle.Location = New System.Drawing.Point(12, 217)
        Me.GrillaComprobanteVentaDetalle.Name = "GrillaComprobanteVentaDetalle"
        Me.GrillaComprobanteVentaDetalle.ReadOnly = True
        Me.GrillaComprobanteVentaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaComprobanteVentaDetalle.Size = New System.Drawing.Size(725, 222)
        Me.GrillaComprobanteVentaDetalle.TabIndex = 8
        '
        'FormPedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 492)
        Me.Controls.Add(Me.GrillaComprobanteVentaDetalle)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.GrillaPedidosPendientes)
        Me.Name = "FormPedidos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pedidos Pendientes"
        CType(Me.GrillaPedidosPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GrillaComprobanteVentaDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrillaPedidosPendientes As System.Windows.Forms.DataGridView
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents GrillaComprobanteVentaDetalle As System.Windows.Forms.DataGridView
End Class
