using System;

namespace ATMApplication
{
    public class PrincipalMenu
    {
        public void PrintMenu()
        {
            try
            {

                DispensingModeMenu modeMenu = new DispensingModeMenu();
                ModelClass model = new ModelClass(Repositorio.instacia.mode);
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" _______  _______  _______  ____          _______  _______  _   ___  ___     ");
                Console.WriteLine("|       ||  _    ||       ||    |        |  _    ||       || | |   ||   |    \n" +
                                "|____   || | |   ||____   | |   |  ____  | | |   ||   ____|| |_|   ||   |___ \n" +
                                " ____|  || | |   | ____|  | |   | |____| | | |   ||  |____ |       ||    _  |\n" +
                                "| ______|| |_|   || ______| |   |        | |_|   ||_____  ||___    ||   | | |\n" +
                                "| |_____ |       || |_____  |   |        |       | _____| |    |   ||   |_| |\n" +
                                "|_______||_______||_______| |___|        |_______||_______|    |___||_______|\n" +
                                "                                                                             \n");
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("                      Jean Carlos Reyes Encarnación                          \n");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("1 - Dispense Mode\n" + "2 - Withdraw Money\n" + "3 - Exit");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case (int)InitialMenu.Mode:
                        modeMenu.PrintMenu();
                        break;
                    case (int)InitialMenu.Withdraw:
                        model.ModeDispensing(model);
                        break;
                    case (int)InitialMenu.Exit:
                        Console.WriteLine("Thanks for using The ATM Application");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please Insert a valid option.");
                        Console.ReadKey();
                        PrintMenu();
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Please Insert a valid option.");
                Console.ReadKey();
                PrintMenu();
            }

        }
    }
}
