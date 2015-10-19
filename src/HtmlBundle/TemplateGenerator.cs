using System.Collections.Generic;
using System.IO;

namespace HtmlBundle
{
    public class TemplateGenerator
    {
        private readonly TextWriter writer;

        public TemplateGenerator(TextWriter writer)
        {
            Checker.IsNull(writer, "writer");

            this.writer = writer;
        }

        public void Generate(IEnumerable<FileContent> files)
        {
            Checker.IsNull(files, "files");

            foreach (var file in files)
            {
                writer.Write(file.Content);
            }
        }
    }
}