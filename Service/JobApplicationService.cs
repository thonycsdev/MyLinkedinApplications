using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Repository.Interfaces;
using Service.DTOs.Requests;
using Service.DTOs.Responses;
using Service.Enums;
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
        public async Task<JobApplicationResponse> CreateAsync(JobApplicationRequest entity)
        {
            var validatedEntity = entity.ValidadeJobRequest();
            await _jobApplicationRepository.Create(new JobApplication());
            var response = new JobApplicationResponse
            {
                CompanyName = validatedEntity.CompanyName,
                Role = validatedEntity.Role,
                Status = (Status)validatedEntity.Status!,
                User = new User(),
                Type = (Types)validatedEntity.Type!,
            };
            return response;

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