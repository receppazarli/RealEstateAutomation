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
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class PropertyForm : DevExpress.XtraEditors.XtraForm
    {
        public PropertyForm()
        {
            InitializeComponent();

            _fieldService = InstanceFactory.GetInstance<IFieldService>();
            _houseService = InstanceFactory.GetInstance<IHouseService>();
            _plotService = InstanceFactory.GetInstance<IPlotService>();
            _shopService = InstanceFactory.GetInstance<IShopService>();
        }


        private readonly IHouseService _houseService;
        private readonly IPlotService _plotService;
        private readonly IShopService _shopService;
        private readonly IFieldService _fieldService;

        private void PropertyForm_Load(object sender, EventArgs e)
        {
            LoadField();
            LoadShop();
            LoadHouse();
            LoadPlot();
        }

        void LoadField()
        {
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
                                     PropertyId = p.PropertyType,
                                     OwnerId = o.FirstName,
                                     Area = f.Area,
                                     Pafta = f.Pafta,
                                     City = ci.CityName,
                                     County = co.CountyName,
                                     Address = f.Address,
                                     Price = f.Price,
                                     Description = f.Description,
                                     DeleteFlag = f.DeleteFlag,
                                 };
                    grcField.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        void LoadHouse()
        {
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
                                     PropertyId = p.PropertyType,
                                     OwnerId = o.FirstName,
                                     Area = h.Area,
                                     HouseType = h.HouseType,
                                     City = ci.CityName,
                                     County = co.CountyName,
                                     Address = h.Address,
                                     Price = h.Price,
                                     Description = h.Description,
                                     DeleteFlag = h.DeleteFlag,
                                 };
                    grcHouse.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        void LoadPlot()
        {
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
                                     PropertyId = p.PropertyType,
                                     OwnerId = o.FirstName,
                                     Area = pl.Area,
                                     Ada = pl.Ada,
                                     Pafta = pl.Pafta,
                                     City = ci.CityName,
                                     County = co.CountyName,
                                     Address = pl.Address,
                                     Price = pl.Price,
                                     Description = pl.Description,
                                     DeleteFlag = pl.DeleteFlag,
                                 };
                    grcPlot.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        void LoadShop()
        {
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
                                     PropertyId = p.PropertyType,
                                     OwnerId = o.FirstName,
                                     Area = s.Area,
                                     City = ci.CityName,
                                     County = co.CountyName,
                                     Address = s.Address,
                                     Price = s.Price,
                                     Description = s.Description,
                                     DeleteFlag = s.DeleteFlag,
                                 };
                    grcShop.DataSource = entity.ToList().Where(x => x.DeleteFlag == false);

                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }



        private void grcField_DoubleClick(object sender, EventArgs e)
        {

            FieldDetailForm fieldDetailForm = new FieldDetailForm();
            fieldDetailForm.ItemId = Convert.ToInt32(grwField.GetRowCellValue(grwField.FocusedRowHandle, "Id"));
            fieldDetailForm.ShowDialog();
            LoadField();
        }

        private void grcPlot_DoubleClick(object sender, EventArgs e)
        {
            PlotDetailForm plotDetailForm = new PlotDetailForm();
            plotDetailForm.ItemId = Convert.ToInt32(grwPlot.GetRowCellValue(grwPlot.FocusedRowHandle, "Id"));
            plotDetailForm.ShowDialog();
            LoadPlot();
        }

        private void grcShop_DoubleClick(object sender, EventArgs e)
        {
            ShopDetailForm shopDetailForm = new ShopDetailForm();
            shopDetailForm.ItemId = Convert.ToInt32(grwShop.GetRowCellValue(grwShop.FocusedRowHandle, "Id"));
            shopDetailForm.ShowDialog();
            LoadShop();
        }

        private void grcHouse_DoubleClick(object sender, EventArgs e)
        {
            HouseDetailForm houseDetailForm = new HouseDetailForm();
            houseDetailForm.ItemId = Convert.ToInt32(grwHouse.GetRowCellValue(grwHouse.FocusedRowHandle, "Id"));
            houseDetailForm.ShowDialog();
            LoadHouse();
        }
    }
}