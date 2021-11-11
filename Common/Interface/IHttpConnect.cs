using Common.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace Common.Interface
{
    public interface IHttpConnect
    {
        T Connecting<T>(string Url, ConnectType connectType, NameValueCollection Header, object Data);
    }
}
