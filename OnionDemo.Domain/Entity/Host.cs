namespace OnionDemo.Domain.Entity
{
    public class Host : DomainEntity
    {
        public List<Accommodation> Accommodations { get; protected set; }
    }

}
