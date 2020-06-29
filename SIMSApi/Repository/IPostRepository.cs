using SIMSApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMSApi.Repository
{
    public interface IPostRepository
    {
        Task<List<UserInformation>> GetUsers();

        Task<UserInformation> GetUser(int? Id);

        Task<int> AddPost(UserInformation user);

        Task<int> DeletePost(int? Id);

        Task<UserInformation> UpdatePost(UserInformation user);
    }
}
