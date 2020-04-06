using System;
using System.Collections.Generic;
using System.Text;

namespace TestRabbit
{
    public class MainProccess
    {

        private readonly IValidate _validate;
        private readonly IConvert _convert;
        private readonly IPublish _publish;      

        public MainProccess(IConvert convert,IPublish publish, IValidate validate)
        {
            _validate = validate;
            _convert = convert;
            _publish = publish;
        }


        public void Run(string message)
        {
            if (_validate.Run(message))
            {
                string convertData = _convert.Run(message);
                _publish.Run(convertData);
            }              

        }


    }
}
