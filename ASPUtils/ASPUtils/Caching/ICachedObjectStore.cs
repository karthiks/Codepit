namespace robcthegeek.ASPUtils.Caching
{
    public interface ICachedObjectStore<T>
    {
        bool ObjectCached { get; }
        T GetObject();
    }
}