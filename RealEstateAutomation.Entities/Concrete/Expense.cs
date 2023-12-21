using RealEstateAutomation.Entities.Abstract;
using System;

namespace RealEstateAutomation.Entities.Concrete
{
    public class Expense : IEntity
    {
        public int Id { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public decimal ExpensePrice { get; set; }
        public string Description { get; set; }
        public bool DeleteFlag { get; set; }
    }
}