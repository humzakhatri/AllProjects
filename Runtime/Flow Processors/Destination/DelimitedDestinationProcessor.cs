using Framework.ConfigData;
using Framework.Interfaces;
using Runtime.Data;
using Runtime.Interfaces;
using Runtime.Runtime.Writers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Runtime.Flow_Processors.Destination
{
    internal class DelimitedDestinationProcessor : DataflowDestinationProcessorBase
    {
        private IWriter Writer;
        private readonly DelimitedDestinationConfigData ConfigData;
        public DelimitedDestinationProcessor(IConfigData configData, CancellationToken cancellationToken) : base(configData, cancellationToken)
        {
            ConfigData = (DelimitedDestinationConfigData)configData;
        }

        protected override void Write(Record record)
        {
            Writer.Write(record);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            Writer = new DelimitedWriter(ConfigData.FilePath);
        }

        public override void Close()
        {
            Writer.Dispose();
            base.Close();
        }

        public override void Dispose()
        {
            Close();
            base.Dispose();
        }
    }
}
