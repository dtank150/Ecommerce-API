using API.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
