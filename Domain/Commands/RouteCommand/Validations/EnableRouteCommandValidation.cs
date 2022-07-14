using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.RouteCommand.Validations
{
    public class EnableRouteCommandValidation : RouteCommandValidation<EnableRouteCommand>
    {
        public EnableRouteCommandValidation()
        {
            ValidateSwaggerID();
            ValidatePosition();
        }
    }
}
