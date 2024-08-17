using BrightStarPhase1AssessmentTest.Models;

namespace BrightStarPhase1AssessmentTest.Services.IRepository
{
    public interface IServiceRepository
    {
        Service GetService(int serviceId, string password);
    }
}
