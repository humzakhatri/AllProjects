using DataAccess.Interfaces;
using DataAccess.Layouts;
using DataAccess.Readers.Delimited;
using Framework.ConfigData;
using Framework.Interfaces;
using Runtime.Blocks;
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
            Reader = new DelimitedReader(new DelimitedReaderOptions() { FilePath = ConfigData.FilePath }, ConfigData.Layout);
        }
        protected override IEnumerable<Record> GetRecords()
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
