using System;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using Domain.Entities;
using Moq;
using Repository.Interfaces;
using Service;
using Service.AutoMapper;
using Service.DTOs.Requests;
using Service.Enums;
using Xunit;

namespace Tests.Service
{
    public class JobApplicationServiceTests
    {
        private readonly Mock<IJobApplicationRepository> _mockRepository;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly Fixture _fixture;
        private readonly JobApplicationService _service;
        private readonly IMapper _mapper;

        public JobApplicationServiceTests()
        {
            _mockRepository = new Mock<IJobApplicationRepository>();
            _userRepository = new Mock<IUserRepository>();
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _mapper = new MapperConfiguration(x => x.AddProfile<AutoMapperConfig>()).CreateMapper();
            _service = new JobApplicationService(_mockRepository.Object, _mapper, _userRepository.Object);
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

        [Fact]
        public async Task GivenAUpdatedDataInAJobApplication_WhenTheAJobApplicationWithTheSameIdExists_ShouldUpdateTheOldInformation()
        {
            var oldJobApplication = _fixture.Build<JobApplication>()
            .With(x => x.Status, Status.Interview)
            .With(x => x.Type, Types.Hybrid)
            .Create();

            var newJobApplication = oldJobApplication;
            newJobApplication.CompanyName = "New Company Name";
            newJobApplication.Role = "New Role";
            newJobApplication.Status = Status.Accepted;

            _mockRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(oldJobApplication);

            var newJobApplicationRequest = new JobApplicationRequest
            {
                CompanyName = newJobApplication.CompanyName,
                Role = newJobApplication.Role,
                Status = (int)newJobApplication.Status,
                Type = (int)newJobApplication.Type!,
                UserId = newJobApplication.UserId
            };

            var result = await _service.UpdateAsync(newJobApplicationRequest, 1);


            Assert.Equal(newJobApplication.CompanyName, result.CompanyName);
            Assert.Equal(newJobApplication.Role, result.Role);
            Assert.Equal(newJobApplication.Status, result.Status);

        }
    }
}