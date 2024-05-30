using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trial.Data.Interfaces;

namespace Trial.Data.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly TrialDbContext _context;

        public GuestRepository(TrialDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Guest> GetAllGuests()
        {
            return _context.Guests.ToList();
        }

        public Guest GetGuestById(int id)
        {
            return _context.Guests.Find(id);
        }

        public void CreateGuest(Guest guest)
        {
            _context.Guests.Add(guest);
            _context.SaveChanges();
        }

        public void UpdateGuest(int id, Guest guest)
        {
            _context.Entry(guest).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteGuest(int id)
        {
            var guest = _context.Guests.Find(id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                _context.SaveChanges();
            }
        }
    }
}
