using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionDemo.Domain.Entity;

namespace OnionDemo.Application.Interfaces
{
    public interface IGuestRepository
    {
        Guest Get(int id);
    }
}
