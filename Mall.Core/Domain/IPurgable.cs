using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core
{
    /// <summary>
    /// 聚合清理
    /// </summary>
    public interface IPurgable
    {
        void Purge();
    }
}
