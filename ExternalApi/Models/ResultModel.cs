using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApi.Models
{
    public class ResultModel
    {
        public bool SucceedResult { get; set; }
        public ValidationResult FailedResults { get; set; }
    }
}
