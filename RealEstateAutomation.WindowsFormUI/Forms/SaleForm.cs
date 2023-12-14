using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraLayout.Utils;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class SaleForm : DevExpress.XtraEditors.XtraForm
    {
        public SaleForm()
        {
            InitializeComponent();
            _customerService = InstanceFactory.GetInstance<ICustomerService>();
            _ownerService = InstanceFactory.GetInstance<IOwnerService>();
            _saleService = InstanceFactory.GetInstance<ISaleService>();
            _fieldService = InstanceFactory.GetInstance<IFieldService>();
            _houseService = InstanceFactory.GetInstance<IHouseService>();
            _plotService = InstanceFactory.GetInstance<IPlotService>();
            _shopService = InstanceFactory.GetInstance<IShopService>();
        }

        private readonly ICustomerService _customerService;
        private readonly IOwnerService _ownerService;
        private readonly ISaleService _saleService;
        private readonly IFieldService _fieldService;
        private readonly IHouseService _houseService;
        private readonly IPlotService _plotService;
        private readonly IShopService _shopService;

        private void SaleForm_Load(object sender, EventArgs e)
        {
            LoadCustomer();
           // LoadField();
            LoadPlot();
            LoadHouse();
            LoadShop();
        }

        void LoadCustomer()
        {
            lkuCustomerId.Properties.DataSource = _customerService.GetAll();
            lkuCustomerId.Properties.DisplayMember = "FirstName";
            lkuCustomerId.Properties.ValueMember = "Id";
        }

        void LoadField()
        {
            lkuField.Properties.DataSource = _fieldService.GetAll().Where(x => x.Sold == false);
            lkuField.Properties.DisplayMember = "OwnerId";
            lkuField.Properties.ValueMember = "Id";
        }

        void LoadPlot()
        {
            lkuPlot.Properties.DataSource = _plotService.GetAll().Where(x => x.Sold == false);
            lkuPlot.Properties.DisplayMember = "OwnerId";
            lkuPlot.Properties.ValueMember = "Id";
        }

        void LoadHouse()
        {
            lkuHouse.Properties.DataSource = _houseService.GetAll().Where(x => x.Sold == false);
            lkuHouse.Properties.DisplayMember = "OwnerId";
            lkuHouse.Properties.ValueMember = "Id";
        }

        void LoadShop()
        {
            lkuShop.Properties.DataSource = _shopService.GetAll().Where(x => x.Sold == false);
            lkuShop.Properties.DisplayMember = "OwnerId";
            lkuShop.Properties.ValueMember = "Id";

        }



        void LoadSale()
        {
            switch (cmbPropertyType.Text)
            {
                case "Field":
                    try
                    {
                        using (RealEstateAutomationContext context = new RealEstateAutomationContext())
                        {
                            var entity = from f in context.Fields
                                         join p in context.Properties on f.PropertyId equals p.Id
                                         join o in context.Owners on f.OwnerId equals o.Id
                                         join ci in context.Cities on f.City equals ci.Id
                                         join co in context.Counties on f.County equals co.Id
                                         select new
                                         {
                                             Id = f.Id,
                                             PropertyId = f.PropertyId,
                                             OwnerId = o.FirstName,
                                             // OwnerFieldId = f.OwnerId,
                                             Area = f.Area,
                                             Pafta = f.Pafta,
                                             City = ci.CityName,
                                             County = co.CountyName,
                                             Address = f.Address,
                                             Price = f.Price,
                                             Description = f.Description,
                                             Sold = f.Sold,
                                             DeleteFlag = f.DeleteFlag,
                                         };
                            //grcField.DataSource = entity.ToList().Where(x => x.DeleteFlag == false)
                            lkuField.Properties.DataSource = entity.ToList().Where(x => x.DeleteFlag == false && x.Sold == false);
                            lkuField.Properties.DisplayMember = "OwnerId";
                            lkuField.Properties.ValueMember = "Id";

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }

                    break;

                case "House":
                    try
                    {
                        using (RealEstateAutomationContext context = new RealEstateAutomationContext())
                        {
                            var entity = from h in context.Houses
                                         join p in context.Properties on h.PropertyId equals p.Id
                                         join o in context.Owners on h.OwnerId equals o.Id
                                         join ci in context.Cities on h.City equals ci.Id
                                         join co in context.Counties on h.County equals co.Id
                                         select new
                                         {
                                             Id = h.Id,
                                             PropertyId = h.PropertyId,
                                             OwnerId = h.OwnerId,
                                             //OwnerHouseId = h.OwnerId,
                                             OwnerHouse = o.FirstName,
                                             Area = h.Area,
                                             HouseType = h.HouseType,
                                             City = ci.CityName,
                                             County = co.CountyName,
                                             Address = h.Address,
                                             Price = h.Price,
                                             Description = h.Description,
                                             Sold = h.Sold,
                                             DeleteFlag = h.DeleteFlag,
                                         };
                            // grcHouse.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }

                    break;

                case "Plot":
                    try
                    {
                        using (RealEstateAutomationContext context = new RealEstateAutomationContext())
                        {
                            var entity = from pl in context.Plots
                                         join p in context.Properties on pl.PropertyId equals p.Id
                                         join o in context.Owners on pl.OwnerId equals o.Id
                                         join ci in context.Cities on pl.City equals ci.Id
                                         join co in context.Counties on pl.County equals co.Id
                                         select new
                                         {
                                             Id = pl.Id,
                                             PropertyId = pl.PropertyId,
                                             OwnerId = pl.OwnerId,
                                             //OwnerPlotId = pl.OwnerId,
                                             OwnerPlot = o.FirstName,
                                             Area = pl.Area,
                                             Ada = pl.Ada,
                                             Pafta = pl.Pafta,
                                             City = ci.CityName,
                                             County = co.CountyName,
                                             Address = pl.Address,
                                             Price = pl.Price,
                                             Description = pl.Description,
                                             Sold = pl.Sold,
                                             DeleteFlag = pl.DeleteFlag,
                                         };
                            // grcPlot.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "Shop":
                    try
                    {
                        using (RealEstateAutomationContext context = new RealEstateAutomationContext())
                        {
                            var entity = from s in context.Shops
                                         join p in context.Properties on s.PropertyId equals p.Id
                                         join o in context.Owners on s.OwnerId equals o.Id
                                         join ci in context.Cities on s.City equals ci.Id
                                         join co in context.Counties on s.County equals co.Id
                                         select new
                                         {
                                             Id = s.Id,
                                             PropertyId = s.PropertyId,
                                             OwnerId = s.OwnerId,
                                             // OwnerShopId = s.OwnerId,
                                             OwnerShop = o.FirstName,
                                             Area = s.Area,
                                             City = ci.CityName,
                                             County = co.CountyName,
                                             Address = s.Address,
                                             Price = s.Price,
                                             Description = s.Description,
                                             Sold = s.Sold,
                                             DeleteFlag = s.DeleteFlag,
                                         };
                            // grcShop.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }

                    break;
            }
        }


        void LoadClick()
        {
            switch (cmbPropertyType.Text)
            {
                case "Field":

                    break;
                case "House":


                    break;
                case "Plot":


                    break;
                case "Shop":


                    break;
            }
        }

        private void cmbPropertyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadSale();
        }


        void Clean()
        {
            txtId.Text = "";
            // txtPropertyId.Text = "";
            // cmbPropertyType.Text = "";
            //txtOwnerName.Text = "";
            txtSaleDate.Text = "";
            txtSalePrice.Text = "";
            lkuCustomerId.Text = "";
        }


        void Sale()
        {
            if (txtId.Text == "")
            {
                DialogResult confirmation = MessageBox.Show(@"Are you sure you want to save the information?", @"Information", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    _saleService.Add(new Sale
                    {
                        //OwnerId = Convert.ToInt32(txtOwnerId.Text),
                        CustomerId = Convert.ToInt32(lkuCustomerId.Text),
                        // SalePropertyId = Convert.ToInt32(txtPropertyId.Text),
                        SaleDate = DateTime.Now,
                        SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                        DeleteFlag = false
                    });
                    switch (cmbPropertyType.Text)
                    {
                        case "Field":
                            //_fieldService.Update(new Field
                            //{
                            //    Id = Convert.ToInt32(grwField.GetRowCellValue(grwField.FocusedRowHandle, "Id")),
                            //    PropertyId = Convert.ToInt32(grwField.GetRowCellValue(grwField.FocusedRowHandle, "PropertyId")),
                            //    OwnerId = Convert.ToInt32(lkuCustomerId.EditValue),
                            //    Area = Convert.ToDecimal(grwField.GetRowCellValue(grwField.FocusedRowHandle, "Area")),
                            //    Pafta = grwField.GetRowCellValue(grwField.FocusedRowHandle, "Pafta").ToString(),
                            //    City = Convert.ToInt32(grwField.GetRowCellValue(grwField.FocusedRowHandle, "City")),
                            //    County = Convert.ToInt32(grwField.GetRowCellValue(grwField.FocusedRowHandle, "County")),
                            //    Address = grwField.GetRowCellValue(grwField.FocusedRowHandle, "Address").ToString(),
                            //    Price = Convert.ToDecimal(grwField.GetRowCellValue(grwField.FocusedRowHandle, "Price")),
                            //    Description = grwField.GetRowCellValue(grwField.FocusedRowHandle, "Description").ToString(),
                            //    Sold = true,
                            //    DeleteFlag = false
                            //});
                            break;
                        case "House":
                            //_houseService.Update(new House
                            //{
                            //    Id = Convert.ToInt32(grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "Id")),
                            //    PropertyId = Convert.ToInt32(grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "PropertyId")),
                            //    OwnerId = Convert.ToInt32(lkuCustomerId.EditValue),
                            //    Area = Convert.ToDecimal(grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "Area")),
                            //    HouseType = grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "HouseType").ToString(),
                            //    City = Convert.ToInt32(grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "City")),
                            //    County = Convert.ToInt32(grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "County")),
                            //    Address = grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "Address").ToString(),
                            //    Price = Convert.ToDecimal(grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "Price")),
                            //    Description = grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "Description").ToString(),
                            //    Sold = true,
                            //    DeleteFlag = false
                            //});

                            break;
                        case "Plot":
                            //_plotService.Update(new Plot
                            //{
                            //    Id = Convert.ToInt32(grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "Id")),
                            //    PropertyId = Convert.ToInt32(grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "PropertyId")),
                            //    OwnerId = Convert.ToInt32(lkuCustomerId.EditValue),
                            //    Area = Convert.ToDecimal(grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "Area")),
                            //    Ada = grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "Ada").ToString(),
                            //    Pafta = grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "Pafta").ToString(),
                            //    City = Convert.ToInt32(grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "City")),
                            //    County = Convert.ToInt32(grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "County")),
                            //    Address = grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "Address").ToString(),
                            //    Price = Convert.ToDecimal(grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "Price")),
                            //    Description = grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "Description").ToString(),
                            //    Sold = true,
                            //    DeleteFlag = false
                            //});

                            break;
                        case "Shop":
                            //_shopService.Update(new Shop
                            //{
                            //    Id = Convert.ToInt32(grwShop.GetRowCellValue(grwShop.FocusedRowHandle, "Id")),
                            //    PropertyId = Convert.ToInt32(grwShop.GetRowCellValue(grwShop.FocusedRowHandle, "PropertyId")),
                            //    OwnerId = Convert.ToInt32(lkuCustomerId.EditValue),
                            //    Area = Convert.ToDecimal(grwShop.GetRowCellValue(grwShop.FocusedRowHandle, "Area")),
                            //    City = Convert.ToInt32(grwShop.GetRowCellValue(grwShop.FocusedRowHandle, "City")),
                            //    County = Convert.ToInt32(grwShop.GetRowCellValue(grwShop.FocusedRowHandle, "County")),
                            //    Address = grwShop.GetRowCellValue(grwShop.FocusedRowHandle, "Address").ToString(),
                            //    Price = Convert.ToDecimal(grwShop.GetRowCellValue(grwShop.FocusedRowHandle, "Price")),
                            //    Description = grwShop.GetRowCellValue(grwShop.FocusedRowHandle, "Description").ToString(),
                            //    Sold = true,
                            //    DeleteFlag = false
                            //});

                            break;
                    }
                }
                else
                {
                    MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else if (txtId.Text != "")
            {

            }
        }
    }
}