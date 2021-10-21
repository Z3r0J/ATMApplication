using System;

namespace ATMApplication
{
    public class ModeEfficient : ModelClass, IMethodMode
    {
        ModelClass model = new ModelClass();
        MetodosRetiros metodosRetiros = new MetodosRetiros();
        public void Withdraw()
        {
            try
            {
                model.Mode = 1;

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
                        model.UnityThousand = UnityThousand;
                        Unity = Convert.ToInt32(divideMoney[1]);
                        string total = Unity.ToString().PadRight(3, '0');
                        Total = Convert.ToDouble(total) / 500;
                        if (Total == 1)
                        {
                            UnityFiveHundred = Convert.ToInt32(Total);
                            model.UnityFiveHundred = UnityFiveHundred;
                            Console.WriteLine(metodosRetiros.MensajeFinal(model));
                            metodosRetiros.SeguirRetirando();
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
                                    model.UnityFiveHundred = UnityFiveHundred;
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
                                            model.UnityTwoHundred = UnityTwoHundred;
                                            UnityHundred = Convert.ToInt32(divideMoney[1]) % 2;
                                            model.UnityHundred = UnityHundred;
                                            Console.WriteLine(metodosRetiros.MensajeFinal(model));
                                            metodosRetiros.SeguirRetirando();
                                        }
                                    }
                                    else
                                    {
                                        total = Unity.ToString().PadRight(3, '0');
                                        Total = Convert.ToDouble(total) / 200;
                                        UnityTwoHundred = Convert.ToInt32(Total);
                                        model.UnityTwoHundred = UnityTwoHundred;
                                        Console.WriteLine(metodosRetiros.MensajeFinal(model));
                                        metodosRetiros.SeguirRetirando();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        UnityThousand = Convert.ToInt32(Total);
                        model.UnityThousand = UnityThousand;
                        Console.WriteLine(metodosRetiros.MensajeFinal(model));
                        metodosRetiros.SeguirRetirando();
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
    }
}
