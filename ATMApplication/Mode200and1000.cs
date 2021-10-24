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
                model.Mode = 1;
                Console.WriteLine("Insert the amount to Withdraw");
                Money = Convert.ToInt32(Console.ReadLine());

                // Validamos si se introdujo una cantidad menor a 200
                if (Money < 200)
                {
                    Console.Write("Solo se acepta papeleta de 200 y 1000");
                    Console.ReadKey();
                    Repositorio.instacia.menu.PrintMenu();
                }


                // Dividimos la cantidad insertada por la denominacion mayor aceptada
                Total = Convert.ToDouble(Money) / 1000;

                // Si es decimal la separamos en 2 cifras, Una cifra para el 1000 en este caso y otra para el 200
                if (Total.ToString().Contains('.'))
                {
                    string[] divideMoney = Total.ToString().Split('.');
                    UnityThousand = Convert.ToInt32(divideMoney[0]);
                    UnityTwoHundred = Convert.ToInt32(divideMoney[1]);
                }

                // Si es un numero entero pues solo sacamos el mensaje diciendo cuanta papeletas de 1000 se otorga
                else
                {
                    UnityThousand = Convert.ToInt32(Total);
                    model.UnityThousand = UnityThousand;
                    Console.WriteLine(methodWithDraw.MensajeFinal(model));
                    methodWithDraw.SeguirRetirando();

                }

                // Aqui Valido si la papeleta de 200 tiene 2 cifras pues no se podra dar esta papeleta ya que debe tener solo 1 cifra.
                // Osea si insertamos 1250  y dividimos en 1000 da 1.25 en vez de 1.2 asi que esto no se admite.

                if (UnityTwoHundred.ToString().Length > 1)
                {
                    Console.WriteLine("Solo se admiten papeletas de 1000 y 200");
                    Console.ReadKey();
                    Repositorio.instacia.menu.PrintMenu();
                }
                else
                {
                    // Aqui validamos Cuantas papeleta de 200 y 1000 tenemos, esto lo hacemos al verificar si el residuo de 200 es 0 y 1000 es mayor que 0
                    if (UnityTwoHundred % 2 == 0 && UnityThousand > 0)
                    {
                        model.UnityThousand = UnityThousand;
                        model.UnityTwoHundred = UnityTwoHundred;
                        Console.WriteLine(methodWithDraw.MensajeFinal(model));
                        methodWithDraw.SeguirRetirando();
                    }

                    // Aqui validamos Cuantas papeleta de 200 tenemos que dar, esto lo hacemos al verificar si el residuo de 200 es 0

                    else if (UnityThousand == 0 && UnityTwoHundred % 2 == 0)
                    {
                        model.UnityThousand = UnityThousand;
                        model.UnityTwoHundred = UnityTwoHundred;
                        Console.WriteLine(methodWithDraw.MensajeFinal(model));
                        methodWithDraw.SeguirRetirando();
                    }
                    

                    //Aqui damos un mensaje cuando no se puede arrojar esa cantidad ejemplo si insertan 1300 pues este mensaje debe darlo.
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
                Console.WriteLine("Please Insert a valid option.");
                Console.Clear();
                Repositorio.instacia.menu.PrintMenu();
            }

        }


    }

}
