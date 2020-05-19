using Runtime.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Flow_Processors
{
    public abstract class FlowProcessorBase : RuntimeProcessorBase
    {
        public bool PreserverOrder { get; set; } = true;
    }
}
