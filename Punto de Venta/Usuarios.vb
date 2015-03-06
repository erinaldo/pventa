Public Class Usuarios
    Private intIdUsuario As Integer
    Private strUsuario As String
    Private strPassword As String
    Private intIdSucursal As Integer

    Public Property IdSucursal() As Integer
        Get
            Return intIdSucursal
        End Get
        Set(ByVal value As Integer)
            intIdSucursal = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return strPassword
        End Get
        Set(ByVal value As String)
            strPassword = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return strUsuario
        End Get
        Set(ByVal value As String)
            strUsuario = value
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

End Class
