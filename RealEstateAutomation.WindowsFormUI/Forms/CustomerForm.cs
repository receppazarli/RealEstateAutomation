using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.Entities.Concrete;
using RealEstateAutomation.WindowsFormUI.Methods;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class CustomerForm : DevExpress.XtraEditors.XtraForm
    {
        public CustomerForm()
        {
            InitializeComponent();

            _customerService = InstanceFactory.GetInstance<ICustomerService>();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _countyService = InstanceFactory.GetInstance<ICountyService>();
        }


        private readonly ICustomerService _customerService;
        private readonly ICityService _cityService;
        private readonly ICountyService _countyService;
        private readonly CommonMethods _commonMethods = new CommonMethods();

        
        private void BaseFormData_Load(object sender, EventArgs e)
        {
            LoadCustomer();
            LoadCity();
        }

        private void LoadCustomer()
        {
            grcCustomer.DataSource = _customerService.GetAll();
        }

        //Şehirleri lookupedeite listeleme 
        private void LoadCity()
        {
            lkuCity.Properties.DataSource = _cityService.GetAll();
            lkuCity.Properties.DisplayMember = "CityName";
            lkuCity.Properties.ValueMember = "Id";
        }

        // Şehire göre  İlçe listeleme
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

        private void LoadClick()
        {
            if (grwCustomers.FocusedRowHandle >= 0)
            {
                btnNationalityId.Text = grwCustomers.GetFocusedRowCellValue("NationalityId").ToString();
                txtFirstName.Text = grwCustomers.GetFocusedRowCellValue("FirstName").ToString();
                txtLastName.Text = grwCustomers.GetFocusedRowCellValue("LastName").ToString();
                btnPhone.Text = grwCustomers.GetFocusedRowCellValue("Phone").ToString();
                lkuCounty.Text = grwCustomers.GetFocusedRowCellValue("County").ToString();
                lkuCity.Text = grwCustomers.GetFocusedRowCellValue("City").ToString();
                txtAddress.Text = grwCustomers.GetFocusedRowCellValue("Address").ToString();
                txtDescription.Text = grwCustomers.GetFocusedRowCellValue("Description").ToString();
                txtId.Text = grwCustomers.GetFocusedRowCellValue("Id").ToString();
                txtDeleteflag.Text = grwCustomers.GetFocusedRowCellValue("DeleteFlag").ToString();
            }
        }


        private void grcCustomer_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        private void Clear()
        {
            btnNationalityId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            btnPhone.Text = "";
            lkuCounty.EditValue = null;
            lkuCity.EditValue = null;
            txtAddress.Text = "";
            txtDescription.Text = "";
            txtId.Text = "";
            txtDeleteflag.Text = "";
        }



        private void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult confirmation = MessageBox.Show(@"Are you sure you want to save the information?", @"Information", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    _customerService.Add(new Customer
                    {
                        NationalityId = btnNationalityId.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Phone = btnPhone.Text,
                        City = lkuCity.Text,
                        County = lkuCounty.Text,
                        Address = txtAddress.Text,
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });
                    LoadCustomer();
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
                    _customerService.Update(new Customer()
                    {
                        Id = Convert.ToInt32(grwCustomers.GetRowCellValue(grwCustomers.FocusedRowHandle, "Id")),
                        NationalityId = btnNationalityId.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Phone = btnPhone.Text,
                        City = lkuCity.Text,
                        County = lkuCounty.Text,
                        Address = txtAddress.Text,
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });
                    LoadCustomer();
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
            DialogResult confirmation = MessageBox.Show(@"Are you sure you want to delete your information?",
                @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                _customerService.Update(new Customer()
                {
                    Id = Convert.ToInt32(grwCustomers.GetRowCellValue(grwCustomers.FocusedRowHandle, "Id")),
                    NationalityId = btnNationalityId.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Phone = btnPhone.Text,
                    City = lkuCity.Text,
                    County = lkuCounty.Text,
                    Address = txtAddress.Text,
                    Description = txtDescription.Text,
                    DeleteFlag = true
                });
                LoadCustomer();
                Clear();
            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnNew_Click(object sender, EventArgs e)
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void grwCustomers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwCustomers.Focus();
                popupMenu1.ShowPopup(position);
            }
        }

        private void btnExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            _commonMethods.ExcelTransfer(grwCustomers);
        }

        private void btnNew2_ItemClick(object sender, ItemClickEventArgs e)
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


    }
}