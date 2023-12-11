using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IPlotService
    {
        void Add(Plot plot);
        void Update(Plot plot);
        Plot GetLastAddedHouse();
    }
}