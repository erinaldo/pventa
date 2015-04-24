Public Class ComprobanteVenta
    Private intNroComprobante As Integer
    Private intNroComprobanteFiscal As String
    Private intNroComprobanteTipo As Integer
    Private intIdCliente As Integer
    Private dtmFechaEmision As Date
    Private intCondicionIva As Integer
    Private dblPrecioBase As Double
    Private dblPorcentajeIva As Double
    Private dblTotalComprobante As Double
    Private intIdUsuario As Integer
    Private strOrigen As String
    Private dblDescuento As Double
    Private dblTotalDescuento As Double
    Private intIdSucursal As Integer
    Private intIdPuntoVenta As Integer

    Public Property Comprobante() As Integer
        Get
            Return intNroComprobante
        End Get
        Set(ByVal value As Integer)
            intNroComprobante = value
        End Set
    End Property

    Public Property ComprobanteFiscal() As String
        Get
            Return intNroComprobanteFiscal
        End Get
        Set(ByVal value As String)
            intNroComprobanteFiscal = value
        End Set
    End Property

    Public Property ComprobanteTipo() As Integer
        Get
            Return intNroComprobanteTipo
        End Get
        Set(ByVal value As Integer)
            intNroComprobanteTipo = value
        End Set
    End Property

    Public Property IdCliente() As Integer
        Get
            Return intIdCliente
        End Get
        Set(ByVal value As Integer)
            intIdCliente = value
        End Set
    End Property

    Public Property FechaEmision() As Date
        Get
            Return dtmFechaEmision
        End Get
        Set(ByVal value As Date)
            dtmFechaEmision = value
        End Set
    End Property

    Public Property CondicionIva() As Integer
        Get
            Return intCondicionIva
        End Get
        Set(ByVal value As Integer)
            intCondicionIva = value
        End Set
    End Property

    Public Property PrecioBase() As Double
        Get
            Return dblPrecioBase
        End Get
        Set(ByVal value As Double)
            dblPrecioBase = value
        End Set
    End Property

    Public Property PorcentajeIva() As Double
        Get
            Return dblPorcentajeIva
        End Get
        Set(ByVal value As Double)
            dblPorcentajeIva = value
        End Set
    End Property

    Public Property TotalComprobante() As Double
        Get
            Return dblTotalComprobante
        End Get
        Set(ByVal value As Double)
            dblTotalComprobante = value
        End Set
    End Property

    Public Property IdUsuario() As Integer
        Get
            Return intIdUsuario
        End Get
        Set(ByVal value As Integer)
            intIdUsuario = value
        End Set
    End Property

    Public Property Origen() As String
        Get
            Return strOrigen
        End Get
        Set(ByVal value As String)
            strOrigen = value
        End Set
    End Property

    Public Property Descuento() As Double
        Get
            Return dblDescuento
        End Get
        Set(ByVal value As Double)
            dblDescuento = value
        End Set
    End Property

    Public Property TotalDescuento() As Double
        Get
            Return dblTotalDescuento
        End Get
        Set(ByVal value As Double)
            dblTotalDescuento = value
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

    Public Property IdPuntoVenta() As Integer
        Get
            Return intIdPuntoVenta
        End Get
        Set(ByVal value As Integer)
            intIdPuntoVenta = value
        End Set
    End Property

End Class
