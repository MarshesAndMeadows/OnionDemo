﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Helpers
{
    public interface IUnitOfWork
    {
        void Commit();

        void Rollback();

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Serializable);

        public byte[] ConvertHexToByteArray(string hex);
    }
}
