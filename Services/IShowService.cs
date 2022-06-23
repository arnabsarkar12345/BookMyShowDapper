using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Models;

namespace BookMyShowAPIDapper.Services
{
    public interface IShowService
    {
        public Task<IEnumerable<Show>> GetShow();
        public Task<IEnumerable<Show>> GetShows(int id);
        public Task<Show> GetParticularShow(int id);
        public Task<Show> CreateShow(ShowDTO show);
        public Task DeleteShow(int id);
    }
}
