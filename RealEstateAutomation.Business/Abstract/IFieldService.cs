using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IFieldService
    {
        List<Field> GetAll();
        void Add(Field field);
        void Update(Field field);
    }
}