using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.RouteCommand.Validations
{
    public class InsertNewRouteCommandValidation:RouteCommandValidation<InsertNewRouteCommand>
    {
        public InsertNewRouteCommandValidation() 
        {
            ValidateDownStreamPathTemplate();
            ValidateDownstreamPort();
            ValidateDownStreamScheme();
            ValidateUpStreamHttpMethod();
            ValidateUpStreamPathTemplate();
            ValidateSwaggerID();
        }
    }
}
