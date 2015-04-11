Module ModuloImpresion

    Private miOCX As FiscalPrinterLib.HASAR

    Public Sub ImprimirTicketFiscal(ByVal grilla As DataGridView)
        miOCX = New FiscalPrinterLib.HASAR

        Try
            miOCX.Puerto = My.Settings.puertoFiscal
            miOCX.Modelo = My.Settings.impresoraFiscal
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
            miOCX.ImprimirPago("Pago con", Paga)
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

            miOCX.Puerto = My.Settings.puertoFiscal
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

            miOCX.Puerto = My.Settings.puertoFiscal
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

            miOCX.Puerto = My.Settings.puertoFiscal
            miOCX.Comenzar()
            obtenerNroComprobanteFiscal = miOCX.UltimoDocumentoFiscalBC()
            miOCX.Finalizar()

        Catch ex As Exception
            obtenerNroComprobanteFiscal = -1
        End Try
    End Function

End Module
