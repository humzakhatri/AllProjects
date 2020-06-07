using DataAccess.Layouts;
using Framework.Interfaces;
using Runtime.Blocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Runtime.Flow_Processors.Source
{
    internal abstract class DbSourceProcessorBase : DataflowSourceProcessorBase
    {
        public DbSourceProcessorBase(IConfigData configData, CancellationToken cancellationToken) : base(configData, cancellationToken)
        {
        }

        protected abstract override IEnumerable<Record> GetRecords();
    }
}
