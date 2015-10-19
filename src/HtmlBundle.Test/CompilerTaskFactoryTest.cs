using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HtmlBundle.Test
{
    [TestClass]
    public class CompilerTaskFactoryTest
    {
        [TestMethod]
        public void Given_all_compiler_types_result_should_not_be_null()
        {
            var types = Enum.GetValues(typeof(CompileType));
            var factory = new CompilerTaskFactory();

            foreach (var type in types)
            {
                factory.CreateInstance((CompileType)type)
                    .Should().NotBeNull("Type {0} should not be null.", type);
            }
        }

        [TestMethod]
        public void When_type_is_HtmlTemplateTag_result_should_be_of_type_ScriptTagCompiler()
        {
            var factory = new CompilerTaskFactory();
            factory.CreateInstance(CompileType.HtmlTemplateTag)
                .Should().BeOfType<ScriptTagCompiler>();
        }
    }
}