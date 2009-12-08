using System;

namespace robcthegeek.ASPUtils.Caching
{
    public class CachedObject<T>
    {
        ICachedObjectStore<T> ObjectStore { get; set; }
        Func<T> RefreshDelegate { get; set; }
        public DateTime SlidingExpiration { get; private set; }

        private IDateTimeProvider dateTimeProvider;
        public IDateTimeProvider DateTimeProvider
        {
            get
            {
                if (dateTimeProvider == null)
                    dateTimeProvider = new SystemDateTimeProvider();
                return dateTimeProvider;
            }

            set
            {
                dateTimeProvider = value;
            }
        }

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

        public void SetSlidingExpiry(TimeSpan timeSpan)
        {
            // Add TimeSpan to Current DateTime and Set SlidingExpiration
            var newSlidingExpiration = dateTimeProvider.Now.Add(timeSpan);
            SlidingExpiration = newSlidingExpiration;
        }
    }
}