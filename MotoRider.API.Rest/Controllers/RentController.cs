using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotoRider.Core.Services.Interfaces;
using MotoRider.Shared.Models;
using System;
using System.Collections.Generic;

namespace MotoRider.API.Rest.Controllers
{
    [Authorize]
    [Route("api/rent")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;

        public RentController(IRentService rentService)
        {
            _rentService = rentService ?? throw new ArgumentNullException(nameof(rentService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Rent>> Get()
        {
            IEnumerable<Rent> rents = _rentService.GetRents();

            if (rents is null)
            {
                return NotFound();
            }

            return Ok(rents);
        }

        [HttpGet("{id}")]
        public ActionResult<Rent> Get(int id)
        {
            Rent rent = _rentService.GetRent(id);

            if (rent is null)
            {
                return NotFound();
            }

            return Ok(rent);
        }

        [HttpPost]
        public ActionResult<bool> Post(Rent rent)
        {
            bool isSuccess = _rentService.InsertRent(rent);

            if (!isSuccess)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Rent rent)
        {
            bool isSuccess = _rentService.UpdateRent(id, rent);

            if (!isSuccess) return BadRequest();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool isSuccess = _rentService.DeleteRent(id);

            if (!isSuccess)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
