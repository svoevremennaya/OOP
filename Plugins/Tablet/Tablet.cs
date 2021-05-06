using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Tablet
{
    [DataContract]
    public class Tablet : ITechnic
    {
        [DataMember] public int Year_production { get; set; }
        [DataMember] public string Brand { get; set; }
        [DataMember] public int Price { get; set; }
        [DataMember] public string Processor { get; set; }
        [DataMember] public int Memory { get; set; }
        [DataMember] public string Screen_type { get; set; }

        public Tablet(int year, string model, int num, string proc, int mem, string size)
        {
            Year_production = year;
            Brand = model;
            Price = num;
            Processor = proc;
            Memory = mem;
            Screen_type = size;
        }

        public string PrintInfo()
        {
            return $"Tablet\nYear of production: {Year_production};\nBrand: {Brand};\nPrice: {Price};\nProcessor: {Processor};\n" +
                $"Memory: {Memory};\nScreen: {Screen_type}";
        }

        public Object[] GetFields()
        {
            Object[] obj = new object[6];
            obj[0] = Year_production;
            obj[1] = Brand;
            obj[2] = Price;
            obj[3] = Processor;
            obj[4] = Memory;
            obj[5] = Screen_type;
            return obj;
        }

        public void FillFields(Object[] args)
        {
            Year_production = Convert.ToInt32(args[0]);
            Brand = (string)args[1];
            Price = Convert.ToInt32(args[2]);
            Processor = (string)args[3];
            Memory = Convert.ToInt32(args[4]);
            Screen_type = (string)args[5];
        }
    }
}
