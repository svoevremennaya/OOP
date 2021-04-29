using Interfaces;
using System;

namespace lab_2.Factories
{
    class ButtonPhoneCreator : Creator
    {
        public ButtonPhoneCreator()
        {
            Img = "button_phone.jpg";
        }

        public override ITechnic FactoryMethod(Object[] args)
        {
            return new ButtonPhone(Convert.ToInt32(args[0]), (string)args[1], Convert.ToInt32(args[2]), (string)args[3], Convert.ToInt32(args[4]), (string)args[5], (bool)args[6]);
        }
    }
}
