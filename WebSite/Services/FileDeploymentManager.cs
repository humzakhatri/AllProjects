using DataAccess.Layout.Builder;
using DataAccess.Readers.Delimited;
using Framework.Global;
using Framework.Website;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using WebSite.Models;

namespace WebSite.Services
{
    public class FileDeploymentManager
    {
        private const long PreviewRecordCount = 10;
        private ConcurrentDictionary<Guid, DeployedFileInfo> FileMap { get; set; } = new ConcurrentDictionary<Guid, DeployedFileInfo>();
        public async Task<Guid> AddFile(IFormFile file, string userName)
        {
            var id = Guid.NewGuid();
            //TODO add filetype checks
            var dir = TempFileManager.TempDirectory;
            var fileName = file.FileName;
            var fullPath = Path.Combine(dir, userName, fileName);
            Directory.CreateDirectory(Path.Combine(dir, userName));
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var fileInfo = new DeployedFileInfo() { DirectoryName = userName, FileName = fileName };
            FileMap.TryAdd(id, fileInfo);
            return id;
        }

        private DeployedFileInfo GetFileInfo(Guid id)
        {
            if (FileMap.TryGetValue(id, out var info))
                return info;
            throw new Exception("File is not present.");
        }

        public FilePreviewModel GetPreview(Guid id)
        {
            var fileInfo = GetFileInfo(id);
            var fullPath = Path.Combine(TempFileManager.TempDirectory, fileInfo.RelativePath);
            var filePreviewModel = new FilePreviewModel();

            var layoutBuilder = new DelimitedLayoutBuilder(new FileLayoutBuilderOptions() { FilePath = fullPath });
            layoutBuilder.Build();

            var options = new DelimitedReaderOptions() { FilePath = fullPath, RecordsToRead = PreviewRecordCount };
            using var reader = new DelimitedReader(options, layoutBuilder.Layout);
            foreach (var record in reader.Read())
            {
                filePreviewModel.Records.Add(record);
            }
            return filePreviewModel;
        }

        public void MoveToRepository(Guid id)
        {
            var fileInfo = GetFileInfo(id);

        }
    }
}
