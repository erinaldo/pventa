Public Class CajaDiaria
    Enum tiposOperacion As Integer
        aperturaCaja = 1
        ingresoDinero = 5
        retiroDinero = 6
        cierreCaja = 10
    End Enum

    Private intFechaHora As DateTime
    Private dblImporte As Double
    Private idOperacion As Integer
    Private id_Usuario As Integer
    Private id_Sucursal As Integer

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
