using Framework.Interfaces;
using Runtime.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Runtime.Flow_Processors
{
    public abstract class FlowProcessorBase : RuntimeProcessorBase
    {
        protected readonly CancellationToken CancellationToken;
        public FlowProcessorBase(IConfigData configData, CancellationToken cancellationToken)
        {
            CancellationToken = cancellationToken;
        }
        public bool PreserverOrder { get; set; } = false;

        public override void Dispose()
        {
            Close();
            base.Dispose();
        }
    }
}
