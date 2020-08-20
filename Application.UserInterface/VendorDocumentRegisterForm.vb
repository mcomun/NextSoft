Public Class VendorDocumentRegisterForm
    Dim oAppService As New AppService.DelfinServiceClient
    Dim oMasterDataList As New MasterDataList
    Dim dsVendorDocumentRelated As New DataSet
    Friend InternalCode As Integer

    Private Sub VendorDocumentRegisterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For g = 0 To NavBarControl1.Groups.Count - 1
            NavBarControl1.Groups(g).Expanded = True
        Next
        LoadDocumentType()
        LoadCurrency()
        LoadPayTerm()
        LoadDetractionType()
        LoadEntityType()
        LoadIncomeTaxType()

        If InternalCode = -1 Then 'New Item
            bbiImport.Enabled = True
            NewItem()
        ElseIf InternalCode >= 0 Then 'Edit Item
            bbiImport.Enabled = False
            SetItem()
        End If

    End Sub

    Private Sub LoadDocumentType()
        Dim dtSource As New DataTable
        dtSource = oMasterDataList.LoadMasterData("AccountingDocumentType", Nothing)
        lueTipoDocumento.Properties.DataSource = dtSource
        lueTipoDocumento.Properties.DisplayMember = "DescripcionTipoDocumento"
        lueTipoDocumento.Properties.ValueMember = "CodigoTipoDocumento"
    End Sub

    Private Sub LoadCurrency()
        Dim dtSource As New DataTable
        dtSource = oMasterDataList.LoadMasterData("Currency", Nothing)
        lueMoneda.Properties.DataSource = dtSource
        lueMoneda.Properties.DisplayMember = "DescripcionMoneda"
        lueMoneda.Properties.ValueMember = "CodigoMoneda"
    End Sub

    Private Sub LoadEntityType()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("EntityType", Nothing)
        lueTipoEntidad.Properties.DataSource = dtQuery
        lueTipoEntidad.Properties.DisplayMember = "DescripcionTipoEntidad"
        lueTipoEntidad.Properties.ValueMember = "CodigoTipoEntidad"
        lueTipoEntidad.ItemIndex = 1
    End Sub

    Private Sub LoadEntityByType()
        Dim dtQuery As New DataTable
        dtQuery = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paListaEntidadPorTipo " & lueTipoEntidad.EditValue.ToString).Tables(0)
        lueRazonSocial.Properties.DataSource = dtQuery
        lueRazonSocial.Properties.DisplayMember = "DescripcionEntidad"
        lueRazonSocial.Properties.ValueMember = "CodigoEntidad"
    End Sub

    Private Sub LoadPayTerm()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("PayTerm", Nothing)
        lueFormaPago.Properties.DataSource = dtQuery
        lueFormaPago.Properties.DisplayMember = "DescripcionFormaPago"
        lueFormaPago.Properties.ValueMember = "CodigoFormaPago"
    End Sub

    Private Sub LoadDetractionType()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("DetractionType", Nothing)
        lueTipoDetraccion.Properties.DataSource = dtQuery
        lueTipoDetraccion.Properties.DisplayMember = "DescripcionTipoDetraccion"
        lueTipoDetraccion.Properties.ValueMember = "CodigoTipoDetraccion"
    End Sub

    Private Sub LoadIncomeTaxType()
        Dim dtSource As New DataTable
        dtSource = oMasterDataList.LoadMasterData("IncomeTaxType", Nothing)
        lueTipoRenta.Properties.DataSource = dtSource
        lueTipoRenta.Properties.DisplayMember = "DescripcionTipoRenta"
        lueTipoRenta.Properties.ValueMember = "CodigoTipoRenta"
        lueTipoRenta.ItemIndex = 0
    End Sub

    Private Sub bbiSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSave.ItemClick

    End Sub

    Private Sub bbiImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiImport.ItemClick

    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick
        Close()
    End Sub

    Private Sub teHBL_Leave(sender As Object, e As EventArgs) Handles teHBL.Leave

    End Sub

    Private Sub NewItem()
        deFechaEmision.EditValue = Today
    End Sub

    Private Sub SetItem()
        dsVendorDocumentRelated = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paObtieneDocumentosProveedorRelacionados " & InternalCode.ToString)
        If dsVendorDocumentRelated Is Nothing Or dsVendorDocumentRelated.Tables(0).Rows.Count = 0 Then
            Return
        End If
        Dim drVendorDocument As DataRow = dsVendorDocumentRelated.Tables(0)(0)

        'Datos Generales
        teHBL.EditValue = drVendorDocument("COPE_HBL")
        lueTipoDocumento.EditValue = drVendorDocument("CodigoTipoDocumento")
        lueMoneda.EditValue = drVendorDocument("CodigoMoneda")
        lueTipoDetraccion.EditValue = drVendorDocument("CodigoTipoDetraccion")
        lueTipoEntidad.EditValue = drVendorDocument("TIPE_Codigo")
        LoadEntityByType()
        lueRazonSocial.EditValue = drVendorDocument("ENTC_Codigo")
        teSerieDocumento.EditValue = drVendorDocument("CCCT_Serie")
        teNumeroDocumento.EditValue = drVendorDocument("CCCT_Numero")
        deFechaEmision.EditValue = drVendorDocument("CCCT_FechaEmision")
        deFechaVencimiento.EditValue = drVendorDocument("CCCT_FechaVcto")
        deFechaRegistro.EditValue = drVendorDocument("CCCT_FecReg")
        teCodigoInterno.EditValue = drVendorDocument("CCCT_Codigo")
        teTipoCambio.EditValue = drVendorDocument("CCCT_TipoCambio")
        seImporteNeto.EditValue = drVendorDocument("CCCT_ValVta")
        seImporteImpuesto.EditValue = drVendorDocument("CCCT_Imp1")
        seImporteTotal.EditValue = drVendorDocument("CCCT_Monto")
        lueFormaPago.EditValue = drVendorDocument("CodigoFormaPago")
        tsAutoDetraccion.EditValue = drVendorDocument("AutoDetraccion")
        'Documento de Referencia
        If drVendorDocument("RequiereReferencia") = 0 Then
            NavBarGroup3.Visible = False
        Else
            NavBarGroup3.Expanded = True
            lueTipoDocumentoRef.Properties.DataSource = lueTipoDocumento.Properties.DataSource
            lueTipoDocumentoRef.Properties.DisplayMember = "DescripcionTipoDocumento"
            lueTipoDocumentoRef.Properties.ValueMember = "CodigoTipoDocumento"
            lueTipoDocumentoRef.EditValue = drVendorDocument("TIPO_CodTDOReferencia")
            teSerieDocumentoRef.EditValue = drVendorDocument("CCCT_SerieReferencia")
            teNumeroDocumentoRef.EditValue = drVendorDocument("CCCT_NumeroReferencia")
            deFechaEmisionRef.EditValue = drVendorDocument("CCCT_FechaEmisionReferencia")
            teCodigoInternoRef.EditValue = drVendorDocument("CCCT_CodReferencia")
        End If
        'Operación Logística
        lueNumeroOperacion.EditValue = drVendorDocument("COPE_NumDoc")
        teClienteOperacion.EditValue = drVendorDocument("Cliente")
        deFechaEmisionOperacion.EditValue = drVendorDocument("COPE_FecEmi")
        teNumeroHblOperacion.EditValue = drVendorDocument("COPE_HBL")
        teCodigoInternoOperacion.EditValue = drVendorDocument("COPE_Codigo")
        'Servicios
        'If dsVendorDocumentRelated.Tables(1).Rows.Count > 0 Then
        '    gcService.DataSource = dsVendorDocumentRelated.Tables(1)
        '    GridView1.BestFitColumns()
        'End If
    End Sub

    Private Sub lueTipoEntidad_Leave(sender As Object, e As EventArgs) Handles lueTipoEntidad.Leave
        LoadEntityByType()
    End Sub
End Class