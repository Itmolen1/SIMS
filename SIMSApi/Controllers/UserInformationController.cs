using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMSApi.GenericRepository;
using SIMSApi.Model;
using SIMSApi.Model.Common;

namespace SIMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        private _GenericInterface<UserInformation> repo = null;
        UserResponseModel userResponseModel;

        public UserInformationController(_GenericInterface<UserInformation> _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var UserList = new List<UserInformation>();

                 UserList = await repo.GetAll();
                if (UserList == null)
                {
                    return NotFound();
                }
                return Ok(UserList);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserInformation user)
        {
            try
            {

                List<UserInformation> userInformations = new List<UserInformation>();
               
                userInformations = await repo.GetAll();
                var userInfo = userInformations.Any(x => x.UserName == user.UserName && x.UserPassword == user.UserPassword);

                //if(userInfo == true)
                //{

                //}

                return Ok(userInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUser(int Id)
        {
            try
            {
                 var result = await repo.GetEntity(Id);
                 return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}