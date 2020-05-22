using Framework.Interfaces;
using Runtime.Flow_Processors;
using Runtime.Flow_Processors.Destination;
using Runtime.Flow_Processors.Source;
using Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Runtime.Pipeline
{
    internal static class FlowProcessorFactory
    {
        internal static IHasBlock Create(IConfigData configData)
        {
            switch (configData.ConfigType)
            {
                case ConfigType.Source:
                    return CreateSource(configData as ISourceConfigData);
                case ConfigType.Destination:
                    return CreateTarget(configData as ITargetConfigData);
                default:
                    throw new Exception("Invalid ConfigType");
            }
        }

        internal static IHasSourceBlock CreateSource(ISourceConfigData configData)
        {
            switch (configData.SourceConfigType)
            {
                case SourceConfigType.Delimited:
                    return new DelimitedSourceProcessor(configData);
                default:
                    throw new Exception("The type doesn't have a curresponding processor.");
            }
        }

        internal static IHasTargetBlock CreateTarget(ITargetConfigData configData)
        {
            switch (configData.TargetConfigType)
            {
                case TargetConfigType.Delimited:
                    return new DelimitedDestinationProcessor(configData);
                default:
                    throw new Exception("The type doesn't have a curresponding processor.");
            }
        }
    }
}
