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
    public class TourRepository : BaseRepository<Tour>, ITourRepository
    {
        public TourRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async Task ChangeTourAsync(Tour newTour, int oldTourId)
        {
            var oldTour = Entities.Find(oldTourId);

            oldTour.Duration = newTour.Duration;
            oldTour.Price = newTour.Price;
            oldTour.TypeTransport = newTour.TypeTransport;
            oldTour.CountPeople = newTour.CountPeople;
            oldTour.EmployeeId = newTour.EmployeeId;
            oldTour.Comments = newTour.Comments;
            oldTour.Hotel = newTour.Hotel;
            oldTour.Excursions = newTour.Excursions;
            oldTour.Reserves = newTour.Reserves;
            oldTour.Employee = newTour.Employee;

            base._travelAgency.Entry(oldTour).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            base._travelAgency.SaveChangesAsync();
        }

        public async Task DeleteTourAsync(int remTourId)
        {
            Entities.Remove(Entities.Find(remTourId));
            base._travelAgency.SaveChangesAsync();
        }

        public async override Task<IReadOnlyCollection<Tour>> FindByConditionAsync(Expression<Func<Tour, bool>> predicat)
            => await this.Entities.Include(x => x.Comments)
            .Include(x => x.Hotel)
            .ThenInclude(x => x.HotelAddress)
            .Include(x => x.Excursions)
            .ThenInclude(x => x.ShowPlaces)
            .Include(x => x.Reserves)
            .Where(predicat).ToListAsync().ConfigureAwait(false);

        public async override Task<IReadOnlyCollection<Tour>> GetAllAsync()
            => await this.Entities.Include(x => x.Comments)
            .Include(x => x.Hotel)
            .ThenInclude(x => x.HotelAddress)
            .Include(x => x.Excursions)
            .ThenInclude(x => x.ShowPlaces)
            .ToListAsync().ConfigureAwait(false);
    }
}
