using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Service.Interfaces
{
    public interface IRoomService
    {
        IEnumerable<Room> GetAllRooms();
        Room GetRoomById(int id);
        void CreateRoom(Room room);
        void UpdateRoom(int id, Room room);
        void DeleteRoom(int id);
    }
}
