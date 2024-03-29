﻿using DataAccess.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Interfaces
{
    public interface IReader : IDisposable
    {
        IEnumerable<Record> Read();
    }
}
