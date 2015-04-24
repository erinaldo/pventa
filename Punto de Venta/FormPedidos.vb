Imports System.IO

Public Class FormPedidos

    Dim listPedidosPendientes As List(Of ComprobanteVenta)
    Dim listComprobanteVentaDetalle As List(Of ComprobanteVentaDetalle)
    Dim listPagos As List(Of Pagos)
    Dim intComprobante As Integer

    Private Sub FormPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            listPedidosPendientes = New List(Of ComprobanteVenta)
            listComprobanteVentaDetalle = New List(Of ComprobanteVentaDetalle)

            If Not existeArchivo("ComprobanteVenta.txt") Then
                MsgBox("No existen pedidos para facturar", MsgBoxStyle.Information, "Mensaje al Operador")
                Exit Sub
            End If

            listPedidosPendientes = ObtenerComprobanteVenta()

            listComprobanteVentaDetalle = ObtenerComprobanteVentaDetalle()

            Dim result As List(Of ComprobanteVenta) = (From ped In listPedidosPendientes
                                                         Where ped.Origen = "I"
                                                         Select ped).ToList

            If result.Count = 0 Then
                MsgBox("No existen pedidos a Facturar.", MsgBoxStyle.Information, "Mensaje al Operador")
                Me.Close()
                Exit Sub
            End If

            GrillaPedidosPendientes.DataSource = result

            Me.GrillaPedidosPendientes.Columns("ComprobanteTipo").Visible = False
            Me.GrillaPedidosPendientes.Columns("IdSucursal").Visible = False
            Me.GrillaPedidosPendientes.Columns("IdPuntoVenta").Visible = False
            Me.GrillaPedidosPendientes.Columns("CondicionIva").Visible = False
            Me.GrillaPedidosPendientes.Columns("IdCliente").Visible = False
            'Me.GrillaPedidosPendientes.Columns("IdFormaPago").Visible = False
            Me.GrillaPedidosPendientes.Columns("IdUsuario").Visible = False
            Me.GrillaPedidosPendientes.Columns("Origen").Visible = False
            Me.GrillaPedidosPendientes.Columns("PorcentajeIva").Visible = False

        Catch ex As FileNotFoundException
            MsgBox("No existen Pedidos.", MsgBoxStyle.Information, "Mensaje al Operador")
            Me.Close()
        Catch ex As Exception
            Throw New Exception("Error en WFL" + "Obtener Lista" + "|" + ex.Message)
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click

        If MsgBox("Quiere imprimir el Ticket?", MsgBoxStyle.YesNo, "Mensaje al Operador") = MsgBoxResult.No Then
            Exit Sub
        End If

        Try

            listPagos = New List(Of Pagos)

            listPagos = ObtenerPagos()

            Dim lstPagos As List(Of Pagos) = (From pago In listPagos
                                     Where pago.Comprobante = intComprobante
                                     Select pago).ToList

            ImprimirTicketFiscal(GrillaComprobanteVentaDetalle, lstPagos)

            Dim result As ComprobanteVenta = (From comp In listPedidosPendientes
                                                     Where comp.Comprobante = intComprobante
                                                     Select comp).First

            result.Origen = "F"
            result.ComprobanteFiscal = obtenerNroComprobanteFiscal()

            Dim objStreamWriter As StreamWriter
            Dim strLine As String
            Try


                objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "ComprobanteVenta.txt", False, System.Text.ASCIIEncoding.ASCII)

                For Each compVent In listPedidosPendientes
                    strLine = compVent.Comprobante & ";" & compVent.ComprobanteFiscal & ";" & compVent.ComprobanteTipo & ";" & compVent.IdCliente & ";" & _
                                    FormatDateTime(compVent.FechaEmision, DateFormat.ShortDate) & ";" & _
                                    compVent.CondicionIva & ";" & compVent.PrecioBase & ";" & compVent.PorcentajeIva & ";" & compVent.TotalComprobante & ";" & compVent.IdUsuario & ";" & compVent.Origen & ";" & _
                                    compVent.Descuento & ";" & compVent.TotalDescuento & ";" & compVent.IdSucursal & ";" & compVent.IdPuntoVenta

                    objStreamWriter.WriteLine(strLine)

                Next
                objStreamWriter.Close()
            Catch ex As Exception
                MsgBox("Error al grabar los comprobantes.", MsgBoxStyle.Information, "Mensaje al Operador")
            End Try
        Catch ex As Exception
            MsgBox("Error al imprimir el comprobante.", MsgBoxStyle.Information, "Mensaje al Operador")
        End Try

    End Sub

    Private Sub GrillaPedidosPendientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaPedidosPendientes.CellClick
        Try
            intComprobante = GrillaPedidosPendientes.CurrentRow.Cells("Comprobante").Value

            Dim result As List(Of ComprobanteVentaDetalle) = (From comp In listComprobanteVentaDetalle
                                                             Where comp.Comprobante = intComprobante
                                                             Select comp).ToList

            GrillaComprobanteVentaDetalle.DataSource = result
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub FormPedidos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub GrillaPedidosPendientes_SelectionChanged(sender As Object, e As EventArgs) Handles GrillaPedidosPendientes.SelectionChanged
        Try
            intComprobante = GrillaPedidosPendientes.CurrentRow.Cells("Comprobante").Value

            Dim result As List(Of ComprobanteVentaDetalle) = (From comp In listComprobanteVentaDetalle
                                                             Where comp.Comprobante = intComprobante
                                                             Select comp).ToList

            GrillaComprobanteVentaDetalle.DataSource = result
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GrillaPedidosPendientes_KeyDown(sender As Object, e As KeyEventArgs) Handles GrillaPedidosPendientes.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnImprimir_Click(sender, e)
        End If
    End Sub
End Class