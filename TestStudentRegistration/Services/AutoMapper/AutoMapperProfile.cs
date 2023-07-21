using AutoMapper;
using TestStudentRegistration.Models;

namespace TestStudentRegistration.Services.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<Student, StudentDTO>().IncludeAllDerived().ReverseMap();
            //CreateMap<Student, StudentAddRequest>().IncludeAllDerived().ReverseMap();
            //CreateMap<Student, object>().IncludeAllDerived().ReverseMap();
            CreateMap<StudentMasterDTO, object>().IncludeAllDerived().ReverseMap();
            CreateMap<StudentMasterDTO, StudentMaster>().IncludeAllDerived().ReverseMap();

            CreateMap<StudentMasterAddRequest, StudentMaster>().IncludeAllDerived().ReverseMap();
            CreateMap<StudentMasterUpdateRequest, StudentMaster>().IncludeAllDerived().ReverseMap();
            CreateMap<StudentMasterUpdateRequest, StudentMasterAddRequest>().IncludeAllDerived().ReverseMap();
        }
    }
}
