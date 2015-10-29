Imports System.IO

Public Class FormEmiteFac1024

    Dim listaArt As New List(Of Articulos)
    Dim listaCli As New List(Of Clientes)
    Dim Articulo As Articulos
    Dim Valido As Boolean
    Dim idListaSeleccionada As Integer
    Dim TotalPCompra As Double
    'Dim blnInicioTicket As Boolean

    Private Sub FormEmiteFac_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        listaArt = ObtenerArticulos()
        listaCli = ObtenerClientes()

        GrillaArticulos.Font = New Font("Arial ", 12, FontStyle.Regular)
        GrillaArticulos.Columns(2).DefaultCellStyle.Format = "N2"
        GrillaArticulos.Columns(4).DefaultCellStyle.Format = "N2"
        'Cargar_Combobox(listaCli, cmbcliente)

        AbrirFormulario()

    End Sub

    Public Sub AbrirFormulario()
        Dim cliente As New Clientes

        If File.Exists(My.Settings.rutaArchivos & "ComprobanteVentaEnEspera.txt") Then
            Me.Label8.Visible = True
        Else
            Me.Label8.Visible = False
        End If
        cliente = datosCliente(1)
        lblCliente.Text = cliente.NombreFantasia
        lblIdCliente.Text = cliente.IdCliente
        idListaSeleccionada = 1
        lblTotal.Text = FormatNumber("0", 2)
        lblCantidad.Text = 0
        Me.TextCodBar.Focus()

    End Sub

    'Public Function Cargar_Combobox(ByVal lista As List(Of Clientes), ByRef cbx As Windows.Forms.ComboBox)

    '    cbx.DataSource = lista
    '    cbx.DisplayMember = "NombreFantasia"
    '    cbx.ValueMember = "IdCliente"

    '    Return Nothing
    'End Function

    Private Sub LimpiarCajas()
        Me.textcodbar.Text = ""
        Me.TextCodigo.Text = "0"
        Me.textPCompra.Text = "0"
        Me.textcodbar.Focus()
    End Sub

    Private Sub retiroDinero()

        Dim dblRetiro As String

        Try
            FormSupervisor.ShowDialog()
            If blnEsSupervisor Then
                dblRetiro = InputBox("Ingrese el importe.", "Retiro de Dinero")
                dblRetiro = Replace(dblRetiro, ".", ",")
                If CDbl(dblRetiro) <> 0 Then
                    If MsgBox("Es correcto el RETIRO de dinero por: $" & FormatNumber(dblRetiro, 2), MsgBoxStyle.YesNo, "Mensaje al Operador") = MsgBoxResult.Yes Then
                        grabarRetiroDinero(CDbl(dblRetiro))
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Debe ingresar un monto válido", MsgBoxStyle.Information, "Mensaje al Operador")
        End Try
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


        Articulo = New Articulos
        If TextCodBar.Text.Contains("*") Then
            Try
                intCantidad = Mid(TextCodBar.Text, 1, InStr(TextCodBar.Text, "*", CompareMethod.Text) - 1)
                CodigoBarrasBuscado = Mid(TextCodBar.Text.ToUpper, InStr(TextCodBar.Text, "*", CompareMethod.Text) + 1, Len(TextCodBar.Text))
            Catch ex As Exception
                FormAtencion.ShowDialog()
                Me.TextCodBar.Text = ""
                Me.TextCodBar.Focus()
                Exit Sub
            End Try
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

        If e.KeyCode = Keys.F7 Then
            retiroDinero()
            Exit Sub
        End If

        If e.KeyCode = Keys.F8 Then
            Button1_Click(sender, e)
            Exit Sub
        End If

        If e.KeyCode = Keys.F3 Then
            If File.Exists(My.Settings.rutaArchivos & "ComprobanteVentaEnEspera.txt") Then
                If GrillaArticulos.RowCount > 0 Then
                    MsgBox("Ya posee un ticket en espera.", MsgBoxStyle.Information, "Mensaje al Operador")
                    Exit Sub
                Else
                    recuperarTickteEnEspera()
                    Me.Label8.Visible = False
                End If
            Else
                If GrillaArticulos.RowCount > 0 Then
                    If MsgBox("Esta seguro de dejar el ticket en espera?", MsgBoxStyle.YesNo, "Mensaje al Operador") = MsgBoxResult.Yes Then
                        guardarTickteEnEspera()
                        Me.Label8.Visible = True
                    End If
                End If
            End If
            Exit Sub
        End If

        If e.KeyCode = Keys.F10 Then
            Dim cliente As New Clientes
            Dim frm As New FormClientes

            frm.Abrir(listaCli)

            If frm.DialogResult = DialogResult.OK Then
                cliente = datosCliente(frm.IdCliente)
                lblCliente.Text = cliente.NombreFantasia
                lblIdCliente.Text = cliente.IdCliente
            End If
            Exit Sub
        End If

        If e.KeyCode = Keys.Delete Then
            cmdEliminar_Click(sender, e)
        End If

        If e.KeyCode = Keys.Escape Then
            cmdCancelar_Click(sender, e)
        End If

    End Sub

    Private Function datosCliente(ByVal idCliente As Integer) As Clientes

        datosCliente = New Clientes

        datosCliente = (From clie In listaCli
                        Where clie.IdCliente = idCliente
                        Select clie).First

    End Function

    Private Sub guardarTickteEnEspera()
        Dim j As Integer = 0
        Dim strComprobanteVentaDetalle As String
        Dim objStreamWriter As StreamWriter

        Try

            objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "ComprobanteVentaEnEspera.txt", False)

            For j = 0 To GrillaArticulos.Rows.Count - 1

                strComprobanteVentaDetalle = GrillaArticulos.Rows(j).Cells("CodigoArticulo").Value & ";" &
                    GrillaArticulos.Rows(j).Cells("DescripcionArticulo").Value & ";" & GrillaArticulos.Rows(j).Cells("PrecioUnitario").Value & ";" &
                    GrillaArticulos.Rows(j).Cells("Cantidad").Value & ";" & GrillaArticulos.Rows(j).Cells("Total").Value & ";" &
                    GrillaArticulos.Rows(j).Cells("Codbar").Value & ";" & GrillaArticulos.Rows(j).Cells("pcompra").Value

                objStreamWriter.WriteLine(strComprobanteVentaDetalle)

            Next

            objStreamWriter.Close()
            LimpiarCajas()
            Me.lblCantidad.Text = "0"
            Me.lblTotal.Text = FormatNumber("0", 2)
            Origen = ""
            GrillaArticulos.Rows.Clear()
            Me.TextCodBar.Text = ""
            Me.TextCodBar.Focus()

        Catch ex As Exception
            MsgBox("Error en el guardado del ticket", MsgBoxStyle.Information, "Mensaje al Operador")
        End Try
    End Sub

    Private Sub recuperarTickteEnEspera()

        Dim objStreamReader As StreamReader
        Dim strLine As String

        Try
            LimpiarCajas()
            Me.lblCantidad.Text = "0"
            Me.lblTotal.Text = FormatNumber("0", 2)
            TotalPCompra = 0
            Origen = ""
            GrillaArticulos.Rows.Clear()

            objStreamReader = New StreamReader(My.Settings.rutaArchivos & "ComprobanteVentaEnEspera.txt")

            Do While Not objStreamReader.EndOfStream
                Dim row As New DataGridViewRow

                strLine = objStreamReader.ReadLine

                row.CreateCells(GrillaArticulos)

                row.Cells(0).Value = Split(strLine, ";")(0)
                row.Cells(1).Value = Split(strLine, ";")(1)
                row.Cells(2).Value = Split(strLine, ";")(2)
                row.Cells(3).Value = Split(strLine, ";")(3)
                row.Cells(4).Value = Split(strLine, ";")(4)
                row.Cells(5).Value = Split(strLine, ";")(5)
                row.Cells(6).Value = Split(strLine, ";")(6)
                'row.Cells(7).Value = Split(strLine, ";")(7)

                GrillaArticulos.Rows.Add(row)

                TotalPCompra = TotalPCompra + row.Cells(6).Value

                Me.lblTotal.Text = CDbl(Me.lblTotal.Text) + CDbl(row.Cells(4).Value)
                Me.lblTotal.Text = FormatNumber(Me.lblTotal.Text, 2)
                'lblCantidad.Text = CDbl(lblCantidad.Text) + row.Cells(3).Value

                Articulo = New Articulos

                Articulo = BuscarArticulo(listaArt, row.Cells(5).Value, 1)

                ContarArticulos(CDbl(row.Cells(3).Value))

                LimpiarCajas()
            Loop

            objStreamReader.Close()

            File.Delete(My.Settings.rutaArchivos & "ComprobanteVentaEnEspera.txt")

            Me.TextCodBar.Text = ""
            Me.TextCodBar.Focus()

        Catch ex As Exception
            MsgBox("Error en el guardado del ticket", MsgBoxStyle.Information, "Mensaje al Operador")
        End Try
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim graba As Boolean
        Dim Pbase As Double
        Dim Iva As Double
        Dim objStreamWriter As StreamWriter
        Dim lstPagos As New List(Of Pagos)
        Dim cliente As New Clientes
        Dim Pagada As Integer

        If GrillaArticulos.RowCount = 0 Then
            Exit Sub
        End If
        'If Origen <> "" Then
        If GrillaArticulos.Rows(0).Cells(0).Value <> "" Then
            If CDbl(lblTotal.Text) > 0 Then
                graba = False
                AceptaPago = False
                cliente = datosCliente(lblIdCliente.Text)

                FormVuelto.Abrir(Me.lblTotal.Text, lstPagos, cliente, Pagada)
                If AceptaPago Then
                    Dim intNroComprobante As Integer
                    Dim intNroComprobanteFiscal As Integer

                    If Origen = "F" Then
                        If cliente.TpoTicket = "A" Then
                            intNroComprobanteFiscal = obtenerNroComprobanteFiscalA() + 1
                            If Not ImprimirTicketFiscalA(cliente, GrillaArticulos, lstPagos) Then
                                Exit Sub
                            End If
                        Else
                            intNroComprobanteFiscal = obtenerNroComprobanteFiscalBC() + 1
                            If cliente.TpoTicket = "B" Then
                                If Not ImprimirTicketFiscalB(cliente, GrillaArticulos, lstPagos) Then
                                    Exit Sub
                                End If
                            Else
                                If Not ImprimirTicketFiscalC(GrillaArticulos, lstPagos) Then
                                    Exit Sub
                                End If
                            End If
                        End If
                    ElseIf Origen = "I" Then
                        intNroComprobanteFiscal = 0
                    End If

                    intNroComprobante = obtenerNroComprobante()

                    objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "ComprobanteVenta.txt", True, System.Text.ASCIIEncoding.ASCII)

                    Dim strComprobanteVenta As String

                    Pbase = CDbl(Me.lblTotal.Text) / (1 + (PorcIva / 100))
                    Iva = CDbl(Me.lblTotal.Text) - FormatNumber(Pbase, 2)

                    'Cargo los datos generales del tiquet
                    strComprobanteVenta = intNroComprobante & ";" & intNroComprobanteFiscal & ";" & 5 & ";" & lblIdCliente.Text & ";" & Date.Now & ";" &
                        3 & ";" & FormatNumber(Pbase, 2) & ";" & PorcIva & ";" & FormatNumber(CDbl(Me.lblTotal.Text), 2) & ";" & idUsuario & ";" & Origen & ";" &
                        FormatNumber(Descuento, 2) & ";" & FormatNumber(TotalDto, 2) & ";" & My.Settings.sucursal & ";" & My.Settings.puestoVenta &
                        ";" & Pagada ' & ";" & IdFormaPago & ";" & FormaPago

                    objStreamWriter.WriteLine(strComprobanteVenta)

                    objStreamWriter.Close()

                    'Agrego los pagos
                    objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "Pagos.txt", True, System.Text.ASCIIEncoding.ASCII)

                    Dim strPagos As String

                    For Each pagos In lstPagos
                        strPagos = intNroComprobante & ";" & My.Settings.sucursal & ";" & My.Settings.puestoVenta & ";" & pagos.IdPago & ";" & pagos.DescripcionPago & ";" & pagos.Monto
                        objStreamWriter.WriteLine(strPagos)
                    Next

                    objStreamWriter.Close()

                    'Cargo los elementos de la grilla
                    Dim j As Integer = 0
                    Dim strComprobanteVentaDetalle As String

                    objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "ComprobanteVentaDetalle.txt", True)

                    For j = 0 To GrillaArticulos.Rows.Count - 1

                        strComprobanteVentaDetalle = intNroComprobante & ";" & My.Settings.sucursal & ";" & My.Settings.puestoVenta & ";" & GrillaArticulos.Rows(j).Cells("CodigoArticulo").Value & ";" & _
                            GrillaArticulos.Rows(j).Cells("DescripcionArticulo").Value & ";" & GrillaArticulos.Rows(j).Cells("Cantidad").Value & ";" & _
                            GrillaArticulos.Rows(j).Cells("PrecioUnitario").Value & ";" & FormatNumber(GrillaArticulos.Rows(j).Cells("Total").Value, 2)

                        objStreamWriter.WriteLine(strComprobanteVentaDetalle)

                    Next

                    objStreamWriter.Close()

                    LimpiarCajas()
                    Me.lblCantidad.Text = "0"
                    Me.lblTotal.Text = FormatNumber("0", 2)
                    Origen = ""
                    GrillaArticulos.Rows.Clear()
                    FormEmiteFac_Load(sender, e)
                    '''''PrepararNuevoTicket()
                    'blnInicioTicket = True
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
                    Me.lblTotal.Text = lblTotal.Text - GrillaArticulos.CurrentRow.Cells("Total").Value
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

    'Private Sub cmbcliente_SelectionChangeCommitted(sender As Object, e As EventArgs)
    'Dim idCli As Integer

    'idCli = cmbcliente.SelectedValue

    'For Each cli In listaCli
    '    If cli.IdCliente = idCli Then
    '        Me.lblLista.Text = cli.ListaDescripcion
    '        idListaSeleccionada = cli.IdLista
    '        Exit For
    '    End If
    'Next

    'End Sub

    Private Sub cmbcliente_DropDownClosed(sender As Object, e As EventArgs)
        Me.TextCodBar.Focus()
    End Sub
End Class
