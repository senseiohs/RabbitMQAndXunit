using System;
using System.Collections.Generic;
using System.Text;

namespace TestRabbit
{
    public interface IConvert
    {
        public string Run(string data);
    }

    public class ConvertBasic : IConvert
    {
        public string Run(string data)
        {
            return data.Replace('a', '@');
        }

    }
}
