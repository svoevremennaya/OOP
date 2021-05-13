using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToJSON
{
    class XMLToJSONAdapter : IFuncPlugin
    {
        public string Algorithm { get; set; }
        public XMLToJSONTransformer.XMLToJSONTransformer transformer = new XMLToJSONTransformer.XMLToJSONTransformer();

        public XMLToJSONAdapter()
        {
            Algorithm = "XMLToJSON";
        }

        public void Encrypt(string objectList)
        {
            transformer.Transform(objectList, "Technic");
        }

        public void Decrypt(string fileName)
        {
            transformer.ReturnState(fileName);
        }
    }
}
