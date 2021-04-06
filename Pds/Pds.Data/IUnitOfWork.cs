﻿using System;
using Pds.Data.Repositories.Interfaces;

namespace Pds.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }
        IResourceRepository Resources { get; }
        IContentRepository Content { get; }
        IBrandRepository Brands { get; }
        IClientRepository Clients { get; }
        IBillRepository Bills { get; }
        ILogRepository Logs { get; }

        void Save();
    }
}