using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Framework.Data
{
    [DebuggerDisplay("{Name}")]
    public class MetaElement : INamed
    {
        public string Name { get; set; }
        public string DefaultValue { get; set; }
    }
}
