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
    public class ReserveRepository : BaseRepository<Reserve>, IReserveRepository
    {
        public ReserveRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async Task AddReserveAsync(string userId, int tourId)
        {
            var user = base._travelAgency.Users.Find(userId);
            var tour = base._travelAgency.Tours.Find(tourId);
            var bookingTime = DateTime.Now;
            if (user != null && tour != null)
            {
                await Entities.AddAsync(new Reserve() { BookingTime = bookingTime, TourReserve = tour, UserReserve = user });
                await base._travelAgency.SaveChangesAsync();
            }

        }

        public async override Task<IReadOnlyCollection<Reserve>> FindByConditionAsync(Expression<Func<Reserve, bool>> predicat)
            => await this.Entities.Include(x => x.TourReserve).Include(x => x.UserReserve).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async override Task<IReadOnlyCollection<Reserve>> GetAllAsync()
            => await this.Entities.Include(x => x.UserReserve)
            .Include(x => x.TourReserve)
            .ThenInclude(x => x.Hotel)
            .ThenInclude(x => x.HotelAddress)
            .ToListAsync().ConfigureAwait(false);

    }
}
