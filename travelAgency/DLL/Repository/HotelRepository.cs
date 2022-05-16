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
    public class HotelRepository : BaseRepository<Hotel>
    {
        public HotelRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async override Task<IReadOnlyCollection<Hotel>> FindByConditionAsync(Expression<Func<Hotel, bool>> predicat)
            => await this.Entities.Include(x => x.HotelAddress).Include(x => x.PhotoPath).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async override Task<IReadOnlyCollection<Hotel>> GetAllAsync() 
            => await this.Entities.Include(x => x.HotelAddress).ToListAsync().ConfigureAwait(false);

    }
}
