Imports System.IO

Public Class FormBuscarArtFactu

    Private lista As List(Of Articulos)

    Public Sub abrirFormulario(ByVal listaArt As List(Of Articulos), ByVal intIdLista As Integer)


        CargarGrillaArticulos(listaArt)

        Me.btnCodBar.Checked = False
        Me.txtCodbar.Visible = False
        Me.txtdescri.Visible = True
        Me.btnDescri.Checked = True

        lista = listaArt
        ShowDialog()

    End Sub

    Private Sub CargarGrillaArticulos(ByVal listaArt As List(Of Articulos))
        Dim lngNroError As Long

        Try
            lngNroError = 0
            Dim i As Integer

            GrillaArticulos.Rows.Clear()

            i = 1
            If Not listaArt Is Nothing Then
                For Each Art In listaArt
                    GrillaArticulos.Rows.Add(Art.Codigo, Art.Descripcion, Art.CodigoBarras, Art.PrecioVenta)
                Next
            End If

        Catch ex As Exception
            Throw New Exception("Error " + "Cargar grilla" + "|" + ex.Message)

        End Try

    End Sub

    Private Sub txtdescri_KeyUp(sender As Object, e As KeyEventArgs) Handles txtdescri.KeyUp

        Dim result As List(Of Articulos) = (From art In lista
                                            Where art.Descripcion.Contains(txtdescri.Text.ToUpper)
                                            Select art).ToList
        CargarGrillaArticulos(result)
    End Sub



    Private Sub btncontinua_Click(sender As Object, e As EventArgs) Handles btncontinua.Click
        Dim strabuscar As String

        If txtdescri.Visible = True Then
            strabuscar = (txtdescri.Text).ToUpper
            For i As Integer = GrillaArticulos.CurrentRow.Index + 1 To Me.GrillaArticulos.Rows.Count - 2
                If Me.GrillaArticulos.Rows(i).Cells(1).Value.ToString.Contains(strabuscar) Then
                    Me.GrillaArticulos.CurrentCell = Me.GrillaArticulos.Rows(i).Cells(1)
                    Exit Sub
                End If
            Next i
        Else
            strabuscar = (txtCodbar.Text).ToUpper
            For i As Integer = GrillaArticulos.CurrentRow.Index + 1 To Me.GrillaArticulos.Rows.Count - 2
                If Me.GrillaArticulos.Rows(i).Cells(2).Value.ToString.Contains(strabuscar) Then
                    Me.GrillaArticulos.CurrentCell = Me.GrillaArticulos.Rows(i).Cells(2)
                    Exit Sub
                End If
            Next i
        End If

    End Sub

    Private Sub btnCodBar_CheckedChanged(sender As Object, e As EventArgs) Handles btnCodBar.CheckedChanged
        If btnCodBar.Checked = False Then
            Me.btnCodBar.Checked = False
            Me.txtCodbar.Visible = False
            Me.txtdescri.Visible = True
            Me.btnDescri.Checked = True
            Me.txtCodbar.Text = ""
            Me.txtdescri.Focus()
        Else
            Me.btnCodBar.Checked = True
            Me.txtCodbar.Visible = True
            Me.txtdescri.Visible = False
            Me.btnDescri.Checked = False
            Me.txtdescri.Text = ""
            Me.txtCodbar.Focus()
        End If
    End Sub

    Private Sub btnDescri_CheckedChanged(sender As Object, e As EventArgs) Handles btnDescri.CheckedChanged
        If btnDescri.Checked = True Then
            Me.btnCodBar.Checked = False
            Me.txtCodbar.Visible = False
            Me.txtdescri.Visible = True
            Me.btnDescri.Checked = True
            Me.txtCodbar.Text = ""
            Me.txtdescri.Focus()
        Else
            Me.btnCodBar.Checked = True
            Me.txtCodbar.Visible = True
            Me.txtdescri.Visible = False
            Me.btnDescri.Checked = False
            Me.txtdescri.Text = ""
            Me.txtCodbar.Focus()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim strabuscar As String

        If txtdescri.Visible = True Then
            strabuscar = (txtdescri.Text).ToUpper
            For i As Integer = GrillaArticulos.CurrentRow.Index - 1 To 0 Step -1
                If Me.GrillaArticulos.Rows(i).Cells(1).Value.ToString.Contains(strabuscar) Then
                    Me.GrillaArticulos.CurrentCell = Me.GrillaArticulos.Rows(i).Cells(1)
                    Exit Sub
                End If

            Next i
        Else
            strabuscar = (txtCodbar.Text).ToUpper
            For i As Integer = GrillaArticulos.CurrentRow.Index - 1 To 0
                If Me.GrillaArticulos.Rows(i).Cells(2).Value.ToString.Contains(strabuscar) Then
                    Me.GrillaArticulos.CurrentCell = Me.GrillaArticulos.Rows(i).Cells(2)
                    Exit Sub
                End If

            Next i
        End If

    End Sub


    Private Sub btnSeleccionar_Click(sender As Object, e As EventArgs) Handles btnSeleccionar.Click
        If GrillaArticulos.CurrentCell.Selected = True Then
            CodartBuscado = GrillaArticulos.Item(0, GrillaArticulos.CurrentCell.RowIndex).Value
            CodigoBarrasBuscado = GrillaArticulos.Item(2, GrillaArticulos.CurrentCell.RowIndex).Value
            Me.Close()
        End If
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub txtCodbar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodbar.KeyUp
        Dim result As List(Of Articulos) = (From art In lista
                                    Where art.CodigoBarras.Contains(txtCodbar.Text.ToUpper)
                                    Select art).ToList
        CargarGrillaArticulos(result)
    End Sub

End Class