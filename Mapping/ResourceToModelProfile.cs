using System;
using AutoMapper;
using PosiPrice.API.Domain.Models;
using PosiPrice.API.Resources;

namespace PosiPrice.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();

            CreateMap<SaveTagResource, Tag>();
        }
    }
}
