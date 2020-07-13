using DataAccess.Layouts;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Runtime.Flow_Processors.Destination
{
    internal class DbDestinationProcessorSqlServer : DbDestinationProcessorBase
    {
        public DbDestinationProcessorSqlServer(IConfigData configData, CancellationToken cancellationToken) : base(configData, cancellationToken)
        {
        }

        protected override void Write(Record record)
        {
            Writer.Write(record);
        }
    }
}
