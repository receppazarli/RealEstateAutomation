using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RealEstateAutomation.Business.Utilities;
using RealEstateAutomation.Business.ValidationRules.FluentValidation;
using System.Data.SqlClient;

namespace RealEstateAutomation.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public List<Customer> GetAll()
        {
            try
            {
                return _customerDal.GetAll(x => x.DeleteFlag == false);
            }
            catch (Exception e)
            {
                MessageBox.Show("There was an error loading the information. Please try again.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        public void Add(Customer customer)
        {
            
            try
            {
                ValidationTool.Validate(new CustomerValidator(), customer);
                _customerDal.Add(customer);
            }

            catch (SqlException e)
            {
                switch (e.Number)
                {
                    case 2627: // Unique key 
                             
                        MessageBox.Show("This record already exists please check your details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    
                    default:
                        MessageBox.Show("An unexpected database error occurred, please try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void Update(Customer customer)
        {
            try
            {
                ValidationTool.Validate(new CustomerValidator(), customer);
                _customerDal.Update(customer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
