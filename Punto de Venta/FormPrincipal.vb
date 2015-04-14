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

        listaCajaDia = ObtenerCajaDiaria()

        Dim caja As List(Of CajaDiaria) = (From caj In listaCajaDia
                                  Where caj.Usuario = idUsuario And caj.FechaHora.Date = Now.Date
                                  Select caj).ToList

        If caja.Count = 0 Then
            btnFacturacion.Enabled = False
            btnCerrarCaja.Enabled = False
            btnIngresoDinero.Enabled = False
            btnRetiroDinero.Enabled = False
            btnAbrirCaja.Enabled = True
        Else
            Dim intCaja As Integer = (From c In caja
                                        Where c.Operacion = CajaDiaria.tiposOperacion.cierreCaja
                                        Select c).Count

            If intCaja = 0 Then
                btnFacturacion.Enabled = True
                btnCerrarCaja.Enabled = True
                btnIngresoDinero.Enabled = True
                btnRetiroDinero.Enabled = True
                btnAbrirCaja.Enabled = False
            Else
                MsgBox("El usuario no puede volver a abrir una caja en el dia de hoy", MsgBoxStyle.Information, "Caja Cerrada")
                btnFacturacion.Enabled = False
                btnCerrarCaja.Enabled = False
                btnIngresoDinero.Enabled = False
                btnRetiroDinero.Enabled = False
                btnAbrirCaja.Enabled = False
                Exit Sub
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

        grabarIngresoDinero(CDbl(InputBox("Ingrese el importe.", "Ingreso de Dinero")))

    End Sub

    Private Sub btnRetiroDinero_Click(sender As Object, e As EventArgs) Handles btnRetiroDinero.Click

        Dim dblRetiro As String

        Try
            FormSupervisor.ShowDialog()
            If blnEsSupervisor Then
                dblRetiro = InputBox("Ingrese el importe.", "Retiro de Dinero")
                If CDbl(dblRetiro) <> 0 Then
                    grabarRetiroDinero(CDbl(dblRetiro))
                End If
            End If
        Catch ex As Exception
            MsgBox("Debe ingresar un monto válido", MsgBoxStyle.Information, "Mensaje al Operador")
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub
End Class