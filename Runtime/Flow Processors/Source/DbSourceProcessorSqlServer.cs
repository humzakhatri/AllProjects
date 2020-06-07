using DataAccess.Layouts;
using DataAccess.Readers.Database;
using Framework.ConfigData;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Runtime.Flow_Processors.Source
{
    internal class DbSourceProcessorSqlServer : DbSourceProcessorBase
    {
        private readonly DbReaderBase Reader;
        public DbSourceProcessorSqlServer(IConfigData configData, CancellationToken cancellationToken) : base(configData, cancellationToken)
        {
            var dbConfigData = configData as DbSourceConfigBase;
            Reader = new DbReaderBase(dbConfigData, dbConfigData.Layout);
        }

        protected override IEnumerable<Record> GetRecords()
        {
            return Reader.Read();
        }
    }
}
