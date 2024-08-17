namespace BrightStarPhase1AssessmentTest.Models
{
    public class Token
    {
        public int TokenId { get; set; }
        public string TokenValue { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
