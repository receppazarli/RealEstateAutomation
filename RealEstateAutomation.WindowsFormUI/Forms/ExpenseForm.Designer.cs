namespace RealEstateAutomation.WindowsFormUI.Forms
{
    partial class ExpenseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnClear2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcelTransfer2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.dteExpenseDate = new DevExpress.XtraEditors.DateEdit();
            this.txtExpensePrice = new DevExpress.XtraEditors.TextEdit();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.txtId = new DevExpress.XtraEditors.TextEdit();
            this.grcExpense = new DevExpress.XtraGrid.GridControl();
            this.grwExpense = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpenseDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExpensePrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeleteFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteExpenseDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteExpenseDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpensePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnClear2,
            this.btnDelete2,
            this.btnSave2,
            this.btnExcelTransfer2});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.MacOffice;
            this.ribbonControl1.Size = new System.Drawing.Size(1248, 133);
            this.ribbonControl1.Visible = false;
            // 
            // btnClear2
            // 
            this.btnClear2.Caption = "CLEAR";
            this.btnClear2.Id = 1;
            this.btnClear2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear2.ImageOptions.Image")));
            this.btnClear2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnClear2.ImageOptions.LargeImage")));
            this.btnClear2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear2_ItemClick);
            // 
            // btnDelete2
            // 
            this.btnDelete2.Caption = "DELETE";
            this.btnDelete2.Id = 2;
            this.btnDelete2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete2.ImageOptions.Image")));
            this.btnDelete2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDelete2.ImageOptions.LargeImage")));
            this.btnDelete2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete2_ItemClick);
            // 
            // btnSave2
            // 
            this.btnSave2.Caption = "SAVE";
            this.btnSave2.Id = 3;
            this.btnSave2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave2.ImageOptions.Image")));
            this.btnSave2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSave2.ImageOptions.LargeImage")));
            this.btnSave2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave2_ItemClick);
            // 
            // btnExcelTransfer2
            // 
            this.btnExcelTransfer2.Caption = "EXCEL TRANSFER";
            this.btnExcelTransfer2.Id = 4;
            this.btnExcelTransfer2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelTransfer2.ImageOptions.Image")));
            this.btnExcelTransfer2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExcelTransfer2.ImageOptions.LargeImage")));
            this.btnExcelTransfer2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcelTransfer2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExcelTransfer2.Name = "btnExcelTransfer2";
            this.btnExcelTransfer2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcelTransfer2_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClear2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDelete2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnSave2);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnExcelTransfer2);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Controls.Add(this.btnClear);
            this.layoutControl1.Controls.Add(this.dteExpenseDate);
            this.layoutControl1.Controls.Add(this.txtExpensePrice);
            this.layoutControl1.Controls.Add(this.txtDescription);
            this.layoutControl1.Controls.Add(this.txtId);
            this.layoutControl1.Controls.Add(this.grcExpense);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 133);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1248, 485);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(859, 132);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(377, 36);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(859, 172);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(377, 36);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.Location = new System.Drawing.Point(859, 212);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(377, 36);
            this.btnClear.StyleController = this.layoutControl1;
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "CLEAR";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dteExpenseDate
            // 
            this.dteExpenseDate.EditValue = null;
            this.dteExpenseDate.Location = new System.Drawing.Point(981, 42);
            this.dteExpenseDate.MenuManager = this.ribbonControl1;
            this.dteExpenseDate.Name = "dteExpenseDate";
            this.dteExpenseDate.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dteExpenseDate.Properties.Appearance.Options.UseFont = true;
            this.dteExpenseDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteExpenseDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteExpenseDate.Size = new System.Drawing.Size(255, 26);
            this.dteExpenseDate.StyleController = this.layoutControl1;
            this.dteExpenseDate.TabIndex = 8;
            // 
            // txtExpensePrice
            // 
            this.txtExpensePrice.Location = new System.Drawing.Point(981, 72);
            this.txtExpensePrice.MenuManager = this.ribbonControl1;
            this.txtExpensePrice.Name = "txtExpensePrice";
            this.txtExpensePrice.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtExpensePrice.Properties.Appearance.Options.UseFont = true;
            this.txtExpensePrice.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txtExpensePrice.Properties.MaskSettings.Set("mask", "c");
            this.txtExpensePrice.Properties.NullText = "0";
            this.txtExpensePrice.Size = new System.Drawing.Size(255, 26);
            this.txtExpensePrice.StyleController = this.layoutControl1;
            this.txtExpensePrice.TabIndex = 7;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(981, 102);
            this.txtDescription.MenuManager = this.ribbonControl1;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDescription.Properties.Appearance.Options.UseFont = true;
            this.txtDescription.Size = new System.Drawing.Size(255, 26);
            this.txtDescription.StyleController = this.layoutControl1;
            this.txtDescription.TabIndex = 6;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(981, 12);
            this.txtId.MenuManager = this.ribbonControl1;
            this.txtId.Name = "txtId";
            this.txtId.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtId.Properties.Appearance.Options.UseFont = true;
            this.txtId.Size = new System.Drawing.Size(255, 26);
            this.txtId.StyleController = this.layoutControl1;
            this.txtId.TabIndex = 5;
            // 
            // grcExpense
            // 
            this.grcExpense.Location = new System.Drawing.Point(12, 12);
            this.grcExpense.MainView = this.grwExpense;
            this.grcExpense.MenuManager = this.ribbonControl1;
            this.grcExpense.Name = "grcExpense";
            this.grcExpense.Size = new System.Drawing.Size(843, 461);
            this.grcExpense.TabIndex = 4;
            this.grcExpense.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grwExpense});
            this.grcExpense.Click += new System.EventHandler(this.grcExpense_Click);
            // 
            // grwExpense
            // 
            this.grwExpense.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grwExpense.Appearance.HeaderPanel.Options.UseFont = true;
            this.grwExpense.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grwExpense.Appearance.Row.Options.UseFont = true;
            this.grwExpense.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.ExpenseDate,
            this.ExpensePrice,
            this.Description,
            this.DeleteFlag});
            this.grwExpense.GridControl = this.grcExpense;
            this.grwExpense.Name = "grwExpense";
            this.grwExpense.OptionsBehavior.ReadOnly = true;
            this.grwExpense.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grwExpense_MouseDown);
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.OptionsColumn.ReadOnly = true;
            // 
            // ExpenseDate
            // 
            this.ExpenseDate.Caption = "Expense Date";
            this.ExpenseDate.FieldName = "ExpenseDate";
            this.ExpenseDate.Name = "ExpenseDate";
            this.ExpenseDate.Visible = true;
            this.ExpenseDate.VisibleIndex = 0;
            // 
            // ExpensePrice
            // 
            this.ExpensePrice.Caption = "Expense Price";
            this.ExpensePrice.FieldName = "ExpensePrice";
            this.ExpensePrice.Name = "ExpensePrice";
            this.ExpensePrice.Visible = true;
            this.ExpensePrice.VisibleIndex = 1;
            // 
            // Description
            // 
            this.Description.Caption = "Description";
            this.Description.FieldName = "Description";
            this.Description.Name = "Description";
            this.Description.Visible = true;
            this.Description.VisibleIndex = 2;
            // 
            // DeleteFlag
            // 
            this.DeleteFlag.Caption = "DeleteFlag";
            this.DeleteFlag.FieldName = "DeleteFlag";
            this.DeleteFlag.Name = "DeleteFlag";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1248, 485);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcExpense;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(847, 465);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txtDescription;
            this.layoutControlItem3.Location = new System.Drawing.Point(847, 90);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(381, 30);
            this.layoutControlItem3.Text = "Description:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(110, 21);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txtExpensePrice;
            this.layoutControlItem4.Location = new System.Drawing.Point(847, 60);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(381, 30);
            this.layoutControlItem4.Text = "Expense Price:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(110, 21);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.dteExpenseDate;
            this.layoutControlItem5.Location = new System.Drawing.Point(847, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(381, 30);
            this.layoutControlItem5.Text = "Expense Date:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(110, 21);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnClear;
            this.layoutControlItem6.Location = new System.Drawing.Point(847, 200);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(381, 265);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnDelete;
            this.layoutControlItem7.Location = new System.Drawing.Point(847, 160);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(381, 40);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnSave;
            this.layoutControlItem8.Location = new System.Drawing.Point(847, 120);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(381, 40);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txtId;
            this.layoutControlItem2.Location = new System.Drawing.Point(847, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(381, 30);
            this.layoutControlItem2.Text = "Id:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(110, 21);
            this.layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // popupMenu1
            // 
            this.popupMenu1.ItemLinks.Add(this.btnSave2);
            this.popupMenu1.ItemLinks.Add(this.btnDelete2);
            this.popupMenu1.ItemLinks.Add(this.btnClear2);
            this.popupMenu1.ItemLinks.Add(this.btnExcelTransfer2);
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbonControl1;
            // 
            // ExpenseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 618);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "ExpenseForm";
            this.Text = "EXPENSE";
            this.Load += new System.EventHandler(this.ExpenseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dteExpenseDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteExpenseDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpensePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.BarButtonItem btnClear2;
        private DevExpress.XtraBars.BarButtonItem btnDelete2;
        private DevExpress.XtraBars.BarButtonItem btnSave2;
        private DevExpress.XtraBars.BarButtonItem btnExcelTransfer2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraEditors.TextEdit txtExpensePrice;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtId;
        private DevExpress.XtraGrid.GridControl grcExpense;
        private DevExpress.XtraGrid.Views.Grid.GridView grwExpense;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.DateEdit dteExpenseDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn ExpenseDate;
        private DevExpress.XtraGrid.Columns.GridColumn ExpensePrice;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn DeleteFlag;
    }
}