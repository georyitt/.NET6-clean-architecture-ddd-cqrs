using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CleanArchitecture.Application.UnitTests.Mocks;

public static class MockUnitOfWork
{
    public static Mock<UnitOfWork> GetUnitOfWork()
    {
        var dbContextId = Guid.NewGuid();
        var options = new DbContextOptionsBuilder<StreamerDbContext>()
            .UseInMemoryDatabase(databaseName: $"StreamerDbContext_{dbContextId}")
            .Options;

        var streamerDbContextFake = new StreamerDbContext(options);

        streamerDbContextFake.Database.EnsureDeleted();
        
        var mockUnitOfWork = new Mock<UnitOfWork>(streamerDbContextFake);
        
        return mockUnitOfWork;
    }
}