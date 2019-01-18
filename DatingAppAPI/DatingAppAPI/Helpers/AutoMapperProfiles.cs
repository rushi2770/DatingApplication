using AutoMapper;
using DatingAppAPI.DTOs;
using DatingAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDTO>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt =>
                {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });
            CreateMap<User, UserForDetailedDTO>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt =>
                 {
                     opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                 }); 
            CreateMap<Photo, PhotosForDetailedDTO>();

            CreateMap<UserForUpdateDTO, User>();

            CreateMap<Photo, PhotoForReturnDTO>();

            CreateMap<PhotoForCreationDTO, Photo>();

            CreateMap<UserForRegisterDTO, User>();

            CreateMap<MessageForCreationDTO, Message>().ReverseMap();

            CreateMap<Message, MessageToReturnDTO>()
                .ForMember(m => m.SenderPhotoUrl, opt => 
                {
                    opt.MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(m => m.RecipientPhotoUrl, opt =>
                {
                    opt.MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).Url);
                });


        }
    }
}
