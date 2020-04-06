using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace TestRabbit.Test
{
    public class ValidateDefaultTest
    {

        [Fact]
        public void VerifySizeOk()
        {
            string input = "hola muchachos";
            ValidateDefault validator = new ValidateDefault();
            bool isValid = validator.Run(input);

            Assert.True(isValid);
        }

        [Fact]
        public void VerifySizeError()
        {
            string input = "h";
            ValidateDefault validator = new ValidateDefault();
            bool isValid = validator.Run(input);

            Assert.False(isValid);
        }

    }
}
