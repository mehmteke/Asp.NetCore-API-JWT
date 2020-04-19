using ApiWithToken.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiWithTokenDBContext context;
        public UnitOfWork(ApiWithTokenDBContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
           await context.SaveChangesAsync();
        }
    }
}
