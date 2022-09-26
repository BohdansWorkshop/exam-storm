using AutoMapper;
using ExamStorm.DataManager.Models;
using ExamStorm.DataManager.Models.Exam;
using ExamStorm.Models.DTO;

namespace ExamStorm
{
    public class ExamStormAutoMapperProfile : Profile
    {
        public ExamStormAutoMapperProfile()
        {
            CreateMap<UserModelDTO, UserModel>();
            CreateMap<UserModel, UserModelDTO>();
            CreateMap<ExamResultModel, UserExamsResultsDTO>()
                .ForMember(uRes => uRes.QuestionsAmount, m => m.MapFrom(eM => eM.Exam.Questions.Count))
                .ForMember(uRes => uRes.ExamDescription, m => m.MapFrom(eM => eM.Exam.Description));
        }
    }
}
