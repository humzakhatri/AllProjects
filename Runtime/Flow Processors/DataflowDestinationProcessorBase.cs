using Framework.Interfaces;
using Runtime.Data;
using Runtime.Interfaces;
using Runtime.Runtime;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Runtime.Flow_Processors
{
    internal abstract class DataflowDestinationProcessorBase : FlowProcessorBase, IHasTargetBlock
    {
        private ActionBlock<Record> Block;
        public ITargetBlock<Record> TargetBlock => Block;
        protected readonly BlockingCollection<Record> Channel;
        public Task WaitingTask => TargetBlock.Completion;

        public int RecordsWriteCount = 0;
        public DataflowDestinationProcessorBase(IConfigData configData, CancellationToken cancellationToken) : base(configData, cancellationToken)
        {
            Channel = new BlockingCollection<Record>();
        }
        protected override void OnInitialize()
        {
            var options = new DataflowBlockOptions() { EnsureOrdered = PreserverOrder };
            Block = new ActionBlock<Record>(WriteRecord);
        }

        protected override void OnStart()
        {
        }

        protected async virtual Task WriteRecord(Record record)
        {
            if (CancellationToken.IsCancellationRequested)
            {
                Close();
                return;
            }
            await Task.Run(() => Channel.Add(record));
        }
    }
}
