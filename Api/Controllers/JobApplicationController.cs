using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Requests;
using Service.DTOs.Responses;
using Service.Interfaces;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;
        public JobApplicationController(IJobApplicationService jobApplicationService)
        {
            _jobApplicationService = jobApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _jobApplicationService.GetAllAsync();
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobApplication(JobApplicationRequest viewModel)
        {
            await _jobApplicationService.CreateAsync(viewModel);
            return Ok();
        }
    }
}