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
        private readonly ExcursionRepository _excursionRepository;
        private readonly ShowPlaceRepository _showPlaceRepository;
        public TourService(TourRepository _tourRepository, ReserveRepository _reserveRepository,
            CommentRepository _commentRepository, ExcursionRepository _excursionRepository, ShowPlaceRepository _showPlaceRepository)
        {
            this._tourRepository = _tourRepository;
            this._reserveRepository = _reserveRepository;
            this._commentRepository = _commentRepository;
            this._excursionRepository = _excursionRepository;
            this._showPlaceRepository = _showPlaceRepository;
        }

        public async Task AddComenntAsync(Comment comment, int tourId, string userId)
        {
            comment.UserId = userId;
            await _commentRepository.AddCommentAsync(comment, tourId);
        }

        public async Task AddExcursionAsync(Excursion excursion, int TourId) 
            => await _excursionRepository.AddExcursionAsync(excursion, TourId);

        public async Task AddReserveAsync(string userId, int tourId)
            => await _reserveRepository.AddReserveAsync(userId, tourId);


        public async Task DeleteExcursionAsync(int remExcursionId) 
            => await _excursionRepository.DeleteExcursionAsync(remExcursionId);





        public async Task<IReadOnlyCollection<Tour>> FindByConditionAsync(Expression<Func<Tour, bool>> predicat)
            =>  await _tourRepository.FindByConditionAsync(predicat);


        public async Task<IReadOnlyCollection<Tour>> GetAllAsync() 
            => await _tourRepository.GetAllAsync();
    }
}
