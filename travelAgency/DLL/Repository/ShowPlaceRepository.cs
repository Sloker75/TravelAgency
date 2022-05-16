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
    public class ShowPlaceRepository : BaseRepository<ShowPlace>
    {
        public ShowPlaceRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async override Task<IReadOnlyCollection<ShowPlace>> FindByConditionAsync(Expression<Func<ShowPlace, bool>> predicat)
            => await this.Entities.Include(x => x.PhotoPath).Include(x => x.Excursion).Where(predicat).ToListAsync().ConfigureAwait(false);


        public async override Task<IReadOnlyCollection<ShowPlace>> GetAllAsync() 
            => await this.Entities.Include(x => x.Excursion).ToListAsync().ConfigureAwait(false);
    }
}
