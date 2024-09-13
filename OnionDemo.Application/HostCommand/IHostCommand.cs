using OnionDemo.Application.Command.CommandDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.HostCommand
{
    public interface IHostCommand
    {
        void CreateHost(CreateHostDto createHostDto);
        void UpdateHost(UpdateHostDto updateHostDto);
        void DeleteHost(DeleteHostDto deleteHostDto);
    }
}
