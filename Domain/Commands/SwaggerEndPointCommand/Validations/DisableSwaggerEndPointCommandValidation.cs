using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.SwaggerEndPointCommand.Validations
{
    public class DisableSwaggerEndPointCommandValidation : SwaggerEndPointValidations<DisableSwaggerEndPointCommand>
    {
        public DisableSwaggerEndPointCommandValidation() 
        {
            ValidateID();
        }
    }
}
