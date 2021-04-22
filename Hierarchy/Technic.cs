using System;
using System.Runtime.Serialization;

namespace lab_2
{
    [DataContract]
    public abstract class Technic
    {
        [DataMember] private int year_production;
        [DataMember] private string brand;
        [DataMember] private int price;

        public Technic()
        {
            year_production = 0;
            brand = "";
            price = 0;
        }

        public Technic(int year, string model, int num)
        {
            year_production = year;
            brand = model;
            price = num;
        }

        public int Year_production
        {
            get { return year_production; }
            set { year_production = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public abstract string PrintInfo();

        public abstract Object[] GetFields();

        public abstract void FillFields(Object[] args);
    }
}
