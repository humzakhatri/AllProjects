using DataAccess.Database;
using Framework.Authentication;
using Framework.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Persister
{
    public class KUserPersister : DbPersisterBase<KUser>
    {
        public KUser GetWithID(long id)
        {
            return GetWithPropertyValue(nameof(KUser.Id), id);
        }

        public KUser GetWithEmail(string email)
        {
            return GetWithPropertyValue(nameof(KUser.Email), email);
        }

        public KUser GetWithUserName(string userName)
        {
            return GetWithPropertyValue(nameof(KUser.UserName), userName);
        }
    }
}
