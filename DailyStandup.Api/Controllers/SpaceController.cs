using DailyStandup.Contract.Spaces;
using Microsoft.AspNetCore.Mvc;

namespace DailyStandup.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpaceController : ControllerBase
{
    private readonly ISpaceService _spaceService;

    public SpaceController(ISpaceService spaceService)
    {
        _spaceService = spaceService;
    }

    [HttpPost]
    public async Task CreateAsync([FromBody] CreateUpdateSpaceDto input)
    {
        await _spaceService.CreateAsync(input);
    }
}

