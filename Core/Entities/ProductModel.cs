using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductModel: BaseEntity
    {
        public string Name{get;set;} = null!;
        public string Description{ get; set; } = null!;
        public decimal Price{get;set;}
        public int Capacity{get;set;}
        public string PictureUrl{get;set;} = null!;
        public CampCity CampCity{get;set;} = null!;
        public int CampCityId{get;set;}
    }
}