using ApplicationDomain.AuthenticationDomain.Bindings;
using ApplicationDomain.Entities;
using AutoMapper;

namespace ApplicationDomain.ReferenceData.AreaRef.Bindings
{
    public class AreaBinding
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public Country Country { set; get; }
        public int UserId { set; get; }
        public UserBinding User { set; get; } 
    }

    public class AreaBindingResponseMapper : Profile
    {
        public AreaBindingResponseMapper()
        {
            CreateMap<Area, AreaBinding>();
        }
    }
}
