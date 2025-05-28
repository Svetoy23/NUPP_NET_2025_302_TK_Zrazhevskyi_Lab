using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Airport.REST.Models;
using Airport.REST.Interfaces;

namespace Airport.REST.Services
{
    public class FlightService : ICrudServiceAsync<FlightModel>
    {
        private readonly List<FlightModel> _flights = new();

        public Task<bool> CreateAsync(FlightModel element)
        {
            element.Id = Guid.NewGuid();
            _flights.Add(element);
            return Task.FromResult(true);
        }

        public Task<FlightModel> ReadAsync(Guid id)
        {
            return Task.FromResult(_flights.Find(f => f.Id == id));
        }

        public Task<IEnumerable<FlightModel>> ReadAllAsync()
        {
            return Task.FromResult<IEnumerable<FlightModel>>(_flights);
        }

        public Task<IEnumerable<FlightModel>> ReadAllAsync(int page, int amount)
        {
            var paged = _flights.Skip((page - 1) * amount).Take(amount);
            return Task.FromResult<IEnumerable<FlightModel>>(paged);
        }

        public Task<bool> UpdateAsync(FlightModel element)
        {
            var index = _flights.FindIndex(f => f.Id == element.Id);
            if (index == -1) return Task.FromResult(false);
            _flights[index] = element;
            return Task.FromResult(true);
        }

        public Task<bool> RemoveAsync(FlightModel element)
        {
            return Task.FromResult(_flights.Remove(element));
        }

        public Task<bool> SaveAsync() => Task.FromResult(true);
    }
}
