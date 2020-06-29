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
using Microsoft.Extensions.Logging;

namespace SIMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        private IGenericInterface<UserInformation> repo = null;
        private readonly ILogger<UserInformationController> logger;
            
       //readonly UserResponseModel userResponseModel;

        public UserInformationController(IGenericInterface<UserInformation> _repo, ILogger<UserInformationController> _logger)
        {
            repo = _repo;
            logger = _logger;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
               logger.LogInformation("Fetching all the User from the Database");
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

        [HttpPost]
        [Route("ById")]
        public async Task<IActionResult> GetUser(UserInformation userInformation)
        {
            try
            {
                 var result = await repo.GetEntity(userInformation.Id);
                 return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Insert(UserInformation userInformation)
        {
            try
            {
              var Data = await repo.Insert(userInformation);
               return Ok(Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(UserInformation userInformation)
        {
            try
            {
                await repo.Update(userInformation);
                return Ok(userInformation);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}