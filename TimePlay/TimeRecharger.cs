using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimePlay
{
    public class TimeRecharger
    {
        public long _timestamp;
        public long _Now {
            get { return GetEpoch(DateTimeOffset.UtcNow); }
        }

        public TimeRecharger() 
        {
            //new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var datetime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var dateWithOffset = new DateTimeOffset(datetime).ToUniversalTime();
            _timestamp = dateWithOffset.ToUnixTimeMilliseconds();
        }
        const double MAX_ENERGY = 100;
        const long RECHARGE_CYCLE = 60000;//1000 = 1초

        public int remain_energy = 0;
        public long remaining_time_to_full = 0;
        public long remaining_time_to_one = 0;

        public long GetEpoch(DateTimeOffset date)
        {
            var dateWithOffset = date.ToUniversalTime();
            return dateWithOffset.ToUnixTimeMilliseconds();
        }
        public long GetEpoch(DateTime date)
        {
            var dateWithOffset = new DateTimeOffset(date).ToUniversalTime();
            return dateWithOffset.ToUnixTimeMilliseconds();
        }
        public int GetEnergy()
        {
            var epochNow = GetEpoch(DateTimeOffset.UtcNow);

            double energy = ((epochNow - _timestamp) / RECHARGE_CYCLE);
            energy = MAX_ENERGY <= energy ? MAX_ENERGY : energy;

            remaining_time_to_full = (long)(MAX_ENERGY <= energy ?
                0 : RECHARGE_CYCLE * MAX_ENERGY - (epochNow - _timestamp));
            remaining_time_to_one = remaining_time_to_full % RECHARGE_CYCLE;
            bool a = remaining_time_to_full != 0;
            bool b = remaining_time_to_one != 0;

            remaining_time_to_one = a && !b?
                RECHARGE_CYCLE : remaining_time_to_full % RECHARGE_CYCLE;

            remain_energy = (int)energy;
            return (int)energy;
        }

        public void SpendEnergy()
        {
            var epochNow = GetEpoch(DateTimeOffset.UtcNow);

            double energy = ((epochNow - _timestamp) / RECHARGE_CYCLE);
            energy = MAX_ENERGY <= energy ? MAX_ENERGY : energy;

            _timestamp = (long)(MAX_ENERGY == energy ?
                epochNow - RECHARGE_CYCLE * (MAX_ENERGY - 1) :
                _timestamp + RECHARGE_CYCLE * 1);
        }
    }
}
