using RealEstateAutomation.Business.Abstract;
using System;
using System.Linq;
using System.Windows.Forms;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class UserForm : DevExpress.XtraEditors.XtraForm
    {
        public UserForm()
        {
            InitializeComponent();
            _userService = InstanceFactory.GetInstance<IUserService>();
        }

        private readonly IUserService _userService;
        public static int UserId;
        public static int UserAuthorization;
        public static string UserName;
        public static string UserPassword;

        private bool Control(string userName, string password)
        {
            var query = _userService.GetAll().Where(x => x.UserName == userName && x.UserPassword == password);

            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void LoadUser()
        {
            var enteredUser = _userService.GetAll()
                .FirstOrDefault(x => x.Id == LoginForm.EnteredUserId);

            if (enteredUser != null)
            {
                UserId = enteredUser.Id;
                UserAuthorization = enteredUser.UserAuthorization;
                UserName = enteredUser.UserName;
                UserPassword = enteredUser.UserPassword;
            }

            txtUsername.Text = UserName;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show(@"Are you sure you want to update your password?",
                @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmation == DialogResult.Yes)
            {
                if (Control(txtUsername.Text, txtOldPassword.Text))
                {
                    _userService.Update(new User
                    {
                        Id = UserId,
                        UserName = txtUsername.Text,
                        UserPassword = txtNewPassword.Text,
                        UserAuthorization = UserAuthorization,
                        DeleteFlag = false
                    });
                    MessageBox.Show(@"Your password has been successfully changed.", @"Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(@"Password incorrect please try again", @"Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOldPasswordHidden_Click(object sender, EventArgs e)
        {
            txtOldPassword.Properties.UseSystemPasswordChar = false;
            btnOldPasswordHidden.Visible = false;
            btnOldPasswordVisible.Visible = true;
        }

        private void btnOldPasswordVisible_Click(object sender, EventArgs e)
        {
            txtOldPassword.Properties.UseSystemPasswordChar = true;
            btnOldPasswordHidden.Visible = true;
            btnOldPasswordVisible.Visible = false;
        }

        private void btnNewPasswordHidden_Click(object sender, EventArgs e)
        {
            txtNewPassword.Properties.UseSystemPasswordChar = false;
            btnNewPasswordHidden.Visible = false;
            btnNewPasswordVisible.Visible = true;
        }

        private void btnNewPasswordVisible_Click(object sender, EventArgs e)
        {

            txtNewPassword.Properties.UseSystemPasswordChar = true;
            btnNewPasswordHidden.Visible = true;
            btnNewPasswordVisible.Visible = false;
        }
    }
}