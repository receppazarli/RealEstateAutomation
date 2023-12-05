﻿using DevExpress.XtraEditors;
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
using DevExpress.XtraLayout.Utils;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class ShopForm : DevExpress.XtraEditors.XtraForm
    {
        public ShopForm()
        {
            InitializeComponent();
            _shopService = InstanceFactory.GetInstance<IShopService>();
            _ownerService = InstanceFactory.GetInstance<IOwnerService>();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _countyService = InstanceFactory.GetInstance<ICountyService>();
        }

        private readonly IShopService _shopService;
        private readonly IOwnerService _ownerService;
        private readonly ICityService _cityService;
        private readonly ICountyService _countyService;
        private readonly CommonMethods _commonMethods = new CommonMethods();

        private void ShopForm_Load(object sender, EventArgs e)
        {
            LoadShop();
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

        void LoadShop()
        {
            try
            {
                using (RealEstateAutomationContext context = new RealEstateAutomationContext())
                {
                    var entity = from s in context.Shops
                                 join p in context.Properties on s.PropertyId equals p.Id
                                 join o in context.Owners on s.OwnerId equals o.Id
                                 join ci in context.Cities on s.City equals ci.Id
                                 join co in context.Counties on s.County equals co.Id
                                 select new
                                 {
                                     Id = s.Id,
                                     PropertyId = p.PropertyType,
                                     OwnerId = o.FirstName,
                                     Area = s.Area,
                                     City = ci.CityName,
                                     County = co.CountyName,
                                     Address = s.Address,
                                     Price = s.Price,
                                     Description = s.Description,
                                     DeleteFlag = s.DeleteFlag,
                                 };
                    grcShop.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

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
            lkuCity.EditValue = 0;
            lkuCounty.EditValue = 0;
            txtAddress.Text = "";
            txtPrice.Text = "0";
            txtDescription.Text = "";
        }

        void LoadClick()
        {
            if (grwShop.FocusedRowHandle >= 0)
            {
                txtId.Text = grwShop.GetFocusedRowCellValue("Id").ToString();
                lkuOwnerId.Text = grwShop.GetFocusedRowCellValue("OwnerId").ToString();
                txtArea.Text = grwShop.GetFocusedRowCellValue("Area").ToString();
                lkuCity.Text = grwShop.GetFocusedRowCellValue("City").ToString();
                lkuCounty.Text = grwShop.GetFocusedRowCellValue("County").ToString();
                txtAddress.Text = grwShop.GetFocusedRowCellValue("Address").ToString();
                txtPrice.Text = grwShop.GetFocusedRowCellValue("Price").ToString();
                txtDescription.Text = grwShop.GetFocusedRowCellValue("Description").ToString();
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

                    _shopService.Add(new Shop
                    {
                        OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                        PropertyId = 4,
                        Area = Convert.ToDecimal(txtArea.Text),
                        City = Convert.ToInt32(lkuCity.EditValue),
                        County = Convert.ToInt32(lkuCounty.EditValue),
                        Address = txtAddress.Text,
                        Price = Convert.ToDecimal(txtPrice.Text),
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });
                    LoadShop();
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
                    _shopService.Update(new Shop
                    {
                        Id = Convert.ToInt32(grwShop.GetRowCellValue(grwShop.FocusedRowHandle, "Id")),
                        PropertyId = Convert.ToInt32("4"),
                        OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                        Area = Convert.ToDecimal(txtArea.Text),
                        City = Convert.ToInt32(lkuCity.EditValue),
                        County = Convert.ToInt32(lkuCounty.EditValue),
                        Address = txtAddress.Text,
                        Price = Convert.ToDecimal(txtPrice.Text),
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });
                    LoadShop();
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

                _shopService.Update(new Shop
                {
                    Id = Convert.ToInt32(grwShop.GetRowCellValue(grwShop.FocusedRowHandle, "Id")),
                    PropertyId = Convert.ToInt32("4"),
                    OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                    Area = Convert.ToDecimal(txtArea.Text),
                    City = Convert.ToInt32(lkuCity.EditValue),
                    County = Convert.ToInt32(lkuCounty.EditValue),
                    Address = txtAddress.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Description = txtDescription.Text,
                    DeleteFlag = true
                });
                LoadShop();
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
            _commonMethods.ExcelTransfer(grwShop);
        }

        private void grwShop_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwShop.Focus();
                popupMenu1.ShowPopup(position);
            }
        }

        private void lookUpEdit3_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
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

        private void grcShop_Click(object sender, EventArgs e)
        {
            LoadClick();
        }
    }
}