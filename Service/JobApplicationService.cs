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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public JobApplicationService(IJobApplicationRepository jobApplicationRepository, IMapper mapper, IUserRepository userRepository)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<JobApplicationResponse> CreateAsync(JobApplicationRequest entity)
        {
            var validatedEntity = entity.ValidadeJobRequest();
            var user = await _userRepository.GetById(validatedEntity.UserId);
            await _jobApplicationRepository.Create(_mapper.Map<JobApplication>(entity));
            var response = new JobApplicationResponse
            {
                CompanyName = validatedEntity.CompanyName,
                Role = validatedEntity.Role,
                Status = (Status)validatedEntity.Status!,
                User = _mapper.Map<UserResponse>(user),
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
            var result = await FindJobApplicationById(id);
            return _mapper.Map<JobApplicationResponse>(result);
        }

        public async Task<JobApplicationResponse> UpdateAsync(JobApplicationRequest entity, int id)
        {
            var oldJobApplication = await FindJobApplicationById(id);
            var entityWithNewInformation = entity.ValidadeJobRequest();

            oldJobApplication.CompanyName = entityWithNewInformation.CompanyName;
            oldJobApplication.Role = entityWithNewInformation.Role;
            oldJobApplication.Status = (Status)entityWithNewInformation.Status!;
            oldJobApplication.Type = (Types)entityWithNewInformation.Type!;

            await UpdateAndSaveJobApplication(oldJobApplication);
            return _mapper.Map<JobApplicationResponse>(oldJobApplication);

        }

        public async Task<JobApplicationResponse> UpdateJobApplicationStatus(int jobApplicationId, int jobApplicaionStatusEnumNumber)
        {
            var jobApplication = await FindJobApplicationById(jobApplicationId);
            jobApplication.Status = (Status)jobApplicaionStatusEnumNumber;
            await UpdateAndSaveJobApplication(jobApplication);
            return _mapper.Map<JobApplicationResponse>(jobApplication);

        }

        private async Task UpdateAndSaveJobApplication(JobApplication jobApplication)
        {
            await _jobApplicationRepository.Update(jobApplication);
        }

        private async Task<JobApplication> FindJobApplicationById(int jobApplicationId)
        {
            var jobApplication = await _jobApplicationRepository.GetById(jobApplicationId);
            jobApplication.ThrowIfNull("Job Application not found");
            return await _jobApplicationRepository.GetById(jobApplicationId);

        }
    }
}