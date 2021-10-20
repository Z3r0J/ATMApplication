using System;

namespace ATMApplication
{
    public class DispensingModeMenu
    {
        public void DispensingMenu()
        {
            ModelClass model = new ModelClass();
           
            try
            {
                Console.WriteLine("1 - 200 & 1000\n" +
               "2 - 100 & 500\n" +
               "3 - Efficient Mode (Defect Mode) 100 , 200 , 500 , 1000");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
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
                    case (int)ModeDispensing.EfficientMode:
                        model.Mode = 1;
                        Repositorio.instacia.mode = model.Mode;
                        Repositorio.instacia.menu.PrintMenu();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
