using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Core.Packages.Persistence.Repositories.EntityFramework;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
