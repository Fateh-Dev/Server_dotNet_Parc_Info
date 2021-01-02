using AutoMapper;
using GestionParcInformatique.Dtos.TypeMouvement;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class TypeMouvementsProfile : Profile
    {
        public TypeMouvementsProfile()
        {
            //Source --> Dest
            CreateMap<TypeMouvement, TypeMouvementReadDto>();
            CreateMap<TypeMouvementCreateDto, TypeMouvement>();
            CreateMap<TypeMouvementUpdateDto, TypeMouvement>();
        }
    }
}