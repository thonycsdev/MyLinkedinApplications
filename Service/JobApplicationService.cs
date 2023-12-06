using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public JobApplicationService(IJobApplicationRepository jobApplicationRepository, IMapper mapper)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _mapper = mapper;
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

        public async Task DeleteAsync(int id)
        {
            await _jobApplicationRepository.Delete(id);
        }

        public async Task<IEnumerable<JobApplicationResponse>> GetAllAsync()
        {
            var results = await _jobApplicationRepository.GetValues();
            return _mapper.Map<IEnumerable<JobApplicationResponse>>(results);
        }

        public async Task<JobApplicationResponse> GetByIdAsync(int id)
        {
            var result = await _jobApplicationRepository.GetById(id);
            return _mapper.Map<JobApplicationResponse>(result);
        }

        public async Task<JobApplicationResponse> UpdateAsync(JobApplicationRequest entity, int id)
        {
            var oldJobApplication = await _jobApplicationRepository.GetById(id);
            var entityWithNewInformation = entity.ValidadeJobRequest();
            oldJobApplication.CompanyName = entityWithNewInformation.CompanyName;
            oldJobApplication.Role = entityWithNewInformation.Role;
            oldJobApplication.Status = (Status)entityWithNewInformation.Status!;
            oldJobApplication.Type = (Types)entityWithNewInformation.Type!;
            await _jobApplicationRepository.Update(oldJobApplication);
            return _mapper.Map<JobApplicationResponse>(oldJobApplication);

        }
    }
}