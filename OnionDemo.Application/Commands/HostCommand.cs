using OnionDemo.Application.Commands.CommandDTO.Host;
using OnionDemo.Application.Helpers;
using OnionDemo.Application.Interfaces;
using OnionDemo.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Commands
{
    public class HostCommand : IHostCommand
    {
        private readonly IUnitOfWork _uow;
        private readonly IHostRepository _repository;

        public HostCommand (IUnitOfWork uow, IHostRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        void IHostCommand.Create(createHostDto hostDto)
        {
            var host = Host.Create(hostDto.Name);
            _repository.Create(host);
        }
    }
}
