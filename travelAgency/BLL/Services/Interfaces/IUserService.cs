using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task DeleteReserveAsync(int remReserveId, string userId);
        Task<Employee> GetEmployeeByUserEmailAsync(string Email);
    }
}
