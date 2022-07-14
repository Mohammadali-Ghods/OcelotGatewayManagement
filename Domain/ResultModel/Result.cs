using Domain.Models;
using FluentValidation.Results;

namespace Domain.ResultModel
{
    public class Result
    {
        public  ValidationResult FailedResults { get; set; }
    }

  
}
