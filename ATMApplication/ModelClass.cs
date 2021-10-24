using System;
using System.Collections.Generic;
using System.Text;

namespace ATMApplication
{
    public class ModelClass
    {
        public int Mode { get; set; }
        public int Money { get; set; }
        public int UnityHundred { get; set; }
        public int UnityTwoHundred { get; set; }
        public int UnityFiveHundred { get; set; }
        public int UnityThousand { get; set; }
        public int Unity { get; set; }
        public double Total { get; set; }
        public IMethodMode method;
        public ModelClass()
        {

        }
        public ModelClass(int mode)
        {
            Mode = mode;
        }

        public void ModeDispensing(ModelClass mode)
        {
            switch (mode.Mode)
            {
                case (int)ModelEnum.Efficient:
                    method = new ModeEfficient();
                    break;
                case (int)ModelEnum.Mode200and1000:
                    method = new Mode200and1000();
                    break;
                case (int)ModelEnum.Mode500and100:
                    method = new Mode500and100();
                    break;
                default:
                    break;
            }
            method.Withdraw();
        }
}
}
