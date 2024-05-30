using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trial.Service.Interfaces
{
    public interface IGuestService
    {
        IEnumerable<Guest> GetAllGuests();
        Guest GetGuestById(int id);
        void CreateGuest(Guest guest);
        void UpdateGuest(int id, Guest guest);
        void DeleteGuest(int id);
    }
}
