using AutoMapper;
using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Features.Streamers.Commands;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Streamers.Commands.CreateStreamer;

public class CreateStreamerCommandHandlerXUnitTest
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWork> _unitOfWork;
    private readonly Mock<IEmailService> _emailService;
    private readonly Mock<ILogger<CreateStreamerCommandHandler>> _logger;

    public CreateStreamerCommandHandlerXUnitTest()
    {
        var mapperConfig = new MapperConfiguration(c => c.AddProfile<MappingProfile>());
        
        _mapper = mapperConfig.CreateMapper();
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        _emailService = new Mock<IEmailService>();
        _logger = new Mock<ILogger<CreateStreamerCommandHandler>>();
        
        MockStreamerRepository.AddDataStreamerRepository(_unitOfWork.Object.StreamerDbContext);
    }

    [Fact]
    public async Task CreateStreamerCommand_InputStreamer_ReturnNumber()
    {
        var streamerInput = new CreateStreamerCommand
        {
            Nombre = "elpepe streaming",
            Url = "https://www.twitch.com/elpepeTV"
        };

        var handler = new CreateStreamerCommandHandler(_unitOfWork.Object, _mapper, _emailService.Object, _logger.Object);

        var result = await handler.Handle(streamerInput, CancellationToken.None);
        
        result.ShouldBeOfType<int>();
    }

}