using Moq;
using System;
using Xunit;

namespace TestRabbit.Test
{
    public class MainProcessTest
    {
        [Fact]
        public void VerifyMainProcess()
        {
            string input = "holaaaa";
            string output = "hol@@@@";
            Mock<IValidate> validate = new Mock<IValidate>();
            Mock<IConvert> convert = new Mock<IConvert>();
            Mock<IPublish> publish = new Mock<IPublish>();

            _= convert.Setup(x => x.Run(input)).Returns(output);
            _ = validate.Setup(x => x.Run(input)).Returns(true);
            MainProccess main = new MainProccess(convert.Object, publish.Object, validate.Object);
            main.Run(input);

            validate.Verify(x => x.Run(input));
            convert.Verify(x => x.Run(input));
            publish.Verify(x => x.Run(output));
        }

        [Fact]
        public void VerifyMainProcessNotValid()
        {
            string input = "holaaaa";  
            Mock<IValidate> validate = new Mock<IValidate>();
            Mock<IConvert> convert = new Mock<IConvert>();
            Mock<IPublish> publish = new Mock<IPublish>();
          
            _ = validate.Setup(x => x.Run(input)).Returns(false);
            MainProccess main = new MainProccess(convert.Object, publish.Object, validate.Object);
            main.Run(input);

            validate.Verify(x => x.Run(input));
            convert.Verify(x => x.Run(It.IsAny<string>()),Times.Never);
            publish.Verify(x => x.Run(It.IsAny<string>()),Times.Never);
        }



    }
}
