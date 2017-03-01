using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DcProgrammingTutorial.Lib.Helpers
{
    public class AmkaCalculation: IIsValidCalculations
    {
        private Func<string, bool> MyNewCalculation = (x) =>
        {
            if (x.Length != 11)
            {
                return false;
            }
            return true; };

        public bool Calculate(string param)
        {
            return MyNewCalculation.Invoke(param);
        }

        public bool Calculate(string param, Func<string, bool> func)
        {
            throw new NotImplementedException();
        }
    }
}
