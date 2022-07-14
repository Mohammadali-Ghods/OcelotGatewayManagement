using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.RouteCommand.Validations
{
    public class UpdateRouteCommandValidation : RouteCommandValidation<UpdateRouteCommand>
    {
        public UpdateRouteCommandValidation() 
        {
            ValidateDownStreamPathTemplate();
            ValidateDownstreamPort();
            ValidateDownStreamScheme();
            ValidateUpStreamHttpMethod();
            ValidateUpStreamPathTemplate();
            ValidateSwaggerID();
            ValidatePosition();
        }
    }
}
