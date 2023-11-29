using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {

    }
}