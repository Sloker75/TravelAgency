using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IExcursionService
    {
        Task<IReadOnlyCollection<Excursion>> GetAllAsync();
        Task AddShowPlaceAsync(ShowPlace showPlace, int excursionId);
        Task DeleteShowPlaceAsync(int remShowPlaceId);
    }
}
