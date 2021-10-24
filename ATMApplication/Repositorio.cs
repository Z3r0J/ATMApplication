using System;
using System.Collections.Generic;
using System.Text;

namespace ATMApplication
{
   public sealed class Repositorio
    {
        public static Repositorio instacia { get; } = new Repositorio();
        public PrincipalMenu menu = new PrincipalMenu();


        public int mode=3;
        private Repositorio()
        {

        }
    }
}
