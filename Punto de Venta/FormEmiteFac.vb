Imports System.IO

Public Class FormEmiteFac

    Dim listaArt As New List(Of Articulos)
    Dim listaCli As New List(Of Clientes)
    Dim Articulo As Articulos
    Dim Valido As Boolean
    Dim idListaSeleccionada As Integer
    Dim TotalPCompra As Double

    Private Sub FormEmiteFac_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objStreamReader As StreamReader
        Dim strLine As String


        objStreamReader = New StreamReader("C:\Articulos.txt")

        Do While Not objStreamReader.EndOfStream
            Dim art As New Articulos

            strLine = objStreamReader.ReadLine
            art.Codigo = Split(strLine, ";")(0)
            art.Descripcion = Split(strLine, ";")(1)
            art.CodigoBarras = Split(strLine, ";")(2)
            art.PrecioCosto = Split(strLine, ";")(3)
            art.PrecioVenta = Split(strLine, ";")(4)
            art.IdLista = Split(strLine, ";")(5)
            art.Unidad = Split(strLine, ";")(6)
            art.CostoGranel = Split(strLine, ";")(7)
            art.UnidadGranel = Split(strLine, ";")(8)

            listaArt.Add(art)

        Loop

        AbrirFormulario()

    End Sub

    Public Sub AbrirFormulario()
        'cadena = My.Settings.cadena

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
        Me.Lbldescripcion.Text = ""
        Me.LblStock.Text = ""
        Me.TextCantidad.Text = ""
        Me.TextCodigo.Text = "0"
        Me.textPCompra.Text = "0"
        Me.TextPU.Text = "0"
        Me.LblTotalU.Text = "0"
        Me.textcodbar.Focus()
    End Sub

    Private Sub ContarArticulos(cantidad As Double)
        If Articulo.Unidad <> 2 Then
            Me.lblCantidad.Text = CDbl(lblCantidad.Text) + cantidad
        Else
            lblCantidad.Text = CDbl(lblCantidad.Text) + 1
        End If
    End Sub

    Private Sub VolcarValoresArticulo()
        Me.TextCodigo.Text = Articulo.Codigo
        'Me.TextCantidad.Text = "1"
        Me.Lbldescripcion.Text = Articulo.Descripcion
        Me.TextPU.Text = Articulo.PrecioVenta
        'Me.LblStock.Text = IIf(Not IsDBNull(dstArticuloFact.Tables(0).Rows(0)("stockactual")), dstArticuloFact.Tables(0).Rows(0)("stockactual"), "Sin datos")
        Me.TextPCompra.Text = Articulo.PrecioCosto
        Me.LblTotalU.Text = CDbl(Articulo.PrecioVenta * CDbl(Me.TextCantidad.Text))

    End Sub

    Function BuscarArticulo(ByVal strCodBarra As String, ByVal intIdLista As Integer) As Articulos

        BuscarArticulo = New Articulos

        For Each articulo As Articulos In listaArt
            If articulo.CodigoBarras = strCodBarra And articulo.IdLista = intIdLista Then
                BuscarArticulo.Codigo = articulo.Codigo
                BuscarArticulo.Descripcion = articulo.Descripcion
                BuscarArticulo.CodigoBarras = articulo.CodigoBarras
                BuscarArticulo.PrecioCosto = articulo.PrecioCosto
                BuscarArticulo.PrecioVenta = articulo.PrecioVenta
                BuscarArticulo.IdLista = articulo.IdLista
                BuscarArticulo.Unidad = articulo.Unidad
                BuscarArticulo.CostoGranel = articulo.CostoGranel
                BuscarArticulo.UnidadGranel = articulo.UnidadGranel
                Exit For
            End If
        Next

    End Function
    Private Sub TextCodBar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextCodBar.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            If TextCodBar.Text <> "" Then
                Articulo = New Articulos
                If TextCodBar.Text.Contains("*") Then
                    TextCantidad.Text = Mid(TextCodBar.Text, 1, InStr(TextCodBar.Text, "*", CompareMethod.Text) - 1)
                    CodigoBarrasBuscado = Mid(TextCodBar.Text, InStr(TextCodBar.Text, "*", CompareMethod.Text) + 1, Len(TextCodBar.Text))
                Else
                    TextCantidad.Text = 1
                    CodigoBarrasBuscado = TextCodBar.Text
                End If

                If Mid(CodigoBarrasBuscado, 1, 1) <> "2" And Mid(CodigoBarrasBuscado, 2, 6) <> "900000" Then
                    Articulo = BuscarArticulo(CodigoBarrasBuscado, idListaSeleccionada)
                    If Not Articulo.CodigoBarras Is Nothing Then
                        '    inserto = False
                        If Len(CodigoBarrasBuscado) > 1 Then
                            ''            'Inserta en la grilla los valores seleccionados
                            VolcarValoresArticulo()
                            ModuloGeneral.InsertarFilasEnGrilla(Me.TextCodigo.Text, Me.Lbldescripcion.Text, CDbl(TextPU.Text), CDbl(Me.TextCantidad.Text), CDbl(Me.LblTotalU.Text), Me.TextCodBar.Text, CDbl(Me.TextPCompra.Text), Me.GrillaArticulos)
                            ''            'Actualizo el Total
                            Me.lblTotal.Text = CDbl(Me.lblTotal.Text) + CDbl(Me.LblTotalU.Text)

                            ''            'Lo calculo cuando lo guardo 
                            TotalPCompra = TotalPCompra + (Val(TextPCompra.Text) * Val(TextCantidad.Text))
                            ''            'HASAR1.ImprimirItem Lbldescripcion.Caption, CDbl(TextCantidad.Text), CDbl(lblTotal.Caption), 21, 0
                            ContarArticulos(CDbl(Me.TextCantidad.Text))
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
                    Dim CodigoFiambre As String
                    Dim preciofiambre As Double
                    CodigoFiambre = Mid(CodigoBarrasBuscado, 2, 6)
                    Articulo = BuscarArticulo(CodigoFiambre, idListaSeleccionada)
                    If Not Articulo Is Nothing Then
                        PrecioFiambreAux = Mid(CodigoBarrasBuscado, 8, 5)
                        preciofiambre = ConvertirPrecio(PrecioFiambreAux)
                        Articulo = BuscarArticulo(Articulo.Codigo, idListaSeleccionada)
                        '--------------------------------
                        Me.TextCodigo.Text = Articulo.Codigo
                        Me.TextCantidad.Text = "1"
                        Me.Lbldescripcion.Text = Articulo.Descripcion
                        Me.TextPU.Text = preciofiambre
                        'Me.LblStock.Text = dstArticuloFact.Tables(0).Rows(0)("stockactual")
                        Me.TextPCompra.Text = Articulo.PrecioCosto
                        Me.LblTotalU.Text = CDbl(preciofiambre * CDbl(Me.TextCantidad.Text))

                        '-----------------------------------
                        ModuloGeneral.InsertarFilasEnGrilla(Me.TextCodigo.Text, Me.Lbldescripcion.Text, CDbl(preciofiambre), CDbl(Me.TextCantidad.Text), CDbl(Me.LblTotalU.Text), CodigoBarrasBuscado, CDbl(Me.TextPCompra.Text), Me.GrillaArticulos)
                        Me.lblTotal.Text = CDbl(Me.lblTotal.Text) + CDbl(Me.LblTotalU.Text)
                        TotalPCompra = TotalPCompra + (CDbl(TextPCompra.Text) * CDbl(TextCantidad.Text))
                        ContarArticulos(CDbl(Me.TextCantidad.Text))
                        'CalcularTotal
                        'HASAR1.ImprimirItem Lbldescripcion.Caption, CDbl(TextCantidad.Text), CDbl(lblTotal.Caption), 21, 0
                        LimpiarCajas()
                    Else
                        FormAtencion.ShowDialog()
                        Me.TextCodBar.Text = ""
                        Me.TextCodBar.Focus()
                    End If
                End If
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

        'If KeyCode = vbKeyF5 Then
        '    FormConsuPrecio.Show vbModal
        'End If

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

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        If Me.TextCodBar.Text <> "" Then
            InsertarFilasEnGrilla(Me.TextCodigo.Text, Me.Lbldescripcion.Text, CDbl(TextPU.Text), CDbl(Me.TextCantidad.Text), CDbl(Me.LblTotalU.Text), Me.TextCodBar.Text, CDbl(Me.TextPCompra.Text), Me.GrillaArticulos)
            ''            'Actualizo el Total
            Me.lblTotal.Text = CDbl(Me.lblTotal.Text) + CDbl(Me.LblTotalU.Text)

            ''            'Lo calculo cuando lo guardo 
            TotalPCompra = TotalPCompra + (Val(TextPCompra.Text) * Val(TextCantidad.Text))
            ''            'HASAR1.ImprimirItem Lbldescripcion.Caption, CDbl(TextCantidad.Text), CDbl(lblTotal.Caption), 21, 0
            ContarArticulos(CDbl(Me.TextCantidad.Text))
            LimpiarCajas()
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

                        intNroComprobante = obtenerNroComprobante()

                        objStreamWriter = New StreamWriter("C:\ComprobanteVenta.txt", True, System.Text.Encoding.Unicode)

                        Dim strComprobanteVenta As String

                        Pbase = CDbl(Me.lblTotal.Text) / (1 + (PorcIva / 100))
                        Iva = CDbl(Me.lblTotal.Text) - FormatNumber(Pbase, 2)
                        'Cargo los datos generales del tiquet

                        strComprobanteVenta = intNroComprobante & ";" & "0001-" & intNroComprobante & ";" & 5 & ";" & cmbcliente.SelectedValue & ";" & _
                            FormatDateTime(DtFechaEmi.Value, DateFormat.ShortDate) & ";" & _
                            3 & ";" & FormatNumber(Pbase, 2) & ";" & PorcIva & ";" & FormatNumber(CDbl(Me.lblTotal.Text), 2) & ";" & "sgerra" & ";" & Origen & ";" & _
                            FormatNumber(Descuento, 2) & ";" & FormatNumber(TotalDto, 2) & ";" & IdFormaPago & ";" & 1 & ";" & "" & ";" & 0 & ";" & 0 & ";" & 0 & ";" & _
                            "" & ";" & 1


                        objStreamWriter.WriteLine(strComprobanteVenta)

                        objStreamWriter.Close()

                        'Cargo los elementos de la grilla
                        Dim j As Integer = 0
                        Dim strComprobanteVentaDetalle As String

                        objStreamWriter = New StreamWriter("C:\ComprobanteVentaDetalle.txt", True, System.Text.Encoding.Unicode)

                        For j = 0 To GrillaArticulos.Rows.Count - 2

                            strComprobanteVentaDetalle = intNroComprobante & ";" & "0001-" & intNroComprobante & ";" & GrillaArticulos.Rows(j).Cells("codart").Value & ";" & _
                                GrillaArticulos.Rows(j).Cells("descri").Value & ";" & GrillaArticulos.Rows(j).Cells("cantidad").Value & ";" & _
                                GrillaArticulos.Rows(j).Cells("punitario").Value & ";" & FormatNumber(GrillaArticulos.Rows(j).Cells("Total").Value, 2) & ";" & _
                                1
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

        ' Guardar en tablas que emulan facturación
        'GrabarFactura_Emulada(True, 1, HASAR1)

        If MsgPregunta("ATENCION: Esta operación CANCELARA el ticket. CANCELA ?") = vbYes Then
            paso = True
            '         HASAR1.CancelarComprobanteFiscal
            '        HASAR1.Finalizar
            Me.Close()
        End If
    End Sub

    Private Sub cmdEliminar_Click(sender As Object, e As EventArgs) Handles cmdEliminar.Click
        Dim fila As Long = 0
        Dim codart As Long = 0

        If GrillaArticulos.CurrentRow.Cells("codart").Value <> 0 Then
            If MsgPregunta("Está seguro de eliminar el producto") = 6 Then
                If GrillaArticulos.CurrentRow.Cells.Count > 0 Then
                    codart = CLng(GrillaArticulos.CurrentRow.Cells("codart").Value)
                    Dim sele As Integer = GrillaArticulos.CurrentRow.Index
                    Me.lblTotal.Text = FormatNumber(CDbl(lblTotal.Text) - CDbl(GrillaArticulos.CurrentRow.Cells("Total").Value), 2)
                    TotalPCompra = TotalPCompra - (CDbl(GrillaArticulos.CurrentRow.Cells("cantidad").Value) * CDbl(GrillaArticulos.CurrentRow.Cells("punitario").Value))
                    dblcantidad = GrillaArticulos.CurrentRow.Cells("cantidad").Value
                    GrillaArticulos.Rows.RemoveAt(sele)

                    'Busco la unidad del articulo para descontar la cantidad o 1
                    'If dstArticuloFact.Tables(0).Rows(0)("uni_id") <> 2 Then
                    '    Me.lblCantidad.Text = CDbl(lblCantidad.Text) - CDbl(dblcantidad)
                    'Else
                    '    Me.lblCantidad.Text = CDbl(Me.lblCantidad.Text) - 1
                    'End If
                    Me.TextCodBar.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New FormBuscarArtFactu
        CodartBuscado = 0
        frm.abrirFormulario(idListaSeleccionada)
        If CodartBuscado <> 0 Then
            'dstArticuloFact = pwiFacturacion.obtenerArticuloFacturacion(cadena, CodartBuscado, idListaSeleccionada)
            'Inserta en la grilla los valores seleccionados
            Me.TextCodBar.Text = CodigoBarrasBuscado
            VolcarValoresArticulo()
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
