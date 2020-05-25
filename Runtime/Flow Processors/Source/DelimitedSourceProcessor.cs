using Framework.ConfigData;
using Framework.Interfaces;
using Runtime.Blocks;
using Runtime.Data;
using Runtime.Interfaces;
using Runtime.Runtime.Readers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Runtime.Flow_Processors.Source
{
    internal class DelimitedSourceProcessor : DataflowSourceProcessorBase
    {
        private IReader Reader;
        private readonly DelimitedSourceConfigData ConfigData;
        public DelimitedSourceProcessor(IConfigData configData, CancellationToken cancellationToken) : base(configData, cancellationToken)
        {
            ConfigData = (DelimitedSourceConfigData)configData;
        }
        protected override void OnInitialize()
        {
            base.OnInitialize();
            Reader = new DelimitedReader(ConfigData.FilePath, ConfigData.Layout);
        }
        protected override IAsyncEnumerable<Record> GetRecords()
        {
            return Reader.Read();
        }
        public override void Close()
        {
            Reader.Dispose();
            base.Close();
        }
    }
}
