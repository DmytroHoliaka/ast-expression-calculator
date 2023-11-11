using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class ContentAnalyzer
    {
        public static void ParseArgumentsToSettings(string[]? args, Settings? settings)
        {
            if (args is null || settings is null)
            {
                throw new ArgumentNullException(nameof(args), "Cannot parse null data");
            }
            else if (args.Length != 2)
            {
                throw new ArgumentException($"Incorrect amount of arguments ({args.Length} element[s])", nameof(args));
            }

            string unionPattern = $"{RegexPatterns.ExpressionPattern}|{RegexPatterns.FilePathPattern}";
            Match match;

            foreach (var argument in args)
            {
                if ((match = Regex.Match(argument, unionPattern)).Success)
                {
                    settings.Record = match.Value;
                }
                else if ((match = Regex.Match(argument, RegexPatterns.UploadPattern)).Success)
                {
                    settings.IsUploaded = true;
                }
                else if ((match = Regex.Match(argument, RegexPatterns.EvalPattern)).Success)
                {
                    settings.IsEvaled = true;
                }
                else
                {
                    throw new ArgumentException("Incorrect argument", nameof(args));
                }
            }

            if (settings.IsUploaded == settings.IsEvaled)
            {
                throw new ArgumentException("An unclear combination of arguments", nameof(args));
            }
            else if ((match = Regex.Match(settings.Record!, RegexPatterns.ExpressionPattern)).Success &&
                      settings.IsEvaled == false)
            {
                throw new ArgumentException("Incorrect combination of arguments", nameof(args));
            }
            else if ((match = Regex.Match(settings.Record!, RegexPatterns.FilePathPattern)).Success &&
                      settings.IsUploaded == false)
            {
                throw new ArgumentException("Incorrect combination of arguments", nameof(args));
            }
        }
    }
}
