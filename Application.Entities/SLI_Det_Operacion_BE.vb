Imports System.Runtime.Serialization

<DataContract()>
Public Class SLI_Det_Operacion_BE

    Public Sub New()
    End Sub

    Private _DOPE_Item As Int32
    <DataMember()>
    Public Property DOPE_Item() As Int32
        Get
            Return _DOPE_Item
        End Get

        Set(ByVal value As Int32)
            _DOPE_Item = value
        End Set
    End Property

    Private _COPE_Codigo As Int32
    <DataMember()>
    Public Property COPE_Codigo() As Int32
        Get
            Return _COPE_Codigo
        End Get

        Set(ByVal value As Int32)
            _COPE_Codigo = value
        End Set
    End Property

    Private _DTAR_Item As Int16
    <DataMember()>
    Public Property DTAR_Item() As Int16
        Get
            Return _DTAR_Item
        End Get

        Set(ByVal value As Int16)
            _DTAR_Item = value
        End Set
    End Property

    Private _CTAR_Codigo As Int32
    <DataMember()>
    Public Property CTAR_Codigo() As Int32
        Get
            Return _CTAR_Codigo
        End Get

        Set(ByVal value As Int32)
            _CTAR_Codigo = value
        End Set
    End Property

    Private _CTAR_Tipo As String
    <DataMember()>
    Public Property CTAR_Tipo() As String
        Get
            Return _CTAR_Tipo
        End Get

        Set(ByVal value As String)
            _CTAR_Tipo = value
        End Set
    End Property

    Private _PACK_Codigo As Int32
    <DataMember()>
    Public Property PACK_Codigo() As Int32
        Get
            Return _PACK_Codigo
        End Get

        Set(ByVal value As Int32)
            _PACK_Codigo = value
        End Set
    End Property

    Private _CONS_CodBas As String
    <DataMember()>
    Public Property CONS_CodBas() As String
        Get
            Return _CONS_CodBas
        End Get

        Set(ByVal value As String)
            _CONS_CodBas = value
        End Set
    End Property

    Private _CONS_TabBas As String
    <DataMember()>
    Public Property CONS_TabBas() As String
        Get
            Return _CONS_TabBas
        End Get

        Set(ByVal value As String)
            _CONS_TabBas = value
        End Set
    End Property

    Private _DOPE_Cantidad As Int16
    <DataMember()>
    Public Property DOPE_Cantidad() As Int16
        Get
            Return _DOPE_Cantidad
        End Get

        Set(ByVal value As Int16)
            _DOPE_Cantidad = value
        End Set
    End Property

    Private _DOPE_PrecioUnitCosto As Decimal
    <DataMember()>
    Public Property DOPE_PrecioUnitCosto() As Decimal
        Get
            Return _DOPE_PrecioUnitCosto
        End Get

        Set(ByVal value As Decimal)
            _DOPE_PrecioUnitCosto = value
        End Set
    End Property

    Private _DOPE_PrecioTotCosto As Decimal
    <DataMember()>
    Public Property DOPE_PrecioTotCosto() As Decimal
        Get
            Return _DOPE_PrecioTotCosto
        End Get

        Set(ByVal value As Decimal)
            _DOPE_PrecioTotCosto = value
        End Set
    End Property

    Private _DOPE_PrecioUnitVta As Decimal
    <DataMember()>
    Public Property DOPE_PrecioUnitVta() As Decimal
        Get
            Return _DOPE_PrecioUnitVta
        End Get

        Set(ByVal value As Decimal)
            _DOPE_PrecioUnitVta = value
        End Set
    End Property

    Private _DOPE_PrecioTotVta As Decimal
    <DataMember()>
    Public Property DOPE_PrecioTotVta() As Decimal
        Get
            Return _DOPE_PrecioTotVta
        End Get

        Set(ByVal value As Decimal)
            _DOPE_PrecioTotVta = value
        End Set
    End Property

    Private _DOPE_Minimo As Decimal
    <DataMember()>
    Public Property DOPE_Minimo() As Decimal
        Get
            Return _DOPE_Minimo
        End Get

        Set(ByVal value As Decimal)
            _DOPE_Minimo = value
        End Set
    End Property

    Private _DOPE_Peso As Decimal
    <DataMember()>
    Public Property DOPE_Peso() As Decimal
        Get
            Return _DOPE_Peso
        End Get

        Set(ByVal value As Decimal)
            _DOPE_Peso = value
        End Set
    End Property

    Private _DOPE_Volumen As Decimal
    <DataMember()>
    Public Property DOPE_Volumen() As Decimal
        Get
            Return _DOPE_Volumen
        End Get

        Set(ByVal value As Decimal)
            _DOPE_Volumen = value
        End Set
    End Property

    Private _AUDI_UsrCrea As String
    <DataMember()>
    Public Property AUDI_UsrCrea() As String
        Get
            Return _AUDI_UsrCrea
        End Get

        Set(ByVal value As String)
            _AUDI_UsrCrea = value
        End Set
    End Property

    Private _AUDI_FecCrea As DateTime
    <DataMember()>
    Public Property AUDI_FecCrea() As DateTime
        Get
            Return _AUDI_FecCrea
        End Get

        Set(ByVal value As DateTime)
            _AUDI_FecCrea = value
        End Set
    End Property

    Private _USR_UsrMod As String
    <DataMember()>
    Public Property USR_UsrMod() As String
        Get
            Return _USR_UsrMod
        End Get

        Set(ByVal value As String)
            _USR_UsrMod = value
        End Set
    End Property

    Private _AUDI_FecMod As DateTime
    <DataMember()>
    Public Property AUDI_FecMod() As DateTime
        Get
            Return _AUDI_FecMod
        End Get

        Set(ByVal value As DateTime)
            _AUDI_FecMod = value
        End Set
    End Property

    Private _DOPE_CostoSada As Decimal
    <DataMember()>
    Public Property DOPE_CostoSada() As Decimal
        Get
            Return _DOPE_CostoSada
        End Get

        Set(ByVal value As Decimal)
            _DOPE_CostoSada = value
        End Set
    End Property

    Private _DOPE_Costo As Decimal
    <DataMember()>
    Public Property DOPE_Costo() As Decimal
        Get
            Return _DOPE_Costo
        End Get

        Set(ByVal value As Decimal)
            _DOPE_Costo = value
        End Set
    End Property

    Private _DOPE_VentaSada As Decimal
    <DataMember()>
    Public Property DOPE_VentaSada() As Decimal
        Get
            Return _DOPE_VentaSada
        End Get

        Set(ByVal value As Decimal)
            _DOPE_VentaSada = value
        End Set
    End Property

    Private _DOPE_Venta As Decimal
    <DataMember()>
    Public Property DOPE_Venta() As Decimal
        Get
            Return _DOPE_Venta
        End Get

        Set(ByVal value As Decimal)
            _DOPE_Venta = value
        End Set
    End Property

    Private _TIPO_TabZON As String
    <DataMember()>
    Public Property TIPO_TabZON() As String
        Get
            Return _TIPO_TabZON
        End Get

        Set(ByVal value As String)
            _TIPO_TabZON = value
        End Set
    End Property

    Private _TIPO_CodZONOrigen As String
    <DataMember()>
    Public Property TIPO_CodZONOrigen() As String
        Get
            Return _TIPO_CodZONOrigen
        End Get

        Set(ByVal value As String)
            _TIPO_CodZONOrigen = value
        End Set
    End Property

    Private _CONS_CodTRA As String
    <DataMember()>
    Public Property CONS_CodTRA() As String
        Get
            Return _CONS_CodTRA
        End Get

        Set(ByVal value As String)
            _CONS_CodTRA = value
        End Set
    End Property

    Private _CONS_TabTRA As String
    <DataMember()>
    Public Property CONS_TabTRA() As String
        Get
            Return _CONS_TabTRA
        End Get

        Set(ByVal value As String)
            _CONS_TabTRA = value
        End Set
    End Property

    Private _TIPO_CodZONDestino As String
    <DataMember()>
    Public Property TIPO_CodZONDestino() As String
        Get
            Return _TIPO_CodZONDestino
        End Get

        Set(ByVal value As String)
            _TIPO_CodZONDestino = value
        End Set
    End Property

    Private _TIPE_Codigo As Int16
    <DataMember()>
    Public Property TIPE_Codigo() As Int16
        Get
            Return _TIPE_Codigo
        End Get

        Set(ByVal value As Int16)
            _TIPE_Codigo = value
        End Set
    End Property

    Private _ENTC_Codigo As Int32
    <DataMember()>
    Public Property ENTC_Codigo() As Int32
        Get
            Return _ENTC_Codigo
        End Get

        Set(ByVal value As Int32)
            _ENTC_Codigo = value
        End Set
    End Property

    Private _CONS_CodEST As String
    <DataMember()>
    Public Property CONS_CodEST() As String
        Get
            Return _CONS_CodEST
        End Get

        Set(ByVal value As String)
            _CONS_CodEST = value
        End Set
    End Property

    Private _CONS_TabEST As String
    <DataMember()>
    Public Property CONS_TabEST() As String
        Get
            Return _CONS_TabEST
        End Get

        Set(ByVal value As String)
            _CONS_TabEST = value
        End Set
    End Property

    Private _PDDO_Item As Int16
    <DataMember()>
    Public Property PDDO_Item() As Int16
        Get
            Return _PDDO_Item
        End Get

        Set(ByVal value As Int16)
            _PDDO_Item = value
        End Set
    End Property

    Private _DOCV_Codigo As Int32
    <DataMember()>
    Public Property DOCV_Codigo() As Int32
        Get
            Return _DOCV_Codigo
        End Get

        Set(ByVal value As Int32)
            _DOCV_Codigo = value
        End Set
    End Property

    Private _DOPE_CostoOriginal As Decimal
    <DataMember()>
    Public Property DOPE_CostoOriginal() As Decimal
        Get
            Return _DOPE_CostoOriginal
        End Get

        Set(ByVal value As Decimal)
            _DOPE_CostoOriginal = value
        End Set
    End Property

    Private _DOPE_CostoSadaOriginal As Decimal
    <DataMember()>
    Public Property DOPE_CostoSadaOriginal() As Decimal
        Get
            Return _DOPE_CostoSadaOriginal
        End Get

        Set(ByVal value As Decimal)
            _DOPE_CostoSadaOriginal = value
        End Set
    End Property

    Private _AUDI_UsrModCosto As String
    <DataMember()>
    Public Property AUDI_UsrModCosto() As String
        Get
            Return _AUDI_UsrModCosto
        End Get

        Set(ByVal value As String)
            _AUDI_UsrModCosto = value
        End Set
    End Property

    Private _AUDI_FecModCosto As DateTime
    <DataMember()>
    Public Property AUDI_FecModCosto() As DateTime
        Get
            Return _AUDI_FecModCosto
        End Get

        Set(ByVal value As DateTime)
            _AUDI_FecModCosto = value
        End Set
    End Property

    Private _SERV_Codigo As Int32
    <DataMember()>
    Public Property SERV_Codigo() As Int32
        Get
            Return _SERV_Codigo
        End Get

        Set(ByVal value As Int32)
            _SERV_Codigo = value
        End Set
    End Property

End Class
