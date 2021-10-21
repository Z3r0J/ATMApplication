using System;
using System.Runtime;
namespace ATMApplication
{
    public class Mode200and1000: ModelClass,IMethodMode
    {
        public void Withdraw()
        {
            try
            {
                Console.WriteLine("Insert the amount to Withdraw");
                Money = Convert.ToInt32(Console.ReadLine());

                if (Money < 200)
                {
                    Console.Write("Actualmente no aceptamos esta cantidad");
                    Console.ReadKey();
                    Repositorio.instacia.menu.PrintMenu();
                }


                Total = Convert.ToDouble(Money) / 1000;
                if (Total.ToString().Contains('.'))
                {
                    string[] divideMoney = Total.ToString().Split('.');
                    UnityThousand = Convert.ToInt32(divideMoney[0]);
                    UnityTwoHundred = Convert.ToInt32(divideMoney[1]);
                }
                else
                {
                    UnityThousand = Convert.ToInt32(Total);
                    UnityTwoHundred = 0;
                }

                if (UnityThousand > 0 && UnityTwoHundred == 0)
                {
                    Console.WriteLine($"Se te dio {UnityThousand} papeleta de 1000");
                    Console.WriteLine("¿Quieres seguir retirando? (S/N)");
                    char answer = Convert.ToChar(Console.ReadLine());
                    if (answer == 'S' || answer == 's')
                    {
                        Withdraw();
                    }
                    else
                    {
                        Console.Clear();
                        Repositorio.instacia.menu.PrintMenu();
                    }
                }

                else if (UnityTwoHundred % 2 == 0 && UnityThousand > 0)
                {
                    Console.WriteLine($"Se te dio {UnityThousand} papeleta de 1000 y {UnityTwoHundred / 2} papeleta de 200 ");
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

                else if (UnityThousand == 0 && UnityTwoHundred % 2 == 0)
                {
                    Console.WriteLine($"Se te dio {UnityTwoHundred / 2} papeleta de 200 ");
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
                    Console.WriteLine("No se puede dar de esta cantidad solo papeleta de 200 y 1000");
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
