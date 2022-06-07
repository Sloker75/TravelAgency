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
        Task<IReadOnlyCollection<Tour>> GetAllAsync();
        Task AddReserveAsync(string userId, int tourId);
        Task AddComenntAsync(Comment comment, int tourId, string userId);
        Task AddExcursionAsync(Excursion excursion, int TourId);
        Task DeleteExcursionAsync(int remExcursionId);
    }
}
