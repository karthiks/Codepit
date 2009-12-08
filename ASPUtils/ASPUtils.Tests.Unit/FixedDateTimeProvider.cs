using System;

namespace robcthegeek.ASPUtils.Tests.Unit
{
    public class FixedDateTimeProvider : IDateTimeProvider
    {
        public DateTime ReturnValue { get; set; }

        public FixedDateTimeProvider(DateTime returnValue)
        {
            ReturnValue = returnValue;
        }

        public DateTime Now
        {
            get { return ReturnValue; }
        }
    }
}
