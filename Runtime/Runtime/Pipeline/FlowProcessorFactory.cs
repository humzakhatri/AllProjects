using Framework.Interfaces;
using Runtime.Flow_Processors;
using Runtime.Flow_Processors.Destination;
using Runtime.Flow_Processors.Source;
using Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Runtime.Runtime.Pipeline
{
    internal static class FlowProcessorFactory
    {
        internal static RuntimeProcessorBase Create(IConfigData configData, CancellationToken cancellationToken)
        {
            switch (configData.ConfigType)
            {
                case ConfigType.Source:
                    return CreateSource(configData as ISourceConfigData, cancellationToken);
                case ConfigType.Destination:
                    return CreateTarget(configData as ITargetConfigData, cancellationToken);
                default:
                    throw new Exception("Invalid ConfigType");
            }
        }

        internal static RuntimeProcessorBase CreateSource(ISourceConfigData configData, CancellationToken cancellationToken)
        {
            switch (configData.SourceConfigType)
            {
                case SourceConfigType.Delimited:
                    return new DelimitedSourceProcessor(configData, cancellationToken);
                default:
                    throw new Exception("The type doesn't have a curresponding processor.");
            }
        }

        internal static RuntimeProcessorBase CreateTarget(ITargetConfigData configData, CancellationToken cancellationToken)
        {
            switch (configData.TargetConfigType)
            {
                case TargetConfigType.Delimited:
                    return new DelimitedDestinationProcessor(configData, cancellationToken);
                default:
                    throw new Exception("The type doesn't have a curresponding processor.");
            }
        }
    }
}
