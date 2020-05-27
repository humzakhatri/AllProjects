using Framework.Document;
using Runtime.Flow_Processors.Source;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace Runtime.Runtime.Pipeline
{
    public class FlowExecuter
    {
        public void Execute(DataflowDocument dataFlow)
        {
            try
            {
                var tokenSource = new CancellationTokenSource();
                var chain = new DataflowPipeLine(dataFlow);
                chain.Initialize();
                chain.Start();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
