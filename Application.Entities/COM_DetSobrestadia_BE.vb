Imports System.Runtime.Serialization

<DataContract()>
Public Class COM_DetSobrestadia_BE
    Private _SOES_Codigo As Int32
    Private _SOES_Item As Int32
    Private _PACK_Codigo As Int32
    Private _PUER_CodDestino As Int32
    Private _SOES_DiasSobrestadiaLinea As Int16
    Private _SOES_DiasSobrestadiaCliente As Int16
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
        Public Property SOES_Item() As Int32
        Get
            Return _SOES_Item
        End Get

        Set(ByVal value As Int32)
            _SOES_Item = value
        End Set
    End Property
    <DataMember()>
        Public Property PACK_Codigo() As Int32
        Get
            Return _PACK_Codigo
        End Get

        Set(ByVal value As Int32)
            _PACK_Codigo = value
        End Set
    End Property
    <DataMember()>
        Public Property PUER_CodDestino() As Int32
        Get
            Return _PUER_CodDestino
        End Get

        Set(ByVal value As Int32)
            _PUER_CodDestino = value
        End Set
    End Property
    Public Property SOES_DiasSobrestadiaLinea() As Int16
        Get
            Return _SOES_DiasSobrestadiaLinea
        End Get

        Set(ByVal value As Int16)
            _SOES_DiasSobrestadiaLinea = value
        End Set
    End Property
    <DataMember()>
        Public Property SOES_DiasSobrestadiaCliente() As Int16
        Get
            Return _SOES_DiasSobrestadiaCliente
        End Get

        Set(ByVal value As Int16)
            _SOES_DiasSobrestadiaCliente = value
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
