using System;

namespace ATMApplication
{
    public class DispensingModeMenu
    {
        public void DispensingMenu()
        {
            try
            {
                Console.WriteLine(" 1 - 200 & 100\n" +
               "2 - 100 & 500\n" +
               "3 - Efficient Mode (Defect Mode) 100 , 200 , 500 , 1000");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case (int)ModeDispensing.TwoHundredandOneThousand:
                        break;
                    case (int)ModeDispensing.OneHundredandFiveHundred:
                        break;
                    case (int)ModeDispensing.EfficientMode:
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
