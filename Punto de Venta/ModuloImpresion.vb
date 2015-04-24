Module ModuloImpresion

    Private miOCX As FiscalPrinterLib.HASAR

    Public Sub ImprimirTicketFiscal(ByVal grilla As DataGridView, ByVal lstPagos As List(Of Pagos))
        miOCX = New FiscalPrinterLib.HASAR

        Try
            miOCX.Puerto = 1
            miOCX.Baudios = 9600
            miOCX.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
            miOCX.Comenzar()
            miOCX.TratarDeCancelarTodo()
            miOCX.AbrirComprobanteFiscal(FiscalPrinterLib.DocumentosFiscales.TICKET_C)

            Dim filas As Integer = grilla.Rows.Count - 1

            For i = 0 To filas
                miOCX.ImprimirItem(Mid(grilla.Rows(i).Cells("DescripcionArticulo").Value(), 1, 15), grilla.Rows(i).Cells("Cantidad").Value(), grilla.Rows(i).Cells("PrecioUnitario").Value(), 0, 0)
            Next i
            'If MontoDesc <> 0 Then
            '    miOCX.DescuentoGeneral("Descuento", MontoDesc, True)
            'End If
            For Each pago In lstPagos
                miOCX.ImprimirPago(pago.DescripcionPago, pago.Abonado)
            Next

            'miOCX.ImprimirPago("Vuelto", Vuelto) '*** Linea que sacamos para 5 y 63 - 30/09/2010

            miOCX.CerrarComprobanteFiscal()
            miOCX.Finalizar()
        Catch ex As Exception
            Throw New Exception("Error en Modulo Impresion" + "Imprimiendo Item" + "|" + ex.Message)
        End Try

    End Sub

    Public Sub ImprimirTicketFiscalA(ByVal cliente As Clientes, ByVal grilla As DataGridView, ByVal lstPagos As List(Of Pagos))
        miOCX = New FiscalPrinterLib.HASAR

        Try
            miOCX.Puerto = 1
            miOCX.Baudios = 9600
            miOCX.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
            miOCX.Comenzar()
            miOCX.TratarDeCancelarTodo()
            miOCX.DatosCliente(cliente.NombreFantasia, cliente.NroDocumento, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.RESPONSABLE_INSCRIPTO, cliente.Domicilio)
            miOCX.AbrirComprobanteFiscal(FiscalPrinterLib.DocumentosFiscales.TICKET_FACTURA_A)

            Dim filas As Integer = grilla.Rows.Count - 1

            For i = 0 To filas
                miOCX.ImprimirItem(Mid(grilla.Rows(i).Cells("DescripcionArticulo").Value(), 1, 15), grilla.Rows(i).Cells("Cantidad").Value(), grilla.Rows(i).Cells("PrecioUnitario").Value(), 0, 0)
            Next i
            'If MontoDesc <> 0 Then
            '    miOCX.DescuentoGeneral("Descuento", MontoDesc, True)
            'End If
            For Each pago In lstPagos
                miOCX.ImprimirPago(pago.DescripcionPago, pago.Abonado)
            Next
            'miOCX.ImprimirPago("Vuelto", Vuelto) '*** Linea que sacamos para 5 y 63 - 30/09/2010

            miOCX.CerrarComprobanteFiscal()
            miOCX.Finalizar()
        Catch ex As Exception
            Throw New Exception("Error en Modulo Impresion" + "Imprimiendo Item" + "|" + ex.Message)
        End Try

    End Sub

    Function ImprimirReporteZ() As Boolean
        Try

            miOCX = New FiscalPrinterLib.HASAR

            miOCX.Puerto = 1
            miOCX.Baudios = 9600
            miOCX.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
            miOCX.Comenzar()
            miOCX.TratarDeCancelarTodo()
            miOCX.ReporteZ()
            miOCX.Finalizar()

            ImprimirReporteZ = True
        Catch ex As Exception
            ImprimirReporteZ = False
        End Try
    End Function

    Function ImprimirReporteX() As Boolean
        Try

            miOCX = New FiscalPrinterLib.HASAR

            miOCX.Puerto = 1
            miOCX.Baudios = 9600
            miOCX.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
            miOCX.Comenzar()
            miOCX.TratarDeCancelarTodo()
            miOCX.ReporteX()
            miOCX.Finalizar()

            ImprimirReporteX = True
        Catch ex As Exception
            ImprimirReporteX = False
        End Try
    End Function

    Function obtenerNroComprobanteFiscal() As Integer
        Try

            miOCX = New FiscalPrinterLib.HASAR

            miOCX.Puerto = 1
            miOCX.Baudios = 9600
            miOCX.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
            miOCX.Comenzar()
            obtenerNroComprobanteFiscal = miOCX.UltimoDocumentoFiscalBC()
            miOCX.Finalizar()

        Catch ex As Exception
            obtenerNroComprobanteFiscal = -1
        End Try
    End Function

End Module
