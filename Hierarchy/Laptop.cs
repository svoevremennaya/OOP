using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    [Serializable]
    public class Laptop : Computers
    {
        private bool num_lock;

        public Laptop()
        {
            num_lock = false;
        }

        public Laptop(int year, string model, int num, string proc, int mem, bool n_lock) : base(year, model, num, proc, mem)
        {
            num_lock = n_lock;
        }

        public bool Num_lock
        {
            get { return num_lock; }
            set { num_lock = value; }
        }

        public override string PrintInfo()
        {
            /*Console.WriteLine($"Year of production: {Year_production}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Model of processor: {Processor}");
            Console.WriteLine($"Value of memory: {Memory}");
            if (num_lock)
                Console.WriteLine("There is a num lock on keyboard\n");
            else
                Console.WriteLine("There is not num lock on keyboard\n");*/

            return $"Laptop\nYear of production: {Year_production};\nBrand: {Brand};\nPrice: {Price};\nProcessor: {Processor};\nMemory: {Memory};\n" +
                ((num_lock) ? "With num lock" : "Without num lock");
        }

        public void PrintHieararchy()
        {
            Console.WriteLine("Technic (base class) -> Computers -> Laptop");
        }

        public override Object[] GetFields()
        {
            Object[] obj = new object[6];
            obj[0] = Year_production;
            obj[1] = Brand;
            obj[2] = Price;
            obj[3] = Processor;
            obj[4] = Memory;
            obj[5] = Num_lock;
            return obj;
        }

        public override void FillFields(Object[] args)
        {
            Year_production = Convert.ToInt32(args[0]);
            Brand = (string)args[1];
            Price = Convert.ToInt32(args[2]);
            Processor = (string)args[3];
            Memory = Convert.ToInt32(args[4]);
            Num_lock = (bool)args[5];
        }
    }
}
