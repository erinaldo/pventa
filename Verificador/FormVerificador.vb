Imports System.IO

Public Class FormVerificador

    Dim listaArt As List(Of Articulos)
    Private Declare Function GetTickCount Lib "kernel32" () As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaArt = ObtenerArticulos()
    End Sub

    Public Function ObtenerArticulos() As List(Of Articulos)
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            ObtenerArticulos = New List(Of Articulos)

            objStreamReader = New StreamReader(My.Settings.rutaArchivos & "Articulos.txt")

            Do While Not objStreamReader.EndOfStream
                Dim art As New Articulos

                strLine = objStreamReader.ReadLine
                art.Codigo = Split(strLine, ";")(0)
                art.Descripcion = Split(strLine, ";")(1)
                art.CodigoBarras = Split(strLine, ";")(2)
                art.PrecioCosto = Split(strLine, ";")(3)
                art.PrecioVenta = Split(strLine, ";")(4)
                'art.IdLista = Split(strLine, ";")(5)
                art.Unidad = Split(strLine, ";")(5)
                art.CostoGranel = Split(strLine, ";")(6)
                art.UnidadGranel = Split(strLine, ";")(7)

                ObtenerArticulos.Add(art)
            Loop

            objStreamReader.Close()
        Catch ex As FileNotFoundException
            Throw New Exception("Error en Modulo General." + " No se encontro el archivo de Articulos" + "|" + ex.Message)
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Obtener Articulos" + "|" + ex.Message)
        End Try
    End Function


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If TextBox1.Text <> "" Then
                Dim Art As Articulos
                Art = BuscarArticulo(listaArt, TextBox1.Text, 1)
                TextBox1.Text = ""
                If Art.Descripcion Is Nothing Then
                    TextBox1.Text = ""
                    Label1.Text = " - - "
                    Label2.Text = "Articulo no Encontrado"
                    TextBox1.Focus()
                Else
                    Label2.Text = Art.Descripcion
                    Label1.Text = "$" & FormatNumber(Art.PrecioVenta, 2).ToString.PadLeft(7)
                    TextBox1.SelectAll()
                End If
                Borrar()
            End If
        End If
    End Sub

    Public Sub Borrar()
        Dim retraso As Integer

        retraso = My.Settings.espera + GetTickCount

        While retraso >= GetTickCount
            Application.DoEvents()
        End While

        Label1.Text = ""
        Label2.Text = ""
        listaArt = ObtenerArticulos()
        TextBox1.SelectAll()
        TextBox1.Text = ""
        TextBox1.Focus()
    End Sub

    Function BuscarArticulo(ByVal listaArt As List(Of Articulos), ByVal strCodBarra As String, ByVal intIdLista As Integer) As Articulos

        Try

            BuscarArticulo = New Articulos

            BuscarArticulo = (From art In listaArt
                      Where art.CodigoBarras = strCodBarra
                      Select art).First

        Catch ex As Exception

        End Try
    End Function

    Private Sub FormVerificador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
            Me.Close()
        End If
    End Sub
End Class
