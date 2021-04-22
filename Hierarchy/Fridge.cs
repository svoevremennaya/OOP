using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace lab_2
{
    [DataContract]
    public class Fridge : Technic
    {
        [DataMember] private int useful_volume;
        [DataMember] private int num_compressor;

        public Fridge()
        {
            useful_volume = 0;
            num_compressor = 0;
        }

        public Fridge(int year, string model, int num, int vol, int compr) : base(year, model, num)
        {
            useful_volume = vol;
            num_compressor = compr;
        }

        public int Useful_volume
        {
            get { return useful_volume; }
            set { useful_volume = value; }
        }

        public int Num_compressor
        { 
            get { return num_compressor; }
            set { num_compressor = value; }
        }

        public override string PrintInfo()
        {
            /*Console.WriteLine($"Year of production: {Year_production}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Useful volume: {useful_volume}");
            Console.WriteLine($"Number of compressors: {num_compressor}\n");*/

            return $"Fridge\nYear of production: {Year_production};\nBrand: {Brand};\nPrice: {Price};\nUseful volume: {Useful_volume};\n" +
                $"Number of compressors: {Num_compressor}";
        }

        public void PrintHieararchy()
        {
            Console.WriteLine("Technic (base class) -> Fridge");
        }

        public override Object[] GetFields()
        {
            Object[] obj = new object[5];
            obj[0] = Year_production;
            obj[1] = Brand;
            obj[2] = Price;
            obj[3] = Useful_volume;
            obj[4] = Num_compressor;
            return obj;
        }

        public override void FillFields(Object[] args)
        {
            Year_production = Convert.ToInt32(args[0]);
            Brand = (string)args[1];
            Price = Convert.ToInt32(args[2]);
            Useful_volume = Convert.ToInt32(args[3]);
            Num_compressor = Convert.ToInt32(args[4]);
        }
    }
}
