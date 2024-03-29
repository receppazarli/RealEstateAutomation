﻿using System.Collections.Generic;
using RealEstateAutomation.Entities.Concrete;

namespace RealEstateAutomation.Business.Abstract
{
    public interface IHouseService
    {
        void Add(House house);
        void Update(House house);
        House GetLastAddedHouse();
        List<House> GetAll();
    }
}