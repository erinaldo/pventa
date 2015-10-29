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

    Function ImprimirTicketFiscalC(ByVal grilla As DataGridView, ByVal lstPagos As List(Of Pagos)) As Boolean
        miOCX = New FiscalPrinterLib.HASAR

        Try
            miOCX.Puerto = My.Settings.puertoFiscal
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

            ImprimirTicketFiscalC = True

        Catch ex As Exception
            miOCX.TratarDeCancelarTodo()
            MsgBox("Error al imprimir TICKET C" & " - " & ex.Message)
            ImprimirTicketFiscalC = False
        End Try

    End Function

    Function ImprimirTicketFiscalB(ByVal cliente As Clientes, ByVal grilla As DataGridView, ByVal lstPagos As List(Of Pagos)) As Boolean
        miOCX = New FiscalPrinterLib.HASAR

        Try
            miOCX.Puerto = My.Settings.puertoFiscal
            miOCX.Baudios = 9600
            miOCX.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
            miOCX.Comenzar()
            miOCX.TratarDeCancelarTodo()
            miOCX.DatosCliente(cliente.NombreFantasia, cliente.NroDocumento, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.MONOTRIBUTO, cliente.Domicilio)
            miOCX.AbrirComprobanteFiscal(FiscalPrinterLib.DocumentosFiscales.TICKET_FACTURA_B)

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

            ImprimirTicketFiscalB = True

        Catch ex As Exception
            miOCX.TratarDeCancelarTodo()
            MsgBox("Error al imprimir TICKET B" & " - " & ex.Message)
            ImprimirTicketFiscalB = False
        End Try

    End Function

    Function ImprimirTicketFiscalA(ByVal cliente As Clientes, ByVal grilla As DataGridView, ByVal lstPagos As List(Of Pagos)) As Boolean
        miOCX = New FiscalPrinterLib.HASAR

        Try
            miOCX.Puerto = My.Settings.puertoFiscal
            miOCX.Baudios = 9600
            miOCX.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
            miOCX.Comenzar()
            miOCX.TratarDeCancelarTodo()
            miOCX.DatosCliente(cliente.NombreFantasia, cliente.NroDocumento, FiscalPrinterLib.TiposDeDocumento.TIPO_CUIT, FiscalPrinterLib.TiposDeResponsabilidades.RESPONSABLE_INSCRIPTO, cliente.Domicilio)
            miOCX.AbrirComprobanteFiscal(FiscalPrinterLib.DocumentosFiscales.TICKET_FACTURA_A)

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

            ImprimirTicketFiscalA = True

        Catch ex As Exception
            miOCX.TratarDeCancelarTodo()
            MsgBox("Error al imprimir TICKET A" & " - " & ex.Message)
            ImprimirTicketFiscalA = False
        End Try

    End Function

    Function ImprimirReporteZ() As Boolean
        Try

            miOCX = New FiscalPrinterLib.HASAR

            miOCX.Puerto = My.Settings.puertoFiscal
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

            miOCX.Puerto = My.Settings.puertoFiscal
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

            miOCX.Puerto = My.Settings.puertoFiscal
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

    Function obtenerNroComprobanteFiscalBC() As Integer
        Try

            miOCX = New FiscalPrinterLib.HASAR

            miOCX.Puerto = My.Settings.puertoFiscal
            miOCX.Baudios = 9600
            miOCX.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
            miOCX.Comenzar()
            obtenerNroComprobanteFiscalBC = miOCX.UltimoDocumentoFiscalBC()
            miOCX.Finalizar()

        Catch ex As Exception
            obtenerNroComprobanteFiscalBC = -1
        End Try
    End Function

    Function obtenerNroComprobanteFiscalA() As Integer
        Try

            miOCX = New FiscalPrinterLib.HASAR

            miOCX.Puerto = My.Settings.puertoFiscal
            miOCX.Baudios = 9600
            miOCX.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_715
            miOCX.Comenzar()
            obtenerNroComprobanteFiscalA = miOCX.UltimoDocumentoFiscalA()
            miOCX.Finalizar()

        Catch ex As Exception
            obtenerNroComprobanteFiscalA = -1
        End Try
    End Function
    'Function faltaPapel() As Boolean

    '    If miOCX.HuboFaltaPapel Then

    '    End If
    '    Return True
    'End Function

End Module
