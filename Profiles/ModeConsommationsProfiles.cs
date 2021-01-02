using AutoMapper;
using GestionParcInformatique.Dtos.ModeConsommation;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class ModeConsommationsProfile : Profile
    {
        public ModeConsommationsProfile()
        {
            //Source --> Dest
            CreateMap<ModeConsommation, ModeConsommationReadDto>();
            CreateMap<ModeConsommationCreateDto, ModeConsommation>();
            CreateMap<ModeConsommationUpdateDto, ModeConsommation>();
        }
    }
}