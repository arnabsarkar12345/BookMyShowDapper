using BookMyShowAPIDapper.DataModels;
using BookMyShowAPIDapper.Models;

namespace BookMyShowAPIDapper.Services
{
    public interface IHallService
    {
        public Task<IEnumerable<Hall>> GetHall(int id);
        public Task<Hall> GetParticularHall(int id);
        public Task UpdateHall(int id, HallDTO hall);
        public Task<Hall> CreateHall(HallDTO hall);
    }
}
