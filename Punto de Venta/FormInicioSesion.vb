Public Class FormInicioSesion

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim clave As String
        If datosCompletos() Then

            Dim Usuario As Usuarios = ObtenerUsuarios(textnombreusuario.Text)
            If Not Usuario.Usuario Is Nothing Then
                idUsuario = Usuario.IdUsuario
                NomUsuario = Usuario.Usuario
                idPerfilUsuario = Usuario.IdSucursal
                clave = Usuario.Password

                If Decript(clave) = textcontrasenia.Text Then
                    FormPrincipal.ShowDialog()
                    textcontrasenia.Text = ""
                    Me.Close()
                Else
                    MsgAtencion("La contraseña está mal ingresada")
                    textcontrasenia.Focus()
                End If
            Else
                MsgAtencion("El usuario ingresado no existe en la Base de Datos")
                textnombreusuario.Focus()
            End If

        Else
            MsgAtencion("No puede dejar el nombre de usuario y/o contraseña sin completar")
            textnombreusuario.Focus()
        End If

    End Sub

    Private Function datosCompletos() As Boolean
        datosCompletos = (Trim(Me.textnombreusuario.Text) <> "") And (Trim(Me.textcontrasenia.Text) <> "")
    End Function

    Private Sub textnombreusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textnombreusuario.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub textcontrasenia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textcontrasenia.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub FormInicioSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        textnombreusuario.Text = ""
        textcontrasenia.Text = ""
    End Sub

End Class