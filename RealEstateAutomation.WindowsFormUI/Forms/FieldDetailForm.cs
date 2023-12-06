using DevExpress.XtraEditors;
using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.DashboardCommon;
using DevExpress.DashboardCommon.Native;
using DevExpress.XtraRichEdit.Model;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using Field = RealEstateAutomation.Entities.Concrete.Field;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class FieldDetailForm : DevExpress.XtraEditors.XtraForm
    {


        public FieldDetailForm()
        {
            InitializeComponent();
            _fieldService = InstanceFactory.GetInstance<IFieldService>();
            _ownerService = InstanceFactory.GetInstance<IOwnerService>();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _countyService = InstanceFactory.GetInstance<ICountyService>();
        }

        private static IFieldService _fieldService;
        private readonly IOwnerService _ownerService;
        private readonly ICityService _cityService;
        private readonly ICountyService _countyService;

        private void FieldDetailForm_Load(object sender, EventArgs e)
        {

            // LoadField();
            LoadOwner();
            LoadCity();
            LoadCounty();

        }
        void LoadOwner()
        {
            lkuOwnerId.Properties.DataSource = _ownerService.GetAll();
            lkuOwnerId.Properties.DisplayMember = "FirstName";
            lkuOwnerId.Properties.ValueMember = "Id";
        }

        private void LoadCity()
        {
            lkuCity.Properties.DataSource = _cityService.GetAll();
            lkuCity.Properties.DisplayMember = "CityName";
            lkuCity.Properties.ValueMember = "Id";
        }

        private void LoadCounty()
        {
            lkuCounty.Properties.DataSource = _countyService.GetAll(Convert.ToInt32(lkuCity.EditValue)).ToList();
            lkuCounty.Properties.DisplayMember = "CountyName";
            lkuCounty.Properties.ValueMember = "Id";
        }

        private void lkuCity_EditValueChanged(object sender, EventArgs e)
        {
            LoadCounty();
        }

        //DbHotelEntities db = new DbHotelEntities();
        //public int id;

        //Repository<TblProductProcess> repo = new Repository<TblProductProcess>();
        //TblProductProcess t = new TblProductProcess();

        //private void FrmProcessDefinitions_Load(object sender, EventArgs e)
        //{
        //    //id value
        //    TxtID.Text = id.ToString();
        //    TxtID.Enabled = false;

        //    lookUpEditProduct.Properties.DataSource = (from x in db.TblProducts
        //        select new
        //        {
        //            x.ProductID,
        //            x.ProductName
        //        }).ToList();
        //          //fill the list
        //    if (id != 0)
        //    {
        //        var product = repo.Find(x => x.ProcessID == id);
        //        lookUpEditProduct.EditValue = product.Product;
        //        TxtAmount.Text = product.Amount.ToString();
        //        TxtStatement.Text = product.Statement;
        //        comboBox1.Text = product.ProcessType;
        //        dateEdit1.Text = product.Date.ToString();
        //    }
        //}

       // private EfEntityRepositoryBase<> repo = new EfFieldDal();



        void LoadField(int id)
        {
            var field = _fieldService.GetById(id);

            if (field != null)
            {
                //txtId.Text=field
            }


        }


    }
}