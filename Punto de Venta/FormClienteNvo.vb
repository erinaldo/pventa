Public Class FormClienteNvo
    Private clienteNvo As Clientes

    Public Property ClienteNuevo() As Clientes
        Get
            Return clienteNvo
        End Get
        Set(ByVal value As Clientes)
            clienteNvo = value
        End Set
    End Property

    Private Sub FormClienteNvo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clienteNvo = New Clientes
        Me.txtIdCliente.Text = 9999

        llenarComboIva()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If txtCuit.Text <> "" And txtDomicilio.Text <> "" And txtRazonSocial.Text <> "" Then
            clienteNvo.IdCliente = Me.txtIdCliente.Text
            clienteNvo.esEmpleado = 0
            clienteNvo.CuentaCorriente = 0
            clienteNvo.Domicilio = txtDomicilio.Text
            clienteNvo.IdSucursal = My.Settings.sucursal
            clienteNvo.NombreFantasia = txtRazonSocial.Text
            clienteNvo.NroDocumento = txtCuit.Text
            clienteNvo.TpoTicket = cboIva.SelectedValue

            DialogResult = DialogResult.OK
            Me.Close()
        Else
            MsgBox("Tiene que completar todos los datos, para poder grabar un nuevo cliente.", MsgBoxStyle.Information, "Mensjae al Operador")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        If MsgBox("Esta seguro que desea cancelar la carga de un nuevo cliente", MsgBoxStyle.YesNo, "Mensaje al Operador") = MsgBoxResult.Yes Then
            DialogResult = DialogResult.Cancel
            Me.Close()
        End If
    End Sub

    Private Sub llenarComboIva()
        Dim dt As DataTable = New DataTable("Tabla")

        dt.Columns.Add("tpoIva")
        dt.Columns.Add("Descripcion")

        Dim dr As DataRow

        dr = dt.NewRow()
        dr("tpoIva") = "A"
        dr("Descripcion") = "Ticket A"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("tpoIva") = "B"
        dr("Descripcion") = "Ticket B"
        dt.Rows.Add(dr)

        dr = dt.NewRow()
        dr("tpoIva") = "C"
        dr("Descripcion") = "Ticket C"
        dt.Rows.Add(dr)

        cboIva.DataSource = dt
        cboIva.ValueMember = "tpoIva"
        cboIva.DisplayMember = "Descripcion"

    End Sub
End Class