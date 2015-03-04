Public Class Articulos
    Private intCodigo As Integer
    Private strDescripcion As String
    Private strCodBar As String
    Private dblPrecio As Double


    Public Property Codigo() As Integer
        Get
            Return intCodigo
        End Get
        Set(ByVal value As Integer)
            intCodigo = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return strDescripcion
        End Get
        Set(ByVal value As String)
            strDescripcion = value
        End Set
    End Property

    Public Property CodigoBarras() As String
        Get
            Return strCodBar
        End Get
        Set(ByVal value As String)
            strCodBar = value
        End Set
    End Property

    Public Property Precio() As Double
        Get
            Return dblPrecio
        End Get
        Set(ByVal value As Double)
            dblPrecio = value
        End Set
    End Property



End Class
