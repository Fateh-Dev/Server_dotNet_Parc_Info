using AutoMapper;
using GestionParcInformatique.Dtos.Marque;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class MarquesProfile : Profile
    {
        public MarquesProfile()
        {
            //Source --> Dest
            CreateMap<Marque, MarqueReadDto>();
            CreateMap<MarqueCreateDto, Marque>();
            CreateMap<MarqueUpdateDto, Marque>();
        }
    }
}