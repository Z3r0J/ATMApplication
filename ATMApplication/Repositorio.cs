using System;
using System.Collections.Generic;
using System.Text;

namespace ATMApplication
{
   public sealed class Repositorio
    {
        public static int Thousand = 0;
       public static int TwoHundred = 0;
        public static Repositorio instacia { get; } = new Repositorio();
        public PrincipalMenu menu = new PrincipalMenu();

        
        public int mode = 1;
        private Repositorio()
        {

        }
    }
}
