using System;
using System.Linq;
using System.Windows.Forms;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.Entities.Concrete;
using RealEstateAutomation.WindowsFormUI.Methods;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class AdminForm : DevExpress.XtraEditors.XtraForm
    {
        public AdminForm()
        {
            InitializeComponent();

            _adminService = InstanceFactory.GetInstance<IAdminService>();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _countyService = InstanceFactory.GetInstance<ICountyService>();
            _userService = InstanceFactory.GetInstance<IUserService>();
        }

        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly ICityService _cityService;
        private readonly ICountyService _countyService;
        private readonly CommonMethods _commonMethods = new CommonMethods();

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadAdmin();
            LoadCity();
        }

        private void LoadAdmin()
        {
            grcAdmin.DataSource = _adminService.GetAll();
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

        void LoadClick()
        {
            if (grwAdmin.FocusedRowHandle >= 0)
            {
                txtId.Text = grwAdmin.GetFocusedRowCellValue("Id").ToString();
                txtNationalityId.Text = grwAdmin.GetFocusedRowCellValue("NationalityId").ToString();
                txtNationalityId.ReadOnly = true;
                txtFirstName.Text = grwAdmin.GetFocusedRowCellValue("FirstName").ToString();
                txtLastName.Text = grwAdmin.GetFocusedRowCellValue("LastName").ToString();
                btnPhone.Text = grwAdmin.GetFocusedRowCellValue("Phone").ToString();
                txtEmail.Text = grwAdmin.GetFocusedRowCellValue("Email").ToString();
                lkuCounty.Text = grwAdmin.GetFocusedRowCellValue("County").ToString();
                lkuCity.Text = grwAdmin.GetFocusedRowCellValue("City").ToString();
                txtAddress.Text = grwAdmin.GetFocusedRowCellValue("Address").ToString();
                txtDeleteFlag.Text = grwAdmin.GetFocusedRowCellValue("DeleteFlag").ToString();
            }
        }

        private void grcAdmin_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        void Clear()
        {
            txtNationalityId.Text = "";
            txtNationalityId.ReadOnly = false;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            btnPhone.Text = "";
            txtEmail.Text = "";
            lkuCounty.EditValue = null;
            lkuCity.EditValue = null;
            txtAddress.Text = "";
            txtId.Text = "";
            txtDeleteFlag.Text = "";
        }

        private void btnExcelTransfer2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _commonMethods.ExcelTransfer(grwAdmin);
        }

        void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult confirmation = MessageBox.Show(@"Are you sure you want to save the information?", @"Information", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    _userService.Add(new User
                    {
                        UserName = txtNationalityId.Text,
                        UserPassword = "1234",
                        UserAuthorization = 1,
                        DeleteFlag = false
                    });

                    User lastAddedUser = _userService.GetLastAddedUser();
                    int newUserId = 0;
                    newUserId = lastAddedUser?.Id ?? 0;

                    if (newUserId != -1 && newUserId != 0)
                    {
                        try
                        {
                            _adminService.Add(new Admin
                            {
                                UserId = newUserId,
                                NationalityId = txtNationalityId.Text,
                                FirstName = txtFirstName.Text,
                                LastName = txtLastName.Text,
                                Phone = btnPhone.Text,
                                Email = txtEmail.Text,
                                City = lkuCity.Text,
                                County = lkuCounty.Text,
                                Address = txtAddress.Text,
                                DeleteFlag = false
                            });
                        }
                        catch (Exception e)
                        {
                            _userService.Delete(new User
                            {
                                Id = newUserId
                            });

                            MessageBox.Show(
                                e.InnerException == null ? e.Message : "This record already exists please check your details",
                                @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    LoadAdmin();
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
                    _adminService.Update(new Admin
                    {
                        Id = Convert.ToInt32(grwAdmin.GetRowCellValue(grwAdmin.FocusedRowHandle, "Id")),
                        UserId = Convert.ToInt32(grwAdmin.GetRowCellValue(grwAdmin.FocusedRowHandle, "UserId")),
                        NationalityId = txtNationalityId.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Phone = btnPhone.Text,
                        Email = txtEmail.Text,
                        City = lkuCity.Text,
                        County = lkuCounty.Text,
                        Address = txtAddress.Text,
                        DeleteFlag = false
                    });
                    LoadAdmin();
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
                try
                {
                    _adminService.Update2(new Admin
                    {
                        Id = Convert.ToInt32(grwAdmin.GetRowCellValue(grwAdmin.FocusedRowHandle, "Id")),
                        UserId = Convert.ToInt32(grwAdmin.GetRowCellValue(grwAdmin.FocusedRowHandle, "UserId")),
                        NationalityId = txtNationalityId.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Phone = btnPhone.Text,
                        Email = txtEmail.Text,
                        City = lkuCity.Text,
                        County = lkuCounty.Text,
                        Address = txtAddress.Text,
                        DeleteFlag = true
                    });

                    int userId = Convert.ToInt32(grwAdmin.GetRowCellValue(grwAdmin.FocusedRowHandle, "UserId"));
                    User updateUser = _userService.GetAll().FirstOrDefault(x => x.Id == userId);
                    string userName = "";
                    string password = "";

                    if (updateUser != null)
                    {
                        userName = updateUser.UserName;
                        password = updateUser.UserPassword;
                    }

                    _userService.Update(new User
                    {
                        Id = Convert.ToInt32(grwAdmin.GetRowCellValue(grwAdmin.FocusedRowHandle, "UserId")),
                        UserName = userName,
                        UserPassword = password,
                        UserAuthorization = 1,
                        DeleteFlag = true
                    });
                }

                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.InnerException == null ? ex.Message : "This record already exists please check your details",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                LoadAdmin();
                Clear();
            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }

        private void btnSave2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnRemove2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Remove();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
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

        private void grcAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwAdmin.Focus();
                popupMenu1.ShowPopup(position);
            }
        }


    }
}