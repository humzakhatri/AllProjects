using Runtime.Data;
using Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;

namespace Runtime.Runtime
{
    internal class DataflowPipeLine : RuntimeProcessorBase
    {
        public readonly IHasSourceBlock Source; //TODO: Add ability to have multiple sources
        public DataflowPipeLine(IHasSourceBlock source)
        {
            Source = source;
        }
        protected override void OnInitialize()
        {
            throw new NotImplementedException();
        }

        protected override void OnStart()
        {
            throw new NotImplementedException();
        }
    }
}
