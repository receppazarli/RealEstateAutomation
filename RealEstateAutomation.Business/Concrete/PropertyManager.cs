using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Concrete
{
    public class PropertyManager : IPropertyService
    {
        private IPropertyDal _propertyDal;

        public PropertyManager(IPropertyDal propertyDal)
        {
            _propertyDal = propertyDal;
        }

        public List<Property> GetAll()
        {
            try
            {
                return _propertyDal.GetAll(x => x.DeleteFlag == false);
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error loading the information. Please try again.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void Add(Property property)
        {
            try
            {
                _propertyDal.Add(property);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while registering the property", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public Property GetLastAddedProperty()
        {
            return _propertyDal.GetLastAddedEntity();

        }

        public void Update(Property property)
        {
            try
            {
                _propertyDal.Update(property);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while updating the property", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void Delete(Property property)
        {
            _propertyDal.Delete(property);
        }
    }
}