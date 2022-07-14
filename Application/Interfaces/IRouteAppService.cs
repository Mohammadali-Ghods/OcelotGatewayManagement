using Application.ViewModel;
using Application.ViewModel.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRouteAppService : IDisposable
    {
        Task<ResultModel> Insert(RouteInsertUpdateModel input);
        Task<ResultModel> Update(RouteInsertUpdateModel input);
        Task<ResultModel> Delete(RouteIDPositionModel input);
        Task<ResultModel> Enable(RouteIDPositionModel input);
        Task<ResultModel> Disable(RouteIDPositionModel input);
    }
}
