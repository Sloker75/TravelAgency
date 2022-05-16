using DLL.Context;
using DLL.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async override Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> predicat)
            => await this.Entities.Include(x => x.Reserves).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async override Task<IReadOnlyCollection<User>> GetAllAsync()
            => await this.Entities.Include(x => x.Reserves).ToListAsync().ConfigureAwait(false);

    }
}
