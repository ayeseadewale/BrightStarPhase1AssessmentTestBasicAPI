using BrightStarPhase1AssessmentTest.DAL;
using BrightStarPhase1AssessmentTest.Models;
using BrightStarPhase1AssessmentTest.Models.DTOs;
using BrightStarPhase1AssessmentTest.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BrightStarPhase1AssessmentTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly ITokenRepository _tokenRepository;

        public LoginController(IServiceRepository serviceRepository, ITokenRepository tokenRepository)
        {
            _serviceRepository = serviceRepository;
            _tokenRepository = tokenRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var service = _serviceRepository.GetService(request.ServiceId, request.Password);
            if (service == null)
            {
                return Unauthorized(new { Message = "Invalid Service ID or Password" });
            }

            var existingToken = _tokenRepository.GetValidToken(null, service.ServiceId);
            if (existingToken != null)
            {
                return Ok(new { Token = existingToken.TokenValue });
            }

            var tokenValue = Guid.NewGuid().ToString();
            var expirationHours = 2; // Configurable in DB
            var expirationDate = DateTime.UtcNow.AddHours(expirationHours);

            var token = new Token
            {
                ServiceId = service.ServiceId,
                TokenValue = tokenValue,
                ExpirationDate = expirationDate
            };

            _tokenRepository.AddToken(token);
            _tokenRepository.SaveChanges();

            return Ok(new { Token = tokenValue });
        }
    }
}
