using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.Utilities;
using RealEstateAutomation.Business.ValidationRules.FluentValidation;
using RealEstateAutomation.DataAccess.Abstract;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace RealEstateAutomation.Business.Concrete
{
    public class HouseManager : IHouseService
    {
        private IHouseDal _houseDal;

        public HouseManager(IHouseDal houseDal)
        {
            _houseDal = houseDal;
        }

        public void Add(House house)
        {
            ValidationTool.Validate(new HouseValidator(), house);
            _houseDal.Add(house);

            //try
            //{
            //    ValidationTool.Validate(new HouseValidator(), house);
            //    _houseDal.Add(house);
            //}

            //catch (SqlException e)
            //{
            //    switch (e.Number)
            //    {
            //        case 2627: // Unique key 

            //            MessageBox.Show("This record already exists please check your details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            break;

            //        default:
            //            MessageBox.Show("An unexpected database error occurred, please try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            break;
            //    }
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(
            //        ex.InnerException == null ? ex.Message : "This record already exists please check your details",
            //        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        public void Update(House house)
        {
            ValidationTool.Validate(new HouseValidator(), house);
            _houseDal.Update(house);

            //try
            //{
            //    ValidationTool.Validate(new HouseValidator(), house);
            //    _houseDal.Update(house);
            //}

            //catch (SqlException e)
            //{
            //    switch (e.Number)
            //    {
            //        case 2627: // Unique key 

            //            MessageBox.Show("This record already exists please check your details", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            break;

            //        default:
            //            MessageBox.Show("An unexpected database error occurred, please try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            break;
            //    }
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show(
            //        ex.InnerException == null ? ex.Message : "This record already exists please check your details",
            //        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        public House GetLastAddedHouse()
        {
            return _houseDal.GetLastAddedEntity();
        }

        public List<House> GetAll()
        {
            try
            {
                return _houseDal.GetAll(x => x.DeleteFlag == false);
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