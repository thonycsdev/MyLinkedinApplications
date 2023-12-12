using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Extensions
{
    public static class CheckJobApplicationEntity
    {
        public static void ThrowIfNull(this JobApplication entity, string? message = null)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), message);
        }
    }
}