namespace Calculator
{
    public static class RegexPatterns
    {
        public const string ExpressionPattern = @"^([ +\-(]*[ ]*\d*[ ]*\.?[ ]*\d*[+\-*/)]*)+$";
        public const string FilePathPattern = @"^(.*?[\/]*?)([a-zA-Z0-9_\- ]+.txt)$";
        public const string TextRecordPattern = $"{ExpressionPattern}|{FilePathPattern}";
        
        public const string UploadPattern = @"^(-u)$|^(-upload)$";
        public const string EvalPattern = @"^(-e)$|^(-eval)$";
    }
}
