using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestRabbit.Test
{
    public class ConvertBasicTest
    {
        [Fact]
        public void VerifyConvertTest()
        {
            string input = "hola muchachos";
            string output = "hol@ much@chos";

            ConvertBasic convert = new ConvertBasic();
            string result = convert.Run(input);

            Assert.Equal(output, result);

        }

    }
}
