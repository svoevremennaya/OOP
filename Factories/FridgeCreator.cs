using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Factories
{
    class FridgeCreator : Creator
    {
        public FridgeCreator()
        {
            Img = "fridge.jpeg";
        }

        public override Technic FactoryMethod(Object[] args)
        {
            return new Fridge(Convert.ToInt32(args[0]), (string)args[1], Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), Convert.ToInt32(args[4]));
        }
    }
}
