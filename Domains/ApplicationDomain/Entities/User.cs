using ApplicationDomain.Common;
using AspNetCore.Common.Identity;
using AspNetCore.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;

namespace ApplicationDomain.Entities
{
    public class User : IdentityUser<int>, IEntity<int>
    {
		public string Fullname { set; get; }
		public DateTime DateOfBirth { set; get; }
		public bool Gender { set; get; }
		public string AvatarURL { set; get; }
		public UserStatus Status { set; get; }
		public string SearchName { set; get; }
		public int Point { set; get; }
	}

	public class UserMapper : Profile
    {
		public UserMapper()
        {
			CreateMap<User, Dropdown>()
				.ForMember(d => d.Value, opt => opt.MapFrom(s => s.Id))
				.ForMember(d => d.Label, opt => opt.MapFrom(s => s.Fullname));
        }
    }
}