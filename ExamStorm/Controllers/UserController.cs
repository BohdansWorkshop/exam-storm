using ExamStorm.DataManager;
using ExamStorm.DataManager.Interfaces;
using ExamStorm.DataManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ExamStorm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseRepository<UserModel> _userModelRepository;

        public UserController(ExamDbContext dbContext)
        {
            _userModelRepository = new RepositoryProvider(dbContext).GetUserRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(Guid id)
        {
            var userModel = await _userModelRepository.GetByIdAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return Ok(userModel);
        }

        [HttpPut]
        public async Task<ActionResult<UserModel>> Put(UserModel userModel)
        {
            var res = await _userModelRepository.AddOrUpdateAsync(userModel);
            if (res != null)
            {
                return Ok(res);
            }
            return BadRequest(userModel);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await _userModelRepository.GetByIdAsync(id);
            var isRemovedSucessfuly = await _userModelRepository.RemoveAsync(user);
            if (isRemovedSucessfuly)
            {
                return Ok(isRemovedSucessfuly);
            }
            return NotFound();
        }
    }
}
