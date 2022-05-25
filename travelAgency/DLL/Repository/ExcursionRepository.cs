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
    public class ExcursionRepository : BaseRepository<Excursion>, IExcursionRepository
    {
        public ExcursionRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async Task AddExcursionAsync(Excursion excursion, int TourId)
        {
            var tour = base._travelAgency.Tours.Find(TourId);
            tour.Excursions.Add(excursion);
            base._travelAgency.Entry(tour).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await base._travelAgency.SaveChangesAsync();
        }

        public async Task DeleteExcursionAsync(int remExcursionId)
        {
            Entities.Remove(Entities.Find(remExcursionId));
            await base._travelAgency.SaveChangesAsync();
        }


        public async override Task<IReadOnlyCollection<Excursion>> FindByConditionAsync(Expression<Func<Excursion, bool>> predicat)
            => await this.Entities.Include(x => x.Tour).ThenInclude(x => x.Hotel).ThenInclude(x => x.HotelAddress).Include(x => x.ShowPlaces).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async override Task<IReadOnlyCollection<Excursion>> GetAllAsync() 
            => await this.Entities.Include(x => x.Tour).ThenInclude(x => x.Hotel).ThenInclude(x => x.HotelAddress).Include(x => x.ShowPlaces).ToListAsync().ConfigureAwait(false);
    }
}
