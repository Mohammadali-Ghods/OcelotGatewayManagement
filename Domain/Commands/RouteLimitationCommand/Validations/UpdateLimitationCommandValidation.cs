using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.RouteLimitationCommand.Validations
{
    public class UpdateLimitationCommandValidation:RateLimitationCommandValidation<UpdateLimitationCommand>
    {
        public UpdateLimitationCommandValidation() 
        {
            ValidatePosition();
            ValidateSwaggerID();
        }
    }
}
