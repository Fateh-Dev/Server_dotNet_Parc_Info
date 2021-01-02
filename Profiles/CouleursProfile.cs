using AutoMapper;
using GestionParcInformatique.Dtos.Couleur;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class CouleursProfile : Profile
    {
        public CouleursProfile()
        {
            //Source --> Dest
            CreateMap<Couleur, CouleurReadDto>();
            CreateMap<CouleurCreateDto, Couleur>();
            CreateMap<CouleurUpdateDto, Couleur>();
        }
    }
}