using System;

namespace robcthegeek.ASPUtils
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}