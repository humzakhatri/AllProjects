using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Framework.Global
{
    public static class TempFileManager
    {
        public static string TempDirectory => @"D:\Temp";
        private static string TempFilePrefix => "KTemp_";
        private static string Extension => ".tmp";

        public static string GetUnique(string fileName)
        {
            int count = 1;
            do
            {
                var filePath = Path.Join(TempDirectory, $"{fileName}{count}");//chop the extension out
                if (!File.Exists(filePath))
                    return $"{filePath}{Extension}";
                count++;
            } while (true);
        }

        public static string GetTempFile(string extension = null)
        {
            int count = 1;
            do
            {
                var filePath = Path.Join(TempDirectory, $"{TempFilePrefix}{count}");
                if (!File.Exists($"{filePath}{extension ?? Extension}"))
                    return $"{filePath}{Extension}";
                count++;
            } while (true);
        }
    }
}
