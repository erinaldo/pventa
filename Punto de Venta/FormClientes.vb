Public Class FormClientes
    Private lstClientesAux As New List(Of Clientes)

    Private intIdCliente As Integer

    Public Property IdCliente() As Integer
        Get
            Return intIdCliente
        End Get
        Set(ByVal value As Integer)
            intIdCliente = value
        End Set
    End Property

    Public Sub Abrir(ByRef lstclientes As List(Of Clientes))
        lstClientesAux = lstclientes

        cargarGrilla(0)

        ocultarColumnas()

        Me.ShowDialog()

        lstclientes = lstClientesAux
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim frm As New FormClienteNvo

        frm.ShowDialog()
        If frm.DialogResult = DialogResult.OK Then
            lstClientesAux.Add(frm.ClienteNuevo)
            cargarGrilla(0)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If grillaClientes.CurrentCell.Selected = True Then
            intIdCliente = grillaClientes.CurrentRow.Cells(1).Value
            DialogResult = DialogResult.OK
            'CodartBuscado = GrillaArticulos.Item(0, GrillaArticulos.CurrentCell.RowIndex).Value
            'CodigoBarrasBuscado = GrillaArticulos.Item(2, GrillaArticulos.CurrentCell.RowIndex).Value
            Me.Close()
        End If
    End Sub

    Private Sub cargarGrilla(ByVal intEsEmpleado As Integer)
        Try

            grillaClientes.DataSource = Nothing
            grillaClientes.Rows.Clear()
            grillaClientes.DataSource = (From lst In lstClientesAux
                                         Where lst.esEmpleado = intEsEmpleado
                                         Select lst).ToList

        Catch ex As Exception
            MsgBox("Error Nro.120. Comuniquese con Administracion", MsgBoxStyle.Critical, "Mensaje al Operador")
        End Try
    End Sub

    Private Sub ocultarColumnas()
        Try
            grillaClientes.Columns(0).Visible = False
            grillaClientes.Columns(6).Visible = False
            grillaClientes.Columns(7).Visible = False
            grillaClientes.Columns(1).Width = 50
            grillaClientes.Columns(2).Width = 150
            grillaClientes.Columns(3).Width = 65
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            cargarGrilla(0)
            ocultarColumnas()
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            cargarGrilla(1)
            ocultarColumnas()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FormClientes_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyData = Keys.F1 Then
            If RadioButton1.Checked Then
                RadioButton2.Checked = True
            Else
                RadioButton1.Checked = True
            End If
        End If
    End Sub

    Private Sub grillaClientes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grillaClientes.CellDoubleClick
        Button1_Click(sender, e)
    End Sub
End Class