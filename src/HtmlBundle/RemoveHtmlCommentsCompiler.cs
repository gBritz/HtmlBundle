using System;
using System.Text.RegularExpressions;

namespace HtmlBundle
{
    public class RemoveHtmlCommentsCompiler : ITaskCompiler
    {
        private readonly Regex regex = new Regex("<!--.*?-->", RegexOptions.Singleline);

        public FileContent Compile(FileContent file)
        {
            Checker.IsNull(file, "file");

            file.Content = regex.Replace(file.Content, String.Empty);
            return file;
        }
    }
}