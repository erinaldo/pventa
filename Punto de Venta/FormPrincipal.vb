Imports System.IO

Public Class FormPrincipal

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MsgBox("Esta seguro de imprimir el Reporte Z?", MsgBoxStyle.YesNo, "Reporte Z") = MsgBoxResult.Yes Then
            ImprimirReporteZ()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormEmiteFac.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Esta seguro de imprimir el Reporte X?", MsgBoxStyle.YesNo, "Reporte X") = MsgBoxResult.Yes Then
            ImprimirReporteX()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim objStreamReader As StreamReader
        Dim strLine As String
        Dim listPedidosPendientes As List(Of ComprobanteVenta)

        listPedidosPendientes = New List(Of ComprobanteVenta)


        objStreamReader = New StreamReader("C:\ComprobanteVenta.txt", System.Text.ASCIIEncoding.ASCII)

        Do While Not objStreamReader.EndOfStream
            Dim pedidoPendiente As New ComprobanteVenta

            strLine = objStreamReader.ReadLine

            pedidoPendiente.Comprobante = Split(strLine, ";")(0)
            pedidoPendiente.ComprobanteFiscal = Split(strLine, ";")(1)
            pedidoPendiente.ComprobanteTipo = Split(strLine, ";")(2)
            pedidoPendiente.IdCliente = Split(strLine, ";")(3)
            pedidoPendiente.FechaEmision = Split(strLine, ";")(4)
            pedidoPendiente.CondicionIva = Split(strLine, ";")(5)
            pedidoPendiente.PrecioBase = Split(strLine, ";")(6)
            pedidoPendiente.PorcentajeIva = Split(strLine, ";")(7)
            pedidoPendiente.TotalComprobante = Split(strLine, ";")(8)
            pedidoPendiente.IdUsuario = Split(strLine, ";")(9)
            pedidoPendiente.Origen = Split(strLine, ";")(10)
            pedidoPendiente.Descuento = Split(strLine, ";")(11)
            pedidoPendiente.TotalDescuento = Split(strLine, ";")(12)
            pedidoPendiente.IdFormaPago = Split(strLine, ";")(13)
            pedidoPendiente.FormaPago = Split(strLine, ";")(14)
            pedidoPendiente.CondicionVenta = Split(strLine, ";")(15)
            pedidoPendiente.Remito = Split(strLine, ";")(16)
            pedidoPendiente.Impuestos = Split(strLine, ";")(17)
            pedidoPendiente.SubtotalImpuestos = Split(strLine, ";")(18)
            pedidoPendiente.MontoIva = Split(strLine, ";")(19)
            pedidoPendiente.NroFactura = Split(strLine, ";")(20)
            pedidoPendiente.Pagada = Split(strLine, ";")(21)

            listPedidosPendientes.Add(pedidoPendiente)

        Loop

        objStreamReader.Close()

        ActualizarComprobanteVenta(listPedidosPendientes)
    End Sub
End Class