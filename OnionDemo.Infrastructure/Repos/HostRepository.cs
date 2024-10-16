﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;
using System.Data;
using OnionDemo.Application.Interfaces;

namespace OnionDemo.Infrastructure.Repos
{
    public class HostRepository(BookMyHomeContext db) : IHostRepository
    {
        void IHostRepository.Create(Host host)
        {
            db.Hosts.Add(host);
            db.SaveChanges();
        }

        Host IHostRepository.Get(int id)
        {
            return db.Hosts.Single(a => a.Id == id);
        }
    }
}
