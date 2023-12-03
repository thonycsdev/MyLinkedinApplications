using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.DTOs;

namespace Service.Extensions
{
    public static class CheckDataFromUserRequest
    {
        public static void CheckData(this UserRequest userRequest)
        {
            if (string.IsNullOrEmpty(userRequest.Name) || string.IsNullOrEmpty(userRequest.Email))
            {
                throw new ArgumentException("Name or Email is null or empty");
            }
            return;
        }
    }
}