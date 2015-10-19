using System.Text.RegularExpressions;

namespace HtmlBundle
{
    public class CollapseWhitespaceCompiler : ITaskCompiler
    {
        // positive look behind for ">", one or more whitespace (non-greedy), positive lookahead for "<"
        private static readonly Regex whitespace = new Regex(@"(?<=>)\s+?(?=<)", RegexOptions.Singleline);

        public FileContent Compile(FileContent file)
        {
            Checker.IsNull(file, "file");

            file.Content = whitespace.Replace(file.Content.Trim(), " ");
            return file;
        }
    }
}