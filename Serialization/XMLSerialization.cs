﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace lab_2
{
    class XMLSerialization
    {      
        public void Serialize(List<Technic> technics)
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

        public List<Technic> Deserialize()
        {
            List<Technic> technics = new List<Technic>();
            NetDataContractSerializer serializer = new NetDataContractSerializer();
            FileStream fileStream = new FileStream("Technic.xml", FileMode.Open);
            using (XmlReader reader = XmlReader.Create(fileStream))
            {
                technics = (List<Technic>)serializer.ReadObject(reader);
            }
            fileStream.Close();
            return technics;
        }
    }
}
