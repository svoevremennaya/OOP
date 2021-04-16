using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Factories
{
    class LaptopCreator : Creator
    {
        public LaptopCreator()
        {
            Img = "laptop.jpg";
        }

        public override Technic FactoryMethod(Object[] args)
        {
            return new Laptop(Convert.ToInt32(args[0]), (string)args[1], Convert.ToInt32(args[2]), (string)args[3], Convert.ToInt32(args[4]), (bool)args[5]);
        }
    }
}
