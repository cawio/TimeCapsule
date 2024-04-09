using TimeCapsule.WebApi.Contracts.Data;
using TimeCapsule.WebApi.Contracts.Requests;
using TimeCapsule.WebApi.Contracts.Responses;
using TimeCapsule.WebApi.Repositories;

namespace TimeCapsule.WebApi.Services;

public class TimeCapsuleService(TimeCapsuleRepository timeCapsuleRepository)
{
    public async Task<CreateTimeCapsuleResponse> CreateTimeCapsule(CreateTimeCapsuleRequest request)
    {
        var timeCapsule = new Data.Models.TimeCapsule
        {
            Title = request.Title,
            Description = request.Description,
            TimeOfCreation = DateTime.Now,
            TimeOfOpening = request.TimeOfOpening,
        };

        var createdTimeCapsule = await timeCapsuleRepository.CreateTimeCapsule(timeCapsule);

        return new CreateTimeCapsuleResponse
        {
            Id = createdTimeCapsule.Id.ToString(),
            Title = createdTimeCapsule.Title,
            Description = createdTimeCapsule.Description,
            TimeOfCreation = createdTimeCapsule.TimeOfCreation,
            TimeOfOpening = createdTimeCapsule.TimeOfOpening,
        };
    }

    public async Task<GetTimeCapsulesResponse> GetTimeCapsules()
    {
        var timeCapsules = await timeCapsuleRepository.GetTimeCapsules();

        return new GetTimeCapsulesResponse
        {
            TimeCapsules = timeCapsules.Select(tc => new TimeCapsuleDto
            {
                Id = tc.Id.ToString(),
                Title = tc.Title,
                Description = tc.Description,
                TimeOfCreation = tc.TimeOfCreation,
                TimeOfOpening = tc.TimeOfOpening,
            }).ToList(),
        };
    }

    public async Task<GetTimeCapsuleResponse> GetTimeCapsule(int id)
    {
        var timeCapsule = await timeCapsuleRepository.GetTimeCapsule(id);

        if (timeCapsule is null)
        {
            return new GetTimeCapsuleResponse();
        }

        return new GetTimeCapsuleResponse
        {
            Capsule = new TimeCapsuleDto
            {
                Id = timeCapsule.Id.ToString(),
                Title = timeCapsule.Title,
                Description = timeCapsule.Description,
                TimeOfCreation = timeCapsule.TimeOfCreation,
                TimeOfOpening = timeCapsule.TimeOfOpening,
            },
        };
    }
}

public class GetTimeCapsuleResponse
{
}