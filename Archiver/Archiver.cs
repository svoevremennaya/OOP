using Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Archiver
{
    public class Archiver : IFuncPlugin
    {
        public string Algorithm { get; set; }

        public Archiver()
        {
            Algorithm = "Archiver";
        }

        public void Encrypt(string fileName)
        { 
            byte[] buf = File.ReadAllBytes(fileName);
            ArchiverPlugin.Archiver archiver = new ArchiverPlugin.Archiver();
            byte[] data = archiver.Form(buf);
            File.WriteAllBytes("Archive.arc", data);
        }

        public void Decrypt(string fileName)
        {
            byte[] buf = File.ReadAllBytes("Archive.arc");
            ArchiverPlugin.Archiver archiver = new ArchiverPlugin.Archiver();
            byte[] data = archiver.Deform(buf);
            File.WriteAllBytes(fileName, data);
        }
    }
}
