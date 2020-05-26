using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData.Connection
{
    [Serializable]
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
