using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Data.Interfaces;
using Trial.Service.Interfaces;

namespace Trial.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        public Room GetRoomById(int id)
        {
            return _roomRepository.GetRoomById(id);
        }

        public void CreateRoom(Room room)
        {
            _roomRepository.CreateRoom(room);
        }

        public void UpdateRoom(int id, Room room)
        {
            _roomRepository.UpdateRoom(id, room);
        }

        public void DeleteRoom(int id)
        {
            _roomRepository.DeleteRoom(id);
        }
}
}
