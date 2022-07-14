using Domain.ValueObject;
using MongoDB.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Route
    {
        public Route(string downstreampathtemplate,string downstreamscheme,string downstreamhost,
            int downstreamport,string upstreampathtemplate,string upstreamhttpmethod)
        {
            DownstreamPathTemplate = downstreampathtemplate;
            DownstreamScheme= downstreamscheme;
            DownstreamHostAndPorts = new DownstreamHostAndPorts(downstreamhost, downstreamport);
            UpstreamPathTemplate = upstreampathtemplate;
            UpstreamHttpMethod = upstreamhttpmethod;
            LastStatus = new LastStatus(Status.Enabled);
        }
        public string DownstreamPathTemplate { get; private set; }
        public string DownstreamScheme { get; private set; }
        public DownstreamHostAndPorts DownstreamHostAndPorts { get; private set; }
        public RateLimitOptions RateLimitOptions { get; private set; }
        public string UpstreamPathTemplate { get; private set; }
        public string UpstreamHttpMethod { get; private set; }
        public LastStatus LastStatus { get; private set; }

        public void Disable() => LastStatus = new LastStatus(Status.DisabledByAdmin);
        public void Enable() => LastStatus = new LastStatus(Status.Enabled);
        public void UpdateDownstreamPathTemplate(string newvalue)=> DownstreamPathTemplate=newvalue;
        public void UpdateDownstreamScheme(string newvalue) => DownstreamScheme = newvalue;
        public void UpdateUpstreamPathTemplate(string newvalue) => UpstreamPathTemplate = newvalue;
        public void UpdateUpstreamHttpMethod(string newvalue) => UpstreamHttpMethod = newvalue;
        public void UpdateDownstreamHostAndPorts(string newhost, int newport) =>
            DownstreamHostAndPorts = new DownstreamHostAndPorts(newhost, newport);
        public void UpdateRateLimitOptions(string newperiod, int periodtimespan, int limit) =>
            RateLimitOptions = new RateLimitOptions(newperiod, periodtimespan, limit);
    }

}
