Imports System.IO

Public Class FormCierreCaja

    Dim lstCajaDaria As New List(Of CajaDiaria)
    Dim lstComprobanteVenta As New List(Of ComprobanteVenta)
    Dim lstFormasPago As New List(Of FormasPago)
    Dim lstComprobantePago As New List(Of Pagos)
    Dim dblTotalFacturado As Double

    Private Sub FormCierreCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim row As DataGridViewRow

        Me.dgvRendicion.Rows.Clear()

        lblUsuario.Text = NomUsuario
        lblIdUsuario.Text = CInt(idUsuario)

        lstCajaDaria = ObtenerCajaDiaria()

        lblApertura.Text = (From Caj In lstCajaDaria
                            Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.aperturaCaja
                            Select Caj.FechaHora).First.ToString


        'lblCierre.Text = (From Caj In lstCajaDaria
        '                Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.cierreCaja
        '                Select Caj.FechaHora).First.ToString

        lblCierre.Text = Date.Now

        'row = New DataGridViewRow

        'row.CreateCells(dgvRendicion)

        'row.Cells(0).Value = "Ingreso Dinero"

        'row.Cells(4).Value = Aggregate Caj In lstCajaDaria
        '                         Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.ingresoDinero
        '                         Into Count(Caj.Importe)

        lblIngreso.Text = Aggregate Caj In lstCajaDaria
                         Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.ingresoDinero And Caj.NroCaja = NroCajaAbierta
                         Into Sum(Caj.Importe)

        'row.Cells(5).Value = CajaDiaria.tiposOperacion.ingresoDinero

        'row.Cells(3).Value = 0

        'row.Cells(2).Value = 0

        'dgvRendicion.Rows.Add(row)

        'row = New DataGridViewRow

        'row.CreateCells(dgvRendicion)

        'row.Cells(0).Value = "Retiros Dinero"

        'row.Cells(4).Value = Aggregate Caj In lstCajaDaria
        '                        Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.retiroDinero
        '                        Into Count(Caj.Importe)

        lblRetiro.Text = Aggregate Caj In lstCajaDaria
                                 Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.retiroDinero And Caj.NroCaja = NroCajaAbierta
                                 Into Sum(Caj.Importe)

        'row.Cells(5).Value = CajaDiaria.tiposOperacion.retiroDinero

        'row.Cells(3).Value = 0

        'row.Cells(2).Value = 0

        'dgvRendicion.Rows.Add(row)

        lstFormasPago = ObtenerFormasPago()

        lstComprobanteVenta = ObtenerComprobanteVenta()

        lstComprobantePago = ObtenerPagos()

        dblTotalFacturado = 0

        For Each formPago In lstFormasPago

            row = New DataGridViewRow

            row.CreateCells(dgvRendicion)

            row.Cells(0).Value = formPago.Descripcion

            row.Cells(1).Value = Aggregate vent In lstComprobanteVenta
                                 Join p In lstComprobantePago On vent.Comprobante Equals p.Comprobante
                                Where vent.IdUsuario = idUsuario And vent.FechaEmision.Date = Now.Date And p.IdPago = formPago.IdFormaPago
                                Into Sum(p.Monto)

            dblTotalFacturado = CDbl(dblTotalFacturado + row.Cells(1).Value)

            row.Cells(4).Value = Aggregate vent In lstComprobanteVenta
                                  Join p In lstComprobantePago On vent.Comprobante Equals p.Comprobante
                                       Where vent.IdUsuario = idUsuario And vent.FechaEmision.Date = Now.Date And p.IdPago = formPago.IdFormaPago
                                       Into Count(p.Monto)

            row.Cells(5).Value = formPago.IdFormaPago

            row.Cells(3).Value = 0

            row.Cells(2).Value = 0

            dgvRendicion.Rows.Add(row)

        Next

        lblIngreso.Text = FormatNumber(lblIngreso.Text, 2)
        lblRetiro.Text = FormatNumber(lblRetiro.Text, 2)

        dgvRendicion.Columns(0).ReadOnly = True
        dgvRendicion.Columns(1).ReadOnly = True
        dgvRendicion.Columns(1).DefaultCellStyle.Format = "N2"
        dgvRendicion.Columns(3).ReadOnly = True
        dgvRendicion.Columns(3).DefaultCellStyle.Format = "N2"
        dgvRendicion.Columns(4).ReadOnly = True

        dgvRendicion.Columns(2).DefaultCellStyle.Format = "N2"

        lblDiferencia.Text = 0

        acomodarDiferencias()

    End Sub

    Private Sub acomodarDiferencias()

        For Each row As DataGridViewRow In dgvRendicion.Rows
            row.Cells(3).Value = row.Cells(2).Value - row.Cells(1).Value
            row.Cells(3).Value = FormatNumber(row.Cells(3).Value, 2)
            'ActualizarDiferencia()
        Next
        ActualizarDiferencia()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            If MsgBox("Esta seguro de grabar la rendicion?", MsgBoxStyle.YesNo, "Rendicion") = MsgBoxResult.Yes Then

                Dim objStreamWriter As StreamWriter
                Dim strLine As String

                grabarCierreCaja()

                objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "Rendicion.txt", True, System.Text.ASCIIEncoding.ASCII)

                For Each row As DataGridViewRow In dgvRendicion.Rows
                    strLine = NroCajaAbierta & ";" & Now.Date & ";" & lblIdUsuario.Text & ";" & My.Settings.sucursal & ";" & My.Settings.puestoVenta & ";" & _
                        row.Cells("descripcion").Value & ";" & row.Cells("totalFacturado").Value & ";" & _
                        row.Cells("rendicion").Value & ";" & row.Cells("diferencia").Value & ";" & row.Cells("cantComprobantes").Value & ";" & _
                        row.Cells("tpoOperacion").Value

                    objStreamWriter.WriteLine(strLine)

                Next

                objStreamWriter.Close()

                agregarNroCaja()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                ' Me.Dispose()
                Me.Close()
            End If

        Catch ex As Exception
            MsgBox("Error CC10 - Por favor informe este error a servicio tecnico.", MsgBoxStyle.Critical, "Mensaje al Operador")
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
        End Try

    End Sub

    Private Sub dgvRendicion_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRendicion.CellEndEdit
        dgvRendicion.Rows(e.RowIndex).Cells(3).Value = dgvRendicion.Rows(e.RowIndex).Cells(2).Value - dgvRendicion.Rows(e.RowIndex).Cells(1).Value
        dgvRendicion.Rows(e.RowIndex).Cells(3).Value = FormatNumber(dgvRendicion.Rows(e.RowIndex).Cells(3).Value, 2)
        ActualizarDiferencia()
    End Sub

    Private Sub dgvRendicion_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRendicion.CellValidated
        Try
            If IsNothing(dgvRendicion.Rows(e.RowIndex).Cells(2).Value) Then
                dgvRendicion.Rows(e.RowIndex).Cells(2).Value = 0
            End If
            dgvRendicion.Rows(e.RowIndex).Cells(2).Value = FormatNumber(Replace(dgvRendicion.Rows(e.RowIndex).Cells(2).Value, ".", ","), 2)
        Catch ex As Exception
            dgvRendicion.Rows(e.RowIndex).Cells(2).Value = 0
        End Try
    End Sub

    Private Sub ActualizarDiferencia()
        Dim dblTotalRendido As Double

        dblTotalRendido = 0

        For Each row As DataGridViewRow In dgvRendicion.Rows
            dblTotalRendido = dblTotalRendido + CDbl(row.Cells(2).Value)
        Next
        lblDiferencia.Text = FormatNumber(lblIngreso.Text - lblRetiro.Text + dblTotalFacturado - dblTotalrendido, 2)
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        If MsgBox("Esta seguro de cancelar la rendición?.", MsgBoxStyle.YesNo, "Mensaje al Operador") = MsgBoxResult.Yes Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            ' Me.Dispose()
            Me.Close()
        End If
    End Sub
End Class