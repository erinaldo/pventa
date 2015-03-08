Imports System.IO

Public Class FormPedidos

    Dim listPedidosPendientes As List(Of PedidosPendientes)

    Private Sub FormPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            listPedidosPendientes = New List(Of PedidosPendientes)

            objStreamReader = New StreamReader("C:\Users\Sergio\Documents\ComprobanteVenta.txt")

            Do While Not objStreamReader.EndOfStream
                Dim pedidoPendiente As New PedidosPendientes

                strLine = objStreamReader.ReadLine
                If Split(strLine, ";")(10) = "I" Then
                    pedidoPendiente.Comprobante = Split(strLine, ";")(0)
                    pedidoPendiente.FormaPago = Split(strLine, ";")(13)
                    pedidoPendiente.Importe = Split(strLine, ";")(8)

                    listPedidosPendientes.Add(pedidoPendiente)
                End If
            Loop

            GrillaPedidosPendientes.DataSource = listPedidosPendientes

        Catch ex As Exception
            Throw New Exception("Error en WFL" + "Obtener Lista" + "|" + ex.Message)
        End Try
    End Sub
End Class