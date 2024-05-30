using Microsoft.AspNetCore.Mvc;
using Trial.Service.DTO;
using Trial.Service.Interfaces;

namespace Trial.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRooms()
        {
            var rooms = _roomService.GetAllRooms();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public ActionResult<Room> GetRoom(int id)
        {
            var room = _roomService.GetRoomById(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPost]
        public ActionResult<Room> PostRoom([FromBody] Room room)
        {
            _roomService.CreateRoom(room);
            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        [HttpPut("{id}")]
        public IActionResult PutRoom(int id, [FromBody] Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            _roomService.UpdateRoom(id, room);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            var room = _roomService.GetRoomById(id);
            if (room == null)
            {
                return NotFound();
            }

            _roomService.DeleteRoom(id);
            return NoContent();
        }
    }
}
