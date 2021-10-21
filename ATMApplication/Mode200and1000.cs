using System;
using System.Runtime;
namespace ATMApplication
{
    public class Mode200and1000: ModelClass,IMethodMode
    {
        ModelClass model = new ModelClass();
        MethodWithDraw methodWithDraw = new MethodWithDraw();
        public void Withdraw()
        {
            try
            {
                model.Mode = 2;
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
                    model.UnityThousand = UnityThousand;
                    Console.WriteLine(methodWithDraw.MensajeFinal(model));
                    methodWithDraw.SeguirRetirando();

                }
                if (UnityTwoHundred.ToString().Length > 1)
                {
                    Console.WriteLine("Solo se admiten papeletas de 1000 y 200");
                    Console.ReadKey();
                    Repositorio.instacia.menu.PrintMenu();
                }
                else
                {

                    if (UnityThousand > 0 && UnityTwoHundred == 0)
                    {
                        model.UnityThousand = UnityThousand;
                        model.UnityTwoHundred = UnityTwoHundred;
                        Console.WriteLine(methodWithDraw.MensajeFinal(model));
                        methodWithDraw.SeguirRetirando();
                    }

                    else if (UnityTwoHundred % 2 == 0 && UnityThousand > 0)
                    {
                        model.UnityThousand = UnityThousand;
                        model.UnityTwoHundred = UnityTwoHundred;
                        Console.WriteLine(methodWithDraw.MensajeFinal(model));
                        methodWithDraw.SeguirRetirando();
                    }

                    else if (UnityThousand == 0 && UnityTwoHundred % 2 == 0)
                    {
                        model.UnityThousand = UnityThousand;
                        model.UnityTwoHundred = UnityTwoHundred;
                        Console.WriteLine(methodWithDraw.MensajeFinal(model));
                        methodWithDraw.SeguirRetirando();
                    }
                    else
                    {
                        Console.WriteLine("No se puede dar de esta cantidad solo papeleta de 200 y 1000");
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
