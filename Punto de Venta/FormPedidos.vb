Imports System.IO

Public Class FormPedidos

    Dim listPedidosPendientes As List(Of ComprobanteVenta)
    Dim listComprobanteVentaDetalle As List(Of ComprobanteVentaDetalle)
    Dim intComprobante As Integer

    Private Sub FormPedidos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            listPedidosPendientes = New List(Of ComprobanteVenta)
            listComprobanteVentaDetalle = New List(Of ComprobanteVentaDetalle)

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
            Me.GrillaPedidosPendientes.Columns("CondicionIva").Visible = False
            Me.GrillaPedidosPendientes.Columns("IdCliente").Visible = False
            Me.GrillaPedidosPendientes.Columns("IdFormaPago").Visible = False
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

        ImprimirTicketFiscal(GrillaComprobanteVentaDetalle)

        Dim result As ComprobanteVenta = (From comp In listPedidosPendientes
                                                 Where comp.Comprobante = intComprobante
                                                 Select comp).First

        
        result.Origen = "F"

        Dim objStreamWriter As StreamWriter
        Dim strLine As String

        objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "ComprobanteVenta.txt", False, System.Text.ASCIIEncoding.ASCII)

        For Each compVent In listPedidosPendientes
            strLine = compVent.Comprobante & ";" & compVent.ComprobanteFiscal & ";" & compVent.ComprobanteTipo & ";" & compVent.IdCliente & ";" & _
                            FormatDateTime(compVent.FechaEmision, DateFormat.ShortDate) & ";" & _
                            compVent.CondicionIva & ";" & compVent.PrecioBase & ";" & compVent.PorcentajeIva & ";" & compVent.TotalComprobante & ";" & compVent.IdUsuario & ";" & compVent.Origen & ";" & _
                            compVent.Descuento & ";" & compVent.TotalDescuento & ";" & compVent.IdFormaPago & ";" & compVent.FormaPago

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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class