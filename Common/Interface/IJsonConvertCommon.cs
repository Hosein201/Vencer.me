namespace Common.Interface
{
    public interface IJsonConvertCommon
    {
        string SerializeObject(object value);
        bool TryDeserializeObject<T>(string value);
        T DeserializeObject<T>(string value);
    }
}
