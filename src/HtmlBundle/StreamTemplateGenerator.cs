using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HtmlBundle
{
    public class StreamTemplateGenerator
    {
        private readonly String fullPath;

        public StreamTemplateGenerator(String fullPath)
        {
            Checker.IsEmpty(fullPath, "fullPath");

            var directory = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(directory))
            {
                throw new ArgumentException(String.Format("Directory '{0}' not exists.", directory), "fullPath");
            }

            this.fullPath = fullPath;
        }

        public void Generate(IEnumerable<FileContent> files)
        {
            Checker.IsNull(files, "files");

            using (var writer = new StreamWriter(fullPath, false, Encoding.UTF8))
            {
                writer.AutoFlush = true;

                var fileWriter = new TemplateGenerator(writer);
                fileWriter.Generate(files);
            }
        }
    }
}