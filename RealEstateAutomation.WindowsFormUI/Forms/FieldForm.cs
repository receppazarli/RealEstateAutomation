using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;
using RealEstateAutomation.WindowsFormUI.Methods;
using DevExpress.XtraBars;
using DevExpress.XtraLayout.Utils;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class FieldForm : DevExpress.XtraEditors.XtraForm
    {
        public FieldForm()
        {
            InitializeComponent();
            _fieldService = InstanceFactory.GetInstance<IFieldService>();
            _propertyService = InstanceFactory.GetInstance<IPropertyService>();
            _ownerService = InstanceFactory.GetInstance<IOwnerService>();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _countyService = InstanceFactory.GetInstance<ICountyService>();


        }

        private readonly IFieldService _fieldService;
        private readonly IPropertyService _propertyService;
        private readonly IOwnerService _ownerService;
        private readonly ICityService _cityService;
        private readonly ICountyService _countyService;
        private readonly CommonMethods _commonMethods = new CommonMethods();

        private void FieldForm_Load(object sender, EventArgs e)
        {
            LoadField();
            // LoadProperty();
            LoadCity();
            LoadCounty();
            LoadOwner();
        }

        //void LoadProperty()
        //{
        //    lkuPropertyId.Properties.DataSource = _propertyService.GetAll();
        //    lkuPropertyId.Properties.DisplayMember = "PropertyType";
        //    lkuPropertyId.Properties.ValueMember = "Id";
        //}

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

        void LoadField()
        {
            try
            {
                using (RealEstateAutomationContext context = new RealEstateAutomationContext())
                {
                    var entity = from f in context.Fields
                                 join p in context.Properties on f.PropertyId equals p.Id
                                 join o in context.Owners on f.OwnerId equals o.Id
                                 join ci in context.Cities on f.City equals ci.Id
                                 join co in context.Counties on f.County equals co.Id
                                 select new
                                 {
                                     Id = f.Id,
                                     PropertyId = p.PropertyType,
                                     OwnerId = o.FirstName,
                                     Area = f.Area,
                                     Pafta = f.Pafta,
                                     City = ci.CityName,
                                     County = co.CountyName,
                                     Address = f.Address,
                                     Price = f.Price,
                                     Description = f.Description,
                                     DeleteFlag = f.DeleteFlag,
                                 };
                    grcField.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

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
            txtPafta.Text = "";
            lkuCity.EditValue = 0;
            lkuCounty.EditValue = 0;
            txtAddress.Text = "";
            txtPrice.Text = "0";
            txtDescription.Text = "";
            txtDeleteFlag.Text = "";
        }

        void LoadClick()
        {
            if (grwField.FocusedRowHandle >= 0)
            {
                txtId.Text = grwField.GetFocusedRowCellValue("Id").ToString();
                lkuOwnerId.Text = grwField.GetFocusedRowCellValue("OwnerId").ToString();
                txtArea.Text = grwField.GetFocusedRowCellValue("Area").ToString();
                txtPafta.Text = grwField.GetFocusedRowCellValue("Pafta").ToString();
                lkuCity.Text = grwField.GetFocusedRowCellValue("City").ToString();
                lkuCounty.Text = grwField.GetFocusedRowCellValue("County").ToString();
                txtAddress.Text = grwField.GetFocusedRowCellValue("Address").ToString();
                txtPrice.Text = grwField.GetFocusedRowCellValue("Price").ToString();
                txtDescription.Text = grwField.GetFocusedRowCellValue("Description").ToString();
                txtDeleteFlag.Text = grwField.GetFocusedRowCellValue("DeleteFlag").ToString();
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

                    _fieldService.Add(new Field
                    {
                        OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                        PropertyId = 1,
                        Area = Convert.ToDecimal(txtArea.Text),
                        Pafta = txtPafta.Text,
                        City = Convert.ToInt32(lkuCity.EditValue),
                        County = Convert.ToInt32(lkuCounty.EditValue),
                        Address = txtAddress.Text,
                        Price = Convert.ToDecimal(txtPrice.Text),
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });
                    LoadField();
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
                    _fieldService.Update(new Field
                    {
                        Id = Convert.ToInt32(grwField.GetRowCellValue(grwField.FocusedRowHandle, "Id")),
                        PropertyId = Convert.ToInt32("1"),
                        OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                        Area = Convert.ToDecimal(txtArea.Text),
                        Pafta = txtPafta.Text,
                        City = Convert.ToInt32(lkuCity.EditValue),
                        County = Convert.ToInt32(lkuCounty.EditValue),
                        Address = txtAddress.Text,
                        Price = Convert.ToDecimal(txtPrice.Text),
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });
                    LoadField();
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

                _fieldService.Update(new Field
                {
                    Id = Convert.ToInt32(grwField.GetRowCellValue(grwField.FocusedRowHandle, "Id")),
                    PropertyId = Convert.ToInt32("1"),
                    OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                    Area = Convert.ToDecimal(txtArea.Text),
                    Pafta = txtPafta.Text,
                    City = Convert.ToInt32(lkuCity.EditValue),
                    County = Convert.ToInt32(lkuCounty.EditValue),
                    Address = txtAddress.Text,
                    Price = Convert.ToDecimal(txtPrice.Text),
                    Description = txtDescription.Text,
                    DeleteFlag = true
                });
                LoadField();
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
            _commonMethods.ExcelTransfer(grwField);
        }

        private void grcField_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        private void grwField_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwField.Focus();
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

        private void lkuCity_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.DisplayText = "";
            }
        }

        private void lkuCounty_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.DisplayText = "";
            }
        }

        private void txtArea_EditValueChanged(object sender, EventArgs e)
        {
            var editor = sender as TextEdit;
            if (editor != null)
            {
                string input = editor.Text.Trim();

                // Özel bir durumu kontrol edin, örneğin, girişin boş olup olmadığını
                if (string.IsNullOrEmpty(input))
                {
                    // Belirli bir koşul altında TextEdit metnini ayarlayın
                    editor.Text = ""; // veya istediğiniz başka bir değer
                }
                else
                {
                    // Normal giriş işleme
                }
            }
        }

        private OwnerForm _ownerForm = new OwnerForm();
        private void btnOwnerAdd_Click(object sender, EventArgs e)
        {
            // _ownerForm.Height = 600;
            // _ownerForm.Width = 1000;
            _ownerForm.ribbonControl1.Visible = true;
            _ownerForm.lcSave.Visibility = LayoutVisibility.Never;
            _ownerForm.lcDelete.Visibility = LayoutVisibility.Never;
            _ownerForm.lcClear.Visibility = LayoutVisibility.Never;
            _ownerForm.ShowDialog();
            LoadOwner();
        }



    }
}