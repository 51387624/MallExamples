﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core.Exception
{
    public class MallException:System.Exception
    {
        public MallException(string message)
           : base(message)
        {

        }
    }
}
