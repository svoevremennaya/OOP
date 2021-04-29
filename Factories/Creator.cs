using Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    public abstract class Creator : ITechnicCreator
    {
        public string Img { get; set; }
        public abstract ITechnic FactoryMethod(Object[] args);
    }
}