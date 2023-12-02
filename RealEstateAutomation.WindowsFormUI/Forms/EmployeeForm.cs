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
using RealEstateAutomation.WindowsFormUI.Methods;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class EmployeeForm : DevExpress.XtraEditors.XtraForm
    {
        public EmployeeForm()
        {
            InitializeComponent();
            _employeeService = InstanceFactory.GetInstance<IEmployeeService>();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _countyService = InstanceFactory.GetInstance<ICountyService>();
        }

        private readonly IEmployeeService _employeeService;
        private readonly ICityService _cityService;
        private readonly ICountyService _countyService;
        private readonly CommonMethods _commonMethods = new CommonMethods();

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadEmployee();
            LoadCity();
        }

        void LoadEmployee()
        {
            grcEmployee.DataSource = _employeeService.GetAll();
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

        void Clear()
        {
            txtNationalityId.Text = "";
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



        void LoadClick()
        {
            if (grwEmployee.FocusedRowHandle >= 0)
            {
                txtId.Text = grwEmployee.GetFocusedRowCellValue("Id").ToString();
                txtNationalityId.Text = grwEmployee.GetFocusedRowCellValue("NationalityId").ToString();
                txtFirstName.Text = grwEmployee.GetFocusedRowCellValue("FirstName").ToString();
                txtLastName.Text = grwEmployee.GetFocusedRowCellValue("LastName").ToString();
                btnPhone.Text = grwEmployee.GetFocusedRowCellValue("Phone").ToString();
                txtEmail.Text = grwEmployee.GetFocusedRowCellValue("Email").ToString();
                lkuCounty.Text = grwEmployee.GetFocusedRowCellValue("County").ToString();
                lkuCity.Text = grwEmployee.GetFocusedRowCellValue("City").ToString();
                txtAddress.Text = grwEmployee.GetFocusedRowCellValue("Address").ToString();
                txtDeleteFlag.Text = grwEmployee.GetFocusedRowCellValue("DeleteFlag").ToString();
            }
        }

        private void grcEmployee_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult confirmation = MessageBox.Show(@"Are you sure you want to save the information?", @"Information", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    _employeeService.Save(new Employee
                    {
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
                    LoadEmployee();
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
                    _employeeService.Update(new Employee()
                    {
                        Id = Convert.ToInt32(grwEmployee.GetRowCellValue(grwEmployee.FocusedRowHandle, "Id")),
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
                    LoadEmployee();
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
                _employeeService.Update(new Employee
                {
                    Id = Convert.ToInt32(grwEmployee.GetRowCellValue(grwEmployee.FocusedRowHandle, "Id")),
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
                LoadEmployee();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void btnDelete2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Remove();
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

        private void btnExcelTransfer2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _commonMethods.ExcelTransfer(grwEmployee);
        }

        private void grcEmployee_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwEmployee.Focus();
                popupMenu1.ShowPopup(position);
            }
        }
    }
}