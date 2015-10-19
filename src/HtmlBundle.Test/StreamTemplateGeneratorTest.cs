using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HtmlBundle.Test
{
    [TestClass]
    public class StreamTemplateGeneratorTest
    {
        [TestMethod]
        public void When_fullPath_is_null_or_empty_should_throw_argument_null_exception()
        {
            Action isNull = () => new StreamTemplateGenerator(null);
            Action isEmpty = () => new StreamTemplateGenerator(String.Empty);

            isNull.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("fullPath");
            isEmpty.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("fullPath");
        }

        [TestMethod]
        public void When_fullPath_is_directory_not_exists_should_throw_argument_exception()
        {
            Action method = () => new StreamTemplateGenerator("asdc:\\asdfasd\\asdf.tpl.html");

            var shouldThrow = method.ShouldThrow<ArgumentException>();
            shouldThrow.And.ParamName.Should().Be("fullPath");
            shouldThrow.And.Message.Should().StartWith("Directory 'asdc:\\asdfasd' not exists.");
        }

        [TestMethod]
        public void When_files_is_null_should_throw_argument_null_exception()
        {
            var generator = new StreamTemplateGenerator("c:\\template.tpl.html");
            Action method = () => generator.Generate(null);
            method.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("files");
        }
    }
}