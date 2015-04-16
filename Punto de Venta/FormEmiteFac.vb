Imports System.IO

Public Class FormEmiteFac

    Dim listaArt As New List(Of Articulos)
    Dim listaCli As New List(Of Clientes)
    Dim Articulo As Articulos
    Dim Valido As Boolean
    Dim idListaSeleccionada As Integer
    Dim TotalPCompra As Double
    Dim blnInicioTicket As Boolean

    Private Sub FormEmiteFac_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listaArt = ObtenerArticulos()

        AbrirFormulario()

    End Sub

    Public Sub AbrirFormulario()

        blnInicioTicket = True
        cmbcliente.Enabled = True
        'If pwiFacturacion.wflEmisionFactura_ExisteCajaAbierta(My.Settings.cadena, idUsuario, My.Settings.sucursal) Then
        GrillaArticulos.Font = New Font("Arial ", 14, FontStyle.Regular)
        GrillaArticulos.Columns(2).DefaultCellStyle.Format = "N2"
        GrillaArticulos.Columns(4).DefaultCellStyle.Format = "N2"
        listaCli = ModuloGeneral.ObtenerClientes()
        Cargar_Combobox(listaCli, cmbcliente)
        cmbcliente.SelectedValue = 1
        cmbcliente.Enabled = False
        Me.lblLista.Text = "Consumidor Final"
        idListaSeleccionada = 1
        lblTotal.Text = FormatNumber("0", 2)
        lblCantidad.Text = 0
        'Me.TextCodBar.Focus()

        'ShowDialog()
        'Else
        'MsgAtencion("El usuario actual no posee una caja abierta. Por favor abra una caja y vuelva a intenatrlo")

        'End If
    End Sub

    Public Function Cargar_Combobox(ByVal lista As List(Of Clientes), ByRef cbx As Windows.Forms.ComboBox)

        cbx.DataSource = lista
        cbx.DisplayMember = "NombreFantasia"
        cbx.ValueMember = "IdCliente"

        Return Nothing
    End Function

    Private Sub LimpiarCajas()
        Me.TextCodBar.Text = ""
        Me.TextCodigo.Text = "0"
        Me.TextPCompra.Text = "0"
        Me.TextCodBar.Focus()
    End Sub

    Private Sub ContarArticulos(cantidad As Double)
        If Articulo.Unidad <> 2 Then
            Me.lblCantidad.Text = CDbl(lblCantidad.Text) + cantidad
        Else
            lblCantidad.Text = CDbl(lblCantidad.Text) + 1
        End If
    End Sub

    Private Sub agregarArticulo()
        Dim intCantidad As Integer

        If blnInicioTicket Then
            cmbcliente.Enabled = False
            blnInicioTicket = False
        End If

        Articulo = New Articulos
        If TextCodBar.Text.Contains("*") Then
            intCantidad = Mid(TextCodBar.Text, 1, InStr(TextCodBar.Text, "*", CompareMethod.Text) - 1)
            CodigoBarrasBuscado = Mid(TextCodBar.Text.ToUpper, InStr(TextCodBar.Text, "*", CompareMethod.Text) + 1, Len(TextCodBar.Text))
        Else
            intCantidad = 1
            CodigoBarrasBuscado = TextCodBar.Text.ToUpper
        End If

        If Mid(CodigoBarrasBuscado, 1, 1) <> "2" And Mid(CodigoBarrasBuscado, 2, 6) <> "900000" Then
            Articulo = BuscarArticulo(listaArt, CodigoBarrasBuscado, idListaSeleccionada)
            If Not Articulo.CodigoBarras Is Nothing Then
                '    inserto = False
                If Len(CodigoBarrasBuscado) > 1 Then
                    ''            'Inserta en la grilla los valores seleccionados
                    'VolcarValoresArticulo()
                    ModuloGeneral.InsertarFilasEnGrilla(Articulo.Codigo, Articulo.Descripcion, CDbl(Articulo.PrecioVenta), CDbl(intCantidad), CDbl(Articulo.PrecioVenta * intCantidad), Articulo.CodigoBarras, CDbl(Articulo.PrecioCosto), Me.GrillaArticulos)
                    ''            'Actualizo el Total
                    Me.lblTotal.Text = CDbl(Me.lblTotal.Text) + CDbl(Articulo.PrecioVenta * intCantidad)

                    ''            'Lo calculo cuando lo guardo 
                    TotalPCompra = TotalPCompra + (Val(Articulo.PrecioCosto) * Val(intCantidad))
                    ''            'HASAR1.ImprimirItem Lbldescripcion.Caption, CDbl(TextCantidad.Text), CDbl(lblTotal.Caption), 21, 0
                    ContarArticulos(intCantidad)
                    LimpiarCajas()
                Else
                    'Articulo = BuscarArticulo(TextCodBar.Text, idListaSeleccionada)
                    'dblcantidad = intCantidad
                    Dim auxTot As Double = 0
                    FormPide.Cargar_Formulario(Articulo.Descripcion, auxTot)

                    If auxTot = 0 Then
                        Me.TextCodBar.Text = ""
                        Me.TextCodBar.Focus()
                        Exit Sub
                    End If
                    ModuloGeneral.InsertarFilasEnGrilla(Articulo.Codigo, Articulo.Descripcion, CDbl(auxTot), CDbl(intCantidad), CDbl(auxTot * intCantidad), Articulo.CodigoBarras, CDbl(Articulo.PrecioCosto), Me.GrillaArticulos)
                    ''            'Actualizo el Total
                    Me.lblTotal.Text = CDbl(Me.lblTotal.Text) + CDbl(auxTot * intCantidad)

                    ''            'Lo calculo cuando lo guardo 
                    TotalPCompra = TotalPCompra + (Val(Articulo.PrecioCosto) * Val(intCantidad))

                    Me.lblTotal.Text = FormatNumber(Me.lblTotal.Text, 2)
                    ContarArticulos(CDbl(intCantidad))
                    LimpiarCajas()
                    TextCodBar.Focus()
                    'TRAER ARTICULOS CANTIDAD
                End If

            Else
                FormAtencion.ShowDialog()
                Me.TextCodBar.Text = ""
                Me.TextCodBar.Focus()

            End If
        Else
            If Len(CodigoBarrasBuscado) > 6 Then
                ' si el articulo es fiambre o producto propio
                Dim PrecioFiambreAux As String
                Dim CodigoFiambre As Integer
                Dim preciofiambre As Double
                CodigoFiambre = Mid(CodigoBarrasBuscado, 2, 6)
                Articulo = BuscarArticulo(listaArt, CodigoFiambre.ToString, idListaSeleccionada)
                If Not Articulo.CodigoBarras Is Nothing Then
                    PrecioFiambreAux = Mid(CodigoBarrasBuscado, 8, 5)
                    preciofiambre = ConvertirPrecio(PrecioFiambreAux)

                    '--------------------------------
                    Me.TextCodigo.Text = Articulo.Codigo
                    intCantidad = 1
                    Me.TextPCompra.Text = Articulo.PrecioCosto

                    '-----------------------------------
                    ModuloGeneral.InsertarFilasEnGrilla(Articulo.Codigo, Articulo.Descripcion, CDbl(preciofiambre), CDbl(intCantidad), CDbl(preciofiambre * CDbl(intCantidad)), CodigoBarrasBuscado, CDbl(Articulo.PrecioCosto), Me.GrillaArticulos)
                    Me.lblTotal.Text = CDbl(Me.lblTotal.Text) + CDbl(preciofiambre * CDbl(intCantidad))
                    TotalPCompra = TotalPCompra + (CDbl(Articulo.PrecioCosto) * CDbl(intCantidad))
                    ContarArticulos(CDbl(intCantidad))

                    LimpiarCajas()
                Else
                    FormAtencion.ShowDialog()
                    Me.TextCodBar.Text = ""
                    Me.TextCodBar.Focus()
                End If
            Else
                Articulo = BuscarArticulo(listaArt, CodigoBarrasBuscado, idListaSeleccionada)

                If Not Articulo.CodigoBarras Is Nothing Then
                    ModuloGeneral.InsertarFilasEnGrilla(Articulo.Codigo, Articulo.Descripcion, CDbl(Articulo.PrecioVenta), CDbl(intCantidad), CDbl(Articulo.PrecioVenta * intCantidad), Articulo.CodigoBarras, CDbl(Articulo.PrecioCosto), Me.GrillaArticulos)
                    ''            'Actualizo el Total
                    Me.lblTotal.Text = CDbl(Me.lblTotal.Text) + CDbl(Articulo.PrecioVenta * intCantidad)

                    ''            'Lo calculo cuando lo guardo 
                    TotalPCompra = TotalPCompra + (Val(Articulo.PrecioCosto) * Val(intCantidad))
                    ''            'HASAR1.ImprimirItem Lbldescripcion.Caption, CDbl(TextCantidad.Text), CDbl(lblTotal.Caption), 21, 0
                    ContarArticulos(intCantidad)
                    LimpiarCajas()
                Else
                    FormAtencion.ShowDialog()
                    Me.TextCodBar.Text = ""
                    Me.TextCodBar.Focus()
                End If

            End If
        End If
    End Sub
    Private Sub TextCodBar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextCodBar.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If TextCodBar.Text <> "" Then
                agregarArticulo()
            Else
                Button1_Click(sender, e)
            End If
        End If

    End Sub

    Private Sub FormEmiteFac_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F1 Then
            cmdAceptar_Click(sender, e)
            Exit Sub
        End If

        If e.KeyCode = Keys.F4 Then
            FormConsulta.ShowDialog()
        End If

        If e.KeyCode = Keys.F5 Then
            FormPedidos.ShowDialog()
        End If

        If e.KeyCode = Keys.F8 Then
            Button1_Click(sender, e)
            Exit Sub
        End If

        If e.KeyCode = 46 Then
            cmdEliminar_Click(sender, e)
        End If

        If e.KeyCode = Keys.Escape Then
            cmdCancelar_Click(sender, e)
        End If

    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim graba As Boolean
        Dim Pbase As Double
        Dim Iva As Double
        Dim objStreamWriter As StreamWriter

        If GrillaArticulos.RowCount = 0 Then
            Exit Sub
        End If
        'If Origen <> "" Then
        If GrillaArticulos.Rows(0).Cells(0).Value <> "" Then
            If CDbl(lblTotal.Text) > 0 Then
                graba = False
                AceptaPago = False
                FormVuelto.Abrir(Me.lblTotal.Text)
                If AceptaPago Then
                    Dim intNroComprobante As Integer
                    Dim intNroComprobanteFiscal As Integer

                    If Origen = "F" Then
                        intNroComprobanteFiscal = obtenerNroComprobanteFiscal() + 1
                    ElseIf Origen = "I" Then
                        intNroComprobanteFiscal = 0
                    End If

                    intNroComprobante = obtenerNroComprobante()

                    objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "ComprobanteVenta.txt", True, System.Text.ASCIIEncoding.ASCII)

                    Dim strComprobanteVenta As String

                    Pbase = CDbl(Me.lblTotal.Text) / (1 + (PorcIva / 100))
                    Iva = CDbl(Me.lblTotal.Text) - FormatNumber(Pbase, 2)
                    'Cargo los datos generales del tiquet

                    strComprobanteVenta = intNroComprobante & ";" & intNroComprobanteFiscal & ";" & 5 & ";" & cmbcliente.SelectedValue & ";" & _
                        FormatDateTime(DtFechaEmi.Value, DateFormat.ShortDate) & ";" & _
                        3 & ";" & FormatNumber(Pbase, 2) & ";" & PorcIva & ";" & FormatNumber(CDbl(Me.lblTotal.Text), 2) & ";" & idUsuario & ";" & Origen & ";" & _
                        FormatNumber(Descuento, 2) & ";" & FormatNumber(TotalDto, 2) & ";" & IdFormaPago & ";" & FormaPago

                    objStreamWriter.WriteLine(strComprobanteVenta)

                    objStreamWriter.Close()

                    'Cargo los elementos de la grilla
                    Dim j As Integer = 0
                    Dim strComprobanteVentaDetalle As String

                    objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "ComprobanteVentaDetalle.txt", True)

                    For j = 0 To GrillaArticulos.Rows.Count - 1

                        strComprobanteVentaDetalle = intNroComprobante & ";" & GrillaArticulos.Rows(j).Cells("CodigoArticulo").Value & ";" & _
                            GrillaArticulos.Rows(j).Cells("DescripcionArticulo").Value & ";" & GrillaArticulos.Rows(j).Cells("Cantidad").Value & ";" & _
                            GrillaArticulos.Rows(j).Cells("PrecioUnitario").Value & ";" & FormatNumber(GrillaArticulos.Rows(j).Cells("Total").Value, 2)

                        objStreamWriter.WriteLine(strComprobanteVentaDetalle)

                    Next

                    objStreamWriter.Close()


                    If Origen = "F" Then
                        'ImprimirImpresoraComun()
                        ImprimirTicketFiscal(GrillaArticulos)
                    Else
                        'ImprimirImpresoraComun()
                    End If
                    LimpiarCajas()
                    Me.lblCantidad.Text = "0"
                    Me.lblTotal.Text = "0"
                    Origen = ""
                    GrillaArticulos.Rows.Clear()
                    FormEmiteFac_Load(sender, e)
                    '''''PrepararNuevoTicket()
                    blnInicioTicket = True
                    'cmbcliente.Enabled = True
                End If
            Else
                MsgAtencion("Debe cargar al menos un articulo")
            End If
        Else
            MsgAtencion("No se puede guardar una factura con importe negativo")
        End If

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click

        If GrillaArticulos.Rows.Count > 0 Then
            If MsgBox("ATENCION: Esta operación CANCELARA el ticket. CANCELA ?", MsgBoxStyle.YesNo, "Mensaje al Operador") = MsgBoxResult.Yes Then
                GuardarCancelado()
                GrillaArticulos.Rows.Clear()
                Me.Dispose()
                Me.Close()
            End If
        Else
            Me.Dispose()
            Me.Close()
        End If
    End Sub

    Private Sub GuardarCancelado()
        Dim j As Integer = 0
        Dim strComprobanteVentaDetalle As String
        Dim objStreamWriter As StreamWriter

        objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "ComprobanteVentaCa.txt", True)

        For j = 0 To GrillaArticulos.Rows.Count - 1

            strComprobanteVentaDetalle = Date.Now & ";" & GrillaArticulos.Rows(j).Cells("CodigoArticulo").Value & ";" & _
                GrillaArticulos.Rows(j).Cells("DescripcionArticulo").Value & ";" & GrillaArticulos.Rows(j).Cells("Cantidad").Value & ";" & _
                GrillaArticulos.Rows(j).Cells("PrecioUnitario").Value & ";" & FormatNumber(GrillaArticulos.Rows(j).Cells("Total").Value, 2) & ";" & NomUsuario

            objStreamWriter.WriteLine(strComprobanteVentaDetalle)

        Next

        objStreamWriter.Close()
    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim fila As Long = 0
        Dim codart As Long = 0
        If GrillaArticulos.CurrentCell Is Nothing Then
            Me.TextCodBar.Focus()
            Exit Sub
        End If
        FormSupervisor.ShowDialog()
        If Not blnEsSupervisor Then
            Exit Sub
        End If
        If GrillaArticulos.CurrentRow.Cells("CodigoArticulo").Value <> 0 Then
            If MsgPregunta("Está seguro de eliminar el producto") = 6 Then
                If GrillaArticulos.CurrentRow.Cells.Count > 0 Then
                    codart = CLng(GrillaArticulos.CurrentRow.Cells("CodigoArticulo").Value)
                    Dim sele As Integer = GrillaArticulos.CurrentRow.Index
                    Me.lblTotal.Text = FormatNumber(CDbl(lblTotal.Text) - CDbl(GrillaArticulos.CurrentRow.Cells("Total").Value), 2)
                    'TotalPCompra = TotalPCompra - (CDbl(GrillaArticulos.CurrentRow.Cells("cantidad").Value) * CDbl(GrillaArticulos.CurrentRow.Cells("punitario").Value))
                    'dblcantidad = GrillaArticulos.CurrentRow.Cells("cantidad").Value
                    ContarArticulos(GrillaArticulos.CurrentRow.Cells("cantidad").Value * -1)
                    GrillaArticulos.Rows.RemoveAt(sele)

                    Me.TextCodBar.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New FormBuscarArtFactu
        CodartBuscado = 0
        CodigoBarrasBuscado = 0
        frm.abrirFormulario(listaArt, idListaSeleccionada)
        If CodartBuscado <> 0 Then
            Me.TextCodBar.Text = CodigoBarrasBuscado
            agregarArticulo()
        End If
    End Sub

    Private Sub cmbcliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcliente.SelectionChangeCommitted
        'Dim idCli As Integer

        'idCli = cmbcliente.SelectedValue

        'For Each cli In listaCli
        '    If cli.IdCliente = idCli Then
        '        Me.lblLista.Text = cli.ListaDescripcion
        '        idListaSeleccionada = cli.IdLista
        '        Exit For
        '    End If
        'Next

    End Sub

End Class
