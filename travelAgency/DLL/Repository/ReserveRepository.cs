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
    public class ReserveRepository : BaseRepository<Reserve>
    {
        public ReserveRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async override Task<IReadOnlyCollection<Reserve>> FindByConditionAsync(Expression<Func<Reserve, bool>> predicat)
            => await this.Entities.Include(x => x.Tour).Include(x => x.User).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async override Task<IReadOnlyCollection<Reserve>> GetAllAsync()
            => await this.Entities.Include(x => x.User).Include(x => x.Tour).ToListAsync().ConfigureAwait(false);

    }
}
