
namespace TaskBooking.Domain.Aggregates.ValueObjects
{
    public class EventDate : ValueObject
    {
        protected EventDate() { }
        public DateTime Date { get; private set; }
        public bool IsTithiBased { get; private set; }
        public string ?Tithi { get; private set; }

        public EventDate(DateTime date, bool isTithiBased, string ?tithi = null)
        {
            Guard.Against.Null(date);
            Date = date;
            IsTithiBased = isTithiBased;
            Tithi = tithi;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Date;
            yield return IsTithiBased;
            yield return Tithi;
        }
    }
}
