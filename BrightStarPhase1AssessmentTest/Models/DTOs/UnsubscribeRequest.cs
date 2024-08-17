namespace BrightStarPhase1AssessmentTest.Models.DTOs
{
    public class UnsubscribeRequest
    {
        public int ServiceId { get; set; }
        public string TokenId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
