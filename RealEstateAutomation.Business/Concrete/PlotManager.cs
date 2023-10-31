using RealEstateAutomation.Business.Abstract;
using RealEstateAutomation.DataAccess.Abstract;

namespace RealEstateAutomation.Business.Concrete
{
    public class PlotManager :IPlotService
    {
        private IPlotDal _plotDal;

        public PlotManager(IPlotDal plotDal)
        {
            _plotDal = plotDal;
        }
    }
}