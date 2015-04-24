Public Class Pagos

    Private intIdPago As Integer
    Private dblMonto As Double
    Private strDescripcionPago As String
    Private dblAbonado As Double
    Private intIdSucursal As Integer
    Private intIdPuntoVenta As Integer
    Private intNroComprobante As Integer

    Public Property Comprobante() As Integer
        Get
            Return intNroComprobante
        End Get
        Set(ByVal value As Integer)
            intNroComprobante = value
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

    Public Property Sucursal() As Integer
        Get
            Return intIdSucursal
        End Get
        Set(ByVal value As Integer)
            intIdSucursal = value
        End Set
    End Property

    Public Property Abonado() As Double
        Get
            Return dblAbonado
        End Get
        Set(ByVal value As Double)
            dblAbonado = value
        End Set
    End Property

    Public Property DescripcionPago() As String
        Get
            Return strDescripcionPago
        End Get
        Set(ByVal value As String)
            strDescripcionPago = value
        End Set
    End Property

    Public Property Monto() As Double
        Get
            Return dblMonto
        End Get
        Set(ByVal value As Double)
            dblMonto = value
        End Set
    End Property

    Public Property IdPago() As Integer
        Get
            Return intIdPago
        End Get
        Set(ByVal value As Integer)
            intIdPago = value
        End Set
    End Property



End Class
