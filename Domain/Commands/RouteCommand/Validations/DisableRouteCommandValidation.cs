using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.RouteCommand.Validations
{
    public class DisableRouteCommandValidation : RouteCommandValidation<DisableRouteCommand>
    {
        public DisableRouteCommandValidation() 
        {
            ValidateSwaggerID();
            ValidatePosition();
        }
    }
}
