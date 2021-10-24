using System;

namespace ATMApplication
{
    public class ModeEfficient : ModelClass, IMethodMode
    {
        ModelClass model = new ModelClass();
        MethodWithDraw methodWithDraw = new MethodWithDraw();
        public void Withdraw()
        {
            try
            {
                model.Mode = 3;

                Console.WriteLine("Insert the amount to withdraw: ");
                Money = Convert.ToInt32(Console.ReadLine());

                // Validamos si se introdujo una cantidad menor a 100
                if (Money < 100)
                {
                    Console.WriteLine("No se puede retirar esta cantidad.");
                }
                // Dividimos la cantidad insertada por la denominacion mayor aceptada
                Total = Convert.ToDouble(Money) / 1000;

                // Si es decimal la separamos en 2 cifras, Una cifra para el 1000 en este caso y otra para una variable llamada Unity para seguirla usando abajo.
                if (Total.ToString().Contains('.'))
                {
                    string[] divideMoney = Total.ToString().Split('.');
                    UnityThousand = Convert.ToInt32(divideMoney[0]);
                    model.UnityThousand = UnityThousand;
                    Unity = Convert.ToInt32(divideMoney[1]);
                    string total = Unity.ToString().PadRight(3, '0');
                    Total = Convert.ToDouble(total) / 500;

                    // Si se a la variable Unity le agregamos 2 00 y lo dividimos en la 2da denominacion mas fuerte y es igual a 1 sacamos el mensaje. de lo contrario seguimos validando.
                    if (Total == 1)
                    {
                        UnityFiveHundred = Convert.ToInt32(Total);
                        model.UnityFiveHundred = UnityFiveHundred;
                        Console.WriteLine(methodWithDraw.MensajeFinal(model));
                        methodWithDraw.SeguirRetirando();
                    }

                    else
                    {

                        //Aqui validamos que no se este insertando ni 50,60,70,90 asi que tomamos nuestro arreglo donde dividimos la division de 1000 en 2 parte.
                        if (divideMoney[1].Length > 1)
                        {
                            Console.WriteLine("No puede insertar esta cantidad.");
                            Console.ReadKey();
                            Repositorio.instacia.menu.PrintMenu();
                        }
                        else
                        {

                            //Aqui  sacamos cuantas de 500 tenemos, la dividimos en 2 y a la unidad que es nuestra variable le sumamos 2 ceros ejemplo si era 1.3 1 de 500 y 3 a unidad
                            if (Total.ToString().Contains('.'))
                            {
                                divideMoney = Total.ToString().Split('.');
                                UnityFiveHundred = Convert.ToInt32(divideMoney[0]);
                                model.UnityFiveHundred = UnityFiveHundred;
                                Unity = Convert.ToInt32(divideMoney[1]);
                                
                                total = Unity.ToString().PadRight(3, '0');

                                // Aqui dividimos la unidad en 200
                                Total = Convert.ToDouble(total) / 200;

                                //Si nuestra variable total al dividir da un numero que el residuo en 2 es 1 entonces le agregamos dos 0 a ese numero
                                if (Total % 2 == 1)
                                {
                                    total = Total.ToString().PadRight(3, '0');

                                    // Aqui volvemos a dividirla en 200

                                    Total = Convert.ToDouble(total) / 200;

                                    // Aqui nosotros volvemos y dividimos el numero en 2 parte y asi le damos papeletas tanto de 100 como de 200.
                                    if (Total.ToString().Contains('.'))
                                    {
                                        divideMoney = Total.ToString().Split('.');
                                        UnityTwoHundred = Convert.ToInt32(divideMoney[0]);
                                        model.UnityTwoHundred = UnityTwoHundred;
                                        UnityHundred = Convert.ToInt32(divideMoney[1]) % 2;
                                        model.UnityHundred = UnityHundred;
                                        Console.WriteLine(methodWithDraw.MensajeFinal(model));
                                        methodWithDraw.SeguirRetirando();
                                    }
                                }
                                // De lo contrario si nuestra variable total al dividir no queda residuo en 2  entonces solo le damos 1 de 200.
                                else
                                {
                                    total = Unity.ToString().PadRight(3, '0');
                                    Total = Convert.ToDouble(total) / 200;
                                    UnityTwoHundred = Convert.ToInt32(Total);
                                    model.UnityTwoHundred = UnityTwoHundred;
                                    Console.WriteLine(methodWithDraw.MensajeFinal(model));
                                    methodWithDraw.SeguirRetirando();
                                }
                            }
                        }
                    }
                }

                // Si es un numero entero pues solo sacamos el mensaje diciendo cuanta papeletas de 1000 se otorga
                else
                {
                    UnityThousand = Convert.ToInt32(Total);
                    model.UnityThousand = UnityThousand;
                    Console.WriteLine(methodWithDraw.MensajeFinal(model));
                    methodWithDraw.SeguirRetirando();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Please Insert a valid option..");
                Console.ReadKey();
                Repositorio.instacia.menu.PrintMenu();
            }
        }
    }
}
