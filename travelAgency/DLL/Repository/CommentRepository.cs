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
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(TravelAgencyContext _travelAgency) : base(_travelAgency)
        {

        }

        public async Task AddCommentAsync(Comment comment, int tourId)
        {
            var tour = await base._travelAgency.Tours.FindAsync(tourId);
            tour.Comments.Add(comment);
            base._travelAgency.Entry(tour).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await base._travelAgency.SaveChangesAsync();
        }

        public async override Task<IReadOnlyCollection<Comment>> FindByConditionAsync(Expression<Func<Comment, bool>> predicat)
            => await this.Entities.Include(x => x.UserComment).Include(x => x.Tour).ThenInclude(x => x.Hotel).ThenInclude(x => x.HotelAddress).Where(predicat).ToListAsync().ConfigureAwait(false);

        public async override Task<IReadOnlyCollection<Comment>> GetAllAsync() 
            => await this.Entities.Include(x => x.UserComment).Include(x => x.Tour).ThenInclude(x => x.Hotel).ThenInclude(x => x.HotelAddress).ToListAsync().ConfigureAwait(false);


    }
}
