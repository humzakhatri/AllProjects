using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Framework.Website
{
    public class DeployedFileInfo
    {
        public string DirectoryName { get; set; }
        public string DbTableName { get => DirectoryName; set => DirectoryName = value; }
        public string FileName { get; set; }
        public string RelativePath => Path.Combine(DirectoryName, FileName);
    }
}
