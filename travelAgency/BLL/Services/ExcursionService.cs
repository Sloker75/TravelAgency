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
    public class ExcursionService : IExcursionService
    {
        private readonly ExcursionRepository _excursionRepository;
        private readonly ShowPlaceRepository _showPlaceRepository;
        public ExcursionService(ExcursionRepository excursionRepository, ShowPlaceRepository showPlaceRepository)
        {
            this._excursionRepository = excursionRepository;
            this._showPlaceRepository = showPlaceRepository;
        }

        public async Task<IReadOnlyCollection<Excursion>> GetAllAsync()
            => await _excursionRepository.GetAllAsync();

        public async Task<IReadOnlyCollection<Excursion>> FindByConditionAsync(Expression<Func<Excursion, bool>> predicat)
            => await _excursionRepository.FindByConditionAsync(predicat);

        public async Task AddShowPlaceAsync(ShowPlace showPlace, int excursionId)
            => await _showPlaceRepository.AddShowPlaceAsync(showPlace, excursionId);

        public async Task DeleteShowPlaceAsync(int remShowPlaceId)
            => await _showPlaceRepository.DeleteShowPlaceAsync(remShowPlaceId);
    }
}
