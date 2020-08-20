Imports System.Runtime.Serialization

<DataContract()>
Public Class EntidadRegistro_BE
    Private _REGI_Codigo As Int32
    Private _ENTC_Codigo As Int32
    Private _TIPO_CodTDI As String
    Private _ENTC_DocIden As String
    Private _ENTC_RazonSocial As String
    Private _ENTC_EMail As String
    Private _ENTC_EmailReceptorFE As String
    Private _ENTC_Telef1 As String
    Private _ENTC_Origen As String
    Private _REGI_Estado As String
    Private _AUDI_UsrCrea As String
    Private _AUDI_FecCrea As DateTime
    Private _AUDI_UsrMod As String
    Private _AUDI_FecMod As DateTime

    Public Sub New()
    End Sub
    <DataMember()>
    Public Property REGI_Codigo() As Int32
        Get
            Return _REGI_Codigo
        End Get

        Set(ByVal value As Int32)
            _REGI_Codigo = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_Codigo() As Int32
        Get
            Return _ENTC_Codigo
        End Get

        Set(ByVal value As Int32)
            _ENTC_Codigo = value
        End Set
    End Property
    <DataMember()>
    Public Property TIPO_CodTDI() As String
        Get
            Return _TIPO_CodTDI
        End Get

        Set(ByVal value As String)
            _TIPO_CodTDI = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_DocIden() As String
        Get
            Return _ENTC_DocIden
        End Get

        Set(ByVal value As String)
            _ENTC_DocIden = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_RazonSocial() As String
        Get
            Return _ENTC_RazonSocial
        End Get

        Set(ByVal value As String)
            _ENTC_RazonSocial = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_EMail() As String
        Get
            Return _ENTC_EMail
        End Get

        Set(ByVal value As String)
            _ENTC_EMail = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_EmailReceptorFE() As String
        Get
            Return _ENTC_EmailReceptorFE
        End Get

        Set(ByVal value As String)
            _ENTC_EmailReceptorFE = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_Telef1() As String
        Get
            Return _ENTC_Telef1
        End Get

        Set(ByVal value As String)
            _ENTC_Telef1 = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_Origen() As String
        Get
            Return _ENTC_Origen
        End Get

        Set(ByVal value As String)
            _ENTC_Origen = value
        End Set
    End Property
    <DataMember()>
    Public Property REGI_Estado() As String
        Get
            Return _REGI_Estado
        End Get

        Set(ByVal value As String)
            _REGI_Estado = value
        End Set
    End Property
    <DataMember()>
    Public Property AUDI_UsrCrea() As String
        Get
            Return _AUDI_UsrCrea
        End Get

        Set(ByVal value As String)
            _AUDI_UsrCrea = value
        End Set
    End Property
    <DataMember()>
    Public Property AUDI_FecCrea() As DateTime
        Get
            Return _AUDI_FecCrea
        End Get

        Set(ByVal value As DateTime)
            _AUDI_FecCrea = value
        End Set
    End Property
    <DataMember()>
    Public Property AUDI_UsrMod() As String
        Get
            Return _AUDI_UsrMod
        End Get

        Set(ByVal value As String)
            _AUDI_UsrMod = value
        End Set
    End Property
    <DataMember()>
    Public Property AUDI_FecMod() As DateTime
        Get
            Return _AUDI_FecMod
        End Get

        Set(ByVal value As DateTime)
            _AUDI_FecMod = value
        End Set
    End Property

End Class
