using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core
{
    public interface IPersistedVersionSetter
    {
        #region Public Properties

        long PersistedVersion { set; }

        #endregion Public Properties
    }
}
