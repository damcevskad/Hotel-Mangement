using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Data.Interfaces;
using Trial.Service.Interfaces;

namespace Trial.Service.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public IEnumerable<Guest> GetAllGuests()
        {
            return _guestRepository.GetAllGuests();
        }

        public Guest GetGuestById(int id)
        {
            return _guestRepository.GetGuestById(id);
        }

        public void CreateGuest(Guest guest)
        {
            _guestRepository.CreateGuest(guest);
        }

        public void UpdateGuest(int id, Guest guest)
        {
            _guestRepository.UpdateGuest(id, guest);
        }

        public void DeleteGuest(int id)
        {
            _guestRepository.DeleteGuest(id);
        }
    }
}
