Imports DevExpress.XtraEditors.DXErrorProvider

Public Class LogisticOperationQueryForm
    Dim oAppService As New AppService.DelfinServiceClient
    Dim oMasterDataList As New MasterDataList
    Public AppUser As String = "sistemas"

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub LogisticOperationQueryForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gcRegistered.MainView.RestoreLayoutFromRegistry(IO.Directory.GetCurrentDirectory)
        deDateFrom.EditValue = DateAdd(DateInterval.Day, -60, Now)
        deDateTo.EditValue = Now
        SplitContainerControl2.Collapsed = Not tsShowRO.EditValue
        Dim iHeight As Integer = SplitContainerControl3.Size.Height
        SplitContainerControl3.SplitterPosition = (iHeight / 2) + 50
        ButtonEnabled()
        LoadEntityType()
    End Sub

    Private Sub LoadEntityType()
        Dim dtQuery As New DataTable
        dtQuery = oMasterDataList.LoadMasterData("EntityType", Nothing)
        lueEntityType.Properties.DataSource = dtQuery
        lueEntityType.Properties.DisplayMember = "DescripcionTipoEntidad"
        lueEntityType.Properties.ValueMember = "CodigoTipoEntidad"
    End Sub

    Private Sub LoadEntityByType()
        Dim dtQuery As New DataTable
        Dim aParams As New ArrayList
        aParams.Add(lueEntityType.EditValue)
        dtQuery = oMasterDataList.LoadMasterData("EntityByType", aParams)
        lueEntity.Properties.DataSource = dtQuery
        lueEntity.Properties.DisplayMember = "DescripcionEntidad"
        lueEntity.Properties.ValueMember = "CodigoEntidad"
    End Sub

    Private Sub bbiAdd1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiAdd1.ItemClick
        Dim oNewForm As New LogisticOperationRegisterForm
        oNewForm.InternalCode = -1
        oNewForm.HBL = GridView1.GetFocusedRowCellValue("COPE_HBL")
        oNewForm.ShowDialog()
    End Sub

    Private Sub bbiAdd2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiAdd2.ItemClick
        Dim oNewForm As New LogisticOperationRegisterForm
        oNewForm.InternalCode = -1
        oNewForm.HBL = ""
        oNewForm.ShowDialog()
    End Sub

    Private Sub bbiEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiEdit.ItemClick
        Dim oEditForm As New LogisticOperationRegisterForm
        oEditForm.InternalCode = GridView1.GetFocusedRowCellValue("COPE_Codigo")
        oEditForm.ShowDialog()
    End Sub

    Private Sub bbiVoid_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiVoid.ItemClick

    End Sub

    Private Sub bbiSearch_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSearch.ItemClick
        LoadInputValidations()
        If Not vpInputs.Validate Then
            Return
        End If
        Dim dtSource As New DataTable
        Dim sParams As String = ""
        sParams = IIf(lueEntity.EditValue Is Nothing, "NULL", lueEntity.EditValue)
        sParams += ", " & IIf(teOperationNumber.Text.Trim = "", "NULL", "'" & teOperationNumber.Text & "'")
        sParams += ", " & IIf(teHBL.Text.Trim = "", "NULL", "'" & teHBL.Text & "'")
        If teOperationNumber.Text.Trim = "" And teHBL.Text.Trim = "" Then
            sParams += ", '" & IIf(deDateFrom.EditValue = Nothing, "NULL", Format(deDateFrom.EditValue, "yyyyMMdd")) & "'"
            sParams += ", '" & IIf(deDateTo.EditValue = Nothing, "NULL", Format(deDateTo.EditValue, "yyyyMMdd")) & "'"
        End If
        gcRegistered.DataSource = Nothing
        SplitContainerControl2.Collapsed = True
        dtSource = oAppService.ExecuteSQL("EXEC NextSoft.dgp.paObtieneOperacionesLogisticas " & sParams).Tables(0)
        If dtSource.Rows.Count > 0 Then
            If dtSource.Select("TipoConsulta=1").Length > 0 Then
                gcRegistered.DataSource = dtSource.Select("TipoConsulta=1").CopyToDataTable
            End If
            If dtSource.Select("TipoConsulta=0").Length > 0 Then
                gcPending.DataSource = dtSource.Select("TipoConsulta=0").CopyToDataTable
            End If
            GridView1.BestFitColumns()
            GridView2.BestFitColumns()
            ButtonEnabled()
            End If
    End Sub

    Private Sub bbiExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiExport.ItemClick
        If GridView2.IsFocusedView Then
            ExportToExcel(gcPending)
        Else
            ExportToExcel(gcRegistered)
        End If

    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick
        Close()
    End Sub

    Private Sub LogisticOperationQueryForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gcRegistered.MainView.SaveLayoutToRegistry(IO.Directory.GetCurrentDirectory)
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If e.FocusedRowHandle = -1 Or SplitContainerControl2.Collapsed = True Then
            Return
        End If
        ButtonEnabled()
        ShowRoutingOrder()
    End Sub

    Private Sub lueEntityType_EditValueChanged(sender As Object, e As EventArgs) Handles lueEntityType.EditValueChanged
        LoadEntityByType()
    End Sub

    Private Sub ShowRoutingOrder()
        Dim OVForm As New VerticalViewerOVForm
        OVForm.bbiClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        OVForm.bbiFileViewer.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        OVForm.sHBL = GridView1.GetFocusedRowCellValue("COPE_HBL")
        OVForm.TopLevel = False
        OVForm.FormBorderStyle = FormBorderStyle.None
        OVForm.Dock = DockStyle.Fill
        SplitContainerControl2.Panel2.Controls.Clear()
        SplitContainerControl2.Panel2.Controls.Add(OVForm)
        OVForm.Show()
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
        vpInputs.SetValidationRule(Me.teOperationNumber, Nothing)
        vpInputs.SetValidationRule(Me.deDateFrom, Nothing)
        vpInputs.SetValidationRule(Me.deDateTo, Nothing)
        If teOperationNumber.Text.Trim = "" Then
            vpInputs.SetValidationRule(Me.deDateFrom, customValidationRule)
            vpInputs.SetValidationRule(Me.deDateTo, customValidationRule)
        End If
        If deDateFrom.EditValue Is Nothing Then
            vpInputs.SetValidationRule(Me.teOperationNumber, customValidationRule)
        End If
    End Sub

    Private Sub ButtonEnabled()
        If GridView1.RowCount = 0 Then
            bbiEdit.Enabled = False
            bbiVoid.Enabled = False
            bbiExport.Enabled = False
            tsShowRO.Enabled = False
            Return
        End If
        If GridView1.RowCount > 0 Then
            tsShowRO.Enabled = True
            For b = 0 To bmActions.Items.Count - 1
                If bmActions.Items(b).Name.Contains("bbi") Then
                    bmActions.Items(b).Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub tsShowRO_Toggled(sender As Object, e As EventArgs) Handles tsShowRO.Toggled
        Validate()
        SplitContainerControl2.Collapsed = Not tsShowRO.EditValue
        If tsShowRO.EditValue Then
            ShowRoutingOrder()
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        bbiEdit.PerformClick()
    End Sub

    Private Sub gcRegistered_Enter(sender As Object, e As EventArgs) Handles gcRegistered.Enter
        bsiAdd.Enabled = False
        tsShowRO.Enabled = True
        bbiEdit.Enabled = True
        bbiVoid.Enabled = True
    End Sub

    Private Sub gcPending_Enter(sender As Object, e As EventArgs) Handles gcPending.Enter
        bsiAdd.Enabled = True
        tsShowRO.EditValue = False
        tsShowRO.Enabled = False
        bbiEdit.Enabled = False
        bbiVoid.Enabled = False
    End Sub

    Private Sub bbiSendMailTo_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSendMailTo.ItemClick
        Dim oMailItem As New CreateMailItem
        oMailItem.subject = "Prueba"
        oMailItem.htmlBody.AppendText("Esto es una prueba de correo")
        oMailItem.mailTo = "aremonfe@gmail.com"
        oMailItem.CreateCustomMessage()
    End Sub

    Private Sub bbiPreInvoicing_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiPreInvoicing.ItemClick

    End Sub

End Class