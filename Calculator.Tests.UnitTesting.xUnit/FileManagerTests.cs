using System.Data;
using System.Text.RegularExpressions;
using Calculator.Services;
using Xunit;

namespace Calculator.Tests.UnitTesting.xUnit
{
    public class FileManagerTests
    {
        [Fact]
        public void EvalFileExpressions_NonExistentInputPath_ThrowsIOException()
        {
            // Arrange
            string inputPath = "unknown_path";
            string outputPath = "path";
            FileManager file = new(inputPath, outputPath);

            // Assert
            Assert.Throws<IOException>(() => file.EvalFileExpressions());
        }

        [Theory]
        [InlineData(@"..\..\..\TestingFiles\10.txt")]
        [InlineData(@"..\..\..\TestingFiles\100.txt")]
        [InlineData(@"..\..\..\TestingFiles\errors.txt")]
        [InlineData(@"..\..\..\TestingFiles\examples.txt")]
        public void EvalFileExpressions_PathToCorrectFile_ReturnsEvaluatedFile(string inputFile)
        {
            // Arrange
            string customFile = @"..\..\..\TestingFiles\custom_output.txt";
            string correctFile = @"..\..\..\TestingFiles\correct_output.txt";

            CreateCorrectFile(inputFile, correctFile);
            CreateCustomFile(inputFile, customFile);

            // Act
            bool actual = AreTheCalculationsTheSame(correctFile, customFile);

            // Assert
            Assert.True(actual);

            File.Delete(customFile);
            File.Delete(correctFile);
        }

        private static void CreateCorrectFile(string input, string output)
        {
            DataTable table = new();
            string? line;
            string result;

            using StreamReader reader = new(input);
            using StreamWriter writer = new(output);

            while ((line = reader.ReadLine()) != null)
            {
                try
                {
                    result = table.Compute(line, string.Empty).ToString()!;
                }
                catch (Exception ex)
                {
                    result = ex.Message;
                }

                writer.WriteLine($"{line} = {result}");
            }
        }

        private static void CreateCustomFile(string input, string output)
        {
            FileManager file = new(input, output);
            file.EvalFileExpressions();
        }

        private static bool AreTheCalculationsTheSame(string correctFile, string customFile)
        {
            using StreamReader correctReader = new(correctFile);
            using StreamReader customReader = new(customFile);

            string expressionPattern = @"^(.*?) = (.*?)$";
            string correctPositiveZeroDivision = "∞";
            string correctNegativeZeroDivision = "-∞";
            string customZeroDivision = "Cannot divide by zero";

            Regex regex = new(expressionPattern);

            while (true)
            {
                string? correctLine = correctReader.ReadLine();
                string? customLine = customReader.ReadLine();

                if (correctLine is null || customLine is null)
                {
                    return correctLine is null && customLine is null;
                }

                Match correctMatch = regex.Match(correctLine);
                Match customMatch = regex.Match(customLine);

                string correctGroup = correctMatch.Groups[2].Value;
                string customGroup = customMatch.Groups[2].Value;

                bool correctCheck = double.TryParse(correctGroup, out double correctResult);
                bool customCheck = double.TryParse(customGroup, out double customResult);

                bool isCorrectInfinite = correctGroup == correctPositiveZeroDivision || correctGroup == correctNegativeZeroDivision;
                bool isCustomZeroDivision = customGroup == customZeroDivision;

                if (isCorrectInfinite && isCustomZeroDivision)
                {
                    continue;
                }

                if (correctCheck != customCheck || 
                   (correctCheck == true &&
                    Math.Abs(correctResult - customResult) > 0.0001))
                {
                    return false;
                }
            }
        }
    }
}
