using System;
using System.Collections.Generic;
using System.Text;

namespace ATMApplication
{
    public class Mode500and100 : ModelClass, IMethodMode
    {
        public void Withdraw()
        {
            try
            {
                Console.WriteLine("Insert the amount to Withdraw");
                Money = Convert.ToInt32(Console.ReadLine());

                if (Money < 100)
                {
                    Console.Write("Solo aceptamos retiro de papeleta de 100 en adelante");
                    Console.ReadKey();
                    Repositorio.instacia.menu.PrintMenu();
                }


                Total = Convert.ToDouble(Money) / 500;
                if (Total.ToString().Contains('.'))
                {
                    string[] divideMoney = Total.ToString().Split('.');
                    UnityFiveHundred = Convert.ToInt32(divideMoney[0]);
                    UnityHundred = Convert.ToInt32(divideMoney[1]);
                }
                else
                {
                    UnityFiveHundred = Convert.ToInt32(Total);
                    UnityHundred = 0;
                }

                if (UnityFiveHundred > 0 && UnityHundred == 0)
                {
                    Console.WriteLine($"Se te dio {UnityFiveHundred} papeleta de 500");
                    Console.WriteLine("¿Quieres seguir retirando? (S/N)");
                    char answer = Convert.ToChar(Console.ReadLine());
                    if (answer == 'S' || answer == 's')
                    {
                        Withdraw();
                    }
                    else
                    {
                        Console.WriteLine("Presiona Enter para volver atras.");
                        Console.ReadKey();
                        Console.Clear();
                        Repositorio.instacia.menu.PrintMenu();
                    }
                }

                else if (UnityHundred % 2 == 0 && UnityFiveHundred > 0)
                {
                    Console.WriteLine($"Se te dio {UnityFiveHundred} papeleta de 500 y {UnityHundred / 2} papeleta de 100 ");
                    Console.WriteLine("¿Quieres seguir retirando? (S/N)");
                    char answer = Convert.ToChar(Console.ReadLine());
                    if (answer == 'S')
                    {
                        Withdraw();
                    }
                    else
                    {
                        Console.Clear();
                        Repositorio.instacia.menu.PrintMenu();
                    }
                }

                else if (UnityFiveHundred == 0 && UnityHundred % 2 == 0)
                {
                    Console.WriteLine($"Se te dio {UnityHundred / 2} papeleta de 100 ");
                    Console.WriteLine("¿Quieres seguir retirando? (S/N)");
                    char answer = Convert.ToChar(Console.ReadLine());
                    if (answer == 's' || answer == 'S')
                    {
                        Withdraw();
                    }
                    else
                    {
                        Console.Clear();
                        Repositorio.instacia.menu.PrintMenu();
                    }
                }
                else
                {
                    Console.WriteLine("No se puede dar de esta cantidad solo papeleta de 500 y 100");
                    Console.ReadKey();
                    Repositorio.instacia.menu.PrintMenu();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Inserta una opcion valida");
                Console.Clear();
                Repositorio.instacia.menu.PrintMenu();
            }
        }
    }
}
