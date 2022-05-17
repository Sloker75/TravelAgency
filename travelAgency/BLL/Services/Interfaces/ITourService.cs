using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ITourService
    {
        Task<List<Tour>> GetAllAsync();
        Task<Tour> FindByIdAsync(int Id);
        Task<List<Tour>> FindByTypeTransportAsync(string typeTransport);
        Task<List<Tour>> FindByCountPeopleAsync(int countPeople);
        Task AddReserveAsync(string userId, int tourId);
        Task AddComenntAsync(Comment comment, int tourId, int userId);
    }
}
