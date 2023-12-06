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

        public void OpenForm<T>() where T : Form, new()
        {
            // MDI çocuk formlar arasında belirtilen form türünü ara
            foreach (Form form in this.MdiChildren)
            {
                if (form is T)
                {
                    // Form zaten açıksa ona odaklan ve metoddan çık
                    form.Activate();
                    return;
                }
            }

            // Form açık değilse yeni bir örnek oluştur ve göster
            T newForm = new T
            {
                MdiParent = this
            };
            newForm.Show();
        }


        private void btnCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<CustomerForm>();
        }

        private void btnAdmin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<AdminForm>();
        }

        private void btnEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<EmployeeForm>();
        }

        private void btnOwners_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<OwnerForm>();
        }

        private void btnFıelds_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<FieldForm>();
        }

        private void btnPlots_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<PlotForm>();
        }

        private void btnHouses_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<HouseForm>();
        }

        private void btnShops_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<ShopForm>();
        }

        private void btnProperties_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<PropertyForm>();
        }
    }
}