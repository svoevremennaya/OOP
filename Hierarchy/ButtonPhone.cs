using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    [Serializable]
    public class Button_phone : Mobile_phones
    {
        private bool camera;

        public Button_phone()
        {
            camera = false;
        }

        public Button_phone(int year, string model, int num, string proc, int mem, string sim, bool cam) : base(year, model, num, proc, mem, sim)
        {
            camera = cam;
        }

        public bool Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        public override string PrintInfo()
        {
            /*Console.WriteLine($"Year of production: {Year_production}");
            Console.WriteLine($"Brand: {Brand}");
            Console.WriteLine($"Price: {Price}");
            Console.WriteLine($"Model of processor: {Processor}");
            Console.WriteLine($"Value of memory: {Memory}");
            Console.WriteLine($"Type of SIM: {Sim_card}");
            if (camera)
                Console.WriteLine("Have a camera\n");
            else
                Console.WriteLine("Do not have a camera\n");*/

            return $"Button phone\nYear of production: {Year_production};\nBrand: {Brand};\nPrice: {Price};\nProcessor: {Processor};\nMemory: {Memory};\n" +
                $"Sim card: {Sim_card};\n" + ((Camera) ? "With camera" : "Without camera");
        }

        public void PrintHieararchy()
        {
            Console.WriteLine("Technic (base class) -> Computers -> Mobile_phones -> Button_phone");
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
            obj[6] = Camera;
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
            Camera = (bool)args[6];
        }
    }
}
