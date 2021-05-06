using Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace AES
{
    public class AesKey
    {
        public byte[] key;
        public byte[] IV;
    }

    public class AES : IFuncPlugin
    {
        public string Algorithm { get; set; }

        public AES()
        {
            Algorithm = "AES";
        }

        public void Encrypt(string fileName)
        {
            AesKey a = new AesKey();
            Aes key = Aes.Create();
            a.key = key.Key;
            a.IV = key.IV;

            string ElementName = "anyType";

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load(fileName);


            while (xmlDoc.GetElementsByTagName(ElementName).Count > 0)
            {
                XmlElement elementToEncrypt = xmlDoc.GetElementsByTagName(ElementName)[0] as XmlElement;

                if (elementToEncrypt == null)
                {
                    throw new XmlException("The specified element was not found");
                }

                EncryptedXml eXml = new EncryptedXml();
                byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, key, false);

                EncryptedData edElement = new EncryptedData();
                edElement.Type = EncryptedXml.XmlEncElementUrl;

                string encryptionMethod = EncryptedXml.XmlEncAES256Url;

                edElement.EncryptionMethod = new EncryptionMethod(encryptionMethod);
                edElement.CipherData.CipherValue = encryptedElement;

                EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
            }
            xmlDoc.Save(fileName);

            XmlSerializer XMLFormatter = new XmlSerializer(typeof(AesKey));
            using (FileStream file = new FileStream("aes_key.key", FileMode.Create))
            {
                XMLFormatter.Serialize(file, a);
            }
        }

        public void Decrypt(string fileName)
        {
            AesKey a = null;
            Aes key = Aes.Create();

            XmlSerializer XMLFormatter = new XmlSerializer(typeof(AesKey));
            using (FileStream file = new FileStream("aes_key.key", FileMode.OpenOrCreate))
            {
                try
                {
                    a = (AesKey)XMLFormatter.Deserialize(file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            key.Key = a.key;
            key.IV = a.IV;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.Load(fileName);

            while (xmlDoc.GetElementsByTagName("EncryptedData").Count > 0)
            {
                XmlElement encryptedElement = xmlDoc.GetElementsByTagName("EncryptedData")[0] as XmlElement;
                if (encryptedElement == null)
                {
                    throw new XmlException("The EncryptedData element was not found.");
                }

                EncryptedData edElement = new EncryptedData();
                edElement.LoadXml(encryptedElement);

                EncryptedXml exml = new EncryptedXml();
                byte[] rgbOutput = exml.DecryptData(edElement, key);
                exml.ReplaceData(encryptedElement, rgbOutput);
            }
            xmlDoc.Save(fileName);
        }
    }
}
