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
        }

        private ICustomerService _customerService;

        private void BaseFormData_Load(object sender, EventArgs e)
        {
            grcCustomer.DataSource = _customerService.GetAll();
        }
    }
}