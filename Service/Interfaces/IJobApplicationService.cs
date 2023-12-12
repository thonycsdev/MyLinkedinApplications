using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.DTOs.Requests;
using Service.DTOs.Responses;

namespace Service.Interfaces
{
    public interface IJobApplicationService : IBaseService<JobApplicationResponse, JobApplicationRequest>
    {
        Task<JobApplicationResponse> UpdateJobApplicationStatus(int jobApplicationId, int jobApplicaionStatusEnumNumber);
    }
}