using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2.Factories
{
    class ButtonPhoneCreator : Creator
    {
        public ButtonPhoneCreator()
        {
            Img = "button_phone.jpg";
        }

        public override Technic FactoryMethod(Object[] args)
        {
            return new Button_phone(Convert.ToInt32(args[0]), (string)args[1], Convert.ToInt32(args[2]), (string)args[3], Convert.ToInt32(args[4]), (string)args[5], (bool)args[6]);
        }
    }
}
