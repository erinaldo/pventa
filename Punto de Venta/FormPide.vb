Public Class FormPide
    Dim descart As String
    Dim tot As Double

    Public Sub Cargar_Formulario(des As String, ByRef total As Double)
        descart = des
        lbldescart.Text = descart
        tot = total
        Me.txtprecio.Text = ""
        Me.txtprecio.Focus()
        ShowDialog()
        total = tot
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        If txtprecio.Text = "" Then
            tot = 0
            Me.Dispose()
            Me.Close()
            Exit Sub
        End If

        If CDbl(txtprecio.Text) < 0 Then
            tot = 0
            Me.Dispose()
            Me.Close()
            Exit Sub
        End If
        tot = CDbl(txtprecio.Text)
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub txtprecio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtprecio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtprecio_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtprecio.Validating
        Try
            txtprecio.Text = FormatNumber(Replace(txtprecio.Text, ".", ","), 2)
        Catch ex As Exception
            txtprecio.Text = 0
        End Try
    End Sub
End Class