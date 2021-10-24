using System;

namespace ATMApplication
{
    public class DispensingModeMenu
    {
         public void PrintMenu(){
            ModelClass model = new ModelClass();
           
            try
            {
                Console.WriteLine("1 - 200 & 1000\n" +
               "2 - 100 & 500\n" +
               "3 - Efficient Mode (Defect Mode) 100 , 200 , 500 , 1000\n" +
               "4 - Go Back");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case (int)ModeDispensing.TwoHundredandOneThousand:
                        model.Mode = 1;
                        Repositorio.instacia.mode = model.Mode;
                        Console.WriteLine("Mode 200 & 1000\nPlease press enter to continue...");
                        Console.ReadKey();
                        Repositorio.instacia.menu.PrintMenu();
                        break;
                    case (int)ModeDispensing.OneHundredandFiveHundred:
                        model.Mode = 2;
                        Console.WriteLine("Mode 100 & 500\nPlease press enter to continue...");
                        Console.ReadKey();
                        Repositorio.instacia.mode = model.Mode;
                        Repositorio.instacia.menu.PrintMenu();

                        break;
                    case (int)ModeDispensing.EfficientMode:
                        model.Mode = 3;
                        Console.WriteLine("Mode Efficient\nPlease press enter to continue...");
                        Console.ReadKey();
                        Repositorio.instacia.mode = model.Mode;
                        Repositorio.instacia.menu.PrintMenu();
                        break;
                    case (int)ModeDispensing.GoBack:
                        Repositorio.instacia.menu.PrintMenu();
                        break;
                    default:
                        Console.WriteLine("Please insert a valid option.");
                        Console.ReadKey();
                        Console.Clear();
                        PrintMenu();
                        break;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Please Insert a valid option.");
                Console.ReadKey();
                Console.Clear();
                PrintMenu();
            }

        }
    }
}
