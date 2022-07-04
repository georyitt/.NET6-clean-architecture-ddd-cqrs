using AutoMapper;
using CleanArchitecture.Application.Features.Videos.Queries.GetVideosList;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Infrastructure.Repositories;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Videos.Queries;

public class GetVideosListQueryHandlerXUnitTest
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWork> _unitOfWork;
    
    public GetVideosListQueryHandlerXUnitTest()
    {
        _unitOfWork = MockUnitOfWork.GetUnitOfWork();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        
        _mapper = mapperConfig.CreateMapper();
        
        MockVideoRepository.AddDataVideoRepository(_unitOfWork.Object.StreamerDbContext);
    }

    [Fact]
    public async Task GetVideosListTest()
    {
        var handler = new GetVideosListQueryHandler(_unitOfWork.Object, _mapper);

        var request = new GetVideosListQuery("geory");
        
        var result = await handler.Handle(request, CancellationToken.None);

        result.ShouldBeOfType<List<VideosVm>>();
        result.Count.ShouldBe(1);
        
    }
}