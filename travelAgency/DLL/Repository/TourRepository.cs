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
    public class TourRepository : BaseRepository<Tour>
    {
        public TourRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async override Task<IReadOnlyCollection<Tour>> FindByConditionAsync(Expression<Func<Tour, bool>> predicat)
            => await this.Entities.Include(x => x.Comments).Include(x => x.Hotel).Include(x => x.Excursions).Include(x => x.Reserves)
            .Where(predicat).ToListAsync().ConfigureAwait(false);

        public async override Task<IReadOnlyCollection<Tour>> GetAllAsync()
            => await this.Entities.Include(x => x.Hotel).Include(x => x.Excursions).ToListAsync().ConfigureAwait(false);
    }
}
