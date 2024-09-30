namespace OnionDemo.Domain.Entity
{
    public class Host : DomainEntity
    {
        protected Host(){}

        private Host(string name, List<Accommodation> accommodations)
        {
            Name = name;
            _accommodations = accommodations;
        }

        private List<Accommodation> _accommodations { get; set; }

        public IReadOnlyCollection<Accommodation> Accommodations => _accommodations ?? [];
        public string Name { get; set; }
    }
}
