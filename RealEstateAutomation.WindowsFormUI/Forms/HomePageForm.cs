using System;
using System.Windows.Forms;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class HomePageForm : DevExpress.XtraEditors.XtraForm
    {
        public HomePageForm()
        {
            InitializeComponent();
            OpenForm<HomePage2>();
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            PanelControl();
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

        public void PanelControl()
        {
            try
            {
                if (LoginForm.EnteredUserAuthorization == 1)
                {
                    ribbonPageEmployees.Visible = true;
                    ribbonPageGroupProperties.Visible = true;
                }
                else if (LoginForm.EnteredUserAuthorization == 2)
                {
                    ribbonPageEmployees.Visible = false;
                    ribbonPageGroupProperties.Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Error Loading System. Please try again.", @"Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


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

        private void btnSales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<SaleForm>();
        }

        private void btnIncome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<IncomeForm>();
        }

        private void btnExpenses_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<ExpenseForm>();
        }

        private void HomePageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private UserForm _userForm = new UserForm();

        private void btnUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _userForm.ShowDialog();
        }

        private void btnHomePage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm<HomePage2>();
        }
    }
}