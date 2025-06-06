using AutoMapper; // Import AutoMapper namespace
using server.Dto; // Import namespace cho UserDto
using server.Entities; // Đã có

namespace server.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Ánh xạ từ User sang UserDto và ngược lại
            CreateMap<User, UserDto>();
            CreateMap<Image, ImageDtoRes>();
        }
    }
}