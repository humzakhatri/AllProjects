using Framework.Interfaces;
using Runtime.Data;
using Runtime.Interfaces;
using Runtime.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Runtime.Flow_Processors
{
    internal abstract class DataflowDestinationProcessorBase : FlowProcessorBase, IHasTargetBlock
    {
        private ActionBlock<Record> Block;
        public ITargetBlock<Record> TargetBlock => Block;
        public DataflowDestinationProcessorBase(IConfigData configData) : base(configData)
        {

        }
        protected override void OnInitialize()
        {
            var options = new DataflowBlockOptions() { EnsureOrdered = PreserverOrder };
            Block = new ActionBlock<Record>(WriteRecord);
        }

        protected override void OnStart()
        {
        }

        protected abstract Task WriteRecord(Record record);
    }
}
