using Application.ViewModel;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace API.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected string[] GetAccessingStoresFromJWTToken()
        {
            string accessingstoresstring = "";

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                accessingstoresstring = claims.ToList()
                    .Where(x => x.Type ==
                    "http://schemas.xmlsoap.org/ws/2009/09/identity/claims/accessigstores")
                    .Select(x => x.Value).FirstOrDefault();
            }

            return accessingstoresstring.Split(',');
        }
        protected string GetRoleFromJWTToken()
        {
            string role = "";

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                role = claims.ToList()
                    .Where(x => x.Type ==
                    "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                    .Select(x => x.Value).FirstOrDefault();
            }

            return role;
        }
        protected ActionResult<ResultModel> CustomResponse(ResultModel result,bool finalstep)
        {
            if (IsOperationValid())
            {
                result.FailedResults = new ValidationResult();
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected ActionResult<ResultModel> CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse(new ResultModel(),true);
        }

        protected ActionResult<ResultModel> CustomResponse(ResultModel Result)
        {
            if (Result.FailedResults != null) 
            {
                foreach (var error in Result.FailedResults.Errors)
                {
                    AddError(error.ErrorMessage);
                }
            }

            return CustomResponse(Result,true);
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}
