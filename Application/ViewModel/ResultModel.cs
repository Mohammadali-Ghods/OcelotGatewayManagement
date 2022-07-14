using Domain.Models;
using FluentValidation.Results;

namespace Application.ViewModel
{
    public class ResultModel
    {
        public ValidationResult FailedResults { get; set; }
        public string FinalJson { get; set; }
    }
}
