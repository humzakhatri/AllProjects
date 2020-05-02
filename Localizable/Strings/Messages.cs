using System;
using System.Collections.Generic;
using System.Text;

namespace Localizable.Strings
{
    public static class Messages
    {
        public static LocalizableString MustProvideContentWithPutOrPost = new LocalizableString("Must provide content with Put Or Post.");
        public static LocalizableString CannotAddContentToGetOrDeleteMethods = new LocalizableString("Cannot add content to get or delete methods.");
        public static LocalizableString MethodNotSupported = new LocalizableString("Method not Supported");
        public static LocalizableString ValueCannotBeEmptyOrNull = new LocalizableString("Value cannot be empty or null");
    }
}
