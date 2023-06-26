using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcCarSalesSite.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var cities = new List<City>()
            {
                new City() {CityName="ADANA"},
                new City() {CityName="ADIYAMAN"},
                new City() {CityName="AFYONKARAHİSAR"},
                new City() {CityName="AĞRI"},
                new City() {CityName="AMASYA"},
                new City() {CityName="ANKARA"},
                new City() {CityName="ANTALYA"},
                new City() {CityName="ARTVİN"},
                new City() {CityName="AYDIN"},
                new City() {CityName="BALIKESİR"},
                new City() {CityName="BİLECİK"},
                new City() {CityName="BİNGÖL"},
                new City() {CityName="BİTLİS"},
                new City() {CityName="BOLU"},
                new City() {CityName="BURDUR"},
                new City() {CityName="BURSA"},
                new City() {CityName="ÇANAKKALE"},
                new City() {CityName="ÇANKIRI"},
                new City() {CityName="ÇORUM"},
                new City() {CityName="DENİZLİ"},
                new City() {CityName="DİYARBAKIR"},
                new City() {CityName="EDİRNE"},
                new City() {CityName="ELAZIĞ"},
                new City() {CityName="ERZİNCAN"},
                new City() {CityName="ERZURUM"},
                new City() {CityName="ESKİŞEHİR"},
                new City() {CityName="GAZİANTEP"},
                new City() {CityName="GİRESUN"},
                new City() {CityName="GÜMÜŞHANE"},
                new City() {CityName="HAKKARİ"},
                new City() {CityName="HATAY"},
                new City() {CityName="ISPARTA"},
                new City() {CityName="MERSİN"},
                new City() {CityName="İSTANBUL"},
                new City() {CityName="İZMİR"},
                new City() {CityName="KARS"},
                new City() {CityName="KASTAMONU"},
                new City() {CityName="KAYSERİ"},
                new City() {CityName="KIRKLARELİ"},
                new City() {CityName="KIRŞEHİR"},
                new City() {CityName="KOCAELİ"},
                new City() {CityName="KONYA"},
                new City() {CityName="KÜTAHYA"},
                new City() {CityName="MALATYA"},
                new City() {CityName="MANİSA"},
                new City() {CityName="KAHRAMANMARAŞ"},
                new City() {CityName="MARDİN"},
                new City() {CityName="MUĞLA"},
                new City() {CityName="MUŞ"},
                new City() {CityName="NEVŞEHİR"},
                new City() {CityName="NİĞDE"},
                new City() {CityName="ORDU"},
                new City() {CityName="RİZE"},
                new City() {CityName="SAKARYA"},
                new City() {CityName="SAMSUN"},
                new City() {CityName="SİİRT"},
                new City() {CityName="SİNOP"},
                new City() {CityName="SİVAS"},
                new City() {CityName="TEKİRDAĞ"},
                new City() {CityName="TOKAT"},
                new City() {CityName="TRABZON"},
                new City() {CityName="TUNCELİ"},
                new City() {CityName="ŞANLIURFA"},
                new City() {CityName="UŞAK"},
                new City() {CityName="VAN"},
                new City() {CityName="YOZGAT"},
                new City() {CityName="ZONGULDAK"},
                new City() {CityName="AKSARAY"},
                new City() {CityName="BAYBURT"},
                new City() {CityName="KARAMAN"},
                new City() {CityName="KIRIKKALE"},
                new City() {CityName="BATMAN"},
                new City() {CityName="ŞIRNAK"},
                new City() {CityName="BARTIN"},
                new City() {CityName="ARDAHAN"},
                new City() {CityName="IĞDIR"},
                new City() {CityName="YALOVA"},
                new City() {CityName="KARABÜK"},
                new City() {CityName="KİLİS"},
                new City() {CityName="OSMANİYE"},
                new City() {CityName="DÜZCE"}
            };

            foreach (var item in cities)
            {
                context.Cities.Add(item);
            }
            context.SaveChanges();
            var status = new List<Status>()
            {
                new Status(){StatusName="KİRALIK"},
                new Status(){StatusName="SATILIK"}
            };

            foreach (var item in status)
            {
                context.Statuses.Add(item);
            }
            context.SaveChanges();

            var brand = new List<Brand>()
            {
                new Brand(){BrandName="BMW"},
                new Brand(){BrandName="MERCEDES"},
                new Brand(){BrandName="AUDI"},
                new Brand(){BrandName="FERRARI"},
                new Brand(){BrandName="MCLAREN"},
                new Brand(){BrandName="PORSCHE"},
                new Brand(){BrandName="FIAT"},
                new Brand(){BrandName="FORD"},
                new Brand(){BrandName="RENAULT"},
                new Brand(){BrandName="KOENIGSEGG"}
            };

            foreach (var item in brand)
            {
                context.Brands.Add(item);
            }
            context.SaveChanges();

            var model = new List<Model>()
            {
                new Model() {ModelName="520", BrandID=1},
                new Model() {ModelName="X5", BrandID=1},
                new Model() {ModelName="A180", BrandID=2},
                new Model() {ModelName="Q7", BrandID=3},
                new Model() {ModelName="A3", BrandID=3},
                new Model() {ModelName="A4", BrandID=3},
                new Model() {ModelName="RS7", BrandID=3},
                new Model() {ModelName="F40", BrandID=4},
                new Model() {ModelName="430", BrandID=4},
                new Model() {ModelName="Enzo", BrandID=4},
                new Model() {ModelName="458 Spyder", BrandID=4},
                new Model() {ModelName="F1", BrandID=5},
                new Model() {ModelName="P1", BrandID=5},
                new Model() {ModelName="720S", BrandID=5},
                new Model() {ModelName="Cayenne", BrandID=6},
                new Model() {ModelName="911", BrandID=6},
                new Model() {ModelName="Carrera GT", BrandID=6},
                new Model() {ModelName="Egea", BrandID=7},
                new Model() {ModelName="Fiorino", BrandID=7},
                new Model() {ModelName="Doblo", BrandID=7},
                new Model() {ModelName="Focus", BrandID=8},
                new Model() {ModelName="Tourneo", BrandID=8},
                new Model() {ModelName="GT", BrandID=8},
                new Model() {ModelName="Austral", BrandID=9},
                new Model() {ModelName="Clio", BrandID=9},
                new Model() {ModelName="Duster", BrandID=9},
                new Model() {ModelName="Agera RS", BrandID=10},
                new Model() {ModelName="Agera R", BrandID=10},
                new Model() {ModelName="CCX", BrandID=10},
            };

            foreach (var item in model)
            {
                context.Models.Add(item);
            }
            context.SaveChanges();  

            var advert = new List<Advert>()
            {
                new Advert(){BrandID=1, Description="Araba Temiz", AdvertNo="A125", Price=2500, AdvertDate="22/06/2023",Kilometer=10000,ModelYear=2015,FuelType="Benzin",GearType="Düz Vites",StatusID=1,ModelID=1,Username="sercankurban",CityID=34,Phone="5397727025"},
                new Advert(){BrandID=3, Description="Araba Temiz Kazasız", AdvertNo="A150", Price=2500, AdvertDate="20/06/2023",Kilometer=5000,ModelYear=2020,FuelType="LGO",GearType="Düz Vites",StatusID=2,ModelID=4,Username="ahmetkaraca",CityID=6,Phone="5554443322"},
            };

            foreach (var item in advert)
            {
                context.Adverts.Add(item);
            }
            context.SaveChanges();

            var picture = new List<Picture>()
            {
                new Picture(){PictureName="bmw520.jpg", AdvertID=1},
                new Picture(){PictureName="bmw520-2.jpg", AdvertID=1},
                new Picture(){PictureName="mercedesa180.jpg", AdvertID=2}
            };

            foreach (var item in picture)
            {
                context.Pictures.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}