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
               "3 - Efficient Mode (Defect Mode) 100 , 200 , 500 , 1000\n");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case (int)ModeDispensing.EfficientMode:
                        model.Mode = 1;
                        Repositorio.instacia.mode = model.Mode;
                        Repositorio.instacia.menu.PrintMenu();
                        break;
                    case (int)ModeDispensing.TwoHundredandOneThousand:
                        model.Mode = 2;
                        Repositorio.instacia.mode = model.Mode;
                        Repositorio.instacia.menu.PrintMenu();

                        break;
                    case (int)ModeDispensing.OneHundredandFiveHundred:
                        model.Mode = 3;
                        Repositorio.instacia.mode = model.Mode;
                        Repositorio.instacia.menu.PrintMenu();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Inserta una opcion valida.");
                Console.ReadKey();
                Console.Clear();
                PrintMenu();
            }

        }
    }
}
