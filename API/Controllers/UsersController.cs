using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {
    [Authorize]
    public class UsersController : BaseApiController {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers() {
            return Ok(await _userRepository.GetMembersAsync());
        }

        // [HttpGet("{id}")]
        // public async Task<ActionResult<AppUser>> GetUser(int id) {
        //     var user = await _userRepository.GetUserByIDAsync(id);
        //     return user;
        // }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUserByUsername(string username) {
            return Ok(await _userRepository.GetMemberAsync(username));
        }
    }
}