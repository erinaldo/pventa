Public Class FormVuelto
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
        If txttotaldto.Text <> "" Then
            Vuelto = 0
            Paga = 0
            Descuento = CDbl(textdto.Text)
            TotalDto = CDbl(txttotaldto.Text)
            MontoDesc = CDbl(lblTot.Text) - CDbl(txttotaldto.Text)
            IdFormaPago = cmbFormas.SelectedValue
            AceptaPago = True
            Me.Close()
        Else
            MsgAtencion("Debe ingresar algun valor de pago")
            'txtP.SetFocus()
        End If
    End Sub

End Class