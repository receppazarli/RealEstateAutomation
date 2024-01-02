using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAll();
        void Add(Admin admin);
        void Update(Admin admin);
        void Update2(Admin admin);
    }
}