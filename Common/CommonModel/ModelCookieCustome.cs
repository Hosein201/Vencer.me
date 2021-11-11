using System;
using System.Collections.Generic;
using System.Text;

namespace Common.CommonModel
{
    public class ModelCookieCustome
    {
        public int Expire { get; set; }
        public string TypeCookie { get; set; }
        public dynamic Data { get; set; }
    }
}
