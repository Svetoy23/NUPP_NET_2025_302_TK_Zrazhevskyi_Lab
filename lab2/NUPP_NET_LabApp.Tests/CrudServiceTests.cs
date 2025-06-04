using NUPP_NET_LabApp.Models;
using NUPP_NET_LabApp.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace NUPP_NET_LabApp.Tests
{
    public class CrudServiceTests
    {
        private readonly InMemoryCrudService<Bus> _crudService;

        public CrudServiceTests()
        {
            _crudService = new InMemoryCrudService<Bus>();
        }

        [Fact]
        public async Task CreateAsync_ShouldAddItem()
        {
            var bus = Bus.CreateNew();
            var result = await _crudService.CreateAsync(bus);

            Assert.True(result);
            var retrievedBus = await _crudService.ReadAsync(bus.Id);
            Assert.Equal(bus.Id, retrievedBus?.Id);
        }

        [Fact]
        public async Task SaveAsync_ShouldPersistData()
        {
            var bus = Bus.CreateNew();
            await _crudService.CreateAsync(bus);

            var result = await _crudService.SaveAsync();
            Assert.True(result);
        }
    }
}
