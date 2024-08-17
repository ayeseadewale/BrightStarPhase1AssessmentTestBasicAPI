using BrightStarPhase1AssessmentTest.DAL;
using BrightStarPhase1AssessmentTest.Models;
using BrightStarPhase1AssessmentTest.Services.IRepository;

namespace BrightStarPhase1AssessmentTest.Services.Repository
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly ApplicationDbContext _context;

        public SubscriberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Subscriber GetSubscriber(string phoneNumber, int serviceId)
        {
            return _context.Subscribers.FirstOrDefault(s => s.PhoneNumber == phoneNumber && s.ServiceId == serviceId);
        }

        public void AddSubscriber(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
        }

        public void UpdateSubscriber(Subscriber subscriber)
        {
            _context.Subscribers.Update(subscriber);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
