using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task AddReserveAsync(int userId, int tourId);
        Task DeleteReserveAsync(int remReserveId, int userId);
    }
}
