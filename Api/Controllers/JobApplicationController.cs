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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _jobApplicationService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _jobApplicationService.DeleteAsync(id);
            return Ok();
        }
        [HttpPut("update_status/{id}")]
        public async Task<IActionResult> Update(int id, int jobApplicaionStatusEnumNumber)
        {
            await _jobApplicationService.UpdateJobApplicationStatus(id, jobApplicaionStatusEnumNumber);
            return Ok();
        }
    }
}