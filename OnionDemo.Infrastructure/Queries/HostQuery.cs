using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionDemo.Application.HostQuery;
using OnionDemo.Application.Query.QueryDTO;

namespace OnionDemo.Infrastructure.Queries
{
    public class HostQuery : IHostQuery
    {
        private readonly BookMyHomeContext _db;

        public HostQuery(BookMyHomeContext db)
        {
            _db = db;
        }
        HostDto IHostQuery.GetHost(int id)
        {
            var host = _db.Hosts.AsNoTracking().Single(a => a.Id == id);
            return new HostDto
            {
                Id = host.Id,
                RowVersion = host.RowVersion
            };
        }

        IEnumerable<HostDto> IHostQuery.GetHosts()
        {
            var result = _db.Hosts.AsNoTracking().
                Select(a => new HostDto
                {
                    Id = a.Id,
                });
            return result;
        }
    }
}
