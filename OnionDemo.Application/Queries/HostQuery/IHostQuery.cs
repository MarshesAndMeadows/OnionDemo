using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Queries.HostQuery
{
    public interface IHostQuery
    {
        HostDto? GetAccommodations(int hostID);
    }
}
