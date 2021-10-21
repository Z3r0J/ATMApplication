using System;

namespace ATMApplication
{
    public class ModeEfficient : ModelClass, IMethodMode
    {
        public void Withdraw()
        {
            try
            {
                Money = 0;
                UnityHundred = 0;
                UnityTwoHundred = 0;
                UnityFiveHundred = 0;
                UnityThousand = 0;
                Total = 0;

                Console.WriteLine("Insert the amount to withdraw: ");
                Money = Convert.ToInt32(Console.ReadLine());
                if (Money < 100)
                {
                    Console.WriteLine("No se puede retirar esta cantidad.");
                }
                else
                {

                    Total = Convert.ToDouble(Money) / 1000;
                    if (Total.ToString().Contains('.'))
                    {
                        string[] divideMoney = Total.ToString().Split('.');
                        UnityThousand = Convert.ToInt32(divideMoney[0]);
                        Unity = Convert.ToInt32(divideMoney[1]);
                        string total = Unity.ToString().PadRight(3, '0');
                        Total = Convert.ToDouble(total) / 500;
                        if (Total == 1)
                        {
                            UnityFiveHundred = Convert.ToInt32(Total);
                            Console.WriteLine(MensajeFinal());
                            SeguirRetirando();
                        }
                        else
                        {
                            if (divideMoney[1].Length > 1)
                            {
                                Console.WriteLine("No puede insertar esta cantidad.");
                            }
                            else
                            {

                                if (Total.ToString().Contains('.'))
                                {
                                    divideMoney = Total.ToString().Split('.');
                                    UnityFiveHundred = Convert.ToInt32(divideMoney[0]);
                                    Unity = Convert.ToInt32(divideMoney[1]);
                                    total = Unity.ToString().PadRight(3, '0');
                                    Total = Convert.ToDouble(total) / 200;
                                    if (Total % 2 == 1)
                                    {
                                        total = Total.ToString().PadRight(3, '0');
                                        Total = Convert.ToDouble(total) / 200;

                                        if (Total.ToString().Contains('.'))
                                        {
                                            divideMoney = Total.ToString().Split('.');
                                            UnityTwoHundred = Convert.ToInt32(divideMoney[0]);
                                            UnityHundred = Convert.ToInt32(divideMoney[1]) % 2;
                                            Console.WriteLine(MensajeFinal());
                                            SeguirRetirando();
                                        }
                                    }
                                    else
                                    {
                                        total = Unity.ToString().PadRight(3, '0');
                                        Total = Convert.ToDouble(total) / 200;
                                        UnityTwoHundred = Convert.ToInt32(Total);
                                        Console.WriteLine(MensajeFinal());
                                        SeguirRetirando();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        UnityThousand = Convert.ToInt32(Total);
                        Console.WriteLine(MensajeFinal());
                        SeguirRetirando();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Ingrese una opcion valida.");
                Console.ReadKey();
                Repositorio.instacia.menu.PrintMenu();
            }
        }

        public string MensajeFinal()
        {

            string message = "";

            if (UnityThousand != 0 && UnityFiveHundred != 0 && UnityTwoHundred != 0 && UnityHundred != 0)
            {
                message = $"El cajero dio {UnityThousand} de 1000, {UnityFiveHundred} de 500, {UnityTwoHundred} de 200, {UnityHundred} de 100";
            }
            else if (UnityThousand != 0 && UnityFiveHundred != 0 && UnityTwoHundred != 0 && UnityHundred == 0)
            {
                message = $"El cajero dio {UnityThousand} de 1000, {UnityFiveHundred} de 500, {UnityTwoHundred / 2} de 200";
            }
            else if (UnityThousand != 0 && UnityFiveHundred != 0 && UnityTwoHundred == 0 && UnityHundred != 0)
            {
                message = $"El cajero dio {UnityThousand} de 1000, {UnityFiveHundred} de 500 y {UnityHundred} de 100";
            }
            else if (UnityThousand != 0 && UnityTwoHundred != 0 && UnityHundred != 0 && UnityFiveHundred == 0)
            {
                message = $"El cajero dio {UnityThousand} de 1000, {UnityTwoHundred} de 200, {UnityHundred} de 100";

            }
            else if (UnityThousand != 0 && UnityFiveHundred != 0 && UnityTwoHundred == 0 && UnityHundred == 0)
            {
                message = $"El cajero dio {UnityThousand} de 1000, {UnityFiveHundred} de 500";
            }
            else if (UnityThousand != 0 && UnityFiveHundred == 0 && UnityTwoHundred != 0 && UnityHundred == 0)
            {
                message = $"El cajero dio {UnityThousand} de 1000, {UnityTwoHundred / 2} de 200";
            }
            else if (UnityThousand != 0 && UnityFiveHundred == 0 && UnityTwoHundred == 0 && UnityHundred !=0)
            {
                message = $"El cajero dio {UnityThousand} de 1000, {UnityHundred} de 100";
            }
            else if (UnityFiveHundred != 0 && UnityTwoHundred != 0 && UnityThousand == 0 && UnityHundred == 0)
            {
                message = $"El cajero dio {UnityFiveHundred} de 500, {UnityTwoHundred / 2} de 200";
            }
            else if (UnityFiveHundred != 0 && UnityTwoHundred != 0 && UnityThousand == 0 && UnityHundred != 0)
            {
                message = $"El cajero dio {UnityFiveHundred} de 500, {UnityTwoHundred} de 200 y {UnityHundred} de 100";
            }
            else if (UnityFiveHundred != 0 && UnityTwoHundred == 0 && UnityThousand == 0 && UnityHundred != 0)
            {
                message = $"El cajero dio {UnityFiveHundred} de 500, {UnityHundred} de 100";
            }
            else if (UnityFiveHundred == 0 && UnityTwoHundred != 0 && UnityThousand == 0 && UnityHundred != 0)
            {
                message = $"El cajero dio {UnityTwoHundred} de 200 y {UnityHundred} de 100";
            }
            else if (UnityFiveHundred != 0 && UnityTwoHundred == 0 && UnityThousand == 0 && UnityHundred == 0)
            {
                message = $"El cajero dio {UnityFiveHundred} de 500";
            }
            else if (UnityFiveHundred == 0 && UnityTwoHundred != 0 && UnityThousand == 0 && UnityHundred == 0)
            {
                message = $"El cajero dio {UnityTwoHundred/2} de 200";
            }
            else if(UnityFiveHundred == 0 && UnityTwoHundred == 0 && UnityThousand == 0 && UnityHundred != 0)
            {
                message = $"El cajero dio {UnityHundred} de 100";
            }
            else if (UnityFiveHundred == 0 && UnityTwoHundred == 0 && UnityThousand != 0 && UnityHundred == 0)
            {
                message = $"El cajero dio {UnityThousand} de 1000";
            }
            return message;
        }

        public void SeguirRetirando()
        {
            Console.WriteLine("¿Quieres seguir retirando? (S/N)");
            char answer = Convert.ToChar(Console.ReadLine());
            if (answer == 's' || answer == 'S')
            {

                Withdraw();
            }
            else
            {
                Console.WriteLine("Presiona Enter para continuar.");
                Console.ReadKey();
                Console.Clear();
                Repositorio.instacia.menu.PrintMenu();
            }
        }
    }
}
