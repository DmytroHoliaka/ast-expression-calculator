using System.Text.RegularExpressions;

namespace Calculator
{
    public class Settings
    {
        public string? Record = null;
        public string? OutputFilePath = null;

        public bool IsUploaded = false;
        public bool IsEvaled = false;

        public Settings(params string[]? args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args), "Application arguments cannot be null");
            }

            ContentAnalyzer.ParseArgumentsToSettings(args, this);

            if (IsUploaded == true)
            {
                string outputFileName = $"output({DateTime.Now:HH-mm-ss}).txt";

                Match match = Regex.Match(Record!, RegexPatterns.FilePathPattern);
                string foldersPath = match.Groups[1].Value;

                OutputFilePath = foldersPath + outputFileName;
            }
        }

        public Settings(Settings? origin)
        {
            if (origin is null)
            {
                throw new ArgumentNullException(nameof(origin), "Origin settings cannot be null in copy ctor");
            }

            Record = origin.Record;
            OutputFilePath = origin.OutputFilePath;
            IsUploaded = origin.IsUploaded;
            IsEvaled = origin.IsEvaled;
        }
    }
}
