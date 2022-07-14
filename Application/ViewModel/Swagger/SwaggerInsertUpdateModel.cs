using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.Swagger
{
    public class SwaggerInsertUpdateModel
    {
        public string SwaggerID { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Url { get; set; }
    }
}
