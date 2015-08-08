using ITunesConverter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITunesScreenshotConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string curDir = Directory.GetCurrentDirectory();
            string destDir = Path.Combine(curDir, "Dest");

            Converter conv = new Converter();
            conv.SourceDir = curDir;
            conv.DestDir = destDir;
            conv.Convert();

        }
    }
}
