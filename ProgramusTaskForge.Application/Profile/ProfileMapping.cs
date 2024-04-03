using ProgromusTaskForge.Application.Dtos.Task;
using ProgromusTaskForge.Domain.Entities.Task;

namespace ProgromusTaskForge.Application.Profile;

public class ProfileMapping : AutoMapper.Profile
{
    public ProfileMapping()
    {
        CreateMap<CreateTaskDto,TaskEntity>();
    }
}