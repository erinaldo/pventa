Public Class FormConsulta

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If TextBox1.Text <> "" Then
                Label1.Text = BuscarArticulo(TextBox1.Text).PrecioVenta
            End If
        End If
    End Sub

    Function BuscarArticulo(ByVal strCodBarra As String) As Articulos

        Try

            Dim listaArt = ObtenerArticulos()

            BuscarArticulo = New Articulos

            'BuscarArticulo = (From art In listaArt
            '                  Where art.CodigoBarras = strCodBarra And art.IdLista = intIdLista
            '                  Select art).First

            BuscarArticulo = (From art In listaArt
                      Where art.CodigoBarras = strCodBarra
                      Select art).First

        Catch ex As Exception
            TextBox1.Text = ""
            Label1.Text = Format(0, 2)
            TextBox1.Focus()
        End Try
    End Function

    Private Sub FormConsulta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
            Me.Close()
        End If
    End Sub
End Class