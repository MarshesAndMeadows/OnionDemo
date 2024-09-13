using OnionDemo.Application;
using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Infrastructure.AccommodationInfrastructure
{
    public class AccommodationRepository(BookMyHomeContext db) : IAccommodationRepository
    {
        void IAccommodationRepository.AddAccommodation(Accommodation accommodation)
        {
            db.Accommodations.Add(accommodation);
            db.SaveChanges();
        }
        Accommodation IAccommodationRepository.GetAccommodation(int id)
        {
            return db.Accommodations.Single(a => a.Id == id);
        }
        void IAccommodationRepository.UpdateAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            db.Entry(accommodation).Property(nameof(Accommodation.RowVersion)).OriginalValue = rowVersion;
            db.Accommodations.Update(accommodation);
            db.SaveChanges();
        }
        void IAccommodationRepository.DeleteAccommodation(Accommodation accommodation, byte[] rowVersion)
        {
            db.Entry(accommodation).Property(nameof(Accommodation.RowVersion)).OriginalValue = rowVersion;
            db.Accommodations.Remove(accommodation);
            db.SaveChanges();
        }
    }
}
