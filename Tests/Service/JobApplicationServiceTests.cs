using System;
using System.Threading.Tasks;
using AutoFixture;
using Domain.Entities;
using Moq;
using Repository.Interfaces;
using Service;
using Service.DTOs.Requests;
using Service.Enums;
using Xunit;

namespace Tests.Service
{
    public class JobApplicationServiceTests
    {
        private readonly Mock<IJobApplicationRepository> _mockRepository;
        private readonly Fixture _fixture;
        private readonly JobApplicationService _service;

        public JobApplicationServiceTests()
        {
            _mockRepository = new Mock<IJobApplicationRepository>();
            _fixture = new Fixture();
            _service = new JobApplicationService(_mockRepository.Object);
        }

        [Fact]
        public async Task GivenAJobApplicationWithoutACompany_WhenTheCreateFunctionIsCalled_ShouldThrowAnErrorWithAMenssage()
        {
            var jobApplication = _fixture.Build<JobApplicationRequest>()
                .Without(x => x.CompanyName)
                .Create();

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.CreateAsync(jobApplication));
            Assert.Equal("Company name is required", ex.Message);
        }

        [Fact]
        public async Task GivenAJobApplicationWithoutAUserId_WhenTheCreateFunctionIsCalled_ShouldThrowAnErrorWithAMenssage()
        {
            var jobApplication = _fixture.Build<JobApplicationRequest>()
                .Without(x => x.UserId)
                .Create();

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.CreateAsync(jobApplication));
            Assert.Equal("UserId is required", ex.Message);
        }

        [Fact]
        public async Task GivenAJobApplicationWithoutARole_WhenTheCreateFunctionIsCalled_ShouldThrowAnErrorWithAMenssage()
        {
            var jobApplication = _fixture.Build<JobApplicationRequest>()
                .Without(x => x.Role)
                .Create();

            var ex = await Assert.ThrowsAsync<Exception>(() => _service.CreateAsync(jobApplication));
            Assert.Equal("Role is required", ex.Message);
        }

        [Fact]
        public async Task GivenAJobApplicationWithoutAStatus_WhenTheCreateFunctionIsCalled_ShouldThrowAnErrorWithAMenssage()
        {
            var jobApplication = _fixture.Build<JobApplicationRequest>()
                .Without(x => x.Status)
                .With(x => x.Type, 1)
                .Create();

            _mockRepository.Setup(x => x.Create(It.IsAny<JobApplication>()));

            var result = await _service.CreateAsync(jobApplication);

            Assert.Equal(Status.Applied, result.Status);
        }

        [Fact]
        public async Task GivenAJobApplicationWithoutAType_WhenTheValidationFunctionIsCalled_ShouldReturnTheDefaultValueAsRemote()
        {
            var jobApplication = _fixture.Build<JobApplicationRequest>()
                .With(x => x.Status, 1)
                .Without(x => x.Type)
                .Create();

            var result = await _service.CreateAsync(jobApplication);

            Assert.Equal(Types.Remote, result.Type);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(-3)]
        [InlineData(-10)]


        public async Task GivenAJobApplicationWithATypeGreatherThan2OrLessThan0_WhenTheValidationFunctionIsCalled_ShouldThrowAnErrorWithAMenssage(int statusNumber)
        {
            var jobApplication = _fixture.Build<JobApplicationRequest>()
                .With(x => x.Type, statusNumber)
                .Create();

            var ex = await Assert.ThrowsAsync<IndexOutOfRangeException>(() => _service.CreateAsync(jobApplication));
            Assert.Equal("The type must be between 0 and 2", ex.Message);

        }
    }
}