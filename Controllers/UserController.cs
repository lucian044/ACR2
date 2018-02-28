using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ACR2.Core;
using ACR2.Core.Models;
using ACR2.Core.Models.Resources;
using ACR2.Models;
using ACR2.Models.Resources;
using ACR2.Persistence;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACR2.Controllers
{
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepo;
        private readonly IUnitOfWork uw;

        public UserController(
            IMapper mapper,
            IUserRepository userRepo,
            IUnitOfWork uw
        )
        {
            this.userRepo = userRepo;
            this.uw = uw;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<UserResource>> GetUsers()
        {
            var users = await userRepo.GetAllUsers();

            return mapper.Map<List<User>, List<UserResource>>(users);

        }

        [HttpPost("new")]
        public async Task<IActionResult> CreateUser([FromBody] SaveUserResource userResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = mapper.Map<SaveUserResource, User>(userResource);

            userRepo.AddUser(user);
            await uw.CompleteAsync();

            var result = mapper.Map<User, UserResource>(user);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userRepo.GetUserById(id);

            if (user == null)
                return NotFound();

            userRepo.RemoveUser(user);
            await uw.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await userRepo.GetUserById(id);

            if (user == null)
                return NotFound();

            var userResource = mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }
    }
}