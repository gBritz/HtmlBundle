using System;

namespace HtmlBundle
{
    public class Checker
    {
        public static void IsNull(Object instance, String argumentName)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void IsEmpty(String value, String argumentName)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}