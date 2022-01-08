using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using Tasks.Application.Interfaces.Repository;
using Tasks.Domain.Entities;

namespace Tasks.Infrastructure.Repository
{
    public class MissionRepository : Repository<Mission>, IMissionRepository
    {
        public MissionRepository(DbSet<Mission> entity) : base(entity) { }


    }
}
