using DataAccess.Layouts;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Runtime.Interfaces
{
    internal interface IHasTargetBlock : IHasBlock
    {
        ITargetBlock<Record> TargetBlock { get; }
        Task WaitingTask { get; }
    }
}
