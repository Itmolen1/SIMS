using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SIMSApi.Model;

namespace SIMSApi.Repository
{
    public class PostRepository : IPostRepository
    {
        SIMSContext db;

        public PostRepository(SIMSContext _db)
        {
            db = _db;
        }

        public async Task<List<UserInformation>> GetUsers()
        {
            try
            {
                if(db != null)
                {
                    return await db.UserInformation.ToListAsync();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> AddPost(UserInformation user)
        {
            try
            {
                if(db != null)
                {
                    await db.UserInformation.AddAsync(user);
                    await db.SaveChangesAsync();

                    return user.Id;
                }

                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeletePost(int? Id)
        {
            int result = 0;
            try
            {
                if(db != null)
                {
                    var UserInfo = await db.UserInformation.FirstOrDefaultAsync(x => x.Id == Id);

                    if(UserInfo != null)
                    {
                        UserInfo.IsActive = false;

                        db.UserInformation.Update(UserInfo);
                        await db.SaveChangesAsync();

                        result = UserInfo.Id;                       
                    }
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }

            throw new NotImplementedException();
        }

        public async Task<UserInformation> GetUser(int? Id)
        {
            try
            {
                if(db != null)
                {
                    return await db.UserInformation.FirstOrDefaultAsync(x=>x.Id == Id);
                    
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task<UserInformation> UpdatePost(UserInformation user)
        {
            try
            {
                if(db != null)
                {
                    db.UserInformation.Update(user);
                    await db.SaveChangesAsync();

                    return await db.UserInformation.FirstOrDefaultAsync(x => x.Id == user.Id);
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
