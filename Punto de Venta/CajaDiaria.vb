Public Class CajaDiaria
    Enum tiposOperacion As Integer
        aperturaCaja = 50
        ingresoDinero = 60
        retiroDinero = 70
        cierreCaja = 80
    End Enum

    Private intNroCaja As Integer
    Private intFechaHora As DateTime
    Private dblImporte As Double
    Private idOperacion As Integer
    Private id_Usuario As Integer
    Private id_Sucursal As Integer
    Private intIdPuntoVenta As Integer

    Public Property NroCaja() As Integer
        Get
            Return intNroCaja
        End Get
        Set(ByVal value As Integer)
            intNroCaja = value
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

    Public Property FechaHora() As DateTime
        Get
            Return intFechaHora
        End Get
        Set(ByVal value As DateTime)
            intFechaHora = value
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

    Public Property Operacion() As tiposOperacion
        Get
            Return idOperacion
        End Get
        Set(ByVal value As tiposOperacion)
            idOperacion = value
        End Set
    End Property

    Public Property Usuario() As Integer
        Get
            Return id_usuario
        End Get
        Set(ByVal value As Integer)
            id_usuario = value
        End Set
    End Property

    Public Property Sucursal() As Integer
        Get
            Return id_Sucursal
        End Get
        Set(ByVal value As Integer)
            id_Sucursal = value
        End Set
    End Property
End Class
