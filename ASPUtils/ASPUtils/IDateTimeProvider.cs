using System;

namespace robcthegeek.ASPUtils
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}