using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            return _customerDal.GetAll();
        }

        public void Add(Customer customer)
        {
            try
            {
                _customerDal.Add(customer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Update(Customer customer)
        {
            try
            {
                _customerDal.Update(customer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
