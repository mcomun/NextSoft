
Public Class MasterDataList
    Private oAppService As New AppService.DelfinServiceClient

    Friend Function LoadMasterData(TableName As String, Params As ArrayList) As DataTable
        Dim dtResult As New DataTable
        Dim QueryText As String = ""
        If TableName = "ServiceCompany" Then
            QueryText = "EXEC NextSoft.web.upGetCompanyService"
        ElseIf TableName = "DocumentType" Then
            QueryText = "EXEC NextSoft.dgp.paListaTipoDocumento"
        ElseIf TableName = "EntityType" Then
            QueryText = "EXEC NextSoft.dgp.paListaTipoEntidad"
        ElseIf TableName = "EntityByType" Then
            QueryText = "EXEC NextSoft.dgp.paListaEntidadPorTipo"
        ElseIf TableName = "OriginCountry" Then
            QueryText = "EXEC NextSoft.dgp.paListaPais"
        ElseIf TableName = "OriginPort" Then
            QueryText = "EXEC NextSoft.dgp.paListaPuerto"
        ElseIf TableName = "DestinationCountry" Then
            QueryText = "EXEC NextSoft.dgp.paListaPais"
        ElseIf TableName = "DestinationPort" Then
            QueryText = "EXEC NextSoft.dgp.paListaPuerto"
        ElseIf TableName = "EquipmentType" Then
            QueryText = "EXEC NextSoft.dgp.paListaTipoEquipo"
        ElseIf TableName = "Incoterm" Then
            QueryText = "EXEC NextSoft.dgp.paListaIncoterm"
        ElseIf TableName = "PackingType" Then
            QueryText = "EXEC NextSoft.dgp.paListaTipoEmbalaje"
        ElseIf TableName = "CargoCondition" Then
            QueryText = "EXEC NextSoft.dgp.paListaCondicionEmbarque"
        ElseIf TableName = "Commodity" Then
            QueryText = "EXEC NextSoft.dgp.paListaTipoCommodity"
        ElseIf TableName = "RelationType" Then
            QueryText = "EXEC NextSoft.dgp.paListaTipoVinculacion"
        ElseIf TableName = "ValidityType" Then
            QueryText = "EXEC NextSoft.dgp.paListaTipoVigencia"
        ElseIf TableName = "AuthorizationType" Then
            QueryText = "EXEC NextSoft.dgp.paListaTipoAutorizacion"
        ElseIf TableName = "AccountingDocumentType" Then
            QueryText = "EXEC NextSoft.dgp.paListaTipoDocumentoContable"
        ElseIf TableName = "Currency" Then
            QueryText = "EXEC NextSoft.dgp.paListaMoneda"
        ElseIf TableName = "Tariff" Then
            QueryText = "EXEC NextSoft.tar.upGetAllTariff"
        ElseIf TableName = "Service" Then
            QueryText = "EXEC NextSoft.dgp.paListaServicio"
        ElseIf TableName = "PayTerm" Then
            QueryText = "EXEC NextSoft.dgp.paListaFormaPago"
        ElseIf TableName = "DetractionType" Then
            QueryText = "EXEC NextSoft.dgp.paListaTipoDetraccion"
        ElseIf TableName = "IncomeTaxType" Then
            QueryText = "EXEC NextSoft.dgp.paListaTipoRenta"
        End If
        Try
            If Not Params Is Nothing Then
                For p = 0 To Params.Count - 1
                    QueryText += Space(1) & Params(p) & IIf(p < Params.Count - 1, ",", "")
                Next
            End If
            dtResult = oAppService.ExecuteSQL(QueryText).Tables(0)
        Catch ex As Exception

        End Try
        Return dtResult
    End Function

End Class
