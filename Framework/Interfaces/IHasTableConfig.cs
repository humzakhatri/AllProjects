using Framework.ConfigData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Interfaces
{
    public interface IHasTableConfig : IHasLayout
    {
        DbTableConfig TableConfig { get; set; }
    }
}
