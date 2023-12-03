using Microsoft.AspNetCore.Mvc;
using Service.DTOs;
using Service.Interfaces;
using Service.Extensions;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
            _logger.LogInformation("UserController created");
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest userRequest)
        {
            _logger.LogInformation("UserController.Create called");
            try
            {
                userRequest.CheckData();
                _logger.LogInformation(JsonSerializer.Serialize(userRequest));
                await _userService.CreateAsync(userRequest);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            try
            {
                var result = await _userService.GetAllAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}