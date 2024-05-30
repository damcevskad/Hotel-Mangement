using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Trial.Service.Interfaces;

namespace Trial.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        // GET: api/Guest
        [HttpGet]
        public ActionResult<IEnumerable<Guest>> GetGuests()
        {
            var guests = _guestService.GetAllGuests();
            return Ok(guests);
        }

        // GET: api/Guest/5
        [HttpGet("{id}")]
        public ActionResult<Guest> GetGuest(int id)
        {
            var guest = _guestService.GetGuestById(id);

            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }

        // POST: api/Guest
        [HttpPost]
        public ActionResult<Guest> PostGuest([FromBody] Guest guest)
        {
            _guestService.CreateGuest(guest);
            return CreatedAtAction("GetGuest", new { id = guest.Id }, guest);
        }

        // PUT: api/Guest/5
        [HttpPut("{id}")]
        public IActionResult PutGuest(int id, [FromBody] Guest guest)
        {
            if (id != guest.Id)
            {
                return BadRequest();
            }

            _guestService.UpdateGuest(id, guest);
            return NoContent();
        }

        // DELETE: api/Guest/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGuest(int id)
        {
            var guest = _guestService.GetGuestById(id);
            if (guest == null)
            {
                return NotFound();
            }

            _guestService.DeleteGuest(id);
            return NoContent();
        }
    }
}
