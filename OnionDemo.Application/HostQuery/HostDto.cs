﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.HostQuery
{
    public class HostDto
    {
        public int Id { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
