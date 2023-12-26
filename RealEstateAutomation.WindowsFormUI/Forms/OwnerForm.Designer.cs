namespace RealEstateAutomation.WindowsFormUI.Forms
{
    partial class OwnerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OwnerForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnClear2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcelTransfer2 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnPhone = new DevExpress.XtraEditors.ButtonEdit();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNationalityId = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtDeleteFlag = new System.Windows.Forms.TextBox();
            this.grcOwner = new DevExpress.XtraGrid.GridControl();
            this.grwOwner = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NationalityId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FirstName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LastName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Phone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeleteFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcClear = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcDelete = new DevExpress.XtraLayout.LayoutControlItem();
            this.lcSave = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOwner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwOwner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcClear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSave)).BeginInit();
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
            this.btnClear2.ItemAppearance.Disabled.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear2.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnClear2.ItemAppearance.Hovered.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear2.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnClear2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnClear2.ItemAppearance.Pressed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear2.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClear2_ItemClick);
            // 
            // btnDelete2
            // 
            this.btnDelete2.Caption = "DELETE";
            this.btnDelete2.Id = 2;
            this.btnDelete2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete2.ImageOptions.Image")));
            this.btnDelete2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDelete2.ImageOptions.LargeImage")));
            this.btnDelete2.ItemAppearance.Disabled.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete2.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnDelete2.ItemAppearance.Hovered.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete2.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnDelete2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelete2.ItemAppearance.Pressed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete2.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnDelete2.Name = "btnDelete2";
            this.btnDelete2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete2_ItemClick);
            // 
            // btnSave2
            // 
            this.btnSave2.Caption = "SAVE";
            this.btnSave2.Id = 3;
            this.btnSave2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave2.ImageOptions.Image")));
            this.btnSave2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSave2.ImageOptions.LargeImage")));
            this.btnSave2.ItemAppearance.Disabled.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave2.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnSave2.ItemAppearance.Hovered.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave2.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnSave2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSave2.ItemAppearance.Pressed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave2.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnSave2.Name = "btnSave2";
            this.btnSave2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave2_ItemClick);
            // 
            // btnExcelTransfer2
            // 
            this.btnExcelTransfer2.Caption = "EXCEL TRANSFER";
            this.btnExcelTransfer2.Id = 4;
            this.btnExcelTransfer2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelTransfer2.ImageOptions.Image")));
            this.btnExcelTransfer2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExcelTransfer2.ImageOptions.LargeImage")));
            this.btnExcelTransfer2.ItemAppearance.Disabled.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcelTransfer2.ItemAppearance.Disabled.Options.UseFont = true;
            this.btnExcelTransfer2.ItemAppearance.Hovered.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcelTransfer2.ItemAppearance.Hovered.Options.UseFont = true;
            this.btnExcelTransfer2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcelTransfer2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExcelTransfer2.ItemAppearance.Pressed.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcelTransfer2.ItemAppearance.Pressed.Options.UseFont = true;
            this.btnExcelTransfer2.Name = "btnExcelTransfer2";
            this.btnExcelTransfer2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnExcelTransfer2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcelTransfer2_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3,
            this.ribbonPageGroup2,
            this.ribbonPageGroup1,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnSave2);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnDelete2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnClear2);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnExcelTransfer2);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Visible = false;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSave);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Controls.Add(this.btnClear);
            this.layoutControl1.Controls.Add(this.btnPhone);
            this.layoutControl1.Controls.Add(this.txtId);
            this.layoutControl1.Controls.Add(this.txtNationalityId);
            this.layoutControl1.Controls.Add(this.txtFirstName);
            this.layoutControl1.Controls.Add(this.txtLastName);
            this.layoutControl1.Controls.Add(this.txtDeleteFlag);
            this.layoutControl1.Controls.Add(this.grcOwner);
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
            this.btnSave.Location = new System.Drawing.Point(859, 162);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(377, 36);
            this.btnSave.StyleController = this.layoutControl1;
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(859, 202);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(377, 36);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.Location = new System.Drawing.Point(859, 242);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(377, 36);
            this.btnClear.StyleController = this.layoutControl1;
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "CLEAR";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnPhone
            // 
            this.btnPhone.Location = new System.Drawing.Point(959, 108);
            this.btnPhone.MenuManager = this.ribbonControl1;
            this.btnPhone.Name = "btnPhone";
            this.btnPhone.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPhone.Properties.Appearance.Options.UseFont = true;
            this.btnPhone.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnPhone.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.SimpleMaskManager));
            this.btnPhone.Properties.MaskSettings.Set("mask", "(000) 000-0000");
            this.btnPhone.Size = new System.Drawing.Size(277, 26);
            this.btnPhone.StyleController = this.layoutControl1;
            this.btnPhone.TabIndex = 10;
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtId.Location = new System.Drawing.Point(959, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(277, 20);
            this.txtId.TabIndex = 9;
            // 
            // txtNationalityId
            // 
            this.txtNationalityId.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtNationalityId.Location = new System.Drawing.Point(959, 36);
            this.txtNationalityId.Name = "txtNationalityId";
            this.txtNationalityId.Size = new System.Drawing.Size(277, 20);
            this.txtNationalityId.TabIndex = 8;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFirstName.Location = new System.Drawing.Point(959, 60);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(277, 20);
            this.txtFirstName.TabIndex = 7;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLastName.Location = new System.Drawing.Point(959, 84);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(277, 20);
            this.txtLastName.TabIndex = 6;
            // 
            // txtDeleteFlag
            // 
            this.txtDeleteFlag.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtDeleteFlag.Location = new System.Drawing.Point(959, 138);
            this.txtDeleteFlag.Name = "txtDeleteFlag";
            this.txtDeleteFlag.Size = new System.Drawing.Size(277, 20);
            this.txtDeleteFlag.TabIndex = 5;
            // 
            // grcOwner
            // 
            this.grcOwner.Location = new System.Drawing.Point(12, 12);
            this.grcOwner.MainView = this.grwOwner;
            this.grcOwner.MenuManager = this.ribbonControl1;
            this.grcOwner.Name = "grcOwner";
            this.grcOwner.Size = new System.Drawing.Size(843, 461);
            this.grcOwner.TabIndex = 4;
            this.grcOwner.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grwOwner});
            this.grcOwner.Click += new System.EventHandler(this.grcOwner_Click);
            this.grcOwner.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grcOwner_MouseDown);
            // 
            // grwOwner
            // 
            this.grwOwner.Appearance.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grwOwner.Appearance.HeaderPanel.Options.UseFont = true;
            this.grwOwner.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grwOwner.Appearance.Row.Options.UseFont = true;
            this.grwOwner.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.NationalityId,
            this.FirstName,
            this.LastName,
            this.Phone,
            this.DeleteFlag});
            this.grwOwner.GridControl = this.grcOwner;
            this.grwOwner.Name = "grwOwner";
            this.grwOwner.OptionsBehavior.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // NationalityId
            // 
            this.NationalityId.Caption = "Nationality ID";
            this.NationalityId.FieldName = "NationalityId";
            this.NationalityId.Name = "NationalityId";
            this.NationalityId.Visible = true;
            this.NationalityId.VisibleIndex = 0;
            // 
            // FirstName
            // 
            this.FirstName.Caption = "First Name";
            this.FirstName.FieldName = "FirstName";
            this.FirstName.Name = "FirstName";
            this.FirstName.Visible = true;
            this.FirstName.VisibleIndex = 1;
            // 
            // LastName
            // 
            this.LastName.Caption = "Last Name";
            this.LastName.FieldName = "LastName";
            this.LastName.Name = "LastName";
            this.LastName.Visible = true;
            this.LastName.VisibleIndex = 2;
            // 
            // Phone
            // 
            this.Phone.Caption = "Phone";
            this.Phone.FieldName = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.Visible = true;
            this.Phone.VisibleIndex = 3;
            // 
            // DeleteFlag
            // 
            this.DeleteFlag.Caption = "Delete Flag";
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
            this.lcClear,
            this.lcDelete,
            this.lcSave,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1248, 485);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcOwner;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(847, 465);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txtLastName;
            this.layoutControlItem3.Location = new System.Drawing.Point(847, 72);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(381, 24);
            this.layoutControlItem3.Text = "Last Name:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(88, 19);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txtFirstName;
            this.layoutControlItem4.Location = new System.Drawing.Point(847, 48);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(381, 24);
            this.layoutControlItem4.Text = "First Name:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(88, 19);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.txtNationalityId;
            this.layoutControlItem5.Location = new System.Drawing.Point(847, 24);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(381, 24);
            this.layoutControlItem5.Text = "Nationality ID:";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(88, 19);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.txtId;
            this.layoutControlItem6.Location = new System.Drawing.Point(847, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(381, 24);
            this.layoutControlItem6.Text = "Id:";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(88, 19);
            this.layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.btnPhone;
            this.layoutControlItem7.Location = new System.Drawing.Point(847, 96);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(381, 30);
            this.layoutControlItem7.Text = "Phone:";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(88, 19);
            // 
            // lcClear
            // 
            this.lcClear.Control = this.btnClear;
            this.lcClear.Location = new System.Drawing.Point(847, 230);
            this.lcClear.Name = "lcClear";
            this.lcClear.Size = new System.Drawing.Size(381, 235);
            this.lcClear.TextSize = new System.Drawing.Size(0, 0);
            this.lcClear.TextVisible = false;
            // 
            // lcDelete
            // 
            this.lcDelete.Control = this.btnDelete;
            this.lcDelete.Location = new System.Drawing.Point(847, 190);
            this.lcDelete.Name = "lcDelete";
            this.lcDelete.Size = new System.Drawing.Size(381, 40);
            this.lcDelete.TextSize = new System.Drawing.Size(0, 0);
            this.lcDelete.TextVisible = false;
            // 
            // lcSave
            // 
            this.lcSave.Control = this.btnSave;
            this.lcSave.Location = new System.Drawing.Point(847, 150);
            this.lcSave.Name = "lcSave";
            this.lcSave.Size = new System.Drawing.Size(381, 40);
            this.lcSave.TextSize = new System.Drawing.Size(0, 0);
            this.lcSave.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txtDeleteFlag;
            this.layoutControlItem2.Location = new System.Drawing.Point(847, 126);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(381, 24);
            this.layoutControlItem2.Text = "Delete Flag:";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(88, 19);
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
            // OwnerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 618);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OwnerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OWNER";
            this.Load += new System.EventHandler(this.OwnerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcOwner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwOwner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcClear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.BarButtonItem btnClear2;
        private DevExpress.XtraBars.BarButtonItem btnSave2;
        private DevExpress.XtraBars.BarButtonItem btnExcelTransfer2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnDelete2;
        private DevExpress.XtraGrid.GridControl grcOwner;
        private DevExpress.XtraGrid.Views.Grid.GridView grwOwner;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.ButtonEdit btnPhone;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNationalityId;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtDeleteFlag;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        public DevExpress.XtraEditors.SimpleButton btnSave;
        public DevExpress.XtraEditors.SimpleButton btnDelete;
        public DevExpress.XtraEditors.SimpleButton btnClear;
        public DevExpress.XtraLayout.LayoutControlItem lcClear;
        public DevExpress.XtraLayout.LayoutControlItem lcDelete;
        public DevExpress.XtraLayout.LayoutControlItem lcSave;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn NationalityId;
        private DevExpress.XtraGrid.Columns.GridColumn FirstName;
        private DevExpress.XtraGrid.Columns.GridColumn LastName;
        private DevExpress.XtraGrid.Columns.GridColumn Phone;
        private DevExpress.XtraGrid.Columns.GridColumn DeleteFlag;
    }
}