using System;
using robcthegeek.ASPUtils.Caching;
using Xunit;

namespace robcthegeek.ASPUtils.Tests.Unit.Caching
{
    public class InMemoryObjectCache : ICachedObjectStore<string>
    {
        private string data;

        public InMemoryObjectCache()
        {

        }

        public InMemoryObjectCache(string startupData)
        {
            data = startupData;
        }

        public bool ObjectCached
        {
            get { return !string.IsNullOrEmpty(data); }
        }

        public string GetObject()
        {
            return data;
        }
    }

    public class DummyRefreshService
    {
        public bool RefreshCalled { get; private set; }
        public string ReturnValue { get; set; }

        public DummyRefreshService()
        {
            RefreshCalled = false;
        }

        public string Refresh()
        {
            RefreshCalled = true;
            return ReturnValue;
        }
    }

    public class CachedObjectTests
    {
        readonly DummyRefreshService refreshService = new DummyRefreshService();

        CachedObject<string> CreateWithEmptyCache()
        {
            var cache = new CachedObject<string>(
                new InMemoryObjectCache(), refreshService.Refresh);
            return cache;
        }

        CachedObject<string> CreateWithPopulatedCache()
        {
            var cache = new CachedObject<string>(
                new InMemoryObjectCache("Existing Data"), refreshService.Refresh);
            return cache;
        }

        CachedObject<string> SetupDateTimeProvider(CachedObject<string> cache, DateTime dateTime)
        {
            var provider = new FixedDateTimeProvider(dateTime);
            cache.DateTimeProvider = provider;
            return cache;
        }

        [Fact]
        public void Data_Ctor_CallsRefresh()
        {
            var cache = CreateWithEmptyCache();
            var data = cache.Data;
            Assert.True(refreshService.RefreshCalled);
        }

        [Fact]
        public void Data_DataChanged_ReturnsDataFromRefreshMethod()
        {
            refreshService.ReturnValue = "New Data";
            var cache = CreateWithEmptyCache();
            var data = cache.Data;
            Assert.Equal("New Data", data);
        }

        [Fact]
        public void Data_EmptyObjectCache_CallsRefresh()
        {
            var cache = CreateWithEmptyCache();
            var data = cache.Data;
            Assert.True(refreshService.RefreshCalled);
        }

        [Fact]
        public void Data_PopulatedObjectCache_ReturnsCachedData()
        {
            var cache = CreateWithPopulatedCache();
            var data = cache.Data;
            Assert.Equal("Existing Data", data);
        }

        [Fact]
        public void Data_RefreshedObjectCache_ReturnsRefreshValue()
        {
            refreshService.ReturnValue = "Refreshed";
            var cache = CreateWithEmptyCache();
            cache.Refresh();
            var data = cache.Data;
            Assert.Equal("Refreshed", data);
        }

        [Fact]
        public void SetSlidingExpiry_TwoMinuteTimeSpan_SlidingExpirationTimeTwoMinutesFromCurrentTime()
        {
            var expectedExpiration = new DateTime(2009, 12, 08, 20, 0, 0);
            var cache = CreateWithEmptyCache();
            SetupDateTimeProvider(cache, new DateTime(2009, 12, 08, 19, 58, 0));
            cache.SetSlidingExpiry(new TimeSpan(0, 0, 2, 0));
            Assert.Equal(expectedExpiration, cache.SlidingExpiration);
        }

        [Fact]
        public void GetData_WithinSlidingExpiration_SlidingExpirationTimeShifts()
        {
            var expectedExpiration = new DateTime(2009, 12, 08, 20, 0, 0);
            var cache = CreateWithEmptyCache();
            SetupDateTimeProvider(cache, new DateTime(2009, 12, 08, 19, 58, 0));
            cache.SetSlidingExpiry(new TimeSpan(0, 0, 2, 0));
        }
        // TODO: Add Sliding Expiry
        // - When We Get Data, Sliding Expiration Should be Reset.
        // - Get Data After Sliding Expiration then Refresh Should be Called.
        
        // TODO: Add Absolute Expiry
        // TODO: Add Repeating Expiry
    }
}