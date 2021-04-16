using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    public abstract class Creator
    {
        public string Img { get; set; }
        public abstract Technic FactoryMethod(Object[] args);
    }
}