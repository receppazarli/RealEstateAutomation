using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraLayout.Utils;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class SaleForm : DevExpress.XtraEditors.XtraForm
    {
        public SaleForm()
        {
            InitializeComponent();
            _customerService = InstanceFactory.GetInstance<ICustomerService>();
            _saleService = InstanceFactory.GetInstance<ISaleService>();
            _fieldService = InstanceFactory.GetInstance<IFieldService>();
            _houseService = InstanceFactory.GetInstance<IHouseService>();
            _plotService = InstanceFactory.GetInstance<IPlotService>();
            _shopService = InstanceFactory.GetInstance<IShopService>();
        }

        private readonly ICustomerService _customerService;
        private readonly ISaleService _saleService;
        private readonly IFieldService _fieldService;
        private readonly IHouseService _houseService;
        private readonly IPlotService _plotService;
        private readonly IShopService _shopService;

        private void SaleForm_Load(object sender, EventArgs e)
        {

        }

        void LoadCustomer()
        {
            lkuCustomerId.Properties.DataSource = _customerService.GetAll();
            lkuCustomerId.Properties.DisplayMember = "FirstName";
            lkuCustomerId.Properties.ValueMember = "Id";
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
                            grcField.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);
                            lycSale.Visibility = LayoutVisibility.Never;
                            lycHouse.Visibility = LayoutVisibility.Never;
                            lycPlot.Visibility = LayoutVisibility.Never;
                            lycShop.Visibility = LayoutVisibility.Never;
                            lycField.Visibility = LayoutVisibility.Always;

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
                            grcHouse.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

                        }
                        lycSale.Visibility = LayoutVisibility.Never;
                        lycPlot.Visibility = LayoutVisibility.Never;
                        lycShop.Visibility = LayoutVisibility.Never;
                        lycField.Visibility = LayoutVisibility.Never;
                        lycHouse.Visibility = LayoutVisibility.Always;
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
                            grcPlot.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);
                            lycSale.Visibility = LayoutVisibility.Never;
                            lycShop.Visibility = LayoutVisibility.Never;
                            lycField.Visibility = LayoutVisibility.Never;
                            lycHouse.Visibility = LayoutVisibility.Never;
                            lycPlot.Visibility = LayoutVisibility.Always;

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
                            grcShop.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);
                            lycSale.Visibility = LayoutVisibility.Never;
                            lycField.Visibility = LayoutVisibility.Never;
                            lycHouse.Visibility = LayoutVisibility.Never;
                            lycPlot.Visibility = LayoutVisibility.Never;
                            lycShop.Visibility = LayoutVisibility.Always;

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

        private void cmbPropertyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSale();
        }
    }
}