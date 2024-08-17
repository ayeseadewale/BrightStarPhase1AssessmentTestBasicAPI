using BrightStarPhase1AssessmentTest.Models;

namespace BrightStarPhase1AssessmentTest.Services.IRepository
{
    public interface ITokenRepository
    {
        Token GetValidToken(string tokenValue, int serviceId);
        void AddToken(Token token);
        void SaveChanges();
    }
}
