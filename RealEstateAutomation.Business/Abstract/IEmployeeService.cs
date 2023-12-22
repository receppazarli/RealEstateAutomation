using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        void Add(Employee employee);
        void Update(Employee employee);

        void Update2(Employee employee);
    }
}