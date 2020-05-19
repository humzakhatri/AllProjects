using Framework.ConfigData;
using Runtime.Data;
using Runtime.Interfaces;
using Runtime.Runtime.Writers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Runtime.Flow_Processors.Destination
{
    internal class DelimitedDestinationProcessor : DataflowDestinationProcessorBase
    {
        private IWriter Writer;
        private readonly DelimitedDestinationConfigData ConfigData;
        public DelimitedDestinationProcessor(DelimitedDestinationConfigData configData)
        {
            ConfigData = configData;
        }

        protected override async Task WriteRecord(Record record)
        {
            try
            {
                await Task.Run(() => Writer.Write(record));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnInitialize()
        {
            Writer = new DelimitedWriter(new FileStream(ConfigData.FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite));
            base.OnInitialize();
        }
    }
}
