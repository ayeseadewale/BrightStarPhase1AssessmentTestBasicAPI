using BrightStarPhase1AssessmentTest.DAL;
using BrightStarPhase1AssessmentTest.Models;
using BrightStarPhase1AssessmentTest.Models.DTOs;
using BrightStarPhase1AssessmentTest.Services.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrightStarPhase1AssessmentTest.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SubscriptionController : ControllerBase
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriptionController(ITokenRepository tokenRepository, ISubscriberRepository subscriberRepository)
        {
            _tokenRepository = tokenRepository;
            _subscriberRepository = subscriberRepository;
        }

        [HttpPost("subscribe")]
        public IActionResult Subscribe([FromBody] SubscribeRequest request)
        {
            var token = _tokenRepository.GetValidToken(request.TokenId, request.ServiceId);
            if (token == null)
            {
                return Unauthorized(new { Message = "Invalid or expired token" });
            }

            var existingSubscription = _subscriberRepository.GetSubscriber(request.PhoneNumber, request.ServiceId);

            if (existingSubscription != null && existingSubscription.IsSubscribed)
            {
                return BadRequest(new { Message = "User is already subscribed" });
            }

            if (existingSubscription == null)
            {
                var subscriber = new Subscriber
                {
                    PhoneNumber = request.PhoneNumber,
                    SubscriptionDate = DateTime.UtcNow,
                    IsSubscribed = true,
                    ServiceId = request.ServiceId
                };

                _subscriberRepository.AddSubscriber(subscriber);
                _subscriberRepository.SaveChanges();

                return Ok(new { SubscriptionId = subscriber.SubscriberId });
            }

            existingSubscription.SubscriptionDate = DateTime.UtcNow;
            existingSubscription.IsSubscribed = true;
            _subscriberRepository.UpdateSubscriber(existingSubscription);
            _subscriberRepository.SaveChanges();

            return Ok(new { SubscriptionId = existingSubscription.SubscriberId });
        }

        [HttpPost("unsubscribe")]
        public IActionResult Unsubscribe([FromBody] UnsubscribeRequest request)
        {
            var token = _tokenRepository.GetValidToken(request.TokenId, request.ServiceId);
            if (token == null)
            {
                return Unauthorized(new { Message = "Invalid or expired token" });
            }

            var existingSubscription = _subscriberRepository.GetSubscriber(request.PhoneNumber, request.ServiceId);
            if (existingSubscription == null || !existingSubscription.IsSubscribed)
            {
                return BadRequest(new { Message = "User is not subscribed" });
            }

            existingSubscription.IsSubscribed = false;
            existingSubscription.UnsubscriptionDate = DateTime.UtcNow;
            _subscriberRepository.UpdateSubscriber(existingSubscription);
            _subscriberRepository.SaveChanges();

            return Ok(new { Message = "User unsubscribed successfully" });
        }

        [HttpPost("check-status")]
        public IActionResult CheckStatus([FromBody] CheckStatusRequest request)
        {
            var token = _tokenRepository.GetValidToken(request.TokenId, request.ServiceId);
            if (token == null)
            {
                return Unauthorized(new { Message = "Invalid or expired token" });
            }

            var subscription = _subscriberRepository.GetSubscriber(request.PhoneNumber, request.ServiceId);
            if (subscription == null || !subscription.IsSubscribed)
            {
                return Ok(new { IsSubscribed = false, Message = "User is not subscribed" });
            }

            return Ok(new
            {
                IsSubscribed = true,
                SubscriptionDate = subscription.SubscriptionDate,
                UnsubscriptionDate = subscription.UnsubscriptionDate
            });
        }
    }
}
