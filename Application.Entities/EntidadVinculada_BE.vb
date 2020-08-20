Imports System.Runtime.Serialization

<DataContract()>
Public Class EntidadVinculada_BE
    Private _ENTC_Codigo As Int32
    Private _ENTC_CodigoVinculada As Int32
    Private _ENTC_DocIdenVinculada As String
    Private _NombreContacto As String
    Private _CorreoContacto As String
    Private _CodigoTipoVinculacion As String
    Private _CodigoTipoVigencia As String
    Private _VigenciaDesde As Nullable(Of DateTime)
    Private _VigenciaHasta As Nullable(Of DateTime)
    Private _Estado As String
    Private _AUDI_UsrCrea As String
    Private _AUDI_FecCrea As DateTime
    Private _AUDI_UsrMod As String
    Private _AUDI_FecMod As DateTime

    Public Sub New()
    End Sub
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
    Public Property ENTC_CodigoVinculada() As Int32
        Get
            Return _ENTC_CodigoVinculada
        End Get

        Set(ByVal value As Int32)
            _ENTC_CodigoVinculada = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_DocIdenVinculada() As String
        Get
            Return _ENTC_DocIdenVinculada
        End Get

        Set(ByVal value As String)
            _ENTC_DocIdenVinculada = value
        End Set
    End Property
    <DataMember()>
    Public Property NombreContacto() As String
        Get
            Return _NombreContacto
        End Get

        Set(ByVal value As String)
            _NombreContacto = value
        End Set
    End Property
    <DataMember()>
    Public Property CorreoContacto() As String
        Get
            Return _CorreoContacto
        End Get

        Set(ByVal value As String)
            _CorreoContacto = value
        End Set
    End Property
    <DataMember()>
    Public Property CodigoTipoVinculacion() As String
        Get
            Return _CodigoTipoVinculacion
        End Get

        Set(ByVal value As String)
            _CodigoTipoVinculacion = value
        End Set
    End Property
    <DataMember()>
    Public Property CodigoTipoVigencia() As String
        Get
            Return _CodigoTipoVigencia
        End Get

        Set(ByVal value As String)
            _CodigoTipoVigencia = value
        End Set
    End Property
    <DataMember()>
    Public Property VigenciaDesde() As Nullable(Of DateTime)
        Get
            Return _VigenciaDesde
        End Get

        Set(ByVal value As Nullable(Of DateTime))
            _VigenciaDesde = value
        End Set
    End Property
    <DataMember()>
    Public Property VigenciaHasta() As Nullable(Of DateTime)
        Get
            Return _VigenciaHasta
        End Get

        Set(ByVal value As Nullable(Of DateTime))
            _VigenciaHasta = value
        End Set
    End Property
    <DataMember()>
    Public Property Estado() As String
        Get
            Return _Estado
        End Get

        Set(ByVal value As String)
            _Estado = value
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
