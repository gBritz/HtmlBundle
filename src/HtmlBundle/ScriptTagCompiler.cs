using System;
using System.Text;

namespace HtmlBundle
{
    public class ScriptTagCompiler : ICompilerTask
    {
        private static readonly String BeginTag = "<script type=\"text/ng-template\" id=\"{0}\">";
        private static readonly String EndTag = "</script>";

        private readonly StringBuilder sb = new StringBuilder();

        public FileContent Compile(FileContent file)
        {
            Checker.IsNull(file, "file");

            sb.AppendFormat(BeginTag, file.Name);
            sb.Append(file.Content);
            sb.Append(EndTag);

            file.Content = sb.ToString();
            sb.Clear();

            return file;
        }
    }
}