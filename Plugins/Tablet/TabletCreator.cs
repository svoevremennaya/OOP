using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tablet
{
    class TabletCreator : ITechnicCreator
    {
        public string Img { get; set; }

        public TabletCreator()
        {
            Img = "tablet.jpg";
        }

        public ITechnic FactoryMethod(Object[] args)
        {
            return new Tablet(Convert.ToInt32(args[0]), (string)args[1], Convert.ToInt32(args[2]), (string)args[3], Convert.ToInt32(args[4]), (string)args[5]);
        }
    }
}
