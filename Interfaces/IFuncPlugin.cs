using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IFuncPlugin
    {
        string Algorithm { get; set; }

        void Encrypt(string fileName);
        void Decrypt(string fileName);
    }
}
