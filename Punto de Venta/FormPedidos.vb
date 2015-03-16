﻿Imports System.IO

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
End Class