<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrincipal
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
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnCerrarCaja = New System.Windows.Forms.Button()
        Me.btnRetiroDinero = New System.Windows.Forms.Button()
        Me.btnIngresoDinero = New System.Windows.Forms.Button()
        Me.btnFacturacion = New System.Windows.Forms.Button()
        Me.btnAbrirCaja = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(235, 286)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(130, 130)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "Reporte X"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(421, 286)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(130, 130)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "Reporte Z"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PuntoVenta.My.Resources.Resources.salir_de_mi_perfil_icono_3964_96
        Me.btnCerrar.Location = New System.Drawing.Point(600, 286)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(130, 130)
        Me.btnCerrar.TabIndex = 7
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnCerrarCaja
        '
        Me.btnCerrarCaja.Enabled = False
        Me.btnCerrarCaja.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarCaja.Image = Global.PuntoVenta.My.Resources.Resources.shop_closed
        Me.btnCerrarCaja.Location = New System.Drawing.Point(55, 286)
        Me.btnCerrarCaja.Name = "btnCerrarCaja"
        Me.btnCerrarCaja.Size = New System.Drawing.Size(130, 130)
        Me.btnCerrarCaja.TabIndex = 4
        Me.btnCerrarCaja.Text = "Cerrar Caja"
        Me.btnCerrarCaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCerrarCaja.UseVisualStyleBackColor = True
        '
        'btnRetiroDinero
        '
        Me.btnRetiroDinero.Enabled = False
        Me.btnRetiroDinero.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRetiroDinero.Image = Global.PuntoVenta.My.Resources.Resources.coin_delete_96x96
        Me.btnRetiroDinero.Location = New System.Drawing.Point(600, 106)
        Me.btnRetiroDinero.Name = "btnRetiroDinero"
        Me.btnRetiroDinero.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRetiroDinero.Size = New System.Drawing.Size(130, 130)
        Me.btnRetiroDinero.TabIndex = 3
        Me.btnRetiroDinero.Text = "Retiro de Dinero"
        Me.btnRetiroDinero.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRetiroDinero.UseVisualStyleBackColor = True
        '
        'btnIngresoDinero
        '
        Me.btnIngresoDinero.Enabled = False
        Me.btnIngresoDinero.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresoDinero.Image = Global.PuntoVenta.My.Resources.Resources.coin_add_96x96
        Me.btnIngresoDinero.Location = New System.Drawing.Point(421, 106)
        Me.btnIngresoDinero.Name = "btnIngresoDinero"
        Me.btnIngresoDinero.Size = New System.Drawing.Size(130, 130)
        Me.btnIngresoDinero.TabIndex = 2
        Me.btnIngresoDinero.Text = "Ingreso de Dinero"
        Me.btnIngresoDinero.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnIngresoDinero.UseVisualStyleBackColor = True
        '
        'btnFacturacion
        '
        Me.btnFacturacion.Enabled = False
        Me.btnFacturacion.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacturacion.Image = Global.PuntoVenta.My.Resources.Resources.la_lucha_contra_la_caja_registradora_icono_4028_96
        Me.btnFacturacion.Location = New System.Drawing.Point(235, 106)
        Me.btnFacturacion.Name = "btnFacturacion"
        Me.btnFacturacion.Size = New System.Drawing.Size(130, 130)
        Me.btnFacturacion.TabIndex = 1
        Me.btnFacturacion.Text = "Facturación"
        Me.btnFacturacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnFacturacion.UseVisualStyleBackColor = True
        '
        'btnAbrirCaja
        '
        Me.btnAbrirCaja.Font = New System.Drawing.Font("Bookman Old Style", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAbrirCaja.Image = Global.PuntoVenta.My.Resources.Resources.shop_open
        Me.btnAbrirCaja.Location = New System.Drawing.Point(55, 106)
        Me.btnAbrirCaja.Name = "btnAbrirCaja"
        Me.btnAbrirCaja.Size = New System.Drawing.Size(130, 130)
        Me.btnAbrirCaja.TabIndex = 0
        Me.btnAbrirCaja.Text = "Abrir Caja"
        Me.btnAbrirCaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAbrirCaja.UseVisualStyleBackColor = True
        '
        'FormPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 542)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.btnCerrarCaja)
        Me.Controls.Add(Me.btnRetiroDinero)
        Me.Controls.Add(Me.btnIngresoDinero)
        Me.Controls.Add(Me.btnFacturacion)
        Me.Controls.Add(Me.btnAbrirCaja)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema de Ventas"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAbrirCaja As System.Windows.Forms.Button
    Friend WithEvents btnFacturacion As System.Windows.Forms.Button
    Friend WithEvents btnIngresoDinero As System.Windows.Forms.Button
    Friend WithEvents btnRetiroDinero As System.Windows.Forms.Button
    Friend WithEvents btnCerrarCaja As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
End Class
