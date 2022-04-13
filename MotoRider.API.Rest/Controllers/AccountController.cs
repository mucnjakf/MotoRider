using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoRider.Core.Services.Interfaces;
using MotoRider.Shared.Models;
using System;

namespace MotoRider.API.Rest.Controllers
{
    [Authorize]
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IUserService userService, IAuthenticationService authenticationService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public ActionResult Authenticate(UserAuthentication userAuthentication)
        {
            string token = _authenticationService.Authenticate(userAuthentication.Username, userAuthentication.Password);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public ActionResult Register(UserAuthentication userAuthentication)
        {
            bool isSuccess = _userService.InsertUser(userAuthentication);

            if (!isSuccess)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
