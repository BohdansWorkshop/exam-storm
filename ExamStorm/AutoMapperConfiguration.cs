using AutoMapper;
using ExamStorm.DataManager.Models;
using ExamStorm.ModelsDTO;

namespace ExamStorm
{
    public class ExamStormAutoMapperProfile : Profile
    {
        public ExamStormAutoMapperProfile()
        {
            CreateMap<UserModelDTO, UserModel>();
            CreateMap<UserModel, UserModelDTO>();
        }
    }
}
