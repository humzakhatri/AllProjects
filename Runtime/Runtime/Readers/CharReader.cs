using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Runtime.Runtime.Readers
{
    public class CharReader : IDisposable
    {
        private TextReader Reader;
        public long count = 0;
        public char? Next = null;
        public bool EOF = false;
        public CharReader(TextReader reader)
        {
            Reader = reader;
        }

        public void ReadNext()
        {
            var read = Reader.Read();
            if (read == 0)
                EOF = true;
            else
                Next = (char)read;
        }

        public void Dispose()
        {
            Reader.Close();
            Reader.Dispose();
        }
    }
}
