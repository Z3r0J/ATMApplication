using System;
using System.Collections.Generic;
using System.Text;

namespace ATMApplication
{
    public class Mode500and100 : ModelClass, IMethodMode
    {
        ModelClass model = new ModelClass();
        MetodosRetiros metodosRetiros = new MetodosRetiros();
        public void Withdraw()
        {
            try
            {
                model.Mode = 3;
                Console.WriteLine("Insert the amount to Withdraw");
                Money = Convert.ToInt32(Console.ReadLine());

                if (Money < 100)
                {
                    Console.Write("Solo aceptamos retiro de papeleta de 100 y de 500");
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
                if (UnityHundred%2==1 || UnityHundred.ToString().Length > 1)
                {
                    Console.WriteLine("Solo se admiten papeletas de 100 y 500");
                    Console.ReadKey();
                    Repositorio.instacia.menu.PrintMenu();
                }
                else {

                    if (UnityFiveHundred > 0 && UnityHundred == 0)
                    {
                        model.UnityFiveHundred = UnityFiveHundred;
                        model.UnityHundred = UnityHundred/2;
                        Console.WriteLine(metodosRetiros.MensajeFinal(model));
                        metodosRetiros.SeguirRetirando();
                    }

                    else if (UnityHundred % 2 == 0 && UnityFiveHundred > 0)
                    {
                        model.UnityFiveHundred = UnityFiveHundred;
                        model.UnityHundred = UnityHundred/2;
                        Console.WriteLine(metodosRetiros.MensajeFinal(model));
                        metodosRetiros.SeguirRetirando();
                    }

                    else if (UnityFiveHundred == 0 && UnityHundred % 2 == 0)
                    {
                        model.UnityFiveHundred = UnityFiveHundred;
                        model.UnityHundred = UnityHundred/2;
                        Console.WriteLine(metodosRetiros.MensajeFinal(model));
                        metodosRetiros.SeguirRetirando();
                    }
                    else
                    {
                        Console.WriteLine("No se puede dar de esta cantidad solo papeleta de 500 y 100");
                        Console.ReadKey();
                        Repositorio.instacia.menu.PrintMenu();
                    }
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
