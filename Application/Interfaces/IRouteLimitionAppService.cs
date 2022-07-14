using Application.ViewModel;
using Application.ViewModel.RouteLimition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRouteLimitionAppService : IDisposable
    {
        Task<ResultModel> Update(RouteLimitationInsertUpdateModel input);
    }
}
