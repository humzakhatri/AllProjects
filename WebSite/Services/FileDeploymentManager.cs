using DataAccess.DbProviders;
using DataAccess.Layout.Builder;
using DataAccess.Layouts;
using DataAccess.Readers.Database;
using DataAccess.Readers.Delimited;
using DataAccess.Transformers;
using Framework.Authentication;
using Framework.ConfigData;
using Framework.ConfigData.Connection;
using Framework.Global;
using Framework.Website;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Runtime.Flow_Processors;
using Runtime.Persisters;
using Runtime.Runtime.Pipeline;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        public void CreateDeployment(Guid sessionFileId, DataApiDeployment deployment)
        {
            var fileInfo = GetFileInfo(sessionFileId);
            fileInfo.DbTableName = deployment.Name;
            SaveDeployment(deployment);
            SaveFileToDatabase(fileInfo);
            DeleteFile(fileInfo);
        }

        private void DeleteFile(DeployedFileInfo fileInfo)
        {
            var dir = TempFileManager.TempDirectory;
            File.Delete(Path.Combine(dir, fileInfo.RelativePath));
        }

        private void SaveDeployment(DataApiDeployment deployment)
        {
            var persister = new DataApiDeploymentPersister();
            persister.Save(deployment);
        }

        private void SaveFileToDatabase(DeployedFileInfo fileInfo)
        {
            var builder = new DynamicFlowBuilder();
            var flow = builder.SaveDeployedFileToRepository(fileInfo);
            var executer = new FlowExecuter();
            executer.Execute(flow);
        }
    }
}
