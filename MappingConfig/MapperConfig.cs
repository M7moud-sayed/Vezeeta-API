using AutoMapper;
using VezeetaAPI.DTOs.Patient;
using VezeetaAPI.Models;

namespace VezeetaAPI.MappingConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<PatientRegisterDTO, Patient>()
                    .AfterMap((src, dest) =>
                    {
                        dest.Pname = src.Name;
                        dest.Pemail = src.Email;
                        dest.Pphone = src.Phone;
                        dest.Pgender = src.Gender;
                        dest.PbirthDate = src.BirthDate;
                        dest.Plocation = src.Location;
                        dest.PpasswordHash = BCrypt.Net.BCrypt.HashPassword(src.Password);
                    }).ReverseMap();
        }
    }
}
