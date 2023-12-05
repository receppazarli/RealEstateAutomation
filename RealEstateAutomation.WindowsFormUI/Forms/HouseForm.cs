using DevExpress.XtraEditors;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.WindowsFormUI.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;
using DevExpress.XtraBars;
using DevExpress.XtraLayout.Utils;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class HouseForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IHouseService _houseService;
        private readonly IOwnerService _ownerService;
        private readonly ICityService _cityService;
        private readonly ICountyService _countyService;
        private readonly CommonMethods _commonMethods = new CommonMethods();

        public HouseForm()
        {
            InitializeComponent();
            _houseService = InstanceFactory.GetInstance<IHouseService>();
            _ownerService = InstanceFactory.GetInstance<IOwnerService>();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _countyService = InstanceFactory.GetInstance<ICountyService>();
        }

        private void HouseForm_Load(object sender, EventArgs e)
        {
            LoadHouse();
            LoadOwner();
            LoadCity();
            LoadCounty();
        }

        void LoadOwner()
        {
            lkuOwnerId.Properties.DataSource = _ownerService.GetAll();
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

        void LoadHouse()
        {
            try
            {
                using (RealEstateAutomationContext context = new RealEstateAutomationContext())
                {
                    var entity = from h in context.Houses
                                 join p in context.Properties on h.PropertyId equals p.Id
                                 join o in context.Owners on h.OwnerId equals o.Id
                                 join ci in context.Cities on h.City equals ci.Id
                                 join co in context.Counties on h.County equals co.Id
                                 select new
                                 {
                                     Id = h.Id,
                                     PropertyId = p.PropertyType,
                                     OwnerId = o.FirstName,
                                     Area = h.Area,
                                     HouseType = h.HouseType,
                                     City = ci.CityName,
                                     County = co.CountyName,
                                     Address = h.Address,
                                     Price = h.Price,
                                     Description = h.Description,
                                     DeleteFlag = h.DeleteFlag,
                                 };
                    grcHouse.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        void Clear()
        {
            txtId.Text = "";
            lkuOwnerId.EditValue = 0;
            txtArea.Text = "0";
            txtHouseType.Text = "";
            lkuCity.EditValue = 0;
            lkuCounty.EditValue = 0;
            txtAddress.Text = "";
            txtPrice.Text = "0";
            txtDescription.Text = "";
        }

        void LoadClick()
        {
            if (grwHouse.FocusedRowHandle >= 0)
            {
                txtId.Text = grwHouse.GetFocusedRowCellValue("Id").ToString();
                lkuOwnerId.Text = grwHouse.GetFocusedRowCellValue("OwnerId").ToString();
                txtArea.Text = grwHouse.GetFocusedRowCellValue("Area").ToString();
                txtHouseType.Text = grwHouse.GetFocusedRowCellValue("HouseType").ToString();
                lkuCity.Text = grwHouse.GetFocusedRowCellValue("City").ToString();
                lkuCounty.Text = grwHouse.GetFocusedRowCellValue("County").ToString();
                txtAddress.Text = grwHouse.GetFocusedRowCellValue("Address").ToString();
                txtPrice.Text = grwHouse.GetFocusedRowCellValue("Price").ToString();
                txtDescription.Text = grwHouse.GetFocusedRowCellValue("Description").ToString();
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

                    _houseService.Add(new House
                    {
                        OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                        PropertyId = 3,
                        Area = Convert.ToDecimal(txtArea.Text),
                        HouseType = txtHouseType.Text,
                        City = Convert.ToInt32(lkuCity.EditValue),
                        County = Convert.ToInt32(lkuCounty.EditValue),
                        Address = txtAddress.Text,
                        Price = Convert.ToDecimal(txtPrice.Text),
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });
                    LoadHouse();
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
                    _houseService.Update(new House
                    {
                        Id = Convert.ToInt32(grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "Id")),
                        PropertyId = Convert.ToInt32("3"),
                        OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                        Area = Convert.ToDecimal(txtArea.Text),
                        HouseType = txtHouseType.Text,
                        City = Convert.ToInt32(lkuCity.EditValue),
                        County = Convert.ToInt32(lkuCounty.EditValue),
                        Address = txtAddress.Text,
                        Price = Convert.ToDecimal(txtPrice.Text),
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });
                    LoadHouse();
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

                _houseService.Update(new House
                {
                    Id = Convert.ToInt32(grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "Id")),
                    PropertyId = Convert.ToInt32("3"),
                    OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                    Area = Convert.ToDecimal(txtArea.Text),
                    HouseType = txtHouseType.Text,
                    City = Convert.ToInt32(lkuCity.EditValue),
                    County = Convert.ToInt32(lkuCounty.EditValue),
                    Address = txtAddress.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Description = txtDescription.Text,
                    DeleteFlag = true
                });
                LoadHouse();
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

        private void btnDelete2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Remove();
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
            _commonMethods.ExcelTransfer(grwHouse);
        }

        private void grwHouse_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwHouse.Focus();
                popupMenu1.ShowPopup(position);
            }
        }

        private void lookUpEdit2_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
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

        private void grcHouse_Click(object sender, EventArgs e)
        {
            LoadClick();
        }
    }
}