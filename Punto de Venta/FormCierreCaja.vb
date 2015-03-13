Public Class FormCierreCaja

    Dim lstCajaDaria As List(Of CajaDiaria)
    Dim lstVentaDetalle As List(Of ComprobanteVentaDetalle)

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

        lstVentaDetalle = ObtenerVentaDetalle()
    End Sub
End Class