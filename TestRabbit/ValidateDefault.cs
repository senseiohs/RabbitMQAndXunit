using System;
using System.Collections.Generic;
using System.Text;

namespace TestRabbit
{
    public interface IValidate
    {
        bool Run(string input);
    }


    public class ValidateDefault: IValidate
    {
        public bool Run(string input) => input.Length > 2;
    }
}
