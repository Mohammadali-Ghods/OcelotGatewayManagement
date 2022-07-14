using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{
    public class RateLimitOptions
    {
        public RateLimitOptions(string period,int periodtimespan,int limit)
        {
            ClientWhitelist = new string[0];
            EnableRateLimiting = true;
            Period = period;
            PeriodTimespan=periodtimespan;
            Limit = limit;
        }
        public string[] ClientWhitelist { get; private set; }
        public bool EnableRateLimiting { get; private set; }
        public string Period { get; private set; }
        public int PeriodTimespan { get; private set; }
        public int Limit { get; private set; }
    }
}
