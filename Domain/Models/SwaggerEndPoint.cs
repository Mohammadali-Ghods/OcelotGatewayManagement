using Domain.ValueObject;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SwaggerEndPoint:Entity
    {
        public SwaggerEndPoint(string id, string swaggername,string swaggerversion,string swaggerurl)
        {
            ID= id;
            Config = new SwaggerConfig(swaggername,swaggerversion,swaggerurl);
            LastStatus = new LastStatus(Status.Enabled);
            Routes = new List<Route>();
        }

        public SwaggerConfig Config { get; private set; }
        public LastStatus LastStatus { get; private set; }
        public List<Route> Routes { get; private set; }
        public void Disable() => LastStatus = new LastStatus(Status.DisabledByAdmin);
        public void Enable() => LastStatus = new LastStatus(Status.Enabled);
        public void UpdateConfig(string name, string version, string url) => Config = 
            new SwaggerConfig(name, version, url);
    }
}
