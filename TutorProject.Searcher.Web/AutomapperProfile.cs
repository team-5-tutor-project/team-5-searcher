using AutoMapper;
using TutorProject.Account.Common.Models;
using TutorProject.Searcher.BLL.Data;
using TutorProject.Searcher.BLL.Results;
using TutorProject.Searcher.Web.Dto;

namespace TutorProject.Searcher.Web;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<SearcherDto, SearcherData>();
        CreateMap<ScheduleDto, ScheduleData>();
        CreateMap<Tutor, TutorResult>();
        CreateMap<Schedule, ScheduleResult>();
    }
}