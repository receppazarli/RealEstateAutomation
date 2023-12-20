using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraLayout.Utils;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;
using RealEstateAutomation.WindowsFormUI.Methods;

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
        private readonly CommonMethods _commonMethods = new CommonMethods();

        private void SaleForm_Load(object sender, EventArgs e)
        {
            //LoadSale();
            LoadCustomer();
            LoadField();
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


        void LoadPlot()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity2 = from pl in context.Plots
                              join p in context.Properties on pl.PropertyId equals p.Id
                              join o in context.Owners on pl.OwnerId equals o.Id
                              join ci in context.Cities on pl.City equals ci.Id
                              join co in context.Counties on pl.County equals co.Id
                              select new
                              {
                                  Id = pl.Id,
                                  PropertyId = pl.PropertyId,
                                  OwnerId = o.FirstName,
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

                lkuPlot.Properties.DataSource = entity2.ToList().Where(x => x.DeleteFlag == false && x.Sold == false);
                lkuPlot.Properties.DisplayMember = "OwnerId";
                lkuPlot.Properties.ValueMember = "PropertyId";
            }
        }

        void LoadHouse()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity2 = from h in context.Houses
                              join p in context.Properties on h.PropertyId equals p.Id
                              join o in context.Owners on h.OwnerId equals o.Id
                              join ci in context.Cities on h.City equals ci.Id
                              join co in context.Counties on h.County equals co.Id
                              select new
                              {
                                  Id = h.Id,
                                  PropertyId = h.PropertyId,
                                  OwnerId = o.FirstName,
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

                lkuHouse.Properties.DataSource = entity2.ToList().Where(x => x.DeleteFlag == false && x.Sold == false);
                lkuHouse.Properties.DisplayMember = "OwnerId";
                lkuHouse.Properties.ValueMember = "PropertyId";
            }
        }

        void LoadShop()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity2 = from s in context.Shops
                              join p in context.Properties on s.PropertyId equals p.Id
                              join o in context.Owners on s.OwnerId equals o.Id
                              join ci in context.Cities on s.City equals ci.Id
                              join co in context.Counties on s.County equals co.Id
                              select new
                              {
                                  Id = s.Id,
                                  PropertyId = s.PropertyId,
                                  OwnerId = o.FirstName,
                                  Area = s.Area,
                                  City = ci.CityName,
                                  County = co.CountyName,
                                  Address = s.Address,
                                  Price = s.Price,
                                  Description = s.Description,
                                  Sold = s.Sold,
                                  DeleteFlag = s.DeleteFlag,
                              };

                lkuShop.Properties.DataSource = entity2.ToList().Where(x => x.DeleteFlag == false && x.Sold == false);
                lkuShop.Properties.DisplayMember = "OwnerId";
                lkuShop.Properties.ValueMember = "PropertyId";
            }

        }

        void LoadField()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity2 = from f in context.Fields
                              join p in context.Properties on f.PropertyId equals p.Id
                              join o in context.Owners on f.OwnerId equals o.Id
                              join ci in context.Cities on f.City equals ci.Id
                              join co in context.Counties on f.County equals co.Id
                              select new
                              {
                                  Id = f.Id,
                                  PropertyId = f.PropertyId,
                                  OwnerId = f.OwnerId,
                                  OwnerName = o.FirstName,
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

                lkuField.Properties.DataSource = entity2.ToList().Where(x => x.DeleteFlag == false && x.Sold == false);
                lkuField.Properties.DisplayMember = "OwnerName";
                lkuField.Properties.ValueMember = "PropertyId";
            }
        }



        void LoadSale()
        {
            switch (cmbPropertyType.Text)
            {
                case "Field":
                    try
                    {
                        LoadSaleField();
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
                        LoadSaleHouse();
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
                        LoadSalePlot();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    break;

                case "Shop":
                    try
                    {
                        LoadSaleShop();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }

                    break;
            }
        }

        private void LoadSaleShop()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity = from s in context.Sales
                             join p in context.Properties on s.SalePropertyId equals p.Id
                             join sh in context.Shops on p.ReferenceId equals sh.Id
                             join o in context.Owners on s.OwnerId equals o.Id
                             join ci in context.Cities on sh.City equals ci.Id
                             join co in context.Counties on sh.County equals co.Id
                             join c in context.Customers on s.CustomerId equals c.Id
                             where p.PropertyType == "Shop"
                             select new
                             {
                                 Id = s.Id,
                                 SalePropertyId = s.SalePropertyId,
                                 SalePropertyType = s.SalePropertyType,
                                 OwnerId = o.FirstName,
                                 CustomerId = c.FirstName,
                                 Area = sh.Area,
                                 City = ci.CityName,
                                 County = co.CountyName,
                                 Address = sh.Address,
                                 SalePrice = s.SalePrice,
                                 SaleDate = s.SaleDate,
                                 Price = sh.Price,
                                 Description = sh.Description,
                                 Sold = sh.Sold,
                                 DeleteFlag = sh.DeleteFlag,
                                 SaleDeleteFlag = s.DeleteFlag,

                             };


                grcSale.DataSource = entity.ToList().Where(x => x.SaleDeleteFlag == false);

                grwSale.Columns["Ada"].Visible = false;
                grwSale.Columns["HouseType"].Visible = false;
                grwSale.Columns["Pafta"].Visible = false;

                lycField.Visibility = LayoutVisibility.Never;
                lycShop.Visibility = LayoutVisibility.Always;
                lycHouse.Visibility = LayoutVisibility.Never;
                lycPlot.Visibility = LayoutVisibility.Never;
            }
        }

        private void LoadSalePlot()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity = from s in context.Sales
                             join p in context.Properties on s.SalePropertyId equals p.Id
                             join pl in context.Plots on p.ReferenceId equals pl.Id
                             join o in context.Owners on s.OwnerId equals o.Id
                             join ci in context.Cities on pl.City equals ci.Id
                             join co in context.Counties on pl.County equals co.Id
                             join c in context.Customers on s.CustomerId equals c.Id
                             where p.PropertyType == "Plot"
                             select new
                             {
                                 Id = s.Id,
                                 SalePropertyId = s.SalePropertyId,
                                 SalePropertyType = s.SalePropertyType,
                                 OwnerId = o.FirstName,
                                 CustomerId = c.FirstName,
                                 Area = pl.Area,
                                 Ada = pl.Ada,
                                 Pafta = pl.Pafta,
                                 City = ci.CityName,
                                 County = co.CountyName,
                                 Address = pl.Address,
                                 SalePrice = s.SalePrice,
                                 SaleDate = s.SaleDate,
                                 Price = pl.Price,
                                 DeleteFlag = pl.DeleteFlag,
                                 Description = pl.Description,
                                 Sold = pl.Sold,
                                 SaleDeleteFlag = s.DeleteFlag,
                             };


                grcSale.DataSource = entity.ToList().Where(x => x.SaleDeleteFlag == false);

                grwSale.Columns["Ada"].Visible = true;
                grwSale.Columns["HouseType"].Visible = false;
                grwSale.Columns["Pafta"].Visible = true;

                lycPlot.Visibility = LayoutVisibility.Always;
                lycField.Visibility = LayoutVisibility.Never;
                lycShop.Visibility = LayoutVisibility.Never;
                lycHouse.Visibility = LayoutVisibility.Never;
            }
        }

        private void LoadSaleHouse()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity = from s in context.Sales
                             join p in context.Properties on s.SalePropertyId equals p.Id
                             join h in context.Houses on p.ReferenceId equals h.Id
                             join o in context.Owners on s.OwnerId equals o.Id
                             join ci in context.Cities on h.City equals ci.Id
                             join co in context.Counties on h.County equals co.Id
                             join c in context.Customers on s.CustomerId equals c.Id
                             where p.PropertyType == "House"
                             select new
                             {
                                 Id = s.Id,
                                 SalePropertyId = s.SalePropertyId,
                                 SalePropertyType = s.SalePropertyType,
                                 OwnerId = o.FirstName,
                                 CustomerId = c.FirstName,
                                 Area = h.Area,
                                 HouseType = h.HouseType,
                                 City = ci.CityName,
                                 County = co.CountyName,
                                 Address = h.Address,
                                 SalePrice = s.SalePrice,
                                 SaleDate = s.SaleDate,
                                 Price = h.Price,
                                 DeleteFlag = h.DeleteFlag,
                                 Description = h.Description,
                                 Sold = h.Sold,
                                 SaleDeleteFlag = s.DeleteFlag,
                             };

                grcSale.DataSource = entity.ToList().Where(x => x.SaleDeleteFlag == false);

                grwSale.Columns["Ada"].Visible = false;
                grwSale.Columns["HouseType"].Visible = true;
                grwSale.Columns["Pafta"].Visible = false;

                lycHouse.Visibility = LayoutVisibility.Always;
                lycField.Visibility = LayoutVisibility.Never;
                lycShop.Visibility = LayoutVisibility.Never;
                lycPlot.Visibility = LayoutVisibility.Never;
            }
        }

        private void LoadSaleField()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity = from s in context.Sales
                             join p in context.Properties on s.SalePropertyId equals p.Id
                             join f in context.Fields on p.ReferenceId equals f.Id
                             join o in context.Owners on s.OwnerId equals o.Id
                             join ci in context.Cities on f.City equals ci.Id
                             join co in context.Counties on f.County equals co.Id
                             join c in context.Customers on s.CustomerId equals c.Id
                             where p.PropertyType == "Field"
                             select new
                             {
                                 Id = s.Id,


                                 SalePropertyId = s.SalePropertyId,
                                 SalePropertyType = s.SalePropertyType,
                                 OwnerId = o.FirstName,
                                 CustomerId = c.FirstName,
                                 Area = f.Area,
                                 Pafta = f.Pafta,
                                 City = ci.CityName,
                                 County = co.CountyName,
                                 Address = f.Address,
                                 SalePrice = s.SalePrice,
                                 SaleDate = s.SaleDate,
                                 Price = f.Price,
                                 DeleteFlag = f.DeleteFlag,
                                 Description = f.Description,
                                 Sold = f.Sold,
                                 SaleDeleteFlag = s.DeleteFlag,
                             };


                grcSale.DataSource = entity.ToList().Where(x => x.SaleDeleteFlag == false);

                grwSale.Columns["Ada"].Visible = false;
                grwSale.Columns["HouseType"].Visible = false;
                grwSale.Columns["Pafta"].Visible = true;

                lycField.Visibility = LayoutVisibility.Always;
                lycShop.Visibility = LayoutVisibility.Never;
                lycHouse.Visibility = LayoutVisibility.Never;
                lycPlot.Visibility = LayoutVisibility.Never;
            }
        }


        void LoadClick()
        {
            switch (cmbPropertyType.Text)
            {
                case "Field":

                    LoadLookUpFieldClick();

                    if (grwSale.FocusedRowHandle >= 0)
                    {
                        txtId.Text = grwSale.GetFocusedRowCellValue("Id").ToString();
                        lkuField.Text = grwSale.GetFocusedRowCellValue("OwnerId").ToString();
                        lkuCustomerId.Text = grwSale.GetFocusedRowCellValue("CustomerId").ToString();
                        txtSalePrice.Text = grwSale.GetFocusedRowCellValue("SalePrice").ToString();
                        txtSaleDate.Text = grwSale.GetFocusedRowCellValue("SaleDate").ToString();
                    }

                    break;

                case "House":

                    LoadLookUpHouseClick();

                    if (grwSale.FocusedRowHandle >= 0)
                    {
                        txtId.Text = grwSale.GetFocusedRowCellValue("Id").ToString();
                        lkuHouse.Text = grwSale.GetFocusedRowCellValue("OwnerId").ToString();
                        lkuCustomerId.Text = grwSale.GetFocusedRowCellValue("CustomerId").ToString();
                        txtSalePrice.Text = grwSale.GetFocusedRowCellValue("SalePrice").ToString();
                        txtSaleDate.Text = grwSale.GetFocusedRowCellValue("SaleDate").ToString();
                    }

                    break;
                case "Plot":

                    LoadLookUpPlotClick();

                    if (grwSale.FocusedRowHandle >= 0)
                    {
                        txtId.Text = grwSale.GetFocusedRowCellValue("Id").ToString();
                        lkuPlot.Text = grwSale.GetFocusedRowCellValue("OwnerId").ToString();
                        lkuCustomerId.Text = grwSale.GetFocusedRowCellValue("CustomerId").ToString();
                        txtSalePrice.Text = grwSale.GetFocusedRowCellValue("SalePrice").ToString();
                        txtSaleDate.Text = grwSale.GetFocusedRowCellValue("SaleDate").ToString();
                    }

                    break;
                case "Shop":

                    LoadLookUpShopClick();

                    if (grwSale.FocusedRowHandle >= 0)
                    {
                        txtId.Text = grwSale.GetFocusedRowCellValue("Id").ToString();
                        lkuShop.Text = grwSale.GetFocusedRowCellValue("OwnerId").ToString();
                        lkuCustomerId.Text = grwSale.GetFocusedRowCellValue("CustomerId").ToString();
                        txtSalePrice.Text = grwSale.GetFocusedRowCellValue("SalePrice").ToString();
                        txtSaleDate.Text = grwSale.GetFocusedRowCellValue("SaleDate").ToString();
                    }

                    break;

            }
        }

        private void LoadLookUpShopClick()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity2 = from s in context.Shops
                              join p in context.Properties on s.PropertyId equals p.Id
                              join o in context.Owners on s.OwnerId equals o.Id
                              join ci in context.Cities on s.City equals ci.Id
                              join co in context.Counties on s.County equals co.Id
                              select new
                              {
                                  Id = s.Id,
                                  PropertyId = s.PropertyId,
                                  OwnerId = o.FirstName,
                                  Area = s.Area,
                                  City = ci.CityName,
                                  County = co.CountyName,
                                  Address = s.Address,
                                  Price = s.Price,
                                  Description = s.Description,
                                  Sold = s.Sold,
                                  DeleteFlag = s.DeleteFlag,
                              };

                lkuShop.Properties.DataSource = entity2.ToList().Where(x => x.DeleteFlag == false);
                lkuShop.Properties.DisplayMember = "OwnerId";
                lkuShop.Properties.ValueMember = "PropertyId";
            }
        }

        private void LoadLookUpPlotClick()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity2 = from pl in context.Plots
                              join p in context.Properties on pl.PropertyId equals p.Id
                              join o in context.Owners on pl.OwnerId equals o.Id
                              join ci in context.Cities on pl.City equals ci.Id
                              join co in context.Counties on pl.County equals co.Id
                              select new
                              {
                                  Id = pl.Id,
                                  PropertyId = pl.PropertyId,
                                  OwnerId = o.FirstName,
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

                lkuPlot.Properties.DataSource = entity2.ToList().Where(x => x.DeleteFlag == false);
                lkuPlot.Properties.DisplayMember = "OwnerId";
                lkuPlot.Properties.ValueMember = "PropertyId";
            }
        }

        private void LoadLookUpHouseClick()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity2 = from h in context.Houses
                              join p in context.Properties on h.PropertyId equals p.Id
                              join o in context.Owners on h.OwnerId equals o.Id
                              join ci in context.Cities on h.City equals ci.Id
                              join co in context.Counties on h.County equals co.Id
                              select new
                              {
                                  Id = h.Id,
                                  PropertyId = h.PropertyId,
                                  OwnerId = o.FirstName,
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

                lkuHouse.Properties.DataSource = entity2.ToList().Where(x => x.DeleteFlag == false);
                lkuHouse.Properties.DisplayMember = "OwnerId";
                lkuHouse.Properties.ValueMember = "PropertyId";
            }
        }

        private void LoadLookUpFieldClick()
        {
            using (RealEstateAutomationContext context = new RealEstateAutomationContext())
            {
                var entity2 = from f in context.Fields
                              join p in context.Properties on f.PropertyId equals p.Id
                              join o in context.Owners on f.OwnerId equals o.Id
                              join ci in context.Cities on f.City equals ci.Id
                              join co in context.Counties on f.County equals co.Id
                              select new
                              {
                                  Id = f.Id,
                                  PropertyId = f.PropertyId,
                                  OwnerId = f.OwnerId,
                                  OwnerName = o.FirstName,
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

                lkuField.Properties.DataSource = entity2.ToList().Where(x => x.DeleteFlag == false);
                lkuField.Properties.DisplayMember = "OwnerName";
                lkuField.Properties.ValueMember = "PropertyId";
            }
        }

        private void cmbPropertyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSale();
        }


        void Clean()
        {
            txtId.Text = "";
            lkuCustomerId.EditValue = 0;
            lkuField.EditValue = null;
            lkuHouse.EditValue = null;
            lkuPlot.EditValue = null;
            lkuShop.EditValue = null;
            txtSaleDate.Text = "";
            txtSalePrice.Text = "0";

        }


        void Sale()
        {
            if (txtId.Text == "")
            {

                DialogResult confirmation = MessageBox.Show(@"Are you sure you want to save the information?", @"Information", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    int selectedFieldPropertyId = 0;
                    int selectedHousePropertyId = 0;
                    int selectedPlotPropertyId = 0;
                    int selectedShopPropertyId = 0;
                    int selectedId = 0;
                    int selectedOwnerId = 0;
                    decimal selectedArea = 0;
                    string selectedAda = "";
                    string selectedPafta = "";
                    string selectedHouseType = "";
                    int selectedCity = 0;
                    int selectedCounty = 0;
                    string selectedAddress = "";
                    decimal selectedPrice = 0;
                    string selectedDescription = "";
                    bool selectedSold = false;
                    bool selectedDeleteFlag = false;

                    switch (cmbPropertyType.Text)
                    {
                        case "Field":

                            if (lkuField.EditValue == null)
                            {
                                MessageBox.Show(@"Field cannot be empty, please select a field.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                            else
                            {
                                selectedFieldPropertyId = (int)lkuField.EditValue;
                            }

                            var selectedField = _fieldService.GetAll()
                                .FirstOrDefault(f => f.PropertyId == selectedFieldPropertyId);

                            if (selectedField != null)
                            {
                                selectedId = selectedField.Id; // Seçilen Field'ın Id'sini al
                                selectedOwnerId = selectedField.OwnerId; // Seçilen Field'ın OwnerId'sini al
                                selectedArea = selectedField.Area;
                                selectedPafta = selectedField.Pafta;
                                selectedCity = selectedField.City;
                                selectedCounty = selectedField.County;
                                selectedAddress = selectedField.Address;
                                selectedPrice = selectedField.Price;
                                selectedDescription = selectedField.Description;
                                selectedSold = selectedField.Sold;
                                selectedDeleteFlag = selectedField.DeleteFlag;
                            }

                            if (selectedOwnerId != 0 && selectedId != 0)
                            {
                                _saleService.Add(new Sale
                                {
                                    OwnerId = selectedOwnerId,
                                    SalePropertyId = selectedFieldPropertyId,
                                    SalePropertyType = "Field",
                                    CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                    SaleDate = DateTime.Now,
                                    SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                    DeleteFlag = false
                                });

                                _fieldService.Update(new Field
                                {
                                    Id = selectedId,
                                    PropertyId = selectedFieldPropertyId,
                                    OwnerId = selectedOwnerId,
                                    Area = selectedArea,
                                    Pafta = selectedPafta,
                                    City = selectedCity,
                                    County = selectedCounty,
                                    Address = selectedAddress,
                                    Price = selectedPrice,
                                    Description = selectedDescription,
                                    Sold = true,
                                    DeleteFlag = selectedDeleteFlag
                                });
                            }

                            LoadSaleField();

                            break;

                        case "House":

                            if (lkuHouse.EditValue == null)
                            {
                                MessageBox.Show(@"House  cannot be empty, please select a house.", @"Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                break;
                            }
                            else
                            {
                                selectedHousePropertyId = (int)lkuHouse.EditValue;
                            }


                            //selectedHousePropertyId = (int)lkuHouse.EditValue;
                            var selectedHouse = _houseService.GetAll()
                                .FirstOrDefault(f => f.PropertyId == selectedHousePropertyId);

                            if (selectedHouse != null)
                            {
                                selectedId = selectedHouse.Id; // Seçilen Field'ın Id'sini al
                                selectedOwnerId = selectedHouse.OwnerId; // Seçilen Field'ın OwnerId'sini al
                                selectedArea = selectedHouse.Area;
                                selectedHouseType = selectedHouse.HouseType;
                                selectedCity = selectedHouse.City;
                                selectedCounty = selectedHouse.County;
                                selectedAddress = selectedHouse.Address;
                                selectedPrice = selectedHouse.Price;
                                selectedDescription = selectedHouse.Description;
                                selectedSold = selectedHouse.Sold;
                                selectedDeleteFlag = selectedHouse.DeleteFlag;

                            }

                            if (selectedOwnerId != 0 && selectedId != 0)
                            {
                                _saleService.Add(new Sale
                                {
                                    OwnerId = selectedOwnerId,
                                    SalePropertyId = selectedHousePropertyId,
                                    SalePropertyType = "House",
                                    CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                    SaleDate = DateTime.Now,
                                    SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                    DeleteFlag = false
                                });

                                _houseService.Update(new House
                                {
                                    Id = selectedId,
                                    PropertyId = selectedHousePropertyId,
                                    OwnerId = selectedOwnerId,
                                    Area = selectedArea,
                                    HouseType = selectedHouseType,
                                    City = selectedCity,
                                    County = selectedCounty,
                                    Address = selectedAddress,
                                    Price = selectedPrice,
                                    Description = selectedDescription,
                                    Sold = true,
                                    DeleteFlag = selectedDeleteFlag
                                });
                            }
                            LoadSaleHouse();
                            break;

                        case "Plot":

                            if (lkuPlot.EditValue == null)
                            {

                                MessageBox.Show(@"Plot  cannot be empty, please select a plot.", @"Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                break;
                            }
                            else
                            {
                                selectedPlotPropertyId = (int)lkuPlot.EditValue;
                            }

                            var selectedPlot = _plotService.GetAll()
                                .FirstOrDefault(f => f.PropertyId == selectedPlotPropertyId);

                            if (selectedPlot != null)
                            {
                                selectedId = selectedPlot.Id; // Seçilen Field'ın Id'sini al
                                selectedOwnerId = selectedPlot.OwnerId; // Seçilen Field'ın OwnerId'sini al
                                selectedArea = selectedPlot.Area;
                                selectedAda = selectedPlot.Ada;
                                selectedPafta = selectedPlot.Pafta;
                                selectedCity = selectedPlot.City;
                                selectedCounty = selectedPlot.County;
                                selectedAddress = selectedPlot.Address;
                                selectedPrice = selectedPlot.Price;
                                selectedDescription = selectedPlot.Description;
                                selectedSold = selectedPlot.Sold;
                                selectedDeleteFlag = selectedPlot.DeleteFlag;

                            }

                            if (selectedOwnerId != 0 && selectedId != 0)
                            {
                                _saleService.Add(new Sale
                                {
                                    OwnerId = selectedOwnerId,
                                    SalePropertyId = selectedPlotPropertyId,
                                    SalePropertyType = "Plot",
                                    CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                    SaleDate = DateTime.Now,
                                    SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                    DeleteFlag = false
                                });

                                _plotService.Update(new Plot
                                {
                                    Id = selectedId,
                                    PropertyId = selectedPlotPropertyId,
                                    OwnerId = selectedOwnerId,
                                    Area = selectedArea,
                                    Ada = selectedAda,
                                    Pafta = selectedPafta,
                                    City = selectedCity,
                                    County = selectedCounty,
                                    Address = selectedAddress,
                                    Price = selectedPrice,
                                    Description = selectedDescription,
                                    Sold = true,
                                    DeleteFlag = selectedDeleteFlag
                                });
                            }
                            LoadSalePlot();
                            break;

                        case "Shop":

                            if (lkuShop.EditValue == null)
                            {

                                MessageBox.Show(@"Shop  cannot be empty, please select a shop.", @"Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                break;
                            }
                            else
                            {
                                selectedShopPropertyId = (int)lkuShop.EditValue;
                            }

                            var selectedShop = _shopService.GetAll()
                                .FirstOrDefault(f => f.PropertyId == selectedShopPropertyId);

                            if (selectedShop != null)
                            {
                                selectedId = selectedShop.Id; // Seçilen Field'ın Id'sini al
                                selectedOwnerId = selectedShop.OwnerId; // Seçilen Field'ın OwnerId'sini al
                                selectedArea = selectedShop.Area;
                                selectedCity = selectedShop.City;
                                selectedCounty = selectedShop.County;
                                selectedAddress = selectedShop.Address;
                                selectedPrice = selectedShop.Price;
                                selectedDescription = selectedShop.Description;
                                selectedSold = selectedShop.Sold;
                                selectedDeleteFlag = selectedShop.DeleteFlag;

                            }

                            if (selectedOwnerId != 0 && selectedId != 0)
                            {
                                _saleService.Add(new Sale
                                {
                                    OwnerId = selectedOwnerId,
                                    SalePropertyId = selectedShopPropertyId,
                                    SalePropertyType = "Shop",
                                    CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                    SaleDate = DateTime.Now,
                                    SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                    DeleteFlag = false
                                });

                                _shopService.Update(new Shop
                                {
                                    Id = selectedId,
                                    PropertyId = selectedShopPropertyId,
                                    OwnerId = selectedOwnerId,
                                    Area = selectedArea,
                                    City = selectedCity,
                                    County = selectedCounty,
                                    Address = selectedAddress,
                                    Price = selectedPrice,
                                    Description = selectedDescription,
                                    Sold = true,
                                    DeleteFlag = selectedDeleteFlag
                                });
                            }
                            LoadSaleShop();
                            break;

                        default:
                            MessageBox.Show(@"Please select a property type.", @"Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
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
                DialogResult confirmation = MessageBox.Show(@"Are you sure you want to update the information?", @"Information", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    int selectedFieldPropertyId = 0;
                    int selectedHousePropertyId = 0;
                    int selectedPlotPropertyId = 0;
                    int selectedShopPropertyId = 0;
                    int selectedId = 0;
                    int selectedOwnerId = 0;
                    decimal selectedArea = 0;
                    string selectedAda = "";
                    string selectedPafta = "";
                    string selectedHouseType = "";
                    int selectedCity = 0;
                    int selectedCounty = 0;
                    string selectedAddress = "";
                    decimal selectedPrice = 0;
                    string selectedDescription = "";
                    bool selectedSold = false;
                    bool selectedDeleteFlag = false;

                    switch (cmbPropertyType.Text)
                    {
                        case "Field":

                            if (lkuField.EditValue == null)
                            {
                                MessageBox.Show(@"Field cannot be empty, please select a field.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                            else
                            {
                                selectedFieldPropertyId = (int)lkuField.EditValue;
                            }

                            var selectedField = _fieldService.GetAll()
                                .FirstOrDefault(f => f.PropertyId == selectedFieldPropertyId);

                            if (selectedField != null)
                            {
                                selectedId = selectedField.Id; // Seçilen Field'ın Id'sini al
                                selectedOwnerId = selectedField.OwnerId; // Seçilen Field'ın OwnerId'sini al
                                selectedArea = selectedField.Area;
                                selectedPafta = selectedField.Pafta;
                                selectedCity = selectedField.City;
                                selectedCounty = selectedField.County;
                                selectedAddress = selectedField.Address;
                                selectedPrice = selectedField.Price;
                                selectedDescription = selectedField.Description;
                                selectedSold = selectedField.Sold;
                                selectedDeleteFlag = selectedField.DeleteFlag;

                            }

                            if (selectedOwnerId != 0 && selectedId != 0)
                            {
                                _saleService.Update(new Sale
                                {
                                    Id = Convert.ToInt32(grwSale.GetRowCellValue(grwSale.FocusedRowHandle, "Id")),
                                    OwnerId = selectedOwnerId,
                                    SalePropertyId = selectedFieldPropertyId,
                                    SalePropertyType = "Field",
                                    CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                    SaleDate = DateTime.Now,
                                    SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                    DeleteFlag = false
                                });

                                _fieldService.Update(new Field
                                {
                                    Id = selectedId,
                                    PropertyId = selectedFieldPropertyId,
                                    OwnerId = selectedOwnerId,
                                    Area = selectedArea,
                                    Pafta = selectedPafta,
                                    City = selectedCity,
                                    County = selectedCounty,
                                    Address = selectedAddress,
                                    Price = selectedPrice,
                                    Description = selectedDescription,
                                    Sold = true,
                                    DeleteFlag = selectedDeleteFlag
                                });
                            }

                            LoadSaleField();

                            break;

                        case "House":

                            if (lkuHouse.EditValue == null)
                            {
                                MessageBox.Show(@"House  cannot be empty, please select a house.", @"Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                break;
                            }
                            else
                            {
                                selectedHousePropertyId = (int)lkuHouse.EditValue;
                            }

                            var selectedHouse = _houseService.GetAll()
                                .FirstOrDefault(f => f.PropertyId == selectedHousePropertyId);

                            if (selectedHouse != null)
                            {
                                selectedId = selectedHouse.Id; // Seçilen Field'ın Id'sini al
                                selectedOwnerId = selectedHouse.OwnerId; // Seçilen Field'ın OwnerId'sini al
                                selectedArea = selectedHouse.Area;
                                selectedHouseType = selectedHouse.HouseType;
                                selectedCity = selectedHouse.City;
                                selectedCounty = selectedHouse.County;
                                selectedAddress = selectedHouse.Address;
                                selectedPrice = selectedHouse.Price;
                                selectedDescription = selectedHouse.Description;
                                selectedSold = selectedHouse.Sold;
                                selectedDeleteFlag = selectedHouse.DeleteFlag;

                            }

                            if (selectedOwnerId != 0 && selectedId != 0)
                            {
                                _saleService.Update(new Sale
                                {
                                    Id = Convert.ToInt32(grwSale.GetRowCellValue(grwSale.FocusedRowHandle, "Id")),
                                    OwnerId = selectedOwnerId,
                                    SalePropertyId = selectedHousePropertyId,
                                    SalePropertyType = "House",
                                    CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                    SaleDate = DateTime.Now,
                                    SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                    DeleteFlag = false
                                });

                                _houseService.Update(new House
                                {
                                    Id = selectedId,
                                    PropertyId = selectedHousePropertyId,
                                    OwnerId = selectedOwnerId,
                                    Area = selectedArea,
                                    HouseType = selectedHouseType,
                                    City = selectedCity,
                                    County = selectedCounty,
                                    Address = selectedAddress,
                                    Price = selectedPrice,
                                    Description = selectedDescription,
                                    Sold = true,
                                    DeleteFlag = selectedDeleteFlag
                                });
                            }
                            LoadSaleHouse();
                            break;

                        case "Plot":

                            if (lkuPlot.EditValue == null)
                            {

                                MessageBox.Show(@"Plot  cannot be empty, please select a plot.", @"Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                break;
                            }
                            else
                            {
                                selectedPlotPropertyId = (int)lkuPlot.EditValue;
                            }

                            var selectedPlot = _plotService.GetAll()
                                .FirstOrDefault(f => f.PropertyId == selectedPlotPropertyId);

                            if (selectedPlot != null)
                            {
                                selectedId = selectedPlot.Id; // Seçilen Field'ın Id'sini al
                                selectedOwnerId = selectedPlot.OwnerId; // Seçilen Field'ın OwnerId'sini al
                                selectedArea = selectedPlot.Area;
                                selectedAda = selectedPlot.Ada;
                                selectedPafta = selectedPlot.Pafta;
                                selectedCity = selectedPlot.City;
                                selectedCounty = selectedPlot.County;
                                selectedAddress = selectedPlot.Address;
                                selectedPrice = selectedPlot.Price;
                                selectedDescription = selectedPlot.Description;
                                selectedSold = selectedPlot.Sold;
                                selectedDeleteFlag = selectedPlot.DeleteFlag;

                            }

                            if (selectedOwnerId != 0 && selectedId != 0)
                            {
                                _saleService.Update(new Sale
                                {
                                    Id = Convert.ToInt32(grwSale.GetRowCellValue(grwSale.FocusedRowHandle, "Id")),
                                    OwnerId = selectedOwnerId,
                                    SalePropertyId = selectedPlotPropertyId,
                                    SalePropertyType = "Plot",
                                    CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                    SaleDate = DateTime.Now,
                                    SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                    DeleteFlag = false
                                });

                                _plotService.Update(new Plot
                                {
                                    Id = selectedId,
                                    PropertyId = selectedPlotPropertyId,
                                    OwnerId = selectedOwnerId,
                                    Area = selectedArea,
                                    Ada = selectedAda,
                                    Pafta = selectedPafta,
                                    City = selectedCity,
                                    County = selectedCounty,
                                    Address = selectedAddress,
                                    Price = selectedPrice,
                                    Description = selectedDescription,
                                    Sold = true,
                                    DeleteFlag = selectedDeleteFlag
                                });
                            }
                            LoadSalePlot();
                            break;

                        case "Shop":

                            if (lkuShop.EditValue == null)
                            {

                                MessageBox.Show(@"Shop  cannot be empty, please select a shop.", @"Information", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                break;
                            }
                            else
                            {
                                selectedShopPropertyId = (int)lkuShop.EditValue;
                            }

                            var selectedShop = _shopService.GetAll()
                                .FirstOrDefault(f => f.PropertyId == selectedShopPropertyId);

                            if (selectedShop != null)
                            {
                                selectedId = selectedShop.Id; // Seçilen Field'ın Id'sini al
                                selectedOwnerId = selectedShop.OwnerId; // Seçilen Field'ın OwnerId'sini al
                                selectedArea = selectedShop.Area;
                                selectedCity = selectedShop.City;
                                selectedCounty = selectedShop.County;
                                selectedAddress = selectedShop.Address;
                                selectedPrice = selectedShop.Price;
                                selectedDescription = selectedShop.Description;
                                selectedSold = selectedShop.Sold;
                                selectedDeleteFlag = selectedShop.DeleteFlag;

                            }

                            if (selectedOwnerId != 0 && selectedId != 0)
                            {
                                _saleService.Update(new Sale
                                {
                                    Id = Convert.ToInt32(grwSale.GetRowCellValue(grwSale.FocusedRowHandle, "Id")),
                                    OwnerId = selectedOwnerId,
                                    SalePropertyId = selectedShopPropertyId,
                                    SalePropertyType = "Shop",
                                    CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                    SaleDate = DateTime.Now,
                                    SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                    DeleteFlag = false
                                });

                                _shopService.Update(new Shop
                                {
                                    Id = selectedId,
                                    PropertyId = selectedShopPropertyId,
                                    OwnerId = selectedOwnerId,
                                    Area = selectedArea,
                                    City = selectedCity,
                                    County = selectedCounty,
                                    Address = selectedAddress,
                                    Price = selectedPrice,
                                    Description = selectedDescription,
                                    Sold = true,
                                    DeleteFlag = selectedDeleteFlag
                                });
                            }
                            LoadSaleShop();
                            break;

                        default:
                            MessageBox.Show(@"Please select a property type.", @"Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            break;
                    }

                }
                else
                {
                    MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        void Remove()
        {
            DialogResult confirmation = MessageBox.Show(@"Are you sure you want to remove the information?", @"Information", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                int selectedFieldPropertyId = 0;
                int selectedHousePropertyId = 0;
                int selectedPlotPropertyId = 0;
                int selectedShopPropertyId = 0;
                int selectedId = 0;
                int selectedOwnerId = 0;
                decimal selectedArea = 0;
                string selectedAda = "";
                string selectedPafta = "";
                string selectedHouseType = "";
                int selectedCity = 0;
                int selectedCounty = 0;
                string selectedAddress = "";
                decimal selectedPrice = 0;
                string selectedDescription = "";
                bool selectedSold = false;
                bool selectedDeleteFlag = false;

                switch (cmbPropertyType.Text)
                {
                    case "Field":

                        if (lkuField.EditValue == null)
                        {
                            MessageBox.Show(@"Field cannot be empty, please select a field.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        else
                        {
                            selectedFieldPropertyId = (int)lkuField.EditValue;
                        }

                        var selectedField = _fieldService.GetAll()
                            .FirstOrDefault(f => f.PropertyId == selectedFieldPropertyId);

                        if (selectedField != null)
                        {
                            selectedId = selectedField.Id; // Seçilen Field'ın Id'sini al
                            selectedOwnerId = selectedField.OwnerId; // Seçilen Field'ın OwnerId'sini al
                            selectedArea = selectedField.Area;
                            selectedPafta = selectedField.Pafta;
                            selectedCity = selectedField.City;
                            selectedCounty = selectedField.County;
                            selectedAddress = selectedField.Address;
                            selectedPrice = selectedField.Price;
                            selectedDescription = selectedField.Description;
                            selectedSold = selectedField.Sold;
                            selectedDeleteFlag = selectedField.DeleteFlag;

                        }

                        if (selectedOwnerId != 0 && selectedId != 0)
                        {
                            _saleService.Update(new Sale
                            {
                                Id = Convert.ToInt32(grwSale.GetRowCellValue(grwSale.FocusedRowHandle, "Id")),
                                OwnerId = selectedOwnerId,
                                SalePropertyId = selectedFieldPropertyId,
                                SalePropertyType = "Field",
                                CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                SaleDate = DateTime.Now,
                                SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                DeleteFlag = true
                            });

                            _fieldService.Update(new Field
                            {
                                Id = selectedId,
                                PropertyId = selectedFieldPropertyId,
                                OwnerId = selectedOwnerId,
                                Area = selectedArea,
                                Pafta = selectedPafta,
                                City = selectedCity,
                                County = selectedCounty,
                                Address = selectedAddress,
                                Price = selectedPrice,
                                Description = selectedDescription,
                                Sold = false,
                                DeleteFlag = selectedDeleteFlag
                            });
                        }

                        LoadSaleField();
                        Clean();
                        break;

                    case "House":

                        if (lkuHouse.EditValue == null)
                        {
                            MessageBox.Show(@"House  cannot be empty, please select a house.", @"Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            break;
                        }
                        else
                        {
                            selectedHousePropertyId = (int)lkuHouse.EditValue;
                        }

                        var selectedHouse = _houseService.GetAll()
                            .FirstOrDefault(f => f.PropertyId == selectedHousePropertyId);

                        if (selectedHouse != null)
                        {
                            selectedId = selectedHouse.Id; // Seçilen Field'ın Id'sini al
                            selectedOwnerId = selectedHouse.OwnerId; // Seçilen Field'ın OwnerId'sini al
                            selectedArea = selectedHouse.Area;
                            selectedHouseType = selectedHouse.HouseType;
                            selectedCity = selectedHouse.City;
                            selectedCounty = selectedHouse.County;
                            selectedAddress = selectedHouse.Address;
                            selectedPrice = selectedHouse.Price;
                            selectedDescription = selectedHouse.Description;
                            selectedSold = selectedHouse.Sold;
                            selectedDeleteFlag = selectedHouse.DeleteFlag;

                        }

                        if (selectedOwnerId != 0 && selectedId != 0)
                        {
                            _saleService.Update(new Sale
                            {
                                Id = Convert.ToInt32(grwSale.GetRowCellValue(grwSale.FocusedRowHandle, "Id")),
                                OwnerId = selectedOwnerId,
                                SalePropertyId = selectedHousePropertyId,
                                SalePropertyType = "House",
                                CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                SaleDate = DateTime.Now,
                                SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                DeleteFlag = true
                            });

                            _houseService.Update(new House
                            {
                                Id = selectedId,
                                PropertyId = selectedHousePropertyId,
                                OwnerId = selectedOwnerId,
                                Area = selectedArea,
                                HouseType = selectedHouseType,
                                City = selectedCity,
                                County = selectedCounty,
                                Address = selectedAddress,
                                Price = selectedPrice,
                                Description = selectedDescription,
                                Sold = false,
                                DeleteFlag = selectedDeleteFlag
                            });
                        }
                        LoadSaleHouse();
                        Clean();
                        break;

                    case "Plot":

                        if (lkuPlot.EditValue == null)
                        {

                            MessageBox.Show(@"Plot  cannot be empty, please select a plot.", @"Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            break;
                        }
                        else
                        {
                            selectedPlotPropertyId = (int)lkuPlot.EditValue;
                        }

                        var selectedPlot = _plotService.GetAll()
                            .FirstOrDefault(f => f.PropertyId == selectedPlotPropertyId);

                        if (selectedPlot != null)
                        {
                            selectedId = selectedPlot.Id; // Seçilen Field'ın Id'sini al
                            selectedOwnerId = selectedPlot.OwnerId; // Seçilen Field'ın OwnerId'sini al
                            selectedArea = selectedPlot.Area;
                            selectedAda = selectedPlot.Ada;
                            selectedPafta = selectedPlot.Pafta;
                            selectedCity = selectedPlot.City;
                            selectedCounty = selectedPlot.County;
                            selectedAddress = selectedPlot.Address;
                            selectedPrice = selectedPlot.Price;
                            selectedDescription = selectedPlot.Description;
                            selectedSold = selectedPlot.Sold;
                            selectedDeleteFlag = selectedPlot.DeleteFlag;

                        }

                        if (selectedOwnerId != 0 && selectedId != 0)
                        {
                            _saleService.Update(new Sale
                            {
                                Id = Convert.ToInt32(grwSale.GetRowCellValue(grwSale.FocusedRowHandle, "Id")),
                                OwnerId = selectedOwnerId,
                                SalePropertyId = selectedPlotPropertyId,
                                SalePropertyType = "Plot",
                                CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                SaleDate = DateTime.Now,
                                SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                DeleteFlag = true
                            });

                            _plotService.Update(new Plot
                            {
                                Id = selectedId,
                                PropertyId = selectedPlotPropertyId,
                                OwnerId = selectedOwnerId,
                                Area = selectedArea,
                                Ada = selectedAda,
                                Pafta = selectedPafta,
                                City = selectedCity,
                                County = selectedCounty,
                                Address = selectedAddress,
                                Price = selectedPrice,
                                Description = selectedDescription,
                                Sold = false,
                                DeleteFlag = selectedDeleteFlag
                            });
                        }
                        LoadSalePlot();
                        Clean();
                        break;

                    case "Shop":


                        if (lkuShop.EditValue == null)
                        {

                            MessageBox.Show(@"Shop  cannot be empty, please select a shop.", @"Information", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            break;
                        }
                        else
                        {
                            selectedShopPropertyId = (int)lkuShop.EditValue;
                        }

                        var selectedShop = _shopService.GetAll()
                            .FirstOrDefault(f => f.PropertyId == selectedShopPropertyId);

                        if (selectedShop != null)
                        {
                            selectedId = selectedShop.Id; // Seçilen Field'ın Id'sini al
                            selectedOwnerId = selectedShop.OwnerId; // Seçilen Field'ın OwnerId'sini al
                            selectedArea = selectedShop.Area;
                            selectedCity = selectedShop.City;
                            selectedCounty = selectedShop.County;
                            selectedAddress = selectedShop.Address;
                            selectedPrice = selectedShop.Price;
                            selectedDescription = selectedShop.Description;
                            selectedSold = selectedShop.Sold;
                            selectedDeleteFlag = selectedShop.DeleteFlag;

                        }

                        if (selectedOwnerId != 0 && selectedId != 0)
                        {
                            _saleService.Update(new Sale
                            {
                                Id = Convert.ToInt32(grwSale.GetRowCellValue(grwSale.FocusedRowHandle, "Id")),
                                OwnerId = selectedOwnerId,
                                SalePropertyId = selectedShopPropertyId,
                                SalePropertyType = "Shop",
                                CustomerId = Convert.ToInt32(lkuCustomerId.EditValue),
                                SaleDate = DateTime.Now,
                                SalePrice = Convert.ToDecimal(txtSalePrice.Text),
                                DeleteFlag = true
                            });

                            _shopService.Update(new Shop
                            {
                                Id = selectedId,
                                PropertyId = selectedShopPropertyId,
                                OwnerId = selectedOwnerId,
                                Area = selectedArea,
                                City = selectedCity,
                                County = selectedCounty,
                                Address = selectedAddress,
                                Price = selectedPrice,
                                Description = selectedDescription,
                                Sold = false,
                                DeleteFlag = selectedDeleteFlag
                            });
                        }
                        LoadSaleShop();
                        Clean();
                        break;

                    default:
                        MessageBox.Show(@"Please select a property type.", @"Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        break;
                }

            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void grcSale_Click(object sender, EventArgs e)
        {
            LoadClick();
        }

        private void btnClear2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult confirmation = MessageBox.Show(@"Are you sure you want to clear the boxes?",
                @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                Clean();

                switch (cmbPropertyType.Text)
                {
                    case "Field":
                        LoadField();
                        break;

                    case "House":
                        LoadHouse();
                        break;

                    case "Plot":
                        LoadPlot();
                        break;

                    case "Shop":
                        LoadShop();
                        break;
                }
            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show(@"Are you sure you want to clear the boxes?",
                @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                Clean();

                switch (cmbPropertyType.Text)
                {
                    case "Field":
                        LoadField();
                        break;

                    case "House":
                        LoadHouse();
                        break;

                    case "Plot":
                        LoadPlot();
                        break;

                    case "Shop":
                        LoadShop();
                        break;
                }
            }
            else
            {
                MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            Sale();
        }

        private void btnSale2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sale();
        }

        private void btnDelete2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Remove();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void btnExcelTransfer2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _commonMethods.ExcelTransfer(grwSale);
        }

        private void grwSale_MouseDown(object sender, MouseEventArgs e)
        {
            if (cmbPropertyType.Text != "")
            {
                if (e.Button == MouseButtons.Right)
                {
                    var position = MousePosition;
                    grwSale.Focus();
                    popupMenu1.ShowPopup(position);
                }
            }
            else
            {
                MessageBox.Show(@"Please select a property type.", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }


        }

        private CustomerForm _customerForm = new CustomerForm();
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            _customerForm.ribbonControl1.Visible = true;
            _customerForm.lcSave.Visibility = LayoutVisibility.Never;
            _customerForm.lcDelete.Visibility = LayoutVisibility.Never;
            _customerForm.lcClear.Visibility = LayoutVisibility.Never;
            _customerForm.ShowDialog();
            LoadSale();
        }

        private void lkuCustomerId_Properties_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.DisplayText = "";
            }
        }

        private void lkuCustomerId_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
            {
                e.DisplayText = "";
            }
        }
    }
}