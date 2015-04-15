Public Class FormConsulta

    Dim listaArt As List(Of Articulos)

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If TextBox1.Text <> "" Then
                Dim Art As Articulos
                Art = BuscarArticulo(listaArt, TextBox1.Text, 1)
                If Art.Descripcion Is Nothing Then
                    TextBox1.Text = ""
                    Label1.Text = FormatNumber(0, 2)
                    Label2.Text = "Articulo no Encontrado"
                    TextBox1.Focus()
                Else
                    Label2.Text = Art.Descripcion
                    Label1.Text = FormatNumber(Art.PrecioVenta, 2)
                    TextBox1.SelectAll()
                End If

            End If
        End If
    End Sub

    

    Private Sub FormConsulta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
            Me.Close()
        ElseIf e.KeyChar = ChrW(Keys.Delete) Then
            TextBox1.Text = ""
            Label1.Text = FormatNumber(0, 2)
            Label2.Text = ""
            TextBox1.Focus()
        End If
    End Sub

    Private Sub FormConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listaArt = ObtenerArticulos()

    End Sub
End Class