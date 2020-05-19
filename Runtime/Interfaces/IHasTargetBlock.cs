using Runtime.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Runtime.Interfaces
{
    interface IHasTargetBlock
    {
        ITargetBlock<Record> TargetBlock { get; }
    }
}
