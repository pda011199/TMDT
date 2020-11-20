using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DoAn.Models;
using DoAn.Models.Domain;

namespace DoAn.Helper
{
    public class ModelHelper:Profile
    {
       public ModelHelper()
        {
            CreateMap<UserRegisterModel, User>();
        }
    }
}
