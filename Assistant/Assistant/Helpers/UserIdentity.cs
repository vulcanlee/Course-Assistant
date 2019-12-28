using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Assistant.Helpers
{
    public class UserIdentity
    {
        public int GetNameIdentity(ClaimsPrincipal claimsIdentity)
        {
            int id = -1;
            var userId = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if(userId!=null)
            {
                id = Convert.ToInt32(userId.Value);
            }
            return id;
        }
    }
}
