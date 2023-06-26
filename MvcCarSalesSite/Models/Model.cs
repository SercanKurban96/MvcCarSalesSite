using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCarSalesSite.Models
{
    public class Model
    {
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }
    }
}