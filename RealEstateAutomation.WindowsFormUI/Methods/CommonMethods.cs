using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using System.Windows.Forms;
using System;

namespace RealEstateAutomation.WindowsFormUI.Methods
{
    public class CommonMethods
    {
        public void ExcelTransfer(GridView Gr)
        {
            DialogResult confirmation1 = MessageBox.Show(@"Are you sure you want to save to Excel?",
                @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (confirmation1 == DialogResult.Yes)
            {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Xlsx|*.xlsx";
                saveFileDialog.Title = "Select Excel Save Location.";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != null)
                {
                    try
                    {
                        Gr.ExportToXlsx(saveFileDialog.FileName);
                        DialogResult confirmation = MessageBox.Show(@"Would you like to open the file?",
                            @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (confirmation == DialogResult.Yes)
                        {
                            Process.Start(saveFileDialog.FileName);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"Your transaction has been canceled...", @"Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(@"Select Excel Save Location.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }
    }
}