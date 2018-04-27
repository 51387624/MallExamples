using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core
{
    /// <summary>
    /// 版本设置器
    /// </summary>
    public interface IPersistedVersionSetter
    {
        long PersistedVersion { set; }
    }
}
