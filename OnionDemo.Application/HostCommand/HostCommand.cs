using OnionDemo.Application.Command.CommandDTO;
using OnionDemo.Application.Command;
using OnionDemo.Application.Helpers;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Application.HostCommand.CommandDTO;

namespace OnionDemo.Application.HostCommand
{
    public class HostCommand(IHostRepository repository) : IHostCommand
    {
        private readonly IUnitOfWork _unitOfWork;


        void IHostCommand.CreateHost(CreateHostDto createHostDto)
        {
            throw new NotImplementedException();
        }

        void IHostCommand.UpdateHost(UpdateHostDto updateHostDto)
        {
            throw new NotImplementedException();
        }

        void IHostCommand.DeleteHost(DeleteHostDto deleteHostDto)
        {
            throw new NotImplementedException();
        }
    }
}