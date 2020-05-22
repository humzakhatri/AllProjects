using Framework.Interfaces;
using Runtime.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Runtime.Interfaces
{
    internal interface IHasSourceBlock : IHasBlock
    {
        ISourceBlock<Record> SourceBlock { get; }
        void LinkTo(IHasTargetBlock targetBlock);
    }
}
