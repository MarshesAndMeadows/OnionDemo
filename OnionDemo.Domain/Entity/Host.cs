namespace OnionDemo.Domain.Entity
{
    public class Host : DomainEntity
    {
        private List<Accommodation> _accommodations { get; set; }

        public IReadOnlyCollection<Accommodation> Accommodations => _accommodations ?? [];

        public IEnumerable<Accommodation> GetAccommodations()
        {
            return Accommodations.AsEnumerable();
        }
    }

}
