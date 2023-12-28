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

namespace RealEstateAutomation.Business.Concrete
{
    public class PlotManager : IPlotService
    {
        private IPlotDal _plotDal;

        public PlotManager(IPlotDal plotDal)
        {
            _plotDal = plotDal;
        }

        public void Add(Plot plot)
        {
            ValidationTool.Validate(new PlotValidator(), plot);
            _plotDal.Add(plot);

            //try
            //{
            //    ValidationTool.Validate(new PlotValidator(), plot);
            //    _plotDal.Add(plot);
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

        public void Update(Plot plot)
        {
            ValidationTool.Validate(new PlotValidator(), plot);
            _plotDal.Update(plot);

            //try
            //{
            //    ValidationTool.Validate(new PlotValidator(), plot);
            //    _plotDal.Update(plot);
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

        public Plot GetLastAddedHouse()
        {
            return _plotDal.GetLastAddedEntity();
        }

        public List<Plot> GetAll()
        {
            try
            {
                return _plotDal.GetAll(x => x.DeleteFlag == false);
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