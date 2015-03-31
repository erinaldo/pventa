Imports System.IO

Public Class FormCierreCaja

    Dim lstCajaDaria As New List(Of CajaDiaria)
    Dim lstComprobanteVenta As New List(Of ComprobanteVenta)
    Dim lstFormasPago As New List(Of FormasPago)

    Private Sub FormCierreCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim row As DataGridViewRow

        Me.dgvRendicion.Rows.Clear()

        lblUsuario.Text = NomUsuario
        lblIdUsuario.Text = CInt(idUsuario)

        lstCajaDaria = ObtenerCajaDiaria()

        lblApertura.Text = (From Caj In lstCajaDaria
                            Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.aperturaCaja
                            Select Caj.FechaHora).First.ToString


        lblCierre.Text = (From Caj In lstCajaDaria
                        Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.cierreCaja
                        Select Caj.FechaHora).First.ToString


        row = New DataGridViewRow

        row.CreateCells(dgvRendicion)

        row.Cells(0).Value = "Ingreso Dinero"

        row.Cells(4).Value = Aggregate Caj In lstCajaDaria
                                 Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.ingresoDinero
                                 Into Count(Caj.Importe)

        row.Cells(1).Value = Aggregate Caj In lstCajaDaria
                         Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.ingresoDinero
                         Into Sum(Caj.Importe)

        row.Cells(5).Value = CajaDiaria.tiposOperacion.ingresoDinero

        dgvRendicion.Rows.Add(row)

        row = New DataGridViewRow

        row.CreateCells(dgvRendicion)

        row.Cells(0).Value = "Retiros Dinero"

        row.Cells(4).Value = Aggregate Caj In lstCajaDaria
                                Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.retiroDinero
                                Into Count(Caj.Importe)

        row.Cells(1).Value = Aggregate Caj In lstCajaDaria
                                 Where Caj.Usuario = idUsuario And Caj.FechaHora.Date = Now.Date And Caj.Operacion = CajaDiaria.tiposOperacion.retiroDinero
                                 Into Sum(Caj.Importe)

        row.Cells(5).Value = CajaDiaria.tiposOperacion.retiroDinero

        dgvRendicion.Rows.Add(row)

        lstFormasPago = ObtenerFormasPago()

        lstComprobanteVenta = ObtenerComprobanteVenta()

        For Each formPago In lstFormasPago

            row = New DataGridViewRow

            row.CreateCells(dgvRendicion)

            row.Cells(0).Value = formPago.Descripcion

            row.Cells(1).Value = Aggregate vent In lstComprobanteVenta
                                        Where vent.IdUsuario = idUsuario And vent.IdFormaPago = formPago.IdFormaPago And vent.FechaEmision = Now.Date
                                        Into Sum(vent.TotalComprobante)

            row.Cells(4).Value = Aggregate vent In lstComprobanteVenta
                                       Where vent.IdUsuario = idUsuario And vent.IdFormaPago = formPago.IdFormaPago And vent.FechaEmision = Now.Date
                                       Into Count(vent.TotalComprobante)

            row.Cells(5).Value = formPago.IdFormaPago

            dgvRendicion.Rows.Add(row)

        Next

        dgvRendicion.Columns(0).ReadOnly = True
        dgvRendicion.Columns(1).ReadOnly = True
        dgvRendicion.Columns(3).ReadOnly = True
        dgvRendicion.Columns(4).ReadOnly = True

        lblDiferencia.Text = 0

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try


            If MsgBox("Esta seguro de grabar la rendicion?", MsgBoxStyle.YesNo, "Rendicion") = MsgBoxResult.Yes Then

                Dim objStreamWriter As StreamWriter
                Dim strLine As String

                objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "Rendicion.txt", True, System.Text.ASCIIEncoding.ASCII)

                For Each row As DataGridViewRow In dgvRendicion.Rows
                    strLine = Now.Date & ";" & lblIdUsuario.Text & ";" & row.Cells("descripcion").Value & ";" & row.Cells("totalFacturado").Value & ";" & _
                        CDbl(row.Cells("rendicion").Value) & ";" & CDbl(row.Cells("diferencia").Value) & ";" & row.Cells("cantComprobantes").Value & ";" & _
                        row.Cells("tpoOperacion").Value

                    objStreamWriter.WriteLine(strLine)

                Next
                objStreamWriter.Close()

                Me.Close()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvRendicion_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRendicion.CellEndEdit
        dgvRendicion.Rows(e.RowIndex).Cells(3).Value = dgvRendicion.Rows(e.RowIndex).Cells(2).Value - dgvRendicion.Rows(e.RowIndex).Cells(1).Value
        dgvRendicion.Rows(e.RowIndex).Cells(3).Value = FormatNumber(dgvRendicion.Rows(e.RowIndex).Cells(3).Value, 2)
        ActualizarDiferencia()
    End Sub

    Private Sub dgvRendicion_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRendicion.CellValidated
        Try
            dgvRendicion.Rows(e.RowIndex).Cells(2).Value = FormatNumber(Replace(dgvRendicion.Rows(e.RowIndex).Cells(2).Value, ".", ","), 2)
        Catch ex As Exception
            dgvRendicion.Rows(e.RowIndex).Cells(2).Value = 0
        End Try
    End Sub

    Private Sub ActualizarDiferencia()
        lblDiferencia.Text = 0
        For Each row As DataGridViewRow In dgvRendicion.Rows
            lblDiferencia.Text = lblDiferencia.Text + CDbl(row.Cells(3).Value)
        Next
        lblDiferencia.Text = FormatNumber(lblDiferencia.Text, 2)
    End Sub

End Class