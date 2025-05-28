using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Dto;
using server.Entities;
using server.Helper;
using server.Repository;

namespace server.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHelper _jwtHelper;
        public AuthController(IUserRepository userRepository, IJwtHelper helper)
        {
            this._userRepository = userRepository;
            this._jwtHelper = helper;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<ResponseDto>> Login([FromBody] LoginUserReqDto req)
        {
            User? user = await this._userRepository.GetUserByEmail(req.Email);
            ResponseDto res = new ResponseDto();

            if (user == null)
            {
                res.IsSuccessed = false;
                res.Message = "Invalid Credentials!";
                return BadRequest(res);
            }

            if (!BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
            {
                res.IsSuccessed = false;
                res.Message = "Invalid Credentials!";
                return BadRequest(res);
            }

            LoginUserResDto userDetail = new LoginUserResDto()
            {
                AccessToken = this._jwtHelper.GenerateJwtToken(user)
            };

            res.Data = userDetail;

            return Ok(res);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<ResponseDto>> Register([FromBody] RegisterUserReqDto req)
        {
            User? user = await this._userRepository.GetUserByEmail(req.Email);
            ResponseDto res = new ResponseDto();
            if (user != null)
            {
                res.IsSuccessed = false;
                res.Message = $"User with email {req.Email} already exsist";
                return BadRequest(res);
            }

            User newUser = new User()
            {
                UserName = req.UserName,
                Email = req.Email,
                Address = req.Address,
                Password = BCrypt.Net.BCrypt.HashPassword(req.Password)
            };
            bool result = await this._userRepository.AddUser(newUser);
            if (!result)
            {
                res.IsSuccessed = false;
                res.Message = "User registration failed!";
                return BadRequest(res);
            }
            res.Message = "User registered successfully!";
            return Ok(res);
        }
    }
}
