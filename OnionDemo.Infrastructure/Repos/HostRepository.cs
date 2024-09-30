using OnionDemo.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;
using System.Data;

namespace OnionDemo.Infrastructure.Repos
{
    public class HostRepository(BookMyHomeContext db) : IHostRepository
    {
        Host IHostRepository.Get(int id)
        {
            return db.Hosts.Single(a => a.Id == id);
        }
    }
}
