using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        User GetLastAddedUser();
        void Delete(User user);
        void Update(User user);
        List<User> GetAll();
    }
}