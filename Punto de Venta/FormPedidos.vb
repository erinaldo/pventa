Imports System.IO

Public Class FormPedidos

    Dim listPedidosPendientes As List(Of ComprobanteVenta)
    Dim listComprobanteVentaDetalle As List(Of ComprobanteVentaDetalle)
    Dim intComprobante As Integer

    Private Sub FormPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            listPedidosPendientes = New List(Of ComprobanteVenta)
            listComprobanteVentaDetalle = New List(Of ComprobanteVentaDetalle)

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

            objStreamReader = New StreamReader("C:\ComprobanteVentaDetalle.txt", System.Text.ASCIIEncoding.ASCII)

            Do While Not objStreamReader.EndOfStream
                Dim compVentDetalle As New ComprobanteVentaDetalle

                strLine = objStreamReader.ReadLine

                compVentDetalle.Comprobante = Split(strLine, ";")(0)
                compVentDetalle.ComprobanteFiscal = Split(strLine, ";")(1)
                compVentDetalle.CodigoArticulo = Split(strLine, ";")(2)
                compVentDetalle.DescripcionArticulo = Split(strLine, ";")(3)
                compVentDetalle.Cantidad = Split(strLine, ";")(4)
                compVentDetalle.PrecioUnitario = Split(strLine, ";")(5)
                compVentDetalle.PrecioTotal = Split(strLine, ";")(6)

                listComprobanteVentaDetalle.Add(compVentDetalle)

            Loop

            Dim result As List(Of ComprobanteVenta) = (From ped In listPedidosPendientes
                                                         Where ped.Origen = "I"
                                                         Select ped).ToList

            GrillaPedidosPendientes.DataSource = result


        Catch ex As Exception
            Throw New Exception("Error en WFL" + "Obtener Lista" + "|" + ex.Message)
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        ImprimirTicketFiscal(GrillaComprobanteVentaDetalle)

        Dim result As ComprobanteVenta = (From comp In listPedidosPendientes
                                                 Where comp.Comprobante = intComprobante
                                                 Select comp).First

        result.Origen = "F"

        Dim objStreamWriter As StreamWriter
        Dim strLine As String

        objStreamWriter = New StreamWriter("C:\ComprobanteVenta.txt", False, System.Text.ASCIIEncoding.ASCII)

        For Each compVent In listPedidosPendientes
            strLine = compVent.Comprobante & ";" & compVent.ComprobanteFiscal & ";" & compVent.ComprobanteTipo & ";" & compVent.IdCliente & ";" & _
                            FormatDateTime(compVent.FechaEmision, DateFormat.ShortDate) & ";" & _
                            compVent.CondicionIva & ";" & compVent.PrecioBase & ";" & compVent.PorcentajeIva & ";" & compVent.TotalComprobante & ";" & compVent.IdUsuario & ";" & compVent.Origen & ";" & _
                            compVent.Descuento & ";" & compVent.TotalDescuento & ";" & compVent.IdFormaPago & ";" & compVent.FormaPago & ";" & compVent.CondicionVenta & ";" & compVent.Remito & ";" & _
                            compVent.Impuestos & ";" & compVent.SubtotalImpuestos & ";" & compVent.MontoIva & ";" & _
                            compVent.NroFactura & ";" & compVent.Pagada

            objStreamWriter.WriteLine(strLine)

        Next
        objStreamWriter.Close()

    End Sub

    Private Sub GrillaPedidosPendientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaPedidosPendientes.CellClick

        intComprobante = GrillaPedidosPendientes.CurrentRow.Cells("Comprobante").Value

        Dim result As List(Of ComprobanteVentaDetalle) = (From comp In listComprobanteVentaDetalle
                                                         Where comp.Comprobante = intComprobante
                                                         Select comp).ToList

        GrillaComprobanteVentaDetalle.DataSource = result
    End Sub
End Class