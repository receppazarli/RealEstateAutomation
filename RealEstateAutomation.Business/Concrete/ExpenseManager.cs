using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.Utilities;
using RealEstateAutomation.Business.ValidationRules.FluentValidation;
using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Concrete
{
    public class ExpenseManager : IExpenseService
    {
        private IExpensesDal _expensesDal;

        public ExpenseManager(IExpensesDal expensesDal)
        {
            _expensesDal = expensesDal;
        }

        public List<Expense> GetAll()
        {
            try
            {
                return _expensesDal.GetAll(x => x.DeleteFlag == false);
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error loading the information. Please try again.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void Add(Expense expense)
        {
            try
            {
                ValidationTool.Validate(new ExpenseValidator(), expense);
                _expensesDal.Add(expense);
            }

            catch (SqlException e)
            {
                switch (e.Number)
                {
                    case 2627: // Unique key 

                        MessageBox.Show("This record already exists please check your details", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    default:
                        MessageBox.Show("An unexpected database error occurred, please try again.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show(
                    ex.InnerException == null ? ex.Message : "This record already exists please check your details",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Update(Expense expense)
        {
            try
            {
                ValidationTool.Validate(new ExpenseValidator(), expense);
                _expensesDal.Update(expense);
            }
            catch (SqlException e)
            {
                switch (e.Number)
                {
                    case 2627: // Unique key 

                        MessageBox.Show("This record already exists please check your details", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    default:
                        MessageBox.Show("An unexpected database error occurred, please try again.", "Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
            }

            catch (Exception ex)

            {
                MessageBox.Show(
                    ex.InnerException == null ? ex.Message : "This record already exists please check your details",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}