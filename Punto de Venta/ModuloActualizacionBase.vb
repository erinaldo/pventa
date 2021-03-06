﻿
Imports System.Data.SqlClient

Module ModuloActualizacionBase

    Dim dsComprobanteVenta As New DataSet("ComprobanteVenta")
    Dim dsComprobanteVentaDetalle As New DataSet("ComprobanteVentaDetalle")
    Dim dsCajaDiaria As New DataSet("CajaDiaria")
    Dim dsRendicion As New DataSet("Rendicion")
    Dim dsPagos As New DataSet("Pagos")
    Dim dsComprobanteCancelado As New DataSet("ComprobanteCancelado")

    Function ActualizarComprobanteVenta(ByVal listaComprobanteVenta As List(Of ComprobanteVenta)) As Boolean

        Try
            ActualizarComprobanteVenta = False

            Dim tblCompVenta As New DataTable

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
                drCurrent("cvt_idsucursal") = compVent.IdSucursal
                drCurrent("cvt_idpuntoventa") = compVent.IdPuntoVenta
                drCurrent("cvt_pagada") = compVent.Pagada

                'Pass that new object into the Add method of the DataTable.Rows collection.
                tblCompVenta.Rows.Add(drCurrent)
            Next

            ImportDataTable(tblCompVenta, "Comprobantes_Venta")

            ActualizarComprobanteVenta = True

        Catch ex As Exception
            ActualizarComprobanteVenta = False
        End Try

    End Function

    Function ActualizarComprobanteVentaDetalle(ByVal listaComprobanteVentaDetalle As List(Of ComprobanteVentaDetalle)) As Boolean

        Try
            ActualizarComprobanteVentaDetalle = False

            Dim tblCompVentaDet As New DataTable

            ObtenerComprobanteVentaDetalleVacio(tblCompVentaDet, "Comprobantes_Venta_Detalle")

            tblCompVentaDet = dsComprobanteVentaDetalle.Tables(0)

            For Each compVent In listaComprobanteVentaDetalle

                Dim drCurrent As DataRow
                ' Obtain a new DataRow object from the DataTable.
                drCurrent = tblCompVentaDet.NewRow()

                ' Set the DataRow field values as necessary.
                drCurrent("cvd_nrocom") = compVent.Comprobante
                drCurrent("cvd_idsucursal") = compVent.Sucursal
                drCurrent("cvd_idpuntoventa") = compVent.PuntoVenta
                drCurrent("cvd_codart") = compVent.CodigoArticulo
                drCurrent("cvd_descart") = compVent.DescripcionArticulo
                drCurrent("cvd_cantidad") = compVent.Cantidad
                drCurrent("cvd_precunit") = compVent.PrecioUnitario
                drCurrent("cvd_totart") = compVent.PrecioTotal

                'Pass that new object into the Add method of the DataTable.Rows collection.
                tblCompVentaDet.Rows.Add(drCurrent)
            Next

            ImportDataTable(tblCompVentaDet, "Comprobantes_Venta_Detalle")

            ActualizarComprobanteVentaDetalle = True

        Catch ex As Exception
            ActualizarComprobanteVentaDetalle = False
        End Try
        
    End Function

    Function ActualizarCajaDiaria(ByVal listaCajaDiaria As List(Of CajaDiaria)) As Boolean

        Try
            ActualizarCajaDiaria = False

            Dim tblCompVentaDet As New DataTable

            ObtenerCajaDiariaVacio(tblCompVentaDet, "Caja_Diaria")

            tblCompVentaDet = dsCajaDiaria.Tables(0)

            For Each cajaDia In listaCajaDiaria

                Dim drCurrent As DataRow
                ' Obtain a new DataRow object from the DataTable.
                drCurrent = tblCompVentaDet.NewRow()

                ' Set the DataRow field values as necessary.
                drCurrent("cd_idCaja") = cajaDia.NroCaja
                drCurrent("cd_fechahora") = cajaDia.FechaHora
                drCurrent("cd_importe") = cajaDia.Importe
                drCurrent("cd_tpooper") = cajaDia.Operacion
                drCurrent("cd_idusuario") = cajaDia.Usuario
                drCurrent("cd_idsucursal") = cajaDia.Sucursal
                drCurrent("cd_idPuntoVenta") = cajaDia.PuntoVenta

                'Pass that new object into the Add method of the DataTable.Rows collection.
                tblCompVentaDet.Rows.Add(drCurrent)
            Next

            ImportDataTable(tblCompVentaDet, "Caja_Diaria")

            ActualizarCajaDiaria = True

        Catch ex As Exception
            ActualizarCajaDiaria = False
        End Try

    End Function

    Function ActualizarRendicion(ByVal listaRendicion As List(Of Rendicion)) As Boolean

        Try
            ActualizarRendicion = False

            Dim tblRendicion As New DataTable

            ObtenerRendicionVacio(tblRendicion, "Rendicion")

            tblRendicion = dsRendicion.Tables(0)

            For Each rendicion In listaRendicion

                Dim drCurrent As DataRow
                ' Obtain a new DataRow object from the DataTable.
                drCurrent = tblRendicion.NewRow()

                ' Set the DataRow field values as necessary.
                drCurrent("r_idCaja") = rendicion.NroCaja
                drCurrent("r_fecha") = rendicion.Fecha
                drCurrent("r_idUsuario") = rendicion.Usuario
                drCurrent("r_idSucursal") = rendicion.Sucursal
                drCurrent("r_idPuntoVenta") = rendicion.PuntoVenta
                drCurrent("r_total") = rendicion.Total
                drCurrent("r_rendido") = rendicion.Rendido
                drCurrent("r_diferencia") = rendicion.Diferencia
                drCurrent("r_comprobantes") = rendicion.Comprobantes
                drCurrent("r_idOperacion") = rendicion.Operacion

                'Pass that new object into the Add method of the DataTable.Rows collection.
                tblRendicion.Rows.Add(drCurrent)
            Next

            ImportDataTable(tblRendicion, "Rendicion")

            ActualizarRendicion = True

        Catch ex As Exception
            ActualizarRendicion = False
        End Try

    End Function

    Function ActualizarPagos(ByVal listaPagos As List(Of Pagos)) As Boolean

        Try
            ActualizarPagos = False

            Dim tblPagos As New DataTable

            ObtenerPagosVacio(tblPagos, "comprobantes_pagos")

            tblPagos = dsPagos.Tables(0)

            For Each pago In listaPagos

                Dim drCurrent As DataRow
                ' Obtain a new DataRow object from the DataTable.
                drCurrent = tblPagos.NewRow()

                ' Set the DataRow field values as necessary.
                drCurrent("cp_nrocomprobante") = pago.Comprobante
                drCurrent("cp_idSucursal") = pago.Sucursal
                drCurrent("cp_idPuntoVenta") = pago.PuntoVenta
                drCurrent("cp_idPago") = pago.IdPago
                drCurrent("cp_descripcionPago") = pago.DescripcionPago
                drCurrent("cp_Monto") = pago.Monto

                'Pass that new object into the Add method of the DataTable.Rows collection.
                tblPagos.Rows.Add(drCurrent)
            Next

            ImportDataTable(tblPagos, "comprobantes_pagos")

            ActualizarPagos = True

        Catch ex As Exception
            ActualizarPagos = False
        End Try

    End Function

    Function ActualizarComprobanteCancelado(ByVal listaComprobanteCancelado As List(Of ComprobanteCancelado)) As Boolean

        Try
            ActualizarComprobanteCancelado = False

            Dim tblCompCanc As New DataTable

            ObtenerComprobanteCanceladoVacio(tblCompCanc, "Comprobantes_Cancelados")

            tblCompCanc = dsComprobanteCancelado.Tables(0)

            For Each compCanc In listaComprobanteCancelado

                Dim drCurrent As DataRow
                ' Obtain a new DataRow object from the DataTable.
                drCurrent = tblCompCanc.NewRow()

                ' Set the DataRow field values as necessary.
                drCurrent("cc_fecha") = compCanc.Fecha
                drCurrent("cc_idsucursal") = compCanc.Sucursal
                drCurrent("cc_idpuntoventa") = compCanc.PuntoVenta
                drCurrent("cc_codart") = compCanc.CodigoArticulo
                drCurrent("cc_descart") = compCanc.DescripcionArticulo
                drCurrent("cc_cantidad") = compCanc.Cantidad
                drCurrent("cc_precunit") = compCanc.PrecioUnitario
                drCurrent("cc_totart") = compCanc.PrecioTotal
                drCurrent("cc_usuario") = compCanc.Usuario

                'Pass that new object into the Add method of the DataTable.Rows collection.
                tblCompCanc.Rows.Add(drCurrent)
            Next

            ImportDataTable(tblCompCanc, "Comprobantes_Cancelados")

            ActualizarComprobanteCancelado = True

        Catch ex As Exception
            ActualizarComprobanteCancelado = False
        End Try

    End Function

    Public Sub ImportDataTable(ByVal DataTable As DataTable, ByVal ServerTableName As String)

        Using cn As New SqlConnection(My.Settings.cadena & strUsuarioPassword),
        bcp As New SqlBulkCopy(cn, SqlBulkCopyOptions.FireTriggers Or SqlBulkCopyOptions.TableLock, Nothing)

            cn.Open()
            bcp.DestinationTableName = ServerTableName
            bcp.WriteToServer(DataTable)

        End Using
    End Sub

    Public Sub ObtenerComprobanteVentaVacio(ByRef DataTable As DataTable, ByVal ServerTableName As String)

        Dim objConn As New SqlConnection(My.Settings.cadena & strUsuarioPassword)
        objConn.Open()

        ' Create an instance of a DataAdapter.
        Dim daComprobanteVenta As New SqlDataAdapter("Select * From Comprobantes_Venta Where cvt_id = -1", objConn)

        ' Create an instance of a DataSet, and retrieve data from the Authors table.

        daComprobanteVenta.FillSchema(dsComprobanteVenta, SchemaType.Source, "Comprobantes_Venta")
        daComprobanteVenta.Fill(dsComprobanteVenta, "Comprobantes_Venta")


    End Sub

    Public Sub ObtenerComprobanteVentaDetalleVacio(ByRef DataTable As DataTable, ByVal ServerTableName As String)

        Dim objConn As New SqlConnection(My.Settings.cadena & strUsuarioPassword)
        objConn.Open()

        ' Create an instance of a DataAdapter.
        Dim daComprobanteVentaDetalle As New SqlDataAdapter("Select * From Comprobantes_Venta_Detalle Where cvd_id = -1", objConn)

        ' Create an instance of a DataSet, and retrieve data from the Authors table.

        daComprobanteVentaDetalle.FillSchema(dsComprobanteVentaDetalle, SchemaType.Source, "Comprobantes_Venta_Detalle")
        daComprobanteVentaDetalle.Fill(dsComprobanteVentaDetalle, "Comprobantes_Venta_Detalle")

    End Sub

    Public Sub ObtenerCajaDiariaVacio(ByRef DataTable As DataTable, ByVal ServerTableName As String)

        Dim objConn As New SqlConnection(My.Settings.cadena & strUsuarioPassword)
        objConn.Open()

        ' Create an instance of a DataAdapter.
        Dim daCajaDiaria As New SqlDataAdapter("Select * From Caja_Diaria Where cd_id = -1", objConn)

        ' Create an instance of a DataSet, and retrieve data from the Authors table.

        daCajaDiaria.FillSchema(dsCajaDiaria, SchemaType.Source, "Caja_Diaria")
        daCajaDiaria.Fill(dsCajaDiaria, "Caja_Diaria")

    End Sub

    Public Sub ObtenerRendicionVacio(ByRef DataTable As DataTable, ByVal ServerTableName As String)

        Dim objConn As New SqlConnection(My.Settings.cadena & strUsuarioPassword)
        objConn.Open()

        ' Create an instance of a DataAdapter.
        Dim daRendicion As New SqlDataAdapter("Select * From Rendicion Where r_id = -1", objConn)

        ' Create an instance of a DataSet, and retrieve data from the Authors table.

        daRendicion.FillSchema(dsRendicion, SchemaType.Source, "Rendicion")
        daRendicion.Fill(dsRendicion, "Rendicion")


    End Sub

    Public Sub ObtenerPagosVacio(ByRef DataTable As DataTable, ByVal ServerTableName As String)

        Dim objConn As New SqlConnection(My.Settings.cadena & strUsuarioPassword)
        objConn.Open()

        ' Create an instance of a DataAdapter.
        Dim daPagos As New SqlDataAdapter("Select * From comprobantes_pagos Where cp_id = -1", objConn)

        ' Create an instance of a DataSet, and retrieve data from the Authors table.

        daPagos.FillSchema(dsPagos, SchemaType.Source, "comprobantes_pagos")
        daPagos.Fill(dsPagos, "comprobantes_pagos")


    End Sub

    Public Sub ObtenerComprobanteCanceladoVacio(ByRef DataTable As DataTable, ByVal ServerTableName As String)

        Dim objConn As New SqlConnection(My.Settings.cadena & strUsuarioPassword)
        objConn.Open()

        ' Create an instance of a DataAdapter.
        Dim daComprobanteCancelado As New SqlDataAdapter("Select * From Comprobantes_Cancelados Where cc_id = -1", objConn)

        ' Create an instance of a DataSet, and retrieve data from the Authors table.

        daComprobanteCancelado.FillSchema(dsComprobanteCancelado, SchemaType.Source, "Comprobantes_Cancelados")
        daComprobanteCancelado.Fill(dsComprobanteCancelado, "Comprobantes_Cancelados")

    End Sub

End Module
