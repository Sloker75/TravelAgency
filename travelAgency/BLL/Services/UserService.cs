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
    public class UserService : IUserService, IEmployeeService
    {
        private readonly UserRepository _userRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly TourRepository _tourRepository;
        public UserService(UserRepository _userRepository, EmployeeRepository _employeeRepository, TourRepository _tourRepository)
        {
            this._userRepository = _userRepository;
            this._employeeRepository = _employeeRepository;
            this._tourRepository = _tourRepository;
        }

        public async Task AddTourAsync(Tour tour, int employeeId)
        {
            tour.EmployeeId = employeeId;
            await _tourRepository.CreateAsync(tour);
        }

        public async Task AddEmployeeAsync(string UserId)
        {
            await _employeeRepository.CreateAsync(new Employee() {UserId = UserId });
        }

        public async Task<Employee> GetEmployeeByUserEmailAsync(string Email)
        {
            return (await _employeeRepository.FindByConditionAsync(x => x.User.Email == Email)).FirstOrDefault();
        }

        public async Task ChangeTourAsync(Tour newTour, int oldTourId)
            => await _tourRepository.ChangeTourAsync(newTour, oldTourId);


        public async Task DeleteReserveAsync(int remReserveId, string userId) 
            => await _userRepository.DeleteReserveAsync(remReserveId, userId);

        public async Task DeleteTourAsync(int remTourId) 
            => await _tourRepository.DeleteTourAsync(remTourId);

        public async Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> predicat)
            => await _userRepository.FindByConditionAsync(predicat);

        public async Task<List<User>> GetAllUserAsync()
            => (await _userRepository.GetAllAsync()).ToList();

        public async Task<List<Employee>> GetAllEmployeeAsync()
            => (await _employeeRepository.GetAllAsync()).ToList();
    }
}
