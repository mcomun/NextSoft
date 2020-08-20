Imports System.Runtime.Serialization

<DataContract()>
Public Class SLI_Cab_Operacion_BE
    Private _COPE_Codigo As Int32
    Private _COPE_NumDoc As String
    Private _COPE_FecEmi As DateTime
    Private _COPE_Observacion As String
    Private _COPE_HBL As String
    Private _CCOT_Codigo As Int32
    Private _ENTC_CodCliente As Int32
    Private _ENTC_CodTransporte As Int32
    Private _ENTC_CodAgente As Int32
    Private _CONS_CodEstado As String
    Private _CONS_TabEstado As String
    Private _COPE_Excepcion As Boolean
    Private _COPE_Fob As Decimal
    Private _COPE_Seguro As Decimal
    Private _COPE_Flete As Decimal
    Private _COPE_Cif As Decimal
    Private _COPE_PartArancelaria As Decimal
    Private _COPE_Ipm As Decimal
    Private _COPE_Igv As Decimal
    Private _COPE_Percepcion As Decimal
    Private _COPE_TasaDespacho As Decimal
    Private _COPE_AdValorem As Decimal
    Private _COPE_1erEmbarque As Boolean
    Private _TIPO_TabMND As String
    Private _TIPO_CodMND As String
    Private _CONS_CodCRG As String
    Private _CONS_TabCRG As String
    Private _CCOT_CodAduana As Int32
    Private _CCOT_CodLogistico As Int32
    Private _CCOT_CodTransporte As Int32
    Private _AUDI_UsrCrea As String
    Private _AUDI_FecCrea As DateTime
    Private _AUDI_UsrMod As String
    Private _AUDI_FecMod As DateTime
    Private _COPE_Nave As String
    Private _COPE_Viaje As String
    Private _COPE_MBL As String
    Private _COPE_FechaArribo As DateTime
    Private _COPE_CantidadDias As Int16
    Private _COPE_VentaSada As Boolean
    Private _COPE_Kilos As Decimal
    Private _COPE_Volumen As Decimal
    Private _COPE_PrecioSada As Boolean
    Private _ENTC_CodAgenPort As Int32
    Private _ENTC_CodTermPort As Int32
    Private _ENTC_CodDepTemporal As Int32
    Private _CTAR_Codigo As Int32
    Private _CTAR_Version As Int16

    Public Sub New()
    End Sub

    <DataMember()>
    Public Property COPE_Codigo() As Int32
        Get
            Return _COPE_Codigo
        End Get

        Set(ByVal value As Int32)
            _COPE_Codigo = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_NumDoc() As String
        Get
            Return _COPE_NumDoc
        End Get

        Set(ByVal value As String)
            _COPE_NumDoc = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_FecEmi() As DateTime
        Get
            Return _COPE_FecEmi
        End Get

        Set(ByVal value As DateTime)
            _COPE_FecEmi = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Observacion() As String
        Get
            Return _COPE_Observacion
        End Get

        Set(ByVal value As String)
            _COPE_Observacion = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_HBL() As String
        Get
            Return _COPE_HBL
        End Get

        Set(ByVal value As String)
            _COPE_HBL = value
        End Set
    End Property
    <DataMember()>
    Public Property CCOT_Codigo() As Int32
        Get
            Return _CCOT_Codigo
        End Get

        Set(ByVal value As Int32)
            _CCOT_Codigo = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_CodCliente() As Int32
        Get
            Return _ENTC_CodCliente
        End Get

        Set(ByVal value As Int32)
            _ENTC_CodCliente = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_CodTransporte() As Int32
        Get
            Return _ENTC_CodTransporte
        End Get

        Set(ByVal value As Int32)
            _ENTC_CodTransporte = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_CodAgente() As Int32
        Get
            Return _ENTC_CodAgente
        End Get

        Set(ByVal value As Int32)
            _ENTC_CodAgente = value
        End Set
    End Property
    <DataMember()>
    Public Property CONS_CodEstado() As String
        Get
            Return _CONS_CodEstado
        End Get

        Set(ByVal value As String)
            _CONS_CodEstado = value
        End Set
    End Property
    <DataMember()>
    Public Property CONS_TabEstado() As String
        Get
            Return _CONS_TabEstado
        End Get

        Set(ByVal value As String)
            _CONS_TabEstado = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Excepcion() As Boolean
        Get
            Return _COPE_Excepcion
        End Get

        Set(ByVal value As Boolean)
            _COPE_Excepcion = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Fob() As Decimal
        Get
            Return _COPE_Fob
        End Get

        Set(ByVal value As Decimal)
            _COPE_Fob = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Seguro() As Decimal
        Get
            Return _COPE_Seguro
        End Get

        Set(ByVal value As Decimal)
            _COPE_Seguro = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Flete() As Decimal
        Get
            Return _COPE_Flete
        End Get

        Set(ByVal value As Decimal)
            _COPE_Flete = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Cif() As Decimal
        Get
            Return _COPE_Cif
        End Get

        Set(ByVal value As Decimal)
            _COPE_Cif = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_PartArancelaria() As Decimal
        Get
            Return _COPE_PartArancelaria
        End Get

        Set(ByVal value As Decimal)
            _COPE_PartArancelaria = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Ipm() As Decimal
        Get
            Return _COPE_Ipm
        End Get

        Set(ByVal value As Decimal)
            _COPE_Ipm = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Igv() As Decimal
        Get
            Return _COPE_Igv
        End Get

        Set(ByVal value As Decimal)
            _COPE_Igv = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Percepcion() As Decimal
        Get
            Return _COPE_Percepcion
        End Get

        Set(ByVal value As Decimal)
            _COPE_Percepcion = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_TasaDespacho() As Decimal
        Get
            Return _COPE_TasaDespacho
        End Get

        Set(ByVal value As Decimal)
            _COPE_TasaDespacho = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_AdValorem() As Decimal
        Get
            Return _COPE_AdValorem
        End Get

        Set(ByVal value As Decimal)
            _COPE_AdValorem = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_1erEmbarque() As Boolean
        Get
            Return _COPE_1erEmbarque
        End Get

        Set(ByVal value As Boolean)
            _COPE_1erEmbarque = value
        End Set
    End Property
    <DataMember()>
    Public Property TIPO_TabMND() As String
        Get
            Return _TIPO_TabMND
        End Get

        Set(ByVal value As String)
            _TIPO_TabMND = value
        End Set
    End Property
    <DataMember()>
    Public Property TIPO_CodMND() As String
        Get
            Return _TIPO_CodMND
        End Get

        Set(ByVal value As String)
            _TIPO_CodMND = value
        End Set
    End Property
    <DataMember()>
    Public Property CONS_CodCRG() As String
        Get
            Return _CONS_CodCRG
        End Get

        Set(ByVal value As String)
            _CONS_CodCRG = value
        End Set
    End Property
    <DataMember()>
    Public Property CONS_TabCRG() As String
        Get
            Return _CONS_TabCRG
        End Get

        Set(ByVal value As String)
            _CONS_TabCRG = value
        End Set
    End Property
    <DataMember()>
    Public Property CCOT_CodAduana() As Int32
        Get
            Return _CCOT_CodAduana
        End Get

        Set(ByVal value As Int32)
            _CCOT_CodAduana = value
        End Set
    End Property
    <DataMember()>
    Public Property CCOT_CodLogistico() As Int32
        Get
            Return _CCOT_CodLogistico
        End Get

        Set(ByVal value As Int32)
            _CCOT_CodLogistico = value
        End Set
    End Property
    <DataMember()>
    Public Property CCOT_CodTransporte() As Int32
        Get
            Return _CCOT_CodTransporte
        End Get

        Set(ByVal value As Int32)
            _CCOT_CodTransporte = value
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
    <DataMember()>
    Public Property COPE_Nave() As String
        Get
            Return _COPE_Nave
        End Get

        Set(ByVal value As String)
            _COPE_Nave = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Viaje() As String
        Get
            Return _COPE_Viaje
        End Get

        Set(ByVal value As String)
            _COPE_Viaje = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_MBL() As String
        Get
            Return _COPE_MBL
        End Get

        Set(ByVal value As String)
            _COPE_MBL = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_FechaArribo() As DateTime
        Get
            Return _COPE_FechaArribo
        End Get

        Set(ByVal value As DateTime)
            _COPE_FechaArribo = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_CantidadDias() As Int16
        Get
            Return _COPE_CantidadDias
        End Get

        Set(ByVal value As Int16)
            _COPE_CantidadDias = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_VentaSada() As Boolean
        Get
            Return _COPE_VentaSada
        End Get

        Set(ByVal value As Boolean)
            _COPE_VentaSada = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Kilos() As Decimal
        Get
            Return _COPE_Kilos
        End Get

        Set(ByVal value As Decimal)
            _COPE_Kilos = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_Volumen() As Decimal
        Get
            Return _COPE_Volumen
        End Get

        Set(ByVal value As Decimal)
            _COPE_Volumen = value
        End Set
    End Property
    <DataMember()>
    Public Property COPE_PrecioSada() As Boolean
        Get
            Return _COPE_PrecioSada
        End Get

        Set(ByVal value As Boolean)
            _COPE_PrecioSada = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_CodAgenPort() As Int32
        Get
            Return _ENTC_CodAgenPort
        End Get

        Set(ByVal value As Int32)
            _ENTC_CodAgenPort = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_CodTermPort() As Int32
        Get
            Return _ENTC_CodTermPort
        End Get

        Set(ByVal value As Int32)
            _ENTC_CodTermPort = value
        End Set
    End Property
    <DataMember()>
    Public Property ENTC_CodDepTemporal() As Int32
        Get
            Return _ENTC_CodDepTemporal
        End Get

        Set(ByVal value As Int32)
            _ENTC_CodDepTemporal = value
        End Set
    End Property
    <DataMember()>
    Public Property CTAR_Codigo() As Int32
        Get
            Return _CTAR_Codigo
        End Get

        Set(ByVal value As Int32)
            _CTAR_Codigo = value
        End Set
    End Property
    <DataMember()>
    Public Property CTAR_Version() As Int16
        Get
            Return _CTAR_Version
        End Get

        Set(ByVal value As Int16)
            _CTAR_Version = value
        End Set
    End Property

End Class
