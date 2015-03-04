Imports System.IO
Public Class FormEmiteFac
    Dim txtcodBar As String
    Dim listaArt As New List(Of Articulos)
    Dim Valido As Boolean
    Dim dstClientes As New DataSet
    Dim idListaSeleccionada As Integer
    Dim dstArticulo As New DataSet
    Dim dstArticuloFact As New DataSet
    Dim TotalPCompra As Double
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objStreamReader As StreamReader
        Dim strLine As String
        objStreamReader = New StreamReader("C:\Prueba.txt")



        Do While Not objStreamReader.EndOfStream
            Dim art As New Articulos
            strLine = objStreamReader.ReadLine
            art.Codigo = Split(strLine, ";")(0)
            art.Descripcion = Split(strLine, ";")(1)
            art.CodigoBarras = Split(strLine, ";")(2)
            art.Precio = Split(strLine, ";")(3)
            listaArt.Add(art)

        Loop

    End Sub


    Private Sub BuscarEnLista()

        For Each articulo As Articulos In listaArt

            If articulo.CodigoBarras = txtcodBar Then
                Label1.Text = articulo.Codigo
                Label2.Text = articulo.Descripcion
                Label3.Text = articulo.Precio
                Exit For
            End If

        Next


    End Sub
    Private Sub textcodbar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textcodbar.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            txtcodBar = textcodbar.Text
            BuscarEnLista()
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
            'cmdEliminar_Click(sender, e)
        End If

        'If KeyCode = vbKeyF12 Then
        '    FormReimprime.Cargar_Form()
        'End If

        If e.KeyCode = 27 Then
            cmdCancelar_Click(sender, e)
        End If

    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        If Me.textcodbar.Text <> "" Then
            InsertarFilasEnGrilla(Me.TextCodigo.Text, Me.Lbldescripcion.Text, CDbl(TextPU.Text), CDbl(Me.TextCantidad.Text), CDbl(Me.LblTotalU.Text), Me.textcodbar.Text, CDbl(Me.textPCompra.Text), Me.GrillaArticulos)
            ''            'Actualizo el Total
            Me.lblTotal.Text = CDbl(Me.lblTotal.Text) + CDbl(Me.LblTotalU.Text)

            ''            'Lo calculo cuando lo guardo 
            TotalPCompra = TotalPCompra + (Val(textPCompra.Text) * Val(TextCantidad.Text))
            ''            'HASAR1.ImprimirItem Lbldescripcion.Caption, CDbl(TextCantidad.Text), CDbl(lblTotal.Caption), 21, 0
            ContarArticulos(CDbl(Me.TextCantidad.Text))
            LimpiarCajas()
        End If
    End Sub
    
    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim graba As Boolean
        'Dim ultimonro As Long
        'Dim Leyenda As String
        Dim Pbase As Double
        Dim Iva As Double
        Dim dstComprobantesVenta As New DataSet
        Dim dstComprobantesVentaDetalle As New DataSet
        If Origen <> "" Then
            If GrillaArticulos.Rows(0).Cells(0).Value <> "" Then
                If CDbl(lblTotal.Text) > 0 Then
                    graba = False
                    AceptaPago = False
                    FormVuelto.Abrir(Me.lblTotal.Text)
                    If AceptaPago Then

                        Pbase = CDbl(Me.lblTotal.Text) / (1 + (PorcIva / 100))
                        Iva = CDbl(Me.lblTotal.Text) - Pbase
                        'Cargo los datos generales del tiquet
                        dstComprobantesVenta = pwiFacturacion.wflComprobantesVenta_obtenerRegistro(cadena, -1)
                        dstComprobantesVenta.Tables(0).Rows.Add()
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_id") = -1
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_nrocom") = -1
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_tipcom") = 5 'lo fijo poruqe no se elije
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_idcliente") = cmbcliente.SelectedValue
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_fecha") = DtFechaEmi.Value
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_idcondiva") = 3
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_pbase") = Pbase
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_porciva") = PorcIva
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_totcom") = CDbl(Me.lblTotal.Text)
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_idusuario") = idUsuario
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_origen") = Origen
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_dto") = Descuento
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_totaldto") = TotalDto
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_formapago") = IdFormaPago
                        'Campos que agregue para la facturacion libre
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_condicionventa") = 1
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_remito") = ""
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_impuestos") = 0
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_subtotalI") = 0
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_montoiva") = 0
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_nrofactura") = ""
                        dstComprobantesVenta.Tables(0).Rows(0)("cvt_pagada") = 1


                        'Cargo los elementos de la grilla
                        dstComprobantesVentaDetalle = pwiFacturacion.wflComprobantesVentaDetalle_obtenerRegistro(cadena, -1)
                        Dim j As Integer = 0

                        For j = 0 To GrillaArticulos.Rows.Count - 2

                            dstComprobantesVentaDetalle.Tables(0).Rows.Add()
                            dstComprobantesVentaDetalle.Tables(0).Rows(dstComprobantesVentaDetalle.Tables(0).Rows.Count - 1)("cvd_id") = -1
                            dstComprobantesVentaDetalle.Tables(0).Rows(dstComprobantesVentaDetalle.Tables(0).Rows.Count - 1)("cvd_nrocom") = -1
                            dstComprobantesVentaDetalle.Tables(0).Rows(dstComprobantesVentaDetalle.Tables(0).Rows.Count - 1)("cvd_codart") = GrillaArticulos.Rows(j).Cells("codart").Value
                            dstComprobantesVentaDetalle.Tables(0).Rows(dstComprobantesVentaDetalle.Tables(0).Rows.Count - 1)("cvd_descart") = GrillaArticulos.Rows(j).Cells("descri").Value
                            dstComprobantesVentaDetalle.Tables(0).Rows(dstComprobantesVentaDetalle.Tables(0).Rows.Count - 1)("cvd_cantidad") = GrillaArticulos.Rows(j).Cells("cantidad").Value
                            dstComprobantesVentaDetalle.Tables(0).Rows(dstComprobantesVentaDetalle.Tables(0).Rows.Count - 1)("cvd_precunit") = GrillaArticulos.Rows(j).Cells("punitario").Value
                            dstComprobantesVentaDetalle.Tables(0).Rows(dstComprobantesVentaDetalle.Tables(0).Rows.Count - 1)("cvd_totart") = GrillaArticulos.Rows(j).Cells("Total").Value
                            dstArticulo = pwiFacturacion.ObtenerArticulo(GrillaArticulos.Rows(j).Cells("codart").Value, cadena)
                            dstComprobantesVentaDetalle.Tables(0).Rows(dstComprobantesVentaDetalle.Tables(0).Rows.Count - 1)("cvd_idrubro") = dstArticulo.Tables(0).Rows(0)("rubro")

                        Next

                        graba = pwiFacturacion.wflEmisionFactura_GuardarComprobante(cadena, dstComprobantesVenta, dstComprobantesVentaDetalle, My.Settings.sucursal)

                        If graba Then


                            If Origen = "F" Then
                                '''ImprimirImpresoraComun()
                                'ImprimirTicketFiscal
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
                    If dstArticuloFact.Tables(0).Rows(0)("uni_id") <> 2 Then
                        Me.lblCantidad.Text = CDbl(lblCantidad.Text) - CDbl(dblcantidad)
                    Else
                        Me.lblCantidad.Text = CDbl(Me.lblCantidad.Text) - 1
                    End If
                    Me.textcodbar.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New FormBuscarArtFactu
        CodartBuscado = 0
        frm.Abrir(idListaSeleccionada)
        If CodartBuscado <> 0 Then
            dstArticuloFact = pwiFacturacion.obtenerArticuloFacturacion(cadena, CodartBuscado, idListaSeleccionada)
            'Inserta en la grilla los valores seleccionados
            Me.textcodbar.Text = CodigoBarrasBuscado
            VolcarValoresArticulo()
        End If
    End Sub
End Class
