<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBuscarArtFactu
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
        Me.btnCodBar = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btncontinua = New System.Windows.Forms.Button()
        Me.txtCodbar = New System.Windows.Forms.TextBox()
        Me.txtdescri = New System.Windows.Forms.TextBox()
        Me.btnDescri = New System.Windows.Forms.RadioButton()
        Me.btnSeleccionar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.GrillaArticulos = New System.Windows.Forms.DataGridView()
        Me.Codart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripción = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codbar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GrillaArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCodBar
        '
        Me.btnCodBar.AutoSize = True
        Me.btnCodBar.Location = New System.Drawing.Point(33, 19)
        Me.btnCodBar.Name = "btnCodBar"
        Me.btnCodBar.Size = New System.Drawing.Size(176, 17)
        Me.btnCodBar.TabIndex = 0
        Me.btnCodBar.TabStop = True
        Me.btnCodBar.Text = "Búsqueda por código de barras:"
        Me.btnCodBar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.btncontinua)
        Me.GroupBox1.Controls.Add(Me.txtCodbar)
        Me.GroupBox1.Controls.Add(Me.txtdescri)
        Me.GroupBox1.Controls.Add(Me.btnDescri)
        Me.GroupBox1.Controls.Add(Me.btnCodBar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(679, 77)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Búsqueda de articulos"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(519, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(134, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Volver Busqueda"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btncontinua
        '
        Me.btncontinua.Location = New System.Drawing.Point(519, 40)
        Me.btncontinua.Name = "btncontinua"
        Me.btncontinua.Size = New System.Drawing.Size(134, 23)
        Me.btncontinua.TabIndex = 4
        Me.btncontinua.Text = "Continúa Buscando"
        Me.btncontinua.UseVisualStyleBackColor = True
        '
        'txtCodbar
        '
        Me.txtCodbar.Location = New System.Drawing.Point(94, 42)
        Me.txtCodbar.Name = "txtCodbar"
        Me.txtCodbar.Size = New System.Drawing.Size(293, 20)
        Me.txtCodbar.TabIndex = 1
        Me.txtCodbar.Visible = False
        '
        'txtdescri
        '
        Me.txtdescri.Location = New System.Drawing.Point(94, 42)
        Me.txtdescri.Name = "txtdescri"
        Me.txtdescri.Size = New System.Drawing.Size(293, 20)
        Me.txtdescri.TabIndex = 0
        '
        'btnDescri
        '
        Me.btnDescri.AutoSize = True
        Me.btnDescri.Location = New System.Drawing.Point(312, 19)
        Me.btnDescri.Name = "btnDescri"
        Me.btnDescri.Size = New System.Drawing.Size(151, 17)
        Me.btnDescri.TabIndex = 1
        Me.btnDescri.TabStop = True
        Me.btnDescri.Text = "Búsqueda por descripción:"
        Me.btnDescri.UseVisualStyleBackColor = True
        '
        'btnSeleccionar
        '
        Me.btnSeleccionar.Location = New System.Drawing.Point(708, 243)
        Me.btnSeleccionar.Name = "btnSeleccionar"
        Me.btnSeleccionar.Size = New System.Drawing.Size(75, 34)
        Me.btnSeleccionar.TabIndex = 6
        Me.btnSeleccionar.Text = "Seleccionar"
        Me.btnSeleccionar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(325, 467)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(95, 35)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'GrillaArticulos
        '
        Me.GrillaArticulos.AllowUserToAddRows = False
        Me.GrillaArticulos.AllowUserToDeleteRows = False
        Me.GrillaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrillaArticulos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Codart, Me.Descripción, Me.Codbar, Me.Precio})
        Me.GrillaArticulos.Location = New System.Drawing.Point(12, 95)
        Me.GrillaArticulos.Name = "GrillaArticulos"
        Me.GrillaArticulos.ReadOnly = True
        Me.GrillaArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrillaArticulos.Size = New System.Drawing.Size(679, 349)
        Me.GrillaArticulos.TabIndex = 4
        '
        'Codart
        '
        Me.Codart.HeaderText = "Código"
        Me.Codart.Name = "Codart"
        Me.Codart.ReadOnly = True
        Me.Codart.Width = 90
        '
        'Descripción
        '
        Me.Descripción.HeaderText = "Descripción"
        Me.Descripción.Name = "Descripción"
        Me.Descripción.ReadOnly = True
        Me.Descripción.Width = 320
        '
        'Codbar
        '
        Me.Codbar.HeaderText = "Codigo de Barras"
        Me.Codbar.Name = "Codbar"
        Me.Codbar.ReadOnly = True
        Me.Codbar.Width = 110
        '
        'Precio
        '
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        '
        'FormBuscarArtFactu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 519)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSeleccionar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.GrillaArticulos)
        Me.Name = "FormBuscarArtFactu"
        Me.Text = "Buscar Articulo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GrillaArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCodBar As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btncontinua As System.Windows.Forms.Button
    Friend WithEvents txtCodbar As System.Windows.Forms.TextBox
    Friend WithEvents txtdescri As System.Windows.Forms.TextBox
    Friend WithEvents btnDescri As System.Windows.Forms.RadioButton
    Friend WithEvents btnSeleccionar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents GrillaArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents Codart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripción As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codbar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Precio As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
