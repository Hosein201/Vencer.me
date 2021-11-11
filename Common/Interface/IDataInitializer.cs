using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interface
{
    public interface IDataInitializer : IScopedDependency
    {
        void InitializeData();
    }
}
