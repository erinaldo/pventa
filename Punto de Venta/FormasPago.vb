Public Class FormasPago

    Private intIdFormaPago As Integer
    Private strDescripcionFormaPago As String

    Public Property Descripcion() As String
        Get
            Return strDescripcionFormaPago
        End Get
        Set(ByVal value As String)
            strDescripcionFormaPago = value
        End Set
    End Property

    Public Property IdFormaPago() As Integer
        Get
            Return intIdFormaPago
        End Get
        Set(ByVal value As Integer)
            intIdFormaPago = value
        End Set
    End Property

End Class
