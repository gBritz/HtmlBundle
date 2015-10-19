namespace HtmlBundle
{
    public interface ICompilerTask
    {
        FileContent Compile(FileContent file);
    }
}