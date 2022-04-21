using System.Text;

namespace ExceptionSandbox;

using System.IO;
public class FileExceptionLogger : ILogger
{
    private readonly string path;
    public FileExceptionLogger(string path)
    {
        this.path = path;
    }
    public void Log(Exception e)
    {
        using (StreamWriter sw = new StreamWriter(path, true))
        {
            sw.WriteLine($"{DateTime.Now} [EXCEPTION] {e.Message}");
        }
    }
}

