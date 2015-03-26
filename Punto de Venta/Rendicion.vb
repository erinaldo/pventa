Public Class Rendicion

    Private intFecha As Date
    Private id_Usuario As Integer
    Private strDescripcion As String
    Private dblTotal As Double
    Private dblRendido As Double
    Private dblDiferencia As Double
    Private intComprobantes As Double
    Private intOperacion As Double

    Public Property Operacion() As Integer
        Get
            Return intOperacion
        End Get
        Set(ByVal value As Integer)
            intOperacion = value
        End Set
    End Property

    Public Property Comprobantes() As Integer
        Get
            Return intComprobantes
        End Get
        Set(ByVal value As Integer)
            intComprobantes = value
        End Set
    End Property

    Public Property Diferencia() As Double
        Get
            Return dblDiferencia
        End Get
        Set(ByVal value As Double)
            dblDiferencia = value
        End Set
    End Property

    Public Property Rendido() As Double
        Get
            Return dblRendido
        End Get
        Set(ByVal value As Double)
            dblRendido = value
        End Set
    End Property

    Public Property Total() As Double
        Get
            Return dblTotal
        End Get
        Set(ByVal value As Double)
            dblTotal = value
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

    Public Property Usuario() As Integer
        Get
            Return id_Usuario
        End Get
        Set(ByVal value As Integer)
            id_Usuario = value
        End Set
    End Property

    Public Property Fecha() As Date
        Get
            Return intFecha
        End Get
        Set(ByVal value As Date)
            intFecha = value
        End Set
    End Property

End Class
