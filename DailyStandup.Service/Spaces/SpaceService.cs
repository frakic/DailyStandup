using DailyStandup.Contract.Spaces;
using DailyStandup.Infrastructure.Domain;
using DailyStandup.Model.Spaces;

namespace DailyStandup.Service.Spaces;
public class SpaceService : ISpaceService
{
    private readonly ISpaceRepository _spaceRepository;
    private readonly IUnitOfWork _unitOfWork;
    public SpaceService(ISpaceRepository spaceRepository,
        IUnitOfWork unitOfWork)
    {
        _spaceRepository = spaceRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task CreateAsync(CreateSpaceDto input)
    {
        var space = new Space(input.Name!);

        await _spaceRepository.InsertAsync(space);
        await _unitOfWork.CommitAsync();
    }
}
