using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITechnicCreator
    {
        string Img { get; set; }

        ITechnic FactoryMethod(Object[] args);
    }
}
