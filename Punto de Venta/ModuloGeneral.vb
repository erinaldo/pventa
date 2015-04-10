Imports System.IO

Module ModuloGeneral


    Public Vuelto As Double
    Public Paga As Double
    Public AceptaPago As Boolean
    Public Descuento As Double
    Public TotalDto As Double
    Public MontoDesc As Double
    Public IdFormaPago As Integer
    Public FormaPago As String
    Public Origen As String
    Public CodartBuscado As Integer
    Public CodigoBarrasBuscado As String
    Public dblcantidad As Double
    Public TotalPcompra As Double
    Public PorcIva As Double = 21
    Public idUsuario As Double '=4
    Public NomUsuario As String '= "Administrador"
    Public idPerfilUsuario As Integer
    Public blnEsSupervisor As Boolean

    Public Sub InsertarFilasEnGrilla(codart As String, descri As String, precio As Double, _
                                           cantidad As Double, total As Double, codbarra As String, costo As Double, _
                                           ByVal grilla As DataGridView)
        Dim i As Integer
        Dim dt As New DataGridViewRow

        i = grilla.Rows.Count
        dt.CreateCells(grilla)
        dt.Cells(0).Value = codart
        dt.Cells(1).Value = descri
        dt.Cells(2).Value = precio
        dt.Cells(3).Value = cantidad
        dt.Cells(4).Value = total
        dt.Cells(5).Value = codbarra
        dt.Cells(6).Value = costo
        grilla.Rows.Insert(i, dt)

    End Sub

    Public Function ConvertirPrecio(PrecioAux As String) As Double
        Dim decimales As Double
        Dim ParteEntera As Double

        decimales = Val(Mid(PrecioAux, Len(PrecioAux) - 1, Len(PrecioAux)))
        ParteEntera = Val(Mid(PrecioAux, 1, 3))

        decimales = decimales / 100

        ConvertirPrecio = ParteEntera + decimales
    End Function

    Public Function obtenerNroComprobante() As Integer
        Dim objStreamReader As StreamReader

        Try
            objStreamReader = New StreamReader(My.Settings.rutaArchivos & "Comprobante.txt")

            obtenerNroComprobante = objStreamReader.ReadLine

            objStreamReader.Close()

            Dim objStreamWriter As StreamWriter

            objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "Comprobante.txt", False)

            objStreamWriter.WriteLine(obtenerNroComprobante + 1)

            objStreamWriter.Close()

        Catch ex As FileNotFoundException
            Dim objStreamWriter As StreamWriter
            objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "Comprobante.txt", True)
            objStreamWriter.Close()
            obtenerNroComprobante()
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Obtener Comprobante" + "|" + ex.Message)
        End Try
    End Function

    Public Function MsgAtencion(strMensaje As String) As MsgBoxStyle
        MsgAtencion = MsgBox(strMensaje, vbCritical + vbOKOnly, "Aviso al operador")
    End Function

    Public Function MsgInformacion(strMensaje As String) As MsgBoxStyle
        MsgInformacion = MsgBox(strMensaje, vbInformation + vbOKOnly, "Aviso al operador")
    End Function

    Public Function MsgPregunta(strMensaje As String) As MsgBoxStyle
        MsgPregunta = MsgBox(strMensaje, vbQuestion + vbYesNoCancel, "Aviso al operador")
    End Function

    Public Function ObtenerArticulos() As List(Of Articulos)
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            ObtenerArticulos = New List(Of Articulos)

            objStreamReader = New StreamReader(My.Settings.rutaArchivos & "Articulos.txt")

            Do While Not objStreamReader.EndOfStream
                Dim art As New Articulos

                strLine = objStreamReader.ReadLine
                art.Codigo = Split(strLine, ";")(0)
                art.Descripcion = Split(strLine, ";")(1)
                art.CodigoBarras = Split(strLine, ";")(2)
                art.PrecioCosto = Split(strLine, ";")(3)
                art.PrecioVenta = Split(strLine, ";")(4)
                'art.IdLista = Split(strLine, ";")(5)
                art.Unidad = Split(strLine, ";")(5)
                art.CostoGranel = Split(strLine, ";")(6)
                art.UnidadGranel = Split(strLine, ";")(7)

                ObtenerArticulos.Add(art)
            Loop

            objStreamReader.Close()
        Catch ex As FileNotFoundException
            Throw New Exception("Error en Modulo General." + " No se encontro el archivo de Articulos" + "|" + ex.Message)
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Obtener Articulos" + "|" + ex.Message)
        End Try
    End Function

    Public Function ObtenerClientes() As List(Of Clientes)
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            ObtenerClientes = New List(Of Clientes)

            objStreamReader = New StreamReader(My.Settings.rutaArchivos & "Clientes.txt")

            Do While Not objStreamReader.EndOfStream
                Dim cli As New Clientes

                strLine = objStreamReader.ReadLine
                cli.IdCliente = Split(strLine, ";")(0)
                cli.NombreFantasia = Split(strLine, ";")(1)
                'cli.IdLista = Split(strLine, ";")(2)
                'cli.ListaDescripcion = Split(strLine, ";")(3)
                cli.IdSucursal = Split(strLine, ";")(2)

                ObtenerClientes.Add(cli)
            Loop

            objStreamReader.Close()
        Catch ex As FileNotFoundException
            Throw New Exception("Error en Modulo General." + " No se encontro el archivo de Clientes" + "|" + ex.Message)
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Obtener Clientes" + "|" + ex.Message)
        End Try
    End Function

    Public Function ObtenerUsuarios(ByVal strNombreUsuario As String) As Usuarios
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            ObtenerUsuarios = New Usuarios

            objStreamReader = New StreamReader(My.Settings.rutaArchivos & "Usuarios.txt")

            Do While Not objStreamReader.EndOfStream

                strLine = objStreamReader.ReadLine
                If Split(strLine, ";")(1).ToUpper = strNombreUsuario.ToUpper Then
                    ObtenerUsuarios.IdUsuario = Split(strLine, ";")(0)
                    ObtenerUsuarios.Usuario = Split(strLine, ";")(1)
                    ObtenerUsuarios.Password = Split(strLine, ";")(2)
                    ObtenerUsuarios.IdSucursal = Split(strLine, ";")(3)
                    Exit Do
                End If

            Loop

            objStreamReader.Close()
        Catch ex As FileNotFoundException
            Throw New Exception("Error en Modulo General." + " No se encontro el archivo de Usuarios" + "|" + ex.Message)
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Obtener Usuarios" + "|" + ex.Message)
        End Try
    End Function

    Public Function ObtenerFormasPago() As List(Of FormasPago)
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            ObtenerFormasPago = New List(Of FormasPago)

            objStreamReader = New StreamReader(My.Settings.rutaArchivos & "FormasPago.txt")

            Do While Not objStreamReader.EndOfStream
                Dim formPago As New FormasPago

                strLine = objStreamReader.ReadLine
                formPago.IdFormaPago = Split(strLine, ";")(0)
                formPago.Descripcion = Split(strLine, ";")(1)

                ObtenerFormasPago.Add(formPago)

            Loop

            objStreamReader.Close()
        Catch ex As FileNotFoundException
            Throw New Exception("Error en Modulo General." + " No se encontro el archivo de Formas de Pago" + "|" + ex.Message)
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Obtener FormasPago" + "|" + ex.Message)
        End Try
    End Function

    Public Function ObtenerRendicion() As List(Of Rendicion)
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            ObtenerRendicion = New List(Of Rendicion)

            objStreamReader = New StreamReader(My.Settings.rutaArchivos & "Rendicion.txt")

            Do While Not objStreamReader.EndOfStream
                Dim rend As New Rendicion

                strLine = objStreamReader.ReadLine
                rend.Fecha = Split(strLine, ";")(0)
                rend.Usuario = Split(strLine, ";")(1)
                rend.Descripcion = Split(strLine, ";")(2)
                rend.Total = Split(strLine, ";")(3)
                rend.Rendido = Split(strLine, ";")(4)
                rend.Diferencia = Split(strLine, ";")(5)
                rend.Comprobantes = Split(strLine, ";")(6)
                rend.Operacion = Split(strLine, ";")(7)

                ObtenerRendicion.Add(rend)
            Loop

            objStreamReader.Close()
        Catch ex As FileNotFoundException
            Throw New Exception("Error en Modulo General." + " No se encontro el archivo de Rendicion" + "|" + ex.Message)
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Obtener Rendicion" + "|" + ex.Message)
        End Try
    End Function

    Public Function ObtenerCajaDiaria() As List(Of CajaDiaria)
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            ObtenerCajaDiaria = New List(Of CajaDiaria)

            objStreamReader = New StreamReader(My.Settings.rutaArchivos & "CajaDiaria.txt")

            Do While Not objStreamReader.EndOfStream
                Dim caja As New CajaDiaria

                strLine = objStreamReader.ReadLine
                caja.FechaHora = Split(strLine, ";")(0)
                caja.Importe = Split(strLine, ";")(1)
                caja.Operacion = Split(strLine, ";")(2)
                caja.Usuario = Split(strLine, ";")(3)
                caja.Sucursal = Split(strLine, ";")(4)

                ObtenerCajaDiaria.Add(caja)
            Loop

            objStreamReader.Close()

        Catch ex As FileNotFoundException
            Dim objStreamWriter As StreamWriter
            objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "CajaDiaria.txt", True)
            objStreamWriter.Close()
            ObtenerCajaDiaria()
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Obtener CajaDiaria" + "|" + ex.Message)
        End Try
    End Function

    Public Function ObtenerComprobanteVenta() As List(Of ComprobanteVenta)
        Dim objStreamReader As StreamReader
        Dim strLine As String

        Try
            ObtenerComprobanteVenta = New List(Of ComprobanteVenta)

            objStreamReader = New StreamReader(My.Settings.rutaArchivos & "ComprobanteVenta.txt", System.Text.ASCIIEncoding.ASCII)

            Do While Not objStreamReader.EndOfStream
                Dim pedidoPendiente As New ComprobanteVenta

                strLine = objStreamReader.ReadLine

                pedidoPendiente.Comprobante = Split(strLine, ";")(0)
                pedidoPendiente.ComprobanteFiscal = Split(strLine, ";")(1)
                pedidoPendiente.ComprobanteTipo = Split(strLine, ";")(2)
                pedidoPendiente.IdCliente = Split(strLine, ";")(3)
                pedidoPendiente.FechaEmision = Split(strLine, ";")(4)
                pedidoPendiente.CondicionIva = Split(strLine, ";")(5)
                pedidoPendiente.PrecioBase = Split(strLine, ";")(6)
                pedidoPendiente.PorcentajeIva = Split(strLine, ";")(7)
                pedidoPendiente.TotalComprobante = Split(strLine, ";")(8)
                pedidoPendiente.IdUsuario = Split(strLine, ";")(9)
                pedidoPendiente.Origen = Split(strLine, ";")(10)
                pedidoPendiente.Descuento = Split(strLine, ";")(11)
                pedidoPendiente.TotalDescuento = Split(strLine, ";")(12)
                pedidoPendiente.IdFormaPago = Split(strLine, ";")(13)
                pedidoPendiente.FormaPago = Split(strLine, ";")(14)

                ObtenerComprobanteVenta.Add(pedidoPendiente)

            Loop

            objStreamReader.Close()
        Catch ex As FileNotFoundException
            Throw New Exception("Error en Modulo General." + " No se encontro el archivo de Comprobante Ventas" + "|" + ex.Message)
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Obtener ComprobanteVenta" + "|" + ex.Message)
        End Try
    End Function

    Public Function ObtenerComprobanteVentaDetalle() As List(Of ComprobanteVentaDetalle)
        Dim objStreamReader As StreamReader
        Dim strLine As String

        Try
            ObtenerComprobanteVentaDetalle = New List(Of ComprobanteVentaDetalle)

            objStreamReader = New StreamReader(My.Settings.rutaArchivos & "ComprobanteVentaDetalle.txt", System.Text.ASCIIEncoding.ASCII)

            Do While Not objStreamReader.EndOfStream
                Dim compVentDetalle As New ComprobanteVentaDetalle

                strLine = objStreamReader.ReadLine

                compVentDetalle.Comprobante = Split(strLine, ";")(0)
                compVentDetalle.CodigoArticulo = Split(strLine, ";")(1)
                compVentDetalle.DescripcionArticulo = Split(strLine, ";")(2)
                compVentDetalle.Cantidad = Split(strLine, ";")(3)
                compVentDetalle.PrecioUnitario = Split(strLine, ";")(4)
                compVentDetalle.PrecioTotal = Split(strLine, ";")(5)

                ObtenerComprobanteVentaDetalle.Add(compVentDetalle)

            Loop

            objStreamReader.Close()

        Catch ex As FileNotFoundException
            Throw New Exception("Error en Modulo General." + " No se encontro el archivo de Comprobante Venta Detalle" + "|" + ex.Message)
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Obtener ComprobanteVentaDetalle" + "|" + ex.Message)
        End Try
    End Function

    Public Sub grabarAperturaCaja()
        Dim objStreamWriter As StreamWriter

        Try
            objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "CajaDiaria.txt", True)

            objStreamWriter.WriteLine(Date.Now & ";" & 0 & ";" & CajaDiaria.tiposOperacion.aperturaCaja & ";" & idUsuario & ";" & My.Settings.sucursal)

            objStreamWriter.Close()
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Grabar Apertura de Caja" + "|" + ex.Message)
        End Try
    End Sub

    Public Sub grabarIngresoDinero(ByVal importe As Double)
        Dim objStreamWriter As StreamWriter

        Try
            objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "CajaDiaria.txt", True)

            objStreamWriter.WriteLine(Date.Now & ";" & importe & ";" & CajaDiaria.tiposOperacion.ingresoDinero & ";" & idUsuario & ";" & My.Settings.sucursal)

            objStreamWriter.Close()
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Grabar Ingreso de Dinero" + "|" + ex.Message)
        End Try
    End Sub

    Public Sub grabarRetiroDinero(ByVal importe As Double)
        Dim objStreamWriter As StreamWriter

        Try
            objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "CajaDiaria.txt", True)

            objStreamWriter.WriteLine(Date.Now & ";" & importe & ";" & CajaDiaria.tiposOperacion.retiroDinero & ";" & idUsuario & ";" & My.Settings.sucursal)

            objStreamWriter.Close()
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Grabar Retiro de Dinero" + "|" + ex.Message)
        End Try
    End Sub

    Public Sub grabarCierreCaja()
        Dim objStreamWriter As StreamWriter

        Try
            objStreamWriter = New StreamWriter(My.Settings.rutaArchivos & "CajaDiaria.txt", True)

            objStreamWriter.WriteLine(Date.Now & ";" & 0 & ";" & CajaDiaria.tiposOperacion.cierreCaja & ";" & idUsuario & ";" & My.Settings.sucursal)

            objStreamWriter.Close()
        Catch ex As Exception
            Throw New Exception("Error en Modulo General." + " Grabar Cierre de Caja" + "|" + ex.Message)
        End Try
    End Sub

    Function existeArchivo(ByVal strArchivo As String) As Boolean
        Try

            existeArchivo = System.IO.File.Exists(My.Settings.rutaArchivos & strArchivo)

        Catch ex As Exception
            existeArchivo = False
        End Try
    End Function

    Function ControlarCierreRealizado() As Boolean

    End Function

    Public Function Decript(pass As String) As String

        Dim pos As Long
        Dim Key As Long
        Dim temp As String
        Dim i As Long
        Dim temp1 As String = ""

        pos = Int(Asc(Mid(pass, 1, 1))) - 150
        Key = Asc(Mid(pass, pos + 2, 1))
        temp = Mid(pass, 1, pos + 1)
        pass = temp & Mid(pass, pos + 3, Len(pass))
        pass = Mid(pass, 2, Len(pass))
        For i = 1 To Len(pass)
            If Asc(Mid(pass, i, 1)) <> Key Then
                temp1 = temp1 & Chr(Key - CInt(Asc(Mid(pass, i, 1))))
            Else
                temp1 = temp1 & Chr(Asc(Mid(pass, i, 1)))
            End If
        Next
        Decript = temp1
    End Function

End Module
