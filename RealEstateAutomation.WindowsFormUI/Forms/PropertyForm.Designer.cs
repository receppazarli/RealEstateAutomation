namespace RealEstateAutomation.WindowsFormUI.Forms
{
    partial class PropertyForm
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.grcHouse = new DevExpress.XtraGrid.GridControl();
            this.grwHouse = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grcField = new DevExpress.XtraGrid.GridControl();
            this.grwField = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grcPlot = new DevExpress.XtraGrid.GridControl();
            this.grwPlot = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.grcShop = new DevExpress.XtraGrid.GridControl();
            this.grwShop = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PropertyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OwnerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Area = new DevExpress.XtraGrid.Columns.GridColumn();
            this.City = new DevExpress.XtraGrid.Columns.GridColumn();
            this.County = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Address = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Price = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DeleteFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcHouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwHouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwPlot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwShop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grcShop);
            this.layoutControl1.Controls.Add(this.grcPlot);
            this.layoutControl1.Controls.Add(this.grcField);
            this.layoutControl1.Controls.Add(this.grcHouse);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1258, 761);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1258, 761);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // grcHouse
            // 
            this.grcHouse.Location = new System.Drawing.Point(631, 367);
            this.grcHouse.MainView = this.grwHouse;
            this.grcHouse.Name = "grcHouse";
            this.grcHouse.Size = new System.Drawing.Size(615, 382);
            this.grcHouse.TabIndex = 4;
            this.grcHouse.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grwHouse});
            // 
            // grwHouse
            // 
            this.grwHouse.GridControl = this.grcHouse;
            this.grwHouse.Name = "grwHouse";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grcHouse;
            this.layoutControlItem1.Location = new System.Drawing.Point(619, 355);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(619, 386);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // grcField
            // 
            this.grcField.Location = new System.Drawing.Point(12, 12);
            this.grcField.MainView = this.grwField;
            this.grcField.Name = "grcField";
            this.grcField.Size = new System.Drawing.Size(615, 351);
            this.grcField.TabIndex = 6;
            this.grcField.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grwField});
            // 
            // grwField
            // 
            this.grwField.GridControl = this.grcField;
            this.grwField.Name = "grwField";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grcField;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(619, 355);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // grcPlot
            // 
            this.grcPlot.Location = new System.Drawing.Point(631, 12);
            this.grcPlot.MainView = this.grwPlot;
            this.grcPlot.Name = "grcPlot";
            this.grcPlot.Size = new System.Drawing.Size(615, 351);
            this.grcPlot.TabIndex = 7;
            this.grcPlot.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grwPlot});
            // 
            // grwPlot
            // 
            this.grwPlot.GridControl = this.grcPlot;
            this.grwPlot.Name = "grwPlot";
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.grcPlot;
            this.layoutControlItem4.Location = new System.Drawing.Point(619, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(619, 355);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // grcShop
            // 
            this.grcShop.Location = new System.Drawing.Point(12, 367);
            this.grcShop.MainView = this.grwShop;
            this.grcShop.Name = "grcShop";
            this.grcShop.Size = new System.Drawing.Size(615, 382);
            this.grcShop.TabIndex = 8;
            this.grcShop.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grwShop});
            // 
            // grwShop
            // 
            this.grwShop.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.PropertyId,
            this.OwnerId,
            this.Area,
            this.City,
            this.County,
            this.Address,
            this.Price,
            this.Description,
            this.DeleteFlag});
            this.grwShop.GridControl = this.grcShop;
            this.grwShop.Name = "grwShop";
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // PropertyId
            // 
            this.PropertyId.Caption = "PropertyId";
            this.PropertyId.FieldName = "PropertyId";
            this.PropertyId.Name = "PropertyId";
            // 
            // OwnerId
            // 
            this.OwnerId.Caption = "Owner Name";
            this.OwnerId.FieldName = "OwnerId";
            this.OwnerId.Name = "OwnerId";
            this.OwnerId.Visible = true;
            this.OwnerId.VisibleIndex = 0;
            // 
            // Area
            // 
            this.Area.Caption = "Area";
            this.Area.FieldName = "Area";
            this.Area.Name = "Area";
            this.Area.Visible = true;
            this.Area.VisibleIndex = 1;
            // 
            // City
            // 
            this.City.Caption = "City";
            this.City.FieldName = "City";
            this.City.Name = "City";
            this.City.Visible = true;
            this.City.VisibleIndex = 2;
            // 
            // County
            // 
            this.County.Caption = "County";
            this.County.FieldName = "County";
            this.County.Name = "County";
            this.County.Visible = true;
            this.County.VisibleIndex = 3;
            // 
            // Address
            // 
            this.Address.Caption = "Address";
            this.Address.FieldName = "Address";
            this.Address.Name = "Address";
            this.Address.Visible = true;
            this.Address.VisibleIndex = 4;
            // 
            // Price
            // 
            this.Price.Caption = "Price";
            this.Price.FieldName = "Price";
            this.Price.Name = "Price";
            this.Price.Visible = true;
            this.Price.VisibleIndex = 5;
            // 
            // Description
            // 
            this.Description.Caption = "Description";
            this.Description.FieldName = "Description";
            this.Description.Name = "Description";
            this.Description.Visible = true;
            this.Description.VisibleIndex = 6;
            // 
            // DeleteFlag
            // 
            this.DeleteFlag.Caption = "DeleteFlag";
            this.DeleteFlag.FieldName = "DeleteFlag";
            this.DeleteFlag.Name = "DeleteFlag";
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.grcShop;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 355);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(619, 386);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // PropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 761);
            this.Controls.Add(this.layoutControl1);
            this.Name = "PropertyForm";
            this.Text = "PropertyForm";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcHouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwHouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcPlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwPlot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grwShop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grcPlot;
        private DevExpress.XtraGrid.Views.Grid.GridView grwPlot;
        private DevExpress.XtraGrid.GridControl grcField;
        private DevExpress.XtraGrid.Views.Grid.GridView grwField;
        private DevExpress.XtraGrid.GridControl grcHouse;
        private DevExpress.XtraGrid.Views.Grid.GridView grwHouse;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.GridControl grcShop;
        private DevExpress.XtraGrid.Views.Grid.GridView grwShop;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn PropertyId;
        private DevExpress.XtraGrid.Columns.GridColumn OwnerId;
        private DevExpress.XtraGrid.Columns.GridColumn Area;
        private DevExpress.XtraGrid.Columns.GridColumn City;
        private DevExpress.XtraGrid.Columns.GridColumn County;
        private DevExpress.XtraGrid.Columns.GridColumn Address;
        private DevExpress.XtraGrid.Columns.GridColumn Price;
        private DevExpress.XtraGrid.Columns.GridColumn Description;
        private DevExpress.XtraGrid.Columns.GridColumn DeleteFlag;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}