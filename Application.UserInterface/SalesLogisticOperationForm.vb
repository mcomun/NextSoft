Public Class SalesLogisticOperationForm
    Friend sHBL As String
    Dim oAppService As New AppService.DelfinServiceClient
    Dim oMasterDataList As New MasterDataList

    Private Sub SalesLogisticOperationForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadTariff()
        LoadEntityType()
        LoadEntityByType()
    End Sub

    Private Sub LoadEntityType()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("EntityType", Nothing)
        RepositoryItemLookUpEdit2.DataSource = dtQuery
        RepositoryItemLookUpEdit2.DisplayMember = "DescripcionTipoEntidad"
        RepositoryItemLookUpEdit2.ValueMember = "CodigoTipoEntidad"
    End Sub

    Private Sub LoadEntityByType()
        Dim dtQuery As New DataTable
        Dim aParams As New ArrayList
        aParams.Add(DBNull.Value)
        dtQuery = oMasterDataList.LoadMasterData("EntityByType", aParams)
        RepositoryItemLookUpEdit3.DataSource = dtQuery
        RepositoryItemLookUpEdit3.DisplayMember = "DescripcionEntidad"
        RepositoryItemLookUpEdit3.ValueMember = "CodigoEntidad"
    End Sub

    Private Sub LoadTariff()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("Tariff", Nothing)
        lueTarifa.Properties.DataSource = dtQuery
        lueTarifa.Properties.DisplayMember = "IdTariff"
        lueTarifa.Properties.ValueMember = "IdTariff"
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

    Private Sub RepositoryItemLookUpEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEdit2.EditValueChanged
        'LoadEntityByType()
    End Sub

End Class