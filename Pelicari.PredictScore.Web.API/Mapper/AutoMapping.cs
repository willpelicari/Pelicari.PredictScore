using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Web.API.Dto;
using System;
using System.Linq;

namespace Pelicari.PredictScore.Web.API.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Schedule, ScheduleDto>();
            CreateMap<ScheduleDto, Schedule>();
            CreateMap<Group, GroupDto>()
                .ForMember(d => d.Containers, o => o.MapFrom(src => src.Users.Select(u => u.Id)));
            CreateMap<GroupDto, Group>()
                .ForMember(d => d.Users, o => o.MapFrom(src => src.Containers.Select(c => new User() { Id = c })));
            CreateMap<Team, TeamDto>()
                .ForMember(d => d.LogoUrl, o => o.MapFrom(src => src.Logo))
                .ForMember(d => d.TeamName, o => o.MapFrom(src => src.Name));
            CreateMap<TeamDto, Team>()
                .ForMember(d => d.Logo, o => o.MapFrom(src => src.LogoUrl))
                .ForMember(d => d.Name, o => o.MapFrom(src => src.TeamName));
            CreateMap<SportDto, Sport>();
            CreateMap<Sport, SportDto>();
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<RoundDto, Round>();
            CreateMap<Round, RoundDto>();
        }

        public static void Setup(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapping>(), AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
