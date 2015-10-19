using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HtmlBundle.Test
{
    [TestClass]
    public class CollapseWhitespaceCompilerTest
    {
        [TestMethod]
        public void When_file_is_null_should_throw_argument_null_exception()
        {
            var compiler = new CollapseWhitespaceCompiler();
            Action method = () => compiler.Compile(null);
            method.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("file");
        }

        [TestMethod]
        public void Given_spaces_begin_tag_when_compile_result_should_not_contains_space()
        {
            var compiler = new CollapseWhitespaceCompiler();
            var content = new FileContent { Content = "       <p>Oi</p>" };
            compiler.Compile(content)
                .Content.Should().Be("<p>Oi</p>");
        }

        [TestMethod]
        public void Given_spaces_end_tag_when_compile_result_should_not_contains_space()
        {
            var compiler = new CollapseWhitespaceCompiler();
            var content = new FileContent { Content = "<p>Oi</p>       " };
            compiler.Compile(content)
                .Content.Should().Be("<p>Oi</p>");
        }

        [TestMethod]
        public void Given_spaces_tag_when_compile_result_should_contains_one_space()
        {
            var compiler = new CollapseWhitespaceCompiler();
            var content = new FileContent { Content = "       <div class='wrap'>       <p>        <span>Oi</span>       </p>       </div>       " };
            compiler.Compile(content)
                .Content.Should().Be("<div class='wrap'> <p> <span>Oi</span> </p> </div>");
        }

        [TestMethod]
        public void Given_multi_line_spaces_tag_when_compile_result_should_contains_one_space()
        {
            var compiler = new CollapseWhitespaceCompiler();
            var content = new FileContent { Content = @"

<div class='wrap'>
<p>
<span>Oi</span>

</p>

</div>


" };
            compiler.Compile(content)
                .Content.Should().Be(@"<div class='wrap'> <p> <span>Oi</span> </p> </div>");
        }
    }
}