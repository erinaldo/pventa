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

        objStreamReader = New StreamReader("C:\Comprobante.txt")

        obtenerNroComprobante = objStreamReader.ReadLine

        objStreamReader.Close()

        Dim objStreamWriter As StreamWriter

        objStreamWriter = New StreamWriter("C:\Comprobante.txt", False)

        objStreamWriter.WriteLine(obtenerNroComprobante + 1)

        objStreamWriter.Close()

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

    Public Function ObtenerClientes() As List(Of Clientes)
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            ObtenerClientes = New List(Of Clientes)

            objStreamReader = New StreamReader("C:\Clientes.txt")

            Do While Not objStreamReader.EndOfStream
                Dim cli As New Clientes

                strLine = objStreamReader.ReadLine
                cli.IdCliente = Split(strLine, ";")(0)
                cli.NombreFantasia = Split(strLine, ";")(1)
                cli.IdLista = Split(strLine, ";")(2)
                cli.ListaDescripcion = Split(strLine, ";")(3)
                cli.IdSucursal = Split(strLine, ";")(4)

                ObtenerClientes.Add(cli)

            Loop

        Catch ex As Exception
            Throw New Exception("Error en WFL" + "Obtener Lista" + "|" + ex.Message)
        End Try
    End Function

    Public Function ObtenerUsuarios(ByVal strNombreUsuario As String) As Usuarios
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            ObtenerUsuarios = New Usuarios

            objStreamReader = New StreamReader("C:\Usuarios.txt")

            Do While Not objStreamReader.EndOfStream

                strLine = objStreamReader.ReadLine
                If Split(strLine, ";")(1) = strNombreUsuario Then
                    ObtenerUsuarios.IdUsuario = Split(strLine, ";")(0)
                    ObtenerUsuarios.Usuario = Split(strLine, ";")(1)
                    ObtenerUsuarios.Password = Split(strLine, ";")(2)
                    ObtenerUsuarios.IdSucursal = Split(strLine, ";")(3)
                    Exit Do
                End If

            Loop

        Catch ex As Exception
            Throw New Exception("Error en WFL" + "Obtener Lista" + "|" + ex.Message)
        End Try
    End Function

    Public Function ObtenerFormasPago() As List(Of FormasPago)
        Try
            Dim objStreamReader As StreamReader
            Dim strLine As String

            ObtenerFormasPago = New List(Of FormasPago)

            objStreamReader = New StreamReader("C:\FormasPago.txt")

            Do While Not objStreamReader.EndOfStream
                Dim formPago As New FormasPago

                strLine = objStreamReader.ReadLine
                formPago.IdFormaPago = Split(strLine, ";")(0)
                formPago.Descripcion = Split(strLine, ";")(1)

                ObtenerFormasPago.Add(formPago)

            Loop

        Catch ex As Exception
            Throw New Exception("Error en WFL" + "Obtener Lista" + "|" + ex.Message)
        End Try
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
