using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;
using System.Data;
using OnionDemo.Application.Interfaces;

namespace OnionDemo.Infrastructure.Repos
{
    public class GuestRepository(BookMyHomeContext db) : IGuestRepository
    {
        Guest IGuestRepository.Get(int id)
        {
            return db.Guests.Single(a => a.Id == id);
        }
    }
}
