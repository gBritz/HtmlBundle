using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HtmlBundle.Test
{
    [TestClass]
    public class RemoveHtmlCommentsCompilerTest
    {
        [TestMethod]
        public void When_file_is_null_should_throw_argument_null_exception()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            Action method = () => compiler.Compile(null);
            method.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("file");
        }

        [TestMethod]
        public void Give_comments_in_start_tag_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent { Content = "<!-- comments --><p>Hi!</p>" };
            var result = compiler.Compile(content);
            
            result.Content.Should().Be("<p>Hi!</p>");
        }

        [TestMethod]
        public void Give_comments_in_end_tag_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent { Content = "<p>Hi!</p><!-- comments -->" };
            var result = compiler.Compile(content);

            result.Content.Should().Be("<p>Hi!</p>");
        }

        [TestMethod]
        public void Give_comments_in_start_multi_line_tag_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent { Content = @"<!--


comments

--><p>Hi!</p>" };
            var result = compiler.Compile(content);

            result.Content.Should().Be("<p>Hi!</p>");
        }

        [TestMethod]
        public void Give_comments_in_end_multiline_tag_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent { Content = @"<p>Hi!</p><!--
                
                comments
                
                -->" };
            var result = compiler.Compile(content);
            
            result.Content.Should().Be("<p>Hi!</p>");
        }

        [TestMethod]
        public void Give_comments_in_start_word_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent { Content = "<p><!-- comments -->Hi!</p>" };
            var result = compiler.Compile(content);

            result.Content.Should().Be("<p>Hi!</p>");
        }

        [TestMethod]
        public void Give_comments_in_end_word_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent { Content = "<p>Hi!<!-- comments --></p>" };
            var result = compiler.Compile(content);

            result.Content.Should().Be("<p>Hi!</p>");
        }

        [TestMethod]
        public void Give_comments_in_start_word_multiline_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent { Content = @"<p><!--

comments

-->Hi!</p>" };
            var result = compiler.Compile(content);

            result.Content.Should().Be("<p>Hi!</p>");
        }

        [TestMethod]
        public void Give_comments_in_end_word_multiline_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent { Content = @"<p>Hi!<!--

comments

--></p>" };
            var result = compiler.Compile(content);

            result.Content.Should().Be("<p>Hi!</p>");
        }

        [TestMethod]
        public void Give_comments_start_between_tags_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent { Content = "<p><!-- comments --><span>Hi!</span></p>" };
            var result = compiler.Compile(content);

            result.Content.Should().Be("<p><span>Hi!</span></p>");
        }

        [TestMethod]
        public void Give_comments_end_between_tags_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent { Content = "<p><span>Hi!</span><!-- comments --></p>" };
            var result = compiler.Compile(content);

            result.Content.Should().Be("<p><span>Hi!</span></p>");
        }

        [TestMethod]
        public void Give_comments_start_between_tags_multiline_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent
            {
                Content = @"<p><!--

comments

--><span>Hi!</span></p>"
            };
            var result = compiler.Compile(content);

            result.Content.Should().Be("<p><span>Hi!</span></p>");
        }

        [TestMethod]
        public void Give_comments_end_between_tags_multiline_when_compile_result_should_not_contains_comments()
        {
            var compiler = new RemoveHtmlCommentsCompiler();
            var content = new FileContent
            {
                Content = @"<p><span>Hi!</span><!--

comments

--></p>"
            };
            var result = compiler.Compile(content);

            result.Content.Should().Be("<p><span>Hi!</span></p>");
        }
    }
}