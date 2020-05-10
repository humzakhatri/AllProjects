using Framework.Data;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Data
{
    internal class DataField : INamed
    {
        public string Value { get; set; }
        public MetaElement Meta { get; set; }
        public string Name { get => Meta.Name; set { throw new Exception("Should not set meta name from field."); } }
    }

}
