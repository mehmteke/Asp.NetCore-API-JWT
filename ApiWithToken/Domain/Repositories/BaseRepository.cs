using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.Repositories
{
    public class BaseRepository
    {
        protected ApiWithTokenDBContext context;

        public BaseRepository(ApiWithTokenDBContext context)
        {
            this.context = context;
        }
    }
}
