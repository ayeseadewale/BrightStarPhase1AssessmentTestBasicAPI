using BrightStarPhase1AssessmentTest.DAL;
using BrightStarPhase1AssessmentTest.Models;
using BrightStarPhase1AssessmentTest.Services.IRepository;

namespace BrightStarPhase1AssessmentTest.Services.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ApplicationDbContext _context;

        public ServiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Service GetService(int serviceId, string password)
        {
            return _context.Services.FirstOrDefault(s => s.ServiceId == serviceId && s.Password == password);
        }
    }
}
