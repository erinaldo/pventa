
Imports System.Data.SqlClient

Module ModuloActualizacionBase

    Dim dsComprobanteVenta As New DataSet("ComprobanteVenta")

    Public Sub ActualizarComprobanteVenta(ByVal listaComprobanteVenta As List(Of ComprobanteVenta))

        Dim tblCompVenta As DataTable
        tblCompVenta = dsComprobanteVenta.Tables(0)

        ObtenerComprobanteVentaVacio(tblCompVenta, "Comprobantes_Venta")

        tblCompVenta = dsComprobanteVenta.Tables(0)

        For Each compVent In listaComprobanteVenta

            Dim drCurrent As DataRow
            ' Obtain a new DataRow object from the DataTable.
            drCurrent = tblCompVenta.NewRow()

            ' Set the DataRow field values as necessary.
            drCurrent("cvt_nrocom") = compVent.Comprobante
            drCurrent("cvt_nrocomfiscal") = compVent.ComprobanteFiscal
            drCurrent("cvt_tipcom") = compVent.ComprobanteTipo
            drCurrent("cvt_idcliente") = compVent.IdCliente
            drCurrent("cvt_fecha") = compVent.FechaEmision
            drCurrent("cvt_idcondiva") = compVent.CondicionIva
            drCurrent("cvt_pbase") = compVent.PrecioBase
            drCurrent("cvt_porciva") = compVent.PorcentajeIva
            drCurrent("cvt_totcom") = compVent.TotalComprobante
            drCurrent("cvt_idusuario") = compVent.IdUsuario
            drCurrent("cvt_origen") = compVent.Origen
            drCurrent("cvt_dto") = compVent.Descuento
            drCurrent("cvt_totaldto") = compVent.TotalDescuento
            drCurrent("cvt_formapago") = compVent.IdFormaPago
            drCurrent("cvt_condicionventa") = compVent.CondicionVenta
            drCurrent("cvt_remito") = compVent.Remito
            drCurrent("cvt_impuestos") = compVent.Impuestos
            drCurrent("cvt_subtotali") = compVent.SubtotalImpuestos
            drCurrent("cvt_montoiva") = compVent.MontoIva
            drCurrent("cvt_nrofactura") = compVent.NroFactura
            drCurrent("cvt_pagada") = compVent.Pagada
            drCurrent("cvt_idsucursal") = My.Settings.sucursal

            'Pass that new object into the Add method of the DataTable.Rows collection.
            tblCompVenta.Rows.Add(drCurrent)
        Next

        ImportDataTable(tblCompVenta, "Comprobantes_Venta")
    End Sub

    Public Sub ActualizarComprobanteVentaDetalle(ByVal listaComprobanteVentaDetalle As List(Of ComprobanteVentaDetalle))

    End Sub

    Public Sub ImportDataTable(ByVal DataTable As DataTable, ByVal ServerTableName As String)

        Using cn As New SqlConnection(My.Settings.cadena), _
        bcp As New SqlBulkCopy(cn, SqlBulkCopyOptions.TableLock, Nothing)

            cn.Open()
            bcp.DestinationTableName = ServerTableName
            bcp.WriteToServer(DataTable)

        End Using
    End Sub

    Public Sub ObtenerComprobanteVentaVacio(ByRef DataTable As DataTable, ByVal ServerTableName As String)

        Dim objConn As New SqlConnection(My.Settings.cadena)
        objConn.Open()

        ' Create an instance of a DataAdapter.
        Dim daComprobanteVenta As New SqlDataAdapter("Select * From Comprobantes_Venta Where cvt_id = -1", objConn)

        ' Create an instance of a DataSet, and retrieve data from the Authors table.

        daComprobanteVenta.FillSchema(dsComprobanteVenta, SchemaType.Source, "Comprobantes_Venta")
        daComprobanteVenta.Fill(dsComprobanteVenta, "Comprobantes_Venta")


    End Sub

End Module
