Public Class FormSupervisor

    Private lngCodSupervisor As Long = 57595153
    Private lngCodigo As String

    Private Sub FormSupervisor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lngCodigo = ""
        blnEsSupervisor = False
    End Sub

    Private Sub FormSupervisor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            If lngCodigo = lngCodSupervisor.ToString Then
                blnEsSupervisor = True
                Me.Close()
                Exit Sub
            Else
                blnEsSupervisor = False
                Me.Dispose()
                Me.Close()
                Exit Sub
            End If
        ElseIf e.KeyChar = ChrW(Keys.Escape) Then
            blnEsSupervisor = False
            Me.Dispose()
            Me.Close()
            Exit Sub
        Else
            lngCodigo = lngCodigo & e.KeyChar.ToString
        End If
    End Sub
End Class