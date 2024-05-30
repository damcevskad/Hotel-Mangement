using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Data.Interfaces;
using Trial.Service.Services;
using Xunit.Abstractions;

namespace Trial.Tests.UnitTests
{
    public class GuestTest
    {
        private readonly Mock<IGuestRepository> _mockGuestRepository;
        private readonly GuestService _guestService;

        public GuestTest()
        {
            _mockGuestRepository = new Mock<IGuestRepository>();
            _guestService = new GuestService(_mockGuestRepository.Object);
        }

        [Fact]
        public void GetAllGuests_ShouldReturnAllGuests()
        {
            var guests = new List<Guest>
            {
                new Guest { Id = 1, FirstName = "John", LastName = "Doe" },
                new Guest { Id = 2, FirstName = "Jane", LastName = "Doe" }
            };
            _mockGuestRepository.Setup(repo => repo.GetAllGuests()).Returns(guests);

            var result = _guestService.GetAllGuests();

            Assert.Equal(guests, result);
        }

        [Fact]
        public void GetGuestById_ShouldReturnGuest_WhenGuestExists()
        {
            var guest = new Guest { Id = 1, FirstName = "John", LastName = "Doe" };
            _mockGuestRepository.Setup(repo => repo.GetGuestById(1)).Returns(guest);

            var result = _guestService.GetGuestById(1);

            Assert.Equal(guest, result);
        }

        [Fact]
        public void CreateGuest_ShouldCallRepositoryCreateGuest()
        {
            var guest = new Guest { FirstName = "John", LastName = "Doe" };

            _guestService.CreateGuest(guest);

            _mockGuestRepository.Verify(repo => repo.CreateGuest(guest), Times.Once);
        }
    }
}
