using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        void Save(Employee employee);
        void Update(Employee employee);

    }
}