Public Class FormAtencion

    Private Sub FormAtencion_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyValue = Keys.Escape Then
            Me.Close()
        End If
        
    End Sub


    Private Sub FormAtencion_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Enter Then
            Me.Close()
        End If
    End Sub
End Class