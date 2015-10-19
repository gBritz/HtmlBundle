using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace HtmlBundle.Test
{
    [TestClass]
    public class TemplateGeneratorTest
    {
        [TestMethod]
        public void When_writer_is_null_should_throw_argument_null_exception()
        {
            Action method = () => new TemplateGenerator((TextWriter)null);
            method.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("writer");
        }

        [TestMethod]
        public void When_files_is_null_should_throw_argument_null_exception()
        {
            var writer = new StringWriter();
            var generator = new TemplateGenerator(writer);
            Action method = () => generator.Generate(null);
            method.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("files");
        }

        [TestMethod]
        public void Given_one_content_when_generate_writer_should_contains_all_contents()
        {
            var writer = new StringWriter();
            var generator = new TemplateGenerator(writer);
            var contents = new []
            {
                new FileContent { Name = "template.tpl.html", Content = "<p>Hi!</p>" }
            };

            generator.Generate(contents);

            writer.GetStringBuilder()
                .ToString()
                .Should().Be("<p>Hi!</p>");
        }

        [TestMethod]
        public void Given_two_contents_when_generate_writer_should_contains_all_contents()
        {
            var writer = new StringWriter();
            var generator = new TemplateGenerator(writer);
            var contents = new[]
            {
                new FileContent { Name = "template.tpl.html", Content = "<p>Hi!</p>" },
                new FileContent { Name = "template2.tpl.html", Content = "<div>World!</div>" },
            };

            generator.Generate(contents);

            writer.GetStringBuilder()
                .ToString()
                .Should().Be("<p>Hi!</p><div>World!</div>");
        }
    }
}