using Runtime.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Runtime.Interfaces
{
    interface IHasSourceBlock
    {
        ISourceBlock<Record> SourceBlock { get; }
        void LinkTo(IHasTargetBlock targetBlock);
    }
}
