using System;

namespace robcthegeek.ASPUtils.Caching
{
    public class CachedObject<T>
    {
        ICachedObjectStore<T> ObjectStore { get; set; }
        Func<T> RefreshDelegate { get; set; }

        public T Data
        {
            get
            {
                if (ObjectStore.ObjectCached)
                    return ObjectStore.GetObject();
                
                return RefreshDelegate();
            }
        }


        public CachedObject(ICachedObjectStore<T> objectStore, Func<T> refreshDelegate)
        {
            ObjectStore = objectStore;
            RefreshDelegate = refreshDelegate;
        }

        public void Refresh()
        {
            // Implement
        }
    }
}