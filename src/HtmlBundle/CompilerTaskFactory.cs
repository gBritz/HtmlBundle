using System;

namespace HtmlBundle
{
    public class CompilerTaskFactory
    {
        public ICompilerTask CreateInstance(CompileType type)
        {
            switch (type)
            {
                case CompileType.HtmlTemplateTag:
                    return new ScriptTagCompiler();

                default:
                    throw new Exception(String.Format("Format {0} not implemented.", type));
            }
        }
    }
}