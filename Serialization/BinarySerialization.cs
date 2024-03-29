﻿using Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows;
using System.Xml;

namespace lab_2
{
    public class BinarySerialization
    {
        public void Serialize(List<ITechnic> technics)
        {
            NetDataContractSerializer serializer = new NetDataContractSerializer();
            FileStream fileStream = new FileStream("Technic.dat", FileMode.Create);

            using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(fileStream))
            {
                serializer.WriteObject(writer, technics);
            }
            fileStream.Close();
        }

        public List<ITechnic> Deserialize()
        {
            List<ITechnic> technics = new List<ITechnic>();
            NetDataContractSerializer serializer = new NetDataContractSerializer();
            FileStream fileStream = new FileStream("Technic.dat", FileMode.Open);

            try
            {
                using (XmlDictionaryReader reader = XmlDictionaryReader.CreateBinaryReader(fileStream, XmlDictionaryReaderQuotas.Max))
                {
                    technics = (List<ITechnic>)serializer.ReadObject(reader);
                }
            }
            catch
            {
                MessageBox.Show("Deserialization error");
            }

            fileStream.Close();
            return technics;
        }
    }
}
