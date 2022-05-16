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
    public class CommentRepository : BaseRepository<Comment>
    {
        public CommentRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async override Task<IReadOnlyCollection<Comment>> FindByConditionAsync(Expression<Func<Comment, bool>> predicat)
            => await this.Entities.Include(x => x.UserComment).Include(x => x.Tour).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async override Task<IReadOnlyCollection<Comment>> GetAllAsync() 
            => await this.Entities.Include(x => x.UserComment).Include(x => x.Tour).ToListAsync().ConfigureAwait(false);


    }
}
