using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace OnionDemo.Domain.Entity
{
    public class Host : DomainEntity
    {
        protected Host()
        {
            _accommodations = new List<Accommodation>();
        }

        private Host(string name, List<Accommodation> accommodations)
        {
            Name = name;
            _accommodations = accommodations;
        }

        private List<Accommodation> _accommodations { get; set; }

        public IReadOnlyCollection<Accommodation> Accommodations => _accommodations ?? [];
        public string Name { get; set; }
        public static Host Create(string name)
        {
            return new Host(name, new List<Accommodation>());
        }
        public void AddAccommodation(Accommodation accommodation)
        {
            if (_accommodations == null)
            {
                _accommodations = new List<Accommodation>();
            }
            _accommodations.Add(accommodation);
        }
    }
}
