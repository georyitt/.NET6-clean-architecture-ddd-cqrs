using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Features.Streamers.Commands.UpdateStreamer;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Streamers.Commands.UpdateStreamer;

public class UpdateStreamerCommandHandlerXUnitTest
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWork> _unitOfWork;
    private readonly Mock<ILogger<UpdateStreamerCommandHandler>> _logger;

    public UpdateStreamerCommandHandlerXUnitTest()
    {
        var mapperConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
        
        _mapper = mapperConfig.CreateMapper();
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        _logger = new Mock<ILogger<UpdateStreamerCommandHandler>>();
        
        MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
    }

    [Fact]
    public async Task UpdateStreamerCommand_InputStreamer_ReturnUnit()
    {
        var streamerInput = new UpdateStreamerCommand
        {
            Id = 8001,
            Nombre = "El pepito",
            Url = "elepesito.com"
        };
        
        var handler = new UpdateStreamerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
        var result = await handler.Handle(streamerInput, CancellationToken.None);

        result.ShouldBeOfType<Unit>();
    }
}