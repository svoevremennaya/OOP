using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace lab_2
{
    [DataContract]
    public class Smartphone : Mobile_phones
    {
        [DataMember] private string screen_type;

        public Smartphone()
        {
            screen_type = "";
        }

        public Smartphone(int year, string model, int num, string proc, int mem, string sim, string screen) : base(year, model, num, proc, mem, sim)
        {
            screen_type = screen;
        }

        public string Screen_type
        {
            get { return screen_type; }
            set { screen_type = value; }
        }

        public override string PrintInfo()
        {
            /*Console.WriteLine($"Year of production: {Year_production}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Model of processor: {Processor}");
            Console.WriteLine($"Value of memory: {Memory}");
            Console.WriteLine($"Type of SIM: {Sim_card}");
            Console.WriteLine($"Type of screen: {Screen_type}\n");*/

            return $"Smartphone\nYear of production: {Year_production};\nBrand: {Brand};\nPrice: {Price};\nProcessor: {Processor};\nMemory: {Memory};\n" +
                $"Sim card: {Sim_card};\nScreen type: {Screen_type}";
        }

        public void PrintHieararchy()
        {
            Console.WriteLine("Technic (base class) -> Computers -> Mobile_phones -> Smartphone");
        }

        public override Object[] GetFields()
        {
            Object[] obj = new object[7];
            obj[0] = Year_production;
            obj[1] = Brand;
            obj[2] = Price;
            obj[3] = Processor;
            obj[4] = Memory;
            obj[5] = Sim_card;
            obj[6] = Screen_type;
            return obj;
        }

        public override void FillFields(Object[] args)
        {
            Year_production = Convert.ToInt32(args[0]);
            Brand = (string)args[1];
            Price = Convert.ToInt32(args[2]);
            Processor = (string)args[3];
            Memory = Convert.ToInt32(args[4]);
            Sim_card = (string)args[5];
            Screen_type = (string)args[6];
        }
    }
}
