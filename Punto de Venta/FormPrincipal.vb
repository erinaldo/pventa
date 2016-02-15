Imports System.IO
Imports System.Configuration

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
        If System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width >= 1024 Then
            Dim frm As New FormEmiteFac1024
            frm.ShowDialog()
        Else
            Dim frm As New FormEmiteFac
            frm.ShowDialog()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Esta seguro de imprimir el Reporte X?", MsgBoxStyle.YesNo, "Reporte X") = MsgBoxResult.Yes Then
            ImprimirReporteX()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnCerrarCaja.Click


        Dim listComprobanteVenta As New List(Of ComprobanteVenta)
        Dim listComprobanteVentaDetalle As New List(Of ComprobanteVentaDetalle)
        Dim listCajaDiaria As New List(Of CajaDiaria)
        Dim listRendicion As New List(Of Rendicion)
        Dim listPagos As New List(Of Pagos)
        Dim listComprobanteCancelado As New List(Of ComprobanteCancelado)

        If File.Exists(My.Settings.rutaArchivos & "ComprobanteVentaEnEspera.txt") Then
            MsgBox("Posee un ticket en espera. No puede cerrar caja.", MsgBoxStyle.Information, "Mensaje al Operador")
            Exit Sub
        End If

        If MsgBox("Esta seguro que desea hacer el cierre de caja?", MsgBoxStyle.YesNo, "Cierre de Caja") = MsgBoxResult.No Then
            Exit Sub
        End If

        If Not existeArchivo("CajaDiaria.txt") Then
            MsgBox("No existe ninguna caja para enviar. No se puede continuar.", MsgBoxStyle.Information, "Mensaje al Operador")
            Exit Sub
        End If

        If Not existeArchivo("ComprobanteVenta.txt") Then
            MsgBox("No existen ventas para enviar. No se puede continuar.", MsgBoxStyle.Information, "Mensaje al Operador")
            Exit Sub
        End If

        If Not existeArchivo("ComprobanteVentaDetalle.txt") Then
            MsgBox("No existen detalle de ventas para enviar. No se puede continuar.", MsgBoxStyle.Information, "Mensaje al Operador")
            Exit Sub
        End If

        'grabarCierreCaja()

        FormCierreCaja.ShowDialog()

        If FormCierreCaja.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Exit Sub
        End If

        listComprobanteVenta = ObtenerComprobanteVenta()
        listComprobanteVentaDetalle = ObtenerComprobanteVentaDetalle()
        listCajaDiaria = ObtenerCajaDiaria()
        listRendicion = ObtenerRendicion()
        listPagos = ObtenerPagos()

        If ActualizarComprobanteVenta(listComprobanteVenta) Then
            My.Computer.FileSystem.DeleteFile(My.Settings.rutaArchivos & "ComprobanteVenta.txt")
        End If
        If ActualizarComprobanteVentaDetalle(listComprobanteVentaDetalle) Then
            My.Computer.FileSystem.DeleteFile(My.Settings.rutaArchivos & "ComprobanteVentaDetalle.txt")
        End If
        If ActualizarCajaDiaria(listCajaDiaria) Then
            My.Computer.FileSystem.DeleteFile(My.Settings.rutaArchivos & "CajaDiaria.txt")
        End If
        If ActualizarRendicion(listRendicion) Then
            My.Computer.FileSystem.DeleteFile(My.Settings.rutaArchivos & "Rendicion.txt")
        End If
        If ActualizarPagos(listPagos) Then
            My.Computer.FileSystem.DeleteFile(My.Settings.rutaArchivos & "Pagos.txt")
        End If
        If existeArchivo("ComprobanteVentaCanc.txt") Then
            listComprobanteCancelado = ObtenerComprobanteCancelado()
            If ActualizarComprobanteCancelado(listComprobanteCancelado) Then
                My.Computer.FileSystem.DeleteFile(My.Settings.rutaArchivos & "ComprobanteVentaCanc.txt")
            End If
        End If


        btnFacturacion.Enabled = False
        btnCerrarCaja.Enabled = False
        btnIngresoDinero.Enabled = False
        btnRetiroDinero.Enabled = False
        btnAbrirCaja.Enabled = False

    End Sub

    Private Sub FormPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        blnEsSupervisor = False

        'If Not ControlarCierreRealizado() Then
        'MsgBox("No se ha realizado el cierre anterior. P
        'End If

        NroCajaAbierta = obtenerNroCaja()

        listaCajaDia = ObtenerCajaDiaria()

        'Dim caja As List(Of CajaDiaria) = (From caj In listaCajaDia
        '                          Where caj.Usuario = idUsuario And caj.FechaHora.Date = Now.Date
        '                          Select caj).ToList

        Dim caja As List(Of CajaDiaria) = (From caj In listaCajaDia
                                           Where caj.NroCaja = NroCajaAbierta
                                           Select caj).ToList

        If caja.Count = 0 Then
            btnFacturacion.Enabled = False
            btnCerrarCaja.Enabled = False
            btnIngresoDinero.Enabled = False
            btnRetiroDinero.Enabled = False
            btnAbrirCaja.Enabled = True
        Else

            Dim CajaDia As CajaDiaria = (From c In caja
                                         Where c.Usuario = idUsuario And c.FechaHora.Date = Now.Date And c.Operacion = CajaDiaria.tiposOperacion.aperturaCaja
                                         Select c).FirstOrDefault

            If CajaDia Is Nothing Then

                Dim CajaAnterior As CajaDiaria = (From c In caja
                                                  Where c.Operacion = CajaDiaria.tiposOperacion.aperturaCaja
                                                  Select c).FirstOrDefault

                grabarCierreCaja(CajaAnterior.FechaHora.Date & " 23:59:00", CajaAnterior.Usuario)

                agregarNroCaja()

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

        Dim dblIngreso As String

        Try

            dblIngreso = InputBox("Ingrese el importe.", "Ingreso de Dinero")
            dblIngreso = Replace(dblIngreso, ".", ",")
            If CDbl(dblIngreso) <> 0 Then
                If MsgBox("Es correcto el Ingreso de dinero por: $" & FormatNumber(dblIngreso, 2), MsgBoxStyle.YesNo, "Mensaje al Operador") = MsgBoxResult.Yes Then
                    grabarIngresoDinero(CDbl(dblIngreso))
                End If
            End If

        Catch ex As Exception
            MsgBox("Debe ingresar un monto válido", MsgBoxStyle.Information, "Mensaje al Operador")
        End Try

    End Sub

    Private Sub btnRetiroDinero_Click(sender As Object, e As EventArgs) Handles btnRetiroDinero.Click

        Dim dblRetiro As String

        Try
            FormSupervisor.ShowDialog()
            If blnEsSupervisor Then
                dblRetiro = InputBox("Ingrese el importe.", "Retiro de Dinero")
                dblRetiro = Replace(dblRetiro, ".", ",")
                If CDbl(dblRetiro) <> 0 Then
                    If MsgBox("Es correcto el RETIRO de dinero por: $" & FormatNumber(dblRetiro, 2), MsgBoxStyle.YesNo, "Mensaje al Operador") = MsgBoxResult.Yes Then
                        grabarRetiroDinero(CDbl(dblRetiro))
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Debe ingresar un monto válido", MsgBoxStyle.Information, "Mensaje al Operador")
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim intNumeroZ As Integer

        Try
            FormSupervisor.ShowDialog()
            If blnEsSupervisor Then
                intNumeroZ = InputBox("Ingrese el Número de Z, que desea imprimir.", "Impresión de Z por Número")
                If intNumeroZ <> 0 Then

                    If ImprimirReporteZPorNumero(intNumeroZ) Then
                        MsgBox("Se imprimio correctamente", MsgBoxStyle.Information, "Mensaje al Operador")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Debe ingresar un número válido", MsgBoxStyle.Information, "Mensaje al Operador")
        End Try
    End Sub

End Class