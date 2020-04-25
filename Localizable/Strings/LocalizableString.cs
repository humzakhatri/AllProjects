using System;
using System.Collections.Generic;
using System.Text;

namespace Localizable.Strings
{
    public class LocalizableString
    {
        public LocalizableString(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
    }
}
