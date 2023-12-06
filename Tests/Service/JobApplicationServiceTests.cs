using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Domain.Entities;
using Moq;
using Repository.Interfaces;
using Service;
using Service.DTOs.Requests;
using Xunit;

namespace Tests.Service
{
    public class JobApplicationServiceTests
    {
        private readonly Mock<IJobApplicationRepository> _mockRepository;
        private readonly Fixture _fixture;
        public JobApplicationServiceTests()
        {
            _mockRepository = new Mock<IJobApplicationRepository>();
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GivenAJobApplicationWithoutACompany_WhenTheCreateFunctionIsCalled_ShouldThrowAnErrorWithAMenssage()
        {
            var jobApplication = _fixture.Build<JobApplicationRequest>()
                .Without(x => x.CompanyName)
                .Create();
            var service = new JobApplicationService(_mockRepository.Object);

            var ex = Assert.ThrowsAsync<Exception>(() => service.CreateAsync(jobApplication));
            Assert.Equal("Company name is required", ex.Result.Message);
        }

        [Fact]
        public async Task GivenAJobApplicationWithoutAUserId_WhenTheCreateFunctionIsCalled_ShouldThrowAnErrorWithAMenssage()
        {
            var jobApplication = _fixture.Build<JobApplicationRequest>()
                .Without(x => x.UserId)
                .Create();
            var service = new JobApplicationService(_mockRepository.Object);

            var ex = Assert.ThrowsAsync<Exception>(() => service.CreateAsync(jobApplication));
            Assert.Equal("UserId is required", ex.Result.Message);
        }

        [Fact]
        public async Task GivenAJobApplicationWithoutARole_WhenTheCreateFunctionIsCalled_ShouldThrowAnErrorWithAMenssage()
        {
            var jobApplication = _fixture.Build<JobApplicationRequest>()
                .Without(x => x.Role)
                .Create();
            var service = new JobApplicationService(_mockRepository.Object);

            var ex = Assert.ThrowsAsync<Exception>(() => service.CreateAsync(jobApplication));
            Assert.Equal("Role is required", ex.Result.Message);
        }

        [Fact]
        public async Task GivenAJobApplicationWithoutAStatus_WhenTheCreateFunctionIsCalled_ShouldThrowAnErrorWithAMenssage()
        {
            var jobApplication = _fixture.Build<JobApplicationRequest>()
                .Without(x => x.Status)
                .Create();
            var service = new JobApplicationService(_mockRepository.Object);

            var ex = Assert.ThrowsAsync<Exception>(() => service.CreateAsync(jobApplication));
            Assert.Equal("Status is required", ex.Result.Message);
        }

        [Fact]
        public async Task GivenAJobApplicationWithoutAType_WhenTheCreateFunctionIsCalled_ShouldThrowAnErrorWithAMenssage()
        {
            var jobApplication = _fixture.Build<JobApplicationRequest>()
                .Without(x => x.Type)
                .Create();
            var service = new JobApplicationService(_mockRepository.Object);

            var ex = Assert.ThrowsAsync<Exception>(() => service.CreateAsync(jobApplication));
            Assert.Equal("Type is required", ex.Result.Message);
        }
    }

}