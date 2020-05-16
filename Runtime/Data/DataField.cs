using Framework.Data;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Runtime.Data
{
    [DebuggerDisplay("{Name}=>{Value}")]
    public class DataField : IDataField
    {
        public string Value { get; set; }
        public MetaElement Meta { get; set; }
        public string Name { get => Meta.Name; set { throw new Exception("Should not set meta name from field."); } }
    }

    public class Record : List<DataField>
    {

    }
}
