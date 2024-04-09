using TimeCapsule.WebApi.Contracts.Data;
using TimeCapsule.WebApi.Contracts.Requests;
using TimeCapsule.WebApi.Contracts.Responses;
using TimeCapsule.WebApi.Extensions.Responses;
using TimeCapsule.WebApi.Repositories;

namespace TimeCapsule.WebApi.Services;

public class TimeCapsuleService(TimeCapsuleRepository capsuleRepository)
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

        var createdTimeCapsule = await capsuleRepository.CreateTimeCapsule(timeCapsule);

        return new CreateTimeCapsuleResponse
        {
            Id = createdTimeCapsule.Id.ToString(),
            Title = createdTimeCapsule.Title,
            Description = createdTimeCapsule.Description,
            TimeOfCreation = createdTimeCapsule.TimeOfCreation,
            TimeOfOpening = createdTimeCapsule.TimeOfOpening,
        };
    }

    public async Task<GetAllTimeCapsulesResponse> GetTimeCapsules()
    {
        var timeCapsules = await capsuleRepository.GetTimeCapsules();

        return new GetAllTimeCapsulesResponse
        {
            TimeCapsules = timeCapsules.Select(tc => new TimeCapsuleResponse
            {
                TimeCapsule = new TimeCapsuleDto
                {
                    Id = tc.Id.ToString(),
                    Title = tc.Title,
                    Description = tc.Description,
                    TimeOfCreation = tc.TimeOfCreation,
                    TimeOfOpening = tc.TimeOfOpening,
                },
            }).ToList(),
        };
    }

    public async Task<TimeCapsuleResponse?> GetTimeCapsule(int id)
    {
        var timeCapsule = await capsuleRepository.GetTimeCapsule(id);

        if (timeCapsule == null)
        {
            return null;
        }

        return new TimeCapsuleResponse
        {
            TimeCapsule = new TimeCapsuleDto
            {
                Id = timeCapsule.Id.ToString(),
                Title = timeCapsule.Title,
                Description = timeCapsule.Description,
                TimeOfCreation = timeCapsule.TimeOfCreation,
                TimeOfOpening = timeCapsule.TimeOfOpening,
            },
        };
    }

    public async Task<bool> DeleteTimeCapsule(int id)
    {
        return await capsuleRepository.DeleteTimeCapsule(id);
    }

    public async Task<TimeCapsuleResponse?> UpdateTimeCapsule(UpdateTimeCapsuleRequest request)
    {
        var success = int.TryParse(request.Id, out var parsedId);
        if (!success)
        {
            return null;
        }

        var timeCapsule = await capsuleRepository.GetTimeCapsule(parsedId);
        if (timeCapsule == null)
        {
            return null;
        }

        var updatedTimeCapsule = new Data.Models.TimeCapsule
        {
            Id = parsedId,
            Title = request.Title ?? timeCapsule.Title,
            Description = request.Description ?? timeCapsule.Description,
            TimeOfCreation = timeCapsule.TimeOfCreation,
            TimeOfOpening = request.OpenDate ?? timeCapsule.TimeOfOpening,
        };

        updatedTimeCapsule = await capsuleRepository.UpdateTimeCapsule(updatedTimeCapsule);

        return new TimeCapsuleResponse
        {
            TimeCapsule = new TimeCapsuleDto
            {
                Id = updatedTimeCapsule.Id.ToString(),
                Title = updatedTimeCapsule.Title,
                Description = updatedTimeCapsule.Description,
                TimeOfCreation = updatedTimeCapsule.TimeOfCreation,
                TimeOfOpening = updatedTimeCapsule.TimeOfOpening,
            },
        };
    }
}