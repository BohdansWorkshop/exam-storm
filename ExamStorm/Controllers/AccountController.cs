using ExamStorm.Models.DTO;
using ExamStorm.Services.JWTAuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using ExamStorm.DataManager.Models;
using ExamStorm.DataManager;
using ExamStorm.DataManager.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace ExamStorm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IBaseRepository<UserModel> _userModelRepository;
        private readonly IBaseRepository<ExamResultModel> _examResultModelRepository;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly IMapper _mapper;

        public AccountController(ExamDbContext dbContext, IJwtAuthManager jwtAuthManager, IMapper mapper)
        {
            _userModelRepository = new RepositoryProvider(dbContext).GetUserRepository;
            _examResultModelRepository = new RepositoryProvider(dbContext).GetExamResultRepository;
            _jwtAuthManager = jwtAuthManager;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginInfoDTO request)
        {
            var existingUser = await _userModelRepository.GetOneWhereAsync(x=> x.Email == request.Email);
            if(existingUser == null)
            {
                return BadRequest("Wrong username or password");
            }

            var isCorrectPass = BCrypt.Net.BCrypt.Verify(request.Password, existingUser.Password);

            if(!isCorrectPass)
            {
                return BadRequest("Wrong username or password");
            }

            var claims = new[]
           {
                new Claim("Id", existingUser.Id.ToString()),
                new Claim(ClaimTypes.Email,existingUser.Email),
                new Claim(ClaimTypes.Role, existingUser.Role.ToString())
            };

            var existingUserDTO = _mapper.Map<UserModelDTO>(existingUser);
            var jwtResult = _jwtAuthManager.GenerateTokens(existingUser.Email, claims, DateTime.Now);
            return Ok(new
            {
                User = existingUserDTO,
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            var existingUser = await _userModelRepository.GetOneWhereAsync(x => x.Email == userModel.Email);
            if (existingUser != null)
            {
                return BadRequest("User with this email is already registered");
            }

            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);
            var newUser = await _userModelRepository.AddAsync(userModel);
            var resultDTO = _mapper.Map<UserModelDTO>(newUser);
            return Ok(resultDTO);
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // optionally "revoke" JWT token on the server side --> add the current token to a block-list
            // https://github.com/auth0/node-jsonwebtoken/issues/375

            var userName = User.Identity?.Name;
            _jwtAuthManager.RemoveRefreshTokenByUserName(userName);
            return Ok();
        }

        [Authorize]
        [HttpGet("examResults")]
        public async Task<IActionResult> GetExamResults()
        {
            var userId = Guid.Parse(User.Claims.First(x => x.Type == "Id").Value.ToString());
            var examResultsForCurrentUser = await _examResultModelRepository.GetWhereAsync(x => x.User.Id == userId);
            var examResultsDTO = new List<UserExamsResultsDTO>();
            examResultsForCurrentUser.ForEach(x => examResultsDTO.Add(_mapper.Map<UserExamsResultsDTO>(x)));
            return Ok(examResultsDTO);
        }

    }
}
