using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll();
        void Save(Admin admin);
        void Update(Admin admin);

    }
}