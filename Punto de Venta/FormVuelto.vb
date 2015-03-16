﻿Public Class FormVuelto
    Dim dstFormas As New DataSet
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        If MsgPregunta("¿Desea cancelar ?") = vbYes Then
            Me.Close()
        End If
    End Sub

    Public Sub Abrir(dblTotFac As Double)
        'dstFormas = pwiFacturacion.obtenerFormasPago(My.Settings.cadena)
        Cargar_Combobox(ObtenerFormasPago, Me.cmbFormas)
        Me.lblTot.Text = dblTotFac
        Me.txttotaldto.Text = dblTotFac
        Me.textdto.Text = 0
        Me.txtAbona.Text = 0
        Me.txtAbona.Focus()
        ShowDialog()

    End Sub

    Public Function Cargar_Combobox(ByVal lstFormasPago As List(Of FormasPago), ByRef cbx As Windows.Forms.ComboBox)

        cbx.DataSource = lstFormasPago
        cbx.ValueMember = "IdFormaPago"
        cbx.DisplayMember = "Descripcion"

        Return Nothing
    End Function

    Private Sub txtprecio_TextChanged(sender As Object, e As EventArgs) Handles textdto.TextChanged
        If TextDto.Text <> "" Then
            txttotaldto.Text = FormatNumber(CDbl(Me.lblTot.Text) - ((CDbl(Me.lblTot.Text) * CDbl(textdto.Text)) / 100), 2)
        Else
            txttotaldto.Text = FormatNumber(CDbl(lblTot.Text), 2)
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If CDbl(txtAbona.Text) <> 0 Then
            If CDbl(txtAbona.Text) >= CDbl(txttotaldto.Text) Then
                Vuelto = 0
                Paga = 0
                Descuento = CDbl(textdto.Text)
                TotalDto = CDbl(txttotaldto.Text)
                MontoDesc = CDbl(lblTot.Text) - CDbl(txttotaldto.Text)
                IdFormaPago = cmbFormas.SelectedValue
                FormaPago = cmbFormas.Text
                AceptaPago = True
                Paga = CDbl(txtAbona.Text)
                Me.lblVuelto.Text = 0
                Me.Close()
            Else
                Me.txtAbona.SelectAll()
            End If
        Else
            MsgAtencion("Debe ingresar algun monto de pago")
            txtAbona.Focus()
        End If
    End Sub

    Private Sub txtAbona_KeyUp(sender As Object, e As KeyEventArgs) Handles txtAbona.KeyUp
        Try
            If e.KeyCode = Keys.Return Then
                btnAceptar_Click(sender, e)
                Exit Sub
            End If

            lblVuelto.Text = CDbl(txtAbona.Text) - CDbl(txttotaldto.Text)

            If CDbl(lblVuelto.Text) < 0 Then
                lblVuelto.ForeColor = Color.Red
            Else
                lblVuelto.ForeColor = Color.Green
            End If
            lblVuelto.Text = FormatNumber(lblVuelto.Text, 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbFormas_DropDownClosed(sender As Object, e As EventArgs) Handles cmbFormas.DropDownClosed
        If cmbFormas.SelectedValue <> ComprobanteVenta.FormasPago.Efectivo Then
            txtAbona.Text = FormatNumber(CDbl(txttotaldto.Text), 2)
            lblVuelto.Text = FormatNumber(0, 2)
        Else
            txtAbona.Text = FormatNumber(0, 2)
            lblVuelto.Text = CDbl(txtAbona.Text) - CDbl(txttotaldto.Text)
            txtAbona.SelectAll()
            txtAbona.Focus()
        End If
    End Sub

    Private Sub txtAbona_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAbona.KeyPress
        If e.KeyChar = "." Then
            If txtAbona.Text.Contains(",") Then
                e.Handled = True
                Exit Sub
            Else
                e.Handled = True
                SendKeys.Send(",")
            End If
        End If
        If e.KeyChar = "," Then
            If txtAbona.Text.Contains(",") Then
                e.Handled = True
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnCancelar_Click_1(sender As Object, e As EventArgs) Handles btnCancelar.Click
        AceptaPago = False
        Me.Close()
    End Sub
End Class