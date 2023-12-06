using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Interfaces;
using Service.DTOs.Requests;
using Service.DTOs.Responses;
using Service.Extensions;
using Service.Interfaces;

namespace Service
{
    public class JobApplicationService : IJobApplicationService
    {
        private readonly IJobApplicationRepository _jobApplicationRepository;
        public JobApplicationService(IJobApplicationRepository jobApplicationRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
        }
        public Task<JobApplicationResponse> CreateAsync(JobApplicationRequest entity)
        {
            entity.ValidadeJobRequest();
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JobApplicationResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<JobApplicationResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JobApplicationResponse> UpdateAsync(JobApplicationRequest entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}