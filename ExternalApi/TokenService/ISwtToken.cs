using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApi.TokenService
{
    public interface ISwtToken
    {
        string JwtGenerator();
    }
}
