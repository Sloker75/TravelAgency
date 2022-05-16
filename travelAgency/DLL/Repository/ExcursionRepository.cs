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
    public class ExcursionRepository : BaseRepository<Excursion>
    {
        public ExcursionRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async override Task<IReadOnlyCollection<Excursion>> FindByConditionAsync(Expression<Func<Excursion, bool>> predicat)
            => await this.Entities.Include(x => x.Tour).Include(x => x.ShowPlaces).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async override Task<IReadOnlyCollection<Excursion>> GetAllAsync() 
            => await this.Entities.Include(x => x.Tour).Include(x => x.ShowPlaces).ToListAsync().ConfigureAwait(false);
    }
}
