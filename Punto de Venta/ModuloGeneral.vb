﻿Imports System.IO

Module ModuloGeneral


    Public Vuelto As Double
    Public Paga As Double
    Public AceptaPago As Boolean
    Public Descuento As Double
    Public TotalDto As Double
    Public MontoDesc As Double
    Public IdFormaPago As Integer
    Public Origen As String
    Public CodartBuscado As Integer
    Public CodigoBarrasBuscado As String
    Public dblcantidad As Double
    Public TotalPcompra As Double

    Public Sub InsertarFilasEnGrilla(codart As String, descri As String, precio As Double, _
                                           cantidad As Double, total As Double, codbarra As String, costo As Double, _
                                           ByVal grilla As DataGridView)
        Dim i As Integer
        Dim dt As New DataGridViewRow

        i = grilla.Rows.Count - 1
        dt.CreateCells(grilla)
        dt.Cells(0).Value = codart
        dt.Cells(1).Value = descri
        dt.Cells(2).Value = precio
        dt.Cells(3).Value = cantidad
        dt.Cells(4).Value = total
        dt.Cells(5).Value = codbarra
        dt.Cells(6).Value = costo
        grilla.Rows.Insert(i, dt)

    End Sub

    Public Function ConvertirPrecio(PrecioAux As String) As Double
        Dim decimales As Double
        Dim ParteEntera As Double

        decimales = Val(Mid(PrecioAux, Len(PrecioAux) - 1, Len(PrecioAux)))
        ParteEntera = Val(Mid(PrecioAux, 1, 3))

        decimales = decimales / 100

        ConvertirPrecio = ParteEntera + decimales

    End Function

    Public Function MsgAtencion(strMensaje As String) As MsgBoxStyle
        MsgAtencion = MsgBox(strMensaje, vbCritical + vbOKOnly, "Aviso al operador")
    End Function

    Public Function MsgInformacion(strMensaje As String) As MsgBoxStyle
        MsgInformacion = MsgBox(strMensaje, vbInformation + vbOKOnly, "Aviso al operador")
    End Function

    Public Function MsgPregunta(strMensaje As String) As MsgBoxStyle
        MsgPregunta = MsgBox(strMensaje, vbQuestion + vbYesNoCancel, "Aviso al operador")
    End Function

    Public Function ObtenerClientes() As List(Of Clientes)
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            ObtenerClientes = New List(Of Clientes)

            objStreamReader = New StreamReader("C:\Clientes.txt")

            Do While Not objStreamReader.EndOfStream
                Dim cli As New Clientes

                strLine = objStreamReader.ReadLine
                cli.IdCliente = Split(strLine, ";")(0)
                cli.NombreFantasia = Split(strLine, ";")(1)
                cli.IdLista = Split(strLine, ";")(2)
                cli.ListaDescripcion = Split(strLine, ";")(3)
                cli.IdSucursal = Split(strLine, ";")(4)
                

                ObtenerClientes.Add(cli)

            Loop


        Catch ex As Exception
            Throw New Exception("Error en WFL" + "Obtener Lista" + "|" + ex.Message)
        End Try
    End Function

    Public Sub ImprimirTicketFiscal()
        'FormEmiteFac.HASAR1.Puerto = 1
        'FormEmiteFac.HASAR1.Comenzar()
        'FormEmiteFac.HASAR1.AbrirComprobanteFiscal TICKET_C

        'filas = FormEmiteFac.GrillaArticulos.Rows - 2

        'For i = 1 To filas
        '    idrubro = BuscarRubro(FormEmiteFac.GrillaArticulos.TextMatrix(i, 2))
        '    FormEmiteFac.HASAR1.ImprimirItem(Mid(FormEmiteFac.GrillaArticulos.TextMatrix(i, 3), 1, 15), FormEmiteFac.GrillaArticulos.TextMatrix(i, 5), FormEmiteFac.GrillaArticulos.TextMatrix(i, 4), 0, 0)

        'Next i
        'If MontoDesc <> 0 Then
        '    FormEmiteFac.HASAR1.DescuentoGeneral("Descuento", MontoDesc, True)
        'End If
        'FormEmiteFac.HASAR1.ImprimirPago("Pago con", Paga)
        ''FormEmiteFac.HASAR1.ImprimirPago "Vuelto", Vuelto *** Linea que sacamos para 5 y 63 - 30/09/2010

        'FormEmiteFac.HASAR1.CerrarComprobanteFiscal()
        'FormEmiteFac.HASAR1.Finalizar()
    End Sub

End Module
