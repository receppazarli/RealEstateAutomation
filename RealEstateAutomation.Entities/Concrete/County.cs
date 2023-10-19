﻿using RealEstateAutomation.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAutomation.Entities.Concrete
{
    public class County :IEntity
    {
        public int Id { get; set; }
        public string CountyName { get; set; }
        public int  CityId { get; set; }
    }
}
