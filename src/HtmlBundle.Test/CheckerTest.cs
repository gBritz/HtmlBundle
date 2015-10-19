using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HtmlBundle.Test
{
    [TestClass]
    public class CheckerTest
    {
        [TestMethod]
        public void When_instance_is_null_should_be_throw_argument_null_exception()
        {
            Action method = () => Checker.IsNull(null, "parameterNameTest");
            method.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("parameterNameTest");
        }

        [TestMethod]
        public void When_instance_is_null_or_emtpy_should_be_throw_argument_null_exception()
        {
            Action isNull = () => Checker.IsEmpty(null, "parameterNameTest");
            Action isEmpty = () => Checker.IsEmpty(String.Empty, "parameterNameTest");

            isNull.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("parameterNameTest");
            isEmpty.ShouldThrow<ArgumentNullException>()
                .And.ParamName.Should().Be("parameterNameTest");
        }
    }
}