using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);

        Task<IEnumerable<User>> GetAsync();

        Task<User> GetAsync(Guid id);
    }
}