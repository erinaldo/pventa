Public Class ComprobanteVentaDetalle

    Private intNroComprobante As Integer
    Private intIdSucursal As Integer
    Private intIdPuntoVenta As Integer
    Private intCodArt As Integer
    Private strDescripcionArticulo As String
    Private intCantidad As Integer
    Private dblPrecioUnitario As Double
    Private dblPrecioTotal As Double

    Public Property Comprobante() As Integer
        Get
            Return intNroComprobante
        End Get
        Set(ByVal value As Integer)
            intNroComprobante = value
        End Set
    End Property

    Public Property Sucursal() As Integer
        Get
            Return intIdSucursal
        End Get
        Set(ByVal value As Integer)
            intIdSucursal = value
        End Set
    End Property

    Public Property PuntoVenta() As Integer
        Get
            Return intIdPuntoVenta
        End Get
        Set(ByVal value As Integer)
            intIdPuntoVenta = value
        End Set
    End Property

    Public Property CodigoArticulo() As Integer
        Get
            Return intCodArt
        End Get
        Set(ByVal value As Integer)
            intCodArt = value
        End Set
    End Property

    Public Property DescripcionArticulo() As String
        Get
            Return strDescripcionArticulo
        End Get
        Set(ByVal value As String)
            strDescripcionArticulo = value
        End Set
    End Property

    Public Property Cantidad() As Integer
        Get
            Return intCantidad
        End Get
        Set(ByVal value As Integer)
            intCantidad = value
        End Set
    End Property

    Public Property PrecioUnitario() As Double
        Get
            Return dblPrecioUnitario
        End Get
        Set(ByVal value As Double)
            dblPrecioUnitario = value
        End Set
    End Property

    Public Property PrecioTotal() As Double
        Get
            Return dblPrecioTotal
        End Get
        Set(ByVal value As Double)
            dblPrecioTotal = value
        End Set
    End Property

End Class
