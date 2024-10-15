using OnionDemo.Application.Commands.CommandDTO.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Commands
{
    public interface IHostCommand
    {
        void Create(createHostDto hostDto);
    }
}
