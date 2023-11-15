using System.Text.RegularExpressions;
using Calculator.Services;
using Xunit;

namespace Calculator.Tests.UnitTesting.xUnit
{
    public class ContentAnalyzerTests
    {
        [Theory]
        [MemberData(nameof(TestingData.IncorrectArgs_ArgumentNullException), MemberType = typeof(TestingData))]
        public void ParseArgumentsToSettings_Null_ThrowsArgumentNullException(AppSettingsContext record)
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => ContentAnalyzer.ParseArgumentsToSettings(record.Args, record.Setup));
        }

        [Theory]
        [MemberData(nameof(TestingData.IncorrectArgs_ArgumentException), MemberType = typeof(TestingData))]
        public void ParseArgumentsToSettings_IncorrectArgs_ThrowsArgumentException(AppSettingsContext record)
        {
            // Assert
            Assert.Throws<ArgumentException>(() => ContentAnalyzer.ParseArgumentsToSettings(record.Args, record.Setup));
        }

        [Theory]
        [MemberData(nameof(TestingData.CorrectArgs_CorrectSettingsInstance), MemberType = typeof(TestingData))]
        public void ParseArgumentsToSettings_CorrectArgs_ReturnsCorrectSettingsInstance(Settings settings, SettingsSimulator settingsSimulator)
        {
            // Act
            bool actual = AreSettingsTheSame(settings, settingsSimulator);

            // Assert
            Assert.True(actual);
        }

        public record AppSettingsContext(string[]? Args, Settings? Setup);
        public record SettingsSimulator(string? Record, bool IsUploaded, bool IsEvaled);

        private static bool AreSettingsTheSame(Settings settings, SettingsSimulator settingsSimulator)
        {
            if (settings.Record != settingsSimulator.Record ||
                settings.IsUploaded != settingsSimulator.IsUploaded ||
                settings.IsEvaled != settingsSimulator.IsEvaled)
            {
                return false;
            }

            if (settings.IsUploaded == true)
            {
                string outputPattern = @"output\(\d{2}-\d{2}-\d{2}\).txt";

                if (settings.OutputFilePath is null ||
                    Regex.IsMatch(settings.OutputFilePath, outputPattern) == false)
                {
                    return false;
                }
            }

            return true;
        }

        private class TestingData
        {
            public static IEnumerable<object[]> IncorrectArgs_ArgumentNullException()
            {
                AppSettingsContext record1 = new(null, new("1+2", "-e"));
                AppSettingsContext record2 = new(Array.Empty<string>(), null);
                AppSettingsContext record3 = new(null, null);

                return new List<object[]>()
                {
                    new object[] {record1},
                    new object[] {record2},
                    new object[] {record3}
                };
            }

            public static IEnumerable<object[]> IncorrectArgs_ArgumentException()
            {
                Settings settings = new("1+2", "-e");

                AppSettingsContext record1 = new(Array.Empty<string>(), settings);
                AppSettingsContext record2 = new(new string[1], settings);
                AppSettingsContext record3 = new(new string[3], settings);
                AppSettingsContext record4 = new(new string[2] { "-u", "-i" }, settings);
                AppSettingsContext record5 = new(new string[2] { "-i", "-u" }, settings);
                AppSettingsContext record6 = new(new string[2] { "-e", "-i" }, settings);
                AppSettingsContext record7 = new(new string[2] { "-i", "-e" }, settings);
                AppSettingsContext record8 = new(new string[2] { "-i", "-j" }, settings);
                AppSettingsContext record9 = new(new string[2] { "-u", "-e" }, settings);
                AppSettingsContext record10 = new(new string[2] { "1+2", "-u" }, settings);
                AppSettingsContext record11 = new(new string[2] { "file.txt", "-e" }, settings);

                return new List<object[]>()
                {
                    new object[] {record1},
                    new object[] {record2},
                    new object[] {record3},
                    new object[] {record4},
                    new object[] {record5},
                    new object[] {record6},
                    new object[] {record7},
                    new object[] {record8},
                    new object[] {record9},
                    new object[] {record10},
                    new object[] {record11}
                };
            }

            public static IEnumerable<object[]> CorrectArgs_CorrectSettingsInstance()
            {
                Settings settings1 = new(@".\file.txt", "-u");
                SettingsSimulator settingsExpected1 = new(@".\file.txt", true, false);

                Settings settings2 = new("2+2*2", "-e");
                SettingsSimulator settingsExpected2 = new("2+2*2", false, true);

                return new List<object[]>()
                {
                    new object[]{settings1, settingsExpected1},
                    new object[]{settings2, settingsExpected2},
                };
            }
        }
    }
}
