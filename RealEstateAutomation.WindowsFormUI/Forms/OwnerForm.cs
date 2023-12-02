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
    public partial class OwnerForm : DevExpress.XtraEditors.XtraForm
    {
        public OwnerForm()
        {
            InitializeComponent();
            _ownerService = InstanceFactory.GetInstance<IOwnerService>();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _countyService = InstanceFactory.GetInstance<ICountyService>();
        }

        private IOwnerService _ownerService;
        private ICityService _cityService;
        private ICountyService _countyService;
        private CommonMethods _commonMethods = new CommonMethods();

        private void OwnerForm_Load(object sender, EventArgs e)
        {
            LoadOwner();
        }

        void LoadOwner()
        {
            grcOwner.DataSource = _ownerService.GetAll();
        }

        void Clear()
        {
            txtId.Text = "";
            txtNationalityId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtDeleteFlag.Text = "";
            btnPhone.Text = "";
        }

        void LoadClick()
        {
            if (grwOwner.FocusedRowHandle >= 0)
            {
                txtId.Text = grwOwner.GetFocusedRowCellValue("Id").ToString();
                txtNationalityId.Text = grwOwner.GetFocusedRowCellValue("NationalityId").ToString();
                txtFirstName.Text = grwOwner.GetFocusedRowCellValue("FirstName").ToString();
                txtLastName.Text = grwOwner.GetFocusedRowCellValue("LastName").ToString();
                btnPhone.Text = grwOwner.GetFocusedRowCellValue("Phone").ToString();
                txtDeleteFlag.Text = grwOwner.GetFocusedRowCellValue("DeleteFlag").ToString();
            }
        }

        void Save()
        {
            if (txtId.Text == "")
            {
                DialogResult confirmation = MessageBox.Show(@"Are you sure you want to save the information?", @"Information", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    _ownerService.Save(new Owner
                    {
                        NationalityId = txtNationalityId.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Phone = btnPhone.Text,
                        DeleteFlag = false
                    });
                    LoadOwner();
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
                    _ownerService.Update(new Owner
                    {
                        Id = Convert.ToInt32(grwOwner.GetRowCellValue(grwOwner.FocusedRowHandle, "Id")),
                        NationalityId = txtNationalityId.Text,
                        FirstName = txtFirstName.Text,
                        LastName = txtLastName.Text,
                        Phone = btnPhone.Text,
                        DeleteFlag = false
                    });
                    LoadOwner();
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
                _ownerService.Update(new Owner
                {
                    Id = Convert.ToInt32(grwOwner.GetRowCellValue(grwOwner.FocusedRowHandle, "Id")),
                    NationalityId = txtNationalityId.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Phone = btnPhone.Text,
                    DeleteFlag = true
                });
                LoadOwner();
                Clear();
            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void grcOwner_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        private void grcOwner_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwOwner.Focus();
                popupMenu1.ShowPopup(position);
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

        private void btnDelete2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Remove();
        }

        private void btnSave2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnExcelTransfer2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _commonMethods.ExcelTransfer(grwOwner);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
    }
}