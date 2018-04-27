﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core.Domain.Events
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public sealed class HandlesInlineAttribute : Attribute
    {
    }
}
