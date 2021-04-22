using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace lab_2
{
    [DataContract]
    public abstract class Mobile_phones : Computers
    {
        [DataMember] private string sim_card;

        public Mobile_phones()
        {
            sim_card = "";
        }

        public Mobile_phones(int year, string brand, int num, string proc, int mem, string sim) : base(year, brand, num, proc, mem)
        {
            sim_card = sim;
        }

        public string Sim_card
        {
            get { return sim_card; }
            set { sim_card = value; }
        }

        public abstract override string PrintInfo();

        public abstract override Object[] GetFields();

        public abstract override void FillFields(Object[] args);
    }
}
