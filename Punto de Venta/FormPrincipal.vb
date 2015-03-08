Public Class FormPrincipal

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If MsgBox("Esta seguro de imprimir el Reporte Z?", MsgBoxStyle.YesNo, "Reporte Z") = MsgBoxResult.Yes Then
            ImprimirReporteZ()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormEmiteFac.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("Esta seguro de imprimir el Reporte X?", MsgBoxStyle.YesNo, "Reporte X") = MsgBoxResult.Yes Then
            ImprimirReporteX()
        End If
    End Sub
End Class