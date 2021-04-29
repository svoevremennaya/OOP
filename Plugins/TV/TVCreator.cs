using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV
{
    public class TVCreator : ITechnicCreator
    {
        public string Img { get; set; }

        public TVCreator()
        {
            Img = "tv.jpg";
        }

        public ITechnic FactoryMethod(Object[] args)
        {
            return new TV(Convert.ToInt32(args[0]), (string)args[1], Convert.ToInt32(args[2]), (string)args[3]);
        }
    }
}
