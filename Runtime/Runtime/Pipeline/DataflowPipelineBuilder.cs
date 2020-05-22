using Framework.Document;
using Framework.Interfaces;
using Microsoft.VisualBasic;
using Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Runtime.Runtime.Pipeline
{
    internal class DataflowPipelineBuilder
    {
        private readonly DataflowDocument Document;
        public IHasSourceBlock Source { get; set; }
        internal DataflowPipelineBuilder(DataflowDocument document)
        {
            Document = document;
        }

        public void Build()
        {
            IConfigData config = Document.Source;
            Source = FlowProcessorFactory.CreateSource(config as ISourceConfigData);
            var prev = Source;
            config = config.Next;
            while (config?.ConfigType != ConfigType.Destination)
            {
                var processor = FlowProcessorFactory.Create(config);
                prev.LinkTo(processor as IHasTargetBlock);
                prev = processor as IHasSourceBlock;
            }
        }
    }
}
