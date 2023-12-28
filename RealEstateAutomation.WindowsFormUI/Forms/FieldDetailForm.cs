using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.Business.DependencyResolvers;
using System;
using System.Linq;
using System.Windows.Forms;
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
            LoadOwner();
            LoadCity();
            LoadCounty();
            LoadField();

            txtId.Text = ItemId.ToString();

        }

        public int ItemId;

        private readonly Field _field = new Field();


        void LoadField()
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
                                 OwnerId = f.OwnerId,
                                 Area = f.Area,
                                 Pafta = f.Pafta,
                                 City = ci.CityName,
                                 County = co.CountyName,
                                 Address = f.Address,
                                 Price = f.Price,
                                 Description = f.Description,
                                 DeleteFlag = f.DeleteFlag,
                             };

                var field = entity.ToList().Where(x => x.Id == ItemId);

                var current = field.FirstOrDefault(x => x.Id == ItemId);
                if (current != null)
                {
                    txtId.Text = current.Id.ToString();

                    txtPropertyType.Text = current.PropertyId.ToString();

                    lkuOwnerId.EditValue = current.OwnerId;
                    lkuCity.Text = current.City.ToString();
                    lkuCounty.Text = current.County.ToString();

                    txtArea.Text = current.Area.ToString();
                    txtPafta.Text = current.Pafta;
                    txtAddress.Text = current.Address;
                    txtPrice.Text = current.Price.ToString();
                    txtDescription.Text = current.Description;
                }
                else
                {
                    MessageBox.Show(@"There was an error loading the information. Please try again.", @"Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }




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

        void Save()
        {
            if (txtId.Text != "")
            {
                DialogResult confirmation = MessageBox.Show(@"Are you sure you want to update the information?",
                    @"Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    try
                    {
                        _fieldService.Update(new Field
                        {
                            Id = Convert.ToInt32(txtId.Text),
                            PropertyId = Convert.ToInt32(txtPropertyType.Text),
                            OwnerId = Convert.ToInt32(lkuOwnerId.EditValue),
                            Area = Convert.ToDecimal(txtArea.Text),
                            Pafta = txtPafta.Text,
                            City = Convert.ToInt32(lkuCity.EditValue),
                            County = Convert.ToInt32(lkuCounty.EditValue),
                            Address = txtAddress.Text,
                            Price = Convert.ToDecimal(txtPrice.Text),
                            Description = txtDescription.Text,
                            Sold = false,
                            DeleteFlag = false
                        });
                        LoadField();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(@"Incorrect data entry, Please fill in the missing fields ", @"Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }

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