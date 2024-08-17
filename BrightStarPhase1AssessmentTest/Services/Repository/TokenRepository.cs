using BrightStarPhase1AssessmentTest.DAL;
using BrightStarPhase1AssessmentTest.Models;
using BrightStarPhase1AssessmentTest.Services.IRepository;

namespace BrightStarPhase1AssessmentTest.Services.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ApplicationDbContext _context;

        public TokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Token GetValidToken(string tokenValue, int serviceId)
        {
            return _context.Tokens.FirstOrDefault(t => t.TokenValue == tokenValue && t.ServiceId == serviceId && t.ExpirationDate > DateTime.UtcNow);
        }

        public void AddToken(Token token)
        {
            _context.Tokens.Add(token);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
