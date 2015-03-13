Imports System.IO

Public Class FormEmiteFac

    Dim listaArt As New List(Of Articulos)
    Dim listaCli As New List(Of Clientes)
    Dim Articulo As Articulos
    Dim Valido As Boolean
    Dim idListaSeleccionada As Integer
    Dim TotalPCompra As Double

    Private Sub FormEmiteFac_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listaArt = ObtenerArticulos()

        AbrirFormulario()

    End Sub

    Public Sub AbrirFormulario()


        'If pwiFacturacion.wflEmisionFactura_ExisteCajaAbierta(My.Settings.cadena, idUsuario, My.Settings.sucursal) Then
        GrillaArticulos.Font = New Font("Arial ", 16, FontStyle.Regular)
        listaCli = ModuloGeneral.ObtenerClientes()
        Cargar_Combobox(listaCli, cmbcliente)
        cmbcliente.SelectedValue = 1
        Me.lblLista.Text = "Consumidor Final" 'dstClientes.Tables(0).Rows(cmbcliente.SelectedIndex)("lpr_descripcion")
        idListaSeleccionada = 1 'dstClientes.Tables(0).Rows(cmbcliente.SelectedIndex)("lpr_id")
        lblTotal.Text = FormatNumber("0", 2)
        lblCantidad.Text = 0
        Me.TextCodBar.Focus()
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
        Me.textcodbar.Text = ""
        'Me.Lbldescripcion.Text = ""
        'Me.LblStock.Text = ""
        'Me.TextCantidad.Text = ""
        Me.TextCodigo.Text = "0"
        Me.textPCompra.Text = "0"
        'Me.TextPU.Text = "0"
        'Me.LblTotalU.Text = "0"
        Me.textcodbar.Focus()
    End Sub

    Private Sub ContarArticulos(cantidad As Double)
        If Articulo.Unidad <> 2 Then
            Me.lblCantidad.Text = CDbl(lblCantidad.Text) + cantidad
        Else
            lblCantidad.Text = CDbl(lblCantidad.Text) + 1
        End If
    End Sub

    Function BuscarArticulo(ByVal strCodBarra As String, ByVal intIdLista As Integer) As Articulos

        BuscarArticulo = New Articulos

        BuscarArticulo = (From art In listaArt
                          Where art.CodigoBarras = strCodBarra And art.IdLista = intIdLista
                          Select art).First

    End Function

    Private Sub agregarArticulo()
        Dim intCantidad As Integer
        Articulo = New Articulos
        If TextCodBar.Text.Contains("*") Then
            intCantidad = Mid(TextCodBar.Text, 1, InStr(TextCodBar.Text, "*", CompareMethod.Text) - 1)
            CodigoBarrasBuscado = Mid(TextCodBar.Text, InStr(TextCodBar.Text, "*", CompareMethod.Text) + 1, Len(TextCodBar.Text))
        Else
            intCantidad = 1
            CodigoBarrasBuscado = TextCodBar.Text
        End If

        If Mid(CodigoBarrasBuscado, 1, 1) <> "2" And Mid(CodigoBarrasBuscado, 2, 6) <> "900000" Then
            Articulo = BuscarArticulo(CodigoBarrasBuscado, idListaSeleccionada)
            If Not Articulo.CodigoBarras Is Nothing Then
                '    inserto = False
                If Len(CodigoBarrasBuscado) > 1 Then
                    ''            'Inserta en la grilla los valores seleccionados
                    'VolcarValoresArticulo()
                    ModuloGeneral.InsertarFilasEnGrilla(Articulo.Codigo, Articulo.Descripcion, CDbl(Articulo.PrecioVenta), CDbl(intCantidad), CDbl(Articulo.PrecioVenta * intCantidad), Articulo.CodigoBarras, CDbl(Articulo.PrecioCosto), Me.GrillaArticulos)
                    ''            'Actualizo el Total
                    Me.lblTotal.Text = CDbl(Me.lblTotal.Text) + CDbl(Articulo.PrecioVenta * intCantidad)

                    ''            'Lo calculo cuando lo guardo 
                    TotalPCompra = TotalPCompra + (Val(TextPCompra.Text) * Val(intCantidad))
                    ''            'HASAR1.ImprimirItem Lbldescripcion.Caption, CDbl(TextCantidad.Text), CDbl(lblTotal.Caption), 21, 0
                    ContarArticulos(intCantidad)
                    LimpiarCajas()
                Else
                    'Articulo = BuscarArticulo(TextCodBar.Text, idListaSeleccionada)
                    dblcantidad = 1
                    Dim auxTot = CDbl(Me.lblTotal.Text)
                    FormPide.Cargar_Formulario(Articulo.Descripcion, Articulo.PrecioVenta, Articulo.Codigo, CodigoBarrasBuscado, Articulo.PrecioCosto, Me.GrillaArticulos, auxTot)
                    Me.lblTotal.Text = FormatNumber(auxTot, 2)
                    ContarArticulos(CDbl(dblcantidad))
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
            ' si el articulo es fiambre o producto propio
            Dim PrecioFiambreAux As String
            Dim CodigoFiambre As Integer
            Dim preciofiambre As Double
            CodigoFiambre = Mid(CodigoBarrasBuscado, 2, 6)
            Articulo = BuscarArticulo(CodigoFiambre.ToString, idListaSeleccionada)
            If Not Articulo Is Nothing Then
                PrecioFiambreAux = Mid(CodigoBarrasBuscado, 8, 5)
                preciofiambre = ConvertirPrecio(PrecioFiambreAux)

                '--------------------------------
                Me.TextCodigo.Text = Articulo.Codigo
                intCantidad = 1
                Me.TextPCompra.Text = Articulo.PrecioCosto

                '-----------------------------------
                ModuloGeneral.InsertarFilasEnGrilla(Articulo.Codigo, Articulo.Descripcion, CDbl(preciofiambre), CDbl(intCantidad), CDbl(preciofiambre * CDbl(intCantidad)), CodigoBarrasBuscado, CDbl(Articulo.PrecioCosto), Me.GrillaArticulos)
                Me.lblTotal.Text = CDbl(Me.lblTotal.Text) + CDbl(preciofiambre * CDbl(intCantidad))
                TotalPCompra = TotalPCompra + (CDbl(TextPCompra.Text) * CDbl(intCantidad))
                ContarArticulos(CDbl(intCantidad))

                LimpiarCajas()
            Else
                FormAtencion.ShowDialog()
                Me.TextCodBar.Text = ""
                Me.TextCodBar.Focus()
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

        If e.KeyCode = 73 Then 'Presiona I-> Graba el ticket e imprime en impresora comun
            Origen = "I"
            cmdAceptar_Click(sender, e)
        End If

        If e.KeyCode = 70 Then 'Presiona F-> Graba el ticket e imprime en impresora fiscal
            Origen = "F"
            cmdAceptar_Click(sender, e)
        End If

        If e.KeyCode = Keys.F5 Then
            FormPedidos.ShowDialog()
        End If

        'If KeyCode = vbKeyF2 Then 'F2 Graba el ticket
        '    FormVentaDiaria.Show vbModal
        'End If

        'If KeyCode = vbKeyF8 Then 'F2 Graba el ticket
        '    HASAR1.Comenzar()
        '    HASAR1.ReporteZ()
        '    HASAR1.Finalizar()
        'End If

        If e.KeyCode = 46 Then
            cmdEliminar_Click(sender, e)
        End If

        'If KeyCode = vbKeyF12 Then
        '    FormReimprime.Cargar_Form()
        'End If

        If e.KeyCode = 27 Then
            cmdCancelar_Click(sender, e)
        End If

    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim graba As Boolean
        Dim Pbase As Double
        Dim Iva As Double
        Dim objStreamWriter As StreamWriter

        If Origen <> "" Then
            If GrillaArticulos.Rows(0).Cells(0).Value <> "" Then
                If CDbl(lblTotal.Text) > 0 Then
                    graba = False
                    AceptaPago = False
                    FormVuelto.Abrir(Me.lblTotal.Text)
                    If AceptaPago Then
                        Dim intNroComprobante As Integer
                        Dim intNroComprobanteFiscal As Integer

                        intNroComprobante = obtenerNroComprobante()
                        intNroComprobanteFiscal = obtenerNroComprobanteFiscal() + 1

                        objStreamWriter = New StreamWriter("C:\ComprobanteVenta.txt", True, System.Text.ASCIIEncoding.ASCII)

                        Dim strComprobanteVenta As String

                        Pbase = CDbl(Me.lblTotal.Text) / (1 + (PorcIva / 100))
                        Iva = CDbl(Me.lblTotal.Text) - FormatNumber(Pbase, 2)
                        'Cargo los datos generales del tiquet

                        strComprobanteVenta = intNroComprobante & ";" & "0001-" & intNroComprobanteFiscal & ";" & 5 & ";" & cmbcliente.SelectedValue & ";" & _
                            FormatDateTime(DtFechaEmi.Value, DateFormat.ShortDate) & ";" & _
                            3 & ";" & FormatNumber(Pbase, 2) & ";" & PorcIva & ";" & FormatNumber(CDbl(Me.lblTotal.Text), 2) & ";" & idUsuario & ";" & Origen & ";" & _
                            FormatNumber(Descuento, 2) & ";" & FormatNumber(TotalDto, 2) & ";" & IdFormaPago & ";" & FormaPago & ";" & 1 & ";" & "" & ";" & 0 & ";" & 0 & ";" & 0 & ";" & _
                            "" & ";" & 1

                        objStreamWriter.WriteLine(strComprobanteVenta)

                        objStreamWriter.Close()

                        'Cargo los elementos de la grilla
                        Dim j As Integer = 0
                        Dim strComprobanteVentaDetalle As String

                        objStreamWriter = New StreamWriter("C:\ComprobanteVentaDetalle.txt", True)

                        For j = 0 To GrillaArticulos.Rows.Count - 1

                            strComprobanteVentaDetalle = intNroComprobante & ";" & "0001-" & intNroComprobanteFiscal & ";" & GrillaArticulos.Rows(j).Cells("CodigoArticulo").Value & ";" & _
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
                        GrillaArticulos.Rows.Clear()
                        FormEmiteFac_Load(sender, e)
                        '''''PrepararNuevoTicket()

                    End If
                Else
                    MsgAtencion("Debe cargar al menos un articulo")
                End If
            Else
                MsgAtencion("No se puede guardar una factura con importe negativo")
            End If

        Else
            MsgAtencion("Presione I o F para guardar")
        End If

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Dim paso As Boolean

        paso = False

        If MsgPregunta("ATENCION: Esta operación CANCELARA el ticket. CANCELA ?") = vbYes Then
            paso = True
            GrillaArticulos.Rows.Clear()
            Me.Close()
        End If
    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim fila As Long = 0
        Dim codart As Long = 0
        If GrillaArticulos.CurrentCell Is Nothing Then
            Exit Sub
        End If
        If GrillaArticulos.CurrentRow.Cells("codart").Value <> 0 Then
            If MsgPregunta("Está seguro de eliminar el producto") = 6 Then
                If GrillaArticulos.CurrentRow.Cells.Count > 0 Then
                    codart = CLng(GrillaArticulos.CurrentRow.Cells("codart").Value)
                    Dim sele As Integer = GrillaArticulos.CurrentRow.Index
                    Me.lblTotal.Text = FormatNumber(CDbl(lblTotal.Text) - CDbl(GrillaArticulos.CurrentRow.Cells("Total").Value), 2)
                    TotalPCompra = TotalPCompra - (CDbl(GrillaArticulos.CurrentRow.Cells("cantidad").Value) * CDbl(GrillaArticulos.CurrentRow.Cells("punitario").Value))
                    dblcantidad = GrillaArticulos.CurrentRow.Cells("cantidad").Value
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
        Dim idCli As Integer

        idCli = cmbcliente.SelectedValue

        For Each cli In listaCli
            If cli.IdCliente = idCli Then
                Me.lblLista.Text = cli.ListaDescripcion
                idListaSeleccionada = cli.IdLista
                Exit For
            End If
        Next

    End Sub

End Class
