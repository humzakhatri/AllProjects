using Framework.Interfaces;
using Runtime.Data;
using Runtime.Flow_Processors;
using Runtime.Interfaces;
using Runtime.Runtime;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Runtime.Blocks
{
    internal abstract class DataflowSourceProcessorBase : FlowProcessorBase, IHasSourceBlock
    {
        private BufferBlock<Record> Block;
        public ISourceBlock<Record> SourceBlock => Block;
        protected bool EOF;
        public DataflowSourceProcessorBase(IConfigData configData) : base(configData)
        {

        }
        protected override void OnInitialize()
        {
            var options = new DataflowBlockOptions() { EnsureOrdered = PreserverOrder };
            Block = new BufferBlock<Record>(options);
        }

        protected override void OnStart()
        {
            try
            {
                Task.Run(SendRecords);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Close();
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
                await foreach (var record in GetRecords())
                    await Block.SendAsync(record);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DataflowLinkOptions BuildLinkOptions()
        {
            return new DataflowLinkOptions() { PropagateCompletion = true };
        }


        public void LinkTo(IHasTargetBlock hasTargetBlock)
        {
            Block.LinkTo(hasTargetBlock.TargetBlock, BuildLinkOptions());
        }

        protected abstract IAsyncEnumerable<Record> GetRecords();
    }
}
