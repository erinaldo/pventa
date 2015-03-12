Imports System.IO

Public Class FormPrincipal
    Dim listaCajaDia As New List(Of CajaDiaria)


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MsgBox("Esta seguro de imprimir el Reporte Z?", MsgBoxStyle.YesNo, "Reporte Z") = MsgBoxResult.Yes Then
            ImprimirReporteZ()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnFacturacion.Click
        FormEmiteFac.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Esta seguro de imprimir el Reporte X?", MsgBoxStyle.YesNo, "Reporte X") = MsgBoxResult.Yes Then
            ImprimirReporteX()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnCerrarCaja.Click
        Dim objStreamReader As StreamReader
        Dim strLine As String
        Dim listPedidosPendientes As New List(Of ComprobanteVenta)

        If MsgBox("Esta seguro que desea hacer el cierre de caja?", MsgBoxStyle.YesNo, "Cierre de Caja") = MsgBoxResult.No Then
            Exit Sub
        End If

        grabarCierreCaja()

        objStreamReader = New StreamReader("C:\ComprobanteVenta.txt", System.Text.ASCIIEncoding.ASCII)

        Do While Not objStreamReader.EndOfStream
            Dim pedidoPendiente As New ComprobanteVenta

            strLine = objStreamReader.ReadLine

            pedidoPendiente.Comprobante = Split(strLine, ";")(0)
            pedidoPendiente.ComprobanteFiscal = Split(strLine, ";")(1)
            pedidoPendiente.ComprobanteTipo = Split(strLine, ";")(2)
            pedidoPendiente.IdCliente = Split(strLine, ";")(3)
            pedidoPendiente.FechaEmision = Split(strLine, ";")(4)
            pedidoPendiente.CondicionIva = Split(strLine, ";")(5)
            pedidoPendiente.PrecioBase = Split(strLine, ";")(6)
            pedidoPendiente.PorcentajeIva = Split(strLine, ";")(7)
            pedidoPendiente.TotalComprobante = Split(strLine, ";")(8)
            pedidoPendiente.IdUsuario = Split(strLine, ";")(9)
            pedidoPendiente.Origen = Split(strLine, ";")(10)
            pedidoPendiente.Descuento = Split(strLine, ";")(11)
            pedidoPendiente.TotalDescuento = Split(strLine, ";")(12)
            pedidoPendiente.IdFormaPago = Split(strLine, ";")(13)
            pedidoPendiente.FormaPago = Split(strLine, ";")(14)
            pedidoPendiente.CondicionVenta = Split(strLine, ";")(15)
            pedidoPendiente.Remito = Split(strLine, ";")(16)
            pedidoPendiente.Impuestos = Split(strLine, ";")(17)
            pedidoPendiente.SubtotalImpuestos = Split(strLine, ";")(18)
            pedidoPendiente.MontoIva = Split(strLine, ";")(19)
            pedidoPendiente.NroFactura = Split(strLine, ";")(20)
            pedidoPendiente.Pagada = Split(strLine, ";")(21)

            listPedidosPendientes.Add(pedidoPendiente)

        Loop

        objStreamReader.Close()

        ActualizarComprobanteVenta(listPedidosPendientes)

        btnFacturacion.Enabled = False
        btnCerrarCaja.Enabled = False
        btnIngresoDinero.Enabled = False
        btnRetiroDinero.Enabled = False
        btnAbrirCaja.Enabled = False

    End Sub

    Private Sub FormPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listaCajaDia = ObtenerCajaDiaria()

        Dim caja As List(Of CajaDiaria) = (From caj In listaCajaDia
                                  Where caj.Usuario = idUsuario
                                  Select caj).ToList

        If caja.Count = 0 Then
            btnFacturacion.Enabled = False
            btnCerrarCaja.Enabled = False
            btnIngresoDinero.Enabled = False
            btnRetiroDinero.Enabled = False
            btnAbrirCaja.Enabled = True
        Else
            btnFacturacion.Enabled = True
            btnCerrarCaja.Enabled = True
            btnIngresoDinero.Enabled = True
            btnRetiroDinero.Enabled = True
            btnAbrirCaja.Enabled = False
        End If


    End Sub

    Private Sub btnAbrirCaja_Click(sender As Object, e As EventArgs) Handles btnAbrirCaja.Click

        grabarAperturaCaja()

        btnFacturacion.Enabled = True
        btnCerrarCaja.Enabled = True
        btnIngresoDinero.Enabled = True
        btnRetiroDinero.Enabled = True
        btnAbrirCaja.Enabled = False

    End Sub

    Private Sub btnIngresoDinero_Click(sender As Object, e As EventArgs) Handles btnIngresoDinero.Click

        grabarIngresoDinero(CDbl(InputBox("Ingrese el importe.", "Ingreso de Dinero")))

    End Sub

    Private Sub btnRetiroDinero_Click(sender As Object, e As EventArgs) Handles btnRetiroDinero.Click

        grabarRetiroDinero(CDbl(InputBox("Ingrese el importe.", "Retiro de Dinero")))

    End Sub
End Class