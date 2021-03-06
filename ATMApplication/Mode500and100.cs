using System;

namespace ATMApplication
{
    public class Mode500and100 : ModelClass, IMethodMode
    {
        ModelClass model = new ModelClass();
        MethodWithDraw methodWithDraw = new MethodWithDraw();
        public void Withdraw()
        {
            try
            {
                model.Mode = 2;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("Insert the amount to Withdraw");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Money = Convert.ToInt32(Console.ReadLine());

                // Validamos si se introdujo una cantidad menor a 100
                if (Money < 100)
                {Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Solo aceptamos retiro de papeleta de 100 y de 500");
                    methodWithDraw.SeguirRetirando();
                }

                // Dividimos la cantidad insertada por la denominacion mayor aceptada
                Total = Convert.ToDouble(Money) / 500;

                // Si es decimal la separamos en 2 cifras, Una cifra para el 500 en este caso y otra para el 100
                if (Total.ToString().Contains('.'))
                {
                    string[] divideMoney = Total.ToString().Split('.');
                    UnityFiveHundred = Convert.ToInt32(divideMoney[0]);
                    UnityHundred = Convert.ToInt32(divideMoney[1]);
                }
                // Si es un numero entero pues solo sacamos el mensaje diciendo cuanta papeletas de 500 se otorga

                else
                {
                    UnityFiveHundred = Convert.ToInt32(Total);
                    model.UnityFiveHundred = UnityFiveHundred;
                    Console.WriteLine(methodWithDraw.MensajeFinal(model));
                    methodWithDraw.SeguirRetirando();
                }

                // Aqui validamos si se estan insertando papeletas no admitidas como por ejemplo 1550, que si lo dividimos
                // por 500 estos nos da 3.1 y al hacer la validacion de que el residuo de las unidades de 100 nos da 1 arrojamos el mensaje de que solo es papeletas de 100 y 500

                if (UnityHundred % 2 == 1 || UnityHundred.ToString().Length > 1)
                {Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Solo se admiten papeletas de 100 y 500");
                    methodWithDraw.SeguirRetirando();
                }


                else
                {
                    // Aqui validamos Cuantas papeleta de 100 y 500 tenemos, esto lo hacemos al verificar si el residuo de 100 es 0 y 1000 es mayor que 0
                    if (UnityHundred % 2 == 0 && UnityFiveHundred > 0)
                    {
                        model.UnityFiveHundred = UnityFiveHundred;
                        model.UnityHundred = UnityHundred / 2;
                        Console.WriteLine(methodWithDraw.MensajeFinal(model));
                        methodWithDraw.SeguirRetirando();
                    }
                    // Aqui validamos Cuantas papeleta de 100 tenemos, esto lo hacemos al verificar si el residuo de 100 es 0
                    else if (UnityFiveHundred == 0 && UnityHundred % 2 == 0)
                    {
                        model.UnityFiveHundred = UnityFiveHundred;
                        model.UnityHundred = UnityHundred / 2;
                        Console.WriteLine(methodWithDraw.MensajeFinal(model));
                        methodWithDraw.SeguirRetirando();
                    }
                    else
                    {Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No se puede dar de esta cantidad solo papeleta de 500 y 100");
                        Console.ReadKey();
                        methodWithDraw.SeguirRetirando();
                    }
                }
            }
            catch (Exception)
            {Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please insert a integer value.");
                Console.Clear();
                Repositorio.instacia.menu.PrintMenu();
            }
        }
    }
}