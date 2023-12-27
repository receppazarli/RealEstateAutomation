using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.WindowsFormUI.Methods;
using System;
using System.Linq;
using System.Windows.Forms;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;
using DevExpress.XtraLayout.Utils;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class PlotForm : DevExpress.XtraEditors.XtraForm
    {
        public PlotForm()
        {
            InitializeComponent();
            _plotService = InstanceFactory.GetInstance<IPlotService>();
            _propertyService = InstanceFactory.GetInstance<IPropertyService>();
            _ownerService = InstanceFactory.GetInstance<IOwnerService>();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _countyService = InstanceFactory.GetInstance<ICountyService>();
        }

        private void PlotForm_Load(object sender, EventArgs e)
        {
            LoadPlot();
            LoadOwner();
            LoadCity();
            LoadCounty();
        }

        private readonly IPlotService _plotService;
        private readonly IPropertyService _propertyService;
        private readonly IOwnerService _ownerService;
        private readonly ICityService _cityService;
        private readonly ICountyService _countyService;
        private readonly CommonMethods _commonMethods = new CommonMethods();

        void LoadOwner()
        {
            lkuOwnerId.Properties.DataSource = _ownerService.GetAll();
            lkuOwnerId.Properties.DisplayMember = "FirstName";
            lkuOwnerId.Properties.ValueMember = "Id";
        }

        void LoadOwner2()
        {
            lkuOwnerId.Properties.DataSource = _ownerService.GetAll2();
            lkuOwnerId.Properties.DisplayMember = "FirstName";
            lkuOwnerId.Properties.ValueMember = "Id";
        }

        private void LoadCity()
        {
            lkuCity.Properties.DataSource = _cityService.GetAll();
            lkuCity.Properties.DisplayMember = "CityName";
            lkuCity.Properties.ValueMember = "Id";
        }

        private void LoadCounty()
        {
            lkuCounty.Properties.DataSource = _countyService.GetAll(Convert.ToInt32(lkuCity.EditValue)).ToList();
            lkuCounty.Properties.DisplayMember = "CountyName";
            lkuCounty.Properties.ValueMember = "Id";
        }

        private void lkuCity_EditValueChanged(object sender, EventArgs e)
        {
            LoadCounty();
        }

        void LoadPlot()
        {
            try
            {
                using (RealEstateAutomationContext context = new RealEstateAutomationContext())
                {
                    var entity = from pl in context.Plots
                                 join p in context.Properties on pl.PropertyId equals p.Id
                                 join o in context.Owners on pl.OwnerId equals o.Id
                                 join ci in context.Cities on pl.City equals ci.Id
                                 join co in context.Counties on pl.County equals co.Id
                                 select new
                                 {
                                     Id = pl.Id,
                                     PropertyId = pl.PropertyId,
                                     OwnerId = pl.OwnerId,
                                     OwnerName = o.FirstName,
                                     Area = pl.Area,
                                     Ada = pl.Ada,
                                     Pafta = pl.Pafta,
                                     City = ci.CityName,
                                     County = co.CountyName,
                                     Address = pl.Address,
                                     Price = pl.Price,
                                     Description = pl.Description,
                                     Sold = pl.Sold,
                                     DeleteFlag = pl.DeleteFlag,
                                 };
                    grcPlot.DataSource = entity.ToList().Where(x => x.DeleteFlag == false && x.Sold == false);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Clear()
        {
            txtId.Text = "";
            txtPropertyType.Text = "";
            lkuOwnerId.EditValue = 0;
            LoadOwner();
            txtArea.Text = "0";
            txtAda.Text = "";
            txtPafta.Text = "";
            lkuCity.EditValue = 0;
            lkuCounty.EditValue = 0;
            txtAddress.Text = "";
            txtPrice.Text = "0";
            txtDescription.Text = "";
        }

        void LoadClick()
        {
            if (grwPlot.FocusedRowHandle >= 0)
            {
                txtId.Text = grwPlot.GetFocusedRowCellValue("Id").ToString();
                txtPropertyType.Text = grwPlot.GetFocusedRowCellValue("PropertyId").ToString();
                LoadOwner2();
                lkuOwnerId.EditValue = grwPlot.GetFocusedRowCellValue("OwnerId");
                txtArea.Text = grwPlot.GetFocusedRowCellValue("Area").ToString();
                txtAda.Text = grwPlot.GetFocusedRowCellValue("Ada").ToString();
                txtPafta.Text = grwPlot.GetFocusedRowCellValue("Pafta").ToString();
                lkuCity.Text = grwPlot.GetFocusedRowCellValue("City").ToString();
                lkuCounty.Text = grwPlot.GetFocusedRowCellValue("County").ToString();
                txtAddress.Text = grwPlot.GetFocusedRowCellValue("Address").ToString();
                txtPrice.Text = grwPlot.GetFocusedRowCellValue("Price").ToString();
                txtDescription.Text = grwPlot.GetFocusedRowCellValue("Description").ToString();
            }
        }

        void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult confirmation = MessageBox.Show(@"Are you sure you want to save the information?", @"Information", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {

                    _propertyService.Add(new Property
                    {
                        PropertyType = "Plot",
                        DeleteFlag = false
                    });

                    Property lastAddedProperty = _propertyService.GetLastAddedProperty();
                    int newPropertyId = 0;
                    newPropertyId = lastAddedProperty?.Id ?? -1;

                    if (newPropertyId != -1 && newPropertyId != 0)
                    {
                        try
                        {
                            _plotService.Add(new Plot
                            {
                                OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                                PropertyId = newPropertyId,
                                Area = Convert.ToDecimal(txtArea.Text),
                                Ada = txtAda.Text,
                                Pafta = txtPafta.Text,
                                City = Convert.ToInt32(lkuCity.EditValue),
                                County = Convert.ToInt32(lkuCounty.EditValue),
                                Address = txtAddress.Text,
                                Price = Convert.ToDecimal(txtPrice.Text),
                                Description = txtDescription.Text,
                                Sold = false,
                                DeleteFlag = false
                            });

                            Plot lastAddedHouse = _plotService.GetLastAddedHouse();
                            int newPlotId = 0;
                            newPlotId = lastAddedHouse?.Id ?? -1;

                            if (newPlotId != -1 && newPlotId != 0)
                            {
                                _propertyService.Update(new Property
                                {
                                    Id = newPropertyId,
                                    ReferenceId = newPlotId,
                                    PropertyType = "Plot",
                                    DeleteFlag = false
                                });
                            }
                        }
                        catch (Exception e)
                        {
                            _propertyService.Delete(new Property
                            {
                                Id = newPropertyId
                            });
                            MessageBox.Show(
                                e.InnerException == null ? e.Message : "This record already exists please check your details",
                                @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    LoadPlot();
                    Clear();
                }
                else
                {
                    MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else if (txtId.Text != "")
            {
                DialogResult confirmation = MessageBox.Show(@"Are you sure you want to update the information?",
                    @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    _plotService.Update(new Plot
                    {
                        Id = Convert.ToInt32(grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "Id")),
                        PropertyId = Convert.ToInt32(txtPropertyType.Text),
                        OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                        Area = Convert.ToDecimal(txtArea.Text),
                        Ada = txtAda.Text,
                        Pafta = txtPafta.Text,
                        City = Convert.ToInt32(lkuCity.EditValue),
                        County = Convert.ToInt32(lkuCounty.EditValue),
                        Address = txtAddress.Text,
                        Price = Convert.ToDecimal(txtPrice.Text),
                        Description = txtDescription.Text,
                        Sold = false,
                        DeleteFlag = false
                    });
                    LoadPlot();
                    Clear();

                }
                else
                {
                    MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        void Remove()
        {
            DialogResult confirmation = MessageBox.Show(@"Are you sure you want to update the information?",
                @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {

                _plotService.Update(new Plot
                {
                    Id = Convert.ToInt32(grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "Id")),
                    PropertyId = Convert.ToInt32(grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "PropertyId")),
                    OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                    Area = Convert.ToDecimal(txtArea.Text),
                    Ada = txtAda.Text,
                    Pafta = txtPafta.Text,
                    City = Convert.ToInt32(lkuCity.EditValue),
                    County = Convert.ToInt32(lkuCounty.EditValue),
                    Address = txtAddress.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Description = txtDescription.Text,
                    Sold = false,
                    DeleteFlag = true
                });
                LoadPlot();
                Clear();


            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }

        private void btnClear2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult confirmation = MessageBox.Show(@"Are you sure you want to clear the boxes?",
                @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                Clear();
            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show(@"Are you sure you want to clear the boxes?",
                @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                Clear();
            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void btnDelete2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Remove();
        }

        private void btnSave2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnExcelTransfer2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _commonMethods.ExcelTransfer(grwPlot);
        }

        private void grwPlot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwPlot.Focus();
                popupMenu1.ShowPopup(position);
            }
        }

        private void lkuOwnerId_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.DisplayText = "";
            }
        }

        private void lkuCity_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.DisplayText = "";
            }
        }

        private void lkuCounty_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.DisplayText = "";
            }
        }

        private OwnerForm _ownerForm = new OwnerForm();
        private void btnOwnerAdd_Click(object sender, EventArgs e)
        {
            _ownerForm.ribbonControl1.Visible = true;
            _ownerForm.lcSave.Visibility = LayoutVisibility.Never;
            _ownerForm.lcDelete.Visibility = LayoutVisibility.Never;
            _ownerForm.lcClear.Visibility = LayoutVisibility.Never;
            _ownerForm.ShowDialog();
            LoadOwner();
        }

        private void grcPlot_Click(object sender, EventArgs e)
        {
            LoadClick();
        }
    }
}