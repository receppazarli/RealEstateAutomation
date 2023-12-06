using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.Utilities;
using RealEstateAutomation.Business.ValidationRules.FluentValidation;
using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Concrete
{
    public class FieldManager : IFieldService
    {
        private readonly IFieldDal _fieldDal;

        public FieldManager(IFieldDal fieldDal)
        {
            _fieldDal = fieldDal;
        }


        public List<Field> GetAll()
        {
            try
            {
                return _fieldDal.GetAll(x => x.DeleteFlag == false);
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error loading the information. Please try again.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void Add(Field field)
        {
            try
            {
                ValidationTool.Validate(new FieldValidator(), field);
                _fieldDal.Add(field);
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

        public void Update(Field field)
        {
            try
            {
                ValidationTool.Validate(new FieldValidator(), field);
                _fieldDal.Update(field);
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

        public List<Field> GetById(int id)
        {
            try
            {
                return _fieldDal.GetAll(x => x.Id == id);
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error loading the information. Please try again.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}