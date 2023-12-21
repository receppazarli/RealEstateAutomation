using System;
using System.Windows.Forms;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.Entities.Concrete;
using RealEstateAutomation.WindowsFormUI.Methods;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class IncomeForm : DevExpress.XtraEditors.XtraForm
    {
        public IncomeForm()
        {
            InitializeComponent();
            _incomeService = InstanceFactory.GetInstance<IIncomeService>();
        }

        private readonly IIncomeService _incomeService;
        private readonly CommonMethods _commonMethods = new CommonMethods();

        private void IncomeForm_Load(object sender, EventArgs e)
        {
            LoadIncome();
        }

        void LoadIncome()
        {
            grcIncome.DataSource = _incomeService.GetAll();
        }

        void Clear()
        {
            txtId.Text = "";
            txtIncomePrice.Text = "0";
            txtDescription.Text = "";
            dteIncomeDate.Clear();
        }

        void LoadClick()
        {
            if (grwIncome.FocusedRowHandle >= 0)
            {
                txtId.Text = grwIncome.GetFocusedRowCellValue("Id").ToString();
                txtIncomePrice.Text = grwIncome.GetFocusedRowCellValue("IncomePrice").ToString();
                txtDescription.Text = grwIncome.GetFocusedRowCellValue("Description").ToString();
                dteIncomeDate.DateTime = Convert.ToDateTime(grwIncome.GetFocusedRowCellValue("IncomeDate"));
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
                    _incomeService.Add(new Income
                    {
                        IncomePrice = Convert.ToDecimal(txtIncomePrice.Text),
                        IncomeDate = string.IsNullOrWhiteSpace(dteIncomeDate.Text) ? (DateTime?)null : Convert.ToDateTime(dteIncomeDate.DateTime.Date),
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });

                    LoadIncome();
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
                    _incomeService.Update(new Income
                    {
                        Id = Convert.ToInt32(grwIncome.GetRowCellValue(grwIncome.FocusedRowHandle, "Id")),
                        IncomePrice = Convert.ToDecimal(txtIncomePrice.Text),
                        IncomeDate = string.IsNullOrWhiteSpace(dteIncomeDate.Text) ? (DateTime?)null : Convert.ToDateTime(dteIncomeDate.DateTime.Date),
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });

                    LoadIncome();
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
            DialogResult confirmation = MessageBox.Show(@"Are you sure you want to update the information?",
                @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                _incomeService.Update(new Income
                {
                    Id = Convert.ToInt32(grwIncome.GetRowCellValue(grwIncome.FocusedRowHandle, "Id")),
                    IncomePrice = Convert.ToDecimal(txtIncomePrice.Text),
                    IncomeDate = string.IsNullOrWhiteSpace(dteIncomeDate.Text) ? (DateTime?)null : Convert.ToDateTime(dteIncomeDate.DateTime.Date),
                    Description = txtDescription.Text,
                    DeleteFlag = true
                });
                LoadIncome();
                Clear();
            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void grcIncome_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        private void grwIncome_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwIncome.Focus();
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

        private void btnDelete2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Remove();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnSave2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnExcelTransfer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _commonMethods.ExcelTransfer(grwIncome);
        }
    }
}