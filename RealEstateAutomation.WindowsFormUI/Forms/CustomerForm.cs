using System;
using System.Linq;
using System.Windows.Forms;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.Entities.Concrete;

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
                txtNationalityId.Text = grwCustomers.GetFocusedRowCellValue("NationalityId").ToString();
                txtFirstName.Text = grwCustomers.GetFocusedRowCellValue("FirstName").ToString();
                txtLastName.Text = grwCustomers.GetFocusedRowCellValue("LastName").ToString();
                txtPhone.Text = grwCustomers.GetFocusedRowCellValue("Phone").ToString();
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

        private void Clean()
        {
            txtNationalityId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            lkuCounty.EditValue = null;
            lkuCity.EditValue = null;
            txtAddress.Text = "";
            txtDescription.Text = "";
            txtId.Text = "";
            txtDeleteflag.Text = "";
        }

        // City ve county int olarak geliyor ordan devam edilecek. Customer ekranı kayıt etme, silme,yeni kayıt ve sağ click eklenecek.


        //private void Save()
        //{
        //    if (txtId.Text == "")
        //    {
        //        DialogResult Confirmation = MessageBox.Show(@"Are you sure you want to save the information?", @"Information", MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Information);

        //        if (Confirmation == DialogResult.Yes)
        //        {
        //            _customerService.Add(new Customer
        //            {
        //                NationalityId = txtNationalityId.Text,
        //                FirstName = txtFirstName.Text,
        //                LastName = txtLastName.Text,
        //                Phone = txtPhone.Text,
        //                City = lkuCity.Text,
        //                County = lkuCounty.Text,
        //                Address = txtAddress.Text,
        //                Description = txtDescription.Text,
        //                DeleteFlag = false
        //            });
        //            LoadCustomer();
        //            Clean();
        //        }
        //        else
        //        {
        //            MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
        //                MessageBoxIcon.Information);
        //        }
        //    }
        //    else if (txtId.Text != "")
        //    {
        //        DialogResult Confirmation = MessageBox.Show(@"Are you sure you want to update the information?",
        //            @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //        if (Confirmation == DialogResult.Yes)
        //        {
        //            _customerService.Update( new Customer()
        //            {
        //                Id = Convert.ToInt32(grwCustomers.GetRowCellValue(grwCustomers.FocusedRowHandle,"Id")),
        //                NationalityId = txtNationalityId.Text,
        //                FirstName = txtFirstName.Text,
        //                LastName = txtLastName.Text,
        //                Phone = txtPhone.Text,
        //                City = lkuCity.Text,
        //                County = lkuCounty.Text,
        //                Address = txtAddress.Text,
        //                Description = txtDescription.Text,
        //                DeleteFlag = false
        //            });
        //            LoadCustomer();
        //            Clean();
        //        }
        //        else
        //        {
        //            MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
        //                MessageBoxIcon.Information);
        //        }
        //    }
        //}
    }
}