Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraNavBar

Public Class LogisticOperationRegisterForm
    Dim oAppService As New AppService.DelfinServiceClient
    Dim oMasterDataList As New MasterDataList
    Dim dsOperationRelated As New DataSet
    Friend InternalCode As Integer
    Friend HBL As String

    Private Sub LogisticOperationRegisterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'NavBarGroup4.Visible = False
        ExpandAllGroups()
        NavBarGroup4.Expanded = False
        LoadOperationRelated()
        LoadEntityDataList(1, "lueCliente")
        LoadEntityDataList(5, "lueTransportista")
        LoadEntityDataList(11, "lueAgenciaMaritima")
        LoadEntityDataList(14, "lueAlmacen")
        LoadEntityDataList(17, "lueTerminalPortuario")
        LoadEntityDataList(0, "RepositoryItemLookUpEdit3")
        LoadCargoCondition()
        LoadCommodity()
        LoadEntityType()
        LoadService()
        LoadTariff()
        LoadCurrency()


        If InternalCode = -1 Then 'New Item
            NewItem()
        ElseIf InternalCode >= 0 Then 'Edit Item
            SetItem()
        End If


    End Sub

    Private Sub LoadCommodity()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("Commodity", Nothing)
        lueTipoMercancia.Properties.DataSource = dtQuery
        lueTipoMercancia.Properties.DisplayMember = "DescripcionTipoCommodity"
        lueTipoMercancia.Properties.ValueMember = "CodigoTipoCommodity"
    End Sub

    Private Sub LoadEntityType()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("EntityType", Nothing)
        RepositoryItemLookUpEdit2.DataSource = dtQuery
        RepositoryItemLookUpEdit2.DisplayMember = "DescripcionTipoEntidad"
        RepositoryItemLookUpEdit2.ValueMember = "CodigoTipoEntidad"
    End Sub

    Private Sub LoadService()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("Service", Nothing)
        RepositoryItemLookUpEdit1.DataSource = dtQuery
        RepositoryItemLookUpEdit1.DisplayMember = "DescripcionServicio"
        RepositoryItemLookUpEdit1.ValueMember = "CodigoServicio"
    End Sub

    Private Sub LoadEntityDataList(EntityType As Integer, ControlName As String)
        Dim dtQuery As New DataTable
        Dim aParams As New ArrayList
        If EntityType > 0 Then
            aParams.Add(EntityType.ToString)
        End If
        dtQuery = oMasterDataList.LoadMasterData("EntityByType", aParams)
        If ControlName = "lueCliente" Then
            lueCliente.Properties.DataSource = dtQuery
            lueCliente.Properties.DisplayMember = "DescripcionEntidad"
            lueCliente.Properties.ValueMember = "CodigoEntidad"
        ElseIf ControlName = "lueTransportista" Then
            lueTransportista.Properties.DataSource = dtQuery
            lueTransportista.Properties.DisplayMember = "DescripcionEntidad"
            lueTransportista.Properties.ValueMember = "CodigoEntidad"
        ElseIf ControlName = "lueAgenciaMaritima" Then
            dtQuery = oMasterDataList.LoadMasterData("EntityByType", aParams)
            lueAgenciaMaritima.Properties.DataSource = dtQuery
            lueAgenciaMaritima.Properties.DisplayMember = "DescripcionEntidad"
            lueAgenciaMaritima.Properties.ValueMember = "CodigoEntidad"
        ElseIf ControlName = "lueAlmacen" Then
            lueAlmacen.Properties.DataSource = dtQuery
            lueAlmacen.Properties.DisplayMember = "DescripcionEntidad"
            lueAlmacen.Properties.ValueMember = "CodigoEntidad"
        ElseIf ControlName = "lueTerminalPortuario" Then
            lueTerminalPortuario.Properties.DataSource = dtQuery
            lueTerminalPortuario.Properties.DisplayMember = "DescripcionEntidad"
            lueTerminalPortuario.Properties.ValueMember = "CodigoEntidad"
        ElseIf ControlName = "RepositoryItemLookUpEdit3" Then
            RepositoryItemLookUpEdit3.DataSource = dtQuery
            RepositoryItemLookUpEdit3.DisplayMember = "DescripcionEntidad"
            RepositoryItemLookUpEdit3.ValueMember = "CodigoEntidad"
        End If

    End Sub

    Private Sub LoadTariff()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("Tariff", Nothing)
        lueTarifa.Properties.DataSource = dtQuery
        lueTarifa.Properties.DisplayMember = "IdTariff"
        lueTarifa.Properties.ValueMember = "IdTariff"
    End Sub

    Private Sub LoadCargoCondition()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("CargoCondition", Nothing)
        lueCondicionEmbarque.Properties.DataSource = dtQuery
        lueCondicionEmbarque.Properties.DisplayMember = "DescripcionCondicionEmbarque"
        lueCondicionEmbarque.Properties.ValueMember = "CodigoCondicionEmbarque"
    End Sub

    Private Sub LoadCurrency()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("Currency", Nothing)
        lueMoneda.Properties.DataSource = dtQuery
        lueMoneda.Properties.DisplayMember = "DescripcionMoneda"
        lueMoneda.Properties.ValueMember = "CodigoMoneda"
    End Sub

    Private Sub LoadOperationRelated()
        'dsOperationRelated = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paObtieneOperacionesLogisticasRelacionadas '" & sHBL & "'")
    End Sub

    Private Sub NewItem()
        deFechaEmision.EditValue = Today
    End Sub

    Private Sub SetItem()
        dsOperationRelated = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paObtieneOperacionesLogisticasRelacionadas " & InternalCode.ToString)
        If dsOperationRelated Is Nothing Or dsOperationRelated.Tables(0).Rows.Count = 0 Then
            Return
        End If
        Dim drOperation As DataRow = dsOperationRelated.Tables(0)(0)
        'Datos Generales
        teNumeroOperacion.EditValue = drOperation("COPE_NumDoc")
        deFechaEmision.EditValue = drOperation("COPE_FecEmi")
        teHBL.EditValue = drOperation("COPE_HBL")
        teMBL.EditValue = drOperation("COPE_MBL")
        lueCliente.EditValue = drOperation("ENTC_CodigoCliente")
        lueTransportista.EditValue = drOperation("ENTC_CodigoTransportista")
        lueAgenciaMaritima.EditValue = drOperation("ENTC_CodigoAgenciaMaritima")
        lueAlmacen.EditValue = drOperation("ENTC_CodigoAlmacen")
        lueTerminalPortuario.EditValue = drOperation("ENTC_CodigoTerminalPortuario")
        lueCondicionEmbarque.EditValue = drOperation("CodigoCondicionEmbarque")
        lueMoneda.EditValue = drOperation("TIPO_CodMND")
        If dsOperationRelated.Tables(2).Rows.Count > 0 Then
            lueTipoMercancia.EditValue = dsOperationRelated.Tables(2).Rows(0)("TIPO_CodCDT")
        End If
        'Nave-Viaje
        teCodigoViaje.EditValue = drOperation("NVIA_Codigo")
        teNombreNave.EditValue = drOperation("NAVE_Nombre")
        teNumeroViaje.EditValue = drOperation("NVIA_NroViaje")
        deFechaEtaEtd.EditValue = drOperation("FechaEtaEtd")
        'Contenedores (Agrupado)
        If dsOperationRelated.Tables(1).Rows.Count > 0 Then
            gcContainerGroup.DataSource = dsOperationRelated.Tables(1)
            GridView2.BestFitColumns()
        End If
        'Contenedores (Detallado)
        If dsOperationRelated.Tables(2).Rows.Count > 0 Then
            gcContainerDetail.DataSource = dsOperationRelated.Tables(2)
            GridView4.BestFitColumns()
        End If
        'Tarifa
        If dsOperationRelated.Tables(3).Rows.Count > 0 Then
            Dim drTariff As DataRow = dsOperationRelated.Tables(3)(0)
            lueTarifa.EditValue = drTariff("IdTariff")
            teTipoTarifa.EditValue = drTariff("TariffType")
            deVigenciaDesde.EditValue = drTariff("ValidFrom")
            deVigenciaHasta.EditValue = drTariff("ValidTo")
            meObservacionesTarifa.EditValue = drTariff("Remarks")
        End If
        'Tarifa Detalle
        If dsOperationRelated.Tables(4).Rows.Count > 0 Then
            gcTariff.DataSource = dsOperationRelated.Tables(4)
            GridView3.BestFitColumns()
        End If
        'Servicios
        If dsOperationRelated.Tables(5).Rows.Count > 0 Then
            gcServiceRelated.DataSource = dsOperationRelated.Tables(5)
            GridView1.BestFitColumns()
        End If
    End Sub

    Private Sub ExpandAllGroups()
        Dim I As Integer
        For I = 0 To NavBarControl1.Groups.Count - 1
            Dim CurrGroup As NavBarGroup = NavBarControl1.Groups(I)
            CurrGroup.Expanded = True
        Next
    End Sub

    Private Sub bbiSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSave.ItemClick

    End Sub

    Private Sub bbiQuery_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiQuery.ItemClick
        If Not vpInputs.Validate Then
            Return
        End If
        Dim oForm As New VerticalViewerOVForm
        oForm.sHBL = teHBL.EditValue
        oForm.ShowDialog()
    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick
        Close()
    End Sub

    Private Sub bbiSendMailTo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSendMailTo.ItemClick

    End Sub

    Private Sub teHBL_Leave(sender As Object, e As EventArgs) Handles teHBL.Leave
        SetItem()
    End Sub

    Private Sub LoadInputValidations()
        Validate()
        Dim containsValidationRule As New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        containsValidationRule.ConditionOperator = ConditionOperator.IsNotBlank
        containsValidationRule.ErrorText = "Asigne un valor."
        containsValidationRule.ErrorType = ErrorType.Critical
        Dim customValidationRule As New CustomValidationRule()
        customValidationRule.ErrorText = "Valor obligatorio."
        customValidationRule.ErrorType = ErrorType.Critical
        'vpInputs.SetValidationRule(Me.lueCustomer, customValidationRule)
        'vpInputs.SetValidationRule(Me.deDateFrom, customValidationRule)
        'vpInputs.SetValidationRule(Me.deDateTo, customValidationRule)
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged

    End Sub

    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles GridView1.FocusedColumnChanged
        'If e.FocusedColumn.FieldName = "TIPE_Codigo" Then
        '    LoadEntityDataList(GridView1.GetFocusedRowCellValue("TIPE_Codigo"), "RepositoryItemLookUpEdit3")
        'End If
    End Sub

    Private Sub lueTarifa_EditValueChanged(sender As Object, e As EventArgs) Handles lueTarifa.EditValueChanged
        gcServiceRelated.DataSource = Nothing
        gcTariff.DataSource = Nothing
        Dim dtTariffDetail, dtServiceRelated As New DataTable
        dtTariffDetail = oAppService.ExecuteSQL("EXEC NextSoft.tar.upGetTariffDetailById " & lueTarifa.EditValue.ToString).Tables(0)
        gcTariff.DataSource = dtTariffDetail
        GridView3.BestFitColumns()
        teTipoTarifa.EditValue = IIf(lueTarifa.GetColumnValue("TariffType") = "B", "BASE", IIf(lueTarifa.GetColumnValue("TariffType") = "R", "REGULAR", IIf(lueTarifa.GetColumnValue("TariffType") = "E", "ESPECIAL", "")))
        deVigenciaDesde.EditValue = lueTarifa.GetColumnValue("ValidFrom")
        deVigenciaHasta.EditValue = lueTarifa.GetColumnValue("ValidTo")
        meObservacionesTarifa.EditValue = lueTarifa.GetColumnValue("Remarks")
        dtServiceRelated = oAppService.ExecuteSQL("EXEC NextSoft.tar.upGetServiceCalulatedByTariff " & lueTarifa.EditValue.ToString & ",'" & teHBL.Text & "'").Tables(0)
        gcServiceRelated.DataSource = dtServiceRelated
        GridView1.BestFitColumns()
    End Sub
End Class