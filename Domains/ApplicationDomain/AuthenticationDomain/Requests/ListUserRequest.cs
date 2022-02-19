using ApplicationDomain.Common;
using AutoMapper;
using FluentValidation;

namespace ApplicationDomain.AuthenticationDomain.Requests
{
    public class ListUserRequest : PaginationRequest
    {
    }
    public class ListUserRequestValidator : AbstractValidator<ListUserRequest>
    {
        public ListUserRequestValidator()
        {
        }
    }

    public class ListUserRequestMapper : Profile
    {
        public ListUserRequestMapper()
        {
        }
    }
}
