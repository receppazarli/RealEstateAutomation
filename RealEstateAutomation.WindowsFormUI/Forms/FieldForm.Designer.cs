namespace RealEstateAutomation.WindowsFormUI.Forms
{
    partial class FieldForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnClear2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave2 = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcelTransfer2 = new DevExpress.XtraBars.BarButtonItem();
            this.grcField = new DevExpress.XtraGrid.GridControl();
            this.grwField = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PropertyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OwnerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Area = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Pafta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.County = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeleteFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.textBox1);
            this.layoutControl1.Controls.Add(this.grcField);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 133);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1248, 485);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1248, 485);
            this.layoutControlGroup1.TextVisible = false;
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
            // btnClear2
            // 
            this.btnClear2.Caption = "CLEAR";
            this.btnClear2.Id = 1;
            this.btnClear2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.btnClear2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.btnClear2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClear2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnClear2.Name = "btnClear2";
            // 
            // btnDelete2
            // 
            this.btnDelete2.Caption = "DELETE";
            this.btnDelete2.Id = 2;
            this.btnDelete2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.btnDelete2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.btnDelete2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDelete2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelete2.Name = "btnDelete2";
            // 
            // btnSave2
            // 
            this.btnSave2.Caption = "SAVE";
            this.btnSave2.Id = 3;
            this.btnSave2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.btnSave2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.btnSave2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSave2.Name = "btnSave2";
            // 
            // btnExcelTransfer2
            // 
            this.btnExcelTransfer2.Caption = "EXCEL TRANSFER";
            this.btnExcelTransfer2.Id = 4;
            this.btnExcelTransfer2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.Image")));
            this.btnExcelTransfer2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem4.ImageOptions.LargeImage")));
            this.btnExcelTransfer2.ItemAppearance.Normal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcelTransfer2.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExcelTransfer2.Name = "btnExcelTransfer2";
            // 
            // grcField
            // 
            this.grcField.Location = new System.Drawing.Point(12, 12);
            this.grcField.MainView = this.grwField;
            this.grcField.MenuManager = this.ribbonControl1;
            this.grcField.Name = "grcField";
            this.grcField.Size = new System.Drawing.Size(843, 461);
            this.grcField.TabIndex = 4;
            this.grcField.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grwField});
            // 
            // grwField
            // 
            this.grwField.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.PropertyId,
            this.OwnerId,
            this.Area,
            this.Pafta,
            this.City,
            this.County,
            this.Address,
            this.Price,
            this.Description,
            this.DeleteFlag});
            this.grwField.GridControl = this.grcField;
            this.grwField.Name = "grwField";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcField;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(847, 465);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = true;
            this.Id.VisibleIndex = 0;
            // 
            // PropertyId
            // 
            this.PropertyId.Caption = "Property ID";
            this.PropertyId.FieldName = "PropertyId";
            this.PropertyId.Name = "PropertyId";
            this.PropertyId.Visible = true;
            this.PropertyId.VisibleIndex = 1;
            // 
            // OwnerId
            // 
            this.OwnerId.Caption = "Owner ID";
            this.OwnerId.FieldName = "OwnerId";
            this.OwnerId.Name = "OwnerId";
            this.OwnerId.Visible = true;
            this.OwnerId.VisibleIndex = 2;
            // 
            // Area
            // 
            this.Area.Caption = "Area";
            this.Area.FieldName = "Area";
            this.Area.Name = "Area";
            this.Area.Visible = true;
            this.Area.VisibleIndex = 3;
            // 
            // Pafta
            // 
            this.Pafta.Caption = "Pafta";
            this.Pafta.FieldName = "Pafta";
            this.Pafta.Name = "Pafta";
            this.Pafta.Visible = true;
            this.Pafta.VisibleIndex = 4;
            // 
            // City
            // 
            this.City.Caption = "City";
            this.City.FieldName = "City";
            this.City.Name = "City";
            this.City.Visible = true;
            this.City.VisibleIndex = 5;
            // 
            // County
            // 
            this.County.Caption = "County";
            this.County.FieldName = "County";
            this.County.Name = "County";
            this.County.Visible = true;
            this.County.VisibleIndex = 6;
            // 
            // Address
            // 
            this.Address.Caption = "Address";
            this.Address.FieldName = "Address";
            this.Address.Name = "Address";
            this.Address.Visible = true;
            this.Address.VisibleIndex = 7;
            // 
            // Price
            // 
            this.Price.Caption = "Price";
            this.Price.FieldName = "Price";
            this.Price.Name = "Price";
            this.Price.Visible = true;
            this.Price.VisibleIndex = 8;
            // 
            // Description
            // 
            this.Description.Caption = "Description";
            this.Description.FieldName = "Description";
            this.Description.Name = "Description";
            this.Description.Visible = true;
            this.Description.VisibleIndex = 9;
            // 
            // DeleteFlag
            // 
            this.DeleteFlag.Caption = "Delete Flag";
            this.DeleteFlag.FieldName = "DeleteFlag";
            this.DeleteFlag.Name = "DeleteFlag";
            this.DeleteFlag.Visible = true;
            this.DeleteFlag.VisibleIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(964, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(272, 20);
            this.textBox1.TabIndex = 5;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textBox1;
            this.layoutControlItem2.Location = new System.Drawing.Point(847, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(381, 465);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(93, 13);
            // 
            // FieldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 618);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FieldForm";
            this.Text = "FIELD";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
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
        private DevExpress.XtraGrid.GridControl grcField;
        private DevExpress.XtraGrid.Views.Grid.GridView grwField;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn PropertyId;
        private DevExpress.XtraGrid.Columns.GridColumn OwnerId;
        private DevExpress.XtraGrid.Columns.GridColumn Area;
        private DevExpress.XtraGrid.Columns.GridColumn Pafta;
        private DevExpress.XtraGrid.Columns.GridColumn City;
        private DevExpress.XtraGrid.Columns.GridColumn County;
        private DevExpress.XtraGrid.Columns.GridColumn Address;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn DeleteFlag;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}