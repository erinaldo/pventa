Public Class PedidosPendientes
    Private intNroComprobante As Integer
    Private strFormaPago As String
    Private dblImporte As Double

    Public Property Comprobante() As Integer
        Get
            Return intNroComprobante
        End Get
        Set(ByVal value As Integer)
            intNroComprobante = value
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

    Public Property Importe() As Double
        Get
            Return dblImporte
        End Get
        Set(ByVal value As Double)
            dblImporte = value
        End Set
    End Property
End Class
