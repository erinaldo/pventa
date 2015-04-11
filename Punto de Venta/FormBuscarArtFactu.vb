Imports System.IO

Public Class FormBuscarArtFactu

    Private lista As List(Of Articulos)

    Public Sub abrirFormulario(ByVal listaArt As List(Of Articulos), ByVal intIdLista As Integer)


        'lista = (From listArt In listaArt
        '        Where listArt.IdLista = intIdLista
        '        Select listArt).ToList

        lista = (From listArt In listaArt
                Select listArt).ToList

        'CargarGrillaArticulos(lista)
        GrillaArticulos.DataSource = lista

        GrillaArticulos.Columns(0).HeaderText = "Código"
        GrillaArticulos.Columns(1).HeaderText = "Descripción"
        GrillaArticulos.Columns(1).Width = 300
        GrillaArticulos.Columns(2).HeaderText = "Cod.Barra"
        GrillaArticulos.Columns(4).HeaderText = "Precio Venta"

        GrillaArticulos.Columns(3).Visible = False
        GrillaArticulos.Columns(5).Visible = False
        GrillaArticulos.Columns(6).Visible = False
        GrillaArticulos.Columns(7).Visible = False

        'lista = listaArt
        ShowDialog()

    End Sub

    'Private Sub CargarGrillaArticulos(ByVal listaArt As List(Of Articulos))
    '    Dim lngNroError As Long

    '    Try
    '        lngNroError = 0
    '        Dim i As Integer

    '        GrillaArticulos.Rows.Clear()

    '        i = 1
    '        If Not listaArt Is Nothing Then
    '            For Each Art In listaArt
    '                GrillaArticulos.Rows.Add(Art.Codigo, Art.Descripcion, Art.CodigoBarras, Art.PrecioVenta)
    '            Next
    '        End If

    '    Catch ex As Exception
    '        Throw New Exception("Error " + "Cargar grilla" + "|" + ex.Message)

    '    End Try

    'End Sub

    Private Sub txtdescri_KeyUp(sender As Object, e As KeyEventArgs) Handles txtdescri.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim result As List(Of Articulos) = (From art In lista
                                                        Where art.Descripcion.Contains(txtdescri.Text.ToUpper)
                                                        Select art).ToList
            'CargarGrillaArticulos(result)
            GrillaArticulos.DataSource = result
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
        If e.KeyCode = Keys.Enter Then
            Dim result As List(Of Articulos) = (From art In lista
                                    Where art.CodigoBarras.Contains(txtCodbar.Text.ToUpper)
                                    Select art).ToList
            'CargarGrillaArticulos(result)
            GrillaArticulos.DataSource = result
        End If
    End Sub

    Private Sub GrillaArticulos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrillaArticulos.CellDoubleClick
        btnSeleccionar_Click(sender, e)
    End Sub

    Private Sub txtCod_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCod.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim result As List(Of Articulos) = (From art In lista
                            Where art.Codigo.ToString.Contains(txtCod.Text)
                            Select art).ToList
            'CargarGrillaArticulos(result)
            GrillaArticulos.DataSource = result
        End If
    End Sub

    Private Sub txtCod_Enter(sender As Object, e As EventArgs) Handles txtCod.Enter
        txtCod.Text = ""
    End Sub

    Private Sub txtdescri_Enter(sender As Object, e As EventArgs) Handles txtdescri.Enter
        txtdescri.Text = ""
    End Sub

    Private Sub txtCodbar_Enter(sender As Object, e As EventArgs) Handles txtCodbar.Enter
        txtCodbar.Text = ""
    End Sub

    Private Sub GrillaArticulos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GrillaArticulos.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnSeleccionar_Click(sender, e)
        End If
    End Sub

    Private Sub txtdescri_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtdescri.KeyPress
        txtCod.Text = ""
        txtCodbar.Text = ""
    End Sub

    Private Sub txtCodbar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodbar.KeyPress
        txtCod.Text = ""
        txtdescri.Text = ""
    End Sub

    Private Sub txtCod_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCod.KeyPress
        txtCodbar.Text = ""
        txtdescri.Text = ""
    End Sub
End Class