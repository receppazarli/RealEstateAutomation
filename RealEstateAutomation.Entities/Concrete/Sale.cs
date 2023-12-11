using System;
using System.Runtime.InteropServices.ComTypes;
using RealEstateAutomation.Entities.Abstract;

namespace RealEstateAutomation.Entities.Concrete
{
    public class Sale : IEntity
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int CustomerId { get; set; }
        public int SalePropertyId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }
        public bool DeleteFlag { get; set; }
    }
}