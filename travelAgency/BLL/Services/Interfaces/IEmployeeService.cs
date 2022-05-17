using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task AddTourAsync(Tour tour, int employeeId);
        Task DeleteTourAsync(int remTourId);
        Task ChangeTourAsync(Tour newTour, int oldTourId);

    }
}
