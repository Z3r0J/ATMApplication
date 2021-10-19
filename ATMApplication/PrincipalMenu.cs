using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime;

namespace ATMApplication
{
    public class PrincipalMenu
    {
        DispensingModeMenu modeMenu = new DispensingModeMenu();
        public void PrintMenu()
        {
            Console.WriteLine("1 - Dispense Mode\n"+"2 - Withdraw Money\n" +"3 - Exit");
            Console.Write("> ");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case (int)InitialMenu.Mode:
                    modeMenu.DispensingMenu();
                    break;
                case (int)InitialMenu.Withdraw:
                    break;
                case (int)InitialMenu.Exit:
                    break;
                default:
                    break;
            }


        }
    }
}
