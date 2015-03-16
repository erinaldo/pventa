Public Class FormCierreCaja

    Dim lstCajaDaria As New List(Of CajaDiaria)
    Dim lstComprobanteVenta As New List(Of ComprobanteVenta)

    Private Sub FormCierreCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lstCajaDaria = ObtenerCajaDiaria()

        lblApertura.Text = (From Caj In lstCajaDaria
                                         Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.aperturaCaja
                                         Select Caj.FechaHora).First.ToString

        lblIngresoDinero.Text = Aggregate Caj In lstCajaDaria
                                 Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.ingresoDinero
                                 Into Sum(Caj.Importe)

        lblRetiroDinero.Text = Aggregate Caj In lstCajaDaria
                                 Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.retiroDinero
                                 Into Sum(Caj.Importe)

        lblCierre.Text = (From Caj In lstCajaDaria
                                 Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.cierreCaja
                                 Select Caj.FechaHora).First.ToString

        lblComprobantesIngresoDinero.Text = Aggregate Caj In lstCajaDaria
                                 Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.ingresoDinero
                                 Into Count(Caj.Importe)

        lblComprobantesRetiroDinero.Text = Aggregate Caj In lstCajaDaria
                                            Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.retiroDinero
                                            Into Count(Caj.Importe)

        lstComprobanteVenta = ObtenerComprobanteVenta()

        lblEfectivo.Text = Aggregate vent In lstComprobanteVenta
                            Where vent.IdUsuario = idUsuario And vent.IdFormaPago = ComprobanteVenta.FormasPago.Efectivo
                            Into Sum(vent.TotalComprobante)

        lblCheques.Text = Aggregate vent In lstComprobanteVenta
                            Where vent.IdUsuario = idUsuario And vent.IdFormaPago = ComprobanteVenta.FormasPago.Cheque
                            Into Sum(vent.TotalComprobante)

        lblTarjetasDebito.Text = Aggregate vent In lstComprobanteVenta
                            Where vent.IdUsuario = idUsuario And vent.IdFormaPago = ComprobanteVenta.FormasPago.TarjetaDebito
                            Into Sum(vent.TotalComprobante)

        lblTarjetasCredito.Text = Aggregate vent In lstComprobanteVenta
                            Where vent.IdUsuario = idUsuario And vent.IdFormaPago = ComprobanteVenta.FormasPago.TarjetaCredito
                            Into Sum(vent.TotalComprobante)

        lblComprobantesEfectivo.Text = Aggregate vent In lstComprobanteVenta
                                       Where vent.IdUsuario = idUsuario And vent.IdFormaPago = ComprobanteVenta.FormasPago.Efectivo
                                       Into Count(vent.TotalComprobante)

        lblComprobantesTarjetasDebito.Text = Aggregate vent In lstComprobanteVenta
                                       Where vent.IdUsuario = idUsuario And vent.IdFormaPago = ComprobanteVenta.FormasPago.TarjetaDebito
                                       Into Count(vent.TotalComprobante)

        lblComprobantesTarjetasCredito.Text = Aggregate vent In lstComprobanteVenta
                                       Where vent.IdUsuario = idUsuario And vent.IdFormaPago = ComprobanteVenta.FormasPago.TarjetaCredito
                                       Into Count(vent.TotalComprobante)

        lblComprobantesCheques.Text = Aggregate vent In lstComprobanteVenta
                                       Where vent.IdUsuario = idUsuario And vent.IdFormaPago = ComprobanteVenta.FormasPago.Cheque
                                       Into Count(vent.TotalComprobante)


        lblTotal.Text = FormatNumber(CDbl(lblIngresoDinero.Text) - CDbl(lblRetiroDinero.Text) + CDbl(lblEfectivo.Text) + CDbl(lblTarjetasDebito.Text) + CDbl(lblTarjetasCredito.Text) + CDbl(lblCheques.Text), 2)

    End Sub

    Public Sub ActualizarDiferencia()

        lblTotal.Text = FormatNumber(CDbl(lblIngresoDinero.Text) - CDbl(lblRetiroDinero.Text) + CDbl(lblEfectivo.Text) + CDbl(lblTarjetasDebito.Text) + CDbl(lblTarjetasCredito.Text) + CDbl(lblCheques.Text), 2)
        txtTotal.Text = FormatNumber(CDbl(txtIngresoDinero.Text) - CDbl(txtRetiroDinero.Text) + CDbl(txtEfectivo.Text) + CDbl(txtTarjetasDebito.Text) + CDbl(txtTarjetasCredito.Text) + CDbl(txtCheques.Text), 2)
        lblDiferenciaTotal.Text = FormatNumber(CDbl(lblDiferenciaIngresoDinero.Text) + CDbl(lblDiferenciaRetiroDinero.Text) + CDbl(lblDiferenciaEfectivo.Text) + CDbl(lblDiferenciaTarjetasDebito.Text) + CDbl(lblDiferenciaTarjetasCredito.Text) + CDbl(lblDiferenciaCheques.Text), 2)
        lblComprobantesTotal.Text = FormatNumber(CDbl(lblComprobantesIngresoDinero.Text) + CDbl(lblComprobantesRetiroDinero.Text) + CDbl(lblComprobantesEfectivo.Text) + CDbl(lblComprobantesTarjetasDebito.Text) + CDbl(lblComprobantesTarjetasCredito.Text) + CDbl(lblComprobantesCheques.Text), 2)

    End Sub

    Private Sub txtIngresoDinero_Validated(sender As Object, e As EventArgs) Handles txtIngresoDinero.Validated
        lblDiferenciaIngresoDinero.Text = FormatNumber(CDbl(txtIngresoDinero.Text) - CDbl(lblIngresoDinero.Text), 2)
        lblDiferenciaTotal.Text = FormatNumber(CDbl(lblTotal.Text) - CDbl(txtTotal.Text), 2)
        ActualizarDiferencia()
    End Sub

    Private Sub txtRetiroDinero_Validated(sender As Object, e As EventArgs) Handles txtRetiroDinero.Validated
        lblDiferenciaRetiroDinero.Text = FormatNumber(CDbl(txtRetiroDinero.Text) - CDbl(lblRetiroDinero.Text), 2)
        lblDiferenciaTotal.Text = FormatNumber(CDbl(lblTotal.Text) - CDbl(txtTotal.Text), 2)
        ActualizarDiferencia()
    End Sub

    Private Sub txtEfectivo_Validated(sender As Object, e As EventArgs) Handles txtEfectivo.Validated
        lblDiferenciaEfectivo.Text = FormatNumber(CDbl(txtEfectivo.Text) - CDbl(lblEfectivo.Text), 2)
        lblDiferenciaTotal.Text = FormatNumber(CDbl(lblTotal.Text) - CDbl(txtTotal.Text), 2)
        ActualizarDiferencia()
    End Sub

    Private Sub txtTarjetasDebito_Validated(sender As Object, e As EventArgs) Handles txtTarjetasDebito.Validated
        lblDiferenciaTarjetasDebito.Text = FormatNumber(CDbl(txtTarjetasDebito.Text) - CDbl(lblTarjetasDebito.Text), 2)
        lblDiferenciaTotal.Text = FormatNumber(CDbl(lblTotal.Text) - CDbl(txtTotal.Text), 2)
        ActualizarDiferencia()
    End Sub

    Private Sub txtTarjetasCredito_Validated(sender As Object, e As EventArgs) Handles txtTarjetasCredito.Validated
        lblDiferenciaTarjetasCredito.Text = FormatNumber(CDbl(txtTarjetasCredito.Text) - CDbl(lblTarjetasCredito.Text), 2)
        lblDiferenciaTotal.Text = FormatNumber(CDbl(lblTotal.Text) - CDbl(txtTotal.Text), 2)
        ActualizarDiferencia()
    End Sub

    Private Sub txtCheques_Validated(sender As Object, e As EventArgs) Handles txtCheques.Validated
        lblDiferenciaCheques.Text = FormatNumber(CDbl(txtCheques.Text) - CDbl(lblCheques.Text), 2)
        lblDiferenciaTotal.Text = FormatNumber(CDbl(lblTotal.Text) - CDbl(txtTotal.Text), 2)
        ActualizarDiferencia()
    End Sub

    Private Sub txtIngresoDinero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIngresoDinero.KeyDown
        If e.KeyCode = Keys.Return Then
            txtRetiroDinero.Focus()
        End If
    End Sub

    Private Sub txtRetiroDinero_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRetiroDinero.KeyDown
        If e.KeyCode = Keys.Return Then
            txtEfectivo.Focus()
        End If
    End Sub

    Private Sub txtEfectivo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEfectivo.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTarjetasDebito.Focus()
        End If
    End Sub

    Private Sub txtTarjetasDebito_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarjetasDebito.KeyDown
        If e.KeyCode = Keys.Return Then
            txtTarjetasCredito.Focus()
        End If
    End Sub

    Private Sub txtTarjetasCredito_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTarjetasCredito.KeyDown
        If e.KeyCode = Keys.Return Then
            txtCheques.Focus()
        End If
    End Sub

    Private Sub txtCheques_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCheques.KeyDown
        If e.KeyCode = Keys.Return Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Esta seguro de grabar la rendicion?", MsgBoxStyle.YesNo, "Rendicion") = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub
End Class