using System;
using System.Windows.Forms;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.WindowsFormUI.Methods;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class ExpenseForm : DevExpress.XtraEditors.XtraForm
    {
        public ExpenseForm()
        {
            InitializeComponent();
            _expenseService = InstanceFactory.GetInstance<IExpenseService>();
        }

        private readonly IExpenseService _expenseService;
        private readonly CommonMethods _commonMethods = new CommonMethods();

        private void ExpenseForm_Load(object sender, EventArgs e)
        {
            LoadExpense();
        }

        private void LoadExpense()
        {
            grcExpense.DataSource = _expenseService.GetAll();
        }

        void Clear()
        {
            txtId.Text = "";
            txtExpensePrice.Text = "0";
            txtDescription.Text = "";
            dteExpenseDate.Clear();
        }

        void LoadClick()
        {
            if (grwExpense.FocusedRowHandle >= 0)
            {
                txtId.Text = grwExpense.GetFocusedRowCellValue("Id").ToString();
                txtExpensePrice.Text = grwExpense.GetFocusedRowCellValue("ExpensePrice").ToString();
                txtDescription.Text = grwExpense.GetFocusedRowCellValue("Description").ToString();
                dteExpenseDate.DateTime = Convert.ToDateTime(grwExpense.GetFocusedRowCellValue("ExpenseDate"));
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
                    _expenseService.Add(new Expense
                    {
                        ExpensePrice = Convert.ToDecimal(txtExpensePrice.Text),
                        ExpenseDate = string.IsNullOrWhiteSpace(dteExpenseDate.Text) ? (DateTime?)null : Convert.ToDateTime(dteExpenseDate.DateTime.Date),
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });

                    LoadExpense();
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
                    _expenseService.Update(new Expense
                    {
                        Id = Convert.ToInt32(grwExpense.GetRowCellValue(grwExpense.FocusedRowHandle, "Id")),
                        ExpensePrice = Convert.ToDecimal(txtExpensePrice.Text),
                        ExpenseDate = string.IsNullOrWhiteSpace(dteExpenseDate.Text) ? (DateTime?)null : Convert.ToDateTime(dteExpenseDate.DateTime.Date),
                        Description = txtDescription.Text,
                        DeleteFlag = false
                    });

                    LoadExpense();
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
                _expenseService.Update(new Expense
                {
                    Id = Convert.ToInt32(grwExpense.GetRowCellValue(grwExpense.FocusedRowHandle, "Id")),
                    ExpensePrice = Convert.ToDecimal(txtExpensePrice.Text),
                    ExpenseDate = string.IsNullOrWhiteSpace(dteExpenseDate.Text) ? (DateTime?)null : Convert.ToDateTime(dteExpenseDate.DateTime.Date),
                    Description = txtDescription.Text,
                    DeleteFlag = true
                });

                LoadExpense();
                Clear();
            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void grcExpense_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        private void grwExpense_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = MousePosition;
                grwExpense.Focus();
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

        private void btnSave2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnExcelTransfer2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _commonMethods.ExcelTransfer(grwExpense);
        }
    }
}