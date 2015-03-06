Module ModuloImpresion

    Private miOCX As FiscalPrinterLib.HASAR

    Public Sub ImprimirTicketFiscal(ByVal grilla As DataGridView)
        miOCX = New FiscalPrinterLib.HASAR

        miOCX.Puerto = 2
        miOCX.Baudios = 9600
        miOCX.AutodetectarControlador(2)
        miOCX.AutodetectarModelo()
        'miOCX.Modelo = FiscalPrinterLib.ModelosDeImpresoras.MODELO_615
        miOCX.Finalizar()
        miOCX.Comenzar()
        miOCX.AbrirComprobanteFiscal(FiscalPrinterLib.DocumentosFiscales.TICKET_C)

        Dim filas As Integer = grilla.Rows.Count - 2

        For i = 1 To filas
            'idrubro = 1
            miOCX.ImprimirItem(Mid(grilla.Rows(i).Cells("descrip").Value(), 1, 15), grilla.Rows(i).Cells("cantidad").Value(), grilla.Rows(i).Cells("Total").Value(), 0, 0)

        Next i
        If MontoDesc <> 0 Then
            miOCX.DescuentoGeneral("Descuento", MontoDesc, True)
        End If
        miOCX.ImprimirPago("Pago con", Paga)
        miOCX.ImprimirPago("Vuelto", Vuelto) '*** Linea que sacamos para 5 y 63 - 30/09/2010

        miOCX.CerrarComprobanteFiscal()
        miOCX.Finalizar()
    End Sub


End Module
