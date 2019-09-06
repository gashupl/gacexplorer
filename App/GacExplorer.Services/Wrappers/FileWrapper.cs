using System.IO;

namespace GacExplorer.Services.Wrappers
{
    public class FileWrapper : IFile
    {
        public bool FileExists(string location)
        {
            return File.Exists(location); 
        }
    }
}
