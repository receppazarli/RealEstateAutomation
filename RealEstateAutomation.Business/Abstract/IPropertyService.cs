using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IPropertyService
    {
        List<Property> GetAll();
        void Add(Property property);

        Property GetLastAddedProperty();
        void Update(Property property);
        void Delete(Property property);

    }
}