public interface IOutputWriter
{
    void Write(string message, params object[] parameters);

    void WriteLine(string message, params object[] parameters);
}