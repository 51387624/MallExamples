using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core
{
    /// <summary>
    /// 实体
    /// </summary>
    public interface IEntity<TKey>
         where TKey : IEquatable<TKey>
    {
        TKey Id { get; }
    }
}
