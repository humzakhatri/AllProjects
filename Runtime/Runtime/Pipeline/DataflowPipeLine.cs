using Framework.Document;
using Framework.Interfaces;
using Runtime.Data;
using Runtime.Interfaces;
using Runtime.Runtime.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Runtime.Runtime
{
    internal class DataflowPipeLine : RuntimeProcessorBase
    {
        public readonly DataflowDocument Document; //TODO: Add ability to have multiple sources
        private IHasSourceBlock Source;
        private IHasTargetBlock Destination;
        private List<IProcessor> FlowProcessors { get; set; } = new List<IProcessor>();
        public CancellationTokenSource CancellationTokenSource { get; private set; } = new CancellationTokenSource();
        public DataflowPipeLine(DataflowDocument document)
        {
            Document = document;
            CancellationTokenSource = new CancellationTokenSource();
        }
        protected override void OnInitialize()
        {
            IConfigData config = Document.Source;
            var source = FlowProcessorFactory.CreateSource(config as ISourceConfigData, CancellationTokenSource.Token);
            FlowProcessors.Add(source);
            source.Initialize();
            Source = source as IHasSourceBlock;
            var prev = Source;
            config = config.Next;
            while (true)
            {
                var processor = FlowProcessorFactory.Create(config, CancellationTokenSource.Token);
                processor.Initialize();
                prev.LinkTo(processor as IHasTargetBlock);
                prev = processor as IHasSourceBlock;
                FlowProcessors.Add(processor);
                if (config?.ConfigType == ConfigType.Destination)
                {
                    Destination = processor as IHasTargetBlock;
                    break;
                }
                config = config.Next;
            }
        }

        protected override void OnStart()
        {
            try
            {
                Parallel.ForEach(FlowProcessors, p => p.Start());
                Destination.WaitingTask.Wait();
                CloseAll();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Source.Close();
            }
        }

        private void CloseAll()
        {
            Parallel.ForEach(FlowProcessors, p => p.Close());
        }
    }
}
