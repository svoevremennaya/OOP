using Interfaces;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Windows;
using System.Xml;

namespace RSA
{
    public class RSA : IFuncPlugin
    {
        public string Algorithm { get; set; }

        public RSA()
        {
            Algorithm = "RSA";
        }

        public void Encrypt(string fileName)
        {
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
            RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

            string KeyName = "1";
            string ElementToEncrypt = "anyType";

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(fileName);
            }
            catch
            {
                MessageBox.Show("Error opening file");
            }

            while (xmlDoc.GetElementsByTagName(ElementToEncrypt).Count > 0)
            {
                XmlElement elementToEncrypt = xmlDoc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;
                if (elementToEncrypt == null)
                {
                    throw new XmlException("The specified element was not found");
                }

                Aes sessionKey = Aes.Create();
                sessionKey.KeySize = 256;

                EncryptedXml eXml = new EncryptedXml();
                byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);

                EncryptedData edElement = new EncryptedData();
                edElement.Type = EncryptedXml.XmlEncElementUrl;
                edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);

                EncryptedKey ek = new EncryptedKey();
                byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, rsaKey, false);
                ek.CipherData = new CipherData(encryptedKey);
                ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);

                edElement.KeyInfo = new KeyInfo();
                KeyInfoName kin = new KeyInfoName();

                kin.Value = KeyName;
                ek.KeyInfo.AddClause(kin);
                edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));

                edElement.CipherData.CipherValue = encryptedElement;
                EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
            }
            xmlDoc.Save(fileName);
        }

        public void Decrypt(string fileName)
        {
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
            RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

            string KeyName = "1";

            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(fileName);
            }
            catch
            {
                MessageBox.Show("Error opening file");
            }

            EncryptedXml exml = new EncryptedXml(xmlDoc);
            exml.AddKeyNameMapping(KeyName, rsaKey);
            exml.DecryptDocument();
            xmlDoc.Save(fileName);
        }
    }
}
