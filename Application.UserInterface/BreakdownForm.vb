Imports DevExpress.XtraEditors.DXErrorProvider
Imports DevExpress.XtraSplashScreen
Imports Microsoft.Office.Interop
Imports DevExpress.XtraWaitForm
Imports System.Runtime.InteropServices

Public Class BreakdownForm

    Dim oAppService As New AppService.DelfinServiceClient
    Public AppUser As String = "sistemas"

    Private Sub BreakdownForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gcMainData.MainView.RestoreLayoutFromRegistry(IO.Directory.GetCurrentDirectory)
        Me.WindowState = FormWindowState.Maximized
        LoadShipline()
        LoadVoyage()
    End Sub

    Private Sub LoadShipline()
        lueShipline.Properties.DataSource = GetShipline(Nothing)
        lueShipline.Properties.DisplayMember = "DescripcionTransportista"
        lueShipline.Properties.ValueMember = "CodigoTransportista"
    End Sub

    Private Sub LoadVoyage()
        lueVoyage.Properties.DataSource = GetVoyage(Nothing, lueShipline.EditValue)
        lueVoyage.Properties.DisplayMember = "NombreNave"
        lueVoyage.Properties.ValueMember = "CodigoViaje"
    End Sub

    Private Sub lueShipline_Properties_EditValueChanged(sender As Object, e As EventArgs) Handles lueShipline.Properties.EditValueChanged
        LoadVoyage()
    End Sub

    Private Sub lueVoyage_EditValueChanged(sender As Object, e As EventArgs) Handles lueVoyage.EditValueChanged
        teVoyage.Text = lueVoyage.GetColumnValue("Viaje_Vuelo")
    End Sub

    Private Sub bbiSearch_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiSearch.ItemClick
        LoadInputValidations(bbiSearch.Tag)
        If Not vpInputs.Validate Then
            Return
        End If
        gcMainData.DataSource = Nothing
        SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
        SplashScreenManager.Default.SetWaitFormDescription("Consultando datos")
        Try
            Dim dtQuery As New DataTable
            Dim sQuery As String = ""
            sQuery += "EXEC NextSoft.dgp.paConsultaDesglose "
            If Not lueShipline.EditValue Is Nothing Then
                sQuery += lueShipline.EditValue.ToString
            Else
                sQuery += "NULL"
            End If
            sQuery += "," & lueVoyage.EditValue.ToString
            dtQuery = oAppService.ExecuteSQL(sQuery).Tables(0)
            dtQuery.Columns.Add("Checked", GetType(Boolean)).DefaultValue = False
            gcMainData.DataSource = dtQuery
            SeleccionaFilas(1)
            GridView1.BestFitColumns()
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
        End Try
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub bbiExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiExport.ItemClick
        ExportToExcel(gcMainData)
    End Sub

    Private Sub bbiBreakdownUpdate_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiBreakdownUpdate.ItemClick
        LoadInputValidations(bbiBreakdownUpdate.Tag)
        If Not vpInputs.Validate Then
            Return
        End If
        If RowSelectedCount() = 0 Then
            DevExpress.XtraEditors.XtraMessageBox.Show("Debe seleccionar al menos un registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
        SplashScreenManager.Default.SetWaitFormDescription("Actualizando datos")
        Try
            For r = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(r, "Checked") = True Then
                    oAppService.ExecuteSQLNonQuery("EXEC NextSoft.dgp.paAsignaDesglose " & GridView1.GetRowCellValue(r, "CCOT_Numero").ToString & ",'" & Format(deRegisterDate.EditValue, "MM/dd/yyyy HH:mm") & "','" & AppUser & "'")
                End If
            Next
        Catch ex As Exception
            SplashScreenManager.CloseForm(False)
            DevExpress.XtraEditors.XtraMessageBox.Show("Se generó un error al actualizar los datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        SplashScreenManager.CloseForm(False)
        bbiSearch.PerformClick()
    End Sub

    Private Sub bbiClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbiClose.ItemClick
        Close()
    End Sub

    Private Sub LoadInputValidations(ButtonTag As Integer)
        Validate()
        Dim containsValidationRule As New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        containsValidationRule.ConditionOperator = ConditionOperator.IsNotBlank
        containsValidationRule.ErrorText = "Asigne un valor."
        containsValidationRule.ErrorType = ErrorType.Critical
        Dim customValidationRule As New CustomValidationRule()
        customValidationRule.ErrorText = "Valor obligatorio."
        customValidationRule.ErrorType = ErrorType.Critical
        If ButtonTag = 0 Then
            vpInputs.SetValidationRule(Me.lueVoyage, customValidationRule)
        ElseIf ButtonTag = 1 Then
            vpInputs.SetValidationRule(Me.deRegisterDate, customValidationRule)
        End If
    End Sub

    Friend Function RowSelectedCount() As Integer
        Dim iChecked As Integer = 0
        For i = 0 To GridView1.RowCount - 1
            If IsDBNull(GridView1.GetRowCellValue(i, "Checked")) Then
                Continue For
            End If
            If GridView1.GetRowCellValue(i, "Checked") Then
                iChecked += 1
            End If
        Next
        Return iChecked
    End Function

    Private Sub SeleccionaFilas(caso As Integer)
        For i = 0 To GridView1.RowCount - 1
            Dim row As DataRow = GridView1.GetDataRow(i)
            If caso = 0 Then
                row("Checked") = True
            End If
            If caso = 1 Then
                row("Checked") = False
            End If
            If caso = 2 Then
                If row("Checked") Then
                    row("Checked") = False
                Else
                    row("Checked") = True
                End If
            End If
        Next
    End Sub

    Private Sub SeleccionaTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeleccionaTodosToolStripMenuItem.Click
        SeleccionaFilas(0)
    End Sub

    Private Sub DeseleccionaTodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeseleccionaTodosToolStripMenuItem.Click
        SeleccionaFilas(1)
    End Sub

    Private Sub InvertirSelecciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InvertirSelecciónToolStripMenuItem.Click
        SeleccionaFilas(2)
    End Sub

    Private Sub RepositoryItemCheckEdit1_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.CheckedChanged
        'If Not IsDBNull(GridView1.GetFocusedRowCellValue("FechaRegistroDesglose")) Then
        '    GridView1.SetFocusedRowCellValue("Checked", False)
        'End If
        'GridView1.CloseEditor()
    End Sub

    Private Sub BreakdownForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        gcMainData.MainView.SaveLayoutToRegistry(IO.Directory.GetCurrentDirectory)
    End Sub
End Class