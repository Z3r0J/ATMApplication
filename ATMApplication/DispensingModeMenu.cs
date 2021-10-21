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
                Console.WriteLine("1 - Efficient Mode (Defect Mode) 100 , 200 , 500 , 1000\n" +
               "2 - 200 & 1000\n" +
               "3 - 100 & 500");
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

                throw;
            }

        }
    }
}
