using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCarSalesSite.Models
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public List<Model> Models { get; set; }
    }
}