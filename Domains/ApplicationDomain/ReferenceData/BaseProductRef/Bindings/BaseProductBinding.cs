using ApplicationDomain.Entities;
using AutoMapper;

namespace ApplicationDomain.ReferenceData.BaseProductRef.Bindings
{
    public class BaseProductBinding
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string ImageUrl { set; get; }
        public bool IsAvailable { set; get; }
        public SubCategory SubCategory { set; get; }
        public Category Category { set; get; }
    }

    public class BaseProductBindingMapper : Profile
    {
        public BaseProductBindingMapper()
        {
            CreateMap<BaseProduct, BaseProductBinding>();
        }
    }
}
