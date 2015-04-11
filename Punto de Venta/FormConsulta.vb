Public Class FormConsulta

    Dim listaArt As List(Of Articulos)

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If TextBox1.Text <> "" Then
                Dim Art As Articulos
                Art = BuscarArticulo(TextBox1.Text)
                If Art.Descripcion Is Nothing Then
                    TextBox1.Text = ""
                    Label1.Text = FormatNumber(0, 2)
                    Label2.Text = "Articulo no Encontrado"
                    TextBox1.Focus()
                Else
                    Label2.Text = Art.Descripcion
                    Label1.Text = Art.PrecioVenta
                End If

            End If
        End If
    End Sub

    Function BuscarArticulo(ByVal strCodBarra As String) As Articulos

        Try

            BuscarArticulo = New Articulos

            'BuscarArticulo = (From art In listaArt
            '                  Where art.CodigoBarras = strCodBarra And art.IdLista = intIdLista
            '                  Select art).First

            BuscarArticulo = (From art In listaArt
                      Where art.CodigoBarras = strCodBarra
                      Select art).First

        Catch ex As Exception

        End Try
    End Function

    Private Sub FormConsulta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub FormConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listaArt = ObtenerArticulos()

    End Sub
End Class