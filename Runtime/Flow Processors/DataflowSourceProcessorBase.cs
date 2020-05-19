using Framework.Interfaces;
using Runtime.Data;
using Runtime.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Runtime.Blocks
{
    internal abstract class DataflowSourceProcessorBase : RuntimeProcessorBase
    {
        private BufferBlock<Record> SourceBlock;
        protected bool EOF;
        public bool PreserverOrder { get; set; } = true;
        protected override void OnInitialize()
        {
            var options = new DataflowBlockOptions() { EnsureOrdered = PreserverOrder };
            SourceBlock = new BufferBlock<Record>(options);
        }

        protected override void OnStart()
        {
            try
            {
                Task.Run(SendRecords);
            }
            catch (Exception ex)
            {

            }
        }

        public override void Close()
        {
            SourceBlock.Complete();
            base.Close();
        }

        protected async Task SendRecords()
        {
            try
            {
                foreach (var record in GetRecords())
                    await SourceBlock.SendAsync(record);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected abstract IEnumerable<Record> GetRecords();
    }
}
