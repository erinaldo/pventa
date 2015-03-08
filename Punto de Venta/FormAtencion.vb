Public Class FormAtencion

    Private Sub FormAtencion_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub


End Class