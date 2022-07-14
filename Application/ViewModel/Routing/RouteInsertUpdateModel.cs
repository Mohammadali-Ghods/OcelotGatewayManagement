using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Routing
{
    public class RouteInsertUpdateModel
    {
        public string DownstreamPathTemplate { get; protected set; }
        public string DownstreamScheme { get; protected set; }
        public string DownstreamHost { get; protected set; }
        public int DownstreamPort { get; protected set; }
        public string UpstreamPathTemplate { get; protected set; }
        public string UpstreamHttpMethod { get; protected set; }
        public string SwaggerID { get; protected set; }
        public int Position { get; protected set; }
    }
}
