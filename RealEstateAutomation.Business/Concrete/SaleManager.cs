﻿using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.Utilities;
using RealEstateAutomation.Business.ValidationRules.FluentValidation;
using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using FluentValidation;

namespace RealEstateAutomation.Business.Concrete
{
    public class SaleManager : ISaleService
    {
        private ISaleDal _saleDal;

        public SaleManager(ISaleDal saleDal)
        {
            _saleDal = saleDal;
        }

        public void Add(Sale sale)
        {
            try
            {
                ValidationTool.Validate(new SaleValidator(), sale);
                _saleDal.Add(sale);
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

        public List<Sale> GetAll()
        {
            try
            {
                return _saleDal.GetAll(x => x.DeleteFlag == false);
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error loading the information. Please try again.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void Update(Sale sale)
        {

            try
            {
                ValidationTool.Validate(new SaleValidator(), sale);
                _saleDal.Update(sale);
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
    }
}