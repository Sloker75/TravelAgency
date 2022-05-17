using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task DeleteReserveAsync(int remReserveId, string userId);
    }
}
