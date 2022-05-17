using BLL.Services.Interfaces;
using DLL.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TourService : ITourService
    {
        private readonly TourRepository _tourRepository;
        private readonly ReserveRepository _reserveRepository;
        private readonly CommentRepository _commentRepository;
        public TourService(TourRepository _tourRepository, ReserveRepository _reserveRepository, CommentRepository _commentRepository)
        {
            this._tourRepository = _tourRepository;
            this._reserveRepository = _reserveRepository;
            this._commentRepository = _commentRepository;
        }

        public async Task AddComenntAsync(Comment comment, int tourId, int userId)
        {
            comment.UserId = userId;
            await _commentRepository.AddCommentAsync(comment, tourId);
        }

        public async Task AddReserveAsync(string userId, int tourId)
            => await _reserveRepository.AddReserveAsync(userId, tourId);

        public async Task<IReadOnlyCollection<Tour>> FindByConditionAsync(Expression<Func<Tour, bool>> predicat)
            =>  await _tourRepository.FindByConditionAsync(predicat);
        
        public async Task<List<Tour>> FindByCountPeopleAsync(int countPeople) 
            => (await _tourRepository.FindByConditionAsync(x => x.CountPeople == countPeople)).ToList();

        public async Task<Tour> FindByIdAsync(int Id)
            => (await _tourRepository.FindByConditionAsync(x => x.Id == Id)).First();

        public async Task<List<Tour>> FindByTypeTransportAsync(string typeTransport)
            => (await _tourRepository.FindByConditionAsync(x => x.TypeTransport == typeTransport)).ToList();

        public async Task<List<Tour>> GetAllAsync() 
            => (await _tourRepository.GetAllAsync()).ToList();
    }
}
