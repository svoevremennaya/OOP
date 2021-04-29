using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ITechnic
    {
        int Year_production { get; set; }
        string Brand { get; set; }
        int Price { get; set; }

        string PrintInfo();
        Object[] GetFields();
        void FillFields(Object[] args);
    }
}
