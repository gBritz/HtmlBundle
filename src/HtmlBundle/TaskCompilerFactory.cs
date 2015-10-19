using System;

namespace HtmlBundle
{
    public class TaskCompilerFactory
    {
        public ITaskCompiler CreateInstance(CompileType type)
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