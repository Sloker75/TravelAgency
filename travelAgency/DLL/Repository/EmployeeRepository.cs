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
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async override Task<IReadOnlyCollection<Employee>> FindByConditionAsync(Expression<Func<Employee, bool>> predicat)
            => await this.Entities.Include(x => x.User).Include(x => x.Tours).ThenInclude(x => x.Hotel).ThenInclude(x => x.HotelAddress).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async override Task<IReadOnlyCollection<Employee>> GetAllAsync()
            => await this.Entities.Include(x => x.User).Include(x => x.Tours).ThenInclude(x => x.Hotel).ThenInclude(x => x.HotelAddress).ToListAsync().ConfigureAwait(false);

    }
}
