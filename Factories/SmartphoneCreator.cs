    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace lab_2.Factories
    {
        class SmartphoneCreator : Creator
        {
            public SmartphoneCreator()
            {
                Img = "smartphone.png";
            }

            public override Technic FactoryMethod(Object[] args)
            {
                return new Smartphone(Convert.ToInt32(args[0]), (string)args[1], Convert.ToInt32(args[2]), (string)args[3], Convert.ToInt32(args[4]), (string)args[5], (string)args[6]);
            }
        }
    }
