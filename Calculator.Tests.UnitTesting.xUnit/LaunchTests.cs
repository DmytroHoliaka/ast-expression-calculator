using Xunit;

namespace Calculator.Tests.UnitTesting.xUnit
{
    public class LaunchTests
    {
        [Fact]
        public void LaunchCtor_Null_ThrowsArgumentNullException()
        {
            // Arrance
            Settings? settings = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => new Launch(settings));
        }

        [Theory]
        [InlineData("2+2*2", "-e")]
        [InlineData("./input.txt", "-u")]
        public void LaunchCtor_CorrectSettigns_ReturnsCorrectInstance(params string[] args)
        {
            // Arrange
            Settings settings = new(args);
            Launch launch = new(settings);

            // Act
            bool actual = AreSettingsTheSame(settings, launch.Tools);

            // Assert
            Assert.True(actual);
        }

        private static bool AreSettingsTheSame(Settings settings1, Settings settings2)
        {
            if (settings1.Record != settings2.Record ||
                settings1.OutputFilePath != settings2.OutputFilePath ||
                settings1.IsUploaded != settings2.IsUploaded ||
                settings1.IsEvaled != settings2.IsEvaled)
            {
                return false;
            }

            return true;
        }
    }
}
