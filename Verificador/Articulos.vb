Public Class Articulos
    Private intCodigo As Integer
    Private strDescripcion As String
    Private strCodBar As String
    Private dblPrecioCosto As Double
    Private dblPrecioVenta As Double
    'Private intListaPrecios As Double
    Private intUnidad As Integer
    Private dblCostoGranel As Double
    Private dblUnidadGranel As Double

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

    Public Property PrecioCosto() As Double
        Get
            Return dblPrecioCosto
        End Get
        Set(ByVal value As Double)
            dblPrecioCosto = value
        End Set
    End Property

    Public Property PrecioVenta() As Double
        Get
            Return dblPrecioVenta
        End Get
        Set(ByVal value As Double)
            dblPrecioVenta = value
        End Set
    End Property

    'Public Property IdLista() As Integer
    '    Get
    '        Return intListaPrecios
    '    End Get
    '    Set(ByVal value As Integer)
    '        intListaPrecios = value
    '    End Set
    'End Property

    Public Property Unidad() As Integer
        Get
            Return intUnidad
        End Get
        Set(ByVal value As Integer)
            intUnidad = value
        End Set
    End Property

    Public Property CostoGranel() As Double
        Get
            Return dblCostoGranel
        End Get
        Set(ByVal value As Double)
            dblCostoGranel = value
        End Set
    End Property

    Public Property UnidadGranel() As Double
        Get
            Return dblUnidadGranel
        End Get
        Set(ByVal value As Double)
            dblUnidadGranel = value
        End Set
    End Property
End Class
