using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using System;
using System.Linq;
using System.Windows.Forms;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class ShopDetailForm : DevExpress.XtraEditors.XtraForm
    {
        public ShopDetailForm()
        {
            InitializeComponent();
            _shopService = InstanceFactory.GetInstance<IShopService>();
            _ownerService = InstanceFactory.GetInstance<IOwnerService>();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _countyService = InstanceFactory.GetInstance<ICountyService>();
        }

        private readonly IShopService _shopService;
        private readonly IOwnerService _ownerService;
        private readonly ICityService _cityService;
        private readonly ICountyService _countyService;

        private void ShopDetailForm_Load(object sender, EventArgs e)
        {
            LoadOwner();
            LoadCity();
            LoadCounty();
            LoadShop();
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

        public int ItemId;

        void LoadShop()
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
                                 DeleteFlag = s.DeleteFlag,
                             };
                var field = entity.ToList().Where(x => x.Id == ItemId);

                var current = field.FirstOrDefault(x => x.Id == ItemId);
                if (current != null)
                {
                    try
                    {
                        txtId.Text = current.Id.ToString();
                        txtPropertyType.Text = current.PropertyId.ToString();


                        lkuOwnerId.Text = current.OwnerId;
                        lkuCity.Text = current.City.ToString();
                        lkuCounty.Text = current.County.ToString();

                        txtArea.Text = current.Area.ToString();
                        txtAddress.Text = current.Address;
                        txtPrice.Text = current.Price.ToString();
                        txtDescription.Text = current.Description;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"Incorrect data entry, Please fill in the missing fields ", @"Information", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        void Save()
        {
            if (txtId.Text != "")
            {
                DialogResult confirmation = MessageBox.Show(@"Are you sure you want to update the information?",
                    @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    _shopService.Update(new Shop
                    {
                        Id = Convert.ToInt32(txtId.Text),
                        PropertyId = Convert.ToInt32(txtPropertyType.Text),
                        OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                        Area = Convert.ToDecimal(txtArea.Text),
                        City = Convert.ToInt32(lkuCity.EditValue),
                        County = Convert.ToInt32(lkuCounty.EditValue),
                        Address = txtAddress.Text,
                        Price = Convert.ToDecimal(txtPrice.Text),
                        Description = txtDescription.Text,
                        Sold = false,
                        DeleteFlag = false
                    });
                    LoadShop();
                }
                else
                {
                    MessageBox.Show(@"Your transaction has been canceled.", @"Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}