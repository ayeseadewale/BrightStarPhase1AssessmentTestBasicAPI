using BrightStarPhase1AssessmentTest.Models;

namespace BrightStarPhase1AssessmentTest.Services.IRepository
{
    public interface ISubscriberRepository
    {
        Subscriber GetSubscriber(string phoneNumber, int serviceId);
        void AddSubscriber(Subscriber subscriber);
        void UpdateSubscriber(Subscriber subscriber);
        void SaveChanges();
    }
}
