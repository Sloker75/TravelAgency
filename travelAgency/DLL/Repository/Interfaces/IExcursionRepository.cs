using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository.Interfaces
{
    public interface IExcursionRepository
    {
        Task AddExcursionAsync(Excursion excursion, int TourId);
        Task DeleteExcursionAsync(int remExcursionId);
    }
}
