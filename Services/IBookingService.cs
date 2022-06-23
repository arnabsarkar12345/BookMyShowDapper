using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Models;

namespace BookMyShowAPIDapper.Services
{
    public interface IBookingService
    {
        //public Task<IEnumerable<Booking>> GetBooking(int id);
        public Task<Booking> GetParticularBooking(int id);
        public Task<Booking> CreateBooking(BookingDTO booking);
    }
}
