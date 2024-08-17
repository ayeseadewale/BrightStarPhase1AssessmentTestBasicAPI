namespace BrightStarPhase1AssessmentTest.Models
{
    public class Subscriber
    {
        public int SubscriberId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public DateTime? UnsubscriptionDate { get; set; }
        public bool IsSubscribed { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
