using OnionDemo.Application;
using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Infrastructure.AccommodationInfrastructure
{
    public class AccommodationRepository(BookMyHomeContext context) : IAccommodationRepository
    {
        void IAccommodationRepository.AddAccommodation(Accommodation accommodation)
        {
            context.Accommodations.Add(accommodation);
            context.SaveChanges();
        }
        Accommodation IAccommodationRepository.GetAccommodation(int id)
        {
            return context.Accommodations.Single(a => a.Id == id);
        }
        void IAccommodationRepository.UpdateAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            context.Entry(accommodation).Property(nameof(Accommodation.RowVersion)).OriginalValue = rowVersion;
            context.Accommodations.Update(accommodation);
            context.SaveChanges();
        }
        void IAccommodationRepository.DeleteAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            context.Entry(accommodation).Property(nameof(Accommodation.RowVersion)).OriginalValue = rowVersion;
            context.Accommodations.Remove(accommodation);
            context.SaveChanges();
        }
    }
}
