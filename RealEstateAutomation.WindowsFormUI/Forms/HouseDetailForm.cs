using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using System;
using System.Linq;
using System.Windows.Forms;
using RealEstateAutomation.DataAccess.Concrete.EntityFramework;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class HouseDetailForm : DevExpress.XtraEditors.XtraForm
    {
        public HouseDetailForm()
        {
            InitializeComponent();
            _houseService = InstanceFactory.GetInstance<IHouseService>();
            _ownerService = InstanceFactory.GetInstance<IOwnerService>();
            _cityService = InstanceFactory.GetInstance<ICityService>();
            _countyService = InstanceFactory.GetInstance<ICountyService>();
        }

        private readonly IHouseService _houseService;
        private readonly IOwnerService _ownerService;
        private readonly ICityService _cityService;
        private readonly ICountyService _countyService;

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


        private void HouseDetailForm_Load(object sender, EventArgs e)
        {
            LoadOwner();
            LoadCity();
            LoadCounty();
            LoadHouse();
        }

        private void lkuCity_EditValueChanged(object sender, EventArgs e)
        {
            LoadCounty();
        }

        public int ItemId;

        private House _house = new House();

        void LoadHouse()
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
                                 Area = h.Area,
                                 HouseType = h.HouseType,
                                 City = ci.CityName,
                                 County = co.CountyName,
                                 Address = h.Address,
                                 Price = h.Price,
                                 Description = h.Description,
                                 DeleteFlag = h.DeleteFlag,
                             };

                var house = entity.ToList().Where(x => x.Id == ItemId);

                var current = house.FirstOrDefault(x => x.Id == ItemId);

                if (current != null)
                {
                    try
                    {
                        txtId.Text = current.Id.ToString();
                        txtPropertyType.Text = current.PropertyId.ToString();

                        lkuOwnerId.EditValue = current.OwnerId;
                        lkuCity.Text = current.City;
                        lkuCounty.Text = current.County;

                        txtArea.Text = current.Area.ToString();
                        txtHouseType.Text = current.HouseType;
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
                    _houseService.Update(new House
                    {
                        Id = Convert.ToInt32(txtId.Text),
                        PropertyId = Convert.ToInt32(txtPropertyType.Text),
                        OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                        Area = Convert.ToDecimal(txtArea.Text),
                        HouseType = txtHouseType.Text,
                        City = Convert.ToInt32(lkuCity.EditValue),
                        County = Convert.ToInt32(lkuCounty.EditValue),
                        Address = txtAddress.Text,
                        Price = Convert.ToDecimal(txtPrice.Text),
                        Description = txtDescription.Text,
                        Sold = false,
                        DeleteFlag = false
                    });
                    LoadHouse();
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