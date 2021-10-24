using System;

namespace ATMApplication
{
    public class MethodWithDraw : ModelClass
    {
        public IMethodMode mode;
        public string MensajeFinal(ModelClass model)
        {
            UnityThousand = model.UnityThousand;
            UnityFiveHundred = model.UnityFiveHundred;
            UnityTwoHundred = model.UnityTwoHundred;
            UnityHundred = model.UnityHundred;
            Mode = model.Mode;

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
            else if (UnityThousand != 0 && UnityFiveHundred == 0 && UnityTwoHundred == 0 && UnityHundred != 0)
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
                message = $"El cajero dio {UnityTwoHundred / 2} de 200";
            }
            else if (UnityFiveHundred == 0 && UnityTwoHundred == 0 && UnityThousand == 0 && UnityHundred != 0)
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
            ModelClass model = new ModelClass();

            Console.WriteLine("¿Quieres seguir retirando? (S/N)");
            char answer = Convert.ToChar(Console.ReadLine());
            if (answer == 's' || answer == 'S')
            {
                model.UnityThousand = 0;
                model.UnityFiveHundred = 0;
                model.UnityTwoHundred = 0;
                model.UnityHundred = 0;

                switch (Mode)
                {
                    case (int)ModelEnum.Efficient:
                        mode = new ModeEfficient();
                        break;
                    case (int)ModelEnum.Mode200and1000:
                        mode = new Mode200and1000();
                        break;
                    case (int)ModelEnum.Mode500and100:
                        mode = new Mode500and100();
                        break;
                }
                mode.Withdraw();
            }
            else
            {
                model.UnityThousand = 0;
                model.UnityFiveHundred = 0;
                model.UnityTwoHundred = 0;
                model.UnityHundred = 0;

                Console.WriteLine("Presiona Enter para continuar.");
                Console.ReadKey();
                Console.Clear();
                Repositorio.instacia.menu.PrintMenu();
            }
        }
    }
}
