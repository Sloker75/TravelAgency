using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository.Interfaces
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment, int tourId);
    }
}
