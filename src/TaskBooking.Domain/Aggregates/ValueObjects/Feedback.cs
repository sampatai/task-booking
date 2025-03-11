namespace TaskBooking.Domain.Aggregates.ValueObjects
{
    public class Feedback : ValueObject
    {
        protected Feedback() { }
        
        public string Comments { get; private set; }
        public int Rating { get; private set; }

        public Feedback(string comments, int rating)
        {
            Guard.Against.Null(comments);
            Guard.Against.NegativeOrZero(rating);
            Comments = comments;
            Rating = rating;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Comments;
            yield return Rating;
        }
    }
}
