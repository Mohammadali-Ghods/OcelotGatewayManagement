using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.RouteLimition
{
    public class RouteLimitationInsertUpdateModel
    {
        public string Period { get;  set; }
        public int PeriodTimeSpan { get;  set; }
        public int Limit { get;  set; }
        public string SwaggerID { get; set; }
        public int Position { get; set; }
    }
}
