Public Class FormFaltaPapel

    Private Sub FormFaltaPapel_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class