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

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class HomePageForm : DevExpress.XtraEditors.XtraForm
    {
        public HomePageForm()
        {
            InitializeComponent();
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {

        }

        private void btnCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.MdiParent = this;
            customerForm.Show();
        }
    }
}