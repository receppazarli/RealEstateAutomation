using RealEstateAutomation.Entities.Abstract;
using System;

namespace RealEstateAutomation.Entities.Concrete
{
    public class Income : IEntity
    {
        public int Id { get; set; }
        public DateTime? IncomeDate  { get; set; }
        public decimal IncomePrice { get; set; }
        public string Description { get; set; }
        public bool DeleteFlag { get; set; }
    }
}