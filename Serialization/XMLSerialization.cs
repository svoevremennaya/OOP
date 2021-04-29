using Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace lab_2
{
    class XMLSerialization
    {      
        public void Serialize(List<ITechnic> technics)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;

            NetDataContractSerializer serializer = new NetDataContractSerializer();
            FileStream fileStream = new FileStream("Technic.xml", FileMode.Create);
            using (XmlWriter writer = XmlWriter.Create(fileStream, settings))
            {
                serializer.WriteObject(writer, technics);
            }
            fileStream.Close();
        }

        public List<ITechnic> Deserialize()
        {
            List<ITechnic> technics = new List<ITechnic>();
            NetDataContractSerializer serializer = new NetDataContractSerializer();
            FileStream fileStream = new FileStream("Technic.xml", FileMode.Open);
            using (XmlReader reader = XmlReader.Create(fileStream))
            {
                technics = (List<ITechnic>)serializer.ReadObject(reader);
            }
            fileStream.Close();
            return technics;
        }
    }
}
