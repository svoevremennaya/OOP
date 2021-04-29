using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TV
{
    [DataContract]
    public class TV : ITechnic
    {
        [DataMember] public int Year_production { get; set; }
        [DataMember] public string Brand { get; set; }
        [DataMember] public int Price { get; set; }
        [DataMember] public string Screen_type { get; set; }

        public TV(int year, string model, int num, string size)
        {
            Year_production = year;
            Brand = model;
            Price = num;
            Screen_type = size;
        }

        public string PrintInfo()
        {
            return $"TV\nYear of production: {Year_production};\nBrand: {Brand};\nPrice: {Price};\nDiagonal: {Screen_type}";
        }

        public Object[] GetFields()
        {
            Object[] obj = new object[4];
            obj[0] = Year_production;
            obj[1] = Brand;
            obj[2] = Price;
            obj[3] = Screen_type;
            return obj;
        }

        public void FillFields(Object[] args)
        {
            Year_production = Convert.ToInt32(args[0]);
            Brand = (string)args[1];
            Price = Convert.ToInt32(args[2]);
            Screen_type = (string)args[3];
        }
    }
}
