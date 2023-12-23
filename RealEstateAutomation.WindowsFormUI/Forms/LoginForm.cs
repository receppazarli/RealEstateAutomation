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

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
            _userService = InstanceFactory.GetInstance<IUserService>();
        }

        private readonly IUserService _userService;
        public static int EnteredUserId;
        public static int EnteredUserAuthorization;
        public static string EnteredUserName;
        public static string EnteredUserPassword;

        private void OpenForm(Form form)
        {

            form.Show();
        }

        private bool AuthorizationControl1(string userName, string password, int authorization)
        {
            var query = _userService.GetAll().Where(x =>
                x.UserName == userName && x.UserPassword == password && x.UserAuthorization == 1);

            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool AuthorizationControl2(string userName, string password, int authorization)
        {
            var query = _userService.GetAll().Where(x =>
                x.UserName == userName && x.UserPassword == password && x.UserAuthorization == 2);

            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show(@"Username and Password cannot be empty.", @"Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtUserName.Text == "")
            {
                MessageBox.Show(@"Username cannot be empty.", @"Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show(@"Password cannot be empty.", @"Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var enteredUser = _userService.GetAll()
                    .FirstOrDefault(x => x.UserPassword == txtPassword.Text && x.UserName == txtUserName.Text);

                if (enteredUser != null)
                {
                    EnteredUserId = enteredUser.Id;
                    EnteredUserAuthorization = enteredUser.UserAuthorization;
                    EnteredUserName = enteredUser.UserName;
                    EnteredUserPassword = enteredUser.UserPassword;
                }

                if (AuthorizationControl1(txtUserName.Text, txtPassword.Text, 1))
                {
                    OpenForm(new HomePageForm());
                    this.Hide();
                }
                else if (AuthorizationControl2(txtUserName.Text, txtPassword.Text, 2))
                {
                    OpenForm(new HomePageForm());
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(@"Username or password is incorrect, please try again.", @"Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult Confirmation = MessageBox.Show(@"Are you sure you want to close?",
                @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Confirmation == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}