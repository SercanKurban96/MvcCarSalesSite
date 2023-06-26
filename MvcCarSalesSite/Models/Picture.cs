using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCarSalesSite.Models
{
    public class Picture
    {
        public int PictureID { get; set; }
        public string PictureName { get; set; }
        public int AdvertID { get; set; }
        public virtual Advert Advert { get; set; }
    }
}