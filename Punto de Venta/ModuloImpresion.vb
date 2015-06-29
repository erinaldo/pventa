Module ModuloImpresion

    Private WithEvents miOCX As FiscalPrinterLib.HASAR

    'Public Sub miOcx_EventoFaltaPapel() Handles miOCX.FaltaPapel
    '    miOCX.TratarDeCancelarTodo()
    '    MsgBox("Error en la impresora. Falta Papel", MsgBoxStyle.Information, "Mensaje al Operador")
    '    Exit Sub
    'End Sub

    'Public Sub miOcx_EventoErrorMecanico() Handles miOCX.ErrorImpresora
    '    miOCX.TratarDeCancelarTodo()
    '    MsgBox("Error en la impresora. Mecanico", MsgBoxStyle.Information, "Mensaje al Operador")
    '    Exit Sub
    'End Sub

    Function ImprimirTicketFiscal(ByVal grilla As DataGridView, ByVal lstPagos As List(Of Pagos)) As Boolean
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
                If grilla.Rows(i).Cells("PrecioUnitario").Value() > 0 Then
                    miOCX.ImprimirItem(Mid(grilla.Rows(i).Cells("DescripcionArticulo").Value(), 1, 15), grilla.Rows(i).Cells("Cantidad").Value(), grilla.Rows(i).Cells("PrecioUnitario").Value(), 21, 0)
                End If
            Next i

            For i = 0 To filas
                If grilla.Rows(i).Cells("PrecioUnitario").Value() < 0 Then
                    miOCX.DevolucionDescuento(Mid(grilla.Rows(i).Cells("DescripcionArticulo").Value(), 1, 15), grilla.Rows(i).Cells("Cantidad").Value() * grilla.Rows(i).Cells("PrecioUnitario").Value(), 21, 0, True, FiscalPrinterLib.TiposDeDescuentos.DEVOLUCION_DE_ENVASES)
                End If
            Next i

            'If MontoDesc <> 0 Then
            '    miOCX.DescuentoGeneral("Descuento", MontoDesc, True)
            'End If
            For Each pago In lstPagos
                miOCX.ImprimirPago(pago.DescripcionPago, pago.Abonado)
            Next

            'miOCX.ImprimirPago("Vuelto", Vuelto) '*** Linea que sacamos para 5 y 63 - 30/09/2010

            miOCX.CerrarComprobanteFiscal()

            If miOCX.HuboFaltaPapel Then
                Dim frm As New FormFaltaPapel
                frm.ShowDialog()
            End If

            miOCX.Finalizar()

            ImprimirTicketFiscal = True

        Catch ex As Exception
            miOCX.TratarDeCancelarTodo()
            MsgBox("Error al imprimir")
            ImprimirTicketFiscal = False
        End Try

    End Function

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
                miOCX.ImprimirItem(Mid(grilla.Rows(i).Cells("DescripcionArticulo").Value(), 1, 15), grilla.Rows(i).Cells("Cantidad").Value(), grilla.Rows(i).Cells("PrecioUnitario").Value(), 21, 0)
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

    Function ImprimirReporteZPorNumero(ByVal intNumeroZ As Integer) As Boolean
        Try

            miOCX = New FiscalPrinterLib.HASAR

            miOCX.Puerto = 1
            miOCX.Baudios = 9600
            miOCX.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
            miOCX.Comenzar()
            miOCX.TratarDeCancelarTodo()
            'miOCX.ReporteZIndividualPorNumero(intNumeroZ)
            miOCX.ReporteZPorNumeros(intNumeroZ, intNumeroZ, True)
            miOCX.Finalizar()

            ImprimirReporteZPorNumero = True
        Catch ex As Exception
            ImprimirReporteZPorNumero = False
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

    'Function faltaPapel() As Boolean

    '    If miOCX.HuboFaltaPapel Then

    '    End If
    '    Return True
    'End Function

End Module
