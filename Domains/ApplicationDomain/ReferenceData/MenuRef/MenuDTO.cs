using ApplicationDomain.AuthenticationDomain.Bindings;
using ApplicationDomain.Entities; 

namespace ApplicationDomain.ReferenceData.MenuRef
{
    public class MenuDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public Country Country { set; get; }
        public int UserId { set; get; }
        public UserBinding User { set; get; }
    }
}
