using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class GatewayViewModel
    {
        public List<RouteViewModel> Routes { get; set; }
        public List<SwaggerEndPoint> SwaggerEndPoints { get; set; }
        public GlobalConfiguration GlobalConfiguration { get; set; }
    }
    public class RouteViewModel 
    {
        public string DownstreamPathTemplate { get; set; }
        public string DownstreamScheme { get; set; }
        public DownstreamHostAndPorts DownstreamHostAndPorts { get; set; }
        public RateLimitOptions RateLimitOptions { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public string UpstreamHttpMethod { get; set; }
        public string SwaggerKey { get; set; }
    }
    public class SwaggerEndPoint 
    {
        public string Key { get; set; }
        public SwaggerConfig Config { get; set; }
    }
    public class GlobalConfiguration 
    {
        public string BaseUrl { get; set; }
    }
}
