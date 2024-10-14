using OnionDemo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.Interfaces;
using System.Text.Json;
using OnionDemo.Infrastructure.Proxy;
using Microsoft.IdentityModel.Tokens;
using System.Web;

namespace OnionDemo.Infrastructure.Repos
{
    public class AccommodationRepository(BookMyHomeContext context, HttpClient client) : IAccommodationRepository
    {
        void IAccommodationRepository.Add(Accommodation accommodation)
        {
            context.Accommodations.Add(accommodation);
            context.SaveChanges();
        }
        void IAccommodationRepository.AddBooking(Accommodation accommodation)
        {
            context.SaveChanges();
        }
        Accommodation IAccommodationRepository.GetAccommodation(int id)
        {
            return context.Accommodations.Include(a => a.Bookings).Single(a => a.Id == id);
        }
        void IAccommodationRepository.UpdateBooking(Booking booking, byte[] rowversion)
        {
            context.Entry(booking).Property(nameof(booking.RowVersion)).OriginalValue = rowversion;
            context.SaveChanges();
        }

        Booking IAccommodationRepository.GetBooking(int id)
        {
            return context.Bookings.Where(a => a.Id == id).Single();
        }

        async Task<bool> IAccommodationRepository.ValidateAddress(string inputAddress)
        {
/*            client.BaseAddress = new Uri("https://api.dataforsyningen.dk/");

            string endpoint = "datavask/adresser";
            string encodedAddress = HttpUtility.UrlEncode(inputAddress);
            string url = $"{endpoint}?betegnelse={encodedAddress}";

            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStreamAsync();
            var adresseResponse = JsonSerializer.Deserialize<AddressResponse>(result);

            // Access the first address and print its ID
            var address = adresseResponse.Results.FirstOrDefault();*/
            return (true);
        }
    }
}
