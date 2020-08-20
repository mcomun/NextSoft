Imports System.Runtime.Serialization

<DataContract()>
Public Class COM_Sobrestadia_BE
    Private _SOES_Codigo As Int32
    Private _ENTC_Codigo As Int32
    Private _CONT_Codigo As Int32
    Private _SOES_ServiceContract As String
    Private _SOES_FecIni As Nullable(Of Date)
    Private _SOES_FecFin As Nullable(Of Date)
    Private _SOES_Activo As Boolean
    Private _SOES_Observaciones As String
    Private _AUDI_UsrCrea As String
    Private _AUDI_FecCrea As DateTime
    Private _AUDI_UsrMod As String
    Private _AUDI_FecMod As DateTime

    Public Sub New()
    End Sub
    <DataMember()>
    Public Property SOES_Codigo() As Int32
        Get
            Return _SOES_Codigo
        End Get

        Set(ByVal value As Int32)
            _SOES_Codigo = value
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
    Public Property CONT_Codigo() As Int32
        Get
            Return _CONT_Codigo
        End Get

        Set(ByVal value As Int32)
            _CONT_Codigo = value
        End Set
    End Property
    <DataMember()>
    Public Property SOES_ServiceContract() As String
        Get
            Return _SOES_ServiceContract
        End Get

        Set(ByVal value As String)
            _SOES_ServiceContract = value
        End Set
    End Property
    <DataMember()>
    Public Property SOES_FecIni() As Nullable(Of Date)
        Get
            Return _SOES_FecIni
        End Get

        Set(ByVal value As Nullable(Of Date))
            _SOES_FecIni = value
        End Set
    End Property
    <DataMember()>
    Public Property SOES_FecFin() As Nullable(Of Date)
        Get
            Return _SOES_FecFin
        End Get

        Set(ByVal value As Nullable(Of Date))
            _SOES_FecFin = value
        End Set
    End Property
    <DataMember()>
    Public Property SOES_Activo() As Boolean
        Get
            Return _SOES_Activo
        End Get

        Set(ByVal value As Boolean)
            _SOES_Activo = value
        End Set
    End Property
    <DataMember()>
    Public Property SOES_Observaciones() As String
        Get
            Return _SOES_Observaciones
        End Get

        Set(ByVal value As String)
            _SOES_Observaciones = value
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
