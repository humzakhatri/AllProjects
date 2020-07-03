﻿using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Database
{
    [AttributeUsage(AttributeTargets.Property)]
    public class IdentityAttribute : Attribute, IDbFieldConstraint
    {
        public string Constraint => "IDENTITY";
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NotNullAttribute : Attribute, IDbFieldConstraint
    {
        public string Constraint => "NOT NULL";
    }

    public class NVarCharAttribute : Attribute , IDbFieldType
    {
        public readonly int Length;
        public NVarCharAttribute(int length)
        {
            Length = length;
        }

        public string Datatype => $"NVARCHAR({Length})";
    }

    public class NTextAttribute : Attribute, IDbFieldType
    {
        public string Datatype => $"NTEXT";
    }
}
