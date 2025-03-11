namespace TaskBooking.Domain.Aggregates.Root
{
    public class TaskRequiredItems : Entity, IAggregateRoot
    {
        protected TaskRequiredItems()
        {
            
        }
        public TaskRequiredItems(string name, List<string> requiredItems)
        {
            PujaRequiredItemId = Guid.NewGuid();
            Name = Guard.Against.NullOrEmpty(name);
            RequiredItems = Guard.Against.Null(requiredItems);
        }
        public Guid PujaRequiredItemId { get; private set; }
        public string Name { get; private set; }
        public List<string> RequiredItems { get; private set; }
    }
}
