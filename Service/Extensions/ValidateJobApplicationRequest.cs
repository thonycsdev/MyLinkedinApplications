using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.DTOs.Requests;

namespace Service.Extensions
{
    public static class ValidateJobApplicationRequest
    {
        public static void ValidadeJobRequest(this JobApplicationRequest entity)
        {
            if (string.IsNullOrEmpty(entity.CompanyName))
                throw new Exception("Company name is required");

            if (string.IsNullOrEmpty(entity.Role))
                throw new Exception("Role is required");

            if (string.IsNullOrEmpty(entity.Status))
                throw new Exception("Status is required");

            if (string.IsNullOrEmpty(entity.Type))
                throw new Exception("Type is required");

            if (entity.UserId == 0)
                throw new Exception("UserId is required");
        }
    }
}