using Common.Interface;
using Newtonsoft.Json;
using System;

namespace Common.Utilities
{
    public class JsonConvertCommon : IJsonConvertCommon
    {
        public string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public bool TryDeserializeObject<T>(string value)
        {
            try
            {
                JsonConvert.DeserializeObject<T>(value);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public T DeserializeObject<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
