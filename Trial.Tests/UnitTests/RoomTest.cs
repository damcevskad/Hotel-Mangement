using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Data.Interfaces;
using Trial.Service.Services;

namespace Trial.Tests.UnitTests
{
    public class RoomTest
    {
        private readonly Mock<IRoomRepository> _mockRoomRepository;
        private readonly RoomService _roomService;

        public RoomTest()
        {
            _mockRoomRepository = new Mock<IRoomRepository>();
            _roomService = new RoomService(_mockRoomRepository.Object);
        }

        [Fact]
        public void GetAllRooms_ShouldReturnAllRooms()
        {
            var rooms = new List<Room>
            {
                new Room { Id = 1, Number = 101, Floor = 1, Type = "Standard" },
                new Room { Id = 2, Number = 102, Floor = 1, Type = "Deluxe" }
            };
            _mockRoomRepository.Setup(repo => repo.GetAllRooms()).Returns(rooms);

            var result = _roomService.GetAllRooms();

            Assert.Equal(rooms, result);
        }

        [Fact]
        public void GetRoomById_ShouldReturnRoom_WhenRoomExists()
        {
            var room = new Room { Id = 1, Number = 101, Floor = 1, Type = "Standard" };
            _mockRoomRepository.Setup(repo => repo.GetRoomById(1)).Returns(room);

            var result = _roomService.GetRoomById(1);

            Assert.Equal(room, result);
        }

        [Fact]
        public void CreateRoom_ShouldCallRepositoryCreateRoom()
        {
            var room = new Room { Number = 101, Floor = 1, Type = "Standard" };

            _roomService.CreateRoom(room);

            _mockRoomRepository.Verify(repo => repo.CreateRoom(room), Times.Once);
        }
    }
}
