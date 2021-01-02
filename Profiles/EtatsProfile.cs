using AutoMapper;
using GestionParcInformatique.Dtos.Etat;
using GestionParcInformatique.Models;

namespace GestionParcInformatique.Profiles
{
    public class EtatsProfile : Profile
    {
        public EtatsProfile()
        {
            //Source --> Dest
            CreateMap<Etat, EtatReadDto>();
            CreateMap<EtatCreateDto, Etat>();
            CreateMap<EtatUpdateDto, Etat>();
        }
    }
}