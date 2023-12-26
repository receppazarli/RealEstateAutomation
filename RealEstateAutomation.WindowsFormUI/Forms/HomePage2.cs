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
using RealEstateAutomation.Entities.Concrete;
using DevExpress.XtraCharts;

namespace RealEstateAutomation.WindowsFormUI.Forms
{
    public partial class HomePage2 : DevExpress.XtraEditors.XtraForm
    {
        public HomePage2()
        {
            InitializeComponent();
            _expenseService = InstanceFactory.GetInstance<IExpenseService>();
            _incomeService = InstanceFactory.GetInstance<IIncomeService>();
            _customerService = InstanceFactory.GetInstance<ICustomerService>();
        }

        private IExpenseService _expenseService;
        private IIncomeService _incomeService;
        private readonly ICustomerService _customerService;

        private void HomePage2_Load(object sender, EventArgs e)
        {
            LoadCurrency();
            LoadCustomer();
            LoadChartExpense();
            LoadChartIncome();
        }

        void LoadCurrency()
        {
            webBrowser1.Navigate("https://tcmb.gov.tr/kurlar/today.xml");
        }

        private void LoadCustomer()
        {
            grcCustomer.DataSource = _customerService.GetAll();
        }

        void LoadChartExpense()
        {
            using (var context = new RealEstateAutomationContext())
            {
                var query = from e in context.Expenses
                            where e.DeleteFlag == false
                            group e by e.ExpenseDate
                    into g
                            select new
                            {
                                ExpenseDate = g.Key,
                                TotalExpense = g.Sum(x => x.ExpensePrice)
                            };

                var expenseList = query.ToList();

                if (chartControlExpense.Series["Expenses"] == null)
                {
                    chartControlExpense.Series.Add(new Series("Expenses", ViewType.Bar));
                }

                Series series = chartControlExpense.Series["Expenses"];

                foreach (var e in expenseList)
                {
                    series.Points.Add(new SeriesPoint(Convert.ToDateTime(e.ExpenseDate),
                        Convert.ToDouble(e.TotalExpense)));
                }
            }

        }


        void LoadChartIncome()
        {
            using (var context = new RealEstateAutomationContext())
            {
                var query = from i in context.Incomes
                            where i.DeleteFlag == false
                            group i by i.IncomeDate
                    into g
                            select new
                            {
                                IncomeDate = g.Key,
                                TotalIncome = g.Sum(x => x.IncomePrice)
                            };

                var incomeList = query.ToList();

                if (chartControlIncome.Series["Incomes"] == null)
                {
                    chartControlIncome.Series.Add(new Series("Incomes", ViewType.Bar));
                }

                Series series = chartControlIncome.Series["Incomes"];

                foreach (var e in incomeList)
                {
                    series.Points.Add(new SeriesPoint(Convert.ToDateTime(e.IncomeDate),
                        Convert.ToDouble(e.TotalIncome)));
                }
            }

        }
    }
}