using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Pelicari.PredictScore.Data.Models;
using Pelicari.PredictScore.Web.API.Dto;
using System;

namespace Pelicari.PredictScore.Web.API.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Team, TeamDto>()
                .ForMember(d => d.LogoUrl, o => o.MapFrom(src => src.Logo))
                .ForMember(d => d.TeamName, o => o.MapFrom(src => src.Name));
            CreateMap<TeamDto, Team>()
                .ForMember(d => d.Logo, o => o.MapFrom(src => src.LogoUrl))
                .ForMember(d => d.Name, o => o.MapFrom(src => src.TeamName));
        }

        public static void Setup(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapping>(), AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
