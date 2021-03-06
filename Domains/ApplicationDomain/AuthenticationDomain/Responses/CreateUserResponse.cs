using ApplicationDomain.Common;
using ApplicationDomain.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomain.UserDomain.Responses
{
    public class CreateUserResponse : ResponseBase
    {
        public int Id { set; get; }
    }
}
