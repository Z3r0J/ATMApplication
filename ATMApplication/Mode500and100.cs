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
                    Console.Write("Actualmente no aceptamos esta cantidad");
                    Console.ReadKey();
                    Repositorio.instacia.menu.PrintMenu();
                }


                Total = Convert.ToDouble(Money) / 500;
                if (Total.ToString().Contains('.'))
                {
                    string[] divideMoney = Total.ToString().Split('.');
                    UnityMil = Convert.ToInt32(divideMoney[0]);
                    UnityCentena = Convert.ToInt32(divideMoney[1]);
                }
                else
                {
                    UnityMil = Convert.ToInt32(Total);
                    UnityCentena = 0;
                }

                if (UnityMil > 0 && UnityCentena == 0)
                {
                    Console.WriteLine($"Se te dio {UnityMil} papeleta de 500");
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

                else if (UnityCentena % 2 == 0 && UnityMil > 0)
                {
                    Console.WriteLine($"Se te dio {UnityMil} papeleta de 500 y {UnityCentena / 2} papeleta de 100 ");
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

                else if (UnityMil == 0 && UnityCentena % 2 == 0)
                {
                    Console.WriteLine($"Se te dio {UnityCentena / 2} papeleta de 100 ");
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
