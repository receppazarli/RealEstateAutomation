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

namespace RealEstateAutomation.WindowsFormUI.Forms.BaseForms
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
    }
}