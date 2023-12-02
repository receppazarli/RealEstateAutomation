using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IOwnerService
    {
        List<Owner> GetAll();

        void Save(Owner owner);
        void Update(Owner owner);

    }
}