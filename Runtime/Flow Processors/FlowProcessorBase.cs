using Framework.Interfaces;
using Runtime.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Flow_Processors
{
    public abstract class FlowProcessorBase : RuntimeProcessorBase
    {
        public FlowProcessorBase(IConfigData configData)
        {

        }
        public bool PreserverOrder { get; set; } = true;
    }
}
