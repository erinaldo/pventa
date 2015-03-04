Public Class Clientes

    Private intIdCliente As Integer
    Private strNombreFantasia As String
    Private intIdLista As Integer
    Private strListaDescripcion As String
    Private intIdSucursal As Integer

    Public Property IdCliente() As Integer
        Get
            Return intIdCliente
        End Get
        Set(ByVal value As Integer)
            intIdCliente = value
        End Set
    End Property

    Public Property NombreFantasia() As String
        Get
            Return strNombreFantasia
        End Get
        Set(ByVal value As String)
            strNombreFantasia = value
        End Set
    End Property

    Public Property IdLista() As Integer
        Get
            Return intIdLista
        End Get
        Set(ByVal value As Integer)
            intIdLista = value
        End Set
    End Property

    Public Property ListaDescripcion() As String
        Get
            Return strListaDescripcion
        End Get
        Set(ByVal value As String)
            strListaDescripcion = value
        End Set
    End Property

    Public Property IdSucursal() As Integer
        Get
            Return intIdSucursal
        End Get
        Set(ByVal value As Integer)
            intIdSucursal = value
        End Set
    End Property

End Class
