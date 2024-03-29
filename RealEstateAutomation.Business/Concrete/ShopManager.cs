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
    public class ShopManager : IShopService
    {
        private readonly IShopDal _shopDal;

        public ShopManager(IShopDal shopDal)
        {
            _shopDal = shopDal;
        }

        public void Add(Shop shop)
        {
            ValidationTool.Validate(new ShopValidator(), shop);
            _shopDal.Add(shop);

            //try
            //{
            //    ValidationTool.Validate(new ShopValidator(), shop);
            //    _shopDal.Add(shop);
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

        public Shop GetLastAddedShop()
        {
            return _shopDal.GetLastAddedEntity();
        }

        public List<Shop> GetAll()
        {
            try
            {
                return _shopDal.GetAll(x => x.DeleteFlag == false);
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error loading the information. Please try again.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public void Update(Shop shop)
        {
            ValidationTool.Validate(new ShopValidator(), shop);
            _shopDal.Update(shop);

            //try
            //{
            //    ValidationTool.Validate(new ShopValidator(), shop);
            //    _shopDal.Update(shop);
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
    }
}