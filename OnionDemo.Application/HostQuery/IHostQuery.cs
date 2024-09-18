using OnionDemo.Application.AccommodationQuery.QueryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.HostQuery
{
    public interface IHostQuery
    {
        HostDto GetHost(int id);
        IEnumerable<HostDto> GetHosts();
    }
}
