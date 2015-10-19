using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace HtmlBundle.Test
{
    [TestClass]
    public class ScriptTagCompilerTest
    {
        [TestMethod]
        public void When_file_is_null_should_throw_argument_null_exception()
        {
            var compiler = new ScriptTagCompiler();
            Action method = () => compiler.Compile(null);
            method.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("file");
        }

        [TestMethod]
        public void Given_html_template_when_compile_result_should_not_be_null_or_empty()
        {
            var content = new FileContent { Name = "template.tpl.html", Content = "<div>Oi!</div>" };
            var compiler = new ScriptTagCompiler();
            var result = compiler.Compile(content);

            result.Should().NotBeNull();
            result.Content.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void Given_html_template_when_compile_result_should_be_html_betwen_tag_script()
        {
            var content = new FileContent { Name = "template.tpl.html", Content = "<div>Oi!</div>" };
            var compiler = new ScriptTagCompiler();
            var result = compiler.Compile(content);

            result.Content.Should().Be("<script type=\"text/ng-template\" id=\"template.tpl.html\"><div>Oi!</div></script>");
        }
    }
}