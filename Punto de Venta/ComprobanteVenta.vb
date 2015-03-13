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
    Private intIdFormaPago As Integer
    Private strFormaPago As String
    Private intCondicionVenta As Integer
    Private strRemito As String
    Private dblImpuestos As Double
    Private dblSubtotalImpuestos As Double
    Private dblMontoIva As Double
    Private strNroFactura As String
    Private intPagada As Integer

    Enum FormasPago As Integer
        Efectivo = 1
        TarjetaDebito = 2
        TarjetaCredito = 3
        Cheque = 4
    End Enum

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

    Public Property IdFormaPago() As FormasPago
        Get
            Return intIdFormaPago
        End Get
        Set(ByVal value As FormasPago)
            intIdFormaPago = value
        End Set
    End Property

    Public Property FormaPago() As String
        Get
            Return strFormaPago
        End Get
        Set(ByVal value As String)
            strFormaPago = value
        End Set
    End Property

    Public Property CondicionVenta() As Integer
        Get
            Return intCondicionVenta
        End Get
        Set(ByVal value As Integer)
            intCondicionVenta = value
        End Set
    End Property

    Public Property Remito() As String
        Get
            Return strRemito
        End Get
        Set(ByVal value As String)
            strRemito = value
        End Set
    End Property

    Public Property Impuestos() As Double
        Get
            Return dblImpuestos
        End Get
        Set(ByVal value As Double)
            dblImpuestos = value
        End Set
    End Property

    Public Property SubtotalImpuestos() As Double
        Get
            Return dblSubtotalImpuestos
        End Get
        Set(ByVal value As Double)
            dblSubtotalImpuestos = value
        End Set
    End Property

    Public Property MontoIva() As Double
        Get
            Return dblMontoIva
        End Get
        Set(ByVal value As Double)
            dblMontoIva = value
        End Set
    End Property

    Public Property NroFactura() As String
        Get
            Return strNroFactura
        End Get
        Set(ByVal value As String)
            strNroFactura = value
        End Set
    End Property

    Public Property Pagada() As Integer
        Get
            Return intPagada
        End Get
        Set(ByVal value As Integer)
            intPagada = value
        End Set
    End Property

End Class
