using System.IO;
using System.Reflection;

namespace Ccom.Common.Utils
{
    public static class GetLocation
    {
        public static string GetLocationPath()
        {
            return new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
        }
    }
}
