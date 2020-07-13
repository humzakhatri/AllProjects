using DataAccess.Writer;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using DataAccess.Writers.Database;
using Framework.ConfigData;
using System.Threading.Tasks;
using DataAccess.Layouts;

namespace Runtime.Flow_Processors.Destination
{
    internal abstract class DbDestinationProcessorBase : DataflowDestinationProcessorBase
    {
        protected readonly DbWriterBase Writer;
        protected readonly DestinationDbConfigData Config;
        protected DbDestinationProcessorBase(IConfigData configData, CancellationToken cancellationToken) : base(configData, cancellationToken)
        {
            Config= (DestinationDbConfigData)configData;
            Writer = new DbWriterBase(Config);
        }

        protected override void OnStart()
        {
            if (Config.CreateTable)
                Writer.CreateTable();
            base.OnStart();
        }
    }
}
