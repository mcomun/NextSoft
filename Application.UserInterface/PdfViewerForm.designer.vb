<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PdfViewerForm
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PdfViewerForm))
        Dim SuperToolTip1 As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip()
        Dim ToolTipItem1 As DevExpress.Utils.ToolTipItem = New DevExpress.Utils.ToolTipItem()
        Me.pdfZoomRibbonPageGroup1 = New DevExpress.XtraPdfViewer.Bars.PdfZoomRibbonPageGroup()
        Me.pdfZoomOutBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoomOutBarItem()
        Me.pdfZoomInBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoomInBarItem()
        Me.pdfExactZoomListBarSubItem1 = New DevExpress.XtraPdfViewer.Bars.PdfExactZoomListBarSubItem()
        Me.pdfZoom10CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom10CheckItem()
        Me.pdfZoom25CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom25CheckItem()
        Me.pdfZoom50CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom50CheckItem()
        Me.pdfZoom75CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom75CheckItem()
        Me.pdfZoom100CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom100CheckItem()
        Me.pdfZoom125CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom125CheckItem()
        Me.pdfZoom150CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom150CheckItem()
        Me.pdfZoom200CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom200CheckItem()
        Me.pdfZoom400CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom400CheckItem()
        Me.pdfZoom500CheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfZoom500CheckItem()
        Me.pdfSetActualSizeZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetActualSizeZoomModeCheckItem()
        Me.pdfSetPageLevelZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetPageLevelZoomModeCheckItem()
        Me.pdfSetFitWidthZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetFitWidthZoomModeCheckItem()
        Me.pdfSetFitVisibleZoomModeCheckItem1 = New DevExpress.XtraPdfViewer.Bars.PdfSetFitVisibleZoomModeCheckItem()
        Me.pdfFileRibbonPageGroup1 = New DevExpress.XtraPdfViewer.Bars.PdfFileRibbonPageGroup()
        Me.pdfFileSaveBarItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.pdfFileOpenBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfFileOpenBarItem()
        Me.pdfFilePrintBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfFilePrintBarItem()
        Me.pdfRibbonPage1 = New DevExpress.XtraPdfViewer.Bars.PdfRibbonPage()
        Me.pdfNavigationRibbonPageGroup1 = New DevExpress.XtraPdfViewer.Bars.PdfNavigationRibbonPageGroup()
        Me.pdfPreviousPageBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfPreviousPageBarItem()
        Me.pdfNextPageBarItem1 = New DevExpress.XtraPdfViewer.Bars.PdfNextPageBarItem()
        Me.pdfViewerDocs = New DevExpress.XtraPdfViewer.PdfViewer()
        Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.pdfBarController1 = New DevExpress.XtraPdfViewer.Bars.PdfBarController(Me.components)
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pdfBarController1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pdfZoomRibbonPageGroup1
        '
        Me.pdfZoomRibbonPageGroup1.ItemLinks.Add(Me.pdfZoomOutBarItem1)
        Me.pdfZoomRibbonPageGroup1.ItemLinks.Add(Me.pdfZoomInBarItem1)
        Me.pdfZoomRibbonPageGroup1.ItemLinks.Add(Me.pdfExactZoomListBarSubItem1)
        Me.pdfZoomRibbonPageGroup1.Name = "pdfZoomRibbonPageGroup1"
        '
        'pdfZoomOutBarItem1
        '
        Me.pdfZoomOutBarItem1.Id = 5
        Me.pdfZoomOutBarItem1.Name = "pdfZoomOutBarItem1"
        '
        'pdfZoomInBarItem1
        '
        Me.pdfZoomInBarItem1.Id = 6
        Me.pdfZoomInBarItem1.Name = "pdfZoomInBarItem1"
        '
        'pdfExactZoomListBarSubItem1
        '
        Me.pdfExactZoomListBarSubItem1.Id = 7
        Me.pdfExactZoomListBarSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom10CheckItem1, True), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom25CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom50CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom75CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom100CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom125CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom150CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom200CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom400CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfZoom500CheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfSetActualSizeZoomModeCheckItem1, True), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfSetPageLevelZoomModeCheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfSetFitWidthZoomModeCheckItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.pdfSetFitVisibleZoomModeCheckItem1)})
        Me.pdfExactZoomListBarSubItem1.Name = "pdfExactZoomListBarSubItem1"
        Me.pdfExactZoomListBarSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionInMenu
        '
        'pdfZoom10CheckItem1
        '
        Me.pdfZoom10CheckItem1.Id = 8
        Me.pdfZoom10CheckItem1.Name = "pdfZoom10CheckItem1"
        '
        'pdfZoom25CheckItem1
        '
        Me.pdfZoom25CheckItem1.Id = 9
        Me.pdfZoom25CheckItem1.Name = "pdfZoom25CheckItem1"
        '
        'pdfZoom50CheckItem1
        '
        Me.pdfZoom50CheckItem1.Id = 10
        Me.pdfZoom50CheckItem1.Name = "pdfZoom50CheckItem1"
        '
        'pdfZoom75CheckItem1
        '
        Me.pdfZoom75CheckItem1.Id = 11
        Me.pdfZoom75CheckItem1.Name = "pdfZoom75CheckItem1"
        '
        'pdfZoom100CheckItem1
        '
        Me.pdfZoom100CheckItem1.Id = 12
        Me.pdfZoom100CheckItem1.Name = "pdfZoom100CheckItem1"
        '
        'pdfZoom125CheckItem1
        '
        Me.pdfZoom125CheckItem1.Id = 13
        Me.pdfZoom125CheckItem1.Name = "pdfZoom125CheckItem1"
        '
        'pdfZoom150CheckItem1
        '
        Me.pdfZoom150CheckItem1.Id = 14
        Me.pdfZoom150CheckItem1.Name = "pdfZoom150CheckItem1"
        '
        'pdfZoom200CheckItem1
        '
        Me.pdfZoom200CheckItem1.Id = 15
        Me.pdfZoom200CheckItem1.Name = "pdfZoom200CheckItem1"
        '
        'pdfZoom400CheckItem1
        '
        Me.pdfZoom400CheckItem1.Id = 16
        Me.pdfZoom400CheckItem1.Name = "pdfZoom400CheckItem1"
        '
        'pdfZoom500CheckItem1
        '
        Me.pdfZoom500CheckItem1.Id = 17
        Me.pdfZoom500CheckItem1.Name = "pdfZoom500CheckItem1"
        '
        'pdfSetActualSizeZoomModeCheckItem1
        '
        Me.pdfSetActualSizeZoomModeCheckItem1.Id = 18
        Me.pdfSetActualSizeZoomModeCheckItem1.Name = "pdfSetActualSizeZoomModeCheckItem1"
        '
        'pdfSetPageLevelZoomModeCheckItem1
        '
        Me.pdfSetPageLevelZoomModeCheckItem1.Id = 19
        Me.pdfSetPageLevelZoomModeCheckItem1.Name = "pdfSetPageLevelZoomModeCheckItem1"
        '
        'pdfSetFitWidthZoomModeCheckItem1
        '
        Me.pdfSetFitWidthZoomModeCheckItem1.Id = 20
        Me.pdfSetFitWidthZoomModeCheckItem1.Name = "pdfSetFitWidthZoomModeCheckItem1"
        '
        'pdfSetFitVisibleZoomModeCheckItem1
        '
        Me.pdfSetFitVisibleZoomModeCheckItem1.Id = 21
        Me.pdfSetFitVisibleZoomModeCheckItem1.Name = "pdfSetFitVisibleZoomModeCheckItem1"
        '
        'pdfFileRibbonPageGroup1
        '
        Me.pdfFileRibbonPageGroup1.ItemLinks.Add(Me.pdfFileSaveBarItem1)
        Me.pdfFileRibbonPageGroup1.ItemLinks.Add(Me.pdfFileOpenBarItem1)
        Me.pdfFileRibbonPageGroup1.ItemLinks.Add(Me.pdfFilePrintBarItem1)
        Me.pdfFileRibbonPageGroup1.Name = "pdfFileRibbonPageGroup1"
        '
        'pdfFileSaveBarItem1
        '
        Me.pdfFileSaveBarItem1.Caption = "Guardar"
        Me.pdfFileSaveBarItem1.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
        Me.pdfFileSaveBarItem1.Id = 22
        Me.pdfFileSaveBarItem1.ImageOptions.SvgImage = CType(resources.GetObject("pdfFileSaveBarItem1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.pdfFileSaveBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S))
        Me.pdfFileSaveBarItem1.Name = "pdfFileSaveBarItem1"
        ToolTipItem1.Text = "Guardar (Ctrl+S)/Guardar un archivo PDF."
        SuperToolTip1.Items.Add(ToolTipItem1)
        Me.pdfFileSaveBarItem1.SuperTip = SuperToolTip1
        '
        'pdfFileOpenBarItem1
        '
        Me.pdfFileOpenBarItem1.Id = 1
        Me.pdfFileOpenBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O))
        Me.pdfFileOpenBarItem1.Name = "pdfFileOpenBarItem1"
        Me.pdfFileOpenBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'pdfFilePrintBarItem1
        '
        Me.pdfFilePrintBarItem1.Id = 2
        Me.pdfFilePrintBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P))
        Me.pdfFilePrintBarItem1.Name = "pdfFilePrintBarItem1"
        '
        'pdfRibbonPage1
        '
        Me.pdfRibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.pdfFileRibbonPageGroup1, Me.pdfNavigationRibbonPageGroup1, Me.pdfZoomRibbonPageGroup1})
        Me.pdfRibbonPage1.Name = "pdfRibbonPage1"
        '
        'pdfNavigationRibbonPageGroup1
        '
        Me.pdfNavigationRibbonPageGroup1.ItemLinks.Add(Me.pdfPreviousPageBarItem1)
        Me.pdfNavigationRibbonPageGroup1.ItemLinks.Add(Me.pdfNextPageBarItem1)
        Me.pdfNavigationRibbonPageGroup1.Name = "pdfNavigationRibbonPageGroup1"
        '
        'pdfPreviousPageBarItem1
        '
        Me.pdfPreviousPageBarItem1.Id = 3
        Me.pdfPreviousPageBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.PageUp)
        Me.pdfPreviousPageBarItem1.Name = "pdfPreviousPageBarItem1"
        '
        'pdfNextPageBarItem1
        '
        Me.pdfNextPageBarItem1.Id = 4
        Me.pdfNextPageBarItem1.ItemShortcut = New DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.PageDown)
        Me.pdfNextPageBarItem1.Name = "pdfNextPageBarItem1"
        '
        'pdfViewerDocs
        '
        Me.pdfViewerDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pdfViewerDocs.Location = New System.Drawing.Point(0, 141)
        Me.pdfViewerDocs.Name = "pdfViewerDocs"
        Me.pdfViewerDocs.Size = New System.Drawing.Size(709, 281)
        Me.pdfViewerDocs.TabIndex = 2
        '
        'ribbonControl1
        '
        Me.ribbonControl1.ExpandCollapseItem.Id = 0
        Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.pdfFileOpenBarItem1, Me.pdfFilePrintBarItem1, Me.pdfPreviousPageBarItem1, Me.pdfNextPageBarItem1, Me.pdfZoomOutBarItem1, Me.pdfZoomInBarItem1, Me.pdfExactZoomListBarSubItem1, Me.pdfZoom10CheckItem1, Me.pdfZoom25CheckItem1, Me.pdfZoom50CheckItem1, Me.pdfZoom75CheckItem1, Me.pdfZoom100CheckItem1, Me.pdfZoom125CheckItem1, Me.pdfZoom150CheckItem1, Me.pdfZoom200CheckItem1, Me.pdfZoom400CheckItem1, Me.pdfZoom500CheckItem1, Me.pdfSetActualSizeZoomModeCheckItem1, Me.pdfSetPageLevelZoomModeCheckItem1, Me.pdfSetFitWidthZoomModeCheckItem1, Me.pdfSetFitVisibleZoomModeCheckItem1, Me.pdfFileSaveBarItem1})
        Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.ribbonControl1.MaxItemId = 23
        Me.ribbonControl1.Name = "ribbonControl1"
        Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.pdfRibbonPage1})
        Me.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010
        Me.ribbonControl1.Size = New System.Drawing.Size(709, 141)
        Me.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above
        Me.ribbonControl1.TransparentEditorsMode = DevExpress.Utils.DefaultBoolean.[False]
        '
        'pdfBarController1
        '
        Me.pdfBarController1.BarItems.Add(Me.pdfFileOpenBarItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfFilePrintBarItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfPreviousPageBarItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfNextPageBarItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoomOutBarItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoomInBarItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfExactZoomListBarSubItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoom10CheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoom25CheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoom50CheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoom75CheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoom100CheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoom125CheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoom150CheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoom200CheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoom400CheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfZoom500CheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfSetActualSizeZoomModeCheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfSetPageLevelZoomModeCheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfSetFitWidthZoomModeCheckItem1)
        Me.pdfBarController1.BarItems.Add(Me.pdfSetFitVisibleZoomModeCheckItem1)
        Me.pdfBarController1.Control = Me.pdfViewerDocs
        '
        'PdfViewerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 422)
        Me.Controls.Add(Me.pdfViewerDocs)
        Me.Controls.Add(Me.ribbonControl1)
        Me.Name = "PdfViewerForm"
        Me.Text = "Visor de Comprobante Electrónico"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pdfBarController1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents pdfZoomRibbonPageGroup1 As DevExpress.XtraPdfViewer.Bars.PdfZoomRibbonPageGroup
    Private WithEvents pdfZoomOutBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoomOutBarItem
    Private WithEvents pdfZoomInBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoomInBarItem
    Private WithEvents pdfExactZoomListBarSubItem1 As DevExpress.XtraPdfViewer.Bars.PdfExactZoomListBarSubItem
    Private WithEvents pdfZoom10CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom10CheckItem
    Private WithEvents pdfZoom25CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom25CheckItem
    Private WithEvents pdfZoom50CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom50CheckItem
    Private WithEvents pdfZoom75CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom75CheckItem
    Private WithEvents pdfZoom100CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom100CheckItem
    Private WithEvents pdfZoom125CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom125CheckItem
    Private WithEvents pdfZoom150CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom150CheckItem
    Private WithEvents pdfZoom200CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom200CheckItem
    Private WithEvents pdfZoom400CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom400CheckItem
    Private WithEvents pdfZoom500CheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfZoom500CheckItem
    Private WithEvents pdfSetActualSizeZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetActualSizeZoomModeCheckItem
    Private WithEvents pdfSetPageLevelZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetPageLevelZoomModeCheckItem
    Private WithEvents pdfSetFitWidthZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetFitWidthZoomModeCheckItem
    Private WithEvents pdfSetFitVisibleZoomModeCheckItem1 As DevExpress.XtraPdfViewer.Bars.PdfSetFitVisibleZoomModeCheckItem
    Private WithEvents pdfFileRibbonPageGroup1 As DevExpress.XtraPdfViewer.Bars.PdfFileRibbonPageGroup
    Private WithEvents pdfFileSaveBarItem1 As DevExpress.XtraBars.BarButtonItem
    Private WithEvents pdfFileOpenBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfFileOpenBarItem
    Private WithEvents pdfFilePrintBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfFilePrintBarItem
    Private WithEvents pdfRibbonPage1 As DevExpress.XtraPdfViewer.Bars.PdfRibbonPage
    Private WithEvents pdfNavigationRibbonPageGroup1 As DevExpress.XtraPdfViewer.Bars.PdfNavigationRibbonPageGroup
    Private WithEvents pdfPreviousPageBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfPreviousPageBarItem
    Private WithEvents pdfNextPageBarItem1 As DevExpress.XtraPdfViewer.Bars.PdfNextPageBarItem
    Private WithEvents pdfViewerDocs As DevExpress.XtraPdfViewer.PdfViewer
    Private WithEvents ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Private WithEvents saveFileDialog1 As SaveFileDialog
    Private WithEvents pdfBarController1 As DevExpress.XtraPdfViewer.Bars.PdfBarController
End Class
