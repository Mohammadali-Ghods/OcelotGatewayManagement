
namespace Domain.Commands.SwaggerEndPointCommand.Validations
{
    public class InsertSwaggerEndPointCommandValidation : SwaggerEndPointValidations<InsertSwaggerEndPointCommand>
    {
        public InsertSwaggerEndPointCommandValidation()
        {
            ValidateID();
        }
    }
}
