using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2
{
    [Serializable]
    public abstract class Computers : Technic
    {
        private string processor;
        private int memory;

        public Computers()
        {
            processor = "";
            memory = 0;
        }

        public Computers(int year, string model, int num, string proc, int mem) : base(year, model, num)
        {
            processor = proc;
            memory = mem;
        }

        public string Processor
        {
            get { return processor; }
            set { processor = value; }
        }

        public int Memory
        {
            get { return memory; }
            set { memory = value; }
        }

        public abstract override string PrintInfo();

        public abstract override Object[] GetFields();

        public abstract override void FillFields(Object[] args);
    }
}
