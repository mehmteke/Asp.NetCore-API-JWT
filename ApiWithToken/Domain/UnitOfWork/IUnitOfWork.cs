using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWithToken.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
