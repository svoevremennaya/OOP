using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab_2
{
    public class BinarySerialization
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        public void Serialize(List<Technic> technics)
        {
            using (FileStream fileStream = new FileStream("Technic.dat", FileMode.Create))
            {
                binaryFormatter.Serialize(fileStream, technics);
            }
        }

        public List<Technic> Deserialize()
        {
            List<Technic> technics = new List<Technic>();
            try
            {
                using (FileStream fileStream = new FileStream("Technic.dat", FileMode.Open))
                {
                    technics = (List<Technic>)binaryFormatter.Deserialize(fileStream);
                }
            }
            catch
            {
                MessageBox.Show("Deserialization error");
            }
            return technics;
        }
    }
}
