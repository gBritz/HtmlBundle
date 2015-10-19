namespace HtmlBundle
{
    public interface ITaskCompiler
    {
        FileContent Compile(FileContent file);
    }
}