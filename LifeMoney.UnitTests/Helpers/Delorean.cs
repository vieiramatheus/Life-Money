using LifeMoney.Domain.Horology;
using System;

namespace LifeMoney.UnitTests
{
    public class Delorean
    {
        public static void TravelTo(DateTime dateTime)
        {
            SpaceTime.This = new TravelSpaceTime(dateTime);
        }

        public static void FreezeTime()
        {
            SpaceTime.This = new TravelSpaceTime(DateTime.Now);
        }

        private class TravelSpaceTime : SpaceTime
        {
            private readonly DateTime _dateTime;

            public TravelSpaceTime(DateTime dateTime)
            {
                _dateTime = dateTime;
            }

            public override DateTime Today => _dateTime;
            public override DateTime Now => _dateTime;
            public override DateTime UtcNow => _dateTime;
        }
    }
}
