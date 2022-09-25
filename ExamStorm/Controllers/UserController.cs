using AutoMapper;
using ExamStorm.DataManager;
using ExamStorm.DataManager.Interfaces;
using ExamStorm.DataManager.Models;
using ExamStorm.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamStorm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseRepository<UserModel> _userModelRepository;
        private readonly IMapper mapper;

        public UserController(ExamDbContext dbContext, IMapper mapper)
        {
            _userModelRepository = new RepositoryProvider(dbContext).GetUserRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetUsers(int pageSize = 10, int pageIndex = 0)
        {
            var skip = pageIndex > 0 ? pageSize * pageIndex - pageSize : 0;
            var userModels = await _userModelRepository.Get(skip: skip, take: pageSize);
            var userModelDtos = userModels.Select(x => mapper.Map<UserModelDTO>(x)).ToList();
            return Ok(userModelDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(Guid id)
        {
            var userModel = await _userModelRepository.GetByIdAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserModelDTO>(userModel));
        }

        [HttpPost("Update")]
        public async Task<ActionResult<UserModelDTO>> Update(UserModelDTO userModelDTO)
        {
            var userModel = mapper.Map<UserModel>(userModelDTO);
            var updatedUserModel = await _userModelRepository.UpdateAsync(userModel);
            if (updatedUserModel != null)
            {
                return Ok(userModelDTO);
            }
            return base.BadRequest((object)updatedUserModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var user = await _userModelRepository.GetByIdAsync(id);
            var isRemovedSucessfuly = await _userModelRepository.RemoveAsync(user);
            return Ok(isRemovedSucessfuly);
        }
    }
}
