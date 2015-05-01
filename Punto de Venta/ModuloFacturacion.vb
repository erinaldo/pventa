Module ModuloFacturacion

    Function BuscarArticulo(ByVal listaArt As List(Of Articulos), ByVal strCodBarra As String, ByVal intIdLista As Integer) As Articulos

        Try

            BuscarArticulo = New Articulos

            'BuscarArticulo = (From art In listaArt
            '                  Where art.CodigoBarras = strCodBarra And art.IdLista = intIdLista
            '                  Select art).First

            BuscarArticulo = (From art In listaArt
                      Where art.CodigoBarras = strCodBarra
                      Select art).First

        Catch ex As Exception
            BuscarArticulo = Nothing
        End Try
    End Function

End Module
