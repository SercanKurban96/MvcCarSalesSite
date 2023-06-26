using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCarSalesSite.Models
{
    public class Advert
    {
        public int AdvertID { get; set; }
        public string AdvertNo { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string AdvertDate { get; set; }
        public int Kilometer { get; set; }
        public int ModelYear { get; set; }
        public string FuelType { get; set; }
        public string GearType { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public int StatusID { get; set; }
        public Status Status { get; set; }

        public int BrandID { get; set; }
        public int ModelID { get; set; }
        public Model Model { get; set; }

        public int CityID { get; set; }
        public City City { get; set; }

        public List<Picture> Pictures { get; set; }
    }
}