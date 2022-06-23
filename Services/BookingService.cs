using BookMyShowAPIDapper.Context;
using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Models;
using Dapper;
using System.Data;

namespace BookMyShowAPIDapper.Services
{
    public class BookingService : IBookingService
    {
        private readonly DapperContext _context;
        public BookingService(DapperContext context)
        {
            _context = context;
        }
        //public async Task<IEnumerable<Booking>> GetBooking(int id)
        //{
        //    var query = "SELECT * FROM Booking WHERE UserId = @Id";
        //    using (var connection = _context.CreateConnection())
        //    {
        //        var bookings = await connection.QueryAsync<Booking>(query);
        //        return bookings.ToList();
        //    }
        //}

        public async Task<Booking> GetParticularBooking(int id)
        {
            var query = "SELECT * from Booking WHERE BookingId = @Id";
            using (var connection = _context.CreateConnection())
            {
                var booking = await connection.QuerySingleOrDefaultAsync<Booking>(query, new { id });
                return booking;
            }
        }
        public async Task<Booking> CreateBooking(BookingDTO booking)
        {
            var query = "INSERT INTO Booking (RequiredSeats, BookingDate, Name, Mobile, ShowId, StartTime, HallId, HallName, MovieId, Title) VALUES (@RequiredSeats, @BookingDate, @Name, @Mobile, @ShowId, @StartTime, @HallId, @HallName, @MovieId, @Title)" + "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("RequiredSeats", booking.RequiredSeats, DbType.Int64);
            parameters.Add("BookingDate", booking.BookingDate, DbType.String);
            parameters.Add("Name", booking.Name, DbType.String);
            parameters.Add("Mobile", booking.Mobile, DbType.String);
            parameters.Add("ShowId", booking.ShowId, DbType.Int64);
            parameters.Add("StartTime", booking.StartTime, DbType.String);
            parameters.Add("HallId", booking.HallId, DbType.Int64);
            parameters.Add("HallName", booking.HallName, DbType.String);
            parameters.Add("MovieId", booking.MovieId, DbType.Int64);
            parameters.Add("Title", booking.Title, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdBooking = new Booking
                {
                    BookingId = id,
                    RequiredSeats = booking.RequiredSeats,
                    BookingDate = booking.BookingDate, 
                    Name = booking.Name,
                    Mobile = booking.Mobile,  
                    ShowId = booking.ShowId,
                    StartTime = booking.StartTime,
                    HallId = booking.HallId,
                    HallName = booking.HallName,
                    MovieId = booking.MovieId,
                    Title = booking.Title
                };
                return createdBooking;
            }
        }

        
    }
}
