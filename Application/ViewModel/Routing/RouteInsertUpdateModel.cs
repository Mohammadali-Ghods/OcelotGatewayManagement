using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Routing
{
    public class RouteInsertUpdateModel
    {
        public string DownstreamPathTemplate { get; set; }
        public string DownstreamScheme { get; set; }
        public string DownstreamHost { get; set; }
        public int DownstreamPort { get; set; }
        public string UpstreamPathTemplate { get; set; }
        public string UpstreamHttpMethod { get; set; }
        public string SwaggerID { get; set; }
        public int Position { get; set; }
    }
}
